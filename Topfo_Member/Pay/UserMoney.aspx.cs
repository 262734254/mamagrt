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

public partial class Pay_UserMoney : System.Web.UI.Page
{
    Tz888.BLL.GetDataList bll = new Tz888.BLL.GetDataList();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string OrderNo = Request.QueryString["order_no"];
            string Point = Request.QueryString["Money"];
            if (OrderNo != "" || Point != "")
            {

                string strLoginName = Page.User.Identity.Name;//tzWeb.LoginInfo.GetLoginUserName(0);

                DataTable dtPoint = bll.GetList("OrderTab", "TotalCount,DisCount", "OrderNo", 1, 1, 0, 1, "OrderNO=" + OrderNo);
                if (dtPoint.Rows.Count > 0)
                {   
                    double payPoint = Convert.ToDouble(dtPoint.Rows[0]["TotalCount"]);//资源价格
                    double dispayPoint = Convert.ToDouble(dtPoint.Rows[0]["DisCount"]);//实际需要支付(需要扣除的金额)
                    if (strLoginName != "")//tzWeb.LoginInfo.GetUserIsLogin(0)
                    {
                        //用户余额
                        double UserPoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(strLoginName));
                        string TransAmt = String.Format("{0:N}", dispayPoint);

                        lab_OrderNo.Text = OrderNo;

                        lblorder_no.Text = TransAmt;//应付金额

                        lblUser_no.Text = String.Format("{0:N}", UserPoint);//用户余额
                    }

                }
               
                else
                {
                    Response.Write("<script>alert('出现错误!!');</script>");
                }
            }
        }
    }
}
