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

public partial class Message_EmaliTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    
    protected void btnDouble_Click(object sender, EventArgs e)
    {
        Tz888.BLL.AutoSendMsg msg = new Tz888.BLL.AutoSendMsg();

        string address = txtEmai.Text.ToString();
        string titel = txtTitle.Text.ToString();
        StringBuilder sb = new StringBuilder();
        sb.Append("<body bgcolor=\"#FFFFFF\" leftmargin=\"0\" topmargin=\"0\" marginwidth=\"0\" marginheight=\"0\">");
        sb.Append("<table width=\"650\" height=\"360\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">");
        sb.Append("<tr><td colspan=\"3\"><img src=\"http://img2.topfo.com//email/img/yuandan.jpg\" width=\"650\" height=\"360\" alt=\"\"></td></tr>");
        sb.Append("</table>");
        sb.Append("</body>");
        msg.SendEmailAll(address, titel, sb.ToString());
      
    }
}
