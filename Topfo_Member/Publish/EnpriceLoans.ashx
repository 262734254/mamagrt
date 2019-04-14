<%@ WebHandler Language="C#" Class="EnpriceLoans" %>

using System;
using System.Web;

public class EnpriceLoans : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Tz888.BLL.loansInfoTab loansinfotabbll = new Tz888.BLL.loansInfoTab();
        int Id = Convert.ToInt32(context.Request["Id"]);
            if (Id > 0)
            {
                int result = loansinfotabbll.UpdaterefurbishtimeLoansInfoTab(Id);
                context.Response.Write(result.ToString().Trim());
            }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}