using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class WaitList
    {
        MemberIndex index = new MemberIndex();
        /// <summary>
        /// ���ﳵ����
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string SelWaitState(string name, int n, string time, string InfoType)
        {
            StringBuilder sb = new StringBuilder();
            string num = " and 1=1";
            if (time != "all")
            {
                if (time == "90")
                {
                    num += " and DateDiff(d,packdate,getdate())>" + time + "";
                }
                else {
                    num += " and DateDiff(d,packdate,getdate())<" + time + "";
                }
            } 
            if (InfoType != "all")
            {
                num += " and infoTypeID='"+InfoType+"'";
            }
            string sql = "select top 10 ShopCarID,LoginName,InfoID,infoTypeID,SourceType,WorthPoint,PackDate,HtmlFile,DisWorthPoint "
                +" from ShopCarVIW where LoginName=@name "+num+" and ShopCarID not in (select top "+10*n+" ShopCarID from "
                +" ShopCarVIW where LoginName=@name "+num+" order by ShopCarID desc) order by ShopCarID desc";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);
            sb.Append("<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><thead><tr>");
            sb.Append("<td align=\"center\"  width=\"9%\"><a href=\"Javascript:SelectAll();\"><span>ȫѡ</span></a>|");
            sb.Append("<a href=\"Javascript:ReSelect();\"><span>��ѡ</span></a></td>");
            sb.Append("<td align=\"center\"  width=\"10%\">���</td>");
            sb.Append("<td align=\"center\"  width=\"20%\">��Դ����</td>");
            sb.Append("<td align=\"center\"  width=\"13%\">�۸�(Ԫ)</td>");
            sb.Append("<td align=\"center\"  width=\"15%\">����ʱ��</td>");
            sb.Append("<td align=\"center\"  width=\"22%\">״̬</td>");
            sb.Append("<td align=\"center\"  width=\"10%\">ƥ��</td>");
            sb.Append("</tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                { 
                   DataRow row=ds.Tables[0].Rows[i];
                   string point = row["DisWorthPoint"].ToString() == "" ? row["WorthPoint"].ToString() : row["DisWorthPoint"].ToString();
                   DateTime dt = Convert.ToDateTime(row["PackDate"].ToString());
                   string date = dt.ToString("yyyy-MM-dd");
                   sb.Append("<tr><td align=\"center\" class=\"taba\" style=\"height: 5px\"><label>");
                   sb.Append("<input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\""+row["ShopCarID"].ToString()+"\" /></label></td>");
                   sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">"+index.SelInfoType(row["infoTypeID"].ToString().Trim())+"</td>");
                   sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">");
                   if (Convert.ToString(row["infoTypeID"]) == "Release")
                   {
                       sb.Append("<a href='http://union.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                   }
                   else if (Convert.ToString(row["infoTypeID"]) == "News" || Convert.ToString(row["infoTypeID"]) == "Cases")
                   {
                       sb.Append("<a href='http://news.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                   }
                   else
                   {
                       sb.Append("<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                   }
                   sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + point + ".00 Ԫ</td>");
                   sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + date + "</td>");
                   sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                   sb.Append("<a class=\"lan1\" href=\"/PayManage/order_item.aspx?InfoID=" + row["InfoID"].ToString() + "\">��������</a>");
                   sb.Append("</td>");
                   sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                   sb.Append("<a href=\"/Manage/PertinentLink.aspx?infoid=" + row["InfoID"].ToString() + "&type=" + row["infoTypeID"].ToString() + "\" class=\"lan1\">�����Դ</a>");
                   sb.Append("</td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// ���ﳵ������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public int PageWait(string name, string time, string InfoType)
        {
            int PageCount = 0;
            string num = " and 1=1";
            if (time != "all")
            {
                if (time == "90")
                {
                    num += " and DateDiff(d,packdate,getdate())>" + time + "";
                }
                else
                {
                    num += " and DateDiff(d,packdate,getdate())<" + time + "";
                }
            }
            if (InfoType != "all")
            {
                num += " and infoTypeID='" + InfoType + "'";
            }
            string sql = "select count(ShopCarID) from(select ShopCarID from ShopCarVIW where "
                +" LoginName=@name "+num+" group by ShopCarID) as b";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            PageCount = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return PageCount;
        }
        /// <summary>
        /// ���ﳵ��ҳ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string PageIndexWait(string name, int n, string time, string InfoType)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = PageWait(name, time, InfoType);
            int pageIndex = 0;//�ܹ����ٸ�ҳ����
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">10</span>�� ");
                sb.Append("<a href='JavaScript:Having(0,0);' class=\"lan1\">��һҳ</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(0," + (n - 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(0," + i + ");'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(0," + (n + 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                sb.Append("<a href='JavaScript:Having(0," + (pageIndex - 1) + ");' class=\"lan1\">���ҳ</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(0);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
        /// <summary>
        /// ���Ѽ�¼����
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string SelListStats(string name, int n, string time, string InfoType)
        {
            StringBuilder sb = new StringBuilder();
            string num = " and 1=1";
            if (time != "all")
            {
                if (time == "90")
                {
                    num += " and DateDiff(d,ConsumeTime,getdate())>" + time + "";
                }
                else
                {
                    num += " and DateDiff(d,ConsumeTime,getdate())<" + time + "";
                }
            }
            if (InfoType != "all")
            {
                num += " and infoTypeID='" + InfoType + "'";
            }
            string sql = "select top 10 LoginName,InfoID,InfoTypeID,SourceType,PointCount,DisPointCount,ConsumeTime,HtmlFile "
                + "from ConsumeRecVIW where LoginName=@name "+num+" and ID not in "
                + "(select top "+10*n+" ID from ConsumeRecVIW where LoginName=@name "+num+" order by ID desc)order by ID desc";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql, para);
            sb.Append("<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\"><thead>");
            sb.Append("<tr><td align=\"center\"  width=\"10%\">���</td>");
            sb.Append("<td align=\"center\"  width=\"20%\">��Դ����</td>");
            sb.Append("<td align=\"center\"  width=\"13%\">�۸�(Ԫ)</td>");
            sb.Append("<td align=\"center\"  width=\"15%\">����ʱ��</td>");
            sb.Append("<td align=\"center\"  width=\"22%\">״̬</td>");
            sb.Append("<td align=\"center\"  width=\"10%\">ƥ��</td></tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string point = row["DisPointCount"].ToString() == "" ? row["PointCount"].ToString() : row["DisPointCount"].ToString();
                    DateTime dt = Convert.ToDateTime(row["ConsumeTime"].ToString());
                    string date = dt.ToString("yyyy-MM-dd");
                    sb.Append("<tr><td align=\"left\" class=\"taba\" style=\"height: 5px\">" + index.SelInfoType(row["infoTypeID"].ToString().Trim()) + "</td>");
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">");
                    if (Convert.ToString(row["infoTypeID"]) == "Release")
                    {
                        sb.Append("<a href='http://union.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                    }
                    else if (Convert.ToString(row["infoTypeID"]) == "News" || Convert.ToString(row["infoTypeID"]) == "Cases")
                    {
                        sb.Append("<a href='http://news.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                    }
                    else
                    {
                        sb.Append("<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target='_blank' title='" + row["SourceType"].ToString() + "' class=\"lan1\">" + index.StrLength(row["SourceType"].ToString()) + "</a></td>");
                    }
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">"+point+".00 Ԫ</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">"+date+"</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("�Ѹ���| ");
                    sb.Append("<a class=\"lan1\" href=\"trade_detail.aspx?infoid=" + row["InfoID"].ToString() + "&type=info&status=1\">�鿴��ϸ</a></td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("<a href=\"/Manage/PertinentLink.aspx?infoid=" + row["InfoID"].ToString() + "&type=" + row["InfoTypeID"].ToString() + "\" class=\"lan1\">�����Դ</a>");
                    sb.Append("</td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// ���Ѽ�¼������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public int PageList(string name, string time, string InfoType)
        {
            int PageCount = 0;
            string num = " and 1=1";
            if (time != "all")
            {
                if (time == "90")
                {
                    num += " and DateDiff(d,ConsumeTime,getdate())>" + time + "";
                }
                else
                {
                    num += " and DateDiff(d,ConsumeTime,getdate())<" + time + "";
                }
            }
            if (InfoType != "all")
            {
                num += " and infoTypeID='" + InfoType + "'";
            }
            string sql = "select count(ID) from (select ID from ConsumeRecVIW where LoginName=@name  "+num+") as a";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            PageCount = Convert.ToInt32(DbHelperSQL.GetSingle(sql,para));
            return PageCount;
        }
        /// <summary>
        /// ���Ѽ�¼��ҳ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string PageIndexList(string name, int n, string time, string InfoType)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = PageList(name, time, InfoType);
            int pageIndex = 0;//�ܹ����ٸ�ҳ����
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">10</span>�� ");
                sb.Append("<a href='JavaScript:Having(0,0);' class=\"lan1\">��һҳ</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(0," + (n - 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(0," + i + ");'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(0," + (n + 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                sb.Append("<a href='JavaScript:Having(0," + (pageIndex - 1) + ");' class=\"lan1\">���ҳ</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(0);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
    }
}
