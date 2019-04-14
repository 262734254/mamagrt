using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Tz888.BLL.Login;
using Tz888.BLL.Common;
using System.Text;
using System.Web.Security;
using System.Collections.Generic;
using System.Security.Cryptography;

public partial class Login : System.Web.UI.Page
{
    private string strLoginType = "";
    private string strRoleName = "";
    private string strLoginName = "";
    private string strPassword = "";
    private string strCarID = "";
    private bool blIsChekUp;
    string hide = "2";
    string cookieDate = "0";
    string strReturnURL = "";
    public string bbs_login = "";
    public string action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            action = Request.QueryString["action"].ToString().Trim();
        }
        if (!Page.IsPostBack)
        {
            strReturnURL = System.Web.HttpUtility.UrlDecode(Request.Params["ReturnURL"]);
            this.ViewState["strReturnURL"] = strReturnURL;
            if (strReturnURL != null)
            {
                Label1.Text = "<p align='center' style='color:#ff6600;font-size:13pt; text-align:center;font-weight:bold;'>您需要登陆后 <br />" +
                    "才能继续刚才的操作…… </p>";
            }
            else
            {
                Label1.Text = "<p align='center' style='color:#000;font-size:13pt; text-align:center;font-weight:bold;'>" +
                    "已经是拓富会员 </p>";
            }
        }


        this.imbLogin.Attributes["onClick"] = "return SetUserNameOnLogin()";
    }
    protected void imbLogin_Click(object sender, ImageClickEventArgs e)
    {
        strLoginName = txtUserName.Text.ToString().Trim();
        strPassword = txtPsd.Text.ToString().Trim();
        if (strLoginName == "" || strPassword == "")
        {
            lblPasswordWrong.Text = "用户名或密码不能为空";
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
            //BBS登录
            //BBSLogin(dt);
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

            if (action == "bbs")
            {
                Response.Redirect(System.Configuration.ConfigurationManager.AppSettings["BBS_weburl"]);
            }
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
    #endregion
    public void Redi()
    {

    }
    /// <summary>
    /// 论坛登陆
    /// </summary>
    /// <param name="dtLogin"></param>
    private void BBSLogin(DataTable dtLogin)
    {
        if (dtLogin != null && dtLogin.Rows.Count > 0)//执行论坛登陆
        {
                DiscuzLoginWS.Tz888_DiscuzLogin ws = new DiscuzLoginWS.Tz888_DiscuzLogin();
                ws.Url = System.Configuration.ConfigurationManager.AppSettings["SVSGA_URL"];
                string key = System.Configuration.ConfigurationManager.AppSettings["BBS_PasswordKey"];
                string str = ws.CheckAndCreateUser(dtLogin.Rows[0]["NickName"].ToString(), txtPsd.Text, dtLogin.Rows[0]["email"].ToString(), key);
                int uid = ws.GetUserID(dtLogin.Rows[0]["NickName"].ToString().Trim());
                string login = ws.CheckLogin(dtLogin.Rows[0]["NickName"].ToString().Trim(), txtPsd.Text, key);
                bool b = Tz888DZLogin.DZntLogin(uid, txtPsd.Text.Trim(), key);
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
    private void CreateLoginErrorLog(string strLoginName)
    {
        DateTime dtLoginTime = DateTime.Now;
        string strLoginIP = Request.UserHostAddress;
        LoginInfoBLL loginRule = new LoginInfoBLL();
        loginRule.CreateLoginErrorLog(strLoginName, dtLoginTime, strLoginIP, true);
    }
    #endregion
}
