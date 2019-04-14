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
public partial class PayManage_ticket_trade_list : System.Web.UI.Page
{
    Tz888.BLL.Conn bll = new Tz888.BLL.Conn();
    public string LoginName = "";
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
        LoginName = Page.User.Identity.Name;
        if (LoginName == null || LoginName == "")
        {
            Response.Redirect("../Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            ViewState["pagesize"] = 15;
            ViewState["CurrPage"] = 1;
            ViewState["strWhere"] = "LoginName='" + LoginName + "'";
            bind();
        }

    }

    public void bind()
    {
        string strWhere = ViewState["strWhere"].ToString();
        
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        long PageSize = Convert.ToInt64(ViewState["pagesize"]);
        lblUserPoint.Text = OnlineStrike.getUserPoint(LoginName).ToString();


        DataTable dt = bll.GetList("VoucherConsumeRecViw", "ConsumePoint", "*", strWhere, "ConvsumeDate desc", ref CurrPage, PageSize, ref TotalCount);
        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(PageSize)).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        Pager();
        myList.DataSource = dt;
        myList.DataBind();


    }
    private void MakeCriteria(ref System.Text.StringBuilder Criteria)
    {
        if (ddldiff.Value.Trim() != "")
        {
            if (ddldiff.Value.Trim() == "90")
            {
                Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "DateDiff(d,ConvsumeDate,getdate())>", "90", false, false);
            }
            else
            {
                Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "DateDiff(d,ConvsumeDate,getdate())<", ddldiff.Value.Trim(), false, false);
            }
        }
        if (ddltype.Value.Trim() != "")
        {
            Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "InfoTypeID", ddltype.Value.Trim(), true, true);
        }
    }
    protected void button_ServerClick(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        MakeCriteria(ref sb);
        ViewState["strWhere"] = sb.ToString();
        bind();
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
    #region 翻页
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

