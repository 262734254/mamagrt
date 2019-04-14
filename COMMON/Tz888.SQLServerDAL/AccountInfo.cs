using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class AccountInfo:IAccountInfo
    {
        #region 帐户信息
        /// <summary>
        /// 帐户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable GetAccountInfo(string LoginName)
        {
            DataSet  ds = null;
            SqlParameter[] parameters = {
                    new SqlParameter("@LoginName",SqlDbType.VarChar,16),
				};         
            parameters[0].Value = LoginName;
            try
            {
                ds = DbHelperSQL.RunProcedure("accountinfo", parameters,"ds");
            }
            catch
            {
            }
            return ds.Tables[0];
        }
        #endregion
    }
}
