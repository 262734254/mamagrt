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

public partial class news_NewsTabShenHes : System.Web.UI.Page
{
    Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();
    Tz888.BLL.news.NewsTypeTabBLL newstypetabbll = new Tz888.BLL.news.NewsTypeTabBLL();
    Tz888.BLL.news.NewsViewTabBLL newsviewtabbll = new Tz888.BLL.news.NewsViewTabBLL();
    private int NewsId
    {
        get
        {
            return (int)ViewState["NewsId"];
        }
        set
        {
            ViewState["NewsId"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }
        if (!IsPostBack)
        {
            NewsId = Convert.ToInt32(Request.QueryString["str"].Trim());
            this.ddrtype.DataSource = newstypetabbll.GetAllNewsType();
            this.ddrtype.DataValueField = "TypeID";
            this.ddrtype.DataTextField = "TypeName";
            this.ddrtype.DataBind();
            BindShow();
        }
    }

    private void BindShow()
    {
        Tz888.Model.NewsTab newstab = newstabbll.GetNewsTabByNewId(NewsId);
        Tz888.Model.NewsViewTab newsviewtab = newsviewtabbll.GetNewsViewByNewId(NewsId);
        txtnewsTitle.Text = newstab.NTitle.ToString();
       
        this.ddrtype.Items.FindByValue(newstab.TypeID.ToString().Trim()).Selected = true;
        this.FreeTextBox1.Value = newsviewtab.NewView;
        txtauthor.Text = newsviewtab.Author.ToString();
        txtform.Text = newsviewtab.Formid.ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
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

        Tz888.Model.NewsTab newstab = new Tz888.Model.NewsTab();
        Tz888.Model.NewsViewTab newsviewtab = new Tz888.Model.NewsViewTab();
        newstab.NTitle = txtnewsTitle.Text.Trim();
        newsviewtab.Zhaiyao = "";
        newsviewtab.Title ="";
        newsviewtab.Keywords ="";
        newsviewtab.Description ="";
        newstab.TypeID = Convert.ToInt32(this.ddrtype.SelectedValue.Trim());
        newsviewtab.NewView = this.FreeTextBox1.Value.Trim();
        newsviewtab.Author = txtauthor.Text.Trim();
        newsviewtab.Formid = txtform.Text.Trim();
        newstab.Urlhtml = "";
        newstab.RecommendID =0;
        //修改主表
        int result1 = newstabbll.UpdateNewsTab(newstab, NewsId);

        //修改详细表
        int result2 = newsviewtabbll.UpdateNewsViewTab(newsviewtab, NewsId);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "提示f：", "s();", true);
        if (result1 > 0 && result2 > 0)
        {

            this.ClientScript.RegisterStartupScript(this.GetType(), "", "location.href='NewMange.aspx';", true);

        }
        else
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('修改失败！');", true);
        }
    }
}
