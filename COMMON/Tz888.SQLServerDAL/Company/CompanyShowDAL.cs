using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.Model.Company;

namespace Tz888.SQLServerDAL.Company
{
    public class CompanyShowDAL : Tz888.IDAL.Company.ICompanyShow
    {
        #region ICompanyShow 成员

        Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
        /// <summary>
        /// 添加企业展厅
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddShow(Tz888.Model.Company.CompanyShow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyShow(");
            strSql.Append("UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,CompanyName,Countrycode,Provinceid,Cityid,Countyid,OrderId,Recomm,Industry)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@TelPhone,@Mobile,@Email,@Audit,@StartTime,@Valid,@TypeName,@CompanyName,@Countrycode,@Provinceid,@Cityid,@Countyid,@OrderId,@Recomm,@Industry)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarBinary,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
                    new SqlParameter("@TypeName", SqlDbType.VarChar,20),
                    new SqlParameter("@CompanyName", SqlDbType.VarChar,100),

                    new SqlParameter("@Countrycode", SqlDbType.VarChar,20),
                    new SqlParameter("@Provinceid", SqlDbType.VarChar,20),
                    new SqlParameter("@Cityid", SqlDbType.VarChar,20),
                    new SqlParameter("@Countyid", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@Recomm", SqlDbType.VarChar,50),
                   new SqlParameter("@Industry", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Audit;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.Valid;
            parameters[8].Value = model.Typename;
            parameters[9].Value = model.CompanyName;

            parameters[10].Value = model.Countrycode;
            parameters[11].Value = model.Provinceid;
            parameters[12].Value = model.Cityid;
            parameters[13].Value = model.Countyid;
            parameters[14].Value = model.OrderId;
            parameters[15].Value = model.Recomm;
            parameters[16].Value = model.Industry;

            object obj = crm.GetSingleShow(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 资源联盟信息添加
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        public int ZylmAddShow(Tz888.Model.Company.CompanyShow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyShow(");
            strSql.Append("UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,RoleId,CompanyName,Countrycode,Provinceid,Cityid,Countyid,OrderId,Recomm,Industry)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@TelPhone,@Mobile,@Email,@Audit,@StartTime,@Valid,@TypeName,@RoleId,@CompanyName,@Countrycode,@Provinceid,@Cityid,@Countyid,@OrderId,@Recomm,@Industry)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarBinary,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
                    new SqlParameter("@TypeName", SqlDbType.VarChar,20),
                	new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@CompanyName", SqlDbType.VarChar,100),

                    new SqlParameter("@Countrycode", SqlDbType.VarChar,20),
                    new SqlParameter("@Provinceid", SqlDbType.VarChar,20),
                    new SqlParameter("@Cityid", SqlDbType.VarChar,20),
                    new SqlParameter("@Countyid", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@Recomm", SqlDbType.VarChar,50),
                    new SqlParameter("@Industry", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Audit;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.Valid;
            parameters[8].Value = model.Typename;
            parameters[9].Value = 3;
            parameters[10].Value = model.CompanyName;

            parameters[11].Value = model.Countrycode;
            parameters[12].Value = model.Provinceid;
            parameters[13].Value = model.Cityid;
            parameters[14].Value = model.Countyid;
            parameters[15].Value = model.OrderId;
            parameters[16].Value = model.Recomm;
            parameters[17].Value = model.Industry;
            object obj = crm.GetSingleShow(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 判断该用户是否已经发布了资源联盟
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfUserName(string name, int roleid)
        {
            int num = 0;
            string sql = "select count(CompanyID) from CompanyShow where roleid=" + roleid + " and UserName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingleShow(sql, para));
            return num;
        }
        /// <summary>  
        /// 判断该用户发布的资源联盟是否审核通过
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfAudit(string name, int roleid)
        {
            int num = 0;
            string sql = "select Audit from CompanyShow where roleid=" + roleid + " and UserName=@name";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingleShow(sql, para));
            return num;
        }
        /// <summary>
        /// 判断该用户是否已经发布了企业展厅
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfUserName(string name)
        {
            int num = 0;
            string sql = "select count(CompanyID) from CompanyShow where UserName=@name";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingleShow(sql, para));
            return num;
        }
        /// <summary>
        /// 通过用户名查找会员的地域信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetMemberInfoByName(string loginName)
        {
            string sql = "SELECT countrycode,provinceid,countyid,cityid,mobile,email from memberinfoTab where loginname='" + loginName + "'";
            return DBUtility.DbHelperSQL.Query(sql);
        }
        /// <summary>  
        /// 判断该用户发布的展厅信息是否审核通过
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfAudit(string name)
        {
            int num = 0;
            string sql = "select Audit from CompanyShow where UserName=@name";
            SqlParameter[] para ={ 
                new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingleShow(sql, para));
            return num;
        }
        public string OverdueTime(string name)
        {
            string num = "";
            return num;
        }
        #endregion

        #region ICompanyShow 成员


        #endregion

        #region ICompanyShow 成员


        public int IfUserNameAudit(string name, int roleid)
        {
            int num = 0;
            string sql = "select count(CompanyID) from CompanyShow where roleid=" + roleid + " and UserName=@name and Audit=1";
            SqlParameter[] para ={ 
               new SqlParameter("@name",SqlDbType.VarChar,50)
            };
            para[0].Value = name;
            num = Convert.ToInt32(crm.GetSingleShow(sql, para));
            return num;
        }

        #endregion

        #region ICompanyShow 成员

        /// <summary>
        /// 添加融资拓富通
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int rzAddShow(CompanyShow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyShow(");
            strSql.Append("UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,RoleId,CompanyName,Countrycode,Provinceid,Cityid,Countyid,OrderId,Recomm,Industry)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@TelPhone,@Mobile,@Email,@Audit,@StartTime,@Valid,@TypeName,@RoleId,@CompanyName,@Countrycode,@Provinceid,@Cityid,@Countyid,@OrderId,@Recomm,@Industry)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarBinary,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
                    new SqlParameter("@TypeName", SqlDbType.VarChar,20),
                	new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@CompanyName", SqlDbType.VarChar,100),

                    new SqlParameter("@Countrycode", SqlDbType.VarChar,20),
                    new SqlParameter("@Provinceid", SqlDbType.VarChar,20),
                    new SqlParameter("@Cityid", SqlDbType.VarChar,20),
                    new SqlParameter("@Countyid", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@Recomm", SqlDbType.VarChar,50),
                    new SqlParameter("@Industry", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Audit;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.Valid;
            parameters[8].Value = model.Typename;
            parameters[9].Value = 4;
            parameters[10].Value = model.CompanyName;

            parameters[11].Value = model.Countrycode;
            parameters[12].Value = model.Provinceid;
            parameters[13].Value = model.Cityid;
            parameters[14].Value = model.Countyid;
            parameters[15].Value = model.OrderId;
            parameters[16].Value = model.Recomm;
            parameters[17].Value = model.Industry;
            object obj = crm.GetSingleShow(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion

        #region ICompanyShow 添加投资拓富通

        /// <summary>
        /// 添加投资拓富通
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int tzAddShow(CompanyShow model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyShow(");
            strSql.Append("UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,RoleId,CompanyName,Countrycode,Provinceid,Cityid,Countyid,OrderId,Recomm,Industry)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@TelPhone,@Mobile,@Email,@Audit,@StartTime,@Valid,@TypeName,@RoleId,@CompanyName,@Countrycode,@Provinceid,@Cityid,@Countyid,@OrderId,@Recomm,@Industry)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarBinary,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
                    new SqlParameter("@TypeName", SqlDbType.VarChar,20),
                	new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@CompanyName", SqlDbType.VarChar,100),

                    new SqlParameter("@Countrycode", SqlDbType.VarChar,20),
                    new SqlParameter("@Provinceid", SqlDbType.VarChar,20),
                    new SqlParameter("@Cityid", SqlDbType.VarChar,20),
                    new SqlParameter("@Countyid", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@Recomm", SqlDbType.VarChar,50),
                    new SqlParameter("@Industry", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Audit;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.Valid;
            parameters[8].Value = model.Typename;
            parameters[9].Value = 5;
            parameters[10].Value = model.CompanyName;

            parameters[11].Value = model.Countrycode;
            parameters[12].Value = model.Provinceid;
            parameters[13].Value = model.Cityid;
            parameters[14].Value = model.Countyid;
            parameters[15].Value = model.OrderId;
            parameters[16].Value = model.Recomm;
            parameters[17].Value = model.Industry;
            object obj = crm.GetSingleShow(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion

        #region ICompanyShow 成员


        public int zfAddShow(CompanyShow model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CompanyShow(");
            strSql.Append("UserName,UserPwd,TelPhone,Mobile,Email,Audit,StartTime,Valid,TypeName,RoleId,CompanyName,Countrycode,Provinceid,Cityid,Countyid,OrderId,Recomm,Industry)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@UserPwd,@TelPhone,@Mobile,@Email,@Audit,@StartTime,@Valid,@TypeName,@RoleId,@CompanyName,@Countrycode,@Provinceid,@Cityid,@Countyid,@OrderId,@Recomm,@Industry)");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserPwd", SqlDbType.VarBinary,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Mobile", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@Valid", SqlDbType.Int,4),
                    new SqlParameter("@TypeName", SqlDbType.VarChar,20),
                	new SqlParameter("@RoleId", SqlDbType.Int,4),
                    new SqlParameter("@CompanyName", SqlDbType.VarChar,100),

                    new SqlParameter("@Countrycode", SqlDbType.VarChar,20),
                    new SqlParameter("@Provinceid", SqlDbType.VarChar,20),
                    new SqlParameter("@Cityid", SqlDbType.VarChar,20),
                    new SqlParameter("@Countyid", SqlDbType.VarChar,20),
                    new SqlParameter("@OrderId", SqlDbType.Int,4),
                    new SqlParameter("@Recomm", SqlDbType.VarChar,50),
                    new SqlParameter("@Industry", SqlDbType.VarChar,50)
            };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserPwd;
            parameters[2].Value = model.TelPhone;
            parameters[3].Value = model.Mobile;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Audit;
            parameters[6].Value = model.StartTime;
            parameters[7].Value = model.Valid;
            parameters[8].Value = model.Typename;
            parameters[9].Value = 6;
            parameters[10].Value = model.CompanyName;

            parameters[11].Value = model.Countrycode;
            parameters[12].Value = model.Provinceid;
            parameters[13].Value = model.Cityid;
            parameters[14].Value = model.Countyid;
            parameters[15].Value = model.OrderId;
            parameters[16].Value = model.Recomm;
            parameters[17].Value = model.Industry;
            object obj = crm.GetSingleShow(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        #endregion
    }
}
