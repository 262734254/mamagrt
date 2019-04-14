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

public partial class PayManage_return_szx : System.Web.UI.Page
{
    protected string bussinessid;
    protected string orderid;
    protected string cardsn;
    protected string truemoney;
    protected string creattime;
    protected string sucflag;
    protected string userid;
    protected string username;
    protected string email;
    protected string tel;
    protected string post;
    protected string address;
    protected string note;
    protected string verifymd5;
    protected string digitalstr;
    protected string mybussinessid;
    protected string md5Key;
    protected string certFile;
    Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Page.Request.RequestType.ToString() != "POST")
        //{
        //    Response.Redirect("/index.htm");//
        //    return;

        //}
        bussinessid = Request.Params["bussinessid"];//商户ID
        orderid = Request.Params["orderid"];//订单号
        cardsn = Request.Params["cardsn"];//用户的充值卡序列号
        truemoney = Request.Params["true_money"];//充值金额
        creattime = Request.Params["creattime"];//'订单日期 不少于21位
        sucflag = Request.Params["suc_flag"];//是否成功 1成功 0失败
        userid = Request.Params["userid"];//用户id
        username = Request.Params["username"];//姓名
        email = Request.Params["email"];//邮件
        tel = Request.Params["tel"];//电话
        post = Request.Params["post"];//邮编
        address = Request.Params["address"];//地主
        note = Request.Params["note"];//留言
        verifymd5 = Request.Params["verifymd5"];//返回的加密字段
        digitalstr = Request.Params["digitalstr"];//返回的签名
        mybussinessid = "945104";//
        md5Key = "tz888";//商户通过神州行管理平台设置的MD5密钥
        certFile = System.Configuration.ConfigurationSettings.AppSettings["szxcert"];//神州行证书文件
        string myverifymd5 = GetKey(bussinessid, orderid, sucflag, truemoney, md5Key);//返回验证
        bool cz_success = OnlineStrike.isSuccess(orderid);//该订单是否充值成功
        lblPnr.Text = orderid;
        lblSys.Text = cardsn;
        lblPoint.Text = truemoney;//实际支付金额
        string loginname = Page.User.Identity.Name;
        if (bussinessid == mybussinessid)
        {
            SIGN32Lib.SignVerifyClass sign32 = new SIGN32Lib.SignVerifyClass();
            bool b = sign32.Verify(certFile, verifymd5, digitalstr);//证书  MD5验证码 二级签名数据
            if (verifymd5 == myverifymd5)
            {
                if (b)//数字验证通过 POST 方式访问（神州行支付网站订单交易结果）
                {
                    //int money=Convert.ToInt32(truemoney)*100+0.5/100;
                    if (sucflag == "1" && Convert.ToInt32(truemoney) > 0)//交易成功
                    {
                        if (!cz_success)//
                        {
                            bool ResultFlag = dal.StrikeSuccess(orderid, "szx",cardsn, loginname);
                            if (!ResultFlag)
                            {
                                Response.AddHeader("Data-Received", "1");//添加headed
                            }
                            else //订单更新失败 继续发送返回结果
                            {
                                Response.AddHeader("Data-Received", "0");
                            }
                        }
                    }
                    else//交易失败
                    {
                        //Response.Write("支付失败");
                    }
                }
            }
            else
            {
                //Response.Write("二级签名验证错误");
            }
        }
        else
        {
            //Response.Write("无效的参数");
        }
        //写入日志
    }
    public string GetKey(string bussinessid, string orderid, string sucflag, string truemoney, string md5Key)
    {
        string key = bussinessid + orderid + sucflag + truemoney + md5Key;//字符格式
        string md = FormsAuthentication.HashPasswordForStoringInConfigFile(key.ToLower(), "MD5");
        string md5str = md.ToLower();//转换为小写
        return md5str;
    }
}