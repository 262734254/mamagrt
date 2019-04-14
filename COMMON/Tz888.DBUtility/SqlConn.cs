using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Tz888.DBUtility
{
    /// <summary>
    /// SqlConn 的摘要说明。
    /// </summary>
    public class SqlConn
    {
        private string cn = null;                              //用于数据库连接的字符串
        private SqlConnection SqlCn = null;                    //用于数据库连接的字符串 
        private SqlTransaction Sqltx = null;				   //用于数据库连接的事务处理	
        private SqlCommand cmd = new SqlCommand();             //用于数据库对象SqlCommand
        private SqlDataAdapter Da = new SqlDataAdapter();      //用于数据库对象SqlDataAdapter

        #region  默认构造函数
        public SqlConn()
        {
            cn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        }

        /// <summary>
        /// 连接构造函数
        /// </summary>
        /// <param name="connString">在WEB.CONFIG定义的连接字符串的KEY</param>
        public SqlConn(string connString)
        {
            cn = System.Configuration.ConfigurationSettings.AppSettings[connString];
        }
        #endregion

        #region 创建数据库连接对象并返回连接
        public SqlConnection GetConnection()
        {
            try
            {
                SqlCn = new SqlConnection(this.cn);
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand("SET LOCK_TIMEOUT 4000", SqlCn);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            catch (SqlException sqlex)
            {
                throw (sqlex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return SqlCn;
        }
        #endregion

        #region 创建手机短信通知数据库链接对象并返回链接
        public SqlConnection GetConnectionSMS()
        {
            try
            {
                SqlCn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["SmsConnectionString"]);
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand("SET LOCK_TIMEOUT 2000", SqlCn);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            catch (SqlException sqlex)
            {
                throw (sqlex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return SqlCn;
        }
        #endregion

        #region 创建论坛数据库连接对象并返回连接
        public SqlConnection GetConnectionForums()
        {
            try
            {
                SqlCn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ForumsConnectionString"]);
                SqlCn.Open();

                SqlCommand cmd = new SqlCommand("SET LOCK_TIMEOUT 3000", SqlCn);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                cmd.Dispose();
            }
            catch (SqlException sqlex)
            {
                throw (sqlex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return SqlCn;
        }
        #endregion

        #region 关闭数据库的连接对象
        public void CloseCn()
        {
            try
            {
                if (Sqltx != null)
                {
                    //释放事物处理
                    Sqltx.Dispose();
                }

                if (SqlCn.State != ConnectionState.Closed)
                {
                    //关闭连接
                    SqlCn.Close();
                    SqlCn = null;
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        #endregion

        #region 创建SQL Command对象，并返回该对象
        /// <summary>
        /// 创建SQL Command对象，并返回该对象
        /// </summary>
        /// <param name="procName">要操作的存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <param name="IsUseTransaction">是否使用事物处理</param>
        /// <returns>创建的SqlCommand对象</returns>
        public SqlCommand CreateCommand(string procName, SqlParameter[] prams, bool IsUseTransaction)
        {
            ///此处原来没有，考虑到在其他函数调用此函数的返回值为局部变量，而此处却使用
            ///公有变量，会导致连续调用两次该函数就会出现参数过多的错误！所以把变量定义
            ///为局部变量
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.SqlCn;
            cmd.CommandText = procName;
            cmd.CommandTimeout = 180;
            if (IsUseTransaction)
            {
                ///设置事物处理
                cmd.Transaction = this.Sqltx;
            }

            cmd.CommandType = CommandType.StoredProcedure;
            if (prams != null)
            {
                foreach (SqlParameter parmeter in prams)
                {
                    cmd.Parameters.Add(parmeter);
                }
            }
            return cmd;
        }
        #endregion

        #region 运行指定的存储过程返回DataTable
        /// <summary>
        /// 运行指定的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <returns></returns>
        public DataTable RunProc(
            string procName,
            SqlParameter[] prams,
            bool IsUseTransaction,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            DataSet Ds = new DataSet();
            try
            {
                if (IsUseTransaction)
                {
                    ///建立事物处理
                    Sqltx = SqlCn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                }

                SqlCommand cmd = CreateCommand(procName, prams, IsUseTransaction);
                cmd.Prepare();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Ds);

                da.Dispose();
                cmd.Dispose();

                if (IsUseTransaction)
                {
                    //提交事物
                    Sqltx.Commit();
                }
            }
            catch (SqlException sqlex)
            {
                // Specific catch for deadlock
                if (sqlex.Number != 1205)
                {
                    if (IsUseTransaction && Sqltx != null)
                    {
                        //回滚事物
                        Sqltx.Rollback();
                    }
                }
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(sqlex.Number.ToString(), sqlex.Message);
                ErrorID = sqlex.Number;
                if (ErrorMsg == "")
                {
                    throw (sqlex);
                }
                else
                {
                    return (null);
                }
            }
            catch (Exception ex)
            {
                if (IsUseTransaction && Sqltx != null)
                {
                    //回滚事物
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return Ds.Tables[Ds.Tables.Count - 1];
        }
        #endregion

        #region 运行指定的存储过程
        /// <summary>
        /// 运行指定的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <returns></returns>
        public bool RunProcLob(
            string procName,
            SqlParameter[] prams,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            DataSet Ds = new DataSet();
            bool blret = false;
            try
            {
                ///建立事物处理
                Sqltx = SqlCn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = CreateCommand(procName, prams, true);
                cmd.Prepare();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Ds);
                blret = true;

                da.Dispose();
                cmd.Dispose();
                Sqltx.Commit();
            }
            catch (SqlException sqlex)
            {
                // Specific catch for deadlock
                if (sqlex.Number != 1205)
                {
                    if (Sqltx != null)
                    {
                        //回滚事物
                        Sqltx.Rollback();
                    }
                }
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(sqlex.Number.ToString(), sqlex.Message);
                ErrorID = sqlex.Number;
                if (ErrorMsg == "")
                {
                    throw (sqlex);
                }
                else
                {
                    return (false);
                }
            }
            catch (Exception ex)
            {
                if (Sqltx != null)
                {
                    //回滚事物
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }
        /// <summary>
        /// 运行指定的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <param name="IsUseTransaction">是否使用事物处理</param>
        /// <returns></returns>
        public bool RunProcLob(
            string procName,
            SqlParameter[] prams,
            bool IsUseTransaction,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            DataSet Ds = new DataSet();
            bool blret = false;
            try
            {
                if (IsUseTransaction)
                {
                    ///建立事物处理
                    Sqltx = SqlCn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                }

                SqlCommand cmd = CreateCommand(procName, prams, IsUseTransaction);
                cmd.Prepare();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(Ds);
                blret = true;

                da.Dispose();
                cmd.Dispose();

                if (IsUseTransaction)
                {
                    //提交事物
                    Sqltx.Commit();
                }
            }
            catch (SqlException sqlex)
            {
                // Specific catch for deadlock
                if (sqlex.Number != 1205)
                {
                    if (IsUseTransaction && Sqltx != null)
                    {
                        //回滚事物
                        Sqltx.Rollback();
                    }
                }
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(sqlex.Number.ToString(), sqlex.Message);
                ErrorID = sqlex.Number;
                if (ErrorMsg == "")
                {
                    throw (sqlex);
                }
                else
                {
                    return (false);
                }
            }
            catch (Exception ex)
            {
                if (IsUseTransaction && Sqltx != null)
                {
                    //回滚事物
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }
        #endregion

        #region  运行指定的返回值存储过程
        public int RunProcReturn(
            string procName,
            SqlParameter[] prams,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            int intVal = 0;
            try
            {
                ///建立事物处理
                Sqltx = SqlCn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = CreateCommand(procName, prams, true);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                intVal = Convert.ToInt32(cmd.Parameters[prams.Length - 1].Value);

                cmd.Dispose();
                Sqltx.Commit();
            }
            catch (SqlException sqlex)
            {
                // Specific catch for deadlock
                if (sqlex.Number != 1205)
                {
                    if (Sqltx != null)
                    {
                        //回滚事物
                        Sqltx.Rollback();
                    }
                }
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(sqlex.Number.ToString(), sqlex.Message);
                ErrorID = sqlex.Number;
                if (ErrorMsg == "")
                {
                    throw (sqlex);
                }
            }
            catch (Exception ex)
            {
                if (Sqltx != null)
                {
                    //回滚事物
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return intVal;
        }
        #endregion

        #region  运行未指定的返回值存储过程
        public bool RunProcRet(
            string procName,
            SqlParameter[] prams,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            bool blret = false;
            try
            {
                ///建立事物处理
                Sqltx = SqlCn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                SqlCommand cmd = CreateCommand(procName, prams, true);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                blret = true;

                cmd.Dispose();
                Sqltx.Commit();
            }
            catch (SqlException sqlex)
            {
                // Specific catch for deadlock
                if (sqlex.Number != 1205)
                {
                    if (Sqltx != null)
                    {
                        //回滚事物
                        Sqltx.Rollback();
                    }
                }
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(sqlex.Number.ToString(), sqlex.Message);
                ErrorID = sqlex.Number;
                if (ErrorMsg == "")
                {
                    throw (sqlex);
                }
            }
            catch (Exception ex)
            {
                if (Sqltx != null)
                {
                    //回滚事物
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }
        #endregion

        #region  运行循环存储过程
        public bool RunProcRet(
            string procName,
            DataView dv,
            DataView dvParams,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            bool blret = false;
            try
            {
                if (dv != null && dvParams != null && dvParams.Count > 0 &&
                    dv.Count > 0)
                {
                    ///建立事物处理
                    Sqltx = SqlCn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                    for (int i = 0; i < dv.Count; i++)
                    {
                        SqlParameter[] prams = new SqlParameter[dvParams.Count];
                        for (int j = 0; j < dvParams.Count; j++)
                        {
                            prams[j] = new SqlParameter();

                            prams[j].ParameterName = "@" + dvParams[j]["ParameterName"].ToString().Trim();
                            prams[j].SqlDbType = GetSqlDbType(dvParams[j]["SqlDbType"].ToString().Trim());

                            if (dvParams[j]["Size"] != System.DBNull.Value &&
                                Convert.ToInt32(dvParams[j]["Size"]) > 0)
                            {
                                prams[j].Size = Convert.ToInt32(dvParams[j]["Size"]);
                            }

                            if (dv[i][dvParams[j]["ParameterName"].ToString().Trim()].ToString().Trim() != "")
                            {
                                prams[j].Value = dv[i][dvParams[j]["ParameterName"].ToString().Trim()];
                            }
                            else
                            {
                                prams[j].Value = System.DBNull.Value;
                            }
                        }

                        SqlCommand cmd = CreateCommand(procName, prams, true);
                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }

                    blret = true;
                    Sqltx.Commit();
                }
            }
            catch (SqlException sqlex)
            {
                // Specific catch for deadlock
                if (sqlex.Number != 1205)
                {
                    if (Sqltx != null)
                    {
                        //回滚事物
                        Sqltx.Rollback();
                    }
                }
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(sqlex.Number.ToString(), sqlex.Message);
                ErrorID = sqlex.Number;
                if (ErrorMsg == "")
                {
                    throw (sqlex);
                }
            }
            catch (Exception ex)
            {
                if (Sqltx != null)
                {
                    //回滚事物
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }

        SqlDbType GetSqlDbType(string strSqlDbType)
        {
            switch (strSqlDbType.Trim().ToLower())
            {
                case "bigint":
                    return (SqlDbType.BigInt);

                case "binary":
                    return (SqlDbType.Binary);

                case "bit":
                    return (SqlDbType.Bit);

                case "char":
                    return (SqlDbType.Char);

                case "datetime":
                    return (SqlDbType.DateTime);

                case "decimal":
                    return (SqlDbType.Decimal);

                case "float":
                    return (SqlDbType.Float);

                case "image":
                    return (SqlDbType.Image);

                case "int":
                    return (SqlDbType.Int);

                case "money":
                    return (SqlDbType.Money);

                case "nchar":
                    return (SqlDbType.NChar);

                case "ntext":
                    return (SqlDbType.NText);

                case "nvarchar":
                    return (SqlDbType.NVarChar);

                case "real":
                    return (SqlDbType.Real);

                case "smalldatetime":
                    return (SqlDbType.SmallDateTime);

                case "smallint":
                    return (SqlDbType.SmallInt);

                case "smallmoney":
                    return (SqlDbType.SmallMoney);

                case "text":
                    return (SqlDbType.Text);

                case "timestamp":
                    return (SqlDbType.Timestamp);

                case "tinyint":
                    return (SqlDbType.TinyInt);

                case "uniqueidentifier":
                    return (SqlDbType.UniqueIdentifier);

                case "varbinary":
                    return (SqlDbType.VarBinary);

                case "varchar":
                    return (SqlDbType.VarChar);

                case "variant":
                default:
                    return (SqlDbType.Variant);
            }
        }
        #endregion

        #region  运行多个存储过程
        public bool RunProcsRet(
            string[] spName,
            ArrayList al,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            bool blret = false;
            try
            {
                ///建立事物处理
                Sqltx = SqlCn.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);

                for (int i = 0; i < spName.Length; i++)
                {
                    SqlCommand cmd = CreateCommand(spName[i], (SqlParameter[])al[i], true);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }

                blret = true;
                Sqltx.Commit();
            }
            catch (SqlException sqlex)
            {
                // Specific catch for deadlock
                if (sqlex.Number != 1205)
                {
                    if (Sqltx != null)
                    {
                        //回滚事物
                        Sqltx.Rollback();
                    }
                }
                ErrorMsg = DBErrorMessageHelper.GetErrorDesc(sqlex.Number.ToString(), sqlex.Message);
                ErrorID = sqlex.Number;
                if (ErrorMsg == "")
                {
                    throw (sqlex);
                }
            }
            catch (Exception ex)
            {
                if (Sqltx != null)
                {
                    //回滚事物
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }

        #endregion
    }
}
