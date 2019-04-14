using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Common;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Common
{
    public class SetCurrencyDAL : ISetCurrency
    {
        #region ISetCurrency ≥…‘±

        public DataView GetList()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CurrencyID", SqlDbType.Char,10),
			};
            parameters[0].Value = "Null";
            DataSet ds = DbHelperSQL.RunProcedure("SetCurrencyTab_GetAllList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        #endregion
    }
}
