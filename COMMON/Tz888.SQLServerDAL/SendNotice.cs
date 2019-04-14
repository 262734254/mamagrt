using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Tz888.IDAL;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL
{
    public class SendNotice : Tz888.IDAL.ISendNotice
    {
        public SendNotice()
        { }
        /// <summary>
        /// 发送手机短信
        /// </summary> 
        /// <param name="mobile">手机号</param>
        /// <param name="Content">发送内容</param>
        /// <returns></returns>
        public bool SendMobileMsg(string mobile, string Content)
        {
            bool ReturnValue = false;

            int rowsAffected = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@TO_MOBILE", SqlDbType.VarChar,50),
											new SqlParameter("@MSG_CONTENT", SqlDbType.VarChar,140),
										
			};
            parameters[0].Value = mobile;
            parameters[1].Value = Content;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnectionSms())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();

                DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Msg_Mobile_Send", parameters, out rowsAffected);
                sqlTran.Commit();
                ReturnValue = true;

            }
            return ReturnValue;
        }

        /// <summary>
        /// 发送手机短信 返回此条数据ID
        /// </summary> 
        /// <param name="mobile">手机号</param>
        /// <param name="Content">发送内容</param>
        /// <returns></returns>
        public int SendMobileSms(string mobile, string Content)
        {
            //bool ReturnValue = false;
            int dymsgID = 0;//返回当然数据ID
            int rowsAffected = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@TO_MOBILE", SqlDbType.VarChar,50),
											new SqlParameter("@MSG_CONTENT", SqlDbType.VarChar,140),
										
			};
            parameters[0].Value = mobile;
            parameters[1].Value = Content;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnectionSms())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();

                dymsgID = DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Msg_Mobile_Send", parameters, out rowsAffected);
                sqlTran.Commit();
                // ReturnValue = true;

            }
            return dymsgID;
        }

        /// <summary>
        /// 更新用户短信数量
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public bool UpdateMobileCount(string LoginName)
        {
            bool ReturnValue = false;
            int rowsAffected = 0;
            SqlParameter[] parameters = {
											new SqlParameter("@LoginName", SqlDbType.VarChar,16),										
			};
            parameters[0].Value = LoginName;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnection())
            {
                sqlConn.Open();
                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                try
                {
                    DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Msg_Mobile_Send", parameters, out rowsAffected);
                    sqlTran.Commit();
                    ReturnValue = true;
                }
                catch
                {
                    sqlTran.Rollback();
                    ReturnValue = false;
                }
                finally
                {
                    sqlConn.Close();
                }
            }
            return ReturnValue;
        }

        /// <summary>
        /// 更改已发送短信状态
        /// </summary>
        /// <param name="ID">短信ID</param>
        /// <returns></returns>
        public bool UPdateSms(string ID)
        {
            bool ReturnValue = false;
            int rowsAffected = 0;
            SqlParameter[] parameters ={
                                   new SqlParameter("@dymsgID",SqlDbType.Int),
              };
            parameters[0].Value = ID;
            using (SqlConnection sqlConn = DbHelperSQL.GetSqlConnectionSms())
            {
                sqlConn.Open();

                SqlTransaction sqlTran = sqlConn.BeginTransaction();
                DbHelperSQL.RunProcedure(sqlConn, sqlTran, "Msg_Mobile_UPdate", parameters, out rowsAffected);
                sqlTran.Commit();

                ReturnValue = true;

            }

            return ReturnValue;

        }
    }
}
