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

public partial class InnerInfo_inbox2 : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(InnerInfo_inbox2));
        if (!Page.IsPostBack)
        {
            ViewState["pagesize"] = 10;
            ViewState["CurrPage"] = 1;

        }
        this.CheckNewGroupMsg();
        bind();
    }
    public void CheckNewGroupMsg()
    {
        Tz888.BLL.InnerInfo bll = new Tz888.BLL.InnerInfo();
        bll.CheckNewGroupMsg(Page.User.Identity.Name);
    }
    public void bind()
    {
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        string strWhere = "";
        string userName = Page.User.Identity.Name;//"huangleon";
        //string userName = "hellocindy";
        if (infoReceiveTime.SelectedValue == "0")
        {
            strWhere = "ReceivedName='" + userName + "'";
        }
        //if (infoReceiveTime.SelectedValue == "91")
        //{
        //    strWhere = "ReceivedName='" + userName + "' and DateDiff(d,ReceivedTime,getdate())>90";
        //}
        //else
        //{
        //    strWhere = "ReceivedName='" + userName + "' and DateDiff(d,ReceivedTime,getdate())<" + Convert.ToInt32(infoReceiveTime.SelectedValue);
        //}
        DataTable dt = dal.GetList("InnerInfoReceivedTab", "ReceivedID", "*", strWhere, "ReceivedID desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);
        outDataTable = dt;
        lblCount.Text = TotalCount.ToString();
        lblCurrPage.Text = CurrPage.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        myList.DataSource = dt;
        myList.DataBind();
    }
    public string status(object view)
    {
        if (view.ToString() == "0")
        {
            return "未读";
        }
        else
        {
            return "已读";
        }
    }
    public string view(object view)
    {
        string name = view.ToString().Trim().ToLower();
        if (name == "拓富网" || name == "tz888admin")
            return "拓富网";
        string result = "";
      
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "loginName='" + name.Trim() + "'";
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("loginInfoTab", "loginName", "nickName", strWhere, "loginName", ref i, k, ref j);
        if (dt != null)
        {
            result = dt.Rows[0]["nickName"].ToString();
        }
        return result;
    }

    public string viewLink(object view)
    {

        string name = view.ToString().Trim().ToLower();

        if (name == "拓富网" || name == "tz888admin")
            return "http://www.topfo.com";

        string manageType = "";
        string result = "";
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string strWhere = "";
        strWhere = "loginName='" + name.Trim() + "'";
        long i = 1;
        long j = 1;
        long k = 1;
        DataTable dt = dal.GetList("loginInfoTab", "loginName", "manageTypeId", strWhere, "loginName", ref i, k, ref j);
        if (dt != null && dt.Rows.Count>0)
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

    public string viewReply(object objname, object objid)
    {
        string name = objname.ToString().Trim().ToLower();
        if (name == "拓富网" || name == "tz888admin")
            return "";
        string id = objid.ToString().Trim();
        return "<a href=\"http://member.topfo.com/InnerInfo/infoView.aspx?Ac=1&ReceivedID=" + id + "\">回复</a>";
    }
    #region 分页
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
        ViewState["CurrPage"] = txtPage.Value.Trim();
        bind();
    }
    protected void PageSize10_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 10;
        PageSize10.ForeColor = System.Drawing.Color.Red;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        bind();
    }
    protected void PageSize20_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 20;
        PageSize20.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize30.ForeColor = System.Drawing.Color.Blue;
        bind();
    }
    protected void PageSize30_Click(object sender, EventArgs e)
    {
        ViewState["pagesize"] = 30;
        PageSize30.ForeColor = System.Drawing.Color.Red;
        PageSize10.ForeColor = System.Drawing.Color.Blue;
        PageSize20.ForeColor = System.Drawing.Color.Blue;
        bind();
    }
    #endregion
    //删除
    [AjaxPro.AjaxMethod]
    public string ToRecycle(string idList)
    {
        string userName = Page.User.Identity.Name;
        Tz888.BLL.InnerInfo infoBll = new Tz888.BLL.InnerInfo();
        string[] s = idList.Split(',');
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Trim() != "")
            {
                bool b = infoBll.InfoVirtualDelete(userName, Convert.ToInt32(s[i].Trim()), 0, "");
            }
        }
        return "ok";
    }
    protected void infoReceiveTime_SelectedIndexChanged1(object sender, EventArgs e)
    {

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