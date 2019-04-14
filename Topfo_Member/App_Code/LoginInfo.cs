using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Collections;
using System.Data;

namespace tzWeb
{
    /// <summary>
    /// CommonUI 的摘要说明。
    /// </summary>
    public class LoginInfo
    {

        static private string userCookieName = "tz888.cn.memberV2";
        //static private string userCookieName = "topfo.com.LoginName";
        static private string agentCookieName = "tz888.cn.agentV2";
        static private string expertCookieName = "tz888.cn.expertV2";
        static private string adminCookieName = "tz888.cn.admin";
        /// <summary>
        /// 获取各类用户的cookie名称
        /// </summary>
        /// <param name="type">0为会员,1为代理商(分站),3为专家</param>
        /// <returns>string</returns>
        static public string getCookieName(int type)
        {
            string cookieName;
            switch (type)
            {
                case 0:
                    cookieName = userCookieName;
                    break;
                case 1:
                    cookieName = agentCookieName;
                    break;
                case 2:
                    cookieName = adminCookieName;
                    break;
                case 3:
                    cookieName = expertCookieName;
                    break;
                default:
                    cookieName = userCookieName;
                    break;
            }
            return cookieName;
        }
        /// <summary>
        /// 得到登录用户名,没有登录 返回 ""
        /// </summary>
        /// <param name="type">0为会员,1为代理商(分站),3为专家</param>
        /// <returns>string</returns>
        public static string GetLoginUserName(int type)
        {
            string userName = "";
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[getCookieName(type)];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
                    userName = authTicket.Name;
                }
            }
            HttpContext.Current.Response.Write("<script>alert("+userName+")</script>");
            return userName;
        }


    }
}
