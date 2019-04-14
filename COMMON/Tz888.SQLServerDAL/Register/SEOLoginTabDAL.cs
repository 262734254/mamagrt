using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Register
{
    public class SEOLoginTabDAL : Tz888.IDAL.Register.ISEOLoginTab  
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(Tz888.Model.Register.SEOLoginTabModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@SEOLoginID", SqlDbType.Int,4),
					new SqlParameter("@Title", SqlDbType.VarChar,100),
					new SqlParameter("@SubTitle", SqlDbType.VarChar,100),
					new SqlParameter("@Keyword", SqlDbType.VarChar,100),
					new SqlParameter("@Summary", SqlDbType.Text),
					new SqlParameter("@LoginID", SqlDbType.Int,4)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.SubTitle;
            parameters[3].Value = model.Keyword;
            parameters[4].Value = model.Summary;
            parameters[5].Value = model.LoginID;

            DbHelperSQL.RunProcedure("UP_SEOLoginTab_ADD", parameters, out rowsAffected);
          //  return (int)parameters[0].Value;
        }

    }
}
