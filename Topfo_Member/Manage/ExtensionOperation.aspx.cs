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

public partial class Manage_ExtensionOperation : System.Web.UI.Page
{
    long intCurrentPage = 1;
    long intCurrentPageSize = 1;
    long intTotalCount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }

        // 在此处放置用户代码以初始化页面
        if (!Page.IsPostBack)
        {
            bool isValid = false;
            long id = 0;
            try
            {
                id = Convert.ToInt64(Request.QueryString["id"].Trim());
            }
            catch
            {
                id = 0;
            }
            if (id != 0)
            {
                ViewState["InfoID"] = id;
                Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
                DataTable dt = bll.GetMainInfoViewList("*", "InfoID = " + id.ToString(), "", ref intCurrentPage, intCurrentPageSize, ref intTotalCount);

                if (dt!=null)
                {
                    try
                    {
                        if (dt.Rows[0]["LoginName"].ToString().Trim() == Page.User.Identity.Name.Trim())//获取成功
                        {
                            //if (Convert.ToDateTime(dt.Rows[0]["InfoOverdueTime"]) < DateTime.Now)
                            //{
                                isValid = true;
                                ltTitle.Text = dt.Rows[0]["Title"].ToString();
                                ltPubDate.Text = Convert.ToDateTime(dt.Rows[0]["PublishT"]).ToString("yyyy-MM-dd");
                                if(dt.Rows[0]["InfoOverdueTime"].ToString().Trim()!="")
                                {
                                    ltStartDate.Text = Convert.ToDateTime(dt.Rows[0]["InfoOverdueTime"]).ToString("yyyy-MM-dd");
                                }
                            //}
                        }
                    }
                    catch { }
                }
            }
            if (!isValid)
            {
                Response.Redirect("./ResourceManage_Pass.aspx");
            }
        }
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
    protected void ibModify_Click(object sender, EventArgs e)
    {
        long id = Convert.ToInt64(ViewState["InfoID"]);
		DateTime startDay = DateTime.Now;
		int term = Convert.ToInt32(stTerm.Value.Trim());

        Tz888.BLL.Info.MainInfoBLL bll = new Tz888.BLL.Info.MainInfoBLL();
        bll.ChangeValidTerm(id, startDay, term);
        Tz888.Common.MessageBox.ShowAndHref("更新成功！", Request.Url.ToString());
    }
}
