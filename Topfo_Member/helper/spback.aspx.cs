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
using System.Security.Cryptography;

public partial class helper_spback : System.Web.UI.Page
{
    //公共参数
    protected string CPID = "0755029";
    protected string CPPWD = "123456";
    protected string feecode = "000000";
    protected string feetype = "02";
    protected string hostname = "http://211.151.48.12/sms/sendsms?";//下行地址
    protected string LoginName = "";
    protected string LoginPwd = "";
    protected string status = "1";
    //--下行参数----
    protected string ToMsg = "";
    Tz888.BLL.VipMsg dal = new Tz888.BLL.VipMsg();
    Tz888.Model.VipMsg model = new Tz888.Model.VipMsg();
   
    protected void Page_Load(object sender, EventArgs e)
    {

        //--上行参数---
        string srcmobile = Request.Params["srcmobile"].ToString();
        string spmobile = Request.Params["spmobile"].ToString();
        string msg = Request.Params["msg"].ToString();
        string msgid = Request.Params["MsgID"].ToString();
        string cpid = Request.Params["CPID"].ToString();
        string linkid = Request.Params["linkid"].ToString();
        string gateway = Request.Params["gateway"].ToString();
        string svid = Request.Params["svid"].ToString();
        LoginName = msg.Substring(2, msg.Length - 2).ToString();
        if (spmobile == "106693891329")
        {
            string re = "http://www.jianzhentech.com/spback.aspx?CPID=0755029&srcmobile=" + srcmobile + "&spmobile=" + spmobile + "&linkID=" + linkid + "&MsgID=" + msgid + "&gateway=" + gateway + "&msg=" + GBK(msg).Replace("#", "%23") + "&svid=" + svid;
            wt(re);
            Response.Redirect(re);
        }
        else
        {
            Tz888.BLL.SendNotice bll = new Tz888.BLL.SendNotice();
            string content = "";//下行消息
            //业务处理
            model.srcMobile = srcmobile;
            model.spMobile = spmobile;
            model.LoginName = LoginName;
            model.Msg = msg;
            model.CPID = cpid;
            model.MsgID = msgid;
            model.linkID = linkid;
            model.gateway = Convert.ToInt32(gateway);
            model.svid = svid;
            int i = dal.Add(model);
            if (i == 0)
            {
                content = "您的拓富通会员试用申请已成功,有效期：" + DateTime.Now.ToShortDateString() + "至" + DateTime.Now.AddDays(1).ToShortDateString() + "请登录网站体验.[拓富网topfo.com],此信息1元/条,不含通讯费";
                feecode = "000100";
                status = "0";
                SendMsg_cp(srcmobile, GBK(content), svid, linkid, msgid, feecode, gateway);
                wt(DateTime.Now.ToString() + LoginName + "操作返回参数：" + i.ToString());
            }
            else
            {
                if (i == 1)
                {
                    content = "您已经超过拓富通会员的试用次数![中国招商投资网topfo.com],此条信息免费";
                }
                else if (i == 2)
                {
                    content = "您输入的帐号有误,申请尚未成功.[中国招商投资网topfo.com],此条信息免费";
                }
                else
                {
                    content = "试用申请失败.[中国招商投资网topfo.com],此条信息免费";
                }
                bool b = bll.SendMobileMsg(srcmobile, content);
                //SendMsg_cp(srcmobile, GBK(content), svid, linkid, msgid, feecode, gateway);
                wt(LoginName + srcmobile + content);
            }
        }
       
    }
    /// <summary>
    /// 发送下行
    /// </summary>
    /// <param name="srcmobile">目标</param>
    /// <param name="msg">内容</param>
    /// <param name="svid">服务的代码(上行带入)</param>
    /// <param name="linkID">（包月不带此参数，点播的参数为上行传过来的参数）</param>
    /// <param name="MsgID">消息ID（上行带入）</param>
    /// <param name="gateway">1代表中国联通，3代表网通，4代表中国移动</param>
    public void SendMsg_cp(string srcmobile, string msg, string svid, string linkID, string MsgID,string feecode, string gateway)
    {
        string strUrl = "http://211.151.48.12/sms/sendsms?mobile=" + srcmobile + "&srcmobile=106693891329&feecode=" + feecode + "&feetype=02&msgfmt=15&svid=" +
            svid + "&msg=" + msg + "&cpid=0755029&cppassword=123456&linkid=" + linkID + "&MsgID=" + MsgID + "&gateway=" + gateway;
        Response.Redirect(strUrl);
    }
    public string GBK(string str)
    {
        return HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding("GB2312"));
    }
    public void InsertLog(string loginname, string mobileno,string msg)
    {
        Tz888.BLL.VipMsg obj = new Tz888.BLL.VipMsg();
        string errmsg=mobileno+","+msg;
        int i = obj.InsertError(loginname,errmsg);
    }
    public void wt(string str)
    {
        if (System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(@"log.txt")))
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Server.MapPath(@"log.txt"), true, System.Text.Encoding.GetEncoding("gb2312"));
                sw.WriteLine(str);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                
            }
        }
    }

}
