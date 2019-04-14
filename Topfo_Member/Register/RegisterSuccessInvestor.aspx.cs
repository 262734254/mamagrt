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


public partial class Register_RegisterSuccessInvestor : System.Web.UI.Page
{
    private string Tname = "";
    private string TpassWord = "";
    private string TEmail = "";
    private string Tact = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbtTop_Click(object sender, EventArgs e)
    {
        Display();
    }

    private void Display()
    {
        Tname = Tz888.Common.DEncrypt.DEncrypt.Decrypt(Request.QueryString["logname"]);
        TpassWord = Tz888.Common.DEncrypt.DEncrypt.Decrypt(Request.QueryString["PassWord"]);
        //验证用户名与密码是否正确
        int ErrorID = 0;
        string ErrorMsg = "";
        LoginInfoBLL loginRule = new LoginInfoBLL();
        DataTable dt = new DataTable();

        dt = loginRule.Authenticate(
            Tname,
            0,
            TpassWord,
            false,
            ref ErrorID,
            ref ErrorMsg);

        if (dt.Rows.Count > 0) 
        {
            //写登陆cookie开始
            HttpCookie loginedUser = new HttpCookie("loginedUser");
            loginedUser.Expires = DateTime.Now.AddDays(1);
            loginedUser.Value = Tname;
            Response.Cookies.Add(loginedUser);
            //写登陆cookie结束
            Tz888.BLL.Login.LoginInfoBLL.Logout();

            //分配验证票,同时建立角色信息		
            LoginInfoBLL.SetUserFormsCookie(Tname, dt.Rows[0]["MemberGradeID"].ToString().Trim(), dt.Rows[0]["ManageTypeID"].ToString().Trim(), true);
            #region  登录后SESSION记录 用户名，用户角色以及 角色组
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dtUser = dal.GetList("VipApplyTab", "BuyTerm", "ApplyID", 1, 1, 0, 1, "LoginName='" + Tname + "'");
            string MemberType = "";
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                MemberType = dtUser.Rows[0]["BuyTerm"].ToString();
            }
            else { MemberType = "1"; }

            string[] obj = { Tname, dt.Rows[0]["ManageTypeID"].ToString().Trim(), MemberType };

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

            #region 获取跳转链接并跳转

            if (dt.Rows[0]["MemberGradeID"].ToString().Trim() == "1002")
            {
                //拓富会员
                Response.Redirect("../indexTof.aspx");
            }
            else
            {
                //普通会员
                //Response.Redirect("http://member.topfo.com/index.aspx");
                Response.Redirect("../index.aspx");
            }
            #endregion
        }
    }
}
