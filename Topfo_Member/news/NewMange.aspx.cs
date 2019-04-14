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

public partial class news_NewMange : System.Web.UI.Page
{
    Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
    Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
    Tz888.BLL.news.NewsViewTabBLL newsviewtabbll = new Tz888.BLL.news.NewsViewTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Page.User.Identity.Name;
        username.Value = name.Trim();
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("~/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
        }
        if (!IsPostBack)
        {
            this.ddlInfoType.DataSource = newstypetabbll.GetAllNewsType();
            this.ddlInfoType.DataValueField = "TypeID";
            this.ddlInfoType.DataTextField = "TypeName";
            this.ddlInfoType.DataBind();
            ListItem list = new ListItem();
            list.Value = "-1";
            list.Text = "请选择";
            ddlInfoType.Items.Add(list);
            ddlInfoType.Items.FindByValue("-1").Selected = true;
        }
    }


}
