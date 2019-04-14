using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Common;
using Tz888.IDAL.Common;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Common
{
    /// <summary>
    /// 行业类型信息数据库访问逻辑类
    /// </summary>
    public class IndustryDAL : IIndustry
    {
        /// <summary>
        /// 取得行业分类的所有列表
        /// </summary>
        /// <returns>行业分类列表</returns>
        public List<IndustryModel> GetAllList()
        {
            List<IndustryModel> lists = new List<IndustryModel>();
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "SetIndustryBTab_GetAllList",null))
            {
                while (rdr.Read())
                {
                    IndustryModel item = new IndustryModel(rdr.GetString(0).Trim(), rdr.GetString(1).Trim(), "", rdr.GetInt32(3));
                    lists.Add(item);
                }
            }
            return lists;
        }
        
        /// <summary>
        /// 根据行业代码获取行业名称
        /// </summary>
        /// <param name="IndustryID">行业代码</param>
        /// <returns></returns>
        public string GetNameByID(string IndustryID)
        {
            SqlParameter para = new SqlParameter("@IndustryBID", SqlDbType.Char, 10);
            para.Value = IndustryID;
            return Convert.ToString(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "SetIndustryBTab_GetNameByID", para));
        }

        /// <summary>
        /// 修改时取表中行业值
        /// </summary>
        /// <param name="IndustryID">返回list</param>
        /// <returns></returns>        
        public List<IndustryModel> GetIndustryList(string IndustryList)
        {
            string[] arrType = IndustryList.Split(',');
            List<IndustryModel> lists = new List<IndustryModel>();
            for (int i = 0; i < arrType.Length; i++)
            {
                SqlParameter para = new SqlParameter("@IndustryBID", SqlDbType.Char, 16);
                para.Value = arrType[i];

                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "SetIndustryBTab_GetListById", para))
                {
                    while (rdr.Read())
                    {
                        IndustryModel item = new IndustryModel(arrType[i], rdr.GetString(1).Trim(), "", rdr.GetInt32(3));
                        lists.Add(item);
                    }
                }
            }
            return lists;
        }

        /// <summary>
        /// 获取所有行业信息
        /// </summary>
        /// <returns></returns>
        public DataView dvGetAllIndustry()
        {
            string sql = "select * from SetIndustryBTab order by IndustryBID asc ";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
    }
}
