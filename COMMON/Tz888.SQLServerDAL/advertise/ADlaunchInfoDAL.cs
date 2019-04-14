using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL.advertise;
using Tz888.Model.advertise;

namespace Tz888.SQLServerDAL.advertise
{
    public class ADlaunchInfoDAL : IADlaunchInfo
    {
        #region IADlaunchInfo ≥…‘±

        public  string SelBName(int id)
        {
            string name;
            string sql = "select BName from ADchannelInfo where BID=@id";
            SqlParameter[] para ={ 
                new SqlParameter("@id",SqlDbType.Int,8)
            };
            para[0].Value = id;
            name = Convert.ToString(DbHelperSQL.GetSingle(sql, para).ToString());
            return name;
        }

        #endregion
    }
}
