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

public partial class InnerInfo_waster2 : Tz888.Common.Pager.BasePage
{
    DataTable outDataTable = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(InnerInfo_waster2));
        if (!Page.IsPostBack)
        {
            ViewState["pagesize"] = 10;
            ViewState["CurrPage"] = 1;
        }

        getList();

    }
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
    public void getList()
    {

        string strWhere = "";
        string username =  Page.User.Identity.Name;//"hujing1210";
        strWhere = "LoginName='" + username + "'";
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;

        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("InnerInfoWasterTab", "WasterId", "*", strWhere, "WasterId desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        outDataTable = dt;
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();

        infoWasterGridView.DataSource = dt;
        infoWasterGridView.DataBind();
    }

    public string view(object view)
    {
        string name = view.ToString();
        string result = "";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "loginName='" + name.Trim() + "'";
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("loginInfoTab", "loginName", "nickName", strWhere, "loginName", ref i, k, ref j);
        if (dt != null && dt.Rows.Count>0)
        {
            result = dt.Rows[0][0].ToString();
        }
        return result;
    }

    public string viewLink(object view)
    {

        string name = view.ToString();
        string manageType = "";
        string result = "";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "loginName='" + name.Trim() + "'";
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("loginInfoTab", "loginName", "manageTypeId", strWhere, "loginName", ref i, k, ref j);
        if (dt != null && dt.Rows.Count > 0)
        {
            manageType = dt.Rows[0][0].ToString();
        }
        switch (manageType)
        {
            case "1001":
                result = "http://member.topfo.com/Register/MemberMessage_P.aspx?LoginName=" + name;
                break;
            case "1003":
                result = "http://member.topfo.com/Register/MemberMessage_E.aspx?LoginName=" + name;
                break;
            case "1004":
                result = "http://member.topfo.com/Register/MemberMessage_G.aspx?LoginName=" + name;
                break;
            default:
                result = "http://member.topfo.com/Register/MemberMessage_P.aspx?LoginName=" + name;
                break;
        }
        return result;
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
    [AjaxPro.AjaxMethod]
    public string ToRecycle(string idList)
    {
        Tz888.BLL.InnerInfo infoBll = new Tz888.BLL.InnerInfo();
        string userName = Page.User.Identity.Name;
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                bool b = infoBll.DeleteWasterInfo(Convert.ToInt32(s[i]));
            }
        }
        return "ok";
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        string loginName = Page.User.Identity.Name;
        //string loginName = "1210";//登录名
        Tz888.BLL.InnerInfo infoBll = new Tz888.BLL.InnerInfo();

        bool result = infoBll.DeleteAllWasterInfo(loginName);
        getList();

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
