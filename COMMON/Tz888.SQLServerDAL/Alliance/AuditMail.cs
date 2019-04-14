using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class AuditMail:IAuditMail
    {
        /// <summary>
        /// 根据条件统计信息数目
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string InfoType, string strWhere)
        {
            string SpName = "MConsumeRepayViw";

            switch (InfoType.ToLower())
            {
                case "consumerepay":
                    SpName = "MConsumeRepayViw";
                    return GetCount(SpName, "RepayID", strWhere); 
 
                default:
                    return 0; 
            }

        }


        public int GetCount(string tblName, string fldName, string strWhere)
        {
            SqlParameter[] Parameters = new SqlParameter[]{
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															 new  SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
															 new  SqlParameter("@fldName",SqlDbType.VarChar,255),
															 new  SqlParameter("@PageSize",SqlDbType.Int,4),
															 new  SqlParameter("@PageIndex",SqlDbType.Int,4),
															 new  SqlParameter("@doCount",SqlDbType.Bit),
															 new  SqlParameter("@OrderType",SqlDbType.Bit),
															 new  SqlParameter("@strWhere",SqlDbType.VarChar,1500)
														 };
            Parameters[0].Value = tblName;
            Parameters[1].Value = fldName;
            Parameters[2].Value = fldName;
            Parameters[3].Value = 1;
            Parameters[4].Value = 1;
            Parameters[5].Value = 1;
            Parameters[6].Value = 0;
            Parameters[7].Value = strWhere;

            DataSet ds = DbHelperSQL.RunProcedure("Sp_Conn_Sort", Parameters, "ds");

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

    }
}

