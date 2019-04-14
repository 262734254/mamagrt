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
/// QuickPayConf 的摘要说明
/// 配置文件
/// 用户可以修改一些配置信息，支付如支付地址，查询地址，商城密钥，版本号编码方式等信息
/// 一般包内容无需修改。
/// </summary>
public class QuickPayConf
{
	public QuickPayConf()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    //版本号
    public static string version = "1.0.0";
    //编码方式
    public static string charset = "GB2312";
    //支付网址
    //public static string gateWay = "https://www.epay.lxdns.com/UpopWeb/api/Pay.action";
    //后续交易网址
    //public static string backStagegateWay = "https://www.epay.lxdns.com/UpopWeb/api/BSPay.action";
    //查询网址
    //public static string queryUrl = "https://www.epay.lxdns.com/UpopWeb/api/Query.action";
    //支付网址
    public static string gateWay = "https://unionpaysecure.com/api/Pay.action";

    //后续交易网址
    public static string backStagegateWay = "https://unionpaysecure.com/api/BSPay.action";

    //查询网址
    public static string queryUrl = "https://unionpaysecure.com/api/Query.action";
    //商户代码
    public static string merCode = "898440348991757";
    //商户名称
    public static string merName = "TopFo";

    //加密方式
    public static string signType = "MD5";

    //商城密匙，需要和银联商户网站上配置的一样
    //public static string securityKey = "88888888";
    public static string securityKey = "IEGR39KF2JGBT3929HFMAF4JFSSE";

    //签名
    public static string signature = "signature";
    public static string signMethod = "signMethod";

    //组装消费请求包
    public static string[] reqVo = new string[]{
				"version",
				"charset",
				"transType",
				"origQid",
				"merId",
				"merAbbr",
				"acqCode",
				"merCode",
				"commodityUrl",
				"commodityName",
				"commodityUnitPrice",
				"commodityQuantity",
				"commodityDiscount",
				"transferFee",
				"orderNumber",
				"orderAmount",
				"orderCurrency",
				"orderTime",
				"customerIp",
				"customerName",
				"defaultPayType",
				"defaultBankNumber",
				"transTimeout",
				"frontEndUrl",
				"backEndUrl",
				"merReserved"
		};

    public static string[] notifyVo = new string[]{
				"charset",
				"cupReserved",
				"exchangeDate",
				"exchangeRate",
				"merAbbr",
				"merId",
				"orderAmount",
				"orderCurrency",
				"orderNumber",
				"qid",
				"respCode",
				"respMsg",
				"respTime",
				"settleAmount",
				"settleCurrency",
			   // "settleCurrencyIndex",
				"settleDate",
				"traceNumber",
				"traceTime",
				"transType",
				"version"
		};

    public static string[] queryVo = new string[]{
			"version",
			"charset",
			"transType",
			"merId",
			"orderNumber",
			"orderTime",
			"merReserved"
		};

}
