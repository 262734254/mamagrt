using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class MemberIndex 
    {
        //��ѯ��Ա��Ϣ
        public string SelMemberNews(string name)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select a.MemberID,a.LoginName,a.Mobile,a.Email,b.MemberGradeID,b.RegisterTime,b.ManageTypeID"
                + " from MemberInfoTab as a inner join LoginInfoTab as b on a.LoginName=b.LoginName where a.LoginName=@name";
            SqlParameter[] para ={ 
                 new SqlParameter("@name",SqlDbType.VarChar,100)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                string MemberID = ds.Tables[0].Rows[0]["MemberID"].ToString().Trim();//��Ա��� 0
                string LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString().Trim();//��Ա���� 1
                string Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString().Trim();//��Ա�ֻ� 2
                string Email = ds.Tables[0].Rows[0]["Email"].ToString().Trim();//��Ա���� 3
                string Member = ds.Tables[0].Rows[0]["MemberGradeID"].ToString().Trim();//��Ա�� 4
                string time = ds.Tables[0].Rows[0]["RegisterTime"].ToString().Trim();//ע��ʱ�� 5
                string Manage = ds.Tables[0].Rows[0]["ManageTypeID"].ToString().Trim();//��Ա���� 6
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(time);
                sb.Append("" + MemberID + "&" + LoginName + "&" + Mobile + "&" + Email + "&" + SelGradeID(Member)+ "&"+dt.ToString("yyyy-MM-dd HH:mm")+"&"+selManageID(Manage)+"");
            }
            return sb.ToString();
        }
        //�ҵ���Ŀ
        public string SelItem(string name)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 InfoID,publishT,InfoTypeID, Title,HtmlFile,AuditingStatus from MainInfoTab where LoginName=@name order by publishT desc";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);

            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.Append("<thead><tr><td>����</td><td>����</td><td>����ʱ��</td><td>״̬</td><td>ƥ��</td></tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 6 ? 6 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string status = Convert.ToString(row["AuditingStatus"].ToString().Trim());
                    string type=row["InfoTypeID"].ToString().Trim();
                    DateTime dt = Convert.ToDateTime(row["publishT"].ToString());
                    string begtime = dt.ToString("yyyy-MM-dd");
                    sb.Append("<tr><td class=\"f_cen\">" + SelInfoType(type) + "</td>");
                    if (status == "1")
                    {
                        if (type == "News" || type == "Cases")
                        {
                            sb.Append("<td><a target=\"_blank\" class='lan1' href='http://news.topfo.com/" + row["HtmlFile"] + "'title='" + row["Title"].ToString().Trim() + "'>" + StrLength(row["Title"].ToString().Trim()) + "</a></td>");
                        }
                        else
                        {
                            sb.Append("<td><a target=\"_blank\" class='lan1' href='http://www.topfo.com/" + row["HtmlFile"] + "' title='" + row["Title"].ToString().Trim() + "'>" + StrLength(row["Title"].ToString().Trim()) + "</a></td>");
                        }
                    }
                    else
                    {
                        sb.Append("<td>" +StrLength(row["Title"].ToString().Trim()) + "</td>");
                    }
                    sb.Append("<td>" + begtime + "</td>");
                    sb.Append("<td>" + Statue(status)+ "</td>");
                    sb.Append("<td><a href='Manage/PertinentLink.aspx?id=" + row["InfoID"].ToString().Trim() + "&type=" + type + "' class='lan1'>ƥ��</a></td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        public  string Statue(string id)
        {
            string name = "";
            if (id != "")
            {
                switch (id)
                {
                    case "0":
                        name = "δ���";
                        break;
                    case "1":
                        name = "���ͨ��";
                        break;
                    case "2":
                        name = "���δͨ��";
                        break;
                    case "3":
                        name = "�ѹ���";
                        break;
                }
            }
            return name;
        }
        //����δ������
        public int SelInnerInfo(string name)
        {
            int num = 0;
            string sql = "select count(ReceivedID) from InnerInfoReceivedTab where IsReaded=0 and ReceivedName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return num;

        }
        //��ѯ��Ա��Ӧ�ļ���
        public string selManageID(string TypeID)
        {
            string TypeName = "";
            if (TypeID != "")
            {
                string sql = "select ManageTypeName from SetManageTypeTab where ManageTypeID=@TypeID";
                SqlParameter[] para ={ 
                   new SqlParameter("@TypeID",SqlDbType.VarChar,100)
                };
                para[0].Value = TypeID;
                TypeName = Convert.ToString(DbHelperSQL.GetSingle(sql,para).ToString());
            }
            return TypeName;
        }
        //��ѯ������Ա
        public string SelGradeID(string GradeID)
        {
            string GradeName = "";
            if (GradeID != "")
            {
                string sql = "select MemberGradeName from SetMemberGradeTab where MemberGradeID=@GradeID";
                SqlParameter[] para ={ 
                new SqlParameter("@GradeID",SqlDbType.VarChar,20)
                };
                para[0].Value = GradeID;
                GradeName = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            }
            return GradeName;
        }
        //���һ���
        public int SelJiFen(string name)
        {
            int jifen = 0;
            string sql = "select IntegralCount from CreateCardTab where LoginName=@name";
            SqlParameter[] para ={
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            jifen = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para).ToString());
            return jifen;
        }
        //��������Ӧ�����
        public string SelInfoType(string TypeID)
        {
            string name = "";
            if (TypeID != "")
            {
                string sql = "select InfoTypeName from SetInfoTypeTab where InfoTypeID=@TypeID";
                SqlParameter[] para ={ 
                   new SqlParameter("@TypeID",SqlDbType.VarChar,20)
                };
                para[0].Value = TypeID;
                name = Convert.ToString(DbHelperSQL.GetSingle(sql,para).ToString());
            }
            return name;
        }
        //����������Ŀ
        public string SelLatest()
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 6 Title,HtmlFile,InfoTypeID,LoginName,publishT from MainInfoTab order by PublishT desc";
            DataSet ds = DbHelperSQL.Query(sql);
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            sb.Append("<thead><tr><td>����</td><td>����</td><td>����ʱ��</td><td>������</td></tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 6 ? 6 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    string type = row["InfoTypeID"].ToString().Trim();
                    DateTime dt = Convert.ToDateTime(row["publishT"].ToString());
                    string begtime = dt.ToString("yyyy-MM-dd");
                    sb.Append("<tr><td class=\"f_cen\">" + SelInfoType(type) + "</td>");
                    
                    if (type == "News" || type == "Cases")
                    {
                        sb.Append("<td><a target=\"_blank\" class='lan1' href='http://news.topfo.com/" + row["HtmlFile"] + "'title='" + row["Title"].ToString().Trim() + "'>" + StrLength(row["Title"].ToString().Trim()) + "</a></td>");
                    }
                    else
                    {
                        sb.Append("<td><a target=\"_blank\" class='lan1' href='http://www.topfo.com/" + row["HtmlFile"] + "' title='" + row["Title"].ToString().Trim() + "'>" + StrLength(row["Title"].ToString().Trim()) + "</a></td>");
                    }
                    
                    sb.Append("<td>" + begtime + "</td>");
                    sb.Append("<td>" + row["LoginName"].ToString().Trim() + "</td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        //��ȡ�ַ�������
        public  string StrLength(string title)
        {
            if (title.Length > 8)
            {
                title = title.Substring(0, 8) + "..";
            }
            return title;
        }

        #region ����б������
        /// <summary>
        /// ��ѯ��Ա����
        /// </summary>
        /// <param name="name">��¼��</param>
        /// <param name="statu">���״̬</param>
        /// <param name="n">��ǰҳ����</param>
        /// <returns></returns>
        public string AjaxStatus(string name,int statu,int n,string InfoType,string title)
        {
            //''+@Industry+'%'
            string infoId = "";//��� 
            string Title = "";//���� 
            string publishT = "";// ��ʼʱ�� 
            string infoType = "";// ��Ӧ���
            string LoginName = "";// �û��� 
            string auditing = "";//���״̬ 
            string html = "";// html
            string over = "";// ����ʱ�� 
            int CaverOut = 0;//���ִ�ҵ����
            StringBuilder sb = new StringBuilder();
            string sdt = "and 1=1";
            if (title != "")
            {
                sdt += " and Title like '" + title + "%'";
            } if ( InfoType!="All")
            {
                sdt += " and InfoTypeID='" + InfoType + "'";
            }
            string sql = "select top 20 InfoID,Title,publishT,InfoTypeID,LoginName,AuditingStatus,HtmlFile,"
                +"case when ValidateTerm = 0 then NULL else DATEADD(Month, ValidateTerm, ValidateStartTime) END AS InfoOverdueTime "
                + " from MainInfoTab where LoginName=@name and AuditingStatus=@statu "+sdt+"  and DelStatus<>1 and InfoTypeID in ('Merchant','Project','Capital','CarveOut','Oppor') and "
                + " InfoID not in(select top "+20*n+" InfoID from MainInfoTab where LoginName=@name "+sdt+"  and AuditingStatus=@statu and "
                + " DelStatus<>1 and InfoTypeID in ('Merchant','Project','Capital','CarveOut','Oppor') order by InfoID desc) order by InfoID desc";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@statu",SqlDbType.Int,4)
            };
            para[0].Value = name;
            para[1].Value = statu;
            DataSet ds = DbHelperSQL.Query(sql,para);

            #region ���ͨ��
            if (statu == 1)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:SelectAll();\">ȫѡ</a>��<a href=\"javascript:ReSelect();\">��ѡ</a></td>");
                 sb.Append("<td width=\"8%\">���</td>");
                 sb.Append("<td width=\"20%\">����</td>");
                 sb.Append("<td width=\"12%\">����ʱ��</td>");
                 sb.Append("<td width=\"27%\">�������</td>");
                 sb.Append("<td width=\"18%\">����</td></tr></thead>");
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 20 ? 20 : ds.Tables[0].Rows.Count); i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        infoId = row["InfoID"].ToString();//��� 
                        Title = row["Title"].ToString(); //���� 
                        publishT = row["publishT"].ToString();// ��ʼʱ�� 
                        infoType = row["InfoTypeID"].ToString().Trim();// ��Ӧ��� 
                        LoginName = row["LoginName"].ToString();// �û��� 
                        auditing = row["AuditingStatus"].ToString();//���״̬ 
                        html = row["HtmlFile"].ToString();// html 
                      // over = row["InfoOverdueTime"].ToString();// ����ʱ�� 
                        DateTime beg = Convert.ToDateTime(publishT);
                        string begTime = beg.ToString("yyyy-MM-dd");
                        sb.Append("<tr><td><input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\""+infoId+"\" /></td>");
                        sb.Append("<td>"+SelInfoType(infoType)+"</td>");
                        if (infoType == "News" || infoType == "Cases")
                        {
                            sb.Append("<td><span class=\"lanl\"><a href='http://news.topfo.com/"+html+"' target=\"_blank\" class=\"lan1\" title='" + Title + "'>" + StrLength(Title) + "</a></span></td>");
                        }
                        else
                        {
                            sb.Append("<td><span class=\"lanl\"><a href='http://www.topfo.com/"+html+"' target=\"_blank\" class=\"lan1\" title='" + Title + "'>" + StrLength(Title) + "</a></span></td>");
                        }
                        sb.Append("<td>"+begTime+"</td>");
                        sb.Append("<td><a href=\"../helper/Promotionset.aspx?InfoID="+infoId+"&type="+infoType+"\" class=\"lan1\">�����ƹ�</a> ");
                        sb.Append("<a href=\"PertinentLink.aspx?InfoID=" + infoId + "&type=" + infoType + "\" class=\"lan1\">����ƥ��</a> ");
                        sb.Append("<a href=\"../Access/Access.aspx?InfoID="+infoId+"\" class=\"lan1\">��ע</a></td>");
                        if (infoType == "News" || infoType == "Cases")
                        {
                            sb.Append("<td><a href='http://news.topfo.com/" + html + "' class=\"lan1\">�鿴</a> ");
                        }
                        else
                        {
                            sb.Append("<td><a href='http://www.topfo.com/" + html + "' class=\"lan1\">�鿴</a> ");
                        }
                        sb.Append("<a href='javascript:Modify();' class=\"lan1\">�޸�</a> ");
                        //sb.Append("<a href='javascript:DelNav(" + infoId + ");' onclick='javascript:Del()' class=\"lan1\">ɾ��</a></td></tr>");
                        //onclick='if(confirm('ȷ��Ҫɾ����')){ return   true;}else{return   false;} '
                    }
                }
                sb.Append("</table>");
            }
            #endregion

            #region �����
            if (statu == 0)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:SelectAll();\">ȫѡ</a>��<a href=\"javascript:ReSelect();\">��ѡ</a></td>");
                sb.Append("<td width=\"8%\">���</td>");
                sb.Append("<td width=\"20%\">����</td>");
                sb.Append("<td width=\"12%\">����ʱ��</td>");
                sb.Append("<td width=\"18%\">����</td></tr></thead>");
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 20 ? 20 : ds.Tables[0].Rows.Count); i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        infoId = row["InfoID"].ToString();//��� 
                        Title = row["Title"].ToString(); //���� 
                        publishT = row["publishT"].ToString();// ��ʼʱ�� 
                        infoType = row["InfoTypeID"].ToString().Trim();// ��Ӧ��� 
                        LoginName = row["LoginName"].ToString();// �û��� 
                        auditing = row["AuditingStatus"].ToString();//���״̬ 
                        html = row["HtmlFile"].ToString();// html 
                        // over = row["InfoOverdueTime"].ToString();// ����ʱ�� 
                        DateTime beg = Convert.ToDateTime(publishT);
                        string begTime = beg.ToString("yyyy-MM-dd");
                        CaverOut = SelCarveOut(infoId);
                        sb.Append("<tr><td><input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\"" + infoId + "\" /></td>");
                        sb.Append("<td>" + SelInfoType(infoType) + "</td>");
                        sb.Append("<td><span class=\"lanl\"><a href='#' class=\"lan1\" title='" + Title + "'>" + StrLength(Title) + "</a></span></td>");
                        sb.Append("<td>" + begTime + "</td>");
                        sb.Append("<td><a href=\"PertinentLink.aspx?InfoID=" + infoId + "&type=" + infoType + "\" class=\"lan1\">ƥ��</a> ");
                        if (infoType == "CarveOut")
                        {
                            sb.Append("<a href='/Publish/ModifyCarveOut.aspx?id=" + infoId + "&type=" + CaverOut + "' class=\"lan1\">�޸�</a></td></tr> ");
                        }
                        else
                        {
                            sb.Append("<a href=\"javascript:modifyNavigate(" + infoId + ",'" + infoType + "');\" class=\"lan1\">�޸�</a></td></tr> ");
                        }
                    }
                }
                sb.Append("</table>");
            }
            #endregion

            #region ���δͨ��
            if (statu == 2)
            { 
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:SelectAll();\">ȫѡ</a>��<a href=\"javascript:ReSelect();\">��ѡ</a></td>");
                sb.Append("<td width=\"8%\">���</td>");
                sb.Append("<td width=\"20%\">����</td>");
                sb.Append("<td width=\"12%\">����ʱ��</td>");
                sb.Append("<td width=\"12%\">δͨ��ԭ��</td>");
                sb.Append("<td width=\"18%\">״̬</td></tr></thead>");
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 20 ? 20 : ds.Tables[0].Rows.Count); i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        infoId = row["InfoID"].ToString();//��� 
                        Title = row["Title"].ToString(); //���� 
                        publishT = row["publishT"].ToString();// ��ʼʱ�� 
                        infoType = row["InfoTypeID"].ToString().Trim();// ��Ӧ��� 
                        LoginName = row["LoginName"].ToString();// �û��� 
                        auditing = row["AuditingStatus"].ToString();//���״̬ 
                        html = row["HtmlFile"].ToString();// html 
                        // over = row["InfoOverdueTime"].ToString();// ����ʱ�� 
                        DateTime beg = Convert.ToDateTime(publishT);
                        string begTime = beg.ToString("yyyy-MM-dd");
                        CaverOut = SelCarveOut(infoId);
                        sb.Append("<tr><td><input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\"" + infoId + "\" /></td>");
                        sb.Append("<td>" + SelInfoType(infoType) + "</td>");
                        sb.Append("<td><span class=\"lanl\"><a href=\"#\" class=\"lan1\" title='"+Title+"'>" + StrLength(Title) + "</a></span></td>");
                        sb.Append("<td>" + begTime + "</td>");
                         sb.Append("<td>--</td>");
                         if (infoType == "CarveOut")
                         {
                             sb.Append("<td><a href='/Publish/ModifyCarveOut.aspx?id=" + infoId + "&type=" + CaverOut + "' class=\"lan1\">�޸�</a></td></tr> ");
                         }
                         else
                         {
                             sb.Append("<td><a href=\"javascript:modifyNavigate(" + infoId + ",'" + infoType + "');\" class=\"lan1\">�޸�</a></td></tr> ");
                         }
                    }
                }
                sb.Append("</table>");
            }
            #endregion

            #region �ѹ���
            if (statu == 3)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:SelectAll();\">ȫѡ</a>��<a href=\"javascript:ReSelect();\">��ѡ</a></td>");
                sb.Append("<td width=\"8%\">���</td>");
                sb.Append("<td width=\"20%\">����</td>");
                sb.Append("<td width=\"12%\">����ʱ��</td>");
                sb.Append("<td width=\"18%\">�޸�</td></tr></thead>");
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 20 ? 20 : ds.Tables[0].Rows.Count); i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        infoId = row["InfoID"].ToString();//��� 
                        Title = row["Title"].ToString(); //���� 
                        publishT = row["publishT"].ToString();// ��ʼʱ�� 
                        infoType = row["InfoTypeID"].ToString().Trim();// ��Ӧ��� 
                        LoginName = row["LoginName"].ToString();// �û��� 
                        auditing = row["AuditingStatus"].ToString();//���״̬ 
                        html = row["HtmlFile"].ToString();// html 
                         over = row["InfoOverdueTime"].ToString();// ����ʱ�� 
                         DateTime beg = Convert.ToDateTime(over);
                        string begTime = beg.ToString("yyyy-MM-dd");
                        sb.Append("<tr><td><input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\"" + infoId + "\" /></td>");
                        sb.Append("<td>" + SelInfoType(infoType) + "</td>");
                        sb.Append("<td><span class=\"lanl\"><a href=\"#\" class=\"lan1\" title='"+Title+"'>" + StrLength(Title) + "</a></span></td>");
                        sb.Append("<td>" + begTime + "</td>");
                        sb.Append("<td><a href='./ExtensionOperation.aspx?id="+infoId+"'>��Ч��</a></td></tr> ");
                    }
                }
                sb.Append("</table>");
            }
            #endregion
            return sb.ToString();
        }
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public int SelDelMain(string InfoID)
        {
            int num=0;
            string sql = "UPDATE MainInfoTab set DelStatus = 1 where InfoID = @InfoID ";
            SqlParameter[] para ={ 
                new SqlParameter("@InfoID",SqlDbType.VarChar,2000)
            };
            para[0].Value = InfoID;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return num;
        }
        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statu"></param>
        /// <returns></returns>
        public int pageIndex(string name, int statu, string InfoType, string title)
        {
            int num = 0;
            string sdt = "and 1=1";
            if (title != "")
            {
                sdt += " and Title like '" + title + "%'";
            } if (InfoType != "All")
            {
                sdt += " and InfoTypeID='" + InfoType + "'";
            }
            string sql="select count(InfoID)  from (select InfoID from MainInfoTab where  LoginName=@name and "
                + "DelStatus<>1 and AuditingStatus=@statu "+sdt+"  and InfoTypeID in ('Merchant','Project','Capital','CarveOut','Oppor') group by InfoID) as c";
            SqlParameter[] para ={ 
                 new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@statu",SqlDbType.Int,4)
            };
            para[0].Value = name;
            para[1].Value = statu;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return num;
        }
        /// <summary>
        /// ��ѯ���ж���ҳ
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public int pageS(string name, int statu, string InfoType, string title)
        {
            int pagecc = 0;
            int page = pageIndex(name,statu,InfoType,title);
            pagecc = page >= 20 ? (page % 20 == 0 ? page / 20 : page / 20 + 1) : 1;
            return pagecc;
        }
        /// <summary>
        /// ��ҳ��ʾ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statu"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string pageCont(string name, int statu, int n, string InfoType, string title)
        {
            StringBuilder sb = new StringBuilder();
            int pageI = pageIndex(name, statu,InfoType,title);
            int pagec = pageS(name, statu,InfoType,title);
            if (pageI != 0)
            {
                sb.Append("��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pagec + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">20</span>�� ");
                sb.Append("<a href='JavaScript:Having(" + statu + ",0," + statu + ");' class=\"lan1\">��һҳ</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + statu + "," + (n - 1) + "," + statu + ");' class=\"lan1\">��һҳ</a>");
                }
                for (int i = (n / 5 * 4); i < (pagec >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pagec); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(" + statu + "," + i + "," + statu + ");'>" + (i + 1) + "</a>");
                }
                if ((n+1) != pagec)
                {
                    sb.Append("<a href='JavaScript:Having(" + statu + "," + (n + 1) + "," + statu + ");' class=\"lan1\">��һҳ</a>");
                }
                sb.Append("<a href='JavaScript:Having(" + statu + "," + (pagec-1) + "," + statu + ");' class=\"lan1\">���ҳ</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(" + statu + ");\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
        /// <summary>
        /// ���Ҵ�ҵ����
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public int SelCarveOut(string InfoID)
        {
            int num = 0;
            string sql = "select b.CarveOutInfoType from MainInfoTab as a inner join CarveOutInfoTab as b on a.InfoID=b.InfoID "
                + "where a.InfoID=@InfoID";
            SqlParameter[] para ={ 
                new SqlParameter("@InfoID",SqlDbType.VarChar,20)
            };
            para[0].Value = InfoID;
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            return num;

        }

        #endregion

    }
}
