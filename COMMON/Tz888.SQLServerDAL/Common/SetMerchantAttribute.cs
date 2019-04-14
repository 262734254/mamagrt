using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Common;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.Common
{
    public class SetMerchantAttribute : ISetMerchantAttribute
    {
        #region ISetMerchantAttribute ≥…‘±

        public DataView GetList()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@MerchantID", SqlDbType.Char,10),
			};
            parameters[0].Value = "Null";
            DataSet ds = DbHelperSQL.RunProcedure("SetMerchanAtributeTab_GetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        #endregion
    }
}
