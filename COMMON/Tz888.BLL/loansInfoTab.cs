using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;
using System.Data.SqlClient;
using Tz888.DBUtility;
using System.Data;

namespace Tz888.BLL
{
    public class loansInfoTab
    {
        private readonly IloansInfoTab dal = DataAccess.CreateILoansInfoTab();
        public int InsertLoansInfoTab(Tz888 .Model .LoansInfoTab loansinfotab,Tz888 .Model .LoansInfo loansinfo,Tz888 .Model .LoanscontactsTab loanscontactstab)
        {
            return dal.InsertLoansInfoTab(loansinfotab, loansinfo, loanscontactstab);
        }
     
        public Tz888.Model.LoansInfoTab GetLoansInfoTabByLoansInfoId(int LoansInfoId)
        {
            return dal.GetLoansInfoTabByLoansInfoId(LoansInfoId);
        }
        public int UpdateLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab)
        {
            return dal.UpdateLoansInfoTab(loansinfotab);
        }
        public int UpdateLoansInfoTabauditID(int id)
        {
            return dal.UpdateLoansInfoTabauditID(id);
        }
        public List<Tz888.Model.LoansInfoTab> GetAllInfoTab()
        {
            return dal.GetAllInfoTab();
        }
        public int DeleteLoansInfoTab(int loansInfoID)
        {
            return dal.DeleteLoansInfoTab(loansInfoID);
        }
        public int ShenHeLoansInfoTab(Tz888.Model.LoansInfoTab loansinfotab)
        {
            return dal.ShenHeLoansInfoTab(loansinfotab);
        }
        public string GetStringPerson(string name, int status, int index, int loantype, string loanstitles)
        {
            string loansinfoIds = "";
            string loansTitles = "";
            string loanscreatetimes = "";
            string loanstypes ="";
            string LoginNames ="";
            string auditings = "";
            string htmls ="";
            string updatetimes = "";
            StringBuilder sb = new StringBuilder();
            string sdt = " and 1=1";
            if (loanstitles != "")
            {
                sdt += " and LoansTitle like '" + loanstitles + "%'";
            } if (loantype !=2)
            {
                sdt += " and BorrowingType=" + loantype + "";
            }
            string sql = "select top 20 loansInfoID,LoginName,LoansTitle,BorrowingType,auditID,chargeID,recommendID,URL,loansdate,refurbishtime from loansInfoTab where "
            + " auditID=@statu and LoginName=@name " + sdt + "  and loansInfoID not in (select top " + 20 * index + " loansInfoID from loansInfoTab where  auditID=@statu " + sdt + " and LoginName=@name"
                 + " order by loansdate desc) order by loansdate desc";
                     SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@statu",SqlDbType.Int,4)
            };
            para[0].Value = name;
            para[1].Value = status;
            DataSet ds = DbHelperSQL.Query(sql, para);
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><thead><tr>");
                sb.Append("<td width=\"12%\"><a href=\"javascript:SelectAll();\">ȫѡ</a>��<a href=\"javascript:ReSelect();\">��ѡ</a></td>");
                sb.Append("<td width=\"8%\">���</td>");
                sb.Append("<td width=\"20%\">����</td>");
                sb.Append("<td width=\"12%\">����ʱ��</td>");
                sb.Append("<td width=\"12%\">ˢ��ʱ��</td>");
                sb.Append("<td width=\"33%\">����</td></tr></thead>");
                if (ds != null & ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < (ds.Tables[0].Rows.Count > 20 ? 20 : ds.Tables[0].Rows.Count); i++)
                    {
                        DataRow row = ds.Tables[0].Rows[i];
                        loansinfoIds = row["loansInfoID"].ToString().Trim ();//��� 
                        loansTitles = row["LoansTitle"].ToString().Trim (); //���� 
                        loanscreatetimes = row["loansdate"].ToString().Trim ();// ����ʱ�� 
                        loanstypes= row["BorrowingType"].ToString().Trim();// �������
                        LoginNames = row["LoginName"].ToString().Trim ();// �û��� 
                        auditings = row["auditID"].ToString().Trim ();//���״̬ 
                        htmls = row["URL"].ToString().Trim ();// html 
                        updatetimes = row["refurbishtime"].ToString().Trim();// ˢ��ʱ�� 
                        DateTime beg = Convert.ToDateTime(loanscreatetimes);
                        DateTime beg2 = Convert.ToDateTime(updatetimes);
                        string begTime = beg.ToString("yyyy-MM-dd");
                        string begTime2 = beg2.ToString("yyyy-MM-dd");
                        sb.Append("<tr><td><input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\"" + loansinfoIds + "\" /></td>");
                        sb.Append("<td>" + SetDaikuanType(loanstypes) + "</td>");
                        sb.Append("<td><span class=\"lanl\"><a href='http://www.topfo.com/" + htmls + "' target=\"_blank\" class=\"lan1\" title='" + loansTitles + "'>" + StrLength(loansTitles) + "</a></span></td>");
                        sb.Append("<td>" + begTime + "</td>");
                        sb.Append("<td>" + begTime2 + "</td>");
                        sb.Append("<td>");
                        sb.Append("<a href='javascript:updateloans(" + loanstypes+ "," + loansinfoIds + ");' class=\"lan1\">�޸�</a> ");
                        sb.Append("<a href='javascript:DelNav(" + loansinfoIds+ ");' onclick='javascript:Del()' class=\"lan1\">ɾ��</a>&nbsp");
                        if (status == 1)
                        {
                            sb.Append("<a href='javascript:updaterefurbishtime(" + loansinfoIds + ");' class=\"lan1\">ˢ��</a></td></tr>");
                        }
                        else 
                        {
                            sb.Append("</td></tr>");
                        }
                     
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
                sdt += " and LoansTitle like '" + loanstitles + "%'";
            } if (loantype !=2)
            {
                sdt += " and BorrowingType=" + loantype + "";
            }
            string sql ="select Count(loansInfoID) from loansInfoTab where  auditID=@statu " + sdt + " and LoginName=@name";
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

        public int UpdaterefurbishtimeLoansInfoTab(int id)
        {
            string sql = "Update loansinfotab set refurbishtime=@refurbishtime where loansInfoID=@loansInfoID ";
            string retime=DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString().Trim();
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@refurbishtime",retime)
                    ,new SqlParameter("@loansInfoID",id )
                    };
            int result = DbHelperSQL.ExecuteSql(sql, ps);
            return result;
        }
        public string SetDaikuanType(string loanstypes)
        {
            string par="";
            if (Convert.ToInt32(loanstypes) == 0)
            {
                par = "���˴���";
            }
            else { par = "��ҵ����"; }
            return par;
        }
        public string StrLength(string title)
        {
            if (title.Length > 8)
            {
                title = title.Substring(0, 8) + "..";
            }
            return title;
        }

    }
}
