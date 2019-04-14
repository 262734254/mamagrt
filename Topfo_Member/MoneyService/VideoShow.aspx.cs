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
/// 视频路演
/// </summary>
public partial class MoneyService_VideoShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //会员类型不同提示不同
        if (!Page.User.IsInRole("GT1001"))
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                          " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                               "给予首页和招商频道、投资频道、融资频道路演展示，让更多人关注您！ 此项服务可以延伸到金字塔型政府招商网站、商业网站建设，具体事宜可与专家另行商洽</p> <br />" +
                               " <p class=\"f_black\">" +
                                   "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";


        }
        else
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                                     " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                                          "给予首页和招商频道、投资频道、融资频道路演展示，让更多人关注您！ 此项服务可以延伸到金字塔型政府招商网站、商业网站建设，具体事宜可与专家另行商洽</p> <br />" +
                                          " <p class=\"f_black\">" +
                                              "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";

        }
    }
}
