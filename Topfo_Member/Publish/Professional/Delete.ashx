<%@ WebHandler Language="C#" Class="Delete" %>

using System;
using System.Web;

public class Delete : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        string name = Convert.ToString(context.Request["Id"]);
        int d = s(name);
        context.Response.Write(d);

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    public int s(string name)
    {
        //string sql = "update ProfessionalinfoTab  set auditId=1 where auditid=4";
        string sql = "update ProfessionalinfoTab set auditId=4 where ProfessionalID=" + int.Parse(name.ToString());
        ////System.Data.SqlClient.SqlParameter[] parameters = { new SqlParameter("@ProfessionalID", SqlDbType.Int, 4) };
        // parameters[0].Value = Convert.ToInt32(name);
        return Tz888.DBUtility.DbHelperSQL.ExecuteCommand(sql);

    }

}