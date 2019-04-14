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
using Tz888.BLL.Register;
using Tz888.Model.Register;

public partial class Register_VIPMemberRegister_In : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");
        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.ToString() == "")
        {
            Response.Redirect("../Login.aspx");
        } 
        if (!IsPostBack)
        {
            if (Request.QueryString["ApplyID"] != null && Request.QueryString["ApplyID"].ToString() != "")
            {
               

                int ApplyID = Convert.ToInt32(Request.QueryString["ApplyID"]);
                this.ViewState["tag"] = "update"; //修改
                this.ViewState["ApplyID"] = ApplyID; //修改的ID号
               
               
                getMessageForUpdate(ApplyID); //加载信息
            }
            else
            {
                this.ViewState["tag"] = "add";//默认为添加

                getMessageForAdd();
            }
        }
        ibOK.Attributes.Add("onclick", "return CheckSubmit();");
    }
    protected void ibOK_Click(object sender, ImageClickEventArgs e)
    {
        //获取ManageTypeID
        Tz888.SQLServerDAL.Conn getOpWorker = new Tz888.SQLServerDAL.Conn();
        DataTable dt = getOpWorker.GetList("logininfotab", "*", "ManageTypeID", 1, 1, 0, 1, "loginname='" + Page.User.Identity.Name+"'");

        if (dt!=null&&dt.Rows.Count>0)
        {
            this.ViewState["ManageType"] = dt.Rows[0]["ManageTypeID"].ToString();
        }
        
        Tz888.Model.Register.VIPMemberRegister modelInfo = new Tz888.Model.Register.VIPMemberRegister();
        Tz888.BLL.Register.VIPMemberRegister obj = new Tz888.BLL.Register.VIPMemberRegister();
        modelInfo.LoginName = Page.User.Identity.Name;
        if (dt != null && dt.Rows.Count > 0)
        {
            modelInfo.ManageTypeID = this.ViewState["ManageType"].ToString();
        }
        modelInfo.BuyTerm = Convert.ToInt16(rblBuyTerm.SelectedValue);
        modelInfo.OrgName = tbOrgName.Text;
        modelInfo.RealName = tbRealName.Text;
        modelInfo.Position = tbPosition.Text;//职务
        modelInfo.Sex = Convert.ToBoolean(rblSex.SelectedValue);
        modelInfo.TelCountryCode = txtTelCountry.Text;
        modelInfo.TelStateCode = txtTelZoneCode.Text;
        modelInfo.TelNum = txtTelNumber.Text;
        modelInfo.Mobile = txtMobile.Text;
        modelInfo.Email = txtEmail.Text;
        modelInfo.ApplyDate = DateTime.Now;
        modelInfo.IsPay = 0;//是否付费
        modelInfo.OprStatus = 0;// 审核状态：0未审核、1审核为拓富通会员、2已审核(已审基本信息)、3审核不通过、4退款、 
        modelInfo.OprDescript = "";
        modelInfo.OprMan = "";
        modelInfo.OprDate = DateTime.Now;
        modelInfo.Memo = "";
        modelInfo.MarketPersonName = "";
        modelInfo.VIPValidateDate = DateTime.Now;//生效时间

        if (modelInfo.OrgName == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "公司名称不能为空");
           
            return;
        }
        if (modelInfo.RealName == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "真实姓名不能为空");
           
            return;
        }
        if (modelInfo.Email == "")
        {
            Tz888.Common.MessageBox.Show(this.Page, "Email");
            return;
        }

         bool bl=true;
        try
        {
            if (this.ViewState["tag"].ToString() == "add")
            {
                modelInfo.ApplyID = 0;
                this.ViewState["ApplyID"] = obj.AddVIPMember(modelInfo);
            }
            else if (this.ViewState["tag"].ToString() == "update")
            {
                modelInfo.ApplyID = Convert.ToInt32(this.ViewState["ApplyID"]);
                bl = obj.UpdateVIPMember(modelInfo);
            }
        }
        catch
        {
            Tz888.Common.MessageBox.Show(this.Page,"信息输入有错。。。");
        }

        if (Convert.ToInt32(this.ViewState["ApplyID"]) > 0 && bl==true )
        {
           Response.Redirect("VIPMemberSubmint_In.aspx?ApplyID=" + this.ViewState["ApplyID"]);
        }
    }

    public void getMessageForUpdate(int ApplyID)
    {
        Tz888.BLL.Register.VIPMemberRegister obj = new Tz888.BLL.Register.VIPMemberRegister();
        Tz888.Model.Register.VIPMemberRegister model = new Tz888.Model.Register.VIPMemberRegister();
        model = obj.GetVIPMemberModel(ApplyID);
        if (Page.User.IsInRole("MT2003"))
        {
            managetype.Text = "项目方";
            this.ViewState["ManageType"] = "2003";
        }
        if (Page.User.IsInRole("MT2002")) 
        {
            managetype.Text = "投资机构";
             this.ViewState["ManageType"] = "2002";
        }
        if (Page.User.IsInRole("MT2001")) 
        {
            managetype.Text = "政府机构";
           this.ViewState["ManageType"] = "2001";
        }

        rblBuyTerm.SelectedValue = model.BuyTerm.ToString();
        tbOrgName.Text = model.OrgName;
        tbRealName.Text = model.RealName ;
        tbPosition.Text = model.Position;
        if (model.Sex)
        {
            rblSex.SelectedIndex = 0;
        }
        else
        {
            rblSex.SelectedIndex = 1;
        }
        //rblSex.SelectedValue = model.Sex.ToString();
        txtTelCountry.Text = model.TelCountryCode;
        txtTelZoneCode.Text = model.TelStateCode;
        txtTelNumber.Text = model.TelNum;
        txtMobile.Text = model.Mobile;
        txtEmail.Text = model.Email;
    }

    public void getMessageForAdd()
    {
        Tz888.BLL.Register.common obj1 = new common();
        Tz888.Model.Register.OrgContactModel mod1 = new OrgContactModel();
        Tz888.BLL.Conn obj2 = new Tz888.BLL.Conn();

        string sUserName = Page.User.Identity.Name;

         //会员注册信息MemberInfoVIW
           DataTable dt = obj2.GetList("LoginInfoTab", "ManageTypeID,RealName,Email", "LoginName", 1, 1, 0, 1, "LoginName='"+sUserName+"'");
            if (dt.Rows.Count > 0)
            {
                string InfoManageType = dt.Rows[0]["ManageTypeID"].ToString().Trim();
                if (Page.User.IsInRole("MT2003"))
                {
                    managetype.Text = "项目方";
                    this.ViewState["ManageType"] = "2003";
                }
                if (Page.User.IsInRole("MT2002"))
                {
                    managetype.Text = "投资机构";
                    this.ViewState["ManageType"] = "2002";
                }
                if (Page.User.IsInRole("MT2001"))
                {
                    managetype.Text = "政府机构";
                    this.ViewState["ManageType"] = "2001";
                }

                tbRealName.Text = dt.Rows[0]["RealName"].ToString();
                //rblSex.SelectedValue = dt.Rows[0]["Sex"].ToString();
                DataTable dt1 = obj2.GetList("memberInfoTab", "sex", "LoginName", 1, 1, 0, 1, "LoginName='" + sUserName + "'");
                if (dt != null && dt.Rows.Count > 0)
                {
                    bool bSex = false;
                    if (dt1.Rows[0]["Sex"].ToString()!="")
                    {
                        bSex = Convert.ToBoolean(dt1.Rows[0]["Sex"]);
                    }
                    if (bSex)
                    {
                        rblSex.SelectedIndex = 1;//女

                    }
                    else
                    {
                        rblSex.SelectedIndex = 0;
                    }
                }
               // txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
            }
            
        //会员公司登记信息
        mod1 = obj1.getContactModel(sUserName);
        if (mod1 != null)
        {
            tbOrgName.Text = mod1.OrganizationName;
            tbPosition.Text = mod1.Career;

            txtTelCountry.Text = mod1.TelCountryCode;
            txtTelZoneCode.Text=mod1.TelStateCode;
            txtTelNumber.Text=mod1.TelNum;
        }
    }
}
