using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Tz888.DBUtility;
using System.Data;

namespace Tz888.BLL.news
{
    public class NewsTabBLL
    {
        Tz888.SQLServerDAL.news.NewsTabDAL newstabdal = new Tz888.SQLServerDAL.news.NewsTabDAL();
        public int InsertNewsTab(Tz888.Model.NewsTab newstab, Tz888.Model.NewsTypeTab newstypetab, Tz888.Model.NewsViewTab newsviewtab)
        {
            return newstabdal.InsertNewsTab(newstab,newstypetab ,newsviewtab);
        }
        public Tz888.Model.NewsTab GetNewsTabByNewId(int NewId)
        {
            return newstabdal.GetNewsTabByNewId(NewId);
        }
        public int DeleteNewsTab(int Newsid)
        {
            return newstabdal.DeleteNewsTab(Newsid);
        }
        public int UpdateNewsTab(Tz888.Model.NewsTab newstab, int newsid)
        {
            return newstabdal.UpdateNewsTab(newstab,newsid);
        }
        public int UpdateNewsTabaudit(int newsid)
        {
            return newstabdal.UpdateNewsTabaudit(newsid);
        }
        public string GetMaxNewsId()
        {
            return newstabdal.GetMaxNewsId();
        }
        public int UpdateNewsTabUrl(string url, int newsid)
        {
            return newstabdal.UpdateNewsTabUrl(url,newsid);
        }
        public string GetStringPerson(string name, int status, int index, int loantype, string loanstitles)
        {
            string loansinfoIds = "";
            string loansTitles = "";
            string loanscreatetimes = "";
            string loanstypes = "";
            string LoginNames = "";
            string auditings = "";
            string htmls = "";
            string updatetimes = "";
            StringBuilder sb = new StringBuilder();
            string sdt = " and 1=1";
            if (loanstitles != "")
            {
                sdt += " and NTitle like '" + loanstitles + "%'";
            } if (loantype != -1)
            {
                sdt += " and TypeID=" + loantype + "";
            }
            string sql = "select top 20 Newsid,UserName,NTitle,TypeID,audit,urlhtml,createdate,recommendID from NewsTab where "
            + " audit=@statu and UserName=@name " + sdt + "  and Newsid not in (select top " + 20 * index + " Newsid from NewsTab where  audit=@statu " + sdt + " and UserName=@name"
                 + " order by createdate desc) order by createdate desc";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@statu",SqlDbType.Int,4)
            };
            para[0].Value = name;
            para[1].Value = status;
            DataSet ds = DBHelpe.Query(sql, para);
            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
            sb.Append("<td width=\"12%\"><a href=\"javascript:SelectAll();\">ȫѡ</a>��<a href=\"javascript:ReSelect();\">��ѡ</a></td>");
            sb.Append("<td width=\"8%\">���</td>");
            sb.Append("<td width=\"20%\">����</td>");
            sb.Append("<td width=\"12%\">����ʱ��</td>");
            sb.Append("<td width=\"12%\">�Ƿ��Ƽ�</td>");
            sb.Append("<td width=\"33%\">����</td></tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 20 ? 20 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    loansinfoIds = row["Newsid"].ToString().Trim();//��� 
                    loansTitles = row["NTitle"].ToString().Trim(); //���� 
                    loanscreatetimes = row["createdate"].ToString().Trim();// ����ʱ�� 
                    loanstypes = row["TypeID"].ToString().Trim();// ���
                    LoginNames = row["UserName"].ToString().Trim();// �û��� 
                    auditings = row["audit"].ToString().Trim();//���״̬ 
                    htmls = row["urlhtml"].ToString().Trim();// html 
                    updatetimes = row["recommendID"].ToString().Trim();// �Ƿ��Ƽ�
                    DateTime beg = Convert.ToDateTime(loanscreatetimes);
                    string begTime = beg.ToString("yyyy-MM-dd");
                    sb.Append("<tr><td><input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\"" + loansinfoIds + "\" /></td>");
                    sb.Append("<td>" + SetDaikuanType(loanstypes) + "</td>");
                    sb.Append("<td><span class=\"lanl\"><a href='http://www.topfo.com/" + htmls + "' target=\"_blank\" class=\"lan1\" title='" + loansTitles + "'>" + StrLength(loansTitles) + "</a></span></td>");
                    sb.Append("<td>" + begTime + "</td>");
                    sb.Append("<td>" + Tuijian(updatetimes) + "</td>");
                    sb.Append("<td>");
                    sb.Append("<a href='javascript:updateloans(" + 0 + "," + loansinfoIds + ");' class=\"lan1\">�޸�</a> ");
                    sb.Append("<a href='javascript:DelNav(" + loansinfoIds + ");' onclick='javascript:Del()' class=\"lan1\">ɾ��</a></td></tr>");
                }
            }
            sb.Append("</table>");


            return sb.ToString();

        }

        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statu"></param>
        /// <returns></returns>
        public int pageIndex(string name, int statu, int loantype, string loanstitles)
        {
            int num = 0;
            string sdt = "and 1=1";
            if (loanstitles != "")
            {
                sdt += " and NTitle like '" + loanstitles + "%'";
            } if (loantype != -1)
            {
                sdt += " and TypeID=" + loantype + "";
            }
            string sql = "select Count(Newsid) from NewsTab where  audit=@statu " + sdt + " and UserName=@name";
            SqlParameter[] para ={ 
                 new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@statu",SqlDbType.Int,4)
            };
            para[0].Value = name;
            para[1].Value = statu;
            num = Convert.ToInt32(DBHelpe.GetSingle(sql, para));
            return num;
        }

        /// <summary>
        /// ��ѯ���ж���ҳ
        /// </summary>
        /// <param name="typeID"></param>
        /// <returns></returns>
        public int pageS(string name, int statu, int InfoType, string title)
        {
            int pagecc = 0;
            int page = pageIndex(name, statu, InfoType, title);
            pagecc = page >= 20 ? (page % 20 == 0 ? page / 20 : page / 20 + 1) : 1;
            return pagecc;
        }

        //��ҳ��ʾ
        public string pageCont(string name, int statu, int index, int loantype, string loanstitles)
        {
            StringBuilder sb = new StringBuilder();
            int pageI = pageIndex(name, statu, loantype, loanstitles);
            int pagec = pageS(name, statu, loantype, loanstitles);
            if (pageI != 0)
            {
                sb.Append("��<span class=\"hong\">" + (index + 1) + "</span>/<span class=\"hong\" id='countss'>" + pagec + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">20</span>�� ");
                sb.Append("<a href='JavaScript:Having(" + statu + ",0," + statu + ");' class=\"lan1\">��һҳ</a>");
                if (index != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + statu + "," + (index - 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                for (int i = (index / 5 * 4); i < (pagec >= ((index / 5 * 4) + 5) ? ((index / 5 * 4) + 5) : pagec); i++)
                {
                    sb.Append("&nbsp<a class=\"lan1\" href='JavaScript:Having(" + statu + "," + i + ");'>" + (i + 1) + "</a>");
                }
                if ((index + 1) != pagec)
                {
                    sb.Append("&nbsp<a href='JavaScript:Having(" + statu + "," + (index + 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                sb.Append("&nbsp<a href='JavaScript:Having(" + statu + "," + (pagec - 1) + ");' class=\"lan1\">���ҳ</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(" + statu + ");\"  value=\"GO\" />");
            }
            return sb.ToString();
        }


        public string SetDaikuanType(string loanstypes)
        {
            Tz888.SQLServerDAL.news.NewsTypeTabDAL newtype = new Tz888.SQLServerDAL.news.NewsTypeTabDAL();
            Tz888.Model.NewsTypeTab newtypemod = newtype.GetNewsTypeByTypeId(Convert.ToInt32(loanstypes.Trim ()));
            return newtypemod.TypeName.ToString();
        }
        public string StrLength(string title)
        {
            if (title.Length > 8)
            {
                title = title.Substring(0, 8) + "..";
            }
            return title;
        }
        public string Tuijian(string remamandid)
        {
            string par = "";
            if (Convert.ToInt32(remamandid.Trim()) == 0)
            {
                par = "��";
            }
            else { par = "��"; }
            return par;
        }

    }
}
