using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL.LoginInfo;
using System.Web.UI;
using System.Configuration;
using System.Web.Security;
using System.Security.Principal;
using System.Web.SessionState;
using System.Globalization;
using System.Security.Cryptography;
using System.Web;
namespace Tz888.BLL.Login
{
    public class Common
    {
        private readonly ICommon dal = DataAccess.CreateILoginInfo_Common();

        public Common()
        {

        }


        #region Title的脚本的注册函数----
        public static void RegisterTitle(System.Web.UI.Page page, string title)
        {
            string titleScript = @"<script language=javascript>
									<!--
									document.title='"
               + title +
               @"';
									//-->
									</script>";



            if (!page.IsClientScriptBlockRegistered("TitleKey"))
            {
                page.RegisterClientScriptBlock("TitleKey", titleScript);
            }
        }
        #endregion

        #region 获取验证票有效时间
        public static string GetAuthenticationTickeTime()
        {
            string AuthenticationTickeTime = ConfigurationManager.AppSettings["AuthenticationTickeTime"].ToString();
            return AuthenticationTickeTime;
        }
        #endregion

        //
        #region 获取规定时间段
        public static string GetLoginTimeRange()
        {
            string LoginTimeRange = ConfigurationSettings.AppSettings["LoginTimeRange"].ToString();
            return LoginTimeRange;
        }
        #endregion

        #region 获取规定时间段允许登录错误次数
        public static string GetAllowErrorTimes()
        {
            string AllowErrorTimes = ConfigurationSettings.AppSettings["AllowErrorTimes"].ToString();
            return AllowErrorTimes;
        }
        #endregion

        #region  根据cookie获取UserString
        public static bool KeepSession(Page page, string url)
        {
            if (page.User.Identity.Name.ToString() == "")
            {
                page.Response.Write("<script>alert('请重新登陆！');location.href='" + url + "';</script>");
                return false;
            }
            else
            {
                string RoleName = "";
                HttpCookie authCookieForms = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookieForms != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookieForms.Value);//解密                
                    RoleName = authTicket.UserData.Trim();
                }
                string strLoginName;
                string strRoleName;
                string strEmployeeName;
                string strDeptID;
                string strWorkType;
                string strWorkTypeName;

                string[] roles = RoleName.Split(',');
                strLoginName = roles[0].Trim();
                strRoleName = roles[1].Trim();
                strEmployeeName = roles[2].Trim();
                strDeptID = roles[3].Trim();
                strWorkType = roles[4].Trim();
                strWorkTypeName = roles[5].Trim();

                page.Session.Add("LoginName", strLoginName);
                page.Session.Add("RoleName", strRoleName);
                page.Session.Add("EmployeeName", strEmployeeName);
                page.Session.Add("DeptID", strDeptID);
                page.Session.Add("WorkType", strWorkType);
                page.Session.Add("WorkTypeName", strWorkTypeName);
                return true;
            }
        }
        public static bool KeepSession(Page page)
        {
            return KeepSession(page, "http://manage.investguide.cn/login.aspx");
        }
        #endregion



    }
}
