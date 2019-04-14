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

public partial class Access_Access : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!IsPostBack)
        {
            string InfoID = Request["InfoID"];
            LoginInfoId.Value = InfoID;
            RoleName();
        }
    }
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        //if (isTof)
        //{
        //    Page.MasterPageFile = "/indexTof.master";
        //}
        //else
        //{
        //    Page.MasterPageFile = "/MasterPage.master";
        //}
    }
    private void RoleName()
    {
        if (Page.User.IsInRole("GT1001"))
        {

        MessageID.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                      " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                           "您的级别不够查看访问者信息，如果您想查看信息。</p> <br />" +
                           " <p class=\"f_black\">" +
                               "请点此<a href='#' class=\"lan1\" target=\"_blank\"> 升级VIP会员</a> 或咨询热线：0755-89805588 <a href='http://member.topfo.com/Access/Attention.aspx' class='lan1'>返回>>></p></div>";

        MessageID.Style["display"] = "block";
        sh_con_1.Style["display"] = "none";
        }
        else
        {
            MessageID.Style["display"] = "none";
            sh_con_1.Style["display"] = "block";
        }
    }
}
