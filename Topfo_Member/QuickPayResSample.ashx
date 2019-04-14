<%@ WebHandler Language="C#" Class="QuickPayResSample" %>

using System;
using System.Web;
using System.Text;

public class QuickPayResSample : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        context.Request.ContentEncoding = System.Text.Encoding.GetEncoding(QuickPayConf.charset);
        String[] resArr = new String[QuickPayConf.notifyVo.Length];
        for (int i = 0; i < QuickPayConf.notifyVo.Length; i++)
        {
            resArr[i] = context.Request.Params[QuickPayConf.notifyVo[i]];
        }
        String signature = context.Request.Params[QuickPayConf.signature];
        String signMethod = context.Request.Params[QuickPayConf.signMethod];

        context.Response.ContentType = "text/html;charset=" + QuickPayConf.charset;
        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding(QuickPayConf.charset);

        try
        {
            bool signatureCheck = new QuickPayUtils().checkSign(resArr, signMethod, signature);
            StringBuilder sb = new StringBuilder();
            sb.Append("签名是否正确：" + signatureCheck);
            bool success = resArr[10] == "00";
            if (success)
            {
                sb.Append("<br>交易是否成功：" + success);
                sb.Append("<br>交易订单号：" + resArr[8]);
                sb.Append("<br>交易流水号：" + resArr[9]);
                sb.Append("<br>交易金额：" + resArr[13]);
              





            }

            else
            {
                sb.Append("<br>失败原因:" + resArr[11]);
            }
            context.Response.Write(sb.ToString());
        }
        catch (Exception) { }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}