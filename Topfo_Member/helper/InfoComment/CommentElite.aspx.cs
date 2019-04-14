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

public partial class helper_InfoComment_CommentElite : System.Web.UI.Page
{
    private bool isLogin = false;
    private int infoId ;
    private string strLoginType = "";
    private string strRoleName = "";
    private string strLoginName = "";
    private string strPassword = "";
    private string strCarID = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"].Trim() != "")
        {
            infoId = Convert.ToInt32(Request.QueryString["id"].Trim());
        }
        if (Page.User.Identity.Name.ToString().Trim() != "")
        {
            strLoginName = Page.User.Identity.Name.ToString().Trim();
            this.divLogin.Visible = false;
            isLogin = true;
        }
        else
        {
            this.divLogin.Visible = true;
            isLogin = false;
        }
        if (!Page.IsPostBack)
        {
            ViewState["CurrPage"] = 1;
            bind();
        }
    }
    public string GetStr(object str, int _lenght)
    {
        if (str.ToString().Length > _lenght)
        {
            return str.ToString().Substring(0, _lenght);
        }
        else
        {
            return str.ToString();
        }
    }
    public void bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        long PageSize = 3;
        DataTable dt = dal.GetList("InfoCommentTab", "ID", "*", "InfoID="+infoId, "ID desc", ref CurrPage, PageSize, ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(PageSize)).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        Pager();
        ComentList.DataSource = dt;
        ComentList.DataBind();
    }
    #region 翻页
    public void Pager()
    {
        if (ViewState["CurrPage"].ToString() == lblPageCount.Text)
        {
            NextPage.Enabled = false;
            LastPage.Enabled = false;
            if (lblPageCount.Text != "1")
            {
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (Convert.ToInt32(ViewState["CurrPage"]) < Convert.ToInt32(lblPageCount.Text))
        {

            if (lblPageCount.Text != "1")
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (ViewState["CurrPage"].ToString() == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            if (Convert.ToInt32(lblPageCount.Text) > 1)
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
            }
        }
        if (lblCount.Text == "0" || lblCount.Text == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            NextPage.Enabled = false;
            LastPage.Enabled = false;
        }
    }
    protected void button_ServerClick(object sender, EventArgs e)
    {
        bind();
    }
    protected void FirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = 1;
        bind();
    }
    protected void PerPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        bind();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        bind();
    }
    protected void LastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = lblPageCount.Text;
        bind();
    }
    protected void btnGo_ServerClick(object sender, EventArgs e)
    {
        if (Tz888.Common.Utility.PageValidate.IsNumber(txtPage.Value.Trim()))
        {
            ViewState["CurrPage"] = txtPage.Value.Trim();
            bind();
        }
    }

    #endregion
    protected void btnOk_Click(object sender, EventArgs e)
    {
        string commentName = "";
        if (isLogin)
        {
            commentName = strLoginName;
            //Response.Write("<script>alert('姓名不能为空')</script>");
        }
        else
        {
            Tz888.Common.MessageBox.ShowAndHref("不能评论，请您登录后评论！", this.Request.Url.ToString());
            return;
        }
        if (this.txtComment.Text.Trim() == "")
        {
            Tz888.Common.MessageBox.ShowAndHref("评论不能为空！", this.Request.Url.ToString());

        }
        else
        {
            Tz888.BLL.LeaveMsg msgBll = new Tz888.BLL.LeaveMsg();
            Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
            model.CommentTime = DateTime.Now;
            model.InfoID = infoId;
            model.FatherID = 0;
            model.CommentContent = this.txtComment.Text;
            //model.LoginName = loginname;
            model.LoginName = commentName;
            bool result = msgBll.SetResponse(model);
            Tz888.Common.MessageBox.ShowAndHref("留言成功", this.Request.Url.ToString());
            this.txtComment.Text = "";
        }

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
        }
        else
        {
            InsertLoginErrorLog(strLoginName);

            if (dt.Rows.Count == 0)
            {
                Tz888.Common.MessageBox.ShowAndHref("输入的用户名或密码不正确,请重新登录！", this.Request.Url.ToString());
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
    protected void btnLogin_ServerClick(object sender, EventArgs e)
    {
        strLoginName = txtName.Text.ToString().Trim();
        strPassword = txtPwd.Text.ToString().Trim();
        if (strLoginName == "" || strPassword == "")
        {
            Tz888.Common.MessageBox.ShowAndHref("用户名或密码不能为空", this.Request.Url.ToString());
            return;
        }

        strCarID = this.txtName.Text.Trim();
        int LoginTimeRange = Convert.ToInt32(Common.GetLoginTimeRange());
        int AllowErrorTimes = Convert.ToInt32(Common.GetAllowErrorTimes());

        DoLogin();
    }
}
