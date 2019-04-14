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

public partial class PayManage_strike_details : System.Web.UI.Page
{
    public string orderNo;
    public string action="1";
    public string loginname;
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
        if (Request.QueryString["order_no"] != null)
        {
            orderNo = Request.QueryString["order_no"].ToString();
        }
        if (Request.QueryString["action"] != null)
        {
            action = Request.QueryString["action"].ToString();
        }
        loginname = Page.User.Identity.Name;
        if (!Page.IsPostBack)
        {
            if (action == "1")
            {
                bindOld();
            }
            if(action=="0")
            {
                bindWait();
            }
        }
    }
    public void bindOld()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("StrikeRecVIW", "*", "ID", 1, 1, 0, 1, "ID='" + orderNo + "'  and ChangeBy='" + loginname + "'");
        if (dt.Rows.Count>0)
        {
            lblORDER.Text = orderNo;
            lblOrderNo.Text = orderNo;
            lblAmount.Text = dt.Rows[0]["PointCount"].ToString();
            lblOrderDate.Text = dt.Rows[0]["ChangeTime"].ToString();
            lblLoginName.Text = dt.Rows[0]["LoginName"].ToString();
            lblStatus.Text = "已付款";  
            if (dt.Rows[0]["paytypename"].ToString() != "")
            {
                lblPayType.Text = dt.Rows[0]["paytypename"].ToString() + "支付";
            }        
        }
    }
    public void bindWait()
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("StrikeOrderViw", "*", "OrderNo", 1, 1, 0, 1, "Status<>10 and OrderNo='" + orderNo + "'  and LoginName='" + Page.User.Identity.Name + "'");
        if (dt.Rows.Count > 0)
        {
            lblORDER.Text = orderNo;
            lblOrderNo.Text = orderNo;
            lblAmount.Text = dt.Rows[0]["TransMoney"].ToString();
            lblOrderDate.Text = dt.Rows[0]["PayTime"].ToString();
            lblLoginName.Text = dt.Rows[0]["StrikeLoginName"].ToString();
            if (dt.Rows[0]["Status"].ToString() == "1")
            {
                lblStatus.Text = "已付款";
            }
            if (dt.Rows[0]["Status"].ToString() == "0")
            {
                lblStatus.Text = "未付款";
            }
            if (dt.Rows[0]["Status"].ToString() == "2")
            {
                lblStatus.Text = "等待确认";
            }

            if (dt.Rows[0]["paytypename"].ToString() != "")
            {
                lblPayType.Text = dt.Rows[0]["paytypename"].ToString() + "支付";
            }
            else
            {
                lblPayType.Text = "暂无";
            }

        }
    }
}
