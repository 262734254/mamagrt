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
using System.Text;
using Tz888.SQLServerDAL;

public partial class Message_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();

        string address = "ypz@topfo.com";
        string titel = "创业资本";
        string bodys = "创业资本创业资本创业资本创业资本创业资本创业资本创业资本创业资本";
        StringBuilder sb = new StringBuilder();
        sb.Append("<body bgcolor=\"#FFFFFF\" leftmargin=\"0\" topmargin=\"0\" marginwidth=\"0\" marginheight=\"0\">");
        sb.Append("<table width=\"668\" height=\"895\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
        sb.Append("<tr>");
        sb.Append("<td colspan=\"3\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_01.jpg\" width=\"668\" height=\"1\" alt=\"d\"></td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td colspan=\"3\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_02.jpg\" alt=\"gg\" width=\"668\" height=\"146\" border=\"0\" usemap=\"#Map\"></td>");
        sb.Append("</tr>");


        sb.Append("<tr>");
        sb.Append("<td colspan=\"3\" valign=\"top\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_03.jpg\" width=\"668\" height=\"188\" alt=\"hh\"></td>");
        sb.Append("</tr>");


        sb.Append("<tr valign=\"middle\">");
        sb.Append("<td width=\"25\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_04.jpg\" width=\"25\" height=\"82\" alt=\"y\"></td>");

        sb.Append("<td width=\"614\">");

        sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");

        sb.Append("<tr>");
        sb.Append("<td height=\"25\" colspan=\"2\" style=\" color:#333333; font-size: 13px; font-weight:bolder;\">尊敬的用户：中国招商投资网（Http://www.topfo.com）提醒您：您收到2条推荐的资源。</td>");
        sb.Append("</tr>");
        sb.Append("<tr>");
        sb.Append("<td width=\"76%\" height=\"25\" style=\" color:#333333; font-size: 13px; font-weight:bolder;\">　　　　　　推荐的资源与您的需求非常匹配，请及时把握商机。</td>");
        sb.Append("<td width=\"24%\"><img src=\"http://www.topfo.com/ADPage/yjtg/tt_08.jpg\" width=\"100\" height=\"25\"></td>");
        sb.Append("</tr>");
        sb.Append("</table>");
        sb.Append("</td>");
        sb.Append("<td>");
        sb.Append("<div align=\"right\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_06.jpg\" width=\"29\" height=\"82\" alt=\"g\"></div>");
        sb.Append("</td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td colspan=\"3\" valign=\"top\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_07.jpg\" width=\"668\" height=\"21\" alt=\"h\"></td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td colspan=\"3\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_08.jpg\" width=\"668\" height=\"38\" alt=\"\"></td>");
        sb.Append("</tr>");

        sb.Append("<tr>");
        sb.Append("<td><img src=\"http://www.topfo.com/ADPage/yjtg/index_09.jpg\" width=\"25\" height=\"124\" alt=\"\"></td>");
        sb.Append("<td background=\"http://www.topfo.com/ADPage/yjtg/index_10.jpg\">");
        sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");


        sb.Append("<tr><td style=\" color:#b40000; font-size:16px; font-weight:bolder;\">新一轮信贷找优质企业项目</td></tr>");
        sb.Append("<tr>");

        sb.Append("</tr>");
        sb.Append("<td style=\" font-size:12px; line-height:18px; padding-top:5px;\"><strong>项目摘要:</strong>新一轮信贷找优质企业项目新一轮信贷找优质企业项目新一轮信贷找优质企业项目新一轮信贷找优质企业项目新一轮信贷找优质企业项目。新一轮信贷找优质企业项目新一轮信贷找优质企业项目 新一轮信贷找优质企业项目新一轮信贷找优质企业项目新一轮信贷项目新一轮信贷找轮信贷找优质企业项目新一轮信贷找优质企业项目 新一轮信贷找优质企业项目新一轮信贷找优质企业项目新一轮信贷项目新一轮信贷找优...<span style=\" padding-left:30px;\"><img src=\"http://www.topfo.com/ADPage/yjtg/tt_17.jpg\" width=\"74\" height=\"21\"></span></td>");
        sb.Append("</tr>");

        sb.Append("</table>");
        sb.Append("</td>");
        sb.Append("<td><div align=\"right\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_17.jpg\" width=\"29\" height=\"124\" alt=\"\"></div></td>");

        sb.Append("</tr>");



        sb.Append("<tr>");
        sb.Append("<td colspan=\"3\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_13.jpg\" width=\"668\" height=\"28\" alt=\"\"></td>");
        sb.Append("</tr>");


        sb.Append("<tr>");
        sb.Append("<td colspan=\"3\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_14.jpg\" width=\"668\" height=\"39\" alt=\"\"></td>");
        sb.Append("</tr>");


        sb.Append("<tr><td colspan=\"3\"><img src=\"http://www.topfo.com/ADPage/yjtg/index_19.jpg\" width=\"668\" height=\"80\" alt=\"\"></td></tr>");

        sb.Append("</table>");
        sb.Append("</body>");


        msg.SendEmail(address, titel, sb.ToString());

    }

    /// <summary>
    /// 发送手机短信
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {

        //// Tz888.SQLServerDAL.SendNotice send = new Tz888.SQLServerDAL.SendNotice();SendMobileSms SendMobileMsg
        //Tz888.BLL.SendNotice send = new Tz888.BLL.SendNotice();
        //string num = "15815504883";
        //string message = "hello";
        //bool str = send.SendMobileMsg(num, message);
        //int str = send.Sendmessage();
        //if (str == 1)
        //{
        //    Response.Write("this is ok");
        //}
        //else
        //{
        //    Response.Write("this is wrong");
        //}

    }
}
