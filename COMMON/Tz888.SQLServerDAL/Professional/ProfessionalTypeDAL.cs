using System;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Professional;
using Tz888.DBUtility;//�����������
namespace Tz888.SQLServerDAL.Professional
{
    public class ProfessionalTypeDAL:ProfessionalTypeIDAL
	{


        #region ProfessionalTypeIDAL ��Ա
        /// <summary>
        /// ��÷�������
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

