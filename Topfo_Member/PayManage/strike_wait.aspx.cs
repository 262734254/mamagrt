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

public partial class PayManage_strike_wait : System.Web.UI.Page
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
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        AjaxPro.Utility.RegisterTypeForAjax(typeof(PayManage_strike_wait));
        if (!Page.IsPostBack)
        {
            DataTable dttype = dal.GetList("setPayTypeTab", "*", "instant", 20, 1, 0, 1, "");
            sType.DataTextField = "PayTypeName";
            sType.DataValueField = "PayTypeCode";
            sType.DataSource = dttype;
            sType.DataBind();

            ListItem lit1 = new ListItem("---全部---", "all");
            sType.Items.Add(lit1);
            sType.Items[sType.Items.Count - 1].Selected = true;

            ViewState["CurrPage"] = 1;
            bind();
        }
    }
    public void bind()
    {
        long CurrPage = Convert.ToInt64(ViewState["CurrPage"]);
        long TotalCount=0;
        string loginname = Page.User.Identity.Name;
        string str = "LoginName='" + loginname + "'and Status<>1 and Status<>10";
        string strWhere = "";
        //无查询条件
        if (sDiff.Value.Trim() == "all" && sDiff.Value.Trim() == "all" && txtLoginName.Value.Trim() == "")
        {
            strWhere = str;
        }
        //按照时间查询
        if (sDiff.Value.Trim() != "all" && sType.Value.Trim() == "all" && txtLoginName.Value.Trim() == "")
        {
            if (sDiff.Value.Trim() == "90")//三个月以上
            {
                strWhere =str+ " and DateDiff(d,PayTime,getdate())>90";
            }
            else
            {
                strWhere = str + " and DateDiff(d,PayTime,getdate())<" + Convert.ToInt32(sDiff.Value.Trim());
            }
        }
        //按照充值方式查询
        if (sDiff.Value.Trim() == "all" && sType.Value.Trim() != "all" && txtLoginName.Value.Trim() == "")
        {
            strWhere = str + " and PayType='" + sType.Value.Trim() + "'";
        }
        //按照充值用户名称查询
        if (sDiff.Value.Trim() == "all" && sType.Value.Trim() == "all" && txtLoginName.Value.Trim() != "")
        {
            strWhere = str + "  and StrikeLoginName='" + txtLoginName.Value.Trim() + "'";
        }
        //按充值时间与充值方式查询
        if (sDiff.Value.Trim() != "all" && sType.Value.Trim() != "all" && txtLoginName.Value.Trim() == "")
        {

            if (sDiff.Value.Trim() == "90")
            {
                strWhere = str + " and DateDiff(d,PayTime,getdate())>90 and  PayType='" + sType.Value.Trim() + "'";
            }
            else
            {
                strWhere = str + "  and PayType='" + sType.Value.Trim() + "' and DateDiff(d,PayTime,getdate())<" + Convert.ToInt32(sDiff.Value.Trim());
            }
        }
        //按充值时间与充值用户查询
        if (sDiff.Value.Trim() != "all" && sType.Value.Trim() == "all" && txtLoginName.Value.Trim() != "")
        {
            if (sDiff.Value.Trim() == "90")
            {
                strWhere = str + " and DateDiff(d,PayTime,getdate())>90 and  StrikeLoginName='" + txtLoginName.Value.Trim() + "'";
            }
            else
            {
                strWhere = str + "  and StrikeLoginName='" + txtLoginName.Value.Trim() + "' and DateDiff(d,PayTime,getdate())<" + Convert.ToInt32(sDiff.Value.Trim());
            }
        }
        //按充值方式与充值用户查询
        if (sDiff.Value.Trim() == "all" && sType.Value.Trim() != "all" && txtLoginName.Value.Trim() != "")
        {
            strWhere = str + "  and PayType='" + sType.Value.Trim() + "' and StrikeLoginName='" + txtLoginName.Value.Trim() + "'";
        }
        //全部条件查询
        if (sDiff.Value.Trim() != "all" && sType.Value.Trim() != "all" && txtLoginName.Value.Trim() != "")
        {
            strWhere = str + "  and PayType='" + sType.Value.Trim() + "' and StrikeLoginName='" + txtLoginName.Value.Trim() + "' and DateDiff(d,PayTime,getdate())<" + Convert.ToInt32(sDiff.Value.Trim());
        }
        DataTable dt = dal.GetList("StrikeOrderviw", "OID", "*", strWhere, "OID desc", ref CurrPage,15, ref TotalCount);
        DataTable dtPoint = dal.GetList("StrikeOrderviw", "sum(TransMoney) as paypoint", "paypoint", 1, 1, 0, 1, strWhere);

        lblCount.Text = TotalCount.ToString();
        lblPageCount.Text = System.Math.Ceiling(Convert.ToDouble(TotalCount) / Convert.ToDouble(15)).ToString();
        lblCurrPage.Text = CurrPage.ToString();
        txtPage.Value = CurrPage.ToString();
        lblCount.Text = TotalCount.ToString();
        lblCount1.Text = TotalCount.ToString();
        lblPoint.Text = dtPoint.Rows[0]["paypoint"].ToString();
        Pager();
        myList.DataSource = dt;
        myList.DataBind();
    }
    [AjaxPro.AjaxMethod]
    public bool deleteOrd(string orderno)
    {
        Tz888.BLL.OrderManage dal = new Tz888.BLL.OrderManage();
        string[] orderlist = orderno.Split(',');
        bool b=true;
        for (int i = 0; i < orderlist.Length; i++)
        {
            if (orderlist[i].Trim() != "")
            {
                b = dal.deleStrikeOrder(orderlist[i].Trim(), 1);
            }
        }
        return b;
    }

    #region 
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

    protected void btnSearch_ServerClick(object sender, EventArgs e)
    {
        bind();
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
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) - 1;
        bind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        ViewState["CurrPage"] = Convert.ToInt64(ViewState["CurrPage"]) + 1;
        bind();
    }
    #endregion
}
