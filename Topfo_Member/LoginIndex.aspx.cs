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


public partial class LoginIndex : System.Web.UI.Page
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

        if (!Page.IsPostBack)
        {
            member_logout.Visible = true;
           member_login.Visible = false;
        }

        if (Tz888.BLL.Login.LoginInfoBLL.GetLoginUserNickName() != "")
        {

            Tz888.SQLServerDAL.Conn obj = new Tz888.SQLServerDAL.Conn();
            DataTable dt = obj.GetList("LoginInfoTab", "*", "LoginName", 1, 1, 0, 1, "LoginName='" + Tz888.BLL.Login.LoginInfoBLL.GetLoginUserNickName() + "'");
            if (dt != null)
            {

                member_logout.Visible = false;
                member_login.Visible = true;
                try
                {
                    lblNickName.Text = dt.Rows[0]["NickName"].ToString().Trim();
                }
                catch {
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
            //lblPasswordWrong.Text = "用户名或密码不能为空";
             Response.Write("<script language='javascript'>alert('用户名或密码不能为空!');</script>");           
            return;
        }

        strCarID = this.txtUserName.Text.Trim();
        int LoginTimeRange = Convert.ToInt32(Common.GetLoginTimeRange());
        int AllowErrorTimes = Convert.ToInt32(Common.GetAllowErrorTimes());
        if (!CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes))
        {
            Response.Write("<script>alert('连续登录次数的过多，请过两小时后重试！');location.href='/Member/Login.aspx';</script>");
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

    private void DoLogin()
    {
        int AuthenticationTickeTime = Convert.ToInt32(Common.GetAuthenticationTickeTime());

        #region //会员登录

        lblValidate.Visible = false;

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

        if (ErrorID != 0)
        {
            lblPasswordWrong.Text = ErrorMsg;
            lblPasswordWrong.Visible = true;
            return;
        }
        if (dt.Rows.Count > 0)
        {
            strRoleName = dt.Rows[0]["RoleName"].ToString().Trim();
        }
        if ((dt.Rows.Count > 0) && (strRoleName == "0")) //
        {
            //BBS登录
            Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), txtPsd.Text.Trim(), dt.Rows[0]["email"].ToString().Trim());
            //分配验证票,同时建立角色信息		
            LoginInfoBLL.SetUserFormsCookie(strLoginName, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), false);

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

            string strReturnURL = System.Web.HttpUtility.UrlDecode(Request.Params["ReturnURL"]);
            string strurl = "";
            if (Request.QueryString["url"] != null)
            {
                strurl = Request.QueryString["url"].ToString();
            }
            string strSimpleRetrun = Request.Params["Simple"];


            if (strReturnURL != null)
            {
                Response.Redirect(strReturnURL);
            }
            else if (strurl != null)
            {
                Response.Redirect(strurl);
            }
            else
            {

                if (this.ViewState["ReturnURL"] != null)
                {
                    Response.Redirect(this.ViewState["ReturnURL"].ToString().Trim());
                }
                else
                {
                    if (dt.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
                    {
                        //拓富会员
                        Response.Redirect("http://member.topfo.com/indexTof.aspx");
                    }
                    else
                    {
                        //普通会员
                        Response.Redirect("http://member.topfo.com/index.aspx");
                    }
                }
            }
        }
        else
        {
            if (dt.Rows.Count == 0)
            {
                lblPasswordWrong.Text = "您输入的用户名或密码不正确,请重新登录！";
            }
            lblPasswordWrong.Visible = true;
        }

        #endregion

    }

    /// <summary>
    /// 论坛登陆
    /// </summary>
    /// <param name="isBBS"></param>
    /// <param name="dtLogin"></param>
    private void BBSLogin(DataTable dtLogin)
    {
        if (dtLogin != null && dtLogin.Rows.Count > 0)//执行论坛登陆
        {

            string truePassword = "";
            string cookieString = "";
            int cookiedays = 0;
            System.Random rd = new Random();
            int[] ran = new int[10];
            for (int i = 0; i < 10; i++)
            {
                ran[i] = i;
            }
            for (int i = 0; i < 16; i++)
            {
                truePassword += ran[rd.Next(9)].ToString();
            }



            //				truePassword = "EiYLCoNb0v1X2167";
            int uid = Convert.ToInt32(dtLogin.Rows[0]["LoginID"]);

            Tz888.BLL.Login.LoginInfoBLL bllLoginInfo = new LoginInfoBLL();
            string groupName = bllLoginInfo.BBSLoginUpdate(uid, Request.UserHostAddress, truePassword);
            if (groupName.Trim() != "")
            {
                if (hide != null)
                {
                    hide = hide.Trim();
                    if (hide != "1")
                    {
                        hide = "2";
                    }
                }
                else
                {
                    hide = "2";
                }
                cookieDate = cookieDate.Trim();
                switch (cookieDate)
                {
                    case "0":
                        break;
                    case "1":
                        cookiedays = 1;
                        break;
                    case "2":
                        cookiedays = 30;
                        break;
                    case "3":
                        cookiedays = 365;
                        break;
                    default:
                        cookieDate = "0";
                        break;
                }
                cookieString = "userid=" + dtLogin.Rows[0]["LoginID"].ToString() + "&";
                cookieString += "username=" + Server.UrlEncode(dtLogin.Rows[0]["NickName"].ToString().Trim()).ToUpper() + "&";
                cookieString += "usercookies=" + cookieDate + "&";
                cookieString += "userhidden=" + hide + "&";
                cookieString += "password=" + truePassword + "&";
                cookieString += "userclass=" + Server.UrlEncode(groupName).ToUpper() + "&";
                cookieString += "StatUserID=6275890";

                HttpCookie hck = new HttpCookie("DvForum");
                hck.Domain = ".topfo.com";
                hck.Value = cookieString;
                hck.Path = "/";
                if (cookiedays != 0)
                {
                    hck.Expires = DateTime.Now.AddDays(cookiedays);
                }
                Response.Cookies.Add(hck);
            }

        }
    }

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
       // SelfCreateWeb.BLL.BLoginUser.ClientLogout();

    }
}