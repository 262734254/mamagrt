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
/// 专题推广
/// </summary>
public partial class MoneyService_SubjectPromotion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //会员类型不同提示不同
        if (!Page.User.IsInRole("GT1001"))
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                          " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                               "1.招商、投融资专家同您联系并为您量身定制、精心优选，针对您的需求推荐优质资源，并由业界资深专家引领您拜访对口资源机构。 2.优先推荐给对口客户进行深度专业运作。 3.通过站内短消息和邮箱和手机接收配对结果通知，专业促进招商、投资、融资，成功更有保障！ 此项资源服务可以打包成“小型招商投融资对接会”、“项目猎头”等活动，具体事宜可与专家另行商洽。</p> <br />" +
                               " <p class=\"f_black\">" +
                                   "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";


        }
        else
        {
            showMessage.InnerHtml = "  <img src='http://img2.topfo.com/member/images/dingyun.jpg' class=\"fl\" />" +
                                     " <div class=\"fbcg1-1\"><p class=\"f_14px lanl\">" +
                                        "1.招商、投融资专家同您联系并为您量身定制、精心优选，针对您的需求推荐优质资源，并由业界资深专家引领您拜访对口资源机构。 2.优先推荐给对口客户进行深度专业运作。 3.通过站内短消息和邮箱和手机接收配对结果通知，专业促进招商、投资、融资，成功更有保障！ 此项资源服务可以打包成“小型招商投融资对接会”、“项目猎头”等活动，具体事宜可与专家另行商洽。</p> <br />" +
                                        " <p class=\"f_black\">" +
                                              "点此了解<a href='http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml' class=\"lan1\" target=\"_blank\"> 拓富通服务详情</a> 咨询热线：0755-89805588</p></div>";

        }
    }
}
