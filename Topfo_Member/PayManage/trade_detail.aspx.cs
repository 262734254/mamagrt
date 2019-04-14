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

public partial class PayManage_trade_detail1 : System.Web.UI.Page
{
    public long infoid;
    public string buytype;
    public string status;
    public long orderNo;
    protected string loginname = "";
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool isTof = Page.User.IsInRole("GT1002");
        if (isTof)
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
        else
        {
            Page.MasterPageFile = "/MasterPage.master";
        }
    }
    public string GetPoint(object point, object dispoint)
    {
        if (point.ToString() == "")
        {
            return dispoint.ToString();
        }
        else
        {
            return dispoint.ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        loginname = Page.User.Identity.Name;
        if (Request.QueryString["order_no"] != null)
        {
            orderNo = Convert.ToInt64(Request.QueryString["order_no"]);
        }
        if (Request.QueryString["infoid"] != null)
        {
            infoid = Convert.ToInt64(Request.QueryString["infoid"]);
        }
        if (Request.QueryString["type"] != null)
        {
            buytype = Request.QueryString["type"].ToString().Trim();
        }
        if (Request.QueryString["status"] != null)
        {
            status = Request.QueryString["status"].ToString().Trim();
        }
        if (!Page.IsPostBack)
        {
            bind();
        }
    }
    public void bind()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = new DataTable();
        DataTable dttype = new DataTable();
        if (buytype == "info")
        {
            if (status == "1")//已付款资源
            {
                dt = dal.GetList("ConsumeRecviw", "*", "ID", 1, 1, 0, 1, "infoid=" + infoid + " and LoginName='" + Page.User.Identity.Name + "'");
                if (dt.Rows.Count > 0)
                {

                    lblTitle.Text = "购买资源：<a target='_blank' href='" + DomainName.SiteDomain() + "/" + dt.Rows[0]["htmlfile"].ToString() + "'>" + dt.Rows[0]["SourceType"].ToString() + "</a>";
                    lblOrderDate.Text = dt.Rows[0]["ConsumeTime"].ToString();
                    lblAmount.Text = dt.Rows[0]["disPointCount"].ToString() == "" ? dt.Rows[0]["PointCount"].ToString() : dt.Rows[0]["disPointCount"].ToString();
                    lblStatus.Text = "已付款";
                    lblPayType.Text = Tz888.Common.Common.GetPayType(dt.Rows[0]["payType"].ToString());
                    lblOrderNo.Text = dt.Rows[0]["OrderNo"].ToString() == "" ? dt.Rows[0]["InfoID"].ToString() : dt.Rows[0]["OrderNo"].ToString();
                    lblORDER.Text = dt.Rows[0]["OrderNo"].ToString() == "" ? dt.Rows[0]["InfoID"].ToString() : dt.Rows[0]["OrderNo"].ToString();
                }
            }
            else
            {
                dt = dal.GetList("ShopCarViw", "*", "ShopCarID", 1, 1, 0, 1, "infoid=" + infoid + " and LoginName='" + Page.User.Identity.Name + "'");
                if (dt.Rows.Count > 0)
                {
                    lblTitle.Text = "购买资源：<a target='_blank' href='" + DomainName.SiteDomain() + "/" + dt.Rows[0]["htmlfile"].ToString() + "'>" + dt.Rows[0]["SourceType"].ToString() + "</a>";
                    lblOrderDate.Text = dt.Rows[0]["packdate"].ToString();
                    lblAmount.Text = dt.Rows[0]["disworthpoint"].ToString() == "" ? dt.Rows[0]["worthpoint"].ToString() : dt.Rows[0]["disworthpoint"].ToString();
                    lblOrderNo.Text = dt.Rows[0]["OrderNo"].ToString() == "" ? dt.Rows[0]["InfoID"].ToString() : dt.Rows[0]["OrderNo"].ToString();
                    lblORDER.Text = dt.Rows[0]["OrderNo"].ToString() == "" ? dt.Rows[0]["InfoID"].ToString() : dt.Rows[0]["OrderNo"].ToString();
                    lblStatus.Text = "未付款";
                    lblPayType.Text = "暂无";
                }
            }
        }
        else
        {
            dt = dal.GetList("smsConsumeRecViw", "Quantity,ConsumeType", "recid", 10, 1, 0, 1, "orderNo=" + orderNo);
            if (buytype == "sms")//短信交易详细
            {
                lblTitle.Text = "购买通知短信" + dt.Rows[0]["Quantity"].ToString() + "条";
            }
            if (buytype == "promotion")//短信交易详细
            {
                lblTitle.Text = "购买推广短信" + dt.Rows[0]["Quantity"].ToString() + "条";
            }
            else if (buytype == "card")//充值卡交易详细
            {
                lblTitle.Text = "购买充值卡";
                cardList.Text = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cardList.Text += "<Li>&nbsp;&nbsp;拓富通" + gettype(dt.Rows[i]["ConsumeType"].ToString()) + dt.Rows[i]["Quantity"].ToString() + "张</Li>";
                }
            }
            DataTable dtPoint = dal.GetList("OrderTab", "PayTypeCode,PayStatus,disCount,PayDate", "orderNo", 10, 1, 0, 1, "orderNo=" + orderNo);
            lblORDER.Text = orderNo.ToString();
            lblOrderNo.Text = orderNo.ToString();
            lblAmount.Text = dtPoint.Rows[0]["disCount"].ToString();
            lblOrderDate.Text = dtPoint.Rows[0]["PayDate"].ToString();
            lblStatus.Text = dtPoint.Rows[0]["PayStatus"].ToString().Trim() == "1" ? "已支付" : "未支付";
            lblPayType.Text = Tz888.Common.Common.GetPayType(dtPoint.Rows[0]["PayTypeCode"].ToString().Trim());
        }
    }

    public string gettype(string str)
    {

        if (str.ToString().Trim() == "card50")
        {
            return "充值卡面额50元";
        }
        if (str.ToString().Trim() == "card100")
        {
            return "充值卡面额100元";
        }
        if (str.ToString().Trim() == "card200")
        {
            return "充值卡面额200元";
        }
        if (str.ToString().Trim() == "card500")
        {
            return "充值卡面额500元";
        }
        if (str.ToString().Trim() == "tuofo")
        {
            return "开通会员";
        }
        else
        {
            return "";
        }
    }

}
