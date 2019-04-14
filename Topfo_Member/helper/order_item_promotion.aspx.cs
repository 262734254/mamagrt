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

public partial class helper_order_item_promotion : System.Web.UI.Page
{
    public string pay_type = "account";
    public int smscount = 0;
    public int price = 0;
    public int sId = 0;
    private void Page_Load(object sender, System.EventArgs e)
    {
        //if (tzWeb.LoginInfo.GetLoginUserName(0) == "")
        //{
        //    Response.Redirect(tzWeb.pay.comm.LoginPage + "?ReturnURL=" + Request.Url.ToString());
        //    return;
        //}
        if (Page.User.Identity.Name == null || Page.User.Identity.Name.Trim() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        if (Request.QueryString["pay_type"] != null)
        {
            pay_type = Request.QueryString["pay_type"].Trim();
        }
        if (Request.QueryString["smscount"] != null)
        {
            smscount = Convert.ToInt32(Request.QueryString["smscount"]);
        }
        if (Request.QueryString["price"] != null)
        {
            price = Convert.ToInt32(Request.QueryString["price"]);
        }
        if (Request.QueryString["Id"] != null)
        {
            sId = Convert.ToInt32(Request.QueryString["Id"]);
        }
        if (!IsPostBack)
        {
            //smscount = 2;
            //price = 2;
            //sId = 58;
            //string loginname = tzWeb.LoginInfo.GetLoginUserName(0);
            string loginname = Page.User.Identity.Name;
            //loginname = "hellocindy";
            double userpoint = Convert.ToDouble(tzWeb.pay.comm.getUserPoint(loginname));
            if (loginname != "")
            {
                //生成订单 返回订单号
                Tz888.BLL.Pay1.PayOrder dal = new Tz888.BLL.Pay1.PayOrder();
                try
                {
                    int ErrorID = 0;
                    string ErrorMsg = "";
                    int orderno = dal.CreatePromotionOrder1(loginname, smscount, sId, price, ref ErrorID, ref ErrorMsg);
                    if (orderno != 0)
                    {
                        string order = tzWeb.pay.comm.JiaMi(orderno.ToString());
                        string par = order.ToString().Replace(" ", "+");
                        string orderNo1 = tzWeb.pay.comm.JieMi(par);
                        double orderpoint = Convert.ToDouble(tzWeb.pay.comm.getOrderPoint(Convert.ToInt64(orderno)));
                        if (userpoint < orderpoint)
                        {
                            Response.Redirect("http://pay.topfo.com/otherpay.aspx?order_no=" + order, true);
                        }
                        else
                        {
                            Response.Redirect("http://pay.topfo.com/account/accountpay.aspx?order_no=" + order, true);
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('订单创建失败')</script>");
                    }
                }
                catch (Exception ae)
                {
                    Response.Write(ae.ToString());
                }
            }
            else
            {
                Response.Redirect("http://pay.topfo.com/paylogin.aspx");
            }
        }
    }

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。

        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// 设计器支持所需的方法 - 不要使用代码编辑器修改

    /// 此方法的内容。

    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }
    #endregion
}
