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

public partial class PayManage_order_item : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    string infoID = "";
    Tz888.BLL.Pay1.PayOrder bbl = new Tz888.BLL.Pay1.PayOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            infoID = Request.QueryString["InfoID"];
            string loginname = Page.User.Identity.Name; //tzWeb.LoginInfo.GetLoginUserName(0);
            int num = bbl.CheckDate(Convert.ToInt64(infoID), "1");
            Tz888.BLL.GetDataList bll = new Tz888.BLL.GetDataList();
            dt = bll.GetList("MainInfoTab", "HtmlFile", "InfoID", 1, 1, 0, 1, "InfoId=" + infoID);
            if (num == 1)
            {

                string Money = bbl.OrderByMoney(Convert.ToInt64(infoID), loginname);
                if (Money =="")
                {



                    double userpoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(loginname));  //用户余额
                    #region 生成订单号
                    if (infoID != "" && infoID != null)
                    {

                        //生成订单 返回订单号
                        Tz888.BLL.Pay1.PayOrder dal = new Tz888.BLL.Pay1.PayOrder();
                        try
                        {
                            int ErrorID = 0;
                            string ErrorMsg = "";

                            int orderno = dal.CreateInfoOrder(Convert.ToInt64(infoID), loginname, ref ErrorID, ref ErrorMsg);  //订单号

                            if (orderno != 0)
                            {

                                AdSystem.Logic loc = new AdSystem.Logic();
                                loc.AdOrder_Add(Convert.ToInt64(orderno));



                                double orderpoint = Convert.ToDouble(tzWeb.pay.comm.getOrderPoint(Convert.ToInt64(orderno)));   //订单金额

                                Response.Redirect("orderBuy_item.aspx?order_no=" + tzWeb.pay.comm.JiaMi(orderno.ToString()) + "&user_on?=" + userpoint.ToString(), false);


                            }
                            else
                            {
                                Tz888.Common.Common.ShowMessage(this.Page, "此信息已不需要付费!", "trade_info_wait.aspx");
                            }
                        }
                        catch
                        {

                            Tz888.Common.Common.ShowMessage(this.Page, "此信息已不需要付费!", "trade_info_wait.aspx");
                        }


                    }
                    #endregion
                }
                else
                {
                    Tz888.Common.Common.ShowMessage(this.Page, "此信息已经购买!", "trade_info_wait.aspx");
                }


            }
            else
            {
                Tz888.Common.Common.ShowMessage(this.Page, "此信息已经过期!", "trade_info_wait.aspx");
            }


        }
    }
}
