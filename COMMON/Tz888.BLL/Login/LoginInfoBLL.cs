using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Web.UI;
using System.Data;


using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL.LoginInfo;
using Tz888.IDAL.Common;


namespace Tz888.BLL.Login
{
    public class LoginInfoBLL
    {
        //LoginName Cookie
        static readonly public string LoginNameCookieName = "topfo.com.LoginName";
        //static readonly public string LoginNameCookieName = "tz888.cn.memberV2";
        //User GradeType Cookie
        static readonly public string UserGradeCookieName = "topfo.com.UserGrade";

        //User ManageType Cookie
        static readonly public string UserManageTypeCookieName = "topfo.com.ManageType";
#if DEBUG
        static readonly public string DomainName = ".topfo.com";
        //static readonly public string DomainName = "localhost";
#else
        static readonly public string DomainName = ".topfo.com";
#endif
        private readonly ILoginInfo dal = DataAccess.CreateILoginInfo_LoginInfo();
        private readonly ICommonFunction dalComm = DALFactory.DataAccess.CreateICommon_CommonFunction();

        ///<summary>
        /// 
        ///</summary>
        public LoginInfoBLL()
        {

        }

        #region �û���½�����Ϣ


        ///<summary>
        /// ��ȡϵͳ�����õĸ���cookie���ƣ���ǰ������cookie
        ///</summary>
        /// <param name="CookieType">0���û���¼�� 1���û�Ȩ�ޣ���ͨ��Ա/�ظ�ͨ��Ա�� 2���û����ͣ�����/���徭Ӫ/��ҵ��λ/����������</param>
        /// <returns>string</returns>
        static public string getCookieNameByCookieType(int CookieType)
        {
            string cookieName;
            switch (CookieType)
            {
                case 0:
                    cookieName = LoginNameCookieName;
                    break;
                case 1:
                    cookieName = UserGradeCookieName;
                    break;
                case 2:
                    cookieName = UserManageTypeCookieName;
                    break;
                default:
                    cookieName = LoginNameCookieName;
                    break;
            }
            return cookieName;
        }

        ///<summary>
        /// ���鵱ǰ�����Ƿ񱣴���ĳ�����͵�Cookie
        ///</summary>
        /// <param name="CookieType">0���û���¼�� 1���û�Ȩ�� 2���û�����</param>
        /// <returns>bool</returns>
        public static bool GetCookeIsNullByCookieType(int CookieType)
        {
            return GetCookieContentByCookieType(CookieType) != "";
        }

        ///<summary>
        /// ���ø���Ʊ֤Cookie
        ///</summary>
        /// <param name="UserName">�û���</param>
        /// <param name="UserData">�û�����</param>
        /// <param name="CookieTypeID">Cookie����ID: 0���û���¼�� 1���û�Ȩ�ޣ���ͨ��Ա/�ظ�ͨ��Ա�� 2���û����ͣ�����/���徭Ӫ/��ҵ��λ/����������</param>
        /// <param name="isPersistent">�Ƿ����õ�¼</param>
        public static void SetUserTicketCookie(string UserName, string UserData, int CookieTypeID, bool isPersistent)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, UserName, DateTime.Now,
                DateTime.Now.AddMinutes(60 * 24 * 30), isPersistent, UserData);
            string encryptTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie authCookie = new HttpCookie(getCookieNameByCookieType(CookieTypeID), encryptTicket);
            authCookie.Domain = DomainName;
            if (isPersistent)
                authCookie.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }


        ///<summary>
        /// ��ȡ����Ʊ֤Cookie������
        ///</summary>
        /// <param name="UserName">�û���</param>
        /// <param name="CookieTypeID">Cookie������ID 0���û���¼�� 1���û�Ȩ�ޣ���ͨ��Ա/�ظ�ͨ��Ա�� 2���û����ͣ�����/���徭Ӫ/��ҵ��λ/����������</param>

        public static string GetUserTicketCookie(string UserName, int CookieTypeID)
        {
            string UserData = "";
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[getCookieNameByCookieType(CookieTypeID)];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//���� 
                    //��֤�Ƿ���ͬһ�û�
                    if (UserName == authTicket.Name.Trim())
                    {
                        UserData = authTicket.UserData;
                    }
                    else
                    {

                    }
                }
            }
            return UserData;
        }
        ///<summary>
        /// ��ȡFormsTicketCookie��UserData����
        ///</summary>
        /// <returns></returns>
        public static string GetFormsTicketCookie()
        {
            HttpCookie authCookieForms = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            string UserData = "";
            string UserName = "";
            if (authCookieForms != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookieForms.Value);//����                
                UserData = authTicket.UserData;
                UserName = authTicket.Name;
            }
            return UserData;
        }

        ///<summary>
        /// �����û���FormsCookie
        ///</summary>
        /// <param name="userName">�û���</param>
        /// <param name="GradeTypeID">�û�Ȩ��ID:1001����ͨ��Ա 1002���ظ�ͨ��Ա</param>
        /// <param name="ManageTypeID">�û����1001������ 1002�����徭Ӫ 1003����ҵ��λ 1004����������</param>
        /// <param name="isPersistent">�Ƿ����õ�¼</param>
        public static void SetUserFormsCookie(string userName, string GradeTypeID, string ManageTypeID, bool isPersistent)
        {
            //���� FormsCookieName            
            string strRole = "GT" + GradeTypeID + "|" + "MT" + ManageTypeID;

            HttpCookie authCookiePrev = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookiePrev != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookiePrev.Value);//����                
                HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now,
                DateTime.Now.AddMinutes(60 * 24 * 30), isPersistent, strRole);
            string encryptTicket = FormsAuthentication.Encrypt(ticket);

            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            authCookie.Domain = DomainName;
            //if (isPersistent)
            //   authCookie.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
            HttpContext.Current.Response.Cookies.Add(authCookie);

            //�����û���¼Ʊ֤cookie
            SetUserTicketCookie(userName, strRole, 0, isPersistent);


            //�����ϵͳ
            HttpCookie clientCookie = new HttpCookie("topfo.com_CKData", System.Web.HttpUtility.UrlEncode(userName, System.Text.Encoding.GetEncoding("utf-8")));
            clientCookie.Expires = DateTime.Now.AddDays(1);

            clientCookie.Domain = DomainName;
            //if (isPersistent)
            //    clientCookie.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
            HttpContext.Current.Response.Cookies.Add(clientCookie);

            //�����ϵͳ
            HttpCookie clientCookieUserName = new HttpCookie(getCookieNameByCookieType(0), System.Web.HttpUtility.UrlEncode(userName, System.Text.Encoding.GetEncoding("utf-8")));
            clientCookieUserName.Domain = DomainName;
            //if (isPersistent)
            //    clientCookieUserName.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
            HttpContext.Current.Response.Cookies.Add(clientCookieUserName);

            //�����ϵͳ
            //FormsAuthenticationTicket ticket2 = new FormsAuthenticationTicket(0, userName, DateTime.Now,
            //    DateTime.Now.AddMinutes(60 * 24 * 30), isPersistent, strRole);
            //string encryptTicket2 = FormsAuthentication.Encrypt(ticket2);
            //HttpCookie clientCookiepay = new HttpCookie("topfo.com.memberV2", encryptTicket2);//tz888.cn.memberV2
            ////HttpCookie clientCookiepay = new HttpCookie("topfo.com.memberV2", System.Web.HttpUtility.UrlEncode(userName, System.Text.Encoding.GetEncoding("utf-8")));
            //clientCookiepay.Domain = DomainName;
            ////if (isPersistent)
            ////    clientCookie.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
            //HttpContext.Current.Response.Cookies.Add(clientCookiepay);


        }


        ///<summary>
        /// ����Cookie����ID(0���û���¼�� 1���û�Ȩ�� 2���û�����)������Cookie�����ݣ�û�и�Cookie���ؿմ�
        ///</summary>
        /// <param name="CookieType">0���û���¼�� 1���û�Ȩ�� 2���û�����</param>
        /// <returns></returns>
        public static string GetCookieContentByCookieType(int CookieTypeID)
        {
            string CookieValue = "";
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[getCookieNameByCookieType(CookieTypeID)];
                if (authCookie != null)
                {
                    //FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//���� 
                    //CookieValue = authTicket.UserData;

                    //string[] roles = authTicket.UserData.Split(new char[] { '|' });

                    CookieValue = authCookie.Value;
                }
            }
            return CookieValue;
        }

        ///<summary>
        /// �õ���¼�ʻ��ǳ�,û�е�¼ ���� ""
        ///</summary>
        /// <returns>string</returns>
        public static string GetLoginUserNickName()
        {
            string nickName = "";
            HttpCookie ckData = HttpContext.Current.Request.Cookies["topfo.com_CKData"];
            if (ckData != null)
            {
                string str = ckData.Value;
                if (str != null)
                {
                    str = System.Web.HttpUtility.UrlDecode(str, System.Text.Encoding.GetEncoding("utf-8"));
                    nickName = str;
                }
            }
            return nickName;
        }


        #region �˳�
        ///<summary>
        /// �˳���������Gookie����
        ///</summary>
        public static void Logout()
        {
            //ԭ��¼Ʊ֤         
            HttpCookie authCookiePrev = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookiePrev != null)
            {
                authCookiePrev.Domain = DomainName;
                authCookiePrev.Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies.Add(authCookiePrev);
            }


            for (int i = 0; i < 3; i++)
            {
                HttpCookie otherAuthCookie = HttpContext.Current.Request.Cookies[getCookieNameByCookieType(i)];
                if (otherAuthCookie != null)
                {
                    otherAuthCookie.Domain = DomainName;
                    otherAuthCookie.Expires = DateTime.Now.AddHours(-1);
                    HttpContext.Current.Response.Cookies.Add(otherAuthCookie);
                }
            }
            ClientLogout();
        }

        ///<summary>
        /// �˳��ͻ���
        ///</summary>
        public static void ClientLogout()
        {
            //�˳��ͻ���
            HttpCookie clientCookie = HttpContext.Current.Request.Cookies["topfo.com_CKData"];
            if (clientCookie != null)
            {
                clientCookie.Domain = DomainName;
                clientCookie.Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies.Add(clientCookie);
            }
        }
        #endregion

        #region ����¼ʧ�ܴ���
        ///<summary>
        /// 
        ///</summary>
        /// <param name="strLoginName"></param>
        /// <param name="LoginTimeRange"></param>
        /// <param name="AllowErrorTimes"></param>
        /// <returns></returns>
        public int CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes)
        {
            return dal.CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes);
        }
        #endregion


        #region ��ȡ��¼���б�
        ///<summary>
        /// 
        ///</summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <returns></returns>
        public DataTable GetLoginInfoList
            (
            string SelectCol,
            string Criteria,
            string Sort
            )
        {
         
            return dal.GetLoginInfoList(SelectCol, Criteria, Sort);
        }
        #endregion



        #region ��ȡ��¼���б�
        ///<summary>
        /// 
        ///</summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public DataTable GetLoginInfoByLoginName(string LoginName)
        {
            return dal.GetLoginInfo(LoginName);
        }
        #endregion



        ///<summary>
        /// �����ݿ��еõ�RoleName
        ///</summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public string GetLoginUserRoleName(string LoginName)
        {
            string roleName = "";
            DataTable dt = dal.GetInfoList("LoginInfoTab", "RoleName", "LoginID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                roleName = dt.Rows[0]["roleName"].ToString().Trim();
            }
            return roleName;
        }


        #endregion

        #region �����ݿ��л�ȡ��֤��Ա��¼��Ϣ
        public DataTable Authenticate(
            string strLoginName,
            long lgCardNo,
            string strPassWord,
            bool IsOnlyCheck,
            ref	int ErrorID,
            ref string ErrorMsg)
        {
           
            DataTable dt = null;
            dt = dal.AuthMemberLogin(strLoginName, lgCardNo, strPassWord, IsOnlyCheck);
            return (dt);
        }

        #endregion

        ///<summary>
        /// 
        ///</summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public string GetUserGradeTypeIDByLoginName(string LoginName)
        {
            string GradeTypeID = "";
            DataTable dt = dal.GetLoginInfo(LoginName);
            if (dt != null && dt.Rows.Count > 0)
            {
                GradeTypeID = dt.Rows[0]["MemberGradeID"].ToString().Trim();
            }
            return GradeTypeID;
        }

        ///<summary>
        /// ��̳��½��Ϣ���� 
        ///</summary>
        /// <param name="userId">�û�ID</param>
        /// <param name="ip">����½IP</param>
        /// <param name="truePassword">�µ��������</param>
        /// <returns>��������,���ؿջ�nullΪ��Ч</returns>
        public string BBSLoginUpdate(int userId, string ip, string truePassword)
        {
            string groupName;
            groupName = dal.BBSLoginUpdate(userId, ip, truePassword);
            return groupName;
        }

        #region ���ҵ�����
        ///<summary>
        /// ��Ϣ���� 
        ///</summary>
        /// <param name="strNickName"></param>
        /// <param name="lgPageCount"></param>
        /// <returns></returns>
        public DataView dsGetAllMsgToMe(string strNickName, ref long lgPageCount)
        {
            long CurrentPage = 0;
            long PageRows = 0;
            DataView dv;

            dv = dalComm.GetListSet("InfoComment_list",
                "*",
                "infoowner='" + strNickName + "'",
                "InfoID desc",
                ref CurrentPage,
                1,
                ref lgPageCount);

            return dv;
        }
        #endregion

        #region ��֤Ա����¼
        public DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            bool IsOnlyCheck)
        {
            return dal.Authenticate(strLoginName, strPassWord, IsOnlyCheck);
        }
        #endregion
        #region �����ݿ��л�ȡ��֤��Ա��¼��Ϣ
        public DataTable LmAuthenticate(
            string strLoginName,
            long lgCardNo,
            bool IsOnlyCheck,
            ref	int ErrorID,
            ref string ErrorMsg)
        {

            DataTable dt = null;
            dt = dal.LmAuthMemberLogin(strLoginName, lgCardNo, IsOnlyCheck);
            return (dt);
        }

        #endregion

        #region ������¼��־
        public bool CreateLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP)
        {
            return dal.InsertLoginLog(strLoginName, strRoleName, dtLoginTime, strLoginIP);
        }
        #endregion
        //������־
        public bool CreateLoginErrorLog(string strLoginName, DateTime dtLoginTime, string strLoginIP, bool blFlag)
        {
            return dal.CreateLoginErrorLog(strLoginName, dtLoginTime, strLoginIP, blFlag);
        }

        public bool ChangePassword(string strLoginName, string strNewPassword)
        {
            return dal.ChangePassword(strLoginName, strNewPassword);
        }


        ///--------------------------------------
        ///---20090811 wangwei
        ///--------------------------------------

        #region ��Ա������Ϣ��Ȩ����֤
        //��֤������ע���һ��Сʱ��������û�б��������ʻ�
        public bool yanzheng(string loginName)
        {
            return dal.yanzheng(loginName);
        }
        #endregion

        #region �Ƿ��������û�
        public int LockUser(string loginName, int AuditStatus)
        {
            return dal.LockUser(loginName, AuditStatus);
        }
        #endregion
    }
}
