<%@ WebHandler Language="C#" Class="DeleteNew" %>

using System;
using System.Web;

public class DeleteNew : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Tz888.BLL.news.NewsTabBLL newstabbll = new Tz888.BLL.news.NewsTabBLL();

        int type = Convert.ToInt32(context.Request["type"]);
        int result1 = 0;
        if (type == 1)
        {
            int Id = Convert.ToInt32(context.Request["Id"]);
            result1 = newstabbll.UpdateNewsTabaudit(Id);

        }
        if (type == 2)
        {
            string str =context.Request["str"].ToString ().Trim ().TrimEnd(',');
               string[] num = str.Split(',');
               for (int t = 0; t < num.Length; t++)
                {
                     result1 = newstabbll.UpdateNewsTabaudit(Convert.ToInt32(num[t]));
                } 
        }
        context.Response.Write(result1);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}