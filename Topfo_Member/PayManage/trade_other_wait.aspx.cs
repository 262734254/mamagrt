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

public partial class PayManage_trade_other_wait : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    public string loginname = "";
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
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManage_trade_other_wait));
        loginname = Page.User.Identity.Name;
        if (!Page.IsPostBack)
        {
            ViewState["CurrPage"] = 1;
            ViewState["pagesize"] = 15;
            ViewState["strWhere"] = "PayStatus=0 and payStatus<>10 and BuyType<>'info' and BuyType<>'cz' and LoginName='" + loginname + "'";
            bind();
        }
    }
    public void bind()
    {
        string strWhere = ViewState["strWhere"].ToString();
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;
        lblUserPoint.Text = OnlineStrike.getUserPoint(loginname).ToString();

        DataTable dt = dal.GetList("OrderTab", "OrderNo", "*", strWhere, "OrderNo desc", ref CurrPage, Convert.ToInt64(ViewState["pagesize"]), ref TotalCount);

        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(ViewState["pagesize"])).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        Pager();
        myList.DataSource = dt;
        myList.DataBind();
    }
    private void MakeCriteria(ref System.Text.StringBuilder Criteria)
    {
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "PayStatus=", "0", false, false);
        Tz888.Common.MakeCriteria.AddCriteria(ref Criteria, "LoginName=", loginname, true, false);
        Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "BuyType<>", "info", true, false);
        Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "PayStatus<>", "10", false, false);
        Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "BuyType<>", "cz", true, false);
        if (sDiff.Value.Trim() == "90")
        {
            Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "DateDiff(d,PayDate,getdate())>","90", false, false);
        }
        if (sDiff.Value.Trim() == "60" || sDiff.Value.Trim() == "30" || sDiff.Value.Trim() == "7")
        {
            Tz888.Common.MakeCriteria.AddNonCriteria(ref Criteria, "DateDiff(d,PayDate,getdate())<",sDiff.Value.Trim(),false,false);
        }
    }
    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        MakeCriteria(ref sb);
        ViewState["strWhere"] = sb.ToString();
        bind();
    }
    [AjaxPro.AjaxMethod]
    public bool deletelist(string orderNo)
    {

        Tz888.BLL.OrderManage dal = new Tz888.BLL.OrderManage();
        string[] a = orderNo.Split(',');
        bool b = true;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i].Trim() != "")
            {
                b = dal.deleOtherOrder(Convert.ToInt64(a[i].Trim()), 1);
            }
        }
        return b;
    }

    public string GetTitle(object str, object orderNo)
    {
        if (str.ToString().Trim() == "sms")
        {
            return "购买通知短信" + GetCount(orderNo.ToString()) + "条";
        }
        if (str.ToString().Trim() == "card")
        {
            return "购买充值卡" + GetCount(orderNo.ToString()) + "张";
        }

        if (str.ToString().Trim() == "promotion")
        {
            return "购买推广短信" + GetCount(orderNo.ToString()) + "条";
        }
        else
        {
            return "";
        }
    }
    public string GetCount(string orderno)
    {
        DataTable dtCount = dal.GetList("SmsConsumeRecViw", "sum(Quantity) as s", "s", 1, 1, 0, 1, "orderno=" + Convert.ToInt64(orderno));
        int count = Convert.ToInt32(dtCount.Rows[0].ItemArray[0]);
        return count.ToString();
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

    #region 函数
    public string GetType(object str)
    {
        if (str.ToString().Trim() == "sms")
        {
            return "短信";
        }
        if (str.ToString().Trim() == "card")
        {
            return "充值卡";
        }
        if (str.ToString().Trim() == "tuofo")
        {
            return "开通会员";
        }
        if (str.ToString().Trim() == "promotion")
        {
            return "短信";
        }
        else
        {
            return "";
        }
    }
    #endregion
}
