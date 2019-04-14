using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.news;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.news
{
    public class NewsTabDAL:INewsTab
    {
        public int InsertNewsTab(Tz888.Model.NewsTab newstab, Tz888.Model.NewsTypeTab newstypetab, Tz888.Model.NewsViewTab newsviewtab)
        {
            int rowsAffected = 0;
            SqlParameter[] parameters = {
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,200),
					new SqlParameter("@NTitle", SqlDbType.VarChar,200),
					new SqlParameter("@audit", SqlDbType.Int,4),
					new SqlParameter("@FromID", SqlDbType.Int,4),
					new SqlParameter("@urlhtml", SqlDbType.VarChar,200),
					new SqlParameter("@createdate", SqlDbType.DateTime),
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@keywords", SqlDbType.VarChar,200),
                    new SqlParameter("@description", SqlDbType.VarChar,200),
                    new SqlParameter("@NewView", SqlDbType.Text,10000),
                    new SqlParameter("@form", SqlDbType.VarChar,2000),
                    new SqlParameter("@author", SqlDbType.VarChar,200),
                    new SqlParameter("@zhaiyao", SqlDbType.VarChar,200),
                    new SqlParameter ("@recommendID", SqlDbType.Int,4),
                 new SqlParameter("@ImagesUrls", SqlDbType.NVarChar,400)
            };
            parameters[0].Value = newstab.TypeID ;
            parameters[1].Value = newstab.UserName;
            parameters[2].Value = newstab.NTitle;
            parameters[3].Value = newstab.Audit ;
            parameters[4].Value = newstab.FromID;
            parameters[5].Value = newstab.Urlhtml ;
            parameters[6].Value =newstab .Createdate ;
            parameters[7].Value = newsviewtab.Title ;
            parameters[8].Value = newsviewtab.Keywords ;
            parameters[9].Value = newsviewtab.Description ;
            parameters[10].Value = newsviewtab.NewView;
            parameters[11].Value = newsviewtab.Formid;
            parameters[12].Value = newsviewtab.Author;
            parameters[13].Value = newsviewtab.Zhaiyao ;
            parameters[14].Value = newstab.RecommendID;
            parameters[15].Value ="NULL";

            DBHelpe.RunProcedure("NewsTab_Insert", parameters, out rowsAffected);
            return rowsAffected;
        }
        public Tz888.Model.NewsTab GetNewsTabByNewId(int NewId)
        {
            string sql = "select * from NewsTab where Newsid=@newid";
            Tz888.Model.NewsTab newstab=null;
            DataSet set = DBHelpe.Query(sql, new SqlParameter("newid", NewId));
            foreach (DataRow row in set.Tables[0].Rows)
            {
                newstab = new Tz888.Model.NewsTab();
                newstab.Newsid = Convert.ToInt32(row["Newsid"]);
                newstab.NTitle =row["NTitle"].ToString ().Trim ();
                newstab.UserName = row["UserName"].ToString().Trim();
                newstab.TypeID = Convert.ToInt32(row["TypeID"]);
                newstab.Audit = Convert.ToInt32(row["Audit"]);
                newstab.FromID = Convert.ToInt32(row["FromID"]);
                newstab.Urlhtml = row["urlhtml"].ToString().Trim();
                newstab.Createdate = row["Createdate"].ToString().Trim();
                newstab.RecommendID = Convert .ToInt32(row["RecommendID"]);
            }
            return newstab;
        }
        public string  GetMaxNewsId()
        {
            string sql = "select Max(Newsid)as Newsid from NewsTab";
            DataSet set = DBHelpe.Query(sql);
            string par = "";
            foreach (DataRow row in set.Tables[0].Rows)
            {
                par = row["Newsid"].ToString().Trim();
            }
            return par;
        }
        public int DeleteNewsTab(int Newsid)
        {
            string sql = "delete NewsTab where Newsid=@Newsid  ";
            int result = DBHelpe.ExecuteSql(sql, new SqlParameter("Newsid", Newsid));
            return result;
        }
        public int UpdateNewsTab(Tz888.Model.NewsTab newstab, int newsid)
        {
            string sql = "Update NewsTab set NTitle=@ntitle ,TypeID=@typeid,recommendID=@recommendID,urlhtml=@urlhtml where Newsid=@Newsid  ";
            SqlParameter[] ps = new SqlParameter[]{
                     new SqlParameter("@ntitle",newstab.NTitle)
                    ,new SqlParameter ("@typeid",newstab.TypeID)
                    ,new SqlParameter ("@recommendID",newstab.RecommendID)
                    ,new SqlParameter ("@urlhtml",newstab.Urlhtml)
                    ,new SqlParameter ("@Newsid",newsid)
                    
            };
            int result = DBHelpe.ExecuteSql(sql, ps);
            return result;
        }
        public int UpdateNewsTabaudit(int newsid)
        {
            string sql = "Update NewsTab set Audit=5 where Newsid=@Newsid  ";//É¾³ýÓÃ  ¸Ä±äÉóºË×´Ì¬
            SqlParameter[] ps = new SqlParameter[]{
                    new SqlParameter ("@Newsid",newsid)
                    
            };
            int result = DBHelpe.ExecuteSql(sql,ps);
            return result;
        }
        public int UpdateNewsTabUrl(string url, int newsid)
        {
            string sql = "Update NewsTab set urlhtml=@urlhtml where Newsid=@Newsid  ";
            SqlParameter[] ps = new SqlParameter[]{
                    new SqlParameter ("@urlhtml",url)
                    ,new SqlParameter ("@Newsid",newsid)
                    
            };
            int result = DBHelpe.ExecuteSql(sql, ps);
            return result;
        }
    }
}
