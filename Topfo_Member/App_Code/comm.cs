using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using com.yeepay;
using System.ComponentModel;
using System.Globalization;

using tenpay;

namespace tzWeb.pay
{

    /// <summary>
    /// by huangleon
    /// </summary>
    public class comm
    {
        private static Tz888.Model.MemberManageInfo BalanceView = new Tz888.Model.MemberManageInfo();
        public static string payDomain = System.Configuration.ConfigurationSettings.AppSettings["payDomain"];
        public static string Domain = System.Configuration.ConfigurationSettings.AppSettings["Domain"];
        public static string LoginPage = System.Configuration.ConfigurationSettings.AppSettings["LoginPage"];

        #region 银行支付post表单
        public static string pnrForm(string OrdId, string TransMoney, string action)
        {
            NumberFormatInfo n = new CultureInfo("en-US", false).NumberFormat;
            string TransAmt = String.Format("{0:N}", Convert.ToDouble(TransMoney));
            string Version = "10";//版本号
            string url = "https://payment.chinapnr.com/pay/TransGet";
            string MerId = "880452";//商户ID
            string MerDate = DateTime.Now.ToString("yyyyMMdd").Trim();//商户时间
            string TransType = "P";//交易方式
            string GateId = "";//网关号
            string MerPriv = "";//商户私有域
            string BgRetUrl = payDomain + "/pnr/BackReturl.aspx";//后台应答URL
            string PageRetUrl = payDomain + "/pnr/PageReturl.aspx?action=" + action;//页面应答URL
            string MerKeyFile = System.Configuration.ConfigurationSettings.AppSettings["pnrMerPK"];//私钥文件名
            CHINAPNRLib.NetpayClientClass ThisOrder = new CHINAPNRLib.NetpayClientClass();
            string ChkValue = ThisOrder.SignOrder0(MerId, MerKeyFile, OrdId, TransAmt, MerDate, TransType, GateId, MerPriv, BgRetUrl, PageRetUrl);
            string htmlCode = @"
							<form id=""frmPay""   action=""" + url + @""" method=""post"">
							<input type=""hidden"" name=Version   value=""" + Version + @""">
							<input type=""hidden"" name=MerId     value=""" + MerId + @""">
							<input type=""hidden"" name=MerDate   value=""" + MerDate + @""">
							<input type=""hidden"" name=OrdId     value=""" + OrdId + @""">
							<input type=""hidden"" name=TransType value=""" + TransType + @""">
							<input type=""hidden"" name=TransAmt  value=""" + TransAmt + @""">
							<input type=""hidden"" name=GateId    value=""" + GateId + @""">
							<input type=""hidden"" name=MerPriv   value=""" + MerPriv + @""">
							<input type=""hidden"" name=BgRetUrl  value=""" + BgRetUrl + @""">
							<input type=""hidden"" name=PageRetUrl value=""" + PageRetUrl + @""">
							<input type=""hidden"" name=ChkValue value=""" + ChkValue + @""">
							<input type=""submit"" style=""display:none"" id=""submit""/>							
							</form>
							<script language=""javascript"">			
							document.all.submit.click();
							</script>";
            return htmlCode;
        }
        #endregion

        //订单金额
        public static string getOrderPoint(long OrderID)
        {
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dt = dal.GetList("ordertab", "discount", "OrderNO", 1, 1, 0, 1, "OrderNo=" + OrderID);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["discount"].ToString();
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 取帐户总余额
        /// </summary>	
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public static bool GetBalanceWorthPoint(string loginname)
        {
            bool blReturn = false;
            long lgCurrentPage = 1;
            long lgPageCount = 0;
           
            Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
            DataTable dv = dal.GetList("CreateCardTab", "WorthPoint,IntegralCount","CardID",1,1,0,1, "LoginName='" + loginname + "'");
            if (dv != null && dv.Rows.Count == 1)
            {
                BalanceView.WorthPoint = Convert.ToSingle(dv.Rows[0]["WorthPoint"]);
                BalanceView.IntegralSum = Convert.ToInt32(dv.Rows[0]["IntegralCount"]);
                blReturn = true;
            }
            return (blReturn);
        }
        #region 用户余额
        public static string getUserPoint(string LoginName)
        {

            BalanceView.LoginName = LoginName; //tzWeb.LoginInfo.GetLoginUserName(0);
            GetBalanceWorthPoint(LoginName);
            double intBalance = Convert.ToDouble(BalanceView.WorthPoint);
            string TransAmt = String.Format("{0:N}", Convert.ToDouble(intBalance.ToString()));
            if (TransAmt != "")
            {
                return TransAmt;
            }
            else
            {
                return "0";
            }
        }
        #endregion
        public static string JieMi(string Text)
        {
            string sKey = "pay888";
            DESCryptoServiceProvider provider1 = new DESCryptoServiceProvider();
            int num1 = Text.Length / 2;
            byte[] buffer1 = new byte[num1];
            for (int num2 = 0; num2 < num1; num2++)
            {
                int num3 = Convert.ToInt32(Text.Substring(num2 * 2, 2), 0x10);
                buffer1[num2] = (byte)num3;
            }
            provider1.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            provider1.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            MemoryStream stream1 = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream1, provider1.CreateDecryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer1, 0, buffer1.Length);
            stream2.FlushFinalBlock();
            return Encoding.Default.GetString(stream1.ToArray());
        }


        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Text">明文</param>
        /// <param name="sKey">密钥</param>
        /// <returns>密文</returns>
        public static string JiaMi(string Text)
        {
            string sKey = "pay888";
            DESCryptoServiceProvider provider1 = new DESCryptoServiceProvider();
            byte[] buffer1 = Encoding.Default.GetBytes(Text);
            provider1.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            provider1.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            MemoryStream stream1 = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream1, provider1.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(buffer1, 0, buffer1.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder1 = new StringBuilder();
            foreach (byte num1 in stream1.ToArray())
            {
                builder1.AppendFormat("{0:X2}", num1);
            }
            return builder1.ToString();
        }
        #region 是否设置了支付密码
        public static bool isSetPwd(string LoginName)
        {
            Tz888.BLL.GetDataList dal = new Tz888.BLL.GetDataList();
            DataTable dt = dal.GetList("PayPwdTab", "PayPassword", "QID", 1, 1, 0, 1, "LoginName='" + LoginName + "'");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["PayPassword"].ToString().Trim() != "" || dt.Rows[0]["PayPassword"] != null || dt.Rows[0]["PayPassword"].ToString().Trim() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}
