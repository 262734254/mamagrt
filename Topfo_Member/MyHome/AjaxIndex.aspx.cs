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
using System.Text;
using System.Collections.Generic;
using Tz888.SQLServerDAL.MyHome;
using Tz888.Model.MyHome;
using Tz888.BLL.MyHome;
using Tz888.Pager;
using System.Drawing;
using System.IO;
using Tz888.DBUtility;

public partial class MyHome_AjaxIndex : System.Web.UI.Page
{
    StringBuilder sb = new StringBuilder();
    int cui = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       cui = Convert.ToInt32(Request["sc"]);
       //if (string.IsNullOrEmpty(Page.User.Identity.Name))
       //{
       //    Response.Redirect("/Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.RawUrl));
       //}
        if (!IsPostBack)
        {
            if (Request["cid"] == "1")
            {
                Click();
            }
            Response.Write(sb.ToString());
        }

    }
    #region 获取字字符长度
    /// <summary>
    /// 获取文章标题长度
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="n">大小</param>
    /// <returns></returns>
    public string GetTitle(string title, int n)
    {
        string str = "";
        if (title != "")
        {
            str = title.Length > n ? title.ToString().Substring(0, n) + ".." : title;
        }
        return str;

    } 
    #endregion

    private void Click()
    {
        string LoginName = Page.User.Identity.Name;
        if (cui != 0)
        {
            string sql = "select LID, NID,Linkwww ,LName  FROM HomeLink where NID=" + cui + " and [LoginName] ='" + LoginName + "'  order by WDoc desc";
            DataTable table = Tz888.DBUtility.DBHelper.GetDataSet(sql);
            string url = "http://";
            sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab2 f_14\"><tr>" +
                "<td colspan=\"6\" class=\"col strong\">网址快捷链接</td></tr><tr>");
            if (table.Rows.Count == 0)
            {
                sb.Append("<td style='text-align:center'>&nbsp;您没有添加这类型数据</td>");
            }
            else
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow row = table.Rows[i];
                    string title = row["LName"].ToString();
                    if ((i - 4) % 6 != 1)
                    {
                        sb.Append("<td align=\"center\" width=\"16%\" style=\"height: 30px\" ><a href= " + url + row["Linkwww"].ToString() + " target=\"_blank\" >&nbsp;" + GetTitle(row["LName"].ToString(), 7) + "</a></td>");
                      
                    }
                    else
                    {
                        sb.Append("<td  align=\"center\" width=\"16%\" style=\"height: 30px\"><a href= " + url + row["Linkwww"].ToString() + " target=\"_blank\" >&nbsp;" + GetTitle(row["LName"].ToString(),7) + "</a></td></tr><tr>");
                    }
    
                }
            }
            sb.Append("</tr></table>");
        }
        else
        {
            sb.Append("<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tab2 f_14\"><tr>" +
                  "<td colspan=\"6\" class=\"col strong\">网址快捷链接</td></tr><tr>");
            sb.Append("</tr></table>");
        }
    }
}
