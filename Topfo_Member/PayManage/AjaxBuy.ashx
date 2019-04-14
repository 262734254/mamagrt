<%@ WebHandler Language="C#" Class="AjaxBuy" %>

using System;
using System.Web;


public class AjaxBuy : IHttpHandler {
    Tz888.BLL.MeberLogin.MemberIndexBLL member = new Tz888.BLL.MeberLogin.MemberIndexBLL();
    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain";
        int page = Convert.ToInt32(context.Request["page"]);
        string InfoType = context.Request["Info"];
        string name = context.Request["name"];
        string time = context.Request["time"];
        int type = Convert.ToInt32(context.Request["Type"]);
        if (type == 0)
        {
            string buy = member.SelBuylist(name, page, time, InfoType);
            context.Response.Write(buy);
        }else if(type==1)
        {
            string pageBuy = member.SelBuyPageIndex(name,page,time,InfoType);
            context.Response.Write(pageBuy);
        }

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}