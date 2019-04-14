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

public partial class PayManage_return_back_pnr : System.Web.UI.Page
{
    public string MerId;//商户ID
    public string MerDate;//商户日期
    public string OrdId;//商户订单号
    public string TransType;//交易类型
    public string TransAmt;//交易金额
    public string GateId;//网关号
    public string MerPriv;//商户私有域
    public string TransStat;//交易状态
    public string SysDate;//系统日期
    public string SysSeqId;//交易流水号
    public string PgKeyFile;//公钥文件名
    public string ChkValue;//签名值
    public string ret;//验证签名
    public string loginname;
    public string action;
    Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        //if (Page.Request.RequestType.ToString() != "POST")
        //{
        //    Response.Redirect("/index.htm");
        //    return;
        //}
        if (Request.QueryString["action"] != null)
        {
            action = Request.QueryString["action"].Trim();
        }
        TransType = Request.Form["TransType"];//交易类型

        MerId = Request.Form["MerId"];//商户号

        OrdId = Request.Form["OrdId"];//订单号

        MerDate = Request.Form["MerDate"];//商户日期

        TransAmt = Request.Form["TransAmt"];//交易金额

        MerPriv = Request.Form["MerPriv"];//商户私有域

        GateId = Request.Form["GateId"];//网关号

        TransStat = Request.Form["TransStat"];//交易状态

        SysDate = Request.Form["SysDate"];//系统日期

        SysSeqId = Request.Form["SysSeqId"];//系统流水号

        //lblPnr.Text = OrdId;
        //lblSys.Text = SysSeqId;
        //lblPayPoint.Text = TransAmt;//实际支付金额
        //lblPoint.Text = tzWeb.pay.comm.getOrderPoint(Convert.ToInt64(OrdId));//需要支付的点数

        ChkValue = Request.Form["ChkValue"];//签名值
        PgKeyFile = System.Configuration.ConfigurationSettings.AppSettings["pnrPK"];//公钥文件名
        CHINAPNRLib.NetpayClientClass ThisOrder = new CHINAPNRLib.NetpayClientClass();
        ret = ThisOrder.VeriSignOrder0(MerId, PgKeyFile, OrdId, TransAmt, MerDate, TransType, TransStat, GateId, MerPriv, SysDate, SysSeqId, ChkValue);
        //loginname = tzWeb.LoginInfo.GetLoginUserName(0);
        bool cs_success = OnlineStrike.isSuccess(OrdId);//该订单是否充值成功
        if (!Page.IsPostBack)
        {
            if (ret == "0")//本次调用成功
            {
                if (TransStat == "S")
                {
                    if (!cs_success)//
                    {
                        //开始充值

                        //bool b = dal.StrikeSuccess(OrdId, "huanglelou");
                        bool b = dal.StrikeSuccess(OrdId, "pnr", SysSeqId, Page.User.Identity.Name);
                        if (b)
                        {
                            Response.Write("RECV_ORD_ID" + OrdId);
                        }
                        else
                        {
                            Response.Write("充值未成功,请联系我们的客服!");
                        }
                    }
                }
            }
            else
            {
                Response.Write("验证失败");
            }
        }

    }
}