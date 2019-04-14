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

public partial class Register_Test2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //btnOk.Attributes.Add("onclick", "return chkPost();");

        this.ViewState["LoginMemberName"] = "262734254ee"; //Page.User.Identity.Name;
        this.ViewState["HeadPortrait"] = "";
        //注册信息
        Tz888.BLL.Login.LoginInfoBLL obj1 = new Tz888.BLL.Login.LoginInfoBLL();
        //登记联系人
        Tz888.BLL.Register.common obj2 = new Tz888.BLL.Register.common();
        Tz888.Model.Register.OrgContactModel model2 = new Tz888.Model.Register.OrgContactModel();
        //会员信息表
        Tz888.Model.Register.MemberInfoModel model3 = new Tz888.Model.Register.MemberInfoModel();
        Tz888.BLL.Register.MemberInfoBLL obj3 = new Tz888.BLL.Register.MemberInfoBLL();
        model3 = obj3.GetModel("LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'");
        if (!IsPostBack)
        {
            #region 加载获取信息
            this.ZoneSelectControl1.CountryID = model3.CountryCode.ToString().Trim();//国别
            ZoneSelectControl1.CityID = model3.CityID.ToString().Trim();//市
            ZoneSelectControl1.ProvinceID = model3.ProvinceID.ToString().Trim();//省
            ZoneSelectControl1.CountyID = model3.CountyID.ToString().Trim(); //县
            txtAddress.Text = model3.Address.ToString();   //联系地址
            txtEmail.Text = model3.Email.ToString();       //邮箱
            txtContactName.Text = model3.MemberName.ToString();//联系人姓名
            txtMobile.Text = model3.Mobile.ToString();       //手机号码
            txtPostCode.Text = model3.PostCode.ToString().Trim();  //邮编
            txtNickName.Text = model3.NickName.ToString(); //昵称
            DataTable dt1 = obj1.GetLoginInfoList("*", "LoginName='" + this.ViewState["LoginMemberName"].ToString() + "'", "LoginName");
            this.ViewState["ManageTypeID"] = dt1.Rows[0]["ManageTypeID"].ToString();
            model2 = obj2.getContactModel(this.ViewState["LoginMemberName"].ToString());
            if (dt1.Rows.Count > 0)
            {
                //txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                lbLoginName.Text = dt1.Rows[0]["LoginName"].ToString().Trim();

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
                lbManageType.Text = ShenFen(dt1.Rows[0]["ManageTypeID"].ToString().Trim());
                txtCompany.Text = dt1.Rows[0]["CompanyName"].ToString();
                txtContactTitle.Text = dt1.Rows[0]["ContactTitle"].ToString();

                if (model2 != null)
                {
                    txtCompany.Text = model2.OrganizationName;
                }

                this.ViewState["tag"] = "update";
            }
            else
            {
                this.ViewState["tag"] = "add";
            }
            #endregion
        }
    }

    protected void IbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string zone = txtTelCountry.Text.ToString().Trim();
        string country = txtTelZoneCode.Text.ToString().Trim();
        string tel = txtTelNumber.Text.ToString().Trim();
        string phone = zone + "-" + country + "-" + tel;
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
        string NickName = txtNickName.Text;
        string Address = txtAddress.Text;
        string PostCode = txtPostCode.Text;
        string Mobile = txtMobile.Text;
        string ManageTypeID = this.ViewState["ManageTypeID"].ToString();
        modelInfo3.LoginName = LoginName;   //登录名
        modelInfo3.CountryCode = ZoneSelectControl1.CountryID.ToString().Trim();
        modelInfo3.CityID = ZoneSelectControl1.CityID.ToString().Trim();
        modelInfo3.ProvinceID = ZoneSelectControl1.ProvinceID.ToString().Trim();
        modelInfo3.CountyID = ZoneSelectControl1.CountyID.ToString().Trim();
        modelInfo3.MemberName = txtContactName.Text.Trim();   //联系人姓名
        modelInfo3.Address = txtAddress.Text;    //地址
        modelInfo3.Birthday = DateTime.Now;      //日期
        modelInfo3.Email = txtEmail.Text;        //邮箱
        modelInfo3.Mobile = txtMobile.Text;      //手机
        modelInfo3.NickName = txtNickName.Text;   //昵称
        modelInfo3.PostCode = txtPostCode.Text.ToString().Trim(); ;  //邮编
        modelInfo3.Tel = phone.Trim();  //电话
        modelInfo3.ContactName = txtCompany.Text.ToString().Trim();  //招商机构名称
        modelInfo3.ContactTitle = txtContactTitle.Text.ToString().Trim(); //职位
        int int1 = 0;
        long int2 = 0;
        //判断会员信息表里是否己存在,并更新注册表
        if (this.ViewState["tag"].ToString() == "add")
        {
            int1 = objInfo3.MemberMessage_Insert(modelInfo3);
        }
        else if (this.ViewState["tag"].ToString() == "update")
        {
            int1 = objInfo3.MemberMessage_Update(modelInfo3);
        }
        //判断登记联系人表里是否己存在       
        //int2 = objInfo2.OrgContactMan_FromMemberMessage(modelInfo2);
        Tz888.BLL.Register.LoginInfoBLL dal1 = new Tz888.BLL.Register.LoginInfoBLL();
        int resultproperty = dal1.UpdateLoginPropertyID(this.ViewState["LoginMemberName"].ToString(), -1, 2001);

        if (int1 > 0)
        {
            Tz888.Common.MessageBox.Show(this.Page, "信息修改成功！");
        }

    }

    #region 身份类型判断
    /// <summary>
    /// 身份类型判断
    /// </summary>
    /// <param name="ManageTypeID"></param>
    /// <returns></returns>
    public string ShenFen(string ManageTypeID)
    {
        string str = "";
        if (ManageTypeID == "2001")
        {
            str = "政府招商";
        }
        else if (ManageTypeID == "2002")
        {
            str = "投资方";
        }
        else if (ManageTypeID == "2003")
        {
            str = "项目方";
        }
        else if (ManageTypeID == "2004")
        {
            str = "中介机构";
        }
        else if (ManageTypeID == "2007")
        {
            str = "专业服务机构";
        }
        return str;
    }
    #endregion
}
