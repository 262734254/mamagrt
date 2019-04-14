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
using System.Data.SqlClient;

public partial class AdUnion_Ad_InfoOrder : Tz888.Common.Pager.BasePage
{
    Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
    public long infoID;

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Page.MasterPageFile = "~/MasterPage.master";

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
        try
        {
            infoID = Convert.ToInt64(Request.QueryString["InfoID"].ToString().Trim());
        }
        catch
        {
            Response.Write("<script type='javascript'>history.go(-1);</script>");
            Response.End();
        }
        if (!Page.IsPostBack)
        {
            ViewState["pagesize"] = 15;
            ViewState["CurrPage"] = 1;
            bind();
        }
    }

    public void bind()
    {
        string LoginName = Page.User.Identity.Name;
        string strWhere = "LoginName='" + LoginName + "'";
        //strWhere = "LoginName='tianyuying'";
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        long PageSize = Convert.ToInt64(ViewState["pagesize"]);

        try
        {
            DataTable dt = bll.GetList("Ad_InfoViw", "InfoID", "*", strWhere, " PublishT desc", ref CurrPage, PageSize, ref TotalCount);
            lblCount.Text = TotalCount.ToString();
            lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(PageSize)).ToString();
            lblCurrPage.Text = CurrPage.ToString();
            txtPage.Value = CurrPage.ToString();
            lblCount.Text = TotalCount.ToString();
            Pager();
            if (dt != null)
            {
                myList.DataSource = dt;
                myList.DataBind();
            }
        }
        catch (SqlException ex)
        {
            throw (ex);
        }

    }

    #region 页面设置方法
    public string GetTypeName(object str)
    {
        if (str.ToString().Trim() == "Capital")
        {
            return "投资资源";
        }
        if (str.ToString().Trim() == "Project")
        {
            return "融资资源";
        }
        if (str.ToString().Trim() == "Merchant")
        {
            return "招商资源";
        }
        else
        {
            return "";
        }
    }
    public string GetStr(object str, int _lenght)
    {
        if (str.ToString().Length > _lenght)
        {
            return str.ToString().Substring(0, _lenght);
        }
        else
        {
            return str.ToString();
        }
    }
    #endregion

    #region 关于翻页与页面条数的问题
    public void Pager()
    {
        if (ViewState["CurrPage"].ToString() == lblPageCount.Text)
        {
            NextPage.Enabled = false;
            LastPage.Enabled = false;
            if (lblPageCount.Text != "1")
            {
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (Convert.ToInt32(ViewState["CurrPage"]) < Convert.ToInt32(lblPageCount.Text))
        {

            if (lblPageCount.Text != "1")
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
                FirstPage.Enabled = true;
                PerPage.Enabled = true;
            }
        }
        if (ViewState["CurrPage"].ToString() == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            if (Convert.ToInt32(lblPageCount.Text) > 1)
            {
                NextPage.Enabled = true;
                LastPage.Enabled = true;
            }
        }
        if (lblCount.Text == "0" || lblCount.Text == "1")
        {
            FirstPage.Enabled = false;
            PerPage.Enabled = false;
            NextPage.Enabled = false;
            LastPage.Enabled = false;
        }
    }
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

}
