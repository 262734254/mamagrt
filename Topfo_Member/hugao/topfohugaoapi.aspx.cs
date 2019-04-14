using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;
using System.IO;

public partial class hugao_topfohugaoapi : System.Web.UI.Page
{
    //互告环境测试 - 获取信息接口 - 获取信息
    public string cookiename = "uID";
    public SqlConnection con;
    public string cookieid;

    public string sqlconStr = System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnString1"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (true)//Page.User.Identity.Name.Trim() != "")
        {
            con = new SqlConnection(sqlconStr);

            try
            {
                //databinding("211946");
                if (Request.QueryString["uid"] != null && Request.QueryString["uid"].ToString().Trim() != "")
                {
                    string userid = Request.QueryString["uid"].ToString().Trim();
                    databinding(userid);
                }
            }
            catch
            {
                Response.Write("faild..");
            }
        }
    }

    public void databinding(string userid)
    {
        string retStr = "";
        try
        {
            con.Open();
            string sqlStr = "select LoginName,NickName,Tel,Email,QQMSN from Logininfotab where loginId=" + userid.ToString() + "";
            DataSet ds = new DataSet();
            new SqlDataAdapter(new SqlCommand(sqlStr, con)).Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                //<item value='name|email|tel|qq|msn'>
                string name = ds.Tables[0].Rows[0]["LoginName"].ToString();
                string email = ds.Tables[0].Rows[0]["Email"].ToString();
                string tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                string qq = ds.Tables[0].Rows[0]["QQMSN"].ToString();
                string msn = ds.Tables[0].Rows[0]["QQMSN"].ToString();
                retStr = "<item value='" + userid.ToString() + "|" + email + "|" + tel + "|" + qq + "|" + msn + "'></item>";
            }
            con.Close();
        }
        catch
        {
            con.Close();
        }
        Response.Write(retStr);
    }
}
