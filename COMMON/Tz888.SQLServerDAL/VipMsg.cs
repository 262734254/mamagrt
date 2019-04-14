using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Security.Cryptography;
namespace Tz888.SQLServerDAL
{
    public class VipMsg:IVipMsg
    {
        public int Add(Tz888.Model.VipMsg model )
        {
            
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,16),
					new SqlParameter("@srcMobile", SqlDbType.VarChar,20),
					new SqlParameter("@spMobile", SqlDbType.VarChar,20),
					new SqlParameter("@Msg", SqlDbType.VarChar,50),
					new SqlParameter("@gateway", SqlDbType.Int,4),
					new SqlParameter("@svid", SqlDbType.VarChar,10),
					new SqlParameter("@linkID", SqlDbType.VarChar,20),
					new SqlParameter("@MsgID", SqlDbType.VarChar,10),
					new SqlParameter("@CPID", SqlDbType.VarChar,10),
					new SqlParameter("@Status", SqlDbType.Int,4),
                    new SqlParameter("@returnStatus", SqlDbType.Int,4),
					};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.srcMobile;
            parameters[2].Value = model.spMobile;
            parameters[3].Value = model.Msg;
            parameters[4].Value = model.gateway;
            parameters[5].Value = model.svid;
            parameters[6].Value = model.linkID;
            parameters[7].Value = model.MsgID;
            parameters[8].Value = model.CPID;
            parameters[9].Value = model.Status;
            parameters[10].Direction = ParameterDirection.Output;
            int i= DbHelperSQL.RunProcReturn("VipMsgTry", parameters);

            return i;
        }

        #region 错误日志
        public int InsertError(string LoginName, string ErrorMsg)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.VarChar,16),
					new SqlParameter("@ErrorMsg", SqlDbType.VarChar,200),
					};
            parameters[0].Value = LoginName;
            parameters[1].Value = ErrorMsg;
            int i = DbHelperSQL.RunProcReturn("VipMsgTryErrorLog", parameters);
            return i;
        }

        #endregion
        #region 验证登录密码
        public DataTable valiLoginPwd(string LoginName, string LoginPwd)
        {
            DataSet ds = null;
            SHA1 sha1 = SHA1.Create();
            byte[] bytePassword = sha1.ComputeHash(Encoding.Unicode.GetBytes(LoginPwd));
            SqlParameter[] parameters = {
				
											new SqlParameter("@LoginName", SqlDbType.Char,16),
											new SqlParameter("@PayPassword", SqlDbType.VarBinary,50),
											new SqlParameter("@flag", SqlDbType.VarChar,50),
			};

            parameters[0].Value = LoginName;
            parameters[1].Value = bytePassword;
            parameters[2].Value = "valiloginpwd";
            try
            {
                ds = DbHelperSQL.RunProcedure("PayPwd", parameters, "ds");
            }
            catch
            { }
            return ds.Tables[0];
        }
        #endregion
    }
}
