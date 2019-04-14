using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.BLL.MeberLogin
{
    public class PertinentLink
    {
        MemberIndex member = new MemberIndex();
        /// <summary>
        /// 查看自己资源情况
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string SelMainInfoId(string InfoID,string InfoType)
        {
            StringBuilder sb = new StringBuilder();
            if (InfoType != "Capital" || InfoType != "Merchant" || InfoType != "Project")
            {
                string sql = "";
                if (InfoType == "Capital")//投资
                {
                    sql = "select a.InfoID,a.AuditingStatus,a.Title,a.publishT,a.InfoTypeID,a.FrontDisplayTime,a.HtmlFile,b.IndustryBID,"
                        + "b.ProvinceID from MainInfoTab as a inner join CapitalInfoTab as b on a.InfoID=b.InfoID where "
                        + " a.InfoID=@InfoID ";

                }
                else if (InfoType == "Merchant")//招商
                {
                    sql = "select a.InfoID,a.Title,a.AuditingStatus,a.publishT,a.InfoTypeID,a.FrontDisplayTime,a.HtmlFile,b.IndustryClassList,"
                        + "b.ProvinceID from MainInfoTab as a inner join MerchantInfoTab as b on a.InfoID=b.InfoID where "
                        + "a.InfoID=@InfoID ";
                }
                else if (InfoType == "Project")//融资
                {
                    sql = "select a.InfoID,a.Title,a.AuditingStatus,a.publishT,a.InfoTypeID,a.FrontDisplayTime,a.HtmlFile,b.IndustryBID,"
                        + "b.ProvinceID from MainInfoTab as a inner join ProjectInfoTab as b on a.InfoID=b.InfoID where "
                        + " a.InfoID=@InfoID ";
                }

                SqlParameter[] para ={ 
                   new SqlParameter("@InfoID",SqlDbType.VarChar,20)
               };
                para[0].Value = InfoID;
                DataSet ds = DbHelperSQL.Query(sql, para);
                sb.Append("<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
                sb.Append("<thead><tr><td align=\"center\"  width=\"10%\">类别</td>");
                sb.Append("<td align=\"center\"  width=\"20%\">标题</td>");
                sb.Append("<td align=\"center\"  width=\"15%\">发布时间</td>");
                sb.Append("<td align=\"center\"  width=\"15%\">上次刷新</td>");
                sb.Append("<td align=\"center\"  width=\"20%\">所属行业</td>");
                sb.Append("<td align=\"center\"  width=\"10%\">所属区域</td>");
                sb.Append("<td align=\"center\"  width=\"10%\">管理</td></tr></thead>");
                sb.Append("<tr><td align=\"center\" class=\"taba\" style=\"height: 5px\">"+member.SelInfoType(InfoType)+"</td>");
                sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">");
                sb.Append("<a href='" + GetHref(ds.Tables[0].Rows[0]["HtmlFile"].ToString().Trim(),ds.Tables[0].Rows[0]["InfoID"].ToString().Trim(),InfoType.Trim()) + "' class=\"lan1\">"+ds.Tables[0].Rows[0]["Title"].ToString()+"</a>");
                sb.Append("</td>");
                sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">"+Bgtime(ds.Tables[0].Rows[0]["PublishT"].ToString().Trim())+"</td>");
                sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + Bgtime(ds.Tables[0].Rows[0]["FrontDisplayTime"].ToString().Trim()) + "</td>");
                if (InfoType == "Merchant")
                {
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + Industy(ds.Tables[0].Rows[0]["IndustryClassList"].ToString().Trim()) + "</td>");
                }
                else
                {
                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + Industy(ds.Tables[0].Rows[0]["IndustryBID"].ToString().Trim()) + "</td>");
                }
                sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">" + Province(ds.Tables[0].Rows[0]["ProvinceID"].ToString().Trim()) + "</td>");
                sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                sb.Append("<a href='" + GetModify("2887378","Merchant") + "'   class=\"lan1\">修改</a> ");
                sb.Append("<a href=\"./InfoRefreshSet.aspx\" class=\"lan1\">刷新</a>");
                sb.Append("</td></tr></table>");
            }
            return sb.ToString();
        }
        public string GetModify(string InfoID, string InfoType)
        {
            string url = "";
            switch (InfoType)
            {
                case "Capital":
                    url = "./ModifyCapital.aspx?id=" + InfoID + "&type=" + InfoType;
                    break;
                case "Project":
                    url = "./ModifyProject.aspx?id=" + InfoID + "&type=" + InfoType;
                    break;
                case "Merchant":
                    url = "./ModifyMerchant.aspx?id=" + InfoID + "&type=" + InfoType;
                    break;
                default:
                    break;
            }
            return url;
        }
        /// <summary>
        /// 判断标题并进行跳转
        /// </summary>
        /// <param name="htmlfile"></param>
        /// <param name="infoID"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string GetHref(string htmlfile, string infoID, string InfoType)
        {
            string num = "";
            if (htmlfile != "")
            {
                num = "http://www.topfo.com/" + htmlfile + "";
            }
            else
            {
                switch (InfoType.Trim())
                {
                    case "Merchant":
                        num = "./ModifyMerchant.aspx?id=" + infoID.ToString().Trim() + "&type=" + InfoType.ToString().Trim();
                        break;
                    case "Project":
                        num = "./ModifyProject.aspx?id=" + infoID.ToString().Trim() + "&type=" + InfoType.ToString().Trim();
                        break;
                    case "Capital":
                        num = "./ModifyCapital.aspx?id=" + infoID.ToString().Trim() + "&type=" + InfoType.ToString().Trim();
                        break;
                }
            }
            return num;
        }
        /// <summary>
        /// 截取时间字段
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public string Bgtime(string time)
        {
            string num = "";
            if (time != "")
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(time);
                num = dt.ToString("yyyy-MM-dd");
            }
            return num;
        }
        /// <summary>
        /// 翻译所在行业
        /// </summary>
        /// <param name="industyID"></param>
        /// <returns></returns>
        public string Industy(string industyID)
        { 
            string num="";
            if (industyID != "")
            {
                string[] name = industyID.Split(',');
                for (int i = 0; i < name.Length-1; i++)
                {
                    string com = name[i].ToString().Trim();
                    string sql = "select IndustryBName from setIndustryBTab where IndustryBID=@com";
                    SqlParameter[] para ={ 
                        new SqlParameter("@com",SqlDbType.VarChar,20)
                    };
                    para[0].Value = com;
                    num += Convert.ToString(DbHelperSQL.GetSingle(sql,para))+"、";
                }
            }
            return num;
        }
        /// <summary>
        /// 翻译所在区域中对应的城市
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public string Province(string ProvinceID)
        {
            string num = "";
            if (ProvinceID != "")
            {
                if (ProvinceID == "0000")
                {
                    num = "全国";
                }
                else
                {
                    string sql = "select ProvinceName from setProvinceTab where ProvinceID=@ProvinceID";
                    SqlParameter[] para ={ 
                        new SqlParameter("@ProvinceID",SqlDbType.VarChar,20)
                    };
                    para[0].Value = ProvinceID;
                    num = Convert.ToString(DbHelperSQL.GetSingle(sql, para));
                }
            }
            else
            {
                num = "全国";
            }
            return num;
        }
        /// <summary>
        /// 翻译认证标准
        /// </summary>
        /// <param name="renzheng"></param>
        /// <returns></returns>
        public string GetRenZheng(string renzheng)
        {
            string num = "";
            if (renzheng == "")
            {
                num = "未认证";
            }
            else
            {
                if (renzheng == "1")
                {
                    num = "已认证";
                }
                else
                {
                    num = "未认证";
                }
            }
            return num;
        }
        /// <summary>
        /// 查找行业名称
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string IndustyID(string InfoID, string InfoType)
        {
            string sql = "";
            if (InfoType == "Merchant")//招商
            {
                sql = "select IndustryClassList from MerchantInfoTab where InfoID=@InfoID";
            }
            else if (InfoType == "Capital")//投资
            {
                sql = "select IndustryBID from CapitalInfoTab where InfoID=@InfoID";
            }
            else if (InfoType == "Project")//融资
            {
                sql = "select IndustryBID from ProjectInfoTab where InfoID=@InfoID";
            }
            SqlParameter[] para ={ 
               new SqlParameter("@InfoID",SqlDbType.VarChar,50)
            };
            para[0].Value = InfoID;
            string num = Convert.ToString(DbHelperSQL.GetSingle(sql, para));
            return num;
        }
        /// <summary>
        /// 绑定对比的资源
        /// </summary>
        /// <param name="InfoType">资源所对应的类别</param>
        /// <param name="n">当前第几页</param>
        /// <param name="Industy">行业编号</param>
        /// <returns></returns>
        public string Balance(string InfoType, int n,string IndustyBID)
        {
            StringBuilder sb = new StringBuilder();
            string sql = " ";
            if (IndustyBID != "")
            {
                string[] ty = IndustyBID.Split(',');
                string num = " 1=1 ";
                for (int i = 0; i < ty.Length-1; i++)
                {
                    if (InfoType == "Merchant")
                    {
                        num += " and b.IndustryBID like '%" + ty[i] + "%'";
                    }
                    else if (InfoType == "Project" || InfoType == "Capital")
                    {
                        num += " and b.IndustryClassList like '%"+ty[i]+"%'";
                    }
                }
                if (InfoType == "Merchant")//招商找投资
                {
                    sql = "select top 10 a.InfoID,a.Title,a.publishT,a.LoginName,a.AuditingStatus,a.FixPriceID,a.HtmlFile,"
                        + "b.ProvinceID,b.IndustryBID,a.MainPointCount from MainInfoTab as a inner join CapitalInfoTab as b on a.InfoID=b.InfoID "
                        + " where " + num + " and a.AuditingStatus=1 and a.InfoID not in(select top " + 10 * n + " a.InfoID from MainInfoTab as a inner join "
                        + "CapitalInfoTab as b on a.InfoID=b.InfoID where " + num + " and a.AuditingStatus=1 order by a.publishT desc) order by a.publishT desc";
                }
                else if (InfoType == "Project" || InfoType == "Capital")//投资、融资找招商
                {
                    sql = "select top 10 a.InfoID,a.Title,a.publishT,a.LoginName,a.AuditingStatus,a.FixPriceID,a.HtmlFile,"
                        + "b.ProvinceID,b.IndustryClassList,a.MainPointCount from MainInfoTab as a inner join MerchantInfoTab as b on a.InfoID=b.InfoID "
                        + " where " + num + " and a.AuditingStatus=1 and a.InfoID not in(select top " + 10 * n + " a.InfoID from MainInfoTab as a inner join "
                        + "MerchantInfoTab as b on a.InfoID=b.InfoID where " + num + " and a.AuditingStatus=1 order by a.publishT desc) order by a.publishT desc";
                }
                DataSet ds = DbHelperSQL.Query(sql);
                sb.Append("<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
                sb.Append("<thead><tr>");
                sb.Append("<td align=\"center\"  width=\"5%\">对比</td>");
                sb.Append("<td align=\"center\"  width=\"20%\">标题</td>");
                sb.Append("<td align=\"center\"  width=\"10%\">发布时间</td>");
                sb.Append("<td align=\"center\"  width=\"19%\">所属行业</td>");
                sb.Append("<td align=\"center\"  width=\"8%\">所属区域</td>");
                sb.Append("<td align=\"center\"  width=\"8%\">资源价格</td>");
                sb.Append("<td align=\"center\"  width=\"8%\">资源保障</td>");
                sb.Append("<td align=\"center\"  width=\"10%\">发布者</td>");
                sb.Append("<td align=\"center\"  width=\"12%\">操作</td>");
                sb.Append("</tr></thead>");
                for (int j = 0; j < (ds.Tables[0].Rows.Count > 10 ? 10 : ds.Tables[0].Rows.Count); j++)
                {
                    DataRow row = ds.Tables[0].Rows[j];
                    sb.Append("<tr><td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("<label><input id=\"cbxSelect\" name=\"cbxSelect\" type=\"checkbox\" value=\"" + row["InfoID"].ToString().Trim() + "\" />");
                    sb.Append("</label></td>");

                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("<a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\" class=\"lan1\">" + row["Title"].ToString() + "</a></td>");
                   
                    sb.Append("<td align=\"left\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("" + Bgtime(Convert.ToString(row["publishT"])) + "</td>");

                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    if (InfoType == "Merchant")
                    {
                        sb.Append("" + Industy(Convert.ToString(row["IndustryBID"])) + "</td>");
                    }
                    else if (InfoType == "Project" || InfoType == "Capital")
                    {
                        sb.Append("" + Industy(Convert.ToString(row["IndustryClassList"])) + "</td>");
                    }

                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("" + Province(Convert.ToString(row["ProvinceID"])) + "</td>");

                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("" + row["MainPointCount"].ToString() + "</td>");

                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("" + GetRenZheng(Convert.ToString(row["AuditingStatus"])) + "</td>");

                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("" + row["LoginName"].ToString() + "</td>");

                    sb.Append("<td align=\"center\" class=\"taba\" style=\"height: 5px\">");
                    sb.Append("<a href='../helper/CollectingInfo.aspx?infoid=" + row["InfoID"].ToString() + "' class=\"lan1\">收藏</a>");

                    sb.Append(" <a href='http://www.topfo.com/" + row["HtmlFile"].ToString() + "' target=\"_blank\" class=\"lan1\">查看</a>");
                   
                    if (Convert.ToString(row["FixPriceID"].ToString().Trim()) != "1")
                    {
                        sb.Append(" <a href='../PayManage/order_item.aspx?InfoID=" + row["InfoID"].ToString() + "' class='lan1'>购买</a>");
                    }
                    sb.Append("</td></tr>");
                }
                sb.Append("</table>");
            }
            return sb.ToString();
        }
        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="InfoType"></param>
        /// <param name="Industy"></param>
        /// <returns></returns>
        public int IndexCount(string InfoType, string Industy)
        {
            int index = 0;
            if (Industy != "")
            { 
                string[] ty = Industy.Split(',');
                string num = " 1=1 ";
                string sql="";
                for (int i = 0; i < ty.Length - 1; i++)
                {
                    if (InfoType == "Merchant")
                    {
                        num += " and b.IndustryBID like '%" + ty[i] + "%'";
                    }
                    else if (InfoType == "Project" || InfoType == "Capital")
                    {
                        num += " and b.IndustryClassList like '%" + ty[i] + "%'";
                    }
                }
                if (InfoType == "Merchant")//招商找投资
                {
                    sql = "select count(InfoID) from (select a.InfoID from MainInfoTab as a inner join CapitalInfoTab as b on a.InfoID=b.InfoID where " + num + " and a.AuditingStatus=1) as c";
                }
                else if (InfoType == "Project" || InfoType == "Capital")//投资、融资找招商
                {
                    sql = "select count(InfoID) from (select a.InfoID from MainInfoTab as a inner join MerchantInfoTab as b on a.InfoID=b.InfoID where " + num + " and a.AuditingStatus=1) as c";
                }
                index = Convert.ToInt32(DbHelperSQL.GetSingle(sql));
            }
            return index;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string SelPageIndex(string InfoType, int n, string Industy)
        {
            StringBuilder sb = new StringBuilder();
            int sy = IndexCount(InfoType, Industy) >= 100 ? 100 : IndexCount(InfoType, Industy);
            int pageCount = sy;
            int pageIndex = 0;//总共多少个页面数
            pageIndex = pageCount >= 10 ? (pageCount % 10 == 0 ? pageCount / 10 : pageCount / 10 + 1) : 1;
            if (pageCount != 0)
            {
                sb.Append("总条数<span class='hong'>" + pageCount + "</span>,第<span class=\"hong\">" + (n + 1) + "</span>/<span class=\"hong\" id='countss'>" + pageIndex + "</span>页,");
                sb.Append("每页显示<span class=\"hong\">10</span>条 ");
                sb.Append("<a href='JavaScript:Having(0);' class=\"lan1\">第一页</a>");
                if (n != 0)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n - 1) + ");' class=\"lan1\">上一页</a>");
                }
                for (int i = (n / 5 * 4); i < (pageIndex >= ((n / 5 * 4) + 5) ? ((n / 5 * 4) + 5) : pageIndex); i++)
                {
                    sb.Append("<a class=\"lan1\" href='JavaScript:Having(" + i + ");'>" + (i + 1) + "</a> ");
                }
                if ((n + 1) != pageIndex)
                {
                    sb.Append("<a href='JavaScript:Having(" + (n + 1) + ");' class=\"lan1\">下一页</a>");
                }
                sb.Append("<a href='JavaScript:Having(" + (pageIndex - 1) + ");' class=\"lan1\">最后页</a> ");
                sb.Append("<input type=\"text\" id=\"pCount\" onkeyup=\"value=value.replace(/[^0-9]/g,'')\" onblur=\"value=value.replace(/[^0-9]/g,'')\" style=\"width: 22px\"/>");
                sb.Append("<input type=\"button\" id=\"btnOk\" onclick=\"javascript:onccxx(0);\"  value=\"GO\" />");
            }
            return sb.ToString();
        }
    }
}
