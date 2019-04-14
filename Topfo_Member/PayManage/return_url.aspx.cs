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
using tenpay;

public partial class PayManage_return_url : System.Web.UI.Page
{
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
        string loginname = Page.User.Identity.Name;

        string key = OnlineStrike.getTenKey();                //密钥
        PayResponseHandler resHandler = new PayResponseHandler(Context);//创建PayResponseHandler实例
        resHandler.setKey(key);

        if (resHandler.isTenpaySign())      //判断签名
        {
            string transaction_id = resHandler.getParameter("transaction_id");  //交易单号
            string total_fee = resHandler.getParameter("total_fee");            //金额金额,以分为单位
            total_fee = Convert.ToString(Convert.ToInt32(total_fee) / 100);
            string pay_result = resHandler.getParameter("pay_result");          //支付结果
            string orderNo = transaction_id.Substring(17, 10).Trim();

            lab_OrderNo.Text = orderNo;
            lab_Point.Text = total_fee.Trim();
            lab_TenNo.Text = transaction_id.Trim();

            if ("0".Equals(pay_result))
            {
                //开始处理业务
                Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
                bool b = dal.StrikeSuccess(orderNo, "tenpay", transaction_id, loginname);

                //调用doShow, 打印meta值跟js代码,告诉财付通处理成功,并在用户浏览器显示$show页面.
                resHandler.doShow("http://member.topfo.com/PayManage/show.aspx");
            }
            else
            {
                Response.Write("支付失败");         //当做不成功处理
            }
        }
        else
        {
            Response.Write("认证签名失败");
            //string debugInfo = resHandler.getDebugInfo();
            //Response.Write("<br/>debugInfo:" + debugInfo);
        }
    }
}
