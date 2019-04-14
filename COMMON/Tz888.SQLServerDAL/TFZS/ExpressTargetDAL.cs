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
    /// 表现指标数据库访问逻辑类
    /// </summary>
    public class ExpressTargetDAL : IExpressTarget
    {
        /// <summary>
        /// 根据主指标代码获取所有对应得表现指标信息列表
        /// </summary>
        /// <param name="mainTargetCode">表现指标代码</param>
        /// <returns>表现指标列表</returns>
        public List<TFZS_ExpressTarget> GetListByMainTargetCode(string mainTargetCode)
        {
            List<TFZS_ExpressTarget> lists = new List<TFZS_ExpressTarget>();
            SqlParameter parm = new SqlParameter("@MainTargetCode", SqlDbType.Char, 30);
            parm.Value = mainTargetCode;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "TFZS_MeasureStandard_GetListByExpressCode", parm))
            {
                while (rdr.Read())
                {
                    TFZS_ExpressTarget item = new TFZS_ExpressTarget();
                    item.ExpressCode = rdr["ExpressCode"].ToString();
                    item.ExpressDescript = rdr["ExpressDescript"].ToString();
                    item.ExpressName = rdr["ExpressName"].ToString();
                    item.ExpressPoint = Convert.ToDecimal(rdr["ExpressPoint"]);
                    item.ExpressRemark = rdr["ExpressRemark"].ToString();
                    item.ExpressType = rdr["ExpressType"].ToString();
                    item.IsMulti = Convert.ToBoolean(rdr["IsMulti"]);
                    item.MainTargetCode = rdr["MainTargetCode"].ToString();
                    item.SortID = Convert.ToInt32(rdr["SortID"]);
                    lists.Add(item);
                }
            }
            return lists;
        }

        /// <summary>
        /// 根据主指标类型获取所有对应得表现指标信息列表
        /// </summary>
        /// <param name="mainTargetType">评价类型(债权ZQ/股权GQ)</param>
        /// <returns>表现指标列表</returns>
        public List<TFZS_ExpressTarget> GetListByMainTargetType(string mainTargetType)
        {
            List<TFZS_ExpressTarget> lists = new List<TFZS_ExpressTarget>();

            SqlParameter parm = new SqlParameter("@MainTargetType", SqlDbType.Char, 30);
            parm.Value = mainTargetType;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "TFZS_ExpressTargetTab_GetListByMainTargetType", parm))
            {
                while (rdr.Read())
                {
                    TFZS_ExpressTarget item = new TFZS_ExpressTarget();
                    item.ExpressCode = rdr["ExpressCode"].ToString();
                    item.ExpressDescript = rdr["ExpressDescript"].ToString();
                    item.ExpressName = rdr["ExpressName"].ToString();
                    item.ExpressPoint = Convert.ToDecimal(rdr["ExpressPoint"]);
                    item.ExpressRemark = rdr["ExpressRemark"].ToString();
                    item.ExpressType = rdr["ExpressType"].ToString();
                    item.IsMulti = Convert.ToBoolean(rdr["IsMulti"]);
                    item.MainTargetCode = rdr["MainTargetCode"].ToString();
                    item.SortID = Convert.ToInt32(rdr["SortID"]);
                    lists.Add(item);
                }
            }
            return lists;
        }
    }
}
