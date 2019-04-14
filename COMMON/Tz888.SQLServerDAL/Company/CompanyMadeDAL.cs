using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Company
{
   public  class CompanyMadeDAL:Tz888.IDAL.Company.ICompanyMade
   {
       Tz888.DBUtility.CrmDBHelper crm = new Tz888.DBUtility.CrmDBHelper();
       #region  成员方法
       /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Tz888.Model.Company.CompanyMadeModel model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CompanyMadeTab(");
            strSql.Append("CompanyID,Price,SumPrice,UserName,CreateDate,BeginTime,EndTime,LinkName,TelPhone,Email,Audit,AuditName,Hit,VisitHit)");
			strSql.Append(" values (");
            strSql.Append("@CompanyID,@Price,@SumPrice,@UserName,@CreateDate,@BeginTime,@EndTime,@LinkName,@TelPhone,@Email,@Audit,@AuditName,@Hit,@VisitHit)");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyID", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.VarChar,100),
					new SqlParameter("@SumPrice", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@AuditName", SqlDbType.VarChar,50),
                    new SqlParameter("@Hit", SqlDbType.Int,4),
                    new SqlParameter("@VisitHit", SqlDbType.Int,4)
            };  
			parameters[0].Value = model.CompanyID;
			parameters[1].Value = model.Price;
			parameters[2].Value = model.SumPrice;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.CreateDate;
			parameters[5].Value = model.BeginTime;
			parameters[6].Value = model.EndTime;
			parameters[7].Value = model.LinkName;
			parameters[8].Value = model.TelPhone;
			parameters[9].Value = model.Email;
			parameters[10].Value = model.Audit;
			parameters[11].Value = model.AuditName;
            parameters[12].Value = model.Hit;
            parameters[13].Value = model.VisitHit;

            object obj = crm.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
       public int Update(Tz888.Model.Company.CompanyMadeModel model,int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CompanyMadeTab set ");
            strSql.Append("CompanyID=@CompanyID,");
            strSql.Append("Price=@Price,");
            strSql.Append("SumPrice=@SumPrice,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("CreateDate=@CreateDate,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("LinkName=@LinkName,");
            strSql.Append("TelPhone=@TelPhone,");
            strSql.Append("Email=@Email,");
            strSql.Append("Audit=@Audit,");
            strSql.Append("AuditName=@AuditName,");
            strSql.Append("Hit=@Hit,");
            strSql.Append("VisitHit=@VisitHit");
            strSql.Append(" where MadeID=@MadeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MadeID", SqlDbType.Int,4),
					new SqlParameter("@CompanyID", SqlDbType.VarChar,50),
					new SqlParameter("@Price", SqlDbType.VarChar,100),
					new SqlParameter("@SumPrice", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@CreateDate", SqlDbType.DateTime),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@LinkName", SqlDbType.VarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.VarChar,50),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Audit", SqlDbType.Int,4),
					new SqlParameter("@AuditName", SqlDbType.VarChar,50),
					new SqlParameter("@Hit", SqlDbType.Int,4),
					new SqlParameter("@VisitHit", SqlDbType.Int,4)};
            model.MadeID = id;
            parameters[0].Value = model.MadeID;
            parameters[1].Value = model.CompanyID;
            parameters[2].Value = model.Price;
            parameters[3].Value = model.SumPrice;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = model.BeginTime;
            parameters[7].Value = model.EndTime;
            parameters[8].Value = model.LinkName;
            parameters[9].Value = model.TelPhone;
            parameters[10].Value = model.Email;
            parameters[11].Value = model.Audit;
            parameters[12].Value = model.AuditName;
            parameters[13].Value = model.Hit;
            parameters[14].Value = model.VisitHit;

            object obj = crm.GetSingle(strSql.ToString(), parameters);
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
        /// 删除一条数据
        /// </summary>
        public int Delete(int MadeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CompanyMadeTab ");
            strSql.Append(" where MadeID=@MadeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MadeID", SqlDbType.Int,4)};
            parameters[0].Value = MadeID;

            int num = Convert.ToInt32(crm.GetSingle(strSql.ToString(), parameters));
            return num;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
       public Tz888.Model.Company.CompanyMadeModel GetModel(int MadeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 MadeID,CompanyID,Price,SumPrice,UserName,CreateDate,BeginTime,EndTime,LinkName,TelPhone,Email,Audit,AuditName,Hit,VisitHit from CompanyMadeTab ");
            strSql.Append(" where MadeID=@MadeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MadeID", SqlDbType.Int,4)};
            parameters[0].Value = MadeID;

            Tz888.Model.Company.CompanyMadeModel model = new Tz888.Model.Company.CompanyMadeModel();
            DataSet ds = crm.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MadeID"].ToString() != "")
                {
                    model.MadeID = int.Parse(ds.Tables[0].Rows[0]["MadeID"].ToString());
                }
                model.CompanyID = ds.Tables[0].Rows[0]["CompanyID"].ToString();
                model.Price = ds.Tables[0].Rows[0]["Price"].ToString();
                model.SumPrice = ds.Tables[0].Rows[0]["SumPrice"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                model.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();
                model.TelPhone = ds.Tables[0].Rows[0]["TelPhone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["Audit"].ToString() != "")
                {
                    model.Audit = int.Parse(ds.Tables[0].Rows[0]["Audit"].ToString());
                }
                model.AuditName = ds.Tables[0].Rows[0]["AuditName"].ToString();
                if (ds.Tables[0].Rows[0]["Hit"].ToString() != "")
                {
                    model.Hit = int.Parse(ds.Tables[0].Rows[0]["Hit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VisitHit"].ToString() != "")
                {
                    model.VisitHit = int.Parse(ds.Tables[0].Rows[0]["VisitHit"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        #region 分页查询
        /// <summary>
        /// 用test数据库
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

            parameters[0].Value = TableViewName;
            parameters[1].Value = Key;
            parameters[2].Value = SelectStr;
            parameters[3].Value = Criteria;
            parameters[4].Value = Sort;
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;

            DataSet ds = crm.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables["ds"];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }
        #endregion 

        #endregion
    }
}
