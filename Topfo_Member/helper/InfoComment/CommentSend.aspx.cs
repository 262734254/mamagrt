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

public partial class helper_InfoComment_CommentSend : Tz888.Common.Pager.BasePage
{
    private int commentType = 0;
    private string commentKey = "";
    public string loginname ;
    DataTable outDataTable = null;
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
    }

    public void getList()
    {
        string strWhere = "";
        loginname = Page.User.Identity.Name;//"liyanlili";

        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        switch (commentType)
        {
            case 0:  //是否回复
                strWhere = "loginName='" + loginname + "' and  IsDelete= '0'";
                break;
            case 2://已回复
                strWhere = "loginName='" + loginname + "' and  IsDelete= '0' and IsResponse= '0' and IsAudit= '0'";
                break;
            case 1: //未回复
                strWhere = "loginName='" + loginname + "'  and IsDelete= '0' and IsResponse= '1' or IsAudit!= '0'";
                break;
        }
        if (ddlCommentTime.SelectedValue == "0")
        {
            strWhere += "";
        }
        if (ddlCommentTime.SelectedValue == "91")
        {
            strWhere += " and DateDiff(d,CommentTime,getdate())>90 ";
        }
        else
        {
            strWhere += " and DateDiff(d,CommentTime,getdate())<" + Convert.ToInt32(ddlCommentTime.SelectedValue);
        }
        if (this.txtCommentSelect.Text.Trim() == "输入关键字")
        {
            this.txtCommentSelect.Text = "";
        }
        if (this.txtCommentSelect.Text.Trim() != "")
        {
            strWhere += " and (CHARINDEX('" + this.txtCommentSelect.Text.Trim() + "'," + "commentContent" + ")>0)";
        }
        DataTable dt = dal.GetList("InfoCommentManagerVIW", "InfoID", "LoginName,InfoID,Title,CommentContent,CommentTime,ID,IsAudit,IsResponse",
            strWhere, "CommentTime desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        outDataTable = dt;
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        rptCommentSend.DataSource = dt;
        rptCommentSend.DataBind();
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

    #region  点击查询
    protected void btnCommentSelect_Click(object sender, EventArgs e)
    {
        commentType=Convert.ToInt32(this.ddlCommentType.SelectedValue);
        commentKey = this.txtCommentSelect.Text.ToString();//文本查询还有问题
        getList();
    }
    #endregion
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
    protected void btnOutExcel_Click(object sender, EventArgs e)
    {

    }
    public void InfoCommentMakeCriteria(ref StringBuilder Criteria)
    {
        //设置绑定查询条件
        //string infoOwner = Session["LoginName"].ToString();
        string commentTime = "91";
        commentTime = this.ddlCommentTime.SelectedValue;
        if (commentType == 0)
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "LoginName=", loginname, true, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "fatherId=", "0", false, false);
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "IsDelete=", "0", false, false);
            if ((commentKey.Trim() != "") && (commentKey.Trim() != "输入关键字"))
            {
                Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "commentContent", commentKey,true, true);
            }
            //Tz888.Common.MakeCriteria.AddDTCriteria(ref Criteria, "CommentTime", DateTime.Today.Subtract(new TimeSpan(Convert.ToInt32(commentTime), 0, 0, 0)).ToString(), DateTime.Today.ToString());
        }
        else if (commentType == 1)
        {
        }
        else if (commentType == 2)
        {
        }
        
    }

    protected void btnOut_Click(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.DataGrid dgExport = null;
        // 当前对话 
        System.Web.HttpContext curContext = System.Web.HttpContext.Current;
        // IO用于导出并返回excel文件 
        System.IO.StringWriter strWriter = null;
        System.Web.UI.HtmlTextWriter htmlWriter = null;


        // 设置编码和附件格式 
        curContext.Response.ContentType = "application/vnd.ms-excel";
        curContext.Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        curContext.Response.Charset = "";

        // 导出excel文件 
        strWriter = new System.IO.StringWriter();
        htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);


        dgExport = new System.Web.UI.WebControls.DataGrid();
        string filename = "leaveMsgSend";
        dgExport.DataSource = outDataTable;
        dgExport.AllowPaging = false;
        dgExport.DataBind();

        // 返回客户端 
        dgExport.RenderControl(htmlWriter);
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + filename + ".xls");
        curContext.Response.Write(strWriter.ToString());
        curContext.Response.End();
    }
}
