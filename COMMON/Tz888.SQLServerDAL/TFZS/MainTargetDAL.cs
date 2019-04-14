using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;
using Tz888.IDAL.TFZS;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.TFZS
{
    /// <summary>
    /// 主指标数据库访问逻辑类
    /// </summary>
    public class MainTargetDAL : IMainTarget
    {
        /// <summary>
        /// 根据评估类型获取主指标列表
        /// </summary>
        /// <param name="mainTargetType">评估类型代码：债权->ZQ 股权->GQ</param>
        /// <returns>对应评估类型的所有主指标信息</returns>
        public List<TFZS_MainTarget> GetListByTargetType(string mainTargetType)
        {
            List<TFZS_MainTarget> lists = new List<TFZS_MainTarget>();
            SqlParameter parm = new SqlParameter("@MainTargetType", SqlDbType.Char, 30);
            parm.Value = mainTargetType;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "TFZS_MainTargetTab_GetListByTargetType", parm))
            {
                while (rdr.Read())
                {
                    TFZS_MainTarget item = new TFZS_MainTarget(rdr.GetString(0), rdr.GetInt32(1), rdr.GetString(2), rdr.GetString(3), rdr.GetDecimal(4), rdr.GetString(5), rdr.GetString(6));
                    lists.Add(item);
                }
            }
            return lists;
        }

        /// <summary>
        /// 获取单项拓富指数成绩
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="MainCode"></param>
        /// <returns></returns>
        public decimal GetEvaluateCount(long InfoID, string DicMainCode)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@DicMainCode", SqlDbType.Char,30),
                    new SqlParameter("@EvaluateCount",SqlDbType.Decimal)
            };
            parameters[0].Value = InfoID;
            parameters[1].Value = DicMainCode;
            parameters[2].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("TFZS_MainTarge_GetCount", parameters, out rowsAffected);
            return (decimal)parameters[2].Value;
        }
    }
}
