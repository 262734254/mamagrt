using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Security;
using System.Web.SessionState;

 
namespace TzVote //�޸ĳ�ʵ����Ŀ�������ռ�����
{
	/// <summary>
	/// ���ݷ��ʻ�����(����OleDb)
	/// �����û������޸������Լ���Ŀ����Ҫ��
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
		#region  ִ�м�SQL���

		/// <summary>
		/// ִ��SQL��䣬����Ӱ��ļ�¼��
		/// </summary>
		/// <param name="SQLString">SQL���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
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
		/// ִ��SQL��䣬����Ӱ��ļ�¼��
		/// </summary>
		/// <param name="SQLString">SQL���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
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
		/// ִ�ж���SQL��䣬ʵ�����ݿ�����
		/// </summary>
		/// <param name="SQLStringList">����SQL���</param>		
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
		/// ִ�д�һ���洢���̲����ĵ�SQL��䡣
		/// </summary>
		/// <param name="SQLString">SQL���</param>
		/// <param name="content">��������,����һ���ֶ��Ǹ�ʽ���ӵ����£���������ţ�����ͨ�������ʽ���</param>
		/// <returns>Ӱ��ļ�¼��</returns>
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
		/// �����ݿ������ͼ���ʽ���ֶ�(������������Ƶ���һ��ʵ��)
		/// </summary>
		/// <param name="strSQL">SQL���</param>
		/// <param name="fs">ͼ���ֽ�,���ݿ���ֶ�����Ϊimage�����</param>
		/// <returns>Ӱ��ļ�¼��</returns>
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
		/// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
		/// </summary>
		/// <param name="SQLString">�����ѯ������</param>
		/// <returns>��ѯ�����object��</returns>
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
		/// ִ�в�ѯ��䣬����OleDbDataReader
		/// </summary>
		/// <param name="strSQL">��ѯ���</param>
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
		/// ִ�в�ѯ��䣬����DataSet
		/// </summary>
		/// <param name="SQLString">��ѯ���</param>
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
