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
using System.Text;
using System.Web.Security;
using System.Collections.Generic;
using System.Security.Cryptography;


public partial class test2 : System.Web.UI.Page
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
        txtUserName.Text = "topfo001";
        txtPsd.Text = "12345678";
    }
    protected void imbLogin_Click(object sender, ImageClickEventArgs e)
    {
        txtPsd.Text = "12345678";
        strLoginName = txtUserName.Text.ToString().Trim();
        strPassword = txtPsd.Text.ToString().Trim();
        if (strLoginName == "" || strPassword == "")
        {
            lblPasswordWrong.Text = "用户名或密码不能为空";
            return;
        }
        //strCarID = this.txtUserName.Text.Trim();
        //int LoginTimeRange = Convert.ToInt32(Common.GetLoginTimeRange());
        //int AllowErrorTimes = Convert.ToInt32(Common.GetAllowErrorTimes());
        //if (!CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes))
        //{
        //    Response.Write("<script>alert('连续登录次数的过多，请过两小时后重试！');location.href='/Member/Login.aspx';</script>");
        //    return;
        //}
        DoLogin();
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
            //写登陆cookie开始
            HttpCookie loginedUser = new HttpCookie("loginedUser");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = strLoginName;

            Response.Cookies.Add(loginedUser);
            //写登陆cookie结束
            Tz888.BLL.Login.LoginInfoBLL.Logout();


            //BBS登录
            Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), txtPsd.Text.Trim(), dt.Rows[0]["email"].ToString().Trim());
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
            string strReturnURL = System.Web.HttpUtility.UrlDecode(Request.Params["ReturnURL"]);
            //string strurl = "index20110314.aspx";
            string strurl = "Publish/Professional/ServiesManage.aspx";
            //string strurl = "Register/GovernmentRegister_100.aspx";
            //  string strurl = "Manage/Aajxstrike.aspx";
            //string strurl = "PayManage/trade_info_wait_100.aspx";
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
                        //Response.Redirect("http://member.topfo.com/indexTof.aspx");
                        Response.Redirect("MasterPage.master");
                    }
                    else
                    {
                        //普通会员
                        //Response.Redirect("http://member.topfo.com/index.aspx");
                        Response.Redirect("MasterPage.master");
                    }
                }
            }
            #endregion
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        strLoginName = txtUserName.Text.ToString().Trim();
        strPassword = txtPsd.Text.ToString().Trim();
        if (strLoginName == "" || strPassword == "")
        {
            lblPasswordWrong.Text = "用户名或密码不能为空";
            return;
        }
        //strCarID = this.txtUserName.Text.Trim();
        //int LoginTimeRange = Convert.ToInt32(Common.GetLoginTimeRange());
        //int AllowErrorTimes = Convert.ToInt32(Common.GetAllowErrorTimes());
        //if (!CheckLoginErrorTime(strLoginName, LoginTimeRange, AllowErrorTimes))
        //{
        //    Response.Write("<script>alert('连续登录次数的过多，请过两小时后重试！');location.href='/Member/Login.aspx';</script>");
        //    return;
        //}
        DoLogin();
    }
}
