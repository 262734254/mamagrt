using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Security;
using System.Web.SessionState;

 
namespace TzVote //修改成实际项目的命名空间名称
{
	/// <summary>
	/// 数据访问基础类(基于OleDb)
	/// 可以用户可以修改满足自己项目的需要。
	/// </summary>
	public abstract class DB
	{
		public static string str="PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=";
        public static string connectionString = str + @"'D:\topfo\tzweb\Vote\tz888Vote_data\tz888Vote#_Date.mdb'"; 
		//public static string connectionString = str + @"D:\VT1.2.3\Member\Vote\tz888Vote_data\tz888Vote#_Date.mdb"; 
        //public static string connectionString =  ConfigurationSettings.AppSettings["VoteConnectionString"]; 	
		public DB()
		{
		}
		#region  执行简单SQL语句

		/// <summary>
		/// 执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>影响的记录数</returns>
		public static int ExecuteSql(string SQLString)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{				
				using (OleDbCommand cmd = new OleDbCommand(SQLString,connection))
				{
					try
					{		
						connection.Open();
						int rows=cmd.ExecuteNonQuery();
						return rows;
					}
					catch(System.Data.OleDb.OleDbException E)
					{					
						connection.Close();
						throw new Exception(E.Message);
					}
				}				
			}
		}
		/// <summary>
		/// 执行SQL语句，返回影响的记录数
		/// </summary>
		/// <param name="SQLString">SQL语句</param>
		/// <returns>影响的记录数</returns>
		public static void ExecuteSqlString(string SQLString)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{				
				using (OleDbCommand cmd = new OleDbCommand(SQLString,connection))
				{
					try
					{		
						connection.Open();
						cmd.ExecuteNonQuery();
						 
					}
					catch(System.Data.OleDb.OleDbException E)
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
			using (OleDbConnection conn = new OleDbConnection(connectionString))
			{
				conn.Open();
				OleDbCommand cmd = new OleDbCommand();
				cmd.Connection=conn;				
				OleDbTransaction tx=conn.BeginTransaction();			
				cmd.Transaction=tx;				
				try
				{   		
					for(int n=0;n<SQLStringList.Count;n++)
					{
						string strsql=SQLStringList[n].ToString();
						if (strsql.Trim().Length>1)
						{
							cmd.CommandText=strsql;
							cmd.ExecuteNonQuery();
						}
					}										
					tx.Commit();					
				}
				catch(System.Data.OleDb.OleDbException E)
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
		public static int ExecuteSql(string SQLString,string content)
		{				
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				OleDbCommand cmd = new OleDbCommand(SQLString,connection);		
				System.Data.OleDb.OleDbParameter  myParameter = new System.Data.OleDb.OleDbParameter ( "@content", OleDbType.VarChar);
				myParameter.Value = content ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.OleDb.OleDbException E)
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
		public static int ExecuteSqlInsertImg(string strSQL,byte[] fs)
		{		
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				OleDbCommand cmd = new OleDbCommand(strSQL,connection);	
				System.Data.OleDb.OleDbParameter  myParameter = new System.Data.OleDb.OleDbParameter ( "@fs", OleDbType.Binary);
				myParameter.Value = fs ;
				cmd.Parameters.Add(myParameter);
				try
				{
					connection.Open();
					int rows=cmd.ExecuteNonQuery();
					return rows;
				}
				catch(System.Data.OleDb.OleDbException E)
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
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				using(OleDbCommand cmd = new OleDbCommand(SQLString,connection))
				{
					try
					{
						connection.Open();
						object obj = cmd.ExecuteScalar();
						if((Object.Equals(obj,null))||(Object.Equals(obj,System.DBNull.Value)))
						{					
							return null;
						}
						else
						{
							return obj;
						}				
					}
					catch(System.Data.OleDb.OleDbException e)
					{						
						connection.Close();
						throw new Exception(e.Message);
					}	
				}
			}
		}
		/// <summary>
		/// 执行查询语句，返回OleDbDataReader
		/// </summary>
		/// <param name="strSQL">查询语句</param>
		/// <returns>OleDbDataReader</returns>
		public static OleDbDataReader ExecuteReader(string strSQL)
		{
			OleDbConnection connection = new OleDbConnection(connectionString);			
			OleDbCommand cmd = new OleDbCommand(strSQL,connection);				
			try
			{
				connection.Open();	
				OleDbDataReader myReader = cmd.ExecuteReader();
				return myReader;
			}
			catch(System.Data.OleDb.OleDbException e)
			{								
				throw new Exception(e.Message);
			}			
			
		}		
		/// <summary>
		/// 执行查询语句，返回DataSet
		/// </summary>
		/// <param name="SQLString">查询语句</param>
		/// <returns>DataSet</returns>
		public static DataSet Query(string SQLString)
		{
			using (OleDbConnection connection = new OleDbConnection(connectionString))
			{
				DataSet ds = new DataSet();
				try
				{
					connection.Open();
					OleDbDataAdapter command = new OleDbDataAdapter(SQLString,connection);				
					command.Fill(ds,"ds");
				}
				catch(System.Data.OleDb.OleDbException ex)
				{				
					throw new Exception(ex.Message);
				}			
				return ds;
			}			
		}


		#endregion
	}
}
