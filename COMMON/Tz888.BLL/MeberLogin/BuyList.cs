using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class BuyList
    {
        MemberIndex index = new MemberIndex();
        /// <summary>
        /// 购买记录显示的内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string SelBuylist(string name, int n, string time, string type)
        {
            StringBuilder sb = new StringBuilder();
            string num = " and 1=1 ";
            if (time == "all")
            {
                num += " ";
            }
            else if (time == "91")
            {
                num += " and DateDiff(d,ConsumeTime,getdate())>'" + time + "'";
            }
            else
            {
                num += " and DateDiff(d,ConsumeTime,getdate())<='" + time + "'";
            }
            if (type != "all")
            {
                num += " and InfoTypeID='" + type + "'";
            }
            string sql = "select top 10 ID,InfoID,InfoTypeID,HtmlFile,SourceType,dispointcount,ConsumeTime,LoginName "
                +" from ConsumeRec2Viw where LoginName=@name "+num+" and ID not in(select top "+10*n+" ID from ConsumeRec2Viw "
                +" where LoginName=@name order by ID desc )  order by ID desc";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead>");
            sb.Append("<tr><td width=\"17%\">类别</td>");
            sb.Append("<td width=\"21%\">资源标题</td>");
            sb.Append("<td width=\"17%\">价格（元）</td>");
            sb.Append("<td width=\"17%\">发布时间</td>");
            sb.Append("<td width=\"16%\">状态</td>");
            sb.Append("<td width=\"12%\">匹配</td>");
            sb.Append("</tr></thead>");
            DataSet ds = DbHelperSQL.Query(sql,para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string point = row["dispointcount"].ToString() == "" ? "0" : row["dispointcount"].ToString();
                    DateTime dt = Convert.ToDateTime(row["ConsumeTime"].ToString());
                    string begTime = dt.ToString("yyyy-MM-dd");

                    sb.Append("<tr><td>"+index.SelInfoType(row["InfoTypeID"].ToString().Trim())+"</td>");
                    if (Convert.ToString(row["infoTypeID"]) == "Release")
                    {
                        sb.Append("<td><a href='http://union.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                    }
                    else if (Convert.ToString(row["infoTypeID"]) == "News" || Convert.ToString(row["infoTypeID"]) == "Cases")
                    {
                        sb.Append("<td><a href='http://news.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                    }
                    else
                    {
                        sb.Append("<td><a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                    }
                    sb.Append("<td><span class=\"hong\">"+point+"</span></td>");
                    sb.Append("<td>" + begTime + "</td>");
                    sb.Append("<td><span class=\"lanl\">已付款| <a target=\"_blank\" class=\"lan1\" href=\"trade_detail.aspx?infoid=" + row["InfoID"].ToString() + "&type=info&status=1\">查看明细</a></span></td>");
                    sb.Append("<td><span class=\"lanl\"><a target=\"_blank\" class=\"lan1\" href=\"/Manage/PertinentLink.aspx?infoid=" + row["InfoID"].ToString() + "&type=" + row["InfoTypeID"].ToString() + "\">相关资源</a></span></td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// 总条数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int SelBuyIndex(string name, string time, string type)
        {
            int IndexCount = 0;
            string num = " and 1=1 ";
            if (time == "all")
            {
                num += " ";
            }
            else if (time == "91")
            {
                num += " and DateDiff(d,ConsumeTime,getdate())>'" + time + "'";
            }
            else
            {
                num += " and DateDiff(d,ConsumeTime,getdate())<='" + time + "'";
            }
            if (type != "all")
            {
                num += " and InfoTypeID='" + type + "'";
            }
            string sql = "select count(ID) from (select ID from ConsumeRec2Viw where LoginName=@name "+num+") as a";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            IndexCount = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return IndexCount;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string SelBuyPageIndex(string name, int n, string time, string type)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = SelBuyIndex(name, time, type);
            int pageIndex = 0;//总共多少个页面数
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("总条数<span class='hong'>"+pageCount+"</span>第<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>页,");
                sb.Append("每页显示<span class=\"hong\">10</span>条 ");
                sb.Append("<a href='JavaScript:Having(0,0);' class=\"lan1\">第一页</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(0," + (n - 1) + ");' class=\"lan1\">上一页</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(0," + i + ");'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(0," + (n + 1) + ");'  class=\"lan1\">下一页</a>");
                }
                sb.Append("<a href='JavaScript:Having(0," + (pageIndex - 1) + ");' class=\"lan1\">最后页</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(0);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
    }
}
