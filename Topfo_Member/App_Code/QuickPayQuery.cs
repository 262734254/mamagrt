using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// QuickPayQuery 的摘要说明
/// 商户查询例子
/// </summary>
public class QuickPayQuery
{
	public QuickPayQuery()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static void main(string[] aa)
    {
        new QuickPayQuery().queryTrans("01", "201104181312393", "20110523194505");
    }

    /// <summary>
    /// 查询交易入口
    /// </summary>
    /// <param name="transType"></param>
    /// <param name="orderNumber"></param>
    /// <param name="orderTime"></param>
    public void queryTrans(string transType, string orderNumber, string orderTime)
    {
        string res = query(transType, orderNumber, orderTime);
        if (res != null && res != "")
        {
            string[] arr = new QuickPayUtils().getResArr(res);
            if (checkSecurity(arr))//验证签名
            {
                merBusiness(arr);//商户业务逻辑
            }
        }
        else
        {
            System.Console.WriteLine("报文格式为空");
        }
    }

    /// <summary>
    /// 向银联发送查询请求
    /// </summary>
    /// <param name="transType"></param>
    /// <param name="orderNumber"></param>
    /// <param name="orderTime"></param>
    /// <returns></returns>
    public string query(string transType, string orderNumber, string orderTime)
    {
        string[] valueVo = new string[]{
				QuickPayConf.version,//协议版本
				QuickPayConf.charset,//字符编码
				transType,//交易类型
				QuickPayConf.merCode,//商户代码
				orderNumber,//订单号
				orderTime,//交易时间
				"{cardNumber=6212341111111111111&phoneNumber=13888888888}"//保留域
			};
        QuickPayUtils quickPayUtils = new QuickPayUtils();
        return quickPayUtils.doPostQueryCmd(QuickPayConf.queryUrl, new QuickPayUtils().createBackStr(valueVo, QuickPayConf.queryVo));
    }

    //验证签名 
    public bool checkSecurity(string[] arr)
    {
        //验证签名
        int checkedRes = new QuickPayUtils().checkSecurity(arr);
        if (checkedRes == 1)
        {
            return true;
        }
        else if (checkedRes == 0)
        {
            System.Console.WriteLine("验证签名失败");
            return false;
        }
        else if (checkedRes == 2)
        {
            System.Console.WriteLine("报文格式错误");
            return false;
        }
        return false;
    }

    //queryResult=0或者2时 respCode为00，其余情况下respCode为非全零的两位错误码
    //queryResult为空时报文格式错误
    //queryResult：
    //0：成功（响应码respCode为00）
    //1：失败（响应码respCode非00）
    //2：处理中（响应码respCode为00）
    //3：无此交易（响应码respCode非00）

    //商户的业务逻辑
    public void merBusiness(string[] arr)
    {
        string queryResult = "";
        //以下是商户业务处理
        for (int i = 0; i < arr.Length; i++)
        {
            string[] queryResultArr = arr[i].Split('=');
            // 处理商户业务逻辑
            if (queryResultArr.Length >= 2 && "queryResult" == queryResultArr[0])
            {
                queryResult = arr[i].Substring(queryResultArr[0].Length + 1);

                break;
            }
        }

        if (queryResult != "")
        {
            if (queryResult == "0")
            {
                System.Console.WriteLine("成功");
            }
            if (queryResult == "1")
            {
                System.Console.WriteLine("失败");
            }
            if (queryResult == "2")
            {
                System.Console.WriteLine("处理中");
            }
            if (queryResult == "3")
            {
                System.Console.WriteLine("无此交易");
            }
        }
        else
        {
            System.Console.WriteLine("报文格式错误");
        }
    }
}
