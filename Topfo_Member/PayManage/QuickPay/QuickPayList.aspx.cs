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
using System.Text;

public partial class PayManage_QuickPay_QuickPayList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Request.ContentEncoding = System.Text.Encoding.GetEncoding(QuickPayConf.charset);
            String[] resArr = new String[QuickPayConf.notifyVo.Length];
            for (int i = 0; i < QuickPayConf.notifyVo.Length; i++)
            {
                resArr[i] = Request.Params[QuickPayConf.notifyVo[i]];
            }
            String signature = Request.Params[QuickPayConf.signature];
            String signMethod = Request.Params[QuickPayConf.signMethod];

            Response.ContentType = "text/html;charset=" + QuickPayConf.charset;
            Response.ContentEncoding = System.Text.Encoding.GetEncoding(QuickPayConf.charset);

            try
            {

                bool signatureCheck = new QuickPayUtils().checkSign(resArr, signMethod, signature);
                StringBuilder sb = new StringBuilder();
                //sb.Append("签名是否正确：" + signatureCheck);
                bool success = resArr[10] == "00";
                if (success)
                {
                    string moneyz = resArr[13];

                    lab_OrderNo.Text = resArr[8]; //资源交易号
                    lab_Point.Text = Convert.ToString(Convert.ToInt32(moneyz) / 100); //实际支付金额
                    lab_aliNo.Text = resArr[9]; //外部交易号

                    //先充值 后消费
                    string loginname = this.Page.User.Identity.Name;





                    Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
                    bool b = dal.StrikeSuccess(lab_OrderNo.Text.ToString().Trim(), "alipay", resArr[9], loginname);




                }

                else
                {
                    sb.Append("<br>失败原因:" + resArr[11]);
                    Response.Write(sb.ToString());
                }
                Response.Write(sb.ToString());

            }
            catch (Exception) { }
        }
    }
}