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

public partial class PayManage_ticket_exchange_record : System.Web.UI.Page
{
    Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
    public int CurrPage=1;
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
        if (!Page.IsPostBack)
        {
            lblLoginName.Text = Page.User.Identity.Name;
            Tz888.BLL.AccountInfo info = new Tz888.BLL.AccountInfo();
            lblJifenCount.Text = info.account(lblLoginName.Text.Trim(), "convertjifen");//累计兑换积分
            lblVoucherNum.Text = info.account(lblLoginName.Text.Trim(), "covertcount");//累计兑换次数
            lblBalanceNum.Text = info.account(lblLoginName.Text.Trim(), "convertvouch");//累计兑换金额
            lblUseNum.Text = info.account(lblLoginName.Text.Trim(), "vouchxf");//已消费额购物券金额
            ViewState["CurrPage"] = 1;
            bind();

        }
       
    }
    public void bindfloor()
    {
        for (int i = 0; i < myList.Items.Count; i++)
        {
            Literal l1 = (Literal)myList.Items[i].FindControl("lblID");
            if (CurrPage == 1)
            {
                l1.Text = (i + 1).ToString();
            }
            else
            {
                l1.Text = ((CurrPage - 1) * 15 + i + 1).ToString();
            }
        }
    }
    public void bind()
    {
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount = 0;

        DataTable dt = dal.GetList("VoucherConvertRecTab", "VoucherID", "*", "LoginName='" + Page.User.Identity.Name + "'", "VoucherID desc", ref CurrPage, 15, ref TotalCount);
       
        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(15)).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        Pager();
        myList.DataSource = dt;
         myList.DataBind();
         bindfloor();
    }
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
}
