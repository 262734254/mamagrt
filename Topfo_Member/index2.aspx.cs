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
using Tz888.BLL;
using Tz888.BLL.Login;





public partial class index : System.Web.UI.Page
{
    string LoginName;
    bool isCheckup;
    string email;
    

    protected void Page_PreInit(object sender, EventArgs e)
    {
       // #if DEBUG
        //System.Web.Security.FormsIdentity id;
        //id = (System.Web.Security.FormsIdentity)("hujie2010");
        //String[] myRoles = new String[4];
        //myRoles[0] = "2001";
        //myRoles[1] = "2002";
        //myRoles[2] = "2003";
        //myRoles[3] = "2004";
        //HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
       // #endif
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
        #if DEBUG
        #else
        
        if (Page.User.Identity.Name == "")
        {
            Response.Redirect("Login.aspx");
        }
        if (Page.User.IsInRole("GT1002"))
        {
            Response.Redirect("indexTof.aspx");
        }
        #endif
        if (!Page.IsPostBack)
        {
            #if DEBUG
            LoginName  ="hujie2010";
#else
            LoginName = Page.User.Identity.Name.Trim();
            #endif
            Tz888.BLL.Conn dal = new Conn();
            DataTable dtUser = dal.GetList("LoginInfoTab", "NickName,isCheckUp,Email", "LoginId", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            Tz888.BLL.Login.LoginInfoBLL bllLoginInfo = new Tz888.BLL.Login.LoginInfoBLL();
            try
            {
                lblUserName.Text = dtUser.Rows[0]["NickName"].ToString();
                isCheckup = Convert.ToBoolean(dtUser.Rows[0]["isCheckUp"].ToString());
                email = dtUser.Rows[0]["Email"].ToString();
            }
            catch
            {
                lblUserName.Text = LoginName.Trim();
                isCheckup = false;
                email = "";
            }

            GetBulletion();
            ShowPublishInfo();
            CheckUsrRes();
            //读取公司登记
            Tz888.BLL.Register.EnterpriseRegisterBLL obj = new Tz888.BLL.Register.EnterpriseRegisterBLL();
            DataTable dt = obj.getEnterpriseModel(LoginName);

            if (dt != null && dt.Rows.Count > 0)
            {
                string strInnerHtml = "";
                //根据会员类型转向不同的登记页面


                if (dt.Rows[0]["AuditingStatus"].ToString() == "0")
                    strInnerHtml = "您的公司/招商机构已经登记，正在审核中。<a href='register/GovernmentRegisterResult.aspx' class='blue'>点击查看</a>";

                if (dt.Rows[0]["AuditingStatus"].ToString() == "1")
                    ShowExhibit();

                if (dt.Rows[0]["AuditingStatus"].ToString() == "2")
                    strInnerHtml = "您的公司/招商机构未通过审核。<a href='register/GovernmentRegisterResult.aspx' class='blue'>点击查看</a>";

                forOrgReg.InnerHtml = strInnerHtml;
            }
            else
            {
                string strInnerHtml = "";
                //根据会员类型转向不同的登记页面



                if (Page.User.IsInRole("MT1003")) //企业  
                {
                    strInnerHtml = " <b>公司登记：</b>您还没有登记公司，无法更好地宣传自己。<span><a href='Register/EnterpriseRegisterResult.aspx' class='blue'>立即登记</a></span>";
                }
                if (Page.User.IsInRole("MT1004")) //机构  
                {
                    strInnerHtml = " <b>机构登记：</b>您还没有登记招商机构，无法更好地宣传自己。<span><a href='Register/EnterpriseRegisterResult.aspx' class='blue'>立即登记</a></span>";
                }
                if (Page.User.IsInRole("MT1001")) //个人
                {
                    strInnerHtml = "";
                }

                forOrgReg.InnerHtml += strInnerHtml;
            }

            string validUrl = "";         //邮箱验证地址

            if (Page.User.IsInRole("MT1003")) //企业  
            {
                validUrl = "Register/ValidEMailEnterprise.aspx?logname={0}&email={1}";
            }
            if (Page.User.IsInRole("MT1004")) //机构  
            {
                validUrl = "Register/ValidEMailGov.aspx?logname={0}&email={1}";
            }
            if (Page.User.IsInRole("MT1001")) //个人
            {
                validUrl = "Register/ValidEMailPersonal.aspx?logname={0}&email={1}";
            }
            if (!isCheckup &&
                (!string.IsNullOrEmpty(LoginName) || !string.IsNullOrEmpty(email)))
            {
                validUrl = validUrl.Replace("{0}", Server.UrlEncode(Tz888.Common.DEncrypt.DEncrypt.Encrypt(LoginName)));
                validUrl = validUrl.Replace("{1}", Server.UrlEncode(Tz888.Common.DEncrypt.DEncrypt.Encrypt(email))) +
                        "&act=" + Tz888.Common.DEncrypt.DEncrypt.Encrypt("valid");
                forOrgReg.InnerHtml += "<br>您还没有进行邮箱验证，为了您的账户安全，请<a class='blue' href='" + validUrl + "' target='_blank'>点此立即验证</a>";
            }
        }
    }
    //重要操作示


    //获取公告
    private void GetBulletion()
    {

        Tz888.BLL.Conn connBll = new Conn();

        DataTable dtB = connBll.GetList("BulletinTab", "content", "infoid", 1, 1, 0, 1, "typeid=8");
        if (dtB.Rows.Count > 0)
        {
            lblBulletin.Text = htmlDecode(dtB.Rows[0]["content"].ToString());
        }
        else
        {
            lblBulletin.Text = "获取公告失败,请联系管理员检查数据源";
        }



    }

    private string htmlDecode(string value)
    {
        value = value.Replace("&lt", "<");
        value = value.Replace("&gt", ">");
        // value = value.Replace("\r", "<br>");

        return value;
    }

    private void ShowPublishInfo()
    {
        if (Page.User.IsInRole("MT1004")) //机构
        {
            GetGovInfo();
        }
        else
        {
            GetOtherInfo();
        }
    }

    //resType: Merchant  Project Capital
    private int GetItemByPara(string resType, string loginName, string auditStatus)
    {
        string strAudit = "";
        if (auditStatus != null)
            strAudit = " and AuditingStatus=" + auditStatus;

        Tz888.BLL.Info.MainInfoBLL mainInfo = new Tz888.BLL.Info.MainInfoBLL();
        try
        {
            DataSet dsTemp = mainInfo.GetList("InfoID", "InfoID", 1, 1, 1, "(InfoTypeID = '" + resType + "') and loginname='" + loginName + "'" + strAudit);
            return dsTemp.Tables[0].Rows.Count;
        }
        catch (Exception exp)
        {
            return 0;
        }


    }

    protected int GetCount(Tz888.BLL.Common.AuditStatus Type)
    {
        //string loginName = CON_LoginName;
        string loginName = Page.User.Identity.Name;

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        return bll.GetCount(Type, loginName, "0");
    }
    //////////////////////////////////////////////////////////////////////////
    private void GetOtherInfo()
    {
        int itemCount = GetItemByPara("Capital' or InfoTypeID='Project", LoginName, null);
        if (itemCount == 0)
        {
            this.forInfo.InnerHtml = "想让更多对口的客户找到您吗？赶紧发布需求吧！<span><a href=\"Publish/publishNavigate.aspx\" class=\"Spaces\">" +
                                    "<img src=\"images_fhy/btn_1.png\" align=\"absmiddle\"></a></span>";
        }
        else
        {
            string content = "";
            int iCount = GetCount(Tz888.BLL.Common.AuditStatus.Auditing); //未审核


            int iCount2 = GetCount(Tz888.BLL.Common.AuditStatus.NoPass);// 2审核未通过
            int iCount3 = GetCount(Tz888.BLL.Common.AuditStatus.Overdue);// 2审核未通过

            if (iCount > 0)
                content = "您有<span class='red_2'>" + iCount.ToString() + "条</span>正在审核中的新需求。<a href='Manage/ResourceManage_Audit.aspx' class='blue'>点击查看</a><br>";
            if (iCount2 > 0)
                content += "您有<span class='red_2'>" + iCount2.ToString() + "条</span>未通过审核的新需求。<a href='Manage/ResourceManage_NoPass.aspx' class='blue'>点击查看</a><br>";
            if (iCount3 > 0)
                content += "您有<span class='red_2'>" + iCount3.ToString() + "条</span>已过期的需求。<a href='Manage/ResourceManage_Overdue.aspx' class='blue'>点击查看</a>";

            this.forInfo.InnerHtml = content;

        }
    }
    //////////////////////////////////////////////////////////////////////////
    private void GetGovInfo()
    {
        int itemCount = GetItemByPara("Merchant", LoginName, null);
        if (itemCount == 0)
        {
            this.forInfo.InnerHtml = "想让更多对口的客户找到您吗？赶紧发布需求吧！<span><a href=\"Publish/publishNavigate.aspx\" class=\"Spaces\">" +
                                    "<img src=\"images_fhy/btn_1.png\" align=\"absmiddle\"></a></span>";
        }
        else
        {
            string content = "";
            int iCount = GetCount(Tz888.BLL.Common.AuditStatus.Auditing); //未审核


            int iCount2 = GetCount(Tz888.BLL.Common.AuditStatus.NoPass); // 2审核未通过
            int iCount3 = GetCount(Tz888.BLL.Common.AuditStatus.Overdue);

            if (iCount > 0)
                content = "您有<span class='red_2'>" + iCount.ToString() + "条</span>正在审核中的新需求。<a href='Manage/ResourceManage_Audit.aspx' class='blue'>点击查看</a><br>";
            if (iCount2 > 0)
                content += "您有<span class='red_2'>" + iCount2.ToString() + "条</span>未通过审核的新需求。<a href='Manage/ResourceManage_NoPass.aspx' class='blue'>点击查看</a><br>";
            if (iCount3 > 0)
                content += "您有<span class='red_2'>" + iCount3.ToString() + "条</span>已过期的需求。<a href='Manage/ResourceManage_Overdue.aspx' class='blue'>点击查看</a>";

            this.forInfo.InnerHtml = content;

        }
    }
    //////////////////////////////////////////////////////////////////////////

    private void CheckUsrRes()
    {

        Tz888.BLL.MemberResourceBLL res = new MemberResourceBLL();
        Tz888.Model.MemberResourceModel resModel = res.GetModel(LoginName);
        if (resModel == null && Page.User.IsInRole("GT1002"))
        {
            this.forSite.InnerHtml += "您还有一些重要的公司资料没有上传，无法让客户完全信任您。点此" +
                        "<a href='Register/EnterpriseRegister_additive.aspx' class='blue'>完善公司资料</a><br>";

        }
    }

    //读取展厅
    private void ShowExhibit()
    {
        System.Collections.Generic.IList<SelfCreateWeb.Model.MSelfCreateWebInfo> list = new SelfCreateWeb.BLL.BSelfCreateWebInfo().GetSelfCreateWebInfo(1, 1, new string[] { "LoginName" }, new string[] { LoginName });
        if (list.Count > 0)
        {
            string siteUrl = "";
           
            if (Page.User.IsInRole("MT1004"))
            {
                siteUrl = "Http://" + list[0].Domain + ".gov.topfo.com";
                forSite.InnerHtml += "您的网上展厅地址为：<a href='" + siteUrl + "' target='_blank'>" + siteUrl +
                    "</a> 点此<a href=\"javascript:document.body.style.behavior='url(#default#homepage)';document.body.setHomePage('" + @siteUrl + "');\" class='blue'>设置为首页</a>";
            }
            if (Page.User.IsInRole("MT1003"))//企业
            {
                siteUrl = "Http://" + list[0].Domain + ".co.topfo.com";
                forSite.InnerHtml += "您的网上展厅地址为：<a href='" + siteUrl + "' target='_blank'>" + siteUrl +
                    "</a> 点此<a href=\"javascript:document.body.style.behavior='url(#default#homepage)';document.body.setHomePage('" + @siteUrl + "');\" class='blue'>设置为首页</a>";
            }
        }
        else
        {
            if (!Page.User.IsInRole("MT1001"))
            {
                forSite.InnerHtml = " <b>网上展厅：</b>您还没有申请网上展厅，无法全面地展示自己!<span><a href='http://co.topfo.com/Manager/intro.aspx' class='blue'>立即创建</a></span>";
            }
            else
            {
                forSite.InnerHtml = "";
            }
        }
    }
}
