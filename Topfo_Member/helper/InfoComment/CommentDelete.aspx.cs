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
using System.Text;

public partial class helper_InfoComment_CommentDelete : Tz888.Common.Pager.BasePage
{
    private int commentNumber = 0;
    public string loginname;
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");

        if (isTof)
        {
            Page.MasterPageFile = "/indexTof.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AjaxPro.Utility.RegisterTypeForAjax(typeof(helper_InfoComment_CommentDelete));

        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }

        //首页中判断是否拓富通会员
        if (!IsPostBack)
        {
            ViewState["pagesize"] = 10;
            ViewState["CurrPage"] = 1;
        }
        getList();
        //this.btnDeleteSelect.Attributes.Add("onClick", "return window.confirm('确定删除所选记录？')");
    }

    public void getList()
    {
        string strWhere = "";
        loginname = Page.User.Identity.Name;//"yld123";

        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        strWhere = "loginName='" + loginname + "' and IsDelete='1' ";


        DataTable dt = dal.GetList("InfoCommentManagerVIW", "InfoID", "LoginName,InfoID,Title,CommentContent,CommentTime,ID,IsAudit,IsResponse",
            strWhere, "CommentTime desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        this.lbCommentNum.Text = TotalCount.ToString();
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        rptCommentDelete.DataSource = dt;
        rptCommentDelete.DataBind();

    }

    protected void FirstPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = 1;
        getList();
    }
    protected void PerPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        getList();
    }
    protected void NextPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        getList();
    }
    protected void LastPage_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = lblPageCount.Text;
        getList();
    }
    protected void btnGo_ServerClick(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = txtPage.Value.Trim();
        getList();
    }
    protected void PageSize10_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 10;
        PageSize10.ForeColor = System.Drawing.Color.Red;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    protected void PageSize20_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 20;
        PageSize20.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        getList();
    }
    protected void PageSize30_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 30;
        PageSize30.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        getList();
    }

    public void InfoCommentMakeCriteria(ref StringBuilder Criteria)
    {
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "LoginName=", loginname, true, false);
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "fatherId=", "0", false, false);
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsDelete=", "1", false, false);
    }
    protected void rptCommentDelete_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        commentNumber++;
    }
    //永久删除
    [AjaxPro.AjaxMethod]
    public string deleteAll(string idList)
    {
        Tz888.BLL.LeaveMsg leaveMsgBll = new Tz888.BLL.LeaveMsg();
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {

            if (s[i].ToString() != "")
            {
                bool b = leaveMsgBll.DeleteLeaveMsg(Convert.ToInt32(s[i]), 1);
            }
        }
        return "ok";
        
    }
    //转移
    [AjaxPro.AjaxMethod]
    public string moveMsg(string idList)
    {
        Tz888.BLL.LeaveMsg leaveMsgBll = new Tz888.BLL.LeaveMsg();
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].ToString() != "")
            {
                bool b = leaveMsgBll.RestoreLeaveMsg(Convert.ToInt32(s[i]));
            }
        }
        return "ok";
       
    }
    public string GetStr(object str, int length)
    {
        if (str.ToString().Length > length)
        {
            return str.ToString().Substring(0, length) + "……";
        }
        else
        {
            return "";
        }
    }
}
