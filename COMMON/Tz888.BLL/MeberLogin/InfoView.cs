using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

/*--�ղ�---*/
namespace Tz888.BLL.MeberLogin
{
    public class InfoView
    {
        MemberIndex index = new MemberIndex();
        /// <summary>
        /// �ҵ��ղ���ʾ����
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
            if (state != "" & state != "��������Դ���ơ������ߡ����͵�")
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
            sb.Append("<tr><td align=\"center\"  width=\"9%\"> <a href=\"Javascript:SelectAll();\"><span >ȫѡ</span></a>");
            sb.Append("|<a href=\"Javascript:ReSelect();\"><span>��ѡ</span></a></td>");
            sb.Append("<td align=\"center\"  style=\"color: #000000\" width=\"20%\">��Դ����</td>");
            sb.Append("<td align=\"center\"  width=\"12%\">������</td>");
            sb.Append("<td align=\"center\"  width=\"9%\">����</td>");
            sb.Append("<td align=\"center\"  width=\"15%\">��Դ�۸�(Ԫ)</td>");
            sb.Append("<td align=\"center\"  width=\"17%\">����ʱ��</td>");
            sb.Append("<td align=\"center\"  width=\"8%\">����</td>");
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
                    sb.Append("<a href=\"#\" class=\"lan1\" onclick=\"JavaScript:Del('" + row["ID"].ToString().Trim() + "');\">ɾ��</a></td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int PageCount(string name, string time, string state)
        {
            int count = 0;
            string num = " and 1=1 ";
            if (state != "" & state != "��������Դ���ơ������ߡ����͵�")
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
        /// ��ҳ
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
            int pageIndex = 0;//�ܹ����ٸ�ҳ����
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("��ҳ����<span class=\"hong\">"+pageCount+"</span> ��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">10</span>�� ");
                sb.Append("<a href='JavaScript:Having(0);' class=\"lan1\">��һҳ</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n - 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(" + i + ");'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n + 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                sb.Append("<a href='JavaScript:Having(" + (pageIndex - 1) + ");' class=\"lan1\">���ҳ</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(0);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
    }
}
