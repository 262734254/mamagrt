using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Tz888.DBUtility
{
    public class CrmDBHelper
    {
        //
        public static string sqlconn = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        //public static string sqlconn = System.Configuration.ConfigurationManager.ConnectionStrings["sqlserver"].ToString();

        public static string sqlComapnyShow = System.Configuration.ConfigurationManager.ConnectionStrings["CompanyShow"].ToString();

       public CrmDBHelper()
        {

        }

        /// <summary>
        ///添加  返回 主键ID
        /// </summary>
        /// <param name="cmdText"></param>
        /// <param name="sqlParam"></param>
        /// <returns></returns>
        public int ExecuteQuerySQLID(string cmdText, params SqlParameter[] sqlParam)
        {

            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {

                    conn.Open();
                }
                catch
                {
                    return 0;
                }
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddRange(sqlParam);
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "select @@IDENTITY";
                    return Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        /// <summary>
        /// 添加 删除 数据
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="sqlParam">参数</param>
        /// <returns></returns>
        public int ExecuteQuerySQL(string cmdText, ref SqlParameter[] sqlParam)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    return 0;
                }
                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddRange(sqlParam);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 返回DataSet类型数据源
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataSet</returns>
        public DataSet ExecuteQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                return ds;
            }
        }
        /// <summary>
        /// 返回DataSet类型数据源
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="sqlParam">参数</param>
        /// <returns>返回DataSet</returns>
        public DataSet ExecuteQuery(string sql, ref SqlParameter[] sqlParam)
        {
            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddRange(sqlParam);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    conn.Close();
                    return ds;
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="sqlParam">参数</param>
        /// <returns>返回SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string sql, ref SqlParameter[] sqlParam)
        {
            try
            {
                SqlConnection conn = new SqlConnection(sqlconn);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(sqlParam);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 返回SqlDataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回SqlDataReader</returns>
        public SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlConnection conn = new SqlConnection(sqlconn);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Prepare a command for execution
        /// </summary>
        /// <param name="cmd">SqlCommand object</param>
        /// <param name="conn">SqlConnection object</param>
        /// <param name="trans">SqlTransaction object</param>
        /// <param name="cmdType">Cmd type e.g. stored procedure or text</param>
        /// <param name="cmdText">Command text, e.g. Select * from Products</param>
        /// <param name="cmdParms">SqlParameters to use in the command</param>
        private void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection conn = new SqlConnection(sqlconn))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }
        /// <summary>
        /// 
        /// 返回DataTable对象
        /// </summary>
        /// <param Name="safeSql"></param>
        /// <returns></returns>
        public DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Connection = new SqlConnection(sqlconn))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(safeSql, Connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        public DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Connection = new SqlConnection(sqlconn))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.Parameters.AddRange(values);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        public object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        public DataSet Query(string sqlString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, sqlString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }
        /// <summary>X
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
           // command.Parameters.Clear();
            command.CommandTimeout = 0;
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                    
                }
            }

            return command;
        }

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        private static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public  int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;
                //Connection.Close();
                return result;
            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(sqlconn))
            {
                try
                {
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(dataSet, tableName);
                    connection.Close();
                    return dataSet;
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    return new DataSet();
                }

            }
        }
        /// <summary>
        /// 返回DataSet类型数据源
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataSet</returns>
        public DataSet ExecuteQuerys(string sql)
        {
            using (SqlConnection connection = new SqlConnection(sqlComapnyShow))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(sql, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }

                return ds;
            }
        }
        #region 企业展厅中用到
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingleShow(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(sqlComapnyShow))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                }
            }
        }
        #endregion

        #region  根据IP查找所对于的城市名称
        /// <summary>
        /// 根据IP查找所对于的城市名称
        /// </summary>
        /// <param name="Ip">所对应的IP</param>
        /// <returns>返回城市名称</returns>
        public string IPName(string Ip)
        {
            string name = "";
            SqlConnection conn = new SqlConnection(sqlconn);
            string strSql = "F_GetPlaceFromIPAddress";
            SqlCommand cmd = new SqlCommand(strSql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@IPAddress", SqlDbType.NVarChar).Value = Ip;// = "218.75.207.2";
            cmd.Parameters.Add("@returnString", SqlDbType.NVarChar);
            cmd.Parameters["@returnString"].Direction = ParameterDirection.ReturnValue;
            try
            {
                conn.Open();
                object o = cmd.ExecuteScalar();
                name = cmd.Parameters["@returnString"].Value.ToString();
            }
            catch (Exception ex)
            {
                name = ex.Message;
            }
            finally
            {
                if (!(conn.State == ConnectionState.Closed))
                {
                    conn.Close();
                }
            }
            return name;
        }
        #endregion

    }
        
}
