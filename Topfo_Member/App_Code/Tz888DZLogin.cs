using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Web.Security;
using Discuz.Common;
/// <summary>
/// DZlogin 的摘要说明
/// </summary>
public class Tz888DZLogin
{
    public Tz888DZLogin()
    {

    }
    public static void BBSLogin(string username,string password,string email)
    {
        if (username != null && username != "")//执行论坛登陆
        {
            try
            {
                DiscuzLoginWS.Tz888_DiscuzLogin ws = new DiscuzLoginWS.Tz888_DiscuzLogin();
                ws.Url = System.Configuration.ConfigurationManager.AppSettings["SVSGA_URL"];
                string key = System.Configuration.ConfigurationManager.AppSettings["BBS_PasswordKey"];
                string str = ws.CheckAndCreateUser(username, password, email, key);
                int uid = ws.GetUserID(username);
                string login = ws.CheckLogin(username, password, key);
                bool b = DZntLogin(uid, password, key);
            }
            catch
            { }
        }
    }
    /// <summary>
    /// dnt论坛登陆方法
    /// </summary>
    /// <param name="uid">用户ID</param>
    /// <param name="password">用户密码,已加密成md5的</param>
    /// <param name="passwordkey">论坛key</param>
    /// <param name="domin">根域名</param>
    /// <returns></returns>
    public static bool DZntLogin(int uid, string password, string passwordkey)
    {
        try
        {
            int invisible = 0;
            int expires = 44330;
            HttpCookie cookie = new HttpCookie("dnt");
            cookie.Values["userid"] = uid.ToString();
            cookie.Values["password"] = HttpUtility.UrlEncode(SetCookiePassword(GetMD5(password), passwordkey));
            cookie.Values["tpp"] = "0";
            cookie.Values["ppp"] = "0";
            cookie.Values["pmsound"] = "1";
            cookie.Values["invisible"] = invisible.ToString();
            cookie.Values["referer"] = "index.aspx";
            cookie.Values["sigstatus"] = "1";
            cookie.Values["expires"] = expires.ToString();

            DateTime.Now.AddDays(1); // Cookies保持天数

            cookie.Domain = ".topfo.com";
            HttpContext.Current.Response.AppendCookie(cookie);

            return true;
        }
        catch
        {
            return false;
        }

    }
    public static string GetMD5(string s)
    {
        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    public static void ClearUserCookie(string cookieName, string domin)
    {
        HttpCookie cookie = new HttpCookie(cookieName);
        cookie.Values.Clear();
        cookie.Expires = DateTime.Now.AddYears(-1);
        cookie.Domain = domin;
        HttpContext.Current.Response.AppendCookie(cookie);
    }
    public static string SetCookiePassword(string password, string key)
    {
        return Discuz.Common.DES.Encode(password, key);
    }
    public static void WriteCookie(string strName, string strValue, int expires)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
        cookie.Domain = "topfo.com";
        if (cookie == null)
        {
            cookie = new HttpCookie(strName);
        }
        cookie.Value = strValue;
        cookie.Expires = DateTime.Now.AddMinutes((double)expires);
        HttpContext.Current.Response.AppendCookie(cookie);
    }
    public static string Md5hash_String(string InputString)
    {
        InputString = FormsAuthentication.HashPasswordForStoringInConfigFile(InputString, "MD5");
        return InputString;
    }
}