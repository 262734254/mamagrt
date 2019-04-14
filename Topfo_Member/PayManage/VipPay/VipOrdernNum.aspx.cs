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

public partial class PayManage_VipPay_VipOrdernNum : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string loginname = Page.User.Identity.Name; 
         string dict= Request.QueryString["dict"].ToString().Trim();  //获取有效期
         string price = Request.QueryString["price"].ToString().Trim(); //获取价格
         string Valdate = Request.QueryString["Vdate"].ToString().Trim(); //获取是就个月1代表3个月，2代表6个月，3代表一年
         if (dict != "" || price != "")
         {
             double userpoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(loginname));  //用户余额
             #region 生成订单号
                 //生成订单 返回订单号
                 Tz888.BLL.Pay1.PayOrder dal = new Tz888.BLL.Pay1.PayOrder();
                 try
                 {
                     int ErrorID = 0;
                     string ErrorMsg = "";

                     int orderno = dal.CreateVipInfoOrder(loginname,price,Valdate,  ref ErrorID, ref ErrorMsg);  //订单号

                     if (orderno != 0)
                     {

                         decimal orderpoint =(Convert.ToDecimal(price));   //订单金额

                         Response.Redirect("orderBuy_item.aspx?order_no=" + tzWeb.pay.comm.JiaMi(orderno.ToString()) + "&dict=" + dict.ToString() + "&Valdate=" + Valdate.ToString(), false);


                     }
                     else
                     {
                         Tz888.Common.Common.ShowMessage(this.Page, "出现异常请稍后再试!", "VipManage.aspx");
                     }
                 }
                 catch(Exception )
                 {

                     Tz888.Common.Common.ShowMessage(this.Page, "出现异常请稍后再试!", "VipManage.aspx");
                 }


             #endregion
         }
         else
         {
             Tz888.Common.Common.ShowMessage(this.Page, "出现异常请稍后再试!", "VipManage.aspx");

         }
     
      }
    }
}
