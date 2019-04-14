using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Security.Cryptography;


/// <summary>
/// BBS_Reg 的摘要说明
/// </summary>
public class AliPay
{
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
                //交换条件
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

    public string CreatUrl(
        string gateway,
        string service,
        string partner,
        string sign_type,
        string out_trade_no,
        string subject,
        string body,
        string payment_type,
        string total_fee,
        string show_url,
        string seller_email,
        string key,
        string return_url,
        string notify_url
        )
    {
        /// <summary>
        /// created by sunzhizhi 2006.5.21,sunzhizhi@msn.com。
        /// </summary>
        int i;

        //构造数组；
        string[] Oristr ={ 
								 "service="+service, 
								 "partner=" + partner, 
								 "subject=" + subject, 
								 "body=" + body, 
								 "out_trade_no=" + out_trade_no, 
								 "total_fee=" + total_fee, 
								 "show_url=" + show_url,  
								 "payment_type=" + payment_type, 
								 "seller_email=" + seller_email, 
								 "notify_url=" + notify_url,
								 "return_url=" + return_url 
							 };

        //进行排序；
        string[] Sortedstr = BubbleSort(Oristr);


        //构造待md5摘要字符串 ；

        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (i == Sortedstr.Length - 1)
            {
                prestr.Append(Sortedstr[i]);

            }
            else
            {

                prestr.Append(Sortedstr[i] + "&");
            }

        }

        prestr.Append(key);

        //生成Md5摘要；
        string sign = GetMD5(prestr.ToString());

        //构造支付Url；
        StringBuilder parameter = new StringBuilder();
        parameter.Append(gateway);
        for (i = 0; i < Sortedstr.Length; i++)
        {
            parameter.Append(Sortedstr[i] + "&");
        }

        parameter.Append("sign=" + sign + "&sign_type=" + sign_type);


        //返回支付Url；
        return parameter.ToString();

    }
}