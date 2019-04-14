<%@ WebHandler Language="C#" Class="AajxTab" %>

using System;
using System.Web;
using Tz888.BLL.MeberLogin;

public class AajxTab : IHttpHandler {
    MemberIndexBLL member = new MemberIndexBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string name =context.Request["name"];
        int type = Convert.ToInt32(context.Request["Type"]);
        int page = Convert.ToInt32(context.Request["page"]);
        int str = Convert.ToInt32(context.Request["Strike"]);
        string time = context.Request["BegTime"];
        string pay = context.Request["payType"];

        if (type == 1)
        {
            if (str == 0)
            {
                string Rec = member.StrikeRec(name, page, time, pay);
                context.Response.Write(Rec);
            }
            else
            {
                string Order = member.StrikeOrder(name, page, time, pay);
                context.Response.Write(Order);
            }
        }
        else if (type == 2)
        {
            if (str == 0)
            {
                string pageRec = member.PageRecIndex(name, page, time, pay);
                context.Response.Write(pageRec);
            }
            else
            {
                string pageOrder = member.PageOrderIndex(name, page, time, pay);
                context.Response.Write(pageOrder);
            }
        }
    }
    
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}