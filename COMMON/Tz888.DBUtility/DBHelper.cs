using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Tz888.DBUtility
{
   public class DBHelper
    {
    
        private static SqlConnection connection;
        public static SqlConnection Connection
        {

            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Home"].ToString();

                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }

        }


        //
        /// <summary>
        /// 带一个输出参数的存储过程
        /// </summary>
        /// <param name="procName">过程名称</param>
        /// <param name="Index">输出参数的索引位置</param>
        /// <param name="values">参数列表</param>
        /// <returns>返回值</returns>
        public static Object ExecuteNonQueryProcOutPut(string procName, int Index, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandTimeout = 120;
            values[Index].Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            cmd.ExecuteNonQuery();
            return cmd.Parameters[Index].Value;
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
           SqlCommand cmd = new SqlCommand(safeSql, Connection);
           cmd.CommandTimeout = 120;
           SqlDataAdapter da = new SqlDataAdapter(cmd);
           da.Fill(ds);

           return ds.Tables[0];
       }




        public static int ExecuteNonQueryProc(string procName, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandTimeout = 120;
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteScalarProc(string procName, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandTimeout = 120;
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }


       public static SqlDataReader ExecuteReaderProc(string procName, params SqlParameter[] values)
       {
           SqlCommand cmd = new SqlCommand(procName, Connection);
           cmd.CommandTimeout = 120;
           cmd.CommandType = CommandType.StoredProcedure;
           if (values != null)
               cmd.Parameters.AddRange(values);
           SqlDataReader reader = cmd.ExecuteReader();
           return reader;
       }

        public static DataTable GetDataTableProc(string procName, params SqlParameter[] values)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(procName, Connection);
            cmd.CommandTimeout = 120;
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
                cmd.Parameters.AddRange(values);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }

       public static DataTable GetDataSet(string sql, params SqlParameter[] values)
       {
           DataSet ds = new DataSet();

           SqlCommand cmd = new SqlCommand(sql, Connection);
           cmd.CommandTimeout = 120;
               cmd.Parameters.AddRange(values);
               SqlDataAdapter da = new SqlDataAdapter(cmd);
               da.Fill(ds);
           
           return ds.Tables[0];
       }







    }
}
