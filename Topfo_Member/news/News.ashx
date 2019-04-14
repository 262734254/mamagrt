<%@ WebHandler Language="C#" Class="News" %>

using System;
using System.Web;

public class News : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Tz888.BLL.news.NewsTabBLL loansinfotabbll = new Tz888.BLL.news.NewsTabBLL ();
        string name = Convert.ToString(context.Request["username"]);
        int status = Convert.ToInt32(context.Request["status"]);
        int index = Convert.ToInt32(context.Request["pageIndex"]);
        int type = Convert.ToInt32(context.Request["type"]);
        string loanstitles = context.Request["loanstitle"].Trim();
        int typeId = Convert.ToInt32(context.Request["typeId"]);//贷款类型
        //type=1:绑定数据 type=2底下分页用
        if (type == 1)
        {
            string a = loansinfotabbll.GetStringPerson(name, status, index, typeId, loanstitles);//名称，审核状态,索引页，类型：企业个人，查询的标题
            context.Response.Write(a);
        }
        else if (type == 2)
        {
            string b = loansinfotabbll.pageCont(name, status, index, typeId, loanstitles);
            context.Response.Write(b);
        }
        else if (type == 3)
        {
            string indexs = "";
            for (int i = 0; i <= 4; i++)
            {
                if (i != 2)
                {
                    indexs += loansinfotabbll.pageIndex(name, i, typeId, loanstitles) + "$";
                }
            }
            context.Response.Write(indexs);
        }

    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}