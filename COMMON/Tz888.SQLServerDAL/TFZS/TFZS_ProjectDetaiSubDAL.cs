using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.TFZS;
using Tz888.Model.TFZS;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.TFZS
{
    public class TFZS_ProjectDetaiSubDAL : ITFZS_ProjectDetaiSub
    {
        #region ITFZS_ProjectDetaiSub ≥…‘±

        public decimal Save(Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel model, bool IsSave)
        {
            int rowsAffected;
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt,8),
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@DicMainCode", SqlDbType.Char,30),
					new SqlParameter("@ExpressCode", SqlDbType.Char,30),
					new SqlParameter("@TARGET_ANSWER", SqlDbType.VarChar,200),
					new SqlParameter("@TARGET_POINT", SqlDbType.Decimal,5),
                    new SqlParameter("@IsSave", SqlDbType.Bit),
                    new SqlParameter("@Point",SqlDbType.Decimal),
            };
            parameters[0].Direction = ParameterDirection.Output;
			parameters[1].Value = model.InfoID;
			parameters[2].Value = model.DicMainCode;
			parameters[3].Value = model.ExpressCode;
			parameters[4].Value = model.TARGET_ANSWER;
			parameters[5].Value = model.TARGET_POINT;
            parameters[6].Value = IsSave;
            parameters[7].Direction = ParameterDirection.Output;

            DbHelperSQL.RunProcedure("TFZS_ProjectDetaiSubTab_Save", parameters, out rowsAffected);
            return (decimal)parameters[7].Value;
        }

        #endregion
    }
}
