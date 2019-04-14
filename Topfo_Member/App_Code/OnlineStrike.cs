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
using System.IO;
using System.Security;
using System.Security.Cryptography; 
using com.yeepay;
using System.ComponentModel;
using System.Globalization;
using tenpay;
/// <summary>
/// OnlinePay 的摘要说明

/// </summary>
public class OnlineStrike
{
    public OnlineStrike()
    {
    }
  
    #region 银行支付post表单
    /// <summary>
    /// 
    /// </summary>
    /// <param name="OrdId"></param>
    /// <param name="TransMoney"></param>
    /// <returns></returns>
    public static string pnrForm(string OrdId, string TransMoney)
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

        string BgRetUrl = DomainName.VipDomain()+"/PayManage/return_back_pnr.aspx";//后台应答URL
        string PageRetUrl = DomainName.VipDomain() + "/PayManage/return_pnr.aspx";//页面应答URL
        string MerKeyFile = System.Configuration.ConfigurationSettings.AppSettings["pnrMerPK"];//私钥文件名

        CHINAPNRLib.NetpayClientClass ThisOrder = new CHINAPNRLib.NetpayClientClass();
        string ChkValue = ThisOrder.SignOrder0(MerId, MerKeyFile, OrdId, TransAmt, MerDate, TransType, GateId, MerPriv, BgRetUrl, PageRetUrl);
        string htmlCode = @"
							<form id=""frmPay""  action=""" + url + @""" method=""post"">
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

    #region 财付通post表单
    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNo"></param>
    /// <param name="total_fee"></param>
    /// <param name="tenUserName"></param>
    /// <returns></returns>
    public static string tenForm(string orderNo, string total_fee, string tenUserName)
    {
        #region 参数说明
        //cmdno 必填业务代码, 财付通支付支付接口填1
        //date 必填商户日期：如20051212
        //bank_type 必填银行类型:财付通支付填0
        //desc 必填交易的商品名称,32个字符16汉字内,不包含特殊符号
        //purchaser_id 必填用户(买方)的财付通帐户(QQ 或EMAIL)
        //bargainor_id 必填商家的商户号,有腾讯公司唯一分配
        //transaction_id 必填交易号(订单号)，由商户网站产生(建议顺序累加)，一对请求和应答的交易号必须相同）。transaction_id 为28 位长的数值，其中前10 位为商户网站编号(SPID)，由财付通统一分配；之后8 位为订单产生的日期，如20050415；最后10位商户需要保证一天内不同的事务（用户订购一次商品或购买一次服务），其ID 不相同。此财付通订单号必须保持唯一，不能重复,财付通根据此定单号通知商户发货和数据更新等。
        //sp_billno 必填商户系统内部的定单号，此参数仅在对账时提供,28个字符内。
        //total_fee 必填总金额，以分为单位,不允许包含任何字符
        //fee_type 必填现金支付币种，目前只支持人民币，码编请参见附件中的
        //return_url 必填接收财付通返回结果的URL(推荐使用ip)
        //attach 必填商家数据包，原样返回
        //spbill_create_ip 必填 用户IP（非商户服务器IP），为了防止欺诈，支付时财付通会校验此IP
        //sign 必填MD5签名结果
        #endregion

        PayRequestHandler req = new PayRequestHandler(HttpContext.Current);

        string cmdno = "1";                             //必填业务代码, 财付通支付支付接口填1
        string date = DateTime.Now.ToString("yyyyMMdd");//当前时间 yyyyMMdd
        string bank_type = "0";                         //必填银行类型:财付通支付填0
        string desc = "财付通充值" + orderNo.ToString().Trim(); //必填交易的商品名称,32个字符16汉字内,不包含特殊符号
        string purchaser_id = tenUserName;              //必填用户(买方)的财付通帐户(QQ 或EMAIL)
        string bargainor_id = "1204800501";             //必填商家的商户号,有腾讯公司唯一分配
        string transaction_id = bargainor_id + date + orderNo;//必填交易号(订单号)，由商户网站产生(建议顺序累加)，一对请求和应答的交易号必须相同）。transaction_id 为28 位长的数值，
        string sp_billno = orderNo;                     //必填商户系统内部的定单号，此参数仅在对账时提供,28个字符内。
        total_fee = Convert.ToString(Convert.ToInt32(total_fee) * 100);//必填总金额，以分为单位,不允许包含任何字符
        string fee_type = "1";                          //必填现金支付币种，目前只支持人民币(1)，码编请参见附件中的
        string return_url = DomainName.VipDomain() + "/PayManage/return_url.aspx";//必填接收财付通返回结果的URL(推荐使用ip)
        string attach = "";                             //必填商家数据包，原样返回
        string spbill_create_ip = HttpContext.Current.Request.UserHostAddress;//必填 用户IP（非商户服务器IP），为了防止欺诈，支付时财付通会校验此IP
        string sign = "";                               //必填MD5签名结果

        string key = "7bef661dd31b649fa6ca6643beb0af21";//密钥

        req.setKey(key);
        req.init();

        req.setParameter("cmdno", cmdno);
        req.setParameter("date", date);
        req.setParameter("bank_type", bank_type);
        req.setParameter("desc", desc);
        req.setParameter("purchaser_id", purchaser_id);
        req.setParameter("bargainor_id", bargainor_id);
        req.setParameter("transaction_id", transaction_id);
        req.setParameter("sp_billno", sp_billno);
        req.setParameter("total_fee", total_fee);
        req.setParameter("fee_type", fee_type);
        req.setParameter("return_url", return_url);
        req.setParameter("attach", attach);
        req.setParameter("spbill_create_ip", spbill_create_ip);
        req.setParameter("sign", sign);

        ////获取debug信息
        //string debuginfo = req.getDebugInfo();
        //HttpContext.Current.Response.Write("<br/>" + debuginfo + "<br/>");

        string requestUrl = req.getRequestURL();
        //HttpContext.Current.Response.Redirect(requestUrl);
        return requestUrl;
    }

    public static string getTenKey()
    {
        string key = "7bef661dd31b649fa6ca6643beb0af21";
        return key;
    }
    #endregion

    #region 支付宝post表单
    /// <summary>
    /// 
    /// </summary>
    /// <param name="orderNo"></param>
    /// <param name="money"></param>
    /// <returns></returns>
    public static string alipayForm(string orderNo, string money)
    {
        string show_url = "http://www.topfo.com/";
        string out_trade_no = orderNo;

        //业务参数赋值；
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";//'支付接口
        string service = "create_direct_pay_by_user";
        //string partner = "2088001390620672";		                    //partner合作伙伴ID	保留字段

        string partner = "2088501923223124";		                    //partner合作伙伴ID	保留字段
        string sign_type = "MD5";
        string subject = "中国招商投资网支付宝充值服务";	            //subject商品名称
        string body = "订单号：" + orderNo + "," + HttpContext.Current.User.Identity.Name + "使用支付宝充值" + money + "元";//body商品描述    
        string payment_type = "1";                                      //支付类型
        string total_fee = money;				                        //总金额0.01～50000.00
        //string show_url ="www.tz888.cn";                              //使用标准格式

         string seller_email = "cn1111111111@163.com";                  //卖家账号
        string key = "dxuq3bnfunsdr353bigih0w5jmly0i31";                //partner账户的支付宝安全校验码

        //string seller_email = "cn888@tz888.cn";                  //卖家账号
        //string key = "kf69mv76m23a9vp34nkz6s16aux29h29";                //partner账户的支付宝安全校验码
        string return_url = DomainName.VipDomain() + "/PayManage/Alipay_Return.aspx";//服务器通知返回接口 前台显示
        string notify_url = DomainName.VipDomain() + "/PayManage/Alipay_Notify.aspx";//服务器通知返回接口 通知支付宝

        AliPay ap = new AliPay();
        string aliay_url = ap.CreatUrl(
            gateway,
            service,
            partner,
            sign_type,
            out_trade_no,
            subject,
            body,
            payment_type,
            total_fee,
            show_url,
            seller_email,
            key,
            return_url,
            notify_url
            );
        return aliay_url;
    }
    #endregion
    public static string alipayFormList(string orderNo, string money)
    {
        string show_url = "http://www.topfo.com/";
        string out_trade_no = orderNo;

        //业务参数赋值；
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";//'支付接口
        string service = "create_direct_pay_by_user";
        string partner = "2088501923223124";		                    //partner合作伙伴ID	保留字段
        string sign_type = "MD5";
        string subject = "中国招商投资网支付宝充值服务";	            //subject商品名称
        string body = "订单号：" + orderNo + "," + HttpContext.Current.User.Identity.Name + "使用支付宝充值" + money + "元";//body商品描述    
        string payment_type = "1";                                      //支付类型
        string total_fee = money;				                        //总金额0.01～50000.00
        //string show_url ="www.tz888.cn";                              //使用标准格式


        string seller_email = "cn1111111111@163.com";                  //卖家账号
        string key = "dxuq3bnfunsdr353bigih0w5jmly0i31";                //partner账户的支付宝安全校验码
        //string seller_email = "cn888@tz888.cn";                  //卖家账号
        //string key = "kf69mv76m23a9vp34nkz6s16aux29h29";                //partner账户的支付宝安全校验码
        string return_url = DomainName.VipDomain() + "/Pay/Alipay_Return.aspx";//服务器通知返回接口 前台显示
        string notify_url = DomainName.VipDomain() + "/Pay/Alipay_Notify.aspx";//服务器通知返回接口 通知支付宝

        AliPay ap = new AliPay();
        string aliay_url = ap.CreatUrl(
            gateway,
            service,
            partner,
            sign_type,
            out_trade_no,
            subject,
            body,
            payment_type,
            total_fee,
            show_url,
            seller_email,
            key,
            return_url,
            notify_url
            );
        return aliay_url;
    }
    public static string alipayFormVIPList(string orderNo, string money)
    {
        string show_url = "http://www.topfo.com/";
        string out_trade_no = orderNo;

        //业务参数赋值；
        string gateway = "https://www.alipay.com/cooperate/gateway.do?";//'支付接口
        string service = "create_direct_pay_by_user";
        string partner = "2088501923223124";		                    //partner合作伙伴ID	保留字段
        string sign_type = "MD5";
        string subject = "中国招商投资网支付宝充值服务";	            //subject商品名称
        string body = "订单号：" + orderNo + "," + HttpContext.Current.User.Identity.Name + "使用支付宝充值" + money + "元";//body商品描述    
        string payment_type = "1";                                      //支付类型
        string total_fee = money;				                        //总金额0.01～50000.00
        //string show_url ="www.tz888.cn";                              //使用标准格式



        string seller_email = "cn1111111111@163.com";                  //卖家账号
        string key = "dxuq3bnfunsdr353bigih0w5jmly0i31";                //partner账户的支付宝安全校验码
        //string seller_email = "cn888@tz888.cn";                  //卖家账号
        //string key = "kf69mv76m23a9vp34nkz6s16aux29h29";                //partner账户的支付宝安全校验码
        string return_url = DomainName.VipDomain() + "/PayManage/VipPay/Alipay_Return.aspx";//服务器通知返回接口 前台显示
        string notify_url = DomainName.VipDomain() + "/PayManage/VipPay/Alipay_Notify.aspx";//服务器通知返回接口 通知支付宝

        AliPay ap = new AliPay();
        string aliay_url = ap.CreatUrl(
            gateway,
            service,
            partner,
            sign_type,
            out_trade_no,
            subject,
            body,
            payment_type,
            total_fee,
            show_url,
            seller_email,
            key,
            return_url,
            notify_url
            );
        return aliay_url;
    }

    #region 神州行提交表单
    public static string szxForm(string orderNo, string TransMoney, string loginname)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        string LoginID = "";
        DataTable dt = dal.GetList("LoginInfoTab", "LoginID", "LoginID", 1, 1, 0, 1, "LoginName='" + loginname + "'");
        if (dt.Rows.Count > 0)
        {
            LoginID = dt.Rows[0]["LoginID"].ToString();
        }
        string url = "http://www.shenzhouxing.com.cn/receive/receive.jsp";
        string bussinessid = "945104";//商户ID
        string bussinessname = "中国招商投资网";
        string userid = LoginID;
        string payid = orderNo;
        string returnurl =DomainName.VipDomain()+"/PayManage/return_szx.aspx";//页面应答URL
        string sname = loginname;
        string semail = "";//email
        string stel = "";//电话
        string spost = "";//邮编
        string saddr = "";//地址 
        string snote = "";//留言
        string digestString = GetKey(userid, orderNo, TransMoney);
        string htmlCode = @"
							<form id=""frmPay""  action=""" + url + @""" method=""post"">
							<input type=""hidden"" name=bussinessid   value=""" + bussinessid + @""">
							<input type=""hidden"" name=bussinessname     value=""" + bussinessname + @""">
							<input type=""hidden"" name=userid   value=""" + userid + @""">
							<input type=""hidden"" name=payid     value=""" + payid + @""">
							<input type=""hidden"" name=money    value=""" + TransMoney + @""">
							<input type=""hidden"" name=returnurl  value=""" + returnurl + @""">
							<input type=""hidden"" name=sname    value=""" + sname + @""">
							<input type=""hidden"" name=semail   value=""" + semail + @""">
							<input type=""hidden"" name=stel  value=""" + stel + @""">
							<input type=""hidden"" name=spost value=""" + spost + @""">
							<input type=""hidden"" name=saddr value=""" + saddr + @""">	
							<input type=""hidden"" name=snote value=""" + snote + @""">	
							<input type=""hidden"" name=digestString value=""" + digestString + @""">
                            <input type=""submit"" style=""display:none"" id=""submit""/>							
							</form>
							<script language=""javascript"">
							document.all.submit.click();
							</script>";
        return htmlCode;
    }
    //神州行MD5验证码

    public static string GetKey(string userid, string orderNo, string money)
    {
        string key = "945104" + orderNo + userid + money + "tz888";//字符格式
        string md = FormsAuthentication.HashPasswordForStoringInConfigFile(key.ToLower(), "MD5");
        string md5str = md.ToLower();//转换为小写

        return md5str;
    }
    #endregion

    #region ebilling支付表单
    public static string ebillingForm(string OrderID, string ChargeArm, string LoginName)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("EbilingICPcodeTab", "Amount,CPCODE", "ID", 1, 1, 0, 1, "Amount=" + Convert.ToDouble(ChargeArm));
        string PCode = "";
        if (dt.Rows.Count > 0)
        {
            PCode = dt.Rows[0]["CPCODE"].ToString().Trim();
        }
        else { return ""; }
        string targetURL = DomainName.PayDomain() + "/ebiling/response.aspx?order_no=" +OrderID;//付费完成地址 使用者

        string Charge = (Convert.ToDouble(ChargeArm) * 100).ToString();//付费金额 ----除以100即为真实额度
        string UId = LoginName;//会员ID 使用ICP服务的使用者ID 注册会员 20个字以内
        string DateTime_ = DateTime.Now.ToString();//传送时间

        string UIResize = "0";//窗口大小模式 0不能放大窗口 1可以放大
        string FormMethod = "POST";//提交方式
        string Target = "_self";//窗口位置
        string Corporation = "1";//固定变量
        string billingURL = DomainName.VipDomain() + "/PayManage/return_ebilling.aspx"; //付费结束URL 服务器

        string billingKind = "1";//固定变量
        string Quote = "0";//固定变量
        string CpDemand = OrderID;//订单号


        string txt = "";
        txt = txt + "targetURL=" + targetURL + ",";
        txt = txt + "PCode=" + PCode + ",";
        txt = txt + "Charge=" + Charge + ",";
        txt = txt + "UId=" + UId + ",";
        txt = txt + "DateTime=" + DateTime_ + ",";
        txt = txt + "UIResize=" + UIResize + ",";
        txt = txt + "FormMethod=" + FormMethod + ",";
        txt = txt + "Target=" + Target + ",";
        txt = txt + "Corporation=" + Corporation + ",";
        txt = txt + "billingURL=" + billingURL + ",";
        txt = txt + "billingKind=" + billingKind + ",";
        txt = txt + "Quote=" + Quote + ",";
        txt = txt + "CpDemand=" + CpDemand;
        string url="http://billing.ebilling.net.cn/ebilling.asp";//正式地址
        string EncTxt = new SOFTFAMILYLib.PayClass().Encode(txt); // 对输出数据加密

        string htmlCode = @"
							<form name=frmPay  action=""" + url + @"""' method=post>
							<input type=""hidden"" name=""request""   value=""" + EncTxt + @""">
						    <input type=""submit"" style=""display:none"" id=""submit""/>
							</form>
							<script language=""javascript"">
							document.all.submit.click();
							</script>";
        return htmlCode;
    }
    #endregion

    #region 订单是否充值成功

    public static bool isSuccess(string OrderNO)
    {
        Tz888.BLL.Conn DAL = new Tz888.BLL.Conn();
        DataTable dt = DAL.GetList("StrikeOrderVIW","Status","OID",1,1,0,1,"OrderNO='"+OrderNO+"'");
       
            if (dt.Rows[0]["Status"].ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
      
    }
    #endregion 
    
    #region 用户余额
    public static double getUserPoint(string LoginName)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("CreateCardTab", "WorthPoint", "id", 1, 1, 0, 1, "LoginName='" + LoginName+"'");
        if (dt.Rows.Count > 0)
        {
            return Convert.ToDouble(dt.Rows[0]["WorthPoint"]);
        }
        else
        {
            return 0;
        }
    }
    //订单金额
    public static double getOrderPoint(long OrderID)
    {
        Tz888.BLL.Conn dal = new Tz888.BLL.Conn();
        DataTable dt = dal.GetList("ordertab", "discount", "OrderNO", 1, 1, 0, 1, "OrderNo=" + OrderID);
        if (dt.Rows.Count > 0)
        {
            return Convert.ToDouble(dt.Rows[0]["discount"]);
        }
        else
        {
            return 0;
        }

    }
    #endregion

    /// <summary>
    /// 用户帐户信息
    /// </summary>
    /// <param name="LoginName">用户名</param>
    /// <param name="param">查询的项</param>
    /// <returns></returns>
    public static string account(string LoginName, string param)
    {
        Tz888.BLL.AccountInfo dal = new Tz888.BLL.AccountInfo();
        DataTable dt = dal.GetAccountInfo(LoginName);
        DataRow[] drs = null;
        string paramvalue = "0";
        if (dt != null)
        {
            drs = dt.Select("param='" + param + "'");
            if (drs.GetLength(0) > 0)
            {
                paramvalue = drs[0]["value"].ToString() == "" ? "0" : drs[0]["value"].ToString();
            }
        }
        return paramvalue;
    }

    #region 加密
    public static string JiaMi(string strText)
    {
        Byte[] Iv64 ={ 11, 22, 33, 44, 52, 66, 77, 85 };
        Byte[] byKey64 ={ 10, 20, 30, 37, 50, 60, 70, 80 };
        try
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            Byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);

            MemoryStream ms = new MemoryStream();
            //System.IO.MemoryStream 创建以内存作为其支持存储区的流

            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey64, Iv64), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            //要写入当前流的字节数。

            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    #endregion


    #region 解密
    public static string JieMi(string strText)
    {
        Byte[] byKey64 ={ 10, 20, 30, 37, 50, 60, 70, 80 };
        Byte[] Iv64 ={ 11, 22, 33, 44, 52, 66, 77, 85 };
        Byte[] inputByteArray = new byte[strText.Length];
        try
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey64, Iv64), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }
    #endregion

}
