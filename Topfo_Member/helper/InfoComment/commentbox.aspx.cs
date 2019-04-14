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
public partial class helper_InfoComment_commentbox : System.Web.UI.Page
{
    public long InfoID;
    public string pageurl = "";
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
        InfoID = Convert.ToInt64(Request.QueryString["id"]);
        pageurl = Request.QueryString["url"].ToString();
        if (Page.User.Identity.Name == "")
        {
            divLogin.Visible = true;
            divLoginOk.Visible = false;
        }
        else
        {
            divLogin.Visible = false;
            divLoginOk.Visible = true;
            Tz888.BLL.Register.MemberInfoBLL regObj = new Tz888.BLL.Register.MemberInfoBLL();
            lblNickName.Text = regObj.getNickName(Page.User.Identity.Name);
        }
        this.btnSend.Attributes.Add("onclick", "loading();");
    }

   

    //发布评论
    public void SendComment()
    {
        string commentName = "";
        Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
        Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
        model.CommentTime = DateTime.Now;
        model.InfoID = Convert.ToInt32(InfoID);
        model.FatherID = 0;
        model.CommentContent = this.txtContent.Text;
        model.LoginName = Page.User.Identity.Name;
        bool result = msgBll.SetResponse(model);
        if (result)
        {
            if (pageurl != "")
            {
                Response.Write("<script>parent.location.href='" + pageurl + "';</script>");
            }
            else
            {
                lblMsg.Text = "评论提交成功!请等待审核!";
            }
        }
        else
        {
            lblMsg.Text = "评论提交失败";
        }
    }
    //登陆
    public void doLogin()
    {
        #region //会员登录


        //验证用户名与密码是否正确
        int ErrorID = 0;
        string ErrorMsg = "";
        LoginInfoBLL loginRule = new LoginInfoBLL();
        DataTable dt = new DataTable();
        strLoginName = txtLoginName.Value.Trim();
        strPassword = txtPassWord.Value.Trim();
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
            //Tz888DZLogin.BBSLogin(dt.Rows[0]["NickName"].ToString().Trim(), txtPsd.Text.Trim(), dt.Rows[0]["email"].ToString().Trim());
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
            divLogin.Visible = false;
            divLoginOk.Visible = true;
            lblNickName.Text = dt.Rows[0]["NickName"].ToString();
        }
        else
        {
            InsertLoginErrorLog(strLoginName);

            if (dt.Rows.Count == 0)
            {
                lblMsg.Text = "<font color='red'>您输入的用户名或密码不正确,请重新登录！</font>";
            }


        }
        #endregion
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

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtLoginName.Value == "" || txtPassWord.Value == "")
        {
            lblMsg.Text = "<font color='red'>请输入用户名和密码</font>";
            return;
        }
        doLogin();
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == "")
        {
            lblMsg.Text = "<font color='red'>请先登陆.</font>";
            return;
        }
        else
        {
            if (txtContent.Text.Trim() == "")
            {
                lblMsg.Text = "<font color='red'>请输入评论内容!</font>";
                return;
            }
            SendComment();
        }
    }
}
