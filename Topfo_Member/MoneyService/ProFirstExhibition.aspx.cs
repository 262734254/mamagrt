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
/// 项目首页展示
/// </summary>
public partial class MoneyService_ProjectFirstExhibition : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //会员类型不同提示不同
        if (!Page.User.IsInRole("GT1001"))
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                          " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                               "1.展示拓富指数，凸显项目价值或区域优势 2.优先排序，增加关注度 3.有机会获得首页，频道等重点推荐 4.即时刷新自己所发布的需求，展示更靠前。 以上服务都是按年服务,从服务定制之日起计算</p> <br />" +
                               " <p class=\"f_black\">" +
                                   "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";


        }
        else
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                                     " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                                          "1.展示拓富指数，凸显项目价值或区域优势 2.优先排序，增加关注度 3.有机会获得首页，频道等重点推荐 4.即时刷新自己所发布的需求，展示更靠前。 以上服务都是按年服务,从服务定制之日起计算</p> <br />" +
                                          " <p class=\"f_black\">" +
                                              "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";


        }
    }
}
