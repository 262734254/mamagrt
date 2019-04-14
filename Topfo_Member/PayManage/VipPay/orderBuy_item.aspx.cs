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

public partial class PayManage_VipPay_orderBuy_item : System.Web.UI.Page
{
    public string par;
    public string orderNo;
    Tz888.BLL.GetDataList bll = new Tz888.BLL.GetDataList();
    string TransAmt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string Vallidate = Request.QueryString["dict"].ToString().Trim();
        if (Request.QueryString["order_no"] != null)
        {
            //解密订单号
            par = Request.QueryString["order_no"].Replace(" ", "+");
            orderNo = tzWeb.pay.comm.JieMi(par);
        }

        if (!IsPostBack)
        {
            string strLoginName = Page.User.Identity.Name; 

            DataTable dtPoint = bll.GetList("OrderTab", "TotalCount,DisCount", "OrderNo", 1, 1, 0, 1, "OrderNO=" + orderNo);
            if (dtPoint.Rows.Count > 0)
            {
                double payPoint = Convert.ToDouble(dtPoint.Rows[0]["TotalCount"]);//资源价格
                double dispayPoint = Convert.ToDouble(dtPoint.Rows[0]["DisCount"]);//实际需要支付(需要扣除的金额)
                if (strLoginName != "")//tzWeb.LoginInfo.GetUserIsLogin(0)
                {
                    //用户余额
                    double UserPoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(strLoginName));
                    TransAmt = String.Format("{0:N}", dispayPoint);


                    lblorder_no.Text = TransAmt;//应付金额
                    lblUser_no.Text = String.Format("{0:N}", UserPoint);//用户余额

                }

            }
            else
            {
                Response.Write("<script>alert('出息异常!!');window.location.href='http://member.topfo.com/index.aspx';</script>");
            }
        }
    }
    /// <summary>
    /// 支付宝支付
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string Validate = Request.QueryString["dict"].ToString().Trim();
        string Vadate = Request.QueryString["Valdate"].ToString().Trim();
        if (Request.QueryString["order_no"] != null)
        {
            //解密订单号
            par = Request.QueryString["order_no"].Replace(" ", "+");
            orderNo = tzWeb.pay.comm.JieMi(par);
            Response.Redirect("accountpay.aspx?order_no=" + tzWeb.pay.comm.JiaMi(orderNo.ToString()) + "&Validate=" + Validate.ToString() + "&vadate=" + Vadate.ToString());

        }

    }
    /// <summary>
    /// 余额支付
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string Validate = Request.QueryString["dict"].ToString().Trim();
        string Vadate = Request.QueryString["Valdate"].ToString().Trim();
        double payPoint = 0.0;
        string strLoginName = Page.User.Identity.Name; 
        DataTable dtPoint = bll.GetList("OrderTab", "TotalCount,DisCount", "OrderNo", 1, 1, 0, 1, "OrderNO=" + orderNo);
        if (dtPoint.Rows.Count > 0)
        {
            payPoint = Convert.ToDouble(dtPoint.Rows[0]["TotalCount"]);//资源价格
        }

        double UserPoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(strLoginName));
        if (UserPoint < payPoint)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "", "alert('用户余额已不足！')", true);

        }
        else
        {
            if (Request.QueryString["order_no"] != null)
            {
                //解密订单号
                par = Request.QueryString["order_no"].Replace(" ", "+");
                orderNo = tzWeb.pay.comm.JieMi(par);
                Response.Redirect("account.aspx?order_no=" + tzWeb.pay.comm.JiaMi(orderNo.ToString()) + "&Validate=" + Validate.ToString() + "&vadate=" + Vadate.ToString());

            }
        }

    }
}
