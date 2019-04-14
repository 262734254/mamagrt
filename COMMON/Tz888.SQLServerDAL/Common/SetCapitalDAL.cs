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
    public class SetCapitalDAL : ISetCapital
    {

        #region ISetCapital ≥…‘±

        public DataView GetList()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CapitalID", SqlDbType.Char,10),
			};
            parameters[0].Value = "Null";
            DataSet ds = DbHelperSQL.RunProcedure("SetCapitalTab_GetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        #endregion
    }
}
