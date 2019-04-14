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

using System.Net;
using System.Net.Mail;
using System.Configuration;

public partial class ValueAdd_ServiceList : System.Web.UI.Page
{
    public string loginNameStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Page.User.Identity.Name))
        {
            Response.Redirect("/login.aspx?url=" + Page.Request.Url.ToString());
        }


        if (!this.Page.IsPostBack)
        {
            databind();
        }
    }

    public void databind()
    {
        loginNameStr = Page.User.Identity.Name.Trim();
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SQLConnString1"].ToString());
        string sqlStr = "select * from serviceincrementtab where loginname='" + loginNameStr + "' order by ApplyTime desc";
        SqlCommand com = new SqlCommand(sqlStr, con);
        try
        {
            con.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter(com).Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();
            }
            con.Close();
        }
        catch
        {
            con.Close();
        }
    }

    public string getprice(string typeID)
    {
        string price = "";
        switch (typeID)
        {
            case "27": price = "1元/条/个(100元起)"; break;
            case "28": price = "按每条资源收费"; break;
            case "29": price = "2000/个"; break;
            case "30": price = "8000/份"; break;
            case "31": price = "3500/期"; break;
            case "32": price = "企业10000元/次<br/>政府30000元/次 "; break;
            case "33": price = "888元/年"; break;
            case "2": price = "价格：8万元/年（不含制作费"; break;
            case "34": price = "8000元/3月"; break;
            case "1": price = "参考广告收费标准"; break;
            case "35": price = "20元/条"; break;
        }
        return price;
    }
}
