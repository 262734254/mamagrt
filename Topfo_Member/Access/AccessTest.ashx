<%@ WebHandler Language="C#" Class="AccessTest" %>

using System;
using System.Web;

public class AccessTest : IHttpHandler {
    Tz888.BLL.MeberLogin.AccessBLL ac = new Tz888.BLL.MeberLogin.AccessBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string InfoID = context.Request["InfoID"];
        int Type = Convert.ToInt32(context.Request["Type"]);
        int page = Convert.ToInt32(context.Request["Page"]);
        if (Type == 1)
        {
            string State = ac.SelAccess(InfoID,page);
            context.Response.Write(State);
        }
        else if (Type == 2)
        {
            string IndexPage = ac.IndexAccess(InfoID,page);
            context.Response.Write(IndexPage);
        }  
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}