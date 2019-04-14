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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string msg = "Mhuanglelou";
        //string LoginName = msg.Substring(1, msg.Length - 1).ToString();
        //Tz888.BLL.VipMsg dal = new Tz888.BLL.VipMsg();
        //Tz888.Model.VipMsg model = new Tz888.Model.VipMsg();
        ////业务处理
        //model.srcMobile = "13128761750";
        //model.spMobile = "123";
        //model.LoginName = LoginName;
        //model.Msg = "";
        //model.CPID = "";
        //model.MsgID = "";
        //model.linkID = "";
        //model.gateway =1;
        //model.svid = "";
        //int i = dal.Add(model);
        //Response.Write(i.ToString());
        string srcmobile = "13128761750";
        string linkID = "";
        string MsgID = "";
        string svid = "";
        string msg = "";
        string gateway = "4";
        string strUrl = "http://211.151.48.12/sms/sendsms?mobile=" + srcmobile + "&srcmobile=93891291&feecode=000100&feetype=02&msgfmt=15&svid=" +
             svid + "&msg=" + msg + "&cpid=0755029&cppassword=123456&linkid=" + linkID + "&MsgID=" + MsgID + "&gateway=" + gateway;
        //wt("下行参数为：" + srcmobile + "|" + msg + "|" + svid + "|" + linkID + "|" + MsgID + "|" + gateway + "|");
       
        Response.Redirect(strUrl);
        wt("返回值：" + Response.StatusCode.ToString());

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
