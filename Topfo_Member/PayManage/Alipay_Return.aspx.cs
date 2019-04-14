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
/// Alipay_Return ��ժҪ˵����
/// </summary>
public partial class PayManage_Alipay_Return : System.Web.UI.Page
{
    #region GetMD5 / BubbleSort / Get_Http
    public static string GetMD5(string s)
    {
        /// <summary>
        /// ��ASP���ݵ�MD5�����㷨
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
        /// ð������
        /// </summary>
        int i, j; //������־ 
        string temp;
        bool exchange;
        for (i = 0; i < r.Length; i++) //�����R.Length-1������ 
        {
            exchange = false; //��������ʼǰ��������־ӦΪ��

            for (j = r.Length - 2; j >= i; j--)
            {
                if (System.String.CompareOrdinal(r[j + 1], r[j]) < 0)
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;
                    exchange = true; //�����˽������ʽ�������־��Ϊ�� 
                }
            }
            if (!exchange) //��������δ������������ǰ��ֹ�㷨 
            {
                break;
            }
        }
        return r;
    }

    //��ȡԶ�̷�����ATN���
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
            strResult = "����" + exp.Message;
        }

        return strResult;
    }
    #endregion

    public string order_no = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        //lblPnr.Text = Request.QueryString["out_trade_no"].Trim();   //��Դ���׺�
        //lblSys.Text = Request.QueryString["trade_no"].Trim();       //�ⲿ���׺�
        //lblPayPoint.Text = Request.QueryString["total_fee"].Trim(); //ʵ��֧�����
        //lblPoint.Text = bll.getTotalFee(Convert.ToInt64(lblPnr.Text));  //��Ҫ֧���ĵ���

        lab_OrderNo.Text = Request.QueryString["out_trade_no"].Trim();   //��Դ���׺�
        lab_Point.Text = Request.QueryString["total_fee"].Trim(); //ʵ��֧�����
        lab_aliNo.Text = Request.QueryString["trade_no"].Trim();       //�ⲿ���׺�
        order_no = Request.QueryString["out_trade_no"].Trim();

        /// <summary>
        /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com��
        /// </summary>
        string partner = "2088001390620672"; 		//***partner�������id��������д��
        string key = "kf69mv76m23a9vp34nkz6s16aux29h29"; //**partner �Ķ�Ӧ���װ�ȫУ���루������д��
        string alipayNotifyURL = "http://notify.alipay.com/trade/notify_query.do?";
        alipayNotifyURL = alipayNotifyURL + "service=notify_verify" + "&partner=" + partner + "&notify_id=" + Request.QueryString["notify_id"];

        //��ȡ֧����ATN���ؽ����true����ȷ�Ķ�����Ϣ��false ����Ч��
        string responseTxt = Get_Http(alipayNotifyURL, 120000);
        int i;
        NameValueCollection coll;
        coll = Request.QueryString;             //Load Form variables into NameValueCollection variable
        String[] requestarr = coll.AllKeys;     // Get names of all forms into a string array.

        //��������
        string[] Sortedstr = BubbleSort(requestarr);
        //  for (i = 0; i < Sortedstr.Length; i++)
        // { 
        // Response.Write("Form: " + Sortedstr[i] + "=" + Request.QueryString[Sortedstr[i]] + "<br>");
        //  }

        //�����md5ժҪ�ַ��� ��
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
        //����Md5ժҪ��
        string mysign = GetMD5(prestr.ToString());
        string sign = Request.QueryString["sign"];
        if (mysign == sign && responseTxt == "true")   //��֤֧������������Ϣ��ǩ���Ƿ���ȷ
        {
            //�ȳ�ֵ ������
            string loginname = this.Page.User.Identity.Name;

            //ҵ���߼�����
            string orderNo = Request.QueryString["out_trade_no"].ToString().Trim();
            string transaction_id = Request.QueryString["trade_no"].Trim();
            string total_fee = Request.QueryString["total_fee"].Trim(); ;

            Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
            bool b = dal.StrikeSuccess(orderNo, "alipay", transaction_id, loginname);
        }
    }

}
