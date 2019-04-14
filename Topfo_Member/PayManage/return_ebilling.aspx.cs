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

public partial class PayManage_return_ebilling : System.Web.UI.Page
{
   
    public string pCode;
    public string dateTime;
    public string caller_id;//付费电话号码
    public string loginname;
    public string charge;//金额
    public string demand_data;//订单号
    public string index_no;//eBilling 服务器认证的付费序号
    Tz888.BLL.StrikeOrder dal = new Tz888.BLL.StrikeOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        wt("接受参数");
        try
        {
            string icpData = new SOFTFAMILYLib.PayClass().Decode(Request.Params["Data"]);
            wt(icpData);
            if (icpData.Length > 8)
            {
                //Get the parameters from a string 
                pCode = icpData.Substring(0, 8);//产品编号
                dateTime = icpData.Substring(8, 14);
                caller_id = icpData.Substring(22, 16);//付费电话号码
                loginname = icpData.Substring(38, 20);//充值帐户
                charge = icpData.Substring(58, 9);//金额
                demand_data = icpData.Substring(67, 40);//订单号
                index_no = icpData.Substring(107, 16);//eBilling服务器认证的付费序号
                string str = icpData.Substring(23 - 1, 16) + icpData.Substring(59 - 1, 9) + icpData.Substring(108 - 1, 16);
                bool cz_success = OnlineStrike.isSuccess(demand_data);
                if (!cz_success)//
                {
                    //开始充值
                    bool b = dal.StrikeSuccess(demand_data, "ebilling", index_no, loginname);
                    Response.Write((new SOFTFAMILYLib.PayClass()).Encode(str));
                    wt((new SOFTFAMILYLib.PayClass()).Encode(str));
                }
            }
            else
                Response.Write("Error!");

        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
            wt(ex.Message);
        }
        
        //写入日志
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
