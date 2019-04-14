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


        #region Title�Ľű���ע�ắ��----
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

        #region ��ȡ��֤Ʊ��Чʱ��
        public static string GetAuthenticationTickeTime()
        {
            string AuthenticationTickeTime = ConfigurationManager.AppSettings["AuthenticationTickeTime"].ToString();
            return AuthenticationTickeTime;
        }
        #endregion

        //
        #region ��ȡ�涨ʱ���
        public static string GetLoginTimeRange()
        {
            string LoginTimeRange = ConfigurationSettings.AppSettings["LoginTimeRange"].ToString();
            return LoginTimeRange;
        }
        #endregion

        #region ��ȡ�涨ʱ��������¼�������
        public static string GetAllowErrorTimes()
        {
            string AllowErrorTimes = ConfigurationSettings.AppSettings["AllowErrorTimes"].ToString();
            return AllowErrorTimes;
        }
        #endregion

        #region  ����cookie��ȡUserString
        public static bool KeepSession(Page page, string url)
        {
            if (page.User.Identity.Name.ToString() == "")
            {
                page.Response.Write("<script>alert('�����µ�½��');location.href='" + url + "';</script>");
                return false;
            }
            else
            {
                string RoleName = "";
                HttpCookie authCookieForms = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookieForms != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookieForms.Value);//����                
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
