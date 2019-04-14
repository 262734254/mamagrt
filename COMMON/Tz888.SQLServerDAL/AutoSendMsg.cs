using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL
{
    public class AutoSendMsg:IAutoSendMsg
    {

        #region 巨澜短信
        /// <summary>
        /// 巨澜短信
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SendMobileMsg(string LoginName, string To_Mobile, string Content)
        {
            bool b = false;
            SqlParameter[] parameters = {
                   
					new SqlParameter("@TO_MOBILE", SqlDbType.VarChar,50),
					new SqlParameter("@MSG_CONTENT", SqlDbType.VarChar,140),
                    new SqlParameter("@LoginName",SqlDbType.VarChar,16),
				};

            parameters[0].Value = To_Mobile;
            parameters[1].Value = Content;
            parameters[2].Value = LoginName;
            try
            {
                b = DbHelperSQL.RunProcLob("Msg_Mobile_Send", parameters);
            }
            catch
            {
            }
            return b;
        }
        #endregion

        #region 方标短信
        #endregion
    }
}
