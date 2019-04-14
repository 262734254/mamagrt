using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace Tz888.SQLServerDAL
{
   public class GetDataList:ErrorBase
   {
  public GetDataList()
		{
			 
		}
	 
		/// <summary>
		/// 通用查询列表
		/// </summary>
		/// <param name="tblName">表名或视图名</param>
		/// <param name="strGetFields">需要返回的列,*为全部列</param>
		/// <param name="fldName">排序字段</param>
		/// <param name="PageSize">页尺码</param>
		/// <param name="PageIndex">页码</param>
		/// <param name="doCount">回记录总数，非0值则返，0则返回查询的记录</param>
		/// <param name="OrderType">设置排序方式，非0值则降序列，0为升序列</param>
		/// <param name="strWhere">查询条件，不需要加where</param>
		/// <returns>DataTable</returns>
		public DataTable GetList(string tblName,string strGetFields,string fldName,int PageSize,int PageIndex,int doCount,int OrderType,string strWhere)
		{

            Tz888.DBUtility.SqlConn mySql = new Tz888.DBUtility.SqlConn();
			DataTable dt=null;
			
			SqlParameter[] Parameters=new  SqlParameter[]{
   
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
   
															 new  SqlParameter("@strGetFields",SqlDbType.VarChar,1000),

															 new  SqlParameter("@fldName",SqlDbType.VarChar,255),

															 new  SqlParameter("@PageSize",SqlDbType.Int,4),

															 new  SqlParameter("@PageIndex",SqlDbType.Int,4),
   
															 new  SqlParameter("@doCount",SqlDbType.Bit),

															 new  SqlParameter("@OrderType",SqlDbType.Bit),
   
															 new  SqlParameter("@strWhere",SqlDbType.VarChar,1500)
														 };
  
		 
			Parameters[0].Value=tblName;

			Parameters[1].Value=strGetFields;

			Parameters[2].Value=fldName;

			Parameters[3].Value=PageSize;

			Parameters[4].Value=PageIndex;

			Parameters[5].Value=doCount;

			Parameters[6].Value=OrderType;

			Parameters[7].Value=strWhere;

			try
			{
				mySql.GetConnection();
				dt=mySql.RunProc("Sp_Conn_Sort",Parameters,true, ref mintErrorID, ref mstrErrorMsg);
			}
			catch(Exception err)
			{
				throw err;
			}
			finally
			{
				mySql.CloseCn();
			}
			return dt;
  
		}
	
		/// <summary>
		/// 统计记录条数
		/// </summary>
		/// <param name="tblName">数据表或视图名</param>
		/// <param name="fldName">索引列名</param>
		/// <param name="strWhere">统计条件</param>
		/// <returns>统计记录条数</returns>
		public int GetCount(string tblName, string fldName, string strWhere)
		{
			SqlParameter[] Parameters = new SqlParameter[]{
															  new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															  new  SqlParameter("@strGetFields",SqlDbType.VarChar,1000),
															  new  SqlParameter("@fldName",SqlDbType.VarChar,255),
															  new  SqlParameter("@PageSize",SqlDbType.Int,4),
															  new  SqlParameter("@PageIndex",SqlDbType.Int,4),
															  new  SqlParameter("@doCount",SqlDbType.Bit),
															  new  SqlParameter("@OrderType",SqlDbType.Bit),
															  new  SqlParameter("@strWhere",SqlDbType.VarChar,1500)
														  };
			Parameters[0].Value = tblName;
			Parameters[1].Value = fldName;
			Parameters[2].Value = fldName;
			Parameters[3].Value = 1;
			Parameters[4].Value = 1;
			Parameters[5].Value = 1;
			Parameters[6].Value = 0;
			Parameters[7].Value = strWhere;

            DataSet ds = Tz888.DBUtility.DbHelperSQL.RunProcedure("Sp_Conn_Sort", Parameters, "ds");

			return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="TableViewName">表名</param>
		/// <param name="Key">主键</param>
		/// <param name="SelectStr">查询字段</param>
		/// <param name="Criteria">条件</param>
		/// <param name="Sort">排序字段</param>
		/// <param name="CurrentPage">当前页</param>
		/// <param name="PageSize">页大小</param>
		/// <param name="TotalCount">总记录</param>
		/// <returns></returns>
		public DataTable GetList(
			string TableViewName,
			string Key,
			string SelectStr,
			string Criteria,
			string Sort,
			ref long CurrentPage,
			long PageSize,
			ref long TotalCount )
		{
            Tz888.DBUtility.SqlConn mySql = new Tz888.DBUtility.SqlConn();
			DataTable dt = null;
			SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,50),
											new SqlParameter("@Key",SqlDbType.VarChar,50),
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt)
										};

			parameters[0].Value = TableViewName;
			parameters[1].Value = Key;
			parameters[2].Value = SelectStr;
			parameters[3].Value = Criteria;
			parameters[4].Value = Sort;

			parameters[5].Direction =ParameterDirection.InputOutput;
			parameters[5].Value = CurrentPage;

			parameters[6].Value = PageSize;

			parameters[7].Direction =ParameterDirection.InputOutput;
			parameters[7].Value = 1;

			try
			{
				//ds = DbHelperSQL.RunProcedure("GetDataList",parameters,"ds");
				mySql.GetConnection();
				dt=mySql.RunProc("GetDataList",parameters,true, ref mintErrorID, ref mstrErrorMsg);
				if( dt != null )
				{
					if( PageSize > 0 )
					{
						TotalCount = Convert.ToInt64( parameters[7].Value );
						CurrentPage = Convert.ToInt64( parameters[5].Value );
					}
					else
					{
						TotalCount = Convert.ToInt64(dt.Rows.Count);
						if( TotalCount > 0 )
						{
							CurrentPage = 1;
						}
						else
						{
							CurrentPage = 0;
						}
					}
				}
			}
			catch(Exception err)
			{
				throw err;
			}
			return dt;
		}
	}

}
