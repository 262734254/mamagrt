using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Collections.Generic;

namespace Tz888.SQLServerDAL
{
    public class Finance : IFinance
    {
        //生成网站信息数据
        public bool SiteInfoInsert()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            bool b = DbHelperSQL.RunProcLob("AccountSiteInfoTab_Calc", parameters);
            return b;
        }
        //网站信息
        public DataTable SiteInfoList()
        {
            SqlParameter[] parameters = { new  SqlParameter("@flag",SqlDbType.VarChar,20),
            };
            parameters[0].Value = "site";
            DataSet  ds = DbHelperSQL.RunProcedure("AccountStatistics", parameters, "ds");
            return ds.Tables[0];
        }
        //生成财务统计信息
        public bool PayInfoInsert()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            bool b = DbHelperSQL.RunProcLob("AccountManagerInfoTab_Calc", parameters);
            return b;
        }
        //财务信息
        public DataTable PayInfoList()
        {
            SqlParameter[] parameters = { new SqlParameter("@flag", SqlDbType.VarChar, 20), };
            parameters[0].Value = "finance";
            DataSet ds = DbHelperSQL.RunProcedure("AccountStatistics", parameters, "ds");
            return ds.Tables[0];
        }        
    }
}
