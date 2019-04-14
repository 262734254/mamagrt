using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Data.OracleClient;
namespace Tz888.DBUtility
{
    public class CommandInfo
    {
        public string CommandText;
        public SqlParameter[] Parameters; 
    }
    /// <summary>
    /// 数据访问抽象基础类
    /// Copyright (C) 2004-2008 By LiTianPing 
    /// </summary>
    public abstract class DbHelperSQL
    {
        //数据库连接字符串(web.config来配置)，可以动态更改connectionString支持多数据库.		
        protected static String connectionString = ConfigurationManager.ConnectionStrings["SQLConnString1"].ConnectionString; 
        protected static String connectionString2 = ConfigurationManager.ConnectionStrings["SelfCreateWeb"].ConnectionString;
        protected static String connectionStringSms = ConfigurationManager.ConnectionStrings["SmsConnectionString"].ConnectionString;
        protected static String UnionConnString = ConfigurationManager.ConnectionStrings["UnionConnString"].ConnectionString;
        protected static String UnionConnString0 = ConfigurationManager.ConnectionStrings["UnionConnString0"].ConnectionString;//使用专业服务联盟数据库invest_Union
        //private static string connectionString1 = System.Configuration.ConfigurationManager.ConnectionStrings["Home"].ConnectionString;
        //private static SqlConnection connection;
        //public static SqlConnection Connection
        //{

        //    get
        //    {
        //        string connectionString1 = ConfigurationManager.ConnectionStrings["Home1"].ToString();

        //        if (connection == null)
        //        {
        //            connection = new SqlConnection(connectionString1);
        //            connection.Open();
        //        }
        //        else if (connection.State == ConnectionState.Closed)
        //        {
        //            connection.Open();
        //        }
        //        else if (connection.State == ConnectionState.Broken)
        //        {
        //            connection.Close();
        //            connection.Open();
        //        }
        //        return connection;
        //    }

        //}

        public DbHelperSQL()
        {
        }
        /// <summary>
        /// 获取一个数据库连接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// 获取网上展厅的数据库连接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnection2()
        {
            return new SqlConnection(connectionString2);
        }
        /// <summary>
        /// 获得短信发送数据库链接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlConnectionSms()
        {
            return new SqlConnection(connectionStringSms);
        }

        /// <summary>
        /// 获得专业服务联盟.资源联盟数据库链接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlUnionConnString()
        {
            return new SqlConnection(UnionConnString);
        }
        /// <summary>
        /// 获得专业服务联盟数据库invest_Union链接
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetSqlUnionConnString0()
        {
            return new SqlConnection(UnionConnString0);
        }
        #region 公用方法

        public static int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public static bool Exists(string strSql)
        {
            object obj = DbHelperSQL.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static object ExecuteScalar(string sql)
        {
            object result = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    result = command.ExecuteScalar();
                    conn.Close();

                }
            }

            return result;
        }
        /// <summary>
        /// 表是否存在
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool TabExists(string TableName)
        {
            string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
            object obj = DbHelperSQL.GetSingle(strsql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = DbHelperSQL.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句
       
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

      
        public static int ExecuteSqlNew(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int count = (int)cmd.ExecuteScalar();
                        return count;
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
        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static void ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                    return count;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
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
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
        public static object GetSingle(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
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
        /// 执行查询语句，返回SqlDataReader ( 注意：使用后一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }
        /// <summary>
        /// 
        /// 返回DataTable对象
        /// </summary>
        /// <param Name="safeSql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            using (SqlConnection Connection = new SqlConnection(connectionString))
            {
                Connection.Open();
                SqlCommand cmd = new SqlCommand(safeSql, Connection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables[0];
        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        ///
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
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
        /// <returns>返回DataSet</returns>
        public static DataSet ExecuteQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch
                {
                    return null;
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            try
                            {
                                // da.SelectCommand = cmd;
                                DataSet ds = new DataSet();
                                da.Fill(ds);
                                return ds;
                            }
                            catch
                            {
                                return null;
                            }
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        public static DataSet Query(string SQLString, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
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
        /// 资源联盟
        /// </summary>
        /// <param name="SQLString"></param>
        /// <returns></returns>
        public static DataSet Querys(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(UnionConnString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(System.Collections.Generic.List<CommandInfo> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {

                        //循环
                        foreach (CommandInfo myDE in SQLStringList)
                        {
                            string cmdText = myDE.CommandText;
                            SqlParameter[] cmdParms = myDE.Parameters;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(System.Collections.Generic.List<CommandInfo> SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (CommandInfo myDE in SQLStringList)
                        {
                            string cmdText = myDE.CommandText;
                            SqlParameter[] cmdParms = myDE.Parameters;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTranWithIndentity(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        int indentity = 0;
                        //循环
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.InputOutput)
                                {
                                    q.Value = indentity;
                                }
                            }
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            foreach (SqlParameter q in cmdParms)
                            {
                                if (q.Direction == ParameterDirection.Output)
                                {
                                    indentity = Convert.ToInt32(q.Value);
                                }
                            }
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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

        /// <summary>
        /// 执行查询语句，返回SqlDataReader ( 注意：使用后一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw new Exception(e.Message);
            }
            //			finally
            //			{
            //				cmd.Dispose();
            //				connection.Close();
            //			}	

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
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


        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程 ( 注意：使用后一定要对SqlDataReader进行Close )
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader returnReader;
                connection.Open();
                SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                returnReader = command.ExecuteReader();
                return returnReader;
            }
        }

        public static int ExecuteCommand(string sql, params SqlParameter[] values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                int result = cmd.ExecuteNonQuery();
                connection.Close();
                return result;
              
            }

        }
        public static DataTable GetDataSet(string sql, params SqlParameter[] values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);
                connection.Close();
                return ds.Tables[0];

            }


        }
        public static int GetScalar(string sql, params SqlParameter[] values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddRange(values);
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                connection.Close();
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
        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
        /// 专业服务联盟 资源联盟
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet RunProcedures(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(UnionConnString))
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
        /// 专业服务联盟 
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataSet RunProcedures0(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(UnionConnString0))
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
        /// 运行指定的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <returns></returns>
        public static bool RunProcLobHO(
            string procName,
            SqlParameter[] prams)
        {
            bool blret = false;
            using (SqlConnection connection = new SqlConnection(UnionConnString0))
            {
                //int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, procName, prams);
                int rowsAffected = command.ExecuteNonQuery();
                //result = Convert.ToInt32(command.Parameters[prams.Length - 1].Value);
                connection.Close();
                if (rowsAffected > 0)
                {
                    blret = true;
                }

            }
            return blret;
        }

        public static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
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
        /// 
        /// </summary>
        /// <param name="sqlConn">执行存储过程所使用的数据库连接对象(使用前需打开连接,此方法不会关闭连接,需手动关闭)</param>
        /// <param name="sqlTran">数据库连接对象上开启的事务对象</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(SqlConnection sqlConn, SqlTransaction sqlTran, string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            int result;
            SqlCommand command = BuildIntCommand(sqlConn, storedProcName, parameters);
            command.Transaction = sqlTran;
            rowsAffected = command.ExecuteNonQuery();
            result = (int)command.Parameters["ReturnValue"].Value;
            return result;
        }


        /// <summary>
        /// 执行存储过程，返回影响的行数		
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowsAffected">影响的行数</param>
        /// <returns></returns>
        public static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
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
        /// 返回指定参数的过程
        /// </summary>
        /// <param name="storedProcName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int RunProcReturn(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                int rowsAffected = command.ExecuteNonQuery();
                result = Convert.ToInt32(command.Parameters[parameters.Length - 1].Value);
                //Connection.Close();
                return result;
            }


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
        /// 运行指定的存储过程
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <returns></returns>
        public static bool RunProcLob(
            string procName,
            SqlParameter[] prams)
        {
            bool blret = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, procName, prams);
                int rowsAffected = command.ExecuteNonQuery();
                //result = Convert.ToInt32(command.Parameters[prams.Length - 1].Value);
                //Connection.Close();
                if (rowsAffected > 0)
                {
                    blret = true;
                }

            }
            return blret;
        }
        /// <summary>
        /// 运行指定的存储过程   Union数据库
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <returns></returns>
        public static bool RunProcLob0(
            string procName,
            SqlParameter[] prams)
        {
            bool blret = false;
            using (SqlConnection connection = new SqlConnection(UnionConnString0))
            {
                //int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, procName, prams);
                int rowsAffected = command.ExecuteNonQuery();
                //result = Convert.ToInt32(command.Parameters[prams.Length - 1].Value);
                //Connection.Close();
                if (rowsAffected > 0)
                {
                    blret = true;
                }

            }
            return blret;
        }

        /// <summary>
        /// 专业服务联盟 资源联盟
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <returns></returns>
        public static bool RunProcLobs(
            string procName,
            SqlParameter[] prams)
        {
            bool blret = false;
            using (SqlConnection connection = new SqlConnection(UnionConnString))
            {
                //int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, procName, prams);
                int rowsAffected = command.ExecuteNonQuery();
                //result = Convert.ToInt32(command.Parameters[prams.Length - 1].Value);
                //Connection.Close();
                if (rowsAffected > 0)
                {
                    blret = true;
                }

            }
            return blret;
        }

        /// <summary>
        /// 专业服务联盟
        /// </summary>
        /// <param name="procName">存储过程名</param>
        /// <param name="prams">对于存储过程有输入参数的数组</param>
        /// <returns></returns>
        public static bool RunProcLobs0(
            string procName,
            SqlParameter[] prams)
        {
            bool blret = false;
            using (SqlConnection connection = new SqlConnection(UnionConnString0))
            {
                //int result;
                connection.Open();
                SqlCommand command = BuildIntCommand(connection, procName, prams);
                int rowsAffected = command.ExecuteNonQuery();
                //result = Convert.ToInt32(command.Parameters[prams.Length - 1].Value);
                //Connection.Close();
                if (rowsAffected > 0)
                {
                    blret = true;
                }

            }
            return blret;
        }
        #endregion

        #region  网上展厅
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet GetWebSiteList(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString2))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }
        #endregion
    

        //#region  DBHelper类
        //#region 存储过程操作

        ///// <summary>
        ///// 执行存储过程，返回SqlDataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>SqlDataReader</returns>
        //public static SqlDataReader RunProcedure1(string storedProcName, IDataParameter[] parameters)
        //{
        //    //SqlConnection connection = new SqlConnection(connectionString1);  
        //    SqlDataReader returnReader;
        //    //connection.Open();
        //    SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        //    command.CommandType = CommandType.StoredProcedure;
        //    returnReader = command.ExecuteReader(CommandBehavior.CloseConnection);
        //    return returnReader;

        //}


        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="tableName">DataSet结果中的表名</param>
        ///// <returns>DataSet</returns>
        //public static DataSet RunProcedure1(string storedProcName, IDataParameter[] parameters, string tableName)
        //{
        //    //using (SqlConnection connection = new SqlConnection(connectionString1))
        //    //{
        //        DataSet dataSet = new DataSet();
        //        //connection.Open();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand1(connection, storedProcName, parameters);
        //        sqlDA.Fill(dataSet, tableName);
        //        //connection.Close();
        //        return dataSet;
        //    //}
        //}
        //public static DataSet RunProcedure1(string storedProcName, IDataParameter[] parameters, string tableName, int Times)
        //{
        //    //using (SqlConnection connection = new SqlConnection(connectionString1))
        //    //{
        //        DataSet dataSet = new DataSet();
        //        //connection.Open();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //        sqlDA.SelectCommand.CommandTimeout = Times;
        //        sqlDA.Fill(dataSet, tableName);
        //        //connection.Close();
        //        return dataSet;
        //    //}
        //}


        ///// <summary>
        ///// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        ///// </summary>
        ///// <param name="connection">数据库连接</param>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>SqlCommand</returns>
        //private static SqlCommand BuildQueryCommand1(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        //{
        //    SqlCommand command = new SqlCommand(storedProcName, connection);
        //    command.CommandType = CommandType.StoredProcedure;

        //    foreach (SqlParameter parameter in parameters)
        //    {
        //        if (parameter != null)
        //        {
        //            // 检查未分配值的输出参数,将其分配以DBNull.Value.
        //            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                (parameter.Value == null))
        //            {
        //                parameter.Value = DBNull.Value;
        //            }
        //            command.Parameters.Add(parameter);
        //        }
        //    }


        //    return command;
        //}

        ///// <summary>
        ///// 执行存储过程，返回影响的行数		
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="rowsAffected">影响的行数</param>
        ///// <returns></returns>
        //public static int RunProcedure1(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        //{
        //    //using (SqlConnection connection = new SqlConnection(connectionString1))
        //    //{
        //        int result;
        //        //connection.Open();
        //        SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
        //        rowsAffected = command.ExecuteNonQuery();
        //        result = (int)command.Parameters["ReturnValue"].Value;
        //        ////Connection.Close();
        //        return result;
        //    //}
        //}

        ///// <summary>
        ///// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>SqlCommand 对象实例</returns>
        //private static SqlCommand BuildIntCommand1(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        //{
        //    SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
        //    command.Parameters.Add(new SqlParameter("ReturnValue",
        //        SqlDbType.Int, 4, ParameterDirection.ReturnValue,
        //        false, 0, 0, string.Empty, DataRowVersion.Default, null));
        //    return command;
        //}
        //      #endregion

        //public static  SqlDataReader ExecuteReaderProc(string procName, params SqlParameter[] values)
        //{
        
        //    SqlCommand cmd = new SqlCommand(procName, connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if (values != null)
        //        cmd.Parameters.AddRange(values);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    return reader;
       


        //}



        //public static int ExecuteNonQueryProc(string procName, params SqlParameter[] values)
        //{
            
        //        SqlCommand cmd = new SqlCommand(procName, connection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        if (values != null)
        //            cmd.Parameters.AddRange(values);
        //        return cmd.ExecuteNonQuery();

            
        //}


        ///// <summary>
        ///// 
        ///// 返回DataTable对象
        ///// </summary>
        ///// <param Name="safeSql"></param>
        ///// <returns></returns>
        //public static DataTable GetDataSet(string safeSql)
        //{
        //    DataSet ds = new DataSet();
            
        //        SqlCommand cmd = new SqlCommand(safeSql, Connection);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        da.Fill(ds);
            
        //    return ds.Tables[0];
        //}


        //public static DataTable GetDataTableProc(string procName, params SqlParameter[] values)
        //{
        //    DataSet ds = new DataSet();
        //    SqlCommand cmd = new SqlCommand(procName, Connection);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    if (values != null)
        //        cmd.Parameters.AddRange(values);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    da.Fill(ds);
        //    return ds.Tables[0];
        //}


        //#endregion

    }

    }
