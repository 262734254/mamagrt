using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class PayManage
    {
        #region ��ֵ������Ϣ
        /// <summary>
        /// ��ֵ������Ϣ
        /// </summary>
        /// <param name="name">�û���</param>
        /// <param name="n">�ڼ�ҳ</param>
        /// <param name="time">ʱ��</param>
        /// <param name="Pay">֧����ʽ</param>
        /// <returns></returns>
        public string StrikeOrder(string name,int n,string time,string Pay)
        {
            StringBuilder sb=new StringBuilder();
            string num = " and 1=1";
            if (time != "-1")
            {
                num += " and DateDiff(d,PayTime,getdate())>" + time + "";
            }
            else if(Pay !="all")
            {
                num += " and PayType="+Pay+"";
            }
            string sql = "select top 15 OrderNO,StrikeLoginName,TransMoney,PayType,OrderTime from StrikeOrderTab where LoginName=@name "+num+" and Status<>1 and Status<>10 and OID "
                +" not in(select top "+15*n+" OID from StrikeOrderTab where LoginName=@name "+num+" and Status<>1 and Status<>10 order "
                +" by OID desc) order by OID desc";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql,para);
            sb.Append("<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            sb.Append("<thead><tr><td align=\"center\"  width=\"15%\">");
            sb.Append("<a href=\"Javascript:SelectAll();\"><span>ȫѡ</span></a>|<a href=\"Javascript:ReSelect();\"><span>��ѡ</span></a></td>");
            sb.Append("<td align=\"center\"  width=\"15%\">������</td>");
            sb.Append("<td align=\"center\"  width=\"10%\">��ֵ�ʺ�</td>");
            sb.Append("<td align=\"center\"  width=\"13%\"> ��ֵ���(Ԫ)</td>");
            sb.Append("<td align=\"center\"  width=\"17%\">����ʱ��</td>");
            sb.Append("<td align=\"center\"  width=\"10%\">��ֵ��ʽ</td>");
            sb.Append("<td align=\"center\"  width=\"20%\">��������</td></tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 15 ? 15 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    DateTime dt = Convert.ToDateTime(row["OrderTime"].ToString());
                    string ordertime = dt.ToString("yyyy-MM-dd hh:mm:ss");
                    sb.Append("<tr>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\"><label>");
                    sb.Append("<input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value='"+row["OrderNO"].ToString()+"' /></label></td>");
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">"+row["OrderNO"].ToString()+"</td>");
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">" + row["StrikeLoginName"].ToString() + "</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + row["TransMoney"].ToString() + ".00 Ԫ</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">"+ordertime+"</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + SelPayType(row["PayType"].ToString().Trim()) + "</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("<a href='javascript:DelNav(" +row["OrderNO"].ToString()+ ");' onclick='javascript:Del()' class=\"lan1\">ɾ������</a> ");
                    sb.Append("<a href=\"strike_details.aspx?action=0&order_no="+row["OrderNO"].ToString()+"\" class=\"lan1\">��ϸ</a> ");
                    sb.Append("<a href=\"#\" class=\"lan1\">֧��</a>");
                    sb.Append("</td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// ��ѯ��ֵ�����ܹ�����������
        /// </summary>
        /// <returns></returns>
        public int PageOrder(string name,string time, string pay)
        {
            int pageCount = 0;//�ܹ�����������
            string num = " and 1=1";
            if (time != "-1")
            {
                num += " and DateDiff(d,PayTime,getdate())>" + time + "";
            }
            else if (pay != "all")
            {
                num += " and PayType=" + pay + "";
            }
            string sql = "select count(OrderNO) from (select OrderNo from  StrikeOrderTab where LoginName=@name "+num+" and Status<>1 and Status<>10 group by OrderNo) as c";
            SqlParameter[] para ={ 
                 new SqlParameter("@name",SqlDbType.VarChar,100)
            };
            para[0].Value = name;
            pageCount = Convert.ToInt32(DbHelperSQL.GetSingle(sql,para));
            return pageCount;
        }
        /// <summary>
        /// �󶨷�ҳ
        /// </summary>
        /// <returns></returns>
        public string PageOrderIndex(string name, int n, string time, string pay)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = PageOrder(name,time,pay);
            int pageIndex = 0;//�ܹ����ٸ�ҳ����
            pageIndex = pageCount >= 15 ? (pageCount % 15 == 0 ? pageCount / 15 : pageCount / 15 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">15</span>�� ");
                sb.Append("<a href='JavaScript:Having(1,0);' class=\"lan1\">��һҳ</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(1," + (n - 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(1," + i + ");'>" + (i + 1) + "</a>");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(1," + (n + 1) + ");' class=\"lan1\">��һҳ</a>");
                }
                sb.Append("<a href='JavaScript:Having(1," + (pageIndex - 1) + ");' class=\"lan1\">���ҳ</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(1);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
        #endregion

        #region ��ֵ��¼��
        /// <summary>
        /// ��ֵ��¼��Ϣ
        /// </summary>
        /// <param name="name">�û���</param>
        /// <param name="n">�ڼ�ҳ</param>
        /// <param name="time">ʱ��</param>
        /// <param name="Pay">֧����ʽ</param>
        /// <returns></returns>
        public string StrikeRec(string name, int n, string time, string pay)
        {
            StringBuilder sb = new StringBuilder();
            string num = " and 1=1";
            if (time != "-1")
            {
                num += " and DateDiff(d,PayTime,getdate())>" + time + "";
            }
            else if (pay != "all")
            {
                num += " and PayType=" + pay + "";
            }
            string sql = "select top 15 ID,LoginName,PointCount,StrikeTime,StrikeType from StrikeRecTab where "
                +" LoginName=@name "+num+" and ID not in (select top "+15*n+" ID from StrikeRecTab where LoginName=@name "+num+" "
                +" order by StrikeTime desc) order by StrikeTime desc";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = DbHelperSQL.Query(sql, para);
            sb.Append("<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
            sb.Append("<thead><tr>");
            sb.Append("<td align=\"center\"  width=\"15%\">��ֵ�ʻ�</td>");
            sb.Append("<td align=\"center\" width=\"18%\">��ֵ���(Ԫ)</td>");
            sb.Append("<td align=\"center\"  width=\"18%\">��ֵʱ��</td>");
            sb.Append("<td align=\"center\"  width=\"15%\">��ֵ��ʽ</td>");
            sb.Append("<td align=\"center\"  width=\"15%\">��������</td>");
            sb.Append("</tr></thead>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 15 ? 15 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<tr><td align=\"center\" class=\"taba\" style=\"height: 5px\">"+row["LoginName"].ToString()+"</td>");
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">"+row["PointCount"].ToString()+".00 Ԫ</td>");
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">"+row["StrikeTime"].ToString()+"</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + SelPayType(row["StrikeType"].ToString().Trim()) + "</td>");
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("<a href=\"strike_details.aspx?action=1&order_no="+row["ID"].ToString()+"\" class=\"lan1\">��ϸ</a> ");
                    sb.Append("</td></tr>");
                }
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        /// <summary>
        /// ��ѯ��ֵ��¼�����ܹ��ж���������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="pay"></param>
        /// <returns></returns>
        public int PageRec(string name, string time, string pay)
        {
            int pageCount = 0;
            string num = " and 1=1";
            if (time != "-1")
            {
                num += " and DateDiff(d,PayTime,getdate())>" + time + "";
            }
            else if (pay != "all")
            {
                num += " and PayType=" + pay + "";
            }
            string sql = "select count(ID) from (select ID from StrikeRecTab where LoginName=@name "+num+" group by ID) as c";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            pageCount=Convert.ToInt32(DbHelperSQL.GetSingle(sql,para));
            return pageCount;
        }
        /// <summary>
        /// �󶨷�ҳ
        /// </summary>
        /// <returns></returns>
        public string PageRecIndex(string name, int n, string time, string pay)
        {
            StringBuilder sb = new StringBuilder();
            int pageCount = PageRec(name, time, pay);
            int pageIndex = 0;//�ܹ����ٸ�ҳ����
            pageIndex = pageCount >= 15 ? (pageCount % 15 == 0 ? pageCount / 15 : pageCount / 15 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("��<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>ҳ,");
                sb.Append("ÿҳ��ʾ<span class=\"hong\">15</span>�� ");
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
        #endregion
        /// <summary>
        /// ��ѯ�ܹ����
        /// </summary>
        /// <param name="field">�������Ӧ���ֶ�����</param>
        /// <param name="table">������</param>
        /// <param name="wherer">����Ӧ������</param>
        /// <returns></returns>
        public int SumMoney(string field, string tablee, string wherer)
        {
            int num = 0;
            //string sql = "select sum(@field) from @tablee where @wherer";
            //SqlParameter[] para ={ 
            //    new SqlParameter("@field",SqlDbType.VarChar,100),
            //    new SqlParameter("@tablee",SqlDbType.VarChar,100),
            //    new SqlParameter("@wherer",SqlDbType.VarChar,500)
            //};
            //para[0].Value = field;
            //para[1].Value = tablee;
            //para[2].Value = wherer;
            //num = Convert.ToInt32(DbHelperSQL.GetSingle(sql, para));
            string sql = "select sum("+field+") from "+tablee+" where "+wherer+"";
            num = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            return num;
        }
        /// <summary>
        /// ����֧����ʽ
        /// </summary>
        /// <param name="Pay"></param>
        /// <returns></returns>
        public string SelPayType(string Pay)
        {
            string name = "";
            if (Pay != "")
            {
                string sql = "select PayTypeName from SetPayTypeTab  where PayTypeCode=@Pay";
                SqlParameter[] para ={ 
                    new SqlParameter("@Pay",SqlDbType.VarChar,50)
                };
                para[0].Value = Pay;
                name = Convert.ToString(DbHelperSQL.GetSingle(sql, para));
            }
            return name;
        }
    }
}
