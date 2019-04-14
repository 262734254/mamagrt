using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL
{
    class LoginInfoIMDAL : ILoginInfoIM
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        public string Add(Tz888.Model.LoginInfoIMModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@IMType", SqlDbType.VarChar,20),
					new SqlParameter("@IMAccount", SqlDbType.VarChar,20),
					new SqlParameter("@IsDisable", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.IMType;
            parameters[2].Value = model.IMAccount;
            parameters[3].Value = model.IsDisable;
            parameters[4].Value = model.Remark;
            try
            {
                DbHelperSQL.RunProcedure("UP_LoginInfoIMTab_ADD", parameters, out rowsAffected);
            }
            catch
            { }
            return parameters[0].ToString();
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(Tz888.Model.LoginInfoIMModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@LoginName", SqlDbType.Char,16),
					new SqlParameter("@IMType", SqlDbType.VarChar,20),
					new SqlParameter("@IMAccount", SqlDbType.VarChar,20),
					new SqlParameter("@IsDisable", SqlDbType.TinyInt,1),
					new SqlParameter("@Remark", SqlDbType.VarChar,100)};
            parameters[0].Value = model.LoginName;
            parameters[1].Value = model.IMType;
            parameters[2].Value = model.IMAccount;
            parameters[3].Value = model.IsDisable;
            parameters[4].Value = model.Remark;
            try
            {

                DbHelperSQL.RunProcedure("UP_LoginInfoIMTab_Update", parameters, out rowsAffected);
            }
            catch { }
        }
    }
}
