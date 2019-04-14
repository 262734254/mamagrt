using System;
using System.Web;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Web.Services.Protocols;
using Tz888.BLL.Login;
using Tz888.BLL.Common;
using System.Text;
using System.Web.Security;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// LmLogin 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class LmLogin : System.Web.Services.WebService
{

    public LmLogin()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    private string strRoleName = "";
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    private bool CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes)
    {
        strLoginName = "hellocindy";
        LoginInfoBLL loginRule = new LoginInfoBLL();
        int intReturn = loginRule.CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes);
        if (intReturn == 0)
            return false;
        else
            return true;

    }

    #region //登录
    private void DoLogin(string LoginName,string txtPsd)
    {
           
        int AuthenticationTickeTime = Convert.ToInt32(Common.GetAuthenticationTickeTime());

        #region //会员登录

        //验证用户名与密码是否正确
        int ErrorID = 0;
        string ErrorMsg = "";
        LoginInfoBLL loginRule = new LoginInfoBLL();
        DataTable dt = new DataTable();

        dt = loginRule.Authenticate( LoginName, 0,txtPsd,false,ref ErrorID, ref ErrorMsg);

        if (ErrorID != 0)
        {
          
            return;
        }
        if (dt.Rows.Count > 0)
        {
            strRoleName = dt.Rows[0]["RoleName"].ToString().Trim();
        }
        if ((dt.Rows.Count > 0) && (strRoleName == "0")) //
        {
            InsertLoginLog(LoginName, strRoleName);
            //写登陆cookie开始
            HttpCookie loginedUser = new HttpCookie("loginedUser");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = LoginName;

            HttpContext.Current.Response.Cookies.Add(loginedUser);
            //写登陆cookie结束
            Tz888.BLL.Login.LoginInfoBLL.Logout();


            //BBS登录
            Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), txtPsd, dt.Rows[0]["email"].ToString().Trim());
            //分配验证票,同时建立角色信息		
            LoginInfoBLL.SetUserFormsCookie(LoginName, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), true);
            #region  登录后SESSION记录 用户名，用户角色以及 角色组
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dtUser = dal.GetList("VipApplyTab", "BuyTerm", "ApplyID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            string MemberType = "";
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                MemberType = dtUser.Rows[0]["BuyTerm"].ToString();
            }
            else { MemberType = "1"; }

            string[] obj = { LoginName, dt.Rows[0]["ManageTypeID"].ToString().Trim(), MemberType };

    

                HttpContext.Current.Session["MemberObj"] = obj;
             

            #endregion

            if (!(HttpContext.Current.User == null))
            {
                if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
                {
                    System.Web.Security.FormsIdentity id;
                    id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    String[] myRoles = new String[6];
                    myRoles[0] = "2001";
                    myRoles[1] = "2002";
                    myRoles[2] = "2003";
                    myRoles[3] = "2004";
                    myRoles[4] = "2006";
                    myRoles[5] = "2007";

                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
                }
            }

            HttpCookie Cook = new HttpCookie("uID");
            Cook.Value = dt.Rows[0]["loginId"].ToString();
            Cook.Domain = ".topfo.com";

            HttpContext.Current.Response.SetCookie(Cook);
            if (dt.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
            {
                //拓富会员
                //Response.Redirect("http://member.topfo.com/indexTof.aspx");
                //HttpContext.Current.Response.Redirect("http://member.topfo.com/indexTof.aspx");
            }
            else
            {
                //普通会员
                //Response.Redirect("http://member.topfo.com/index.aspx");
                //HttpContext.Current.Response.Redirect("http://member.topfo.com/index.aspx");
            }
         
        }
       

        #endregion

    }
    #endregion


    #region 插入登录日志
    private void InsertLoginLog(string strLoginName, string strRoleName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP =  HttpContext.Current.Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginLog(strLoginName, strRoleName, dtLoginTime, strLoginIP);

    }
    #endregion

    #region 插入登录失败日志
    private void CreateLoginErrorLog(string strLoginName)
    {
     
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = HttpContext.Current.Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginErrorLog(strLoginName, dtLoginTime, strLoginIP, true);
    }
    #endregion
    [WebMethod(true)]
    public void Lmlogin(string LoginName, string txtPsd)
  {


      DoLogin(LoginName, txtPsd);
    }

}

