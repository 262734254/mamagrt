using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// 数据访问类MerchantSiteTab 。
    /// </summary>
    public class MerchantSite : IMerchantSite
    {
        public MerchantSite()
        { }
        #region  成员方法

        /// <summary>
        ///  增加一条记录
        /// </summary>
        public int Add(Tz888.Model.MerchantSite model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					new SqlParameter("@SiteTitle", SqlDbType.VarChar,50),
					new SqlParameter("@SiteUrl", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
					new SqlParameter("@Email", SqlDbType.VarChar,30),
					new SqlParameter("@PostLoginName", SqlDbType.VarChar,16),
					new SqlParameter("@AuditStatus", SqlDbType.Int,4),
					new SqlParameter("@AuditLoginName", SqlDbType.VarChar,16)};
            parameters[0].Value = "Insert";
            parameters[1].Value = model.SiteTitle;
            parameters[2].Value = model.SiteUrl;
            parameters[3].Value = model.ProvinceID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.CountyID;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.PostLoginName;
            parameters[8].Value = model.AuditStatus;
            parameters[9].Value = model.AuditLoginName;

            DbHelperSQL.RunProcedure("MerchantSite", parameters, out rowsAffected);
            return rowsAffected;
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public int Update(Tz888.Model.MerchantSite model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SiteTitle", SqlDbType.VarChar,50),
					new SqlParameter("@SiteUrl", SqlDbType.VarChar,50),
					new SqlParameter("@ProvinceID", SqlDbType.VarChar,10),
					new SqlParameter("@CityID", SqlDbType.VarChar,10),
					new SqlParameter("@CountyID", SqlDbType.VarChar,10),
                    new SqlParameter("@flag", SqlDbType.VarChar,30),
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SiteTitle;
            parameters[2].Value = model.SiteUrl;
            parameters[3].Value = model.ProvinceID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.CountyID;
            parameters[6].Value = "Update";
            

            DbHelperSQL.RunProcedure("MerchantSite", parameters, out rowsAffected);
            return rowsAffected;
        }
        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Status">审核状态</param>
        /// <param name="AuditLoginName">审核人</param>
        /// <returns></returns>
        public int Auditing(int ID, int AuditStatus,string AuditLoginName)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@AuditStatus", SqlDbType.Int),
					new SqlParameter("@AuditLoginName", SqlDbType.VarChar,16),
					new SqlParameter("@flag", SqlDbType.VarChar,30),
					
            };
            parameters[0].Value = ID;
            parameters[1].Value = AuditStatus;
            parameters[2].Value = AuditLoginName;
            parameters[3].Value ="Auditing";
           

            DbHelperSQL.RunProcedure("MerchantSite", parameters, out rowsAffected);
            return rowsAffected;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@flag", SqlDbType.VarChar,30),
				};
            parameters[0].Value = ID;
            parameters[1].Value = "Delete";
            DbHelperSQL.RunProcedure("MerchantSite", parameters, out rowsAffected);
            return rowsAffected;
        }

        #endregion  成员方法
    }
}

