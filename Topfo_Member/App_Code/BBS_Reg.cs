using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// BBS_Reg 的摘要说明
/// </summary>
public class BBS_Reg
{
    public BBS_Reg()
    {
    }
    public static void Reg(string username, string password,string email)
    {
        DiscuzLoginWS.Tz888_DiscuzLogin ws = new DiscuzLoginWS.Tz888_DiscuzLogin();
        ws.Url = System.Configuration.ConfigurationManager.AppSettings["SVSGA_URL"];
        string pwdKey = System.Configuration.ConfigurationManager.AppSettings["BBS_PasswordKey"];
        string st = ws.CreateUser(username, password, email, "True", pwdKey);
    }
}
