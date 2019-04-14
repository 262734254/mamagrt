using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Tz888.DBUtility
{
    /// <summary>
    /// SqlConn ��ժҪ˵����
    /// </summary>
    public class SqlConn
    {
        private string cn = null;                              //�������ݿ����ӵ��ַ���
        private SqlConnection SqlCn = null;                    //�������ݿ����ӵ��ַ��� 
        private SqlTransaction Sqltx = null;				   //�������ݿ����ӵ�������	
        private SqlCommand cmd = new SqlCommand();             //�������ݿ����SqlCommand
        private SqlDataAdapter Da = new SqlDataAdapter();      //�������ݿ����SqlDataAdapter

        #region  Ĭ�Ϲ��캯��
        public SqlConn()
        {
            cn = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
        }

        /// <summary>
        /// ���ӹ��캯��
        /// </summary>
        /// <param name="connString">��WEB.CONFIG����������ַ�����KEY</param>
        public SqlConn(string connString)
        {
            cn = System.Configuration.ConfigurationSettings.AppSettings[connString];
        }
        #endregion

        #region �������ݿ����Ӷ��󲢷�������
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

        #region �����ֻ�����֪ͨ���ݿ����Ӷ��󲢷�������
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

        #region ������̳���ݿ����Ӷ��󲢷�������
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

        #region �ر����ݿ�����Ӷ���
        public void CloseCn()
        {
            try
            {
                if (Sqltx != null)
                {
                    //�ͷ����ﴦ��
                    Sqltx.Dispose();
                }

                if (SqlCn.State != ConnectionState.Closed)
                {
                    //�ر�����
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

        #region ����SQL Command���󣬲����ظö���
        /// <summary>
        /// ����SQL Command���󣬲����ظö���
        /// </summary>
        /// <param name="procName">Ҫ�����Ĵ洢������</param>
        /// <param name="prams">���ڴ洢�������������������</param>
        /// <param name="IsUseTransaction">�Ƿ�ʹ�����ﴦ��</param>
        /// <returns>������SqlCommand����</returns>
        public SqlCommand CreateCommand(string procName, SqlParameter[] prams, bool IsUseTransaction)
        {
            ///�˴�ԭ��û�У����ǵ��������������ô˺����ķ���ֵΪ�ֲ����������˴�ȴʹ��
            ///���б������ᵼ�������������θú����ͻ���ֲ�������Ĵ������԰ѱ�������
            ///Ϊ�ֲ�����
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.SqlCn;
            cmd.CommandText = procName;
            cmd.CommandTimeout = 180;
            if (IsUseTransaction)
            {
                ///�������ﴦ��
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

        #region ����ָ���Ĵ洢���̷���DataTable
        /// <summary>
        /// ����ָ���Ĵ洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">���ڴ洢�������������������</param>
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
                    ///�������ﴦ��
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
                    //�ύ����
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
                        //�ع�����
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
                    //�ع�����
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return Ds.Tables[Ds.Tables.Count - 1];
        }
        #endregion

        #region ����ָ���Ĵ洢����
        /// <summary>
        /// ����ָ���Ĵ洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">���ڴ洢�������������������</param>
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
                ///�������ﴦ��
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
                        //�ع�����
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
                    //�ع�����
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }
        /// <summary>
        /// ����ָ���Ĵ洢����
        /// </summary>
        /// <param name="procName">�洢������</param>
        /// <param name="prams">���ڴ洢�������������������</param>
        /// <param name="IsUseTransaction">�Ƿ�ʹ�����ﴦ��</param>
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
                    ///�������ﴦ��
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
                    //�ύ����
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
                        //�ع�����
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
                    //�ع�����
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }
        #endregion

        #region  ����ָ���ķ���ֵ�洢����
        public int RunProcReturn(
            string procName,
            SqlParameter[] prams,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            int intVal = 0;
            try
            {
                ///�������ﴦ��
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
                        //�ع�����
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
                    //�ع�����
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return intVal;
        }
        #endregion

        #region  ����δָ���ķ���ֵ�洢����
        public bool RunProcRet(
            string procName,
            SqlParameter[] prams,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            bool blret = false;
            try
            {
                ///�������ﴦ��
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
                        //�ع�����
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
                    //�ع�����
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }
        #endregion

        #region  ����ѭ���洢����
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
                    ///�������ﴦ��
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
                        //�ع�����
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
                    //�ع�����
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

        #region  ���ж���洢����
        public bool RunProcsRet(
            string[] spName,
            ArrayList al,
            ref int ErrorID,
            ref string ErrorMsg)
        {
            bool blret = false;
            try
            {
                ///�������ﴦ��
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
                        //�ع�����
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
                    //�ع�����
                    Sqltx.Rollback();
                }
                throw (ex);
            }
            return blret;
        }

        #endregion
    }
}
