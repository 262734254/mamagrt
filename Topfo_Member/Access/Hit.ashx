<%@ WebHandler Language="C#" Class="Hit" %>

using System;
using System.Web;

public class Hit : IHttpHandler {
    Tz888.BLL.MeberLogin.AccessBLL ac = new Tz888.BLL.MeberLogin.AccessBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string InfoID = context.Request["InfoID"];
        string balk = context.Request["jsoncallback"];
        int num = ac.ModfiyHit(InfoID);
        string com = num.ToString();
        //string my = balk + com;
        context.Response.Write(balk + "({name:"+com+"})");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}