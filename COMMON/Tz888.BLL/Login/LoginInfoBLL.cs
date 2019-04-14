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

        #region 用户登陆相关信息


        ///<summary>
        /// 获取系统所设置的各类cookie名称，当前有三种cookie
        ///</summary>
        /// <param name="CookieType">0：用户登录名 1：用户权限（普通会员/拓富通会员） 2：用户类型（个人/个体经营/企业单位/政府机构）</param>
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
        /// 检验当前机器是否保存有某种类型的Cookie
        ///</summary>
        /// <param name="CookieType">0：用户登录名 1：用户权限 2：用户类型</param>
        /// <returns>bool</returns>
        public static bool GetCookeIsNullByCookieType(int CookieType)
        {
            return GetCookieContentByCookieType(CookieType) != "";
        }

        ///<summary>
        /// 设置各类票证Cookie
        ///</summary>
        /// <param name="UserName">用户名</param>
        /// <param name="UserData">用户数据</param>
        /// <param name="CookieTypeID">Cookie类型ID: 0：用户登录名 1：用户权限（普通会员/拓富通会员） 2：用户类型（个人/个体经营/企业单位/政府机构）</param>
        /// <param name="isPersistent">是否永久登录</param>
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
        /// 获取各类票证Cookie的内容
        ///</summary>
        /// <param name="UserName">用户名</param>
        /// <param name="CookieTypeID">Cookie的类型ID 0：用户登录名 1：用户权限（普通会员/拓富通会员） 2：用户类型（个人/个体经营/企业单位/政府机构）</param>

        public static string GetUserTicketCookie(string UserName, int CookieTypeID)
        {
            string UserData = "";
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[getCookieNameByCookieType(CookieTypeID)];
                if (authCookie != null)
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
                    //验证是否是同一用户
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
        /// 获取FormsTicketCookie的UserData内容
        ///</summary>
        /// <returns></returns>
        public static string GetFormsTicketCookie()
        {
            HttpCookie authCookieForms = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            string UserData = "";
            string UserName = "";
            if (authCookieForms != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookieForms.Value);//解密                
                UserData = authTicket.UserData;
                UserName = authTicket.Name;
            }
            return UserData;
        }

        ///<summary>
        /// 设置用户的FormsCookie
        ///</summary>
        /// <param name="userName">用户名</param>
        /// <param name="GradeTypeID">用户权限ID:1001：普通会员 1002：拓富通会员</param>
        /// <param name="ManageTypeID">用户类别：1001：个人 1002：个体经营 1003：企业单位 1004：政府机构</param>
        /// <param name="isPersistent">是否永久登录</param>
        public static void SetUserFormsCookie(string userName, string GradeTypeID, string ManageTypeID, bool isPersistent)
        {
            //设置 FormsCookieName            
            string strRole = "GT" + GradeTypeID + "|" + "MT" + ManageTypeID;

            HttpCookie authCookiePrev = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookiePrev != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookiePrev.Value);//解密                
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

            //设置用户登录票证cookie
            SetUserTicketCookie(userName, strRole, 0, isPersistent);


            //兼顾老系统
            HttpCookie clientCookie = new HttpCookie("topfo.com_CKData", System.Web.HttpUtility.UrlEncode(userName, System.Text.Encoding.GetEncoding("utf-8")));
            clientCookie.Expires = DateTime.Now.AddDays(1);

            clientCookie.Domain = DomainName;
            //if (isPersistent)
            //    clientCookie.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
            HttpContext.Current.Response.Cookies.Add(clientCookie);

            //兼顾老系统
            HttpCookie clientCookieUserName = new HttpCookie(getCookieNameByCookieType(0), System.Web.HttpUtility.UrlEncode(userName, System.Text.Encoding.GetEncoding("utf-8")));
            clientCookieUserName.Domain = DomainName;
            //if (isPersistent)
            //    clientCookieUserName.Expires = DateTime.Now.AddMinutes(60 * 24 * 30);
            HttpContext.Current.Response.Cookies.Add(clientCookieUserName);

            //兼顾老系统
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
        /// 根据Cookie类型ID(0：用户登录名 1：用户权限 2：用户类型)，返回Cookie的内容，没有该Cookie返回空串
        ///</summary>
        /// <param name="CookieType">0：用户登录名 1：用户权限 2：用户类型</param>
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
                    //FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);//解密 
                    //CookieValue = authTicket.UserData;

                    //string[] roles = authTicket.UserData.Split(new char[] { '|' });

                    CookieValue = authCookie.Value;
                }
            }
            return CookieValue;
        }

        ///<summary>
        /// 得到登录帐户昵称,没有登录 返回 ""
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


        #region 退出
        ///<summary>
        /// 退出，清除相关Gookie操作
        ///</summary>
        public static void Logout()
        {
            //原登录票证         
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
        /// 退出客户端
        ///</summary>
        public static void ClientLogout()
        {
            //退出客户端
            HttpCookie clientCookie = HttpContext.Current.Request.Cookies["topfo.com_CKData"];
            if (clientCookie != null)
            {
                clientCookie.Domain = DomainName;
                clientCookie.Expires = DateTime.Now.AddHours(-1);
                HttpContext.Current.Response.Cookies.Add(clientCookie);
            }
        }
        #endregion

        #region 检查登录失败次数
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


        #region 获取登录信列表
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



        #region 获取登录信列表
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
        /// 从数据库中得到RoleName
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

        #region 从数据库中获取验证会员登录信息
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
        /// 论坛登陆信息更新 
        ///</summary>
        /// <param name="userId">用户ID</param>
        /// <param name="ip">最后登陆IP</param>
        /// <param name="truePassword">新的随机密码</param>
        /// <returns>返回组名,返回空或null为无效</returns>
        public string BBSLoginUpdate(int userId, string ip, string truePassword)
        {
            string groupName;
            groupName = dal.BBSLoginUpdate(userId, ip, truePassword);
            return groupName;
        }

        #region 给我的留言
        ///<summary>
        /// 信息留言 
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

        #region 验证员工登录
        public DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            bool IsOnlyCheck)
        {
            return dal.Authenticate(strLoginName, strPassWord, IsOnlyCheck);
        }
        #endregion
        #region 从数据库中获取验证会员登录信息
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

        #region 创建登录日志
        public bool CreateLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP)
        {
            return dal.InsertLoginLog(strLoginName, strRoleName, dtLoginTime, strLoginIP);
        }
        #endregion
        //错误日志
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

        #region 会员发布信息的权限验证
        //验证条件：注册后一个小时、必须是没有被锁定的帐户
        public bool yanzheng(string loginName)
        {
            return dal.yanzheng(loginName);
        }
        #endregion

        #region 是否锁定该用户
        public int LockUser(string loginName, int AuditStatus)
        {
            return dal.LockUser(loginName, AuditStatus);
        }
        #endregion
    }
}
