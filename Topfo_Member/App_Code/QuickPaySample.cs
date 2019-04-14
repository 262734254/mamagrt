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
/// QuickPaySample 的摘要说明
/// 首先 封装查询请求对象valueVo，调用根据包doPostQueryCmd方法，自动签名，请求查询获取应答res。根据res调用工具类checkQuerySecurity进行签名验证，通过后完成商户自己的业务逻辑
/// </summary>
public class QuickPaySample
{
	public QuickPaySample()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    static int i = 0;

    public void ProcessRequest(string url,string shopName,string OrderNo,string money,string UserName)
    {
        //商户需要组装如下对象的数据
        string[] valueVo = new string[]{
				QuickPayConf.version,//协议版本
				QuickPayConf.charset,//字符编码
	            "01",//交易类型
			    "",// 原始交易流水号
			    QuickPayConf.merCode,// 商户代码
			    QuickPayConf.merName,// 商户简称
				"",// 收单机构代码
				"",// 商户类别	            
	            url,//商品URL
	            shopName,//商品名称
       
	            "8000",//商品单价 单位：分
	            "1",//商品数量
	            "0",//折扣 单位：分
           
	            "1000",//运费 单位：分
				OrderNo, //DateTime.Now.ToString("yyyyMMddHHmmss")+(++i),///订单号（需要商户自己生成）
	            money,//交易金额 单位：分
	            "156",//交易币种
				DateTime.Now.ToString("yyyyMMddHHmmss"),//交易时间

	            HttpContext.Current.Request.UserHostAddress,//用户IP
	            UserName,//用户真实姓名
	            "",//默认支付方式
	            "",//默认银行编号
	            "120000",//交易超时时间

                    //"http://localhost:52306/Topfo_Member/PayManage/QuickPay/QuickPayResSample.aspx",// 前台回调商户URL
                    //"http://localhost:52306/Topfo_Member/PayManage/QuickPay/QuickPayResSample.aspx",// 后台回调商户URL
            
                     "http://member.topfo.com/PayManage/QuickPay/QuickPayResSample.aspx",// 前台回调商户URL
                    "http://member.topfo.com/PayManage/QuickPay/QuickPayResSample1.aspx",// 后台回调商户URL
					"{cardNumber=6212341111111111111&phoneNumber=13888888888}"// 商户保留域
			};


        /*
        说明：以下代码直接返回跳转到银联在线支付页面字符串
            new QuickPayUtils().createPayHtml(valueVo)
        */
        string html = new QuickPayUtils().createPayHtml(valueVo);//跳转到银联页面支付

        /*
        说明：以下代码直接返回跳转到银行支付页面字符串 目前:支持工行(ICBC)，农行(ABC)，中行(BOC)，建行(CCB)，招行(CMB)，广发(GDB)，浦发(SPDB)
            new QuickPayUtils().createPayHtml(valueVo, "CCB")
        */
        ///String html = new QuickPayUtils().createPayHtml(valueVo, "CCB");//直接跳转到网银页面支付      HttpContext.Current.Response.Write
        ///HttpContext.Current.Response.ContentType
        HttpContext.Current.Response.ContentType = "text/html;charset=" + QuickPayConf.charset;
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding(QuickPayConf.charset);
        try
        {
            HttpContext.Current.Response.Write(html);
        }
        catch (Exception)
        {
        }
    }
    public void ProcessRequestList(string url, string shopName, string OrderNo, string money, string UserName)
    {
        //商户需要组装如下对象的数据
        string[] valueVo = new string[]{
				QuickPayConf.version,//协议版本
				QuickPayConf.charset,//字符编码
	            "01",//交易类型
			    "",// 原始交易流水号
			    QuickPayConf.merCode,// 商户代码
			    QuickPayConf.merName,// 商户简称
				"",// 收单机构代码
				"",// 商户类别	            
	            url,//商品URL
	            shopName,//商品名称
       
	            "8000",//商品单价 单位：分
	            "1",//商品数量
	            "0",//折扣 单位：分
           
	            "1000",//运费 单位：分
				OrderNo, //DateTime.Now.ToString("yyyyMMddHHmmss")+(++i),///订单号（需要商户自己生成）
	            money,//交易金额 单位：分
	            "156",//交易币种
				DateTime.Now.ToString("yyyyMMddHHmmss"),//交易时间

	            HttpContext.Current.Request.UserHostAddress,//用户IP
	            UserName,//用户真实姓名
	            "",//默认支付方式
	            "",//默认银行编号
	            "120000",//交易超时时间

                    //"http://localhost:52306/Topfo_Member/PayManage/QuickPay/QuickPayResSample.aspx",// 前台回调商户URL
                    //"http://localhost:52306/Topfo_Member/PayManage/QuickPay/QuickPayResSample.aspx",// 后台回调商户URL
            
                     "http://member.topfo.com/PayManage/QuickPay/QuickPayList.aspx",// 前台回调商户URL
                    "http://member.topfo.com/PayManage/QuickPay/QuickPayList1.aspx",// 后台回调商户URL
					"{cardNumber=6212341111111111111&phoneNumber=13888888888}"// 商户保留域
			};


        /*
        说明：以下代码直接返回跳转到银联在线支付页面字符串
            new QuickPayUtils().createPayHtml(valueVo)
        */
        string html = new QuickPayUtils().createPayHtml(valueVo);//跳转到银联页面支付

        /*
        说明：以下代码直接返回跳转到银行支付页面字符串 目前:支持工行(ICBC)，农行(ABC)，中行(BOC)，建行(CCB)，招行(CMB)，广发(GDB)，浦发(SPDB)
            new QuickPayUtils().createPayHtml(valueVo, "CCB")
        */
        ///String html = new QuickPayUtils().createPayHtml(valueVo, "CCB");//直接跳转到网银页面支付      HttpContext.Current.Response.Write
        ///HttpContext.Current.Response.ContentType
        HttpContext.Current.Response.ContentType = "text/html;charset=" + QuickPayConf.charset;
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding(QuickPayConf.charset);
        try
        {
            HttpContext.Current.Response.Write(html);
        }
        catch (Exception)
        {
        }
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}
