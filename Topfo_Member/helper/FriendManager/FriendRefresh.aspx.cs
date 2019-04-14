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

public partial class helper_FriendManager_FriendRefresh : System.Web.UI.Page
{
    private string contactName = "";
    private string loginName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("/Login.aspx");
        }
        if ((Request.QueryString["contact"] != null) && (Request.QueryString["contact"] != ""))
        {
            contactName = Request.QueryString["contact"].ToString().Trim();
            loginName = Page.User.Identity.Name;
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
        Tz888.BLL.GoodFriend friendBll = new Tz888.BLL.GoodFriend();
        Tz888.Model.GoodFriend friend = new Tz888.Model.GoodFriend();
        friend.LoginName = loginName;//"clandylee";
        friend.ContactName = contactName;//"kittycat";
        //好友资源更新
        DataTable dt = friendBll.ResourceRefreshDT(friend);

        friendRefreshGridView.DataSource = dt;
        friendRefreshGridView.DataBind();
    }
    protected void friendRefreshGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataRowView view = e.Row.DataItem as DataRowView;
        if (view != null)
        {
            switch (view["infoTypeId"].ToString())
            {
                case "Project":
                    e.Row.Cells[0].Text = "企业项目";
                    break;
                case "Capital":
                    e.Row.Cells[0].Text = "资本资源";
                    break;
                case "Merchant":
                    e.Row.Cells[0].Text = "政府招商";
                    break;
                default :
                    e.Row.Cells[0].Text = "企业项目";
                    break;
            }
            HyperLink hlk = new HyperLink();
            hlk = (HyperLink)e.Row.FindControl("hlkTitle");
            hlk.Text = view["title"].ToString();
            hlk.NavigateUrl = "http://www.topfo.com/"+view["htmlFile"].ToString();

        }
    }
}
