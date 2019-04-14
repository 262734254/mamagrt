using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Register_MemberRigisterDetailInvest : System.Web.UI.Page
{
    public Tz888.Model.Register.MemberInfoModel model2;
    public Tz888.BLL.Login.LoginInfoBLL obj1;
    public Tz888.BLL.Register.MemberInfoBLL obj2;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");
        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";//正式发布时需改为/MasterPage.master
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        model2 = new Tz888.Model.Register.MemberInfoModel();
        obj1 = new Tz888.BLL.Login.LoginInfoBLL();          //注册信息
        obj2 = new Tz888.BLL.Register.MemberInfoBLL();      //会员信息表

        this.ViewState["LoginMemberName"] = Page.User.Identity.Name; //"bettylee";
        this.ViewState["HeadPortrait"] = "";
        
        if (!IsPostBack)
        {
            //databind();
            databind2();
        }
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
        //update();
        update2();

    }

    #region 20090821 王伟修改

    public void databind2()
    {
        DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'", "LoginName");
        model2 = obj2.GetModel("LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'");

        this.ViewState["ManageTypeID"] = dt1.Rows[0]["ManageTypeID"].ToString();
        if (dt1.Rows.Count > 0)
        {
            txtEmail.Text = dt1.Rows[0]["Email"].ToString();
            lbLoginName.Text = dt1.Rows[0]["LoginName"].ToString();
            if (dt1.Rows[0]["Tel"] != DBNull.Value && dt1.Rows[0]["Tel"].ToString() != "")
            {
                try
                {
                    string[] tel = dt1.Rows[0]["Tel"].ToString().Split('-');
                    txtTelCountry.Text = tel[0].ToString();
                    txtTelZoneCode.Text = tel[1].ToString();
                    txtTelNumber.Text = tel[2].ToString();
                }
                catch
                {
                    txtTelCountry.Text = "+86";
                    txtTelZoneCode.Text = "";
                    //因以前数据格式不同原因，没有用‘-’分格
                    txtTelNumber.Text = dt1.Rows[0]["Tel"].ToString();
                }
            }
            lbNickName.Text = dt1.Rows[0]["NickName"].ToString();
            txtCompany.Text = dt1.Rows[0]["CompanyName"].ToString();
            txtContactTitle.Text = dt1.Rows[0]["ContactTitle"].ToString();
            txtContactName.Text = dt1.Rows[0]["ContactName"].ToString();

            this.ViewState["tag"] = "add";
            if (model2 != null)
            {
                txtMobile.Text = model2.Mobile;
                txtAddress.Text = model2.Address;
                txtPostCode.Text = model2.PostCode;
                this.ViewState["tag"] = "update";
            }
        }
    }

    public void update2()
    {
        string LoginName = this.ViewState["LoginMemberName"].ToString();
        string MemberName = txtCompany.Text.Trim();
        //bool Sex = Convert.ToBoolean(rblSex.SelectedValue);
        string NickName = lbNickName.Text;

        string Address = txtAddress.Text;
        string PostCode = txtPostCode.Text;
        string Mobile = txtMobile.Text;
        string ManageTypeID = this.ViewState["ManageTypeID"].ToString();
        string TelStr = txtTelCountry.Text.Trim() + "-" + txtTelZoneCode.Text.Trim() + "-" + txtTelNumber.Text.Trim();
        string ContactTitle = txtContactTitle.Text.Trim();
        string ContactName = txtContactName.Text.Trim();

        model2.LoginName = lbLoginName.Text.Trim();
        model2.Tel = TelStr.Trim();
        model2.ContactName = txtContactName.Text.Trim();
        model2.ContactTitle = txtContactTitle.Text.Trim();

        model2.MemberName = txtCompany.Text.Trim();
        model2.Address = txtAddress.Text;
        model2.Birthday = DateTime.Now;
        model2.Email = txtEmail.Text;
        model2.Mobile = txtMobile.Text;
        model2.NickName = lbNickName.Text;
        model2.PostCode = txtPostCode.Text;

        int int1 = 0;


        //判断会员信息表里是否己存在,并更新注册表
        if (this.ViewState["tag"].ToString() == "add")
        {
            int1 = obj2.MemberMessage_Insert(model2);
        }
        else if (this.ViewState["tag"].ToString() == "update")
        {
            int1 = obj2.MemberMessage_Update(model2);
        }
        

        //判断登记联系人表里是否己存在       
        //int2 = objInfo2.OrgContactMan_FromMemberMessage(modelInfo2);

        if (int1 > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "信息修改成功！");
        }
    }

    #endregion
    
    #region 20090821 修改前的绑定与修改信息

    public void databind()
    {
        model2 = obj2.GetModel("LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'");


        DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'", "LoginName");
        this.ViewState["ManageTypeID"] = dt1.Rows[0]["ManageTypeID"].ToString();
        if (dt1.Rows.Count > 0)
        {
            txtEmail.Text = dt1.Rows[0]["Email"].ToString();
            lbLoginName.Text = dt1.Rows[0]["LoginName"].ToString();

            if (dt1.Rows[0]["Tel"] != DBNull.Value && dt1.Rows[0]["Tel"].ToString() != "")
            {
                try
                {
                    string[] tel = dt1.Rows[0]["Tel"].ToString().Split('-');
                    txtTelCountry.Text = tel[0].ToString();
                    txtTelZoneCode.Text = tel[1].ToString();
                    txtTelNumber.Text = tel[2].ToString();
                }
                catch
                {
                    txtTelCountry.Text = "+86";
                    txtTelZoneCode.Text = "";
                    //因以前数据格式不同原因，没有用‘-’分格
                    txtTelNumber.Text = dt1.Rows[0]["Tel"].ToString();

                }
            }
            lbNickName.Text = dt1.Rows[0]["NickName"].ToString();
            txtCompany.Text = dt1.Rows[0]["CompanyName"].ToString();
            txtContactTitle.Text = dt1.Rows[0]["ContactTitle"].ToString();
            txtContactName.Text = dt1.Rows[0]["ContactName"].ToString();

            if (model2 != null)
            {
                txtMobile.Text = model2.Mobile;
                txtAddress.Text = model2.Address;
                txtPostCode.Text = model2.PostCode;
            }

            this.ViewState["tag"] = "update";
        }
        else
        {
            this.ViewState["tag"] = "add";
        }
    }

    public void update()
    {
        //注册信息        
        //Tz888.BLL.Login.LoginInfoBLL objInfo1 = new Tz888.BLL.Login.LoginInfoBLL();
        //登记联系人


        //Tz888.BLL.Register.common objInfo2 = new Tz888.BLL.Register.common();
        //Tz888.Model.Register.OrgContactModel modelInfo2 = new Tz888.Model.Register.OrgContactModel();
        //会员信息表


        Tz888.Model.Register.MemberInfoModel modelInfo3 = new Tz888.Model.Register.MemberInfoModel();
        Tz888.BLL.Register.MemberInfoBLL objInfo3 = new Tz888.BLL.Register.MemberInfoBLL();

        string LoginName = this.ViewState["LoginMemberName"].ToString();
        string MemberName = txtCompany.Text.Trim();
        //bool Sex = Convert.ToBoolean(rblSex.SelectedValue);
        string NickName = lbNickName.Text;

        string Address = txtAddress.Text;
        string PostCode = txtPostCode.Text;
        string Mobile = txtMobile.Text;
        string ManageTypeID = this.ViewState["ManageTypeID"].ToString();

        modelInfo3.MemberName = txtCompany.Text.Trim();
        modelInfo3.Address = txtAddress.Text;
        modelInfo3.Birthday = DateTime.Now;
        modelInfo3.Email = txtEmail.Text;
        modelInfo3.Mobile = txtMobile.Text;
        modelInfo3.NickName = lbNickName.Text;
        modelInfo3.PostCode = txtPostCode.Text;

        int int1 = 0;

        //判断会员信息表里是否己存在,并更新注册表
        if (this.ViewState["tag"].ToString() == "add")
        {
            int1 = objInfo3.MemberMessage_Insert(modelInfo3);
        }
        else if (this.ViewState["tag"].ToString() == "update")
        {
            int1 = objInfo3.MemberMessage_Update(modelInfo3);
        }

        if (int1 > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "信息修改成功！");
        }
    }

    #endregion

}
