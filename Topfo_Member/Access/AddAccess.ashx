<%@ WebHandler Language="C#" Class="AddAccess" %>

using System;
using System.Web;


public class AddAccess : IHttpHandler {
    Tz888.BLL.MeberLogin.AccessBLL ac = new Tz888.BLL.MeberLogin.AccessBLL();
    public void ProcessRequest (HttpContext context) {
         context.Response.ContentEncoding = System.Text.Encoding.UTF8;
        context.Response.ContentType = "application/json";
       // context.Response.ContentType = "text/plain";
        string InfoID = context.Request["InfoID"];
        string Name = context.Request["AccessName"];
        string time = context.Request["AccessTime"];
        string Ip = context.Request.UserHostAddress;
        string Proince = "";
        int num = ac.AccessInsert(InfoID,Name,time,Ip,Proince);
        context.Response.Write(num);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}