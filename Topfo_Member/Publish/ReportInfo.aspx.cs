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
        string strWhere = "ID  IN(SELECT MIN(ID) FROM InfoReportViw  GROUP BY InfoID)";
        DataTable dt = null;
        if (Request.QueryString["ID"] != null)
        {
            strWhere = " ReportID='" + Request.QueryString["ID"].ToString() + "'";
            lbCheckTime.Text = DateTime.Now.ToShortDateString();
            lbCheckMan.Text = Page.User.Identity.Name;
            dt = dal.GetList("ReportReplayInfoViw", "ID", "*", strWhere, "ID desc", ref CurrPage, 15, ref TotalCount);
        }
        
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lbTitle.Text = dt.Rows[i]["Title"].ToString();
                lbInfoTypeID.Text = dt.Rows[i]["InfoTypeID"].ToString();
                lbContent.Text = dt.Rows[i]["ReplayContent"].ToString();
                lbCheckTime.Text = dt.Rows[i]["ReplayDate"].ToString();
            }
        }
    }
}
