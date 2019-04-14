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
using SelfCreateWeb.BLL;

public partial class LoginBox : System.Web.UI.Page
{
    private string strLoginType = "";
    private string strRoleName = "";
    private string strLoginName = "";
    private string strPassword = "";
    private string strCarID = "";
    private bool blIsChekUp;
    string hide = "2";
    string cookieDate = "0";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.imbLogin.Attributes["onClick"] = "return SetUserNameOnLogin()";

        if (Tz888.BLL.Login.LoginInfoBLL.GetLoginUserNickName() != "")
        {
            Tz888.BLL.Conn obj = new Tz888.BLL.Conn();
            DataTable dt = obj.GetList("LoginInfoTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + Tz888.BLL.Login.LoginInfoBLL.GetLoginUserNickName() + "'");
            if (dt != null)
            {
                member_logout.Visible = false;
                member_login.Visible = true;
                try
                {
                    lblNickName.Text = dt.Rows[0]["NickName"].ToString().Trim();
                }
                catch
                {
                    lblNickName.Text = strLoginName;
                }
                switch (dt.Rows[0]["MemberGradeID"].ToString().Trim())
                {
                    case "1001":
                        lblUserType.Text = "普通会员";
                        break;
                    case "1002":
                        lblUserType.Text = "拓富通会员";
                        break;
                    case "1003":
                        lblUserType.Text = "拓富通试用会员";
                        break;
                }
            }
            else
            {
                member_logout.Visible = true;
                member_login.Visible = false;
            }
        }
    }
    protected void imbLogin_Click(object sender, ImageClickEventArgs e)
    {
        strLoginName = txtUserName.Text.ToString().Trim();
        strPassword = txtPsd.Text.ToString().Trim();
        if (strLoginName == "" || strPassword == "")
        {
            Response.Write("<script>alert('用户名或密码不能为空！');location.href='/LoginBox.aspx';</script>");
            return;
        }

        strCarID = this.txtUserName.Text.Trim();
        int LoginTimeRange = Convert.ToInt32(Common.GetLoginTimeRange());
        int AllowErrorTimes = Convert.ToInt32(Common.GetAllowErrorTimes());
        if (!CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes))
        {
            Response.Write("<script>alert('连续登录次数的过多，请过两小时后重试！');location.href='/LoginBox.aspx';</script>");
            return;
        }

        DoLogin();
    }

    private bool CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes)
    {
        LoginInfoBLL loginRule = new LoginInfoBLL();
        int intReturn = loginRule.CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes);
        if (intReturn == 0)
            return false;
        else
            return true;
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

        dt = loginRule.Authenticate(
            strLoginName,
            0,
            strPassword,
            false,
            ref ErrorID,
            ref ErrorMsg);


        if (dt.Rows.Count > 0)
        {
            strRoleName = dt.Rows[0]["RoleName"].ToString().Trim();


        }
        if ((dt.Rows.Count > 0) && (strRoleName == "0")) //
        {
            InsertLoginLog(strLoginName, strRoleName);
            //BBS登录
            Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), txtPsd.Text.Trim(), dt.Rows[0]["email"].ToString().Trim());
            //分配验证票,同时建立角色信息		
            LoginInfoBLL.SetUserFormsCookie(strLoginName, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), true);

            if (!(HttpContext.Current.User == null))
            {
                if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
                {
                    System.Web.Security.FormsIdentity id;
                    id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    String[] myRoles = new String[4];
                    myRoles[0] = "1001";
                    myRoles[1] = "1002";
                    myRoles[2] = "1003";
                    myRoles[3] = "1004";
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
                }
            }

            //此为搭建的互告环境 20100330
            HttpCookie Cook = new HttpCookie("uID");
            Cook.Value = dt.Rows[0]["loginId"].ToString();
            Cook.Domain = ".topfo.com";
            Response.SetCookie(Cook);
            Response.Redirect("MyHome/Homelist.aspx");
            //Response.Write("<script>window.location.reload()</script>");
        }
        else
        {
            InsertLoginErrorLog(strLoginName);

            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('您输入的用户名或密码不正确,请重新登录！');location.href='/LoginBox.aspx';</script>");
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
    public void linkout_Click(object sender, System.EventArgs e)
    {
        Session.Abandon();
        Tz888.BLL.Login.LoginInfoBLL.Logout();
        member_logout.Visible = true;
        member_login.Visible = false;
        //SelfCreateWeb.BLL.BLoginUser.Logout();
        //SelfCreateWeb.BLL.BLoginUser.ClientLogout();
    }
}