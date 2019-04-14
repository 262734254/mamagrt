using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

/*--收藏---*/
namespace Tz888.BLL.MeberLogin
{
    public class InfoView
    {
        MemberIndex index = new MemberIndex();
        /// <summary>
        /// 我的收藏显示内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string SelInfoView(string name, int n, string time, string state)
        {
            StringBuilder sb = new StringBuilder();
            string num=" and 1=1 ";
            if (state != "" & state != "请输入资源名称、发布者、类型等")
            {
                num += " and (Title like '%" + state + "%' OR PublishMan like '%" + state + "%' OR InfoTypeName like '%" + state + "%')";
            }
            if (time == "-1")
            {
                num += " ";
            }
            else if (time == "91")
            {
                num += " and DateDiff(d,CreateDate,getdate())>'" + time + "'";
            }
            else
            {
                num += " and DateDiff(d,CreateDate,getdate())<='"+time+"'";
            }
            string sql = "select top 10 ID,LoginName,Title,WorthPoint,InfoTypeName,HtmlFile,InfoOverdueTime,InfoTypeID,"
                +" PublishMan,MainPointCount from InfoViewCollectionVIW where LoginName=@name "+num+" and ID not in(select "
                +" top "+10*n+" ID from InfoViewCollectionVIW where LoginName=@name "+num+" order by ID desc) order by ID desc";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);
            sb.Append("<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><thead>");
            sb.Append("<tr><td align=\"center\"  width=\"9%\"> <a href=\"Javascript:SelectAll();\"><span >全选</span></a>");
            sb.Append("|<a href=\"Javascript:ReSelect();\"><span>反选</span></a></td>");
            sb.Append("<td align=\"center\"  style=\"color: #000000\" width=\"20%\">资源标题</td>");
            sb.Append("<td align=\"center\"  width=\"12%\">发布者</td>");
            sb.Append("<td align=\"center\"  width=\"9%\">类型</td>");
            sb.Append("<td align=\"center\"  width=\"15%\">资源价格(元)</td>");
            sb.Append("<td align=\"center\"  width=\"17%\">到期时间</td>");
            sb.Append("<td align=\"center\"  width=\"8%\">管理</td>");
            sb.Append("</tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string point = row["MainPointCount"].ToString() == "" ? row["WorthPoint"].ToString() : row["MainPointCount"].ToString();
                    sb.Append("<tr><td align=\"center\" class=\"taba\" style=\"height: 5px\"><label>");
                    sb.Append("<input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value='"+row["ID"].ToString()+"' /></label></td>");
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">");
                    if (Convert.ToString(row["infoTypeID"]) == "Release")
                    {
                        sb.Append("<a href='http://union.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["Title"].ToString() + "' class=\"lan1\">" + index.StrLength(row["Title"].ToString()) + "</a></td>");
                    }
                    else if (Convert.ToString(row["infoTypeID"]) == "News" || Convert.ToString(row["infoTypeID"]) == "Cases")
                    {
                        sb.Append("<a href='http://news.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["Title"].ToString() + "' class=\"lan1\">" + index.StrLength(row["Title"].ToString()) + "</a></td>");
                    }
                    else
                    {
                        sb.Append("<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["Title"].ToString() + "' class=\"lan1\">" + index.StrLength(row["Title"].ToString()) + "</a></td>");
                    }
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">" + row["PublishMan"].ToString() + "</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + row["InfoTypeName"].ToString() + "</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">"+point+"</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + row["InfoOverdueTime"].ToString() + "</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("<a href=\"#\" class=\"lan1\" onclick=\"JavaScript:Del('" + row["ID"].ToString().Trim() + "');\">删除</a></td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int PageCount(string name, string time, string state)
        {
            int count = 0;
            string num = " and 1=1 ";
            if (state != "" & state != "请输入资源名称、发布者、类型等")
            {
                num += " and (Title like '%" + state + "%' OR PublishMan like '%" + state + "%' OR InfoTypeName like '%" + state + "%')";
            }
            if (time == "-1")
            {
                num += " ";
            }
            else if (time == "91")
            {
                num += " and DateDiff(d,CreateDate,getdate())>'" + time + "'";
            }
            else
            {
                num += " and DateDiff(d,CreateDate,getdate())<='" + time + "'";
            }
            string sql = "select count(ID) from (select ID from InfoViewCollectionVIW where LoginName=@name "+num+" ) as c";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            count = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return count;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string PageIndex(string name, int n, string time, string state)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = PageCount(name, time, state);
            int pageIndex = 0;//总共多少个页面数
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("总页面数<span class=\"hong\">"+pageCount+"</span> 第<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>页,");
                sb.Append("每页显示<span class=\"hong\">10</span>条 ");
                sb.Append("<a href='JavaScript:Having(0);' class=\"lan1\">第一页</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n - 1) + ");' class=\"lan1\">上一页</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(" + i + ");'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n + 1) + ");' class=\"lan1\">下一页</a>");
                }
                sb.Append("<a href='JavaScript:Having(" + (pageIndex - 1) + ");' class=\"lan1\">最后页</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(0);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
    }
}
