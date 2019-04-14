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
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.IO;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Net;


/// <summary>
/// Alipay_Return 的摘要说明。
/// </summary>
public partial class PayManage_Alipay_Return : System.Web.UI.Page
{
    #region GetMD5 / BubbleSort / Get_Http
    public static string GetMD5(string s)
    {
        /// <summary>
        /// 与ASP兼容的MD5加密算法
        /// </summary>
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    public static string[] BubbleSort(string[] r)
    {
        /// <summary>
        /// 冒泡排序法
        /// </summary>
        int i, j; //交换标志 
        string temp;
        bool exchange;
        for (i = 0; i < r.Length; i++) //最多做R.Length-1趟排序 
        {
            exchange = false; //本趟排序开始前，交换标志应为假

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;
                    exchange = true; //发生了交换，故将交换标志置为真 
                }
            }
            if (!exchange) //本趟排序未发生交换，提前终止算法 
            {
                break;
            }
        }
        return r;
    }

    //获取远程服务器ATN结果
    public String Get_Http(String a_strUrl, int timeout)
    {
        string strResult;
        try
        {
            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(a_strUrl);
            myReq.Timeout = timeout;
            HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
            Stream myStream = HttpWResp.GetResponseStream();
            StreamReader sr = new StreamReader(myStream, Encoding.Default);
            StringBuilder strBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                strBuilder.Append(sr.ReadLine());
            }

            strResult = strBuilder.ToString();
        }
        catch (Exception exp)
        {
            strResult = "错误：" + exp.Message;
        }

        return strResult;
    }
    #endregion

    public string order_no = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //lblPnr.Text = Request.QueryString["out_trade_no"].Trim();   //资源交易号
        //lblSys.Text = Request.QueryString["trade_no"].Trim();       //外部交易号
        //lblPayPoint.Text = Request.QueryString["total_fee"].Trim(); //实际支付金额
        //lblPoint.Text = bll.getTotalFee(Convert.ToInt64(lblPnr.Text));  //需要支付的点数

        lab_OrderNo.Text = Request.QueryString["out_trade_no"].Trim();   //资源交易号
        lab_Point.Text = Request.QueryString["total_fee"].Trim(); //实际支付金额
        lab_aliNo.Text = Request.QueryString["trade_no"].Trim();       //外部交易号
        order_no = Request.QueryString["out_trade_no"].Trim();

        /// <summary>
        /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com。
        /// </summary>
        string partner = "2088001390620672"; 		//***partner合作伙伴id（必须填写）
        string key = "kf69mv76m23a9vp34nkz6s16aux29h29"; //**partner 的对应交易安全校验码（必须填写）
        string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";
        alipayNotifyURL = alipayNotifyURL + "service=notify_verify" + "&partner=" + partner + "&notify_id=" + Request.QueryString["notify_id"];

        //获取支付宝ATN返回结果，true是正确的订单信息，false 是无效的
        string responseTxt = Get_Http(alipayNotifyURL, 120000);
        int i;
        NameValueCollection coll;
        coll = Request.QueryString;             //Load Form variables into NameValueCollection variable
        String[] requestarr = coll.AllKeys;     // Get names of all forms into a string array.

        //进行排序；
        string[] Sortedstr = BubbleSort(requestarr);
        //  for (i = 0; i < Sortedstr.Length; i++)
        // { 
        // Response.Write("Form: " + Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]] + "<br>");
        //  }

        //构造待md5摘要字符串 ；
        StringBuilder prestr = new StringBuilder();
        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (Request.Form[Sortedstr[i]] != "" && Sortedstr[i] != "sign" && Sortedstr[i] != "sign_type")
            {
                if (i == Sortedstr.Length - 1)
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]]);
                }
                else
                {
                    prestr.Append(Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]] + "&");
                }
            }
        }
        prestr.Append(key);
        //生成Md5摘要；
        string mysign = GetMD5(prestr.ToString());
        string sign = Request.QueryString["sign"];
        if (mysign == sign && responseTxt == "true")   //验证支付发过来的消息，签名是否正确
        {
            //先充值 后消费
            string loginname = this.Page.User.Identity.Name;

            //业务逻辑处理
            string orderNo = Request.QueryString["out_trade_no"].ToString().Trim();
            string transaction_id = Request.QueryString["trade_no"].Trim();
            string total_fee = Request.QueryString["total_fee"].Trim(); ;

            Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
            bool b = dal.StrikeSuccess(orderNo, "alipay", transaction_id, loginname);
        }
    }

}
