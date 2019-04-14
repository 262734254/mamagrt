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

public partial class PayManage_QuickPay_QuickPay : System.Web.UI.Page
{
    public string par;
    public string orderNo;
    Tz888.BLL.GetDataList bll = new Tz888.BLL.GetDataList();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["order_no"] != null)
        {
            //解密订单号
            par = Request.QueryString["order_no"].Replace(" ", "+");
            orderNo = tzWeb.pay.comm.JieMi(par);
        }

        if (!IsPostBack)
        {
            string strLoginName = Page.User.Identity.Name; //tzWeb.LoginInfo.GetLoginUserName(0);

            DataTable dtPoint = bll.GetList("OrderTab", "TotalCount,DisCount", "OrderNo", 1, 1, 0, 1, "OrderNO=" + orderNo);
            if (dtPoint.Rows.Count > 0)
            {
                double payPoint = Convert.ToDouble(dtPoint.Rows[0]["TotalCount"]);//资源价格
                double dispayPoint = Convert.ToDouble(dtPoint.Rows[0]["DisCount"]);//实际需要支付(需要扣除的金额)
                if (strLoginName != "")//tzWeb.LoginInfo.GetUserIsLogin(0)
                {
                    //用户余额
                    double UserPoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(strLoginName));
                    string TransAmt = String.Format("{0:N}", dispayPoint);
                    lblorderby_no.Text = TransAmt;//应付金额

                    lblorder_no.Text = TransAmt;//应付金额

                    lblUser_no.Text = String.Format("{0:N}", UserPoint);//用户余额

                }

            }
            else
            {
                Response.Write("<script>alert('订单已被取消!!');window.location.href='http://www.topfo.com';</script>");
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        string htmlFile = "";
        string url = "http://www.topfo.com/";
        string shopName = "";
        int WorthPoint = 0;
        Tz888.BLL.GetDataList bll = new Tz888.BLL.GetDataList();

        string strWhere = "OrderNo='" + orderNo + "'";

        DataTable dt = bll.GetList("ShopCarVIW", "HtmlFile,SourceType,WorthPoint", "ShopCarID", 1, 1, 0, 1, strWhere);

        if (dt.Rows.Count > 0)
        {
             url = dt.Rows[0]["HtmlFile"].ToString().Trim();

             WorthPoint = Convert.ToInt32(dt.Rows[0]["WorthPoint"].ToString().Trim());
            
        }

        int money = WorthPoint * 100;
     
        QuickPaySample quick = new QuickPaySample();
        if (money > 0 || orderNo != "")
        {
            quick.ProcessRequest(htmlFile, "中国招商投资网资源信息", orderNo, Convert.ToString(money), "cn001");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("orderBuy_item.aspx?order_no=" + par);
    }
}

