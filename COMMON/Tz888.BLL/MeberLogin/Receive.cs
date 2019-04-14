using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class Receive
    {

        #region 我收到的留言
        /// <summary>
        /// 我收到的留言
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string SelReceive(string name, int n, string time, string title)
        {
            StringBuilder sb = new StringBuilder();
            string num=" and 1=1 ";
            if (time != "all")
            {
                if (time == "91")
                {
                    num += " and DateDiff(d,CommentTime,getdate())>'" + time + "' ";
                }
                else
                {
                    num += " and DateDiff(d,CommentTime,getdate())<='" + time + "' ";
                }  
            }
            if (title != "" & title != "请输入标题")
            {
                num += " and title like '%"+title+"%' ";
            }
            string sql = "select top 10 ID,InfoID,LoginName,CommentContent,CommentTime,IsAudit,Title,InfoOwner,HtmlFile,"
                +" InfoTypeID from InfoCommentManagerVIW where InfoOwner=@name "+num+" and IsDelete<>1 and ID not in(select top "+10*n+" ID "
                + "from InfoCommentManagerVIW where InfoOwner=@name " + num + " and IsDelete<>1 order by ID desc) order by ID desc";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    DateTime dt = Convert.ToDateTime(row["CommentTime"].ToString());
                    string begTime = dt.ToLongDateString().ToString();
                    string LGName = row["LoginName"].ToString().Trim();
                    sb.Append("<li><table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>");
                    sb.Append("<td width=\"7%\" class=\"t-center\"><label>");
                    sb.Append("<input type=\"checkbox\" name=\"cbxSelect\" id=\"cbxSelect\" value='"+row["ID"].ToString()+"' /></label></td>");
                    sb.Append("<td width=\"85%\">");
                    sb.Append("<div class=\"liuyan-title\">");
                    if (Convert.ToString(row["infoTypeID"]) == "Release")
                    {
                        sb.Append("<a href='http://union.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank'  class=\"lan1\">" + row["Title"].ToString() + "</a>");
                    }
                    else if (Convert.ToString(row["infoTypeID"]) == "News" || Convert.ToString(row["infoTypeID"]) == "Cases")
                    {
                        sb.Append("<a href='http://news.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank'  class=\"lan1\">" + row["Title"].ToString() + "</a>");
                    }
                    else
                    {
                        sb.Append("<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank'  class=\"lan1\">" + row["Title"].ToString() + "</a>");
                    }
                    sb.Append("</div>");
                    sb.Append("<div class=\"liuyan-con\">" + row["CommentContent"].ToString() + "</div>");
                    sb.Append("<div class=\"liuyan-xinxi\">");
                    sb.Append("<span class=\"fl\"> <span class=\"f_cen\">" + begTime + "</span>");
                    sb.Append("来自<span class=\"hong\">"+row["LoginName"]+"</span>对于 <span class='f_cen'>"+row["title"].ToString()+"</span>的留言</span> ");
                    sb.Append("<span class=\"fr\">");
                    sb.Append("<a href='JavaScript:Res("+row["ID"].ToString()+")'  class='lan1'>回复</a> ");
                    sb.Append("<a href='javascript:Friendd(\""+LGName+"\")'  class='lan1' >加为好友</a> ");
                    sb.Append("<a href='JavaScript:Publish(" + row["ID"].ToString() + "," + row["IsAudit"].ToString() + ")' id='pubId' class='lan1'>" + status(Convert.ToString(row["IsAudit"])) + "</a> ");
                    sb.Append("<a href='JavaScript:Del("+row["ID"].ToString()+")' class='lan1'>删除</a>");
                    sb.Append("</span></div>");
                    sb.Append("</td></tr></table></li>");

                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public int IndexReceive(string name, string time, string title)
        {
            int indexPage = 0;
            string num = " and 1=1 ";
            if (time != "all")
            {
                if (time == "91")
                {
                    num += " and DateDiff(d,CommentTime,getdate())>'" + time + "' ";
                }
                else
                {
                    num += " and DateDiff(d,CommentTime,getdate())<='" + time + "' ";
                }
            }
            if (title != "" & title != "请输入标题")
            {
                num += " and title like '%" + title + "%' ";
            }
            string sql = "select count(ID) from (select ID from InfoCommentManagerVIW where InfoOwner=@name " + num + " and IsDelete<>1) as a";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            indexPage = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return indexPage;
        }
        /// <summary>
        /// 我收到的留言分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string IndexPageReceive(string name, int n, string time, string title)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = IndexReceive(name, time, title);
            int pageIndex = 0;//总共多少个页面数
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("总条数<span class='hong'>" + pageCount + "</span>,第<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>页,");
                sb.Append("每页显示<span class=\"hong\">10</span>条 ");
                sb.Append("<a href='JavaScript:Having(0,1);' class=\"lan1\">第一页</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n - 1) + ",1);' class=\"lan1\">上一页</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(" + i + ",1);'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n + 1) + ",1);' class=\"lan1\">下一页</a>");
                }
                sb.Append("<a href='JavaScript:Having(" + (pageIndex - 1) + ",1);' class=\"lan1\">最后页</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" class='btn-002' onclick=\"javascript:onccxx(1);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
        public string status(string view)
        {
            if (view.ToString() == "0")
            {
                return "公开留言";
            }
            else
            {
                return "关闭留言";
            }

        }
        #endregion

        #region 我发出的留言
        /// <summary>
        /// 我发出的留言
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string SelSend(string name, int n, string time, string title)
        {
            StringBuilder sb = new StringBuilder();
            string num = " and 1=1 ";
            if (time != "all")
            {
                if (time == "91")
                {
                    num += " and DateDiff(d,CommentTime,getdate())>'" + time + "' ";
                }
                else
                {
                    num += " and DateDiff(d,CommentTime,getdate())<='" + time + "' ";
                }
            }
            if (title != "" & title != "请输入标题")
            {
                num += " and title like '%" + title + "%' ";
            }
            string sql = "select top 10 ID,InfoID,LoginName,CommentContent,CommentTime,IsAudit,Title,InfoOwner,HtmlFile,"
                + " InfoTypeID from InfoCommentManagerVIW where LoginName=@name " + num + " and IsDelete<>1 and ID not in(select top " + 10 * n + " ID "
                + "from InfoCommentManagerVIW where LoginName=@name " + num + " and IsDelete<>1 order by ID desc) order by ID desc";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql, para);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    DateTime dt = Convert.ToDateTime(row["CommentTime"].ToString());
                    string begTime = dt.ToLongDateString().ToString();

                    sb.Append("<li><table width=\"98%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>");
                    sb.Append("<td width=\"7%\" class=\"t-center\"><label>");
                    sb.Append("<input type=\"checkbox\" name=\"cbxSelect\" id=\"cbxSelect\" value='" + row["ID"].ToString() + "' /></label></td>");
                    sb.Append("<td width=\"85%\">");
                    sb.Append("<div class=\"liuyan-title\">");
                    if (Convert.ToString(row["infoTypeID"]) == "Release")
                    {
                        sb.Append("<a href='http://union.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank'  class=\"lan1\">" + row["Title"].ToString() + "</a>");
                    }
                    else if (Convert.ToString(row["infoTypeID"]) == "News" || Convert.ToString(row["infoTypeID"]) == "Cases")
                    {
                        sb.Append("<a href='http://news.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank'  class=\"lan1\">" + row["Title"].ToString() + "</a>");
                    }
                    else
                    {
                        sb.Append("<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank'  class=\"lan1\">" + row["Title"].ToString() + "</a>");
                    }
                    sb.Append("</div>");
                    sb.Append("<div class=\"liuyan-con\">" + row["CommentContent"].ToString() + "</div>");
                    sb.Append("<div class=\"liuyan-xinxi\">");
                    sb.Append("<span class=\"fl\"> <span class=\"f_cen\">" + begTime + "</span>");
                    sb.Append("发给<span class=\"hong\">" + row["InfoOwner"] + "</span>对于 <span class='f_cen'>" + row["title"].ToString() + "</span>的留言</span> ");
                    sb.Append("</div>");
                    sb.Append("</td></tr></table></li>");

                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        public int IndexSend(string name, string time, string title)
        {
            int indexPage = 0;
            string num = " and 1=1 ";
            if (time != "all")
            {
                if (time == "91")
                {
                    num += " and DateDiff(d,CommentTime,getdate())>'" + time + "' ";
                }
                else
                {
                    num += " and DateDiff(d,CommentTime,getdate())<='" + time + "' ";
                }
            }
            if (title != "" & title != "请输入标题")
            {
                num += " and title like '%" + title + "%' ";
            }
            string sql = "select count(ID) from (select ID from InfoCommentManagerVIW where LoginName=@name and IsDelete<>1 " + num + ") as a";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            indexPage = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return indexPage;
        }
        /// <summary>
        /// 我发出的留言分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string IndexPageSend(string name, int n, string time, string title)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = IndexSend(name, time, title);
            int pageIndex = 0;//总共多少个页面数
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("总条数<span class='hong'>" + pageCount + "</span>,第<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>页,");
                sb.Append("每页显示<span class=\"hong\">10</span>条 ");
                sb.Append("<a href='JavaScript:Having(0,2);' class=\"lan1\">第一页</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n - 1) + ",2);' class=\"lan1\">上一页</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(" + i + ",2);'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n + 1) + ",2);' class=\"lan1\">下一页</a>");
                }
                sb.Append("<a href='JavaScript:Having(" + (pageIndex - 1) + ",2);' class=\"lan1\">最后页</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" class='btn-002' id=\"btnOk\" onclick=\"javascript:onccxx(2);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
        #endregion

    }
}
