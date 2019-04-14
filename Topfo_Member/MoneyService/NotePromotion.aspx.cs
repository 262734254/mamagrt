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
/// <summary>
/// 信息推广
/// </summary>
public partial class MoneyService_NotePromotion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //会员类型不同提示不同
        if (!Page.User.IsInRole("GT1001"))
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                          " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                                "可通过邮箱、站内短信、手机短信等方式面向全球所有有对口需求的行业用户定向投递您的需求，获得全球300万以上行业用户对您的持续关注，拓世界之财富，网全球之商机！</p> <br />" +
                               " <p class=\"f_black\">" +
                                   "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";


        }
        else
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                                     " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                                           "可通过邮箱、站内短信、手机短信等方式面向全球所有有对口需求的行业用户定向投递您的需求，获得全球300万以上行业用户对您的持续关注，拓世界之财富，网全球之商机！</p> <br />" +
                                          " <p class=\"f_black\">" +
                                              "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";

        }
    }
}
