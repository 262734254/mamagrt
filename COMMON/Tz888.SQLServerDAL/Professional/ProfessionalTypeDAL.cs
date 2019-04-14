using System;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Professional;
using Tz888.DBUtility;//请先添加引用
namespace Tz888.SQLServerDAL.Professional
{
    public class ProfessionalTypeDAL:ProfessionalTypeIDAL
	{


        #region ProfessionalTypeIDAL 成员
        /// <summary>
        /// 获得服务类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetTypeAll()
        {
            string sql = "SELECT * FROM ProfessionalTypeTbl";
            return DbHelperSQL.ExecuteQuery(sql);
        }

        #endregion
    }
}

