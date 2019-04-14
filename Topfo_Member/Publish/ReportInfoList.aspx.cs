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
public partial class Publish_ReportInfo : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
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
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!Page.IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        long CurrPage = 0;
        long TotalCount = 0;
        string strWhere = " ReportMan=''";
        if (Request.QueryString["InfoID"] != null)
        {
            strWhere = "  InfoID='" + Request.QueryString["InfoID"].ToString() + "'";
        }
        DataTable dt = dal.GetList("InfoReportViw", "ID", "*", strWhere, "ID desc", ref CurrPage, 15, ref TotalCount);
        InfoList.DataSource = dt;
        InfoList.DataBind();
    }
    public string GetCount(long infoid)
    {
        DataTable dt = dal.GetList("InfoReportTab", "InfoID", "InfoID", 1, 1, 1, 1, "InfoID=" + infoid);
        return dt.Rows[0].ItemArray[0].ToString();
    }
    public string GetUrl(string isChecked, string InfoID, string ID)
    {
        string url = "";
        if (isChecked.Trim() == "1")
        {
            url = "已处理";
        }
        else
        {
            url = "未处理";
        }
        return url;
    }
}
