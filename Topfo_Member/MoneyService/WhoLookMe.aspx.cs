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
/// 谁看过我
/// </summary>
public partial class MoneyService_WhoLookMe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //会员类型不同提示不同
        if (!Page.User.IsInRole("GT1001"))
        {
            showMessage.InnerHtml = "<img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                          " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                               "谁看过我可以让您第一时间掌握先机，获得对口资源和资讯,这是中国招商投资网专门为您提供的一项增值服务。</p> <br />" +
                               " <p class=\"f_black\">" +
                                   "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";


        }
        else
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                                     " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                                          "谁看过我可以让您第一时间掌握先机，获得对口资源和资讯,这是中国招商投资网专门为您提供的一项增值服务。</p> <br />" +
                                          " <p class=\"f_black\">" +
                                              "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";

        }
    }
}
