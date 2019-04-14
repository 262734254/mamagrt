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
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data.SqlClient;

public partial class setCookie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.QueryString["loginname"] == null)
        //{
        //    Response.Redirect("setCookie.aspx?loginname=kenwkls&checkLogin=1&infoid=sitekey6fe97759aa27a0c9&sitekey=6fe97759aa27a0c9");
        //    return;
        //}
        //http://member.topfo.com/setCookie.aspx?loginname=1207_948_hg&checklogin=1&sitekey=4a1dfdc2b83477cd&infoid=1132461

        //send_autoreg();

        if (Request.QueryString["send"] != null && Request.QueryString["send"].ToString().Trim() != "")
        {
            string sendType = Request.QueryString["send"].ToString().Trim();
            if (sendType == "adv")
            {
                send_adv();
            }
            else if (sendType == "autoreg")
            {
                send_autoreg();
            }
            else
            {
                return;
            }
        }        
    }

    #region sendType adv or autoreg
    public void send_adv()
    {
        if (Request.QueryString["advsiteID"] != null && Request.QueryString["advsiteID"].Trim() != "")
        {
            HttpCookie loginedUser = new HttpCookie("adv_cpa");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = Request.QueryString["advsiteID"].Trim();
            Response.Cookies.Add(loginedUser);
        }
    }

    public void send_autoreg()
    {
        AdSystem.siteCookie bll = new AdSystem.siteCookie();
        AdSystem.Logic loc = new AdSystem.Logic();
        bool flag = false;
        string userLoginname, siteKey, infoID;
        int isCheckLogin = Convert.ToInt32(Request.QueryString["checkLogin"]);
        userLoginname = Request.QueryString["loginname"];

        if (isCheckLogin == 0 || userLoginname.Trim() == "")
        {
            return;
        }
        else
        {
            DataTable dt = bll.getUserRegType(userLoginname);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["autoReg"].ToString().Trim() == "1")//判断用户是否为自动注册用户
            {
                //设置网站的登陆
                siteKey = Request.QueryString["sitekey"].Trim();
                infoID = Request.QueryString["infoid"].Trim();
                flag = loc.setCookie(siteKey, infoID);

                ////写登陆cookie开始
                DoLogin(userLoginname);
            }
            else
            {
                Response.Redirect("Login.aspx");
                return;
            }
        }
    }
    #endregion

    #region //登录
    private void DoLogin(string strLoginName)
    {
        int AuthenticationTickeTime = Convert.ToInt32(Common.GetAuthenticationTickeTime());
        string strRoleName = "0";

        #region //会员登录
        InsertLoginLog(strLoginName, strRoleName);

        //写登陆cookie开始
        HttpCookie loginedUser = new HttpCookie("loginedUser");
        loginedUser.Expires = DateTime.Now.AddDays(1);
        loginedUser.Value = strLoginName;
        Response.Cookies.Add(loginedUser);
        //写登陆cookie结束

        Tz888.BLL.Login.LoginInfoBLL.Logout();
        //BBS登录
        //Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), txtPsd.Text.Trim(), dt.Rows[0]["email"].ToString().Trim());
        //分配验证票,同时建立角色信息		
        LoginInfoBLL.SetUserFormsCookie(strLoginName, "1001", "2003", true);

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

}
