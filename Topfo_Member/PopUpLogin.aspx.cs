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

/// <summary>
/// 创业、商机信息最终页面查看联系方式的小登陆窗
/// </summary>
public partial class PopUpLogin : System.Web.UI.Page
{
    private string strLoginType = "";
    private string strRoleName = "";
    private string strLoginName = "";
    private string strPassword = "";
    private string strCarID = "";
    private bool blIsChekUp;
    string hide = "2";
    string cookieDate = "0";

    private string strRndNum = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ReturnUrl"] != null)
        {
            this.ViewState["ReturnURL"] = Request.QueryString["ReturnUrl"].Trim();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //检查验证码
        try
        {
            strRndNum = Session["valationNo"].ToString().Trim();
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }

        if (txtValidate.Text.Trim().ToLower() != strRndNum.ToLower())
        {
            lblValidate.Text = "验证码不对!";
            lblValidate.Visible = true;
            return;
        }

        strLoginName = this.txtLoginName.Text.ToString().Trim();
        strPassword = this.txtPassword.Text.ToString().Trim();
        if (strLoginName == "" || strPassword == "")
        {
            lblPasswordWrong.Text = "用户名或密码不能为空";
            return;
        }
        strCarID = this.txtLoginName.Text.Trim();
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

    #region //登录
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
            InsertLoginLog(strLoginName, strRoleName);
            Tz888.BLL.Login.LoginInfoBLL.Logout();
            //BBS登录
            Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), strPassword, dt.Rows[0]["email"].ToString().Trim());
            //分配验证票,同时建立角色信息
            LoginInfoBLL.SetUserFormsCookie(strLoginName, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), true);

            if (!(HttpContext.Current.User == null))
            {
                if (HttpContext.Current.User.Identity.AuthenticationType == "Forms")
                {
                    System.Web.Security.FormsIdentity id;
                    id = (System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity;
                    String[] myRoles = new String[4];
                    myRoles[0] = "2001";
                    myRoles[1] = "2002";
                    myRoles[2] = "2003";
                    myRoles[3] = "2004";
                    HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(id, myRoles);
                }
            }

            string strReturnURL = System.Web.HttpUtility.UrlDecode(Request.Params["ReturnURL"]);
            string strurl = "Index.aspx";
            if (Request.QueryString["url"] != null)
            {
                strurl = Request.QueryString["url"].ToString();
            }
            string strSimpleRetrun = Request.Params["Simple"];

            if (strReturnURL != null)
            {
                Response.Redirect(strReturnURL);
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
    private void CreateLoginErrorLog(string strLoginName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginErrorLog(strLoginName, dtLoginTime, strLoginIP, true);
    }
    #endregion
}
