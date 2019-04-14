using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;
using Tz888.IDAL;

namespace Tz888.SQLServerDAL
{
    public class Log : ILog
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public bool Insert(Tz888.Model.LogModel model)
        {
            long LogID;

            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.BigInt,8),
					new SqlParameter("@DateTime", SqlDbType.DateTime),
					new SqlParameter("@ThreadID", SqlDbType.BigInt,8),
					new SqlParameter("@SettingID", SqlDbType.Int,4),
					new SqlParameter("@Message", SqlDbType.VarChar,500),
					new SqlParameter("@Level", SqlDbType.TinyInt,1),
					new SqlParameter("@EventType", SqlDbType.TinyInt,1),
					new SqlParameter("@LoginName", SqlDbType.Char,10)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.DateTime;
            parameters[2].Value = model.ThreadID;
            parameters[3].Value = model.SettingID;
            parameters[4].Value = model.Message;
            parameters[5].Value = model.Level;
            parameters[6].Value = model.EventType;
            parameters[7].Value = model.LoginName;

            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringOrderDistributedTransaction, CommandType.StoredProcedure, "LogTab_Insert", parameters);
                
            LogID = (long)parameters[0].Value;

            if (LogID > 0)
                return true;
            return false;
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(long LogID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@LogID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = LogID;

            rowsAffected = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionStringOrderDistributedTransaction, CommandType.StoredProcedure, "LogTab_Delete", parameters);

            if (rowsAffected > 0)
                return true;
            return false;
        }
    }
}
