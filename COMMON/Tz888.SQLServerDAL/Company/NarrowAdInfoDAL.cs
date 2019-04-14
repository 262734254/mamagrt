using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Tz888.SQLServerDAL.Company
{
    public  class NarrowAdInfoDAL:Tz888.IDAL.Company.INarrowAdInfoTab
    {
        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
        #region INarrowAdInfoTab 成员
        /// <summary>
        /// 窄告信息添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int NaAdd(Tz888.Model.Company.NarrowAdInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NarrowAdInfoTab(");
            strSql.Append("UserName,CreateDate,Title,Descript,Url,InfoTypeName,CountryCode,ProvinceID,CityID,CountyId,IndustryBID)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@CreateDate,@Title,@Descript,@Url,@InfoTypeName,@CountryCode,@ProvinceID,@CityID,@CountyId,@IndustryBID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@Descript", SqlDbType.VarChar,3000),
					new SqlParameter("@Url", SqlDbType.VarChar,200),
					new SqlParameter("@InfoTypeName", SqlDbType.VarChar,50),
					new SqlParameter("@CountryCode", SqlDbType.VarChar,20),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,20),
					new SqlParameter("@CityID", SqlDbType.VarChar,20),
					new SqlParameter("@CountyId", SqlDbType.VarChar,20),
					new SqlParameter("@IndustryBID", SqlDbType.VarChar,50)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.CreateDate;
            parameters[2].Value = model.Title;
            parameters[3].Value = model.Descript;
            parameters[4].Value = model.Url;
            parameters[5].Value = model.InfoTypeName;
            parameters[6].Value = model.CountryCode;
            parameters[7].Value = model.ProvinceID;
            parameters[8].Value = model.CityID;
            parameters[9].Value = model.CountyId;
            parameters[10].Value = model.IndustryBID;

            object obj = crm.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 窄告搜索信息添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SearchAdd(Tz888.Model.Company.NarrowSearchModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into NarrowSearchTab(");
            strSql.Append("AdID,LoginName,CreateDate)");
            strSql.Append(" values (");
            strSql.Append("@AdID,@LoginName,@CreateDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@AdID", SqlDbType.Int,4),
					new SqlParameter("@LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime)};
            parameters[0].Value = model.AdID;
            parameters[1].Value = model.LoginName;
            parameters[2].Value = model.CreateDate;

            object obj = crm.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 根据会员编号查询出用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelLoginName(int id)
        {
            string sql = "select LoginName from LoginInfoTab where LoginID=@id";
            SqlParameter[] para ={
                new SqlParameter("@id",SqlDbType.Int ,4)
            };
            para[0].Value = id;
            string num =Convert.ToString(Tz888.DBUtility.DbHelperSQL.GetSingle(sql,para));
            return num;
        }
        /// <summary>
        /// 窄告搜索表中，根据窄告编号，判断不能同时添加相同的帐号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SearchLoginName(int id, string name)
        {
            string sql = "select count(LoginName) from NarrowSearchTab where AdID=@id and LoginName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@id",SqlDbType.Int ,4),
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = id;
            para[1].Value = name;
            int num = Convert.ToInt32(crm.GetSingle(sql,para));
            return num;
        }
        /// <summary>
        /// 查看别人窄告你的信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string NarrowName(string name)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select top 9 a.Title,a.Url,a.Descript from NarrowAdInfoTab as a inner join NarrowSearchTab as b on "
                + "a.AdID=b.AdID where b.LoginName=@name order by newid() ";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            DataSet ds = crm.Query(sql,para);
            sb.Append("<ul>");
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < (ds.Tables[0].Rows.Count > 9 ? 9 : ds.Tables[0].Rows.Count); i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append("<li><h3><a href=\""+row["Url"]+"\">"+row["Title"]+"</a></h3>");
                    sb.Append("<p>" + sLength(35, Convert.ToString(row["Descript"])) + "</p></li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }

        /// <summary>
        /// 根据窄告编号查询出搜索表中ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string NarrowID(int Id)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select ID from NarrowSearchTab where AdID=@Id";
            SqlParameter[] para ={
                new SqlParameter("@Id",SqlDbType.Int,4)
            };
            para[0].Value = Id;
            DataSet ds = crm.Query(sql,para);
            if (ds != null & ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow row = ds.Tables[0].Rows[i];
                    sb.Append(""+row["ID"]+",");
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// 删除表中的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            int num = 0;
            string[] values = NarrowID(Id).Split(',');
            for (int i = 0; i < values.Length-1; i++)
            {
                int com = Convert.ToInt32(values[i]);
                string sqlS = "delete from NarrowSearchTab where ID=@com";
                SqlParameter[] paraS ={ 
                   new SqlParameter("@com",SqlDbType.Int,4)
                };
                paraS[0].Value = com;
                int dt = Convert.ToInt32(crm.GetSingle(sqlS, paraS));
            }
            string sql = "delete from NarrowAdInfoTab where AdID=@Id";
            SqlParameter[] para ={ 
                new SqlParameter("@Id",SqlDbType.Int,4) 
            };
            para[0].Value = Id;
            num = Convert.ToInt32(crm.GetSingle(sql,para));
            return num;
        }
        #endregion

        public string sLength(int n, string title)
        {
            string num = "";
            string nTitle = title.ToString().Trim();
            if (nTitle.Length>n)
            {
                num = nTitle.Substring(0, n) + "...";
            }
            else
            {
                num = nTitle.Trim();
            }
            return num;
        }
    }
}
