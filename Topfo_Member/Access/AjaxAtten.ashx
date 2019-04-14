<%@ WebHandler Language="C#" Class="AjaxAtten" %>

using System;
using System.Web;

public class AjaxAtten : IHttpHandler {
    Tz888.BLL.MeberLogin.AccessBLL ac = new Tz888.BLL.MeberLogin.AccessBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string name = context.Request["name"];
        int page = Convert.ToInt32(context.Request["Page"]);
        int Type = Convert.ToInt32(context.Request["Type"]);
        string InfoType = context.Request["InfoType"];
        if (Type == 1)
        {
            string Statue = ac.SelMainLoginName(name, page, InfoType);
            context.Response.Write(Statue);
        }
        else if (Type == 2)
        {
            string pageIndex = ac.SelPageIndex(name, page, InfoType);
            context.Response.Write(pageIndex);
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}