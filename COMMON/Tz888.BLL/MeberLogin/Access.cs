using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class Access
    {
        MemberIndex member = new MemberIndex();
        #region ������Ϣ
        CrmDBHelper crm = new CrmDBHelper();
        /// <summary>
        /// ��ӷ�������Ϣ
        /// </summary>
        /// <param name="InfoID">��Ŀ����Ӧ��InfoID</param>
        /// <param name="Name">������</param>
        /// <param name="Time">����ʱ��</param>
        /// <param name="Ip">����IP</param>
        /// <param name="Proince">����������ʡ��</param>
        /// <returns></returns>
        public int AccessInsert(string InfoID, string Name, string Time, string Ip, string Proince)
        {
            string sql = "insert into AccessInfoTab(InfoID,AccessName,AccessTime,AccessIP,ProinceID) values "
                +"(@InfoID,@Name,@Time,@Ip,@Proince)";
            SqlParameter[] para ={ 
                new SqlParameter("@InfoID",SqlDbType.VarChar,20),
                new SqlParameter("@Name",SqlDbType.VarChar,50),
                new SqlParameter("@Time",SqlDbType.VarChar,50),
                new SqlParameter("@Ip",SqlDbType.VarChar,50),
                new SqlParameter("@Proince",SqlDbType.VarChar,50)
            };
            para[0].Value =InfoID;
            para[1].Value = Name;
            para[2].Value = Time;
            para[3].Value = Ip;
            para[4].Value = Proince;
            int count =Convert.ToInt32(crm.GetSingle(sql, para));
            return count;
        }
        /// <summary>
        /// ��������Ӧ��InfoID���ҷ�����Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string SelAccess(string InfoID, int n)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 10 AccessName,AccessTime,AccessIP,ProinceID from AccessInfoTab where InfoID=@InfoID and "
                + "AccessID not in(select top " + 10 * n + " AccessID from AccessInfoTab where InfoID=@InfoID order by AccessID desc )"
                +" order by AccessID desc";
            SqlParameter[] para ={ 
               new SqlParameter("@InfoID",SqlDbType.VarChar,50)
            };
            para[0].Value = InfoID;
            DataSet ds = crm.Query(sql,para);
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
            sb.Append("<td width=\"17%\">������</td>");
            sb.Append("<td width=\"21%\">����ʱ��</td>");
            sb.Append("<td width=\"19%\">����ӦIP</td>");
            sb.Append("<td width=\"17%\">���ڵ�ʡ</td>");
            sb.Append("<td width=\"14%\">�鿴</td>");
            sb.Append("</tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<tr>");
                    if (row["AccessName"].ToString() == "�ο�")
                    {
                        sb.Append("<td><span class='lan1'>" + row["AccessName"].ToString() + "</span></td>");
                    }
                    else
                    {
                        sb.Append("<td><a href=\"SelAccessName.aspx?AccessName=" + row["AccessName"].ToString() + "\" class=\"lan1\">" + row["AccessName"].ToString() + "</a></td>");
                    }
                    sb.Append("<td>"+row["AccessTime"].ToString()+"</td>");
                    sb.Append("<td>"+row["AccessIP"]+"</td>");
                    sb.Append("<td>" + row["ProinceID"].ToString() + "</td>");
                    if (row["AccessName"].ToString() == "�ο�")
                    {
                        sb.Append("<td><span class='lan1'>��Ϣ������</span></td>");
                    }
                    else
                    {
                        sb.Append("<td><a href=\"SelAccessName.aspx?AccessName=" + row["AccessName"].ToString() + "\" class=\"lan1\">�鿴��Ϣ</a></td>");
                    } 
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// ���ҷ�����������
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public int CountAccess(string InfoID)
        {
            int num=0;
            string sql = "select count(AccessID) from (select AccessID from AccessInfoTab where InfoID=@InfoID) as a";
            SqlParameter[] para ={ 
               new SqlParameter("@InfoID",SqlDbType.VarChar,50)
            };
            para[0].Value = InfoID;
            num = Convert.ToInt32(crm.GetSingle(sql, para));
            return num;
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string IndexAccess(string InfoID, int n)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = CountAccess(InfoID);
            int pageIndex = 0;//�ܹ����ٸ�ҳ����
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("������<span class='hong'>" + pageCount + "</span>,��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>ҳ,");
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
        #endregion

        #region �ҷ�������Ŀ
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string SelMainLoginName(string name, int n, string InfoType)
        {
            StringBuilder sb = new StringBuilder();
            string num = " and 1=1 ";
            if (InfoType != "all")
            {
                num += " and InfoTypeID='"+InfoType+"' ";
            }
            string sql = "select top 10 InfoID,Title,PublishT ,Hit,InfoTypeID,AuditingStatus from MainInfoTab where AuditingStatus=1 and"
                + " LoginName=@name " + num + " and InfoID not in(select top " + 10 * n + " InfoID from MainInfoTab where AuditingStatus=1 and LoginName=@name " + num + " order by InfoID desc) order by InfoID desc";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
            sb.Append("<td width=\"14%\">���</td>");
            sb.Append("<td width=\"30%\">��Դ����</td>");
            sb.Append("<td width=\"12%\">������</td>");
            sb.Append("<td width=\"18%\">����ʱ��</td>");
            sb.Append("<td width=\"14%\">״̬</td>");
            sb.Append("<td width=\"12%\">����</td>");
            sb.Append("</tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    DateTime dt = Convert.ToDateTime(row["PublishT"].ToString());
                    string time = dt.ToString("yyyy-MM-dd");
                    sb.Append("<tr><td>"+member.SelInfoType(row["InfoTypeID"].ToString().Trim())+"</td>");
                    sb.Append("<td><span class=\"lanl\" >"+row["Title"].ToString()+"</span></td>");
                    sb.Append("<td>"+row["Hit"].ToString()+"</td>");
                    sb.Append("<td>"+time+"</td>");
                    sb.Append("<td><span class=\"lanl\">" + member.Statue(row["AuditingStatus"].ToString().Trim()) + "</span></td>");
                    sb.Append("<td><span class=\"lanl\">");
                    if (row["AuditingStatus"].ToString() == "1")
                    {
                        sb.Append("<a href='Access.aspx?InfoID=" + row["InfoID"] + "' class=\"lan1\" >������</a>");
                    }
                    else
                    {
                        sb.Append("--");
                    }
                    sb.Append("</span></td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IndexCount(string name, string InfoType)
        {
            int num=0;
            string com = " and 1=1 ";
            if (InfoType != "all")
            {
                com += " and InfoTypeID='" + InfoType + "' ";
            }
            string sql = "select count(InfoID) from (select InfoID from MainInfoTab where AuditingStatus=1 and LoginName=@name " + com + " ) as a";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num =Convert.ToInt32(DbHelperSQL.GetSingle(sql,para));
            return num;
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string SelPageIndex(string name, int n,string InfoType)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = IndexCount(name,InfoType);
            int pageIndex = 0;//�ܹ����ٸ�ҳ����
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("������<span class='hong'>" + pageCount + "</span>,��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>ҳ,");
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
        #endregion

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="id"></param>
        public int ModfiyHit(string InfoID)
        {
            int num = 0;
            string sql = "select Hit from MainInfoTab where InfoID=@InfoID";
            SqlParameter[] para ={ 
               new SqlParameter("@InfoID",SqlDbType.VarChar,20)
            };
            para[0].Value = InfoID;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para).ToString());
            int Hit = num + 1;
            string sqll = "update MainInfoTab set Hit=@Hit where InfoID=@InfoID";
            SqlParameter[] sqlpara ={ 
                 new SqlParameter("@Hit",SqlDbType.Int,8),
                new SqlParameter("@InfoID",SqlDbType.VarChar,20)
            };
            sqlpara[0].Value = Hit;
            sqlpara[1].Value = InfoID;
            int com = Convert.ToInt32(DbHelperSQL.GetSingle(sqll, sqlpara));
            return Hit;
        }
    }
}
