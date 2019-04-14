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
using Tz888.Model;
using Tz888.Common.Pager;


public partial class news_NewTab : System.Web.UI.Page
{
    Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
    Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            BindShow();
        }
    }

    private void BindShow()
    {
        this.ddrtype.DataSource = newstypetabbll.GetAllNewsType();
        this.ddrtype.DataValueField = "TypeID";
        this.ddrtype.DataTextField = "TypeName";
        this.ddrtype.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Tz888.Model.NewsTab newstab = new NewsTab();
        Tz888.Model.NewsTypeTab newstypetab = new NewsTypeTab();
        Tz888.Model.NewsViewTab newsviewtab = new NewsViewTab();
        if (txtnewsTitle.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入标题');", true);
            return;
        }
        if (FreeTextBox1.Value.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入内容');", true);
            return;
        }
        if (txtauthor.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入作者');", true);
            return;
        }
        if (txtform.Text.Trim() == "")
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('请输入来源');", true);
            return;
        }
        newstab.UserName = Page.User.Identity.Name;
        newstab.TypeID = Convert.ToInt32(this.ddrtype.SelectedValue);
        newstab.NTitle = txtnewsTitle.Text.Trim();
        newstab.Audit = 0;
        newstab.Urlhtml = "";
         newstab.RecommendID = 0;
        newstab.Createdate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
        newstab.FromID = 2;
        newsviewtab.Title ="";
        newsviewtab.Keywords ="";
        newsviewtab.Description ="";
        newsviewtab.NewView = FreeTextBox1.Value.Trim();
        newsviewtab.Formid = txtform.Text.Trim();
        newsviewtab.Author = txtauthor.Text.Trim();
        newsviewtab.Zhaiyao ="";
        int result = newstabbll.InsertNewsTab(newstab, newstypetab, newsviewtab);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "s();", true);
        if (result > 0)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='NewMange.aspx';", true);
        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('录入失败');", true);
        }
    }
}
