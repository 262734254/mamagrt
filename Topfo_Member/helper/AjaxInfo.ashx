<%@ WebHandler Language="C#" Class="AjaxInfo" %>

using System;
using System.Web;

public class AjaxInfo : IHttpHandler {
    Tz888.BLL.MeberLogin.MemberIndexBLL member = new Tz888.BLL.MeberLogin.MemberIndexBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string name = context.Request["name"];
        string time = context.Request["time"];
        int type = Convert.ToInt32(context.Request["Type"]);
        int page = Convert.ToInt32(context.Request["Page"]);
        string title = context.Request["Title"];
       
        if (type == 1)
        {
            string num = member.SelInfoView(name, page, time, title);
            context.Response.Write(num);
        }
        else
        {
            string pageIndex = member.PageIndexInfo(name, page, time, title);
            context.Response.Write(pageIndex);
        }
        
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}