using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using System.Data;
using Tz888.DALFactory;
using System.Data.SqlClient;
using Tz888.DBUtility;
namespace Tz888.BLL.Professional
{
    public class ProfessionalviewBLL
    {
        ProfessionalviewIDAL viewIdal = DataAccess.CreateviewInfo();
        /// <summary>
        /// ����һ��רҵ��������
        /// </summary>
        /// <returns></returns>
        public bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link)
        {
            return viewIdal.InsertProFessionlView(mainInfo, viewInfo, link);
        }
        /// <summary>
        /// �޸�һ��רҵ��������
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionalview viewInfo, ProfessionalLink link)
        {
            return viewIdal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
        /// <summary>
        /// ���б�
        /// </summary>
        /// <param name="page"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string strService(string name, int statu, int n, string InfoType, string title)
        {
            StringBuilder sb = new StringBuilder();
            string str = string.Empty;
            string DisTitle = "";
            string sdt = "and 1=1";
            if (title != "")
            {
                sdt += " and Titel like '" + title + "%'";
            } if (InfoType != "All")
            {
                sdt += " and typeTID='" + InfoType + "'";
            }
            string sql = "select top 15 ProfessionalID,LoginName,Titel,typeTID,auditId,htmlUrl,createDate from ProfessionalinfoTab where "
            + " LoginName=@name and auditId<>4 and auditId=@auditId " + sdt + " and ProfessionalID not in "
            + "(select top " + 15 * n + " ProfessionalID from ProfessionalinfoTab where LoginName=@name  and auditId<>4 and auditId=@auditId " + sdt + ""
                 + " order by createDate desc) order by createDate desc";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50),
                 new SqlParameter("@auditId",SqlDbType.Int,4)
            };
            para[0].Value = name;
            para[1].Value = statu;
            DataSet ds = DbHelperSQL.Query(sql, para);

            #region ���ͨ��
            if (statu == 1)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:checkall();\">ȫѡ</a>��<a href=\"javascript:checknull();\">��ѡ</a></td>");
                sb.Append("<td width=\"8%\">���</td>");
                sb.Append("<td width=\"20%\">����</td>");
                sb.Append("<td width=\"12%\">����ʱ��</td>");
                sb.Append("<td width=\"18%\">����</td></tr></thead>");
                if ((ds != null) & (ds.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 15 ? 15 : ds.Tables[0].Rows.Count); i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        DateTime dt = Convert.ToDateTime(row["CreateDate"].ToString());
                        string ordertime = dt.ToString("yyyy-MM-dd");
                        DisTitle = row["Titel"].ToString(); //���� 
                        sb.Append("<tr><td><input id=\"cbxSelect\" name='" + row["ProfessionalID"].ToString() + "' type=\"checkbox\" value=\"" + row["ProfessionalID"].ToString() + "\" /></td>");
                        sb.Append("<td>" + GetType(row["typeTID"].ToString()) + "</td>");

                        sb.Append("<td><span class=\"lanl\"><a href='http://www.topfo.com/" + row["htmlUrl"].ToString() + "' target=\"_blank\" class=\"lan1\" title='" + DisTitle + "'>" + StrLength(DisTitle) + "</a></span></td>");

                        sb.Append("<td>" + ordertime + "</td><td>");
                       
                        //if (int.Parse(row["auditId"].ToString()) != 1)
                        //{
                            //sb.Append("<a href=\"ServiesManage.aspx?Servies='" + row["id"].ToString() + "'&Title='" + row["Titel"] + "'\" class=\"lan1\"> ����ƥ��</a> |");
                            sb.Append("<a href='javascript:DelNav(" + row["ProfessionalID"].ToString() + ");' onclick=\"return confirm('ȷ��Ҫɾ����')\" class=\"lan1\">ɾ��</a>|");
                        //}
                        sb.Append("<a  class=\"lan1\" href='javascript:modifyNavigate(" + row["ProfessionalID"].ToString() + "," + row["typeTID"].ToString() + "); '\">�޸�</a> ");
                        if (int.Parse(row["auditId"].ToString()) == 1)
                        {
                            sb.Append("|<a href='http://www.topfo.com/" + row["htmlUrl"].ToString() + "' class=\"lan1\">�鿴</a> ");
                        }
                        sb.Append("</td></tr>");
                    }
                    sb.Append("</table>");
                }
            }
            #endregion
            #region �����
            if (statu == 0)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:checkall();\">ȫѡ</a>��<a href=\"javascript:checknull();\">��ѡ</a></td>");
                sb.Append("<td width=\"8%\">���</td>");
                sb.Append("<td width=\"20%\">����</td>");
                sb.Append("<td width=\"12%\">����ʱ��</td>");
                sb.Append("<td width=\"18%\">����</td></tr></thead>");
                if ((ds != null) & (ds.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 15 ? 15 : ds.Tables[0].Rows.Count); i++)
                    {
                       
                        DataRow row = ds.Tables[0].Rows[i];
                        DisTitle = row["Titel"].ToString(); //���� 
                        DateTime dt = Convert.ToDateTime(row["CreateDate"].ToString());
                        string ordertime = dt.ToString("yyyy-MM-dd");
                        sb.Append("<tr><td><input id=\"cbxSelect\" name='" + row["ProfessionalID"].ToString() + "' type=\"checkbox\" value=\"" + row["ProfessionalID"].ToString() + "\" /></td>");
                        sb.Append("<td>" + GetType(row["typeTID"].ToString()) + "</td>");

                        sb.Append("<td><span class=\"lanl\"><a href='http://www.topfo.com/" + row["htmlUrl"].ToString() + "' target=\"_blank\" class=\"lan1\" title='" + DisTitle + "'>" + StrLength(DisTitle) + "</a></span></td>");

                        sb.Append("<td>" + ordertime + "</td><td>");
                        //if (int.Parse(row["auditId"].ToString()) != 1)
                        //{
                            sb.Append("<a href='javascript:DelNav(" + row["ProfessionalID"].ToString() + ");' onclick=\"return confirm('ȷ��Ҫɾ����')\" class=\"lan1\">ɾ��</a>|");
                        //}
                        sb.Append("<a  class=\"lan1\" href='javascript:modifyNavigate(" + row["ProfessionalID"].ToString() + "," + row["typeTID"].ToString() + " );'\">�޸�</a> ");
                        if (int.Parse(row["auditId"].ToString()) == 1)
                        {
                            sb.Append("|<a href='http://www.topfo.com/" + row["htmlUrl"].ToString() + "' class=\"lan1\">�鿴</a> ");
                        }
                        sb.Append("</td></tr>");
                    }
                    sb.Append("</table>");
                }
            }
            #endregion
            #region ���δͨ��
            if (statu == 2)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:checkall();\">ȫѡ</a>��<a href=\"javascript:checknull();\">��ѡ</a></td>");
                sb.Append("<td width=\"8%\">���</td>");
                sb.Append("<td width=\"20%\">����</td>");
                sb.Append("<td width=\"12%\">����ʱ��</td>");
                sb.Append("<td width=\"18%\">����</td></tr></thead>");
                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 15 ? 15 : ds.Tables[0].Rows.Count); i++)
                    {
                       
                        DataRow row = ds.Tables[0].Rows[i];
                        DisTitle = row["Titel"].ToString(); //���� 
                        DateTime dt = Convert.ToDateTime(row["CreateDate"].ToString());
                        string ordertime = dt.ToString("yyyy-MM-dd");
                        sb.Append("<tr><td><input id=\"cbxSelect\" name='" + row["ProfessionalID"].ToString() + "' type=\"checkbox\" value=\"" + row["ProfessionalID"].ToString() + "\" /></td>");
                        sb.Append("<td>" + GetType(row["typeTID"].ToString()) + "</td>");

                        sb.Append("<td><span class=\"lanl\"><a href='http://www.topfo.com/" + row["htmlUrl"].ToString() + "' target=\"_blank\" class=\"lan1\" title='" + DisTitle + "'>" + StrLength(DisTitle) + "</a></span></td>");

                        sb.Append("<td>" + ordertime + "</td><td>");
                        //if (int.Parse(row["auditId"].ToString()) != 1)
                        //{DelNav(" + loansinfoIds + ");'
                            sb.Append("<a href='javascript:DelNav(" + row["ProfessionalID"].ToString() + ");' onclick=\"return confirm('ȷ��Ҫɾ����')\" class=\"lan1\">ɾ��</a>|");
                        //}
                        sb.Append("<a  class=\"lan1\" href='javascript:modifyNavigate(" + row["ProfessionalID"].ToString() + "," + row["typeTID"].ToString() + ");'\" >�޸�</a> ");
                        if (int.Parse(row["auditId"].ToString()) == 1)
                        {
                            sb.Append("|<a href='http://www.topfo.com/" + row["htmlUrl"].ToString() + "' class=\"lan1\">�鿴</a> ");
                        }
                        sb.Append("</td></tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return sb.ToString();
            #endregion

        }
        //��ȡ�ַ�������
        public string StrLength(string title)
        {
            if (title.Length > 14)
            {
                title = title.Substring(0, 14) + "..";
            }
            return title;
        }
        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statu"></param>
        /// <returns></returns>
        public int pageIndex(string name, int statu, string InfoType, string title)
        {
            int pageCount = 0;
            string sdt = "and 1=1";
            if (title != "")
            {
                sdt += " and Titel like '" + title + "%'";
            } if (InfoType != "All")
            {
                sdt += " and typeTID='" + InfoType + "'";
            }

            string sql = "select count(ProfessionalID) from (select ProfessionalID from ProfessionalinfoTab where LoginName=@name and auditId<>4 and auditId=@statu  " + sdt + " group by ProfessionalID) as c";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@statu",SqlDbType.Int,4)
            };
            para[0].Value = name;
            para[1].Value = statu;
            pageCount = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return pageCount;
        }
        /// <summary>
        /// ��ѯ���ж���ҳ
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public int pageS(string name, int statu, string InfoType, string title)
        {
            int pagecc = 0;
            int page = pageIndex(name, statu, InfoType, title);
            pagecc = page >= 15 ? (page % 15 == 0 ? page / 15 : page / 15 + 1) : 1;
            return pagecc;
        }
        /// <summary>
        /// �󶨷�ҳ
        /// </summary>
        /// <param name="name">�û���</param>
        /// <param name="n">ҳ����</param>
        /// <param name="type"> 1 ���� 2������3�˲�</param>
        /// <returns></returns>
        public string PageRecIndex(string name, int statu, int n, string InfoType, string title)
        {
            StringBuilder sb = new StringBuilder();
            int pageI = pageIndex(name, statu, InfoType, title);
            int pagec = pageS(name, statu, InfoType, title);
            if (pageI != 0)
            {
                //sb.Append("<a href=\"javascript:checkall()\" class=\"Aorange02\">ȫѡ</a>&nbsp;|&nbsp;");
                //sb.Append("<a href=\"javascript:checknull()\" class=\"Ablue02\">��ѡ</a>&nbsp;|&nbsp;");
                //sb.Append("<a class=\"btn\" href=\"javascript:deleteAlloK()\">ɾ��</a>");
                sb.Append("��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pagec + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">15</span>�� ");
                sb.Append("<a href='JavaScript:Having(" + statu + ",0);' class=\"lan1\">��һҳ</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + statu + ");' class=\"lan1\">��һҳ</a>");
                }
                for (int i = (n / 5 * 4); i < (pagec >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pagec); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(" + statu + "," + i + ");'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pagec)
                {
                    sb.Append("<a href='JavaScript:Having(" + statu + "," + (n + 1) + " );' class=\"lan1\">��һҳ</a>");
                }
                sb.Append("<a href='JavaScript:Having(" + statu + "," + (pagec - 1) + ");' class=\"lan1\">���ҳ</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(" + statu + ");\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
        protected string GetType(string typeid)
        {
            string auditStr = "";
            switch (int.Parse(typeid.ToString()))
            {
                case 1:
                    auditStr = "רҵ����";
                    break;
                case 2:
                    auditStr = "רҵ����";
                    break;
                case 3:
                    auditStr = "רҵ�˲�";
                    break;

            }
            return auditStr;
        }
        protected string getState(string audit)
        {
            string auditStr = "";
            switch (int.Parse(audit.ToString()))
            {
                case 0:
                    auditStr = "δ���";
                    break;
                case 1:
                    auditStr = "���ͨ��";
                    break;
                case 2:
                    auditStr = "���δͨ��";
                    break;

            }
            return auditStr;
        }
    }
}
