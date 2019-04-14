<%@ WebHandler Language="C#" Class="DeleteLoans" %>

using System;
using System.Web;

public class DeleteLoans : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Tz888.BLL.loansInfoTab loansinfotabbll = new Tz888.BLL.loansInfoTab();
        int type = Convert.ToInt32(context.Request["type"]);
        int result1 = 0;
        if (type == 1)
        {
            int Id = Convert.ToInt32(context.Request["Id"]);
            result1 = loansinfotabbll.UpdateLoansInfoTabauditID(Id);

        }
        if (type == 2)
        {
            string str = context.Request["str"].ToString().Trim().TrimEnd(',');
            string[] num = str.Split(',');
            for (int t = 0; t < num.Length; t++)
            {
                result1 = loansinfotabbll.UpdateLoansInfoTabauditID(Convert.ToInt32(num[t]));
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