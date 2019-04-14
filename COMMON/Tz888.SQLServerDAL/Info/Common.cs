using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Info;
using Tz888.IDAL.Info;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// 信息处理公共数据库访问逻辑类
    /// </summary>
    public class Common : ICommon 
    {
        /// <summary>
        /// 获取所有项目合作类型
        /// </summary>
        /// <returns>合作类型列表</returns>
        public List<CooperationDemandTypeModel> GetCooperationDemandList(string InfoType)
        {
            List<CooperationDemandTypeModel> lists = new List<CooperationDemandTypeModel>();
            SqlParameter[] parameters = { new SqlParameter("@InfoType",SqlDbType.Char,10),
            };
            parameters[0].Value = InfoType;
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "CooperationDemandTypeTab_GetList", parameters))
            {
                while (rdr.Read())
                {
                    CooperationDemandTypeModel item = new CooperationDemandTypeModel(rdr.GetString(0).Trim(), rdr.GetString(1).Trim(),rdr.GetString(2).Trim());
                    lists.Add(item);
                }
            }
            return lists;
        }

        /// <summary>
        /// 获取所有招商类型
        /// </summary>
        /// <returns></returns>
        public List<Tz888.Model.Info.MerchantAttributeModel> GetMerchantAttributeList()
        {
            List<MerchantAttributeModel> lists = new List<MerchantAttributeModel>();
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "SetMerchantAttributeTab_GetList", null))
            {
                while (rdr.Read())
                {
                    MerchantAttributeModel item = new MerchantAttributeModel(rdr.GetString(0).Trim(), rdr.GetString(1).Trim());
                    lists.Add(item);
                }
            }
            return lists;
        }

        /// <summary>
        /// 获取信息类型所对应的代码
        /// </summary>
        /// <param name="InfoTypeID">信息类型</param>
        /// <returns></returns>
        public string GetInfoTypeCode(string InfoTypeID)
        {
            string infoTypeCode = "";
            SqlParameter parm = new SqlParameter("@InfoTypeID", SqlDbType.Char, 10);
            parm.Value = InfoTypeID;
            infoTypeCode = Convert.ToString(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "SetInfoTypeTab_GetInfoTypeCode", parm));
            return infoTypeCode;
        }



      
    }
}
