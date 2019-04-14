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
using Tz888.BLL.Login;
using Tz888.BLL.Common;

public partial class lmLogin : System.Web.UI.Page
{

    private string strRoleName = "";
    private string strLoginName = "";
    private string strPassword = "";

    //是否自动登陆
    public string action = "";
    bool isAuto = false;
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (this.Request.QueryString["loginname"] != null)
            {
                strLoginName = tzWeb.pay.comm.JieMi(this.Request.QueryString["loginname"].ToString().Trim()); 
                DoLogin();

            }
            else 
            {
                Response.Write("<script>alert('用户名或密码错误!');location.href='http://member.topfo.com/login.aspx';</script>");

            }
        }
    }
  



    #region //登录
    private void DoLogin()
    {
        int AuthenticationTickeTime = Convert.ToInt32(Common.GetAuthenticationTickeTime());

        #region //会员登录
   

        //验证用户名与密码是否正确
        int ErrorID = 0;
        string ErrorMsg = "";
        LoginInfoBLL loginRule = new LoginInfoBLL();
        DataTable dt = new DataTable();

        dt = loginRule.LmAuthenticate(
            strLoginName,
            0,
      
            false,
            ref ErrorID,
            ref ErrorMsg);

        if (ErrorID != 0)
        {

            Response.Write("<script>alert('用户名或密码错误!');location.href='http://member.topfo.com/login.aspx';</script>");
            return;
        }
        if (dt.Rows.Count > 0)
        {
            strRoleName = dt.Rows[0]["RoleName"].ToString().Trim();
        }
        if ((dt.Rows.Count > 0) && (strRoleName == "0")) //
        {
            InsertLoginLog(strLoginName, strRoleName);
            //写登陆cookie开始
            HttpCookie loginedUser = new HttpCookie("loginedUser");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = strLoginName;

            Response.Cookies.Add(loginedUser);
            //写登陆cookie结束
            Tz888.BLL.Login.LoginInfoBLL.Logout();


            //分配验证票,同时建立角色信息		
            LoginInfoBLL.SetUserFormsCookie(strLoginName, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), true);
            #region  登录后SESSION记录 用户名，用户角色以及 角色组
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dtUser = dal.GetList("VipApplyTab", "BuyTerm", "ApplyID", 1, 1, 0, 1, "LoginName='" + strLoginName + "'");
            string MemberType = "";
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                MemberType = dtUser.Rows[0]["BuyTerm"].ToString();
            }
            else { MemberType = "1"; }

            string[] obj = { strLoginName, dt.Rows[0]["ManageTypeID"].ToString().Trim(), MemberType };

            Session["MemberObj"] = obj;

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
            //此为搭建的互告环境 20100330
            HttpCookie Cook = new HttpCookie("uID");
            Cook.Value = dt.Rows[0]["loginId"].ToString();
            Cook.Domain = ".topfo.com";

            Response.SetCookie(Cook);

            #region 获取跳转链接并跳转
          
           

                if (this.ViewState["ReturnURL"] != null)
                {
                    Response.Redirect(this.ViewState["ReturnURL"].ToString().Trim());
                }
                else
                {
                    if (dt.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
                    {
                        //拓富会员
                        Response.Redirect("indexTof.aspx");
                    }
                    else
                    {
                        //普通会员
                        Response.Redirect("index.aspx");
                    }
                }
            
            #endregion
        }
        else
        {
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('用户名或密码错误!');location.href='http://member.topfo.com/login.aspx';</script>");
            }
        }

        #endregion

    }
    #endregion

    #region 插入登录日志
    private void InsertLoginLog(string strLoginName, string strRoleName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginLog(strLoginName, strRoleName, dtLoginTime, strLoginIP);

    }
    #endregion

    #region 插入登录失败日志
    private void InsertLoginErrorLog(string strLoginName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginErrorLog(strLoginName, dtLoginTime, strLoginIP, true);
    }
    #endregion

    private bool CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes)
    {
        LoginInfoBLL loginRule = new LoginInfoBLL();
        int intReturn = loginRule.CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes);
        if (intReturn == 0)
            return false;
        else
            return true;
    }
}



