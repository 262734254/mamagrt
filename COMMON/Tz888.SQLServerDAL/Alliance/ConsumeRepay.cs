using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class ConsumeRepay : IConsumeRepay
    {
        public ConsumeRepay()
        { }
        /// <summary>
        /// 增加一条数据 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Tz888.Model.ConsumeRepay model)
        {
            SqlParameter[] parameters = {  
                    new SqlParameter("@UserName", SqlDbType.VarChar,30),
                    new SqlParameter("@RepayWay", SqlDbType.VarChar,20),
                    new SqlParameter("@RepayMoney", SqlDbType.Float,8),
                    new SqlParameter("@RepayStatus", SqlDbType.Int,4),
                    new SqlParameter("@CreateDate", SqlDbType.DateTime,8),
                    new SqlParameter("@AuditMan",SqlDbType.VarChar,30),
                    new SqlParameter("@RepayDate",SqlDbType.DateTime,8),
                    new SqlParameter("@AuditStatus",SqlDbType.Int,4),
                    new SqlParameter("@AuditDescript",SqlDbType.Text),
                    new SqlParameter("@flag",SqlDbType.VarChar,30),
            };
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.RepayWay;
            parameters[2].Value = model.RepayMoney;
            parameters[3].Value = model.RepayStatus;
            parameters[4].Value = model.Createdate;
            parameters[5].Value = model.AuditMan;
            parameters[6].Value = model.RepayDate;
            parameters[7].Value = model.AuditStatus;
            parameters[8].Value = model.AuditDescript;
            parameters[9].Value = "Insert";
            bool b = DbHelperSQL.RunProcLob("ConsumeRepayInfo", parameters);
            return b;
        }

        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.ConsumeRepay model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@RepayID", SqlDbType.Int,4), 
                    new SqlParameter("@AuditMan",SqlDbType.VarChar,30), 
                    new SqlParameter("@AuditStatus",SqlDbType.Int,4),
                    new SqlParameter("@AuditDescript",SqlDbType.Text),
                    new SqlParameter("@RepayDate",SqlDbType.DateTime,8),
                    new SqlParameter("@flag",SqlDbType.VarChar,30),};
            parameters[0].Value = model.RepayID;    
            parameters[1].Value = model.AuditMan; 
            parameters[2].Value = model.AuditStatus;
            parameters[3].Value = model.AuditDescript;
            parameters[4].Value = model.RepayDate;
            parameters[5].Value = "Update";
            bool b = DbHelperSQL.RunProcLob("ConsumeRepayInfo", parameters);
            return b;
        }

        /// <summary>
        /// 查询用户申请提取信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataTable GetConsumeMess(int RepayID,string UserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@RepayID", SqlDbType.Int,4), 
                    new SqlParameter("@UserName",SqlDbType.VarChar,30),
                　  new SqlParameter("@flag",SqlDbType.VarChar,30),
            };
            parameters[0].Value = RepayID;
            parameters[1].Value = UserName;
            parameters[2].Value = "Select";

            DataSet ds = DbHelperSQL.RunProcedure("ConsumeRepayInfo", parameters,"ds");
            return ds.Tables[0];
        }

        /// <summary>
        /// 查询用户剩余提取额
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataTable GetConsumeMoney(string UserName)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,30), 
            };
            parameters[0].Value = UserName;

            DataSet ds = DbHelperSQL.RunProcedure("RepayMoneyInfo", parameters, "ds");
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取审核状态的会员发放总数
        /// </summary>
        /// <returns></returns>
        public DataTable GetAuditRelealseCount()
        {
            SqlParameter[] parameters = { }; 

            DataSet ds = DbHelperSQL.RunProcedure("Sp_MAuditRelealse", parameters, "ds");
            return ds.Tables[0];
        }

        /// <summary>
        /// 获取发放总数
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllRelealseCount()
        {
            SqlParameter[] parameters = { };

            DataSet ds = DbHelperSQL.RunProcedure("Sp_MAllRelease", parameters, "ds");
            return ds.Tables[0];
        }

    }
}
