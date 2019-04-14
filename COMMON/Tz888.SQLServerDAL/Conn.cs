using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Tz888.IDAL;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL
{
    public class Conn : IConn
    {
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
        public DataTable GetList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount,
            int OrderType, string strWhere)
        {
            DataSet ds = null;
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
            Parameters[1].Value = strGetFields;
            Parameters[2].Value = fldName;
            Parameters[3].Value = PageSize;
            Parameters[4].Value = PageIndex;
            Parameters[5].Value = doCount;
            Parameters[6].Value = OrderType;
            Parameters[7].Value = strWhere;

            try
            {
                ds = DbHelperSQL.RunProcedure("Sp_Conn_Sort", Parameters, "ds");
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        /// <summary>
        /// 通用查询列表
        /// </summary>
        /// <param name="TableName">表名或视图名</param>
        /// <param name="FileName">需要返回的列,*为全部列</param>        
        /// <param name="Where">查询条件，需要加where</param>
        /// <returns>DataTable</returns>
        public DataTable GetList(string FileName, string TableName, string Where)
        {
            DataSet ds = null;
            SqlParameter[] parameters = {
                new SqlParameter("@tableName", SqlDbType.VarChar,300),
                new SqlParameter("@fieldName", SqlDbType.VarChar,1000),
                new SqlParameter("@where", SqlDbType.VarChar,500),
            };
            parameters[0].Value = TableName;
            parameters[1].Value = FileName;
            parameters[2].Value = Where;
            
            try
            {
                ds = DbHelperSQL.RunProcedure("Conn", parameters, "ds");
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
            }
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                return ds.Tables[0];
            }
            else
            {
                return new DataTable();
            }
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

            DataSet ds = DbHelperSQL.RunProcedure("Sp_Conn_Sort", Parameters, "ds");

            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }

        /// <summary>
        /// 统计记录条数
        /// </summary>
        /// <param name="tblName">数据表或视图名</param>
        /// <param name="fldName">索引列名</param>
        /// <param name="strWhere">统计条件</param>
        /// <returns>统计记录条数</returns>
        public int GetCountFN(string tblName, string fldName, string strWhere)
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

            DataSet ds = DbHelperSQL.RunProcedure("Sp_Conn_Sort_FN", Parameters, "ds");

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
        public DataTable GetListFN(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
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
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;
            parameters[7].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure("GetDataList_FN", parameters, "ds");

            if (ds == null)
                return null;
            dt = ds.Tables[0];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }
        /// <summary>
        /// 通用删除
        /// </summary>
        /// <param name="tblName">表名</param>
        /// <param name="where ">where</param>
        public bool  Delect(string tblName, string where )
        {

            SqlParameter[] Parameters = new SqlParameter[]{
															 new  SqlParameter("@tblName",SqlDbType.VarChar,255),
															 new  SqlParameter("@where",SqlDbType.VarChar,500),
        };
            Parameters[0].Value = tblName;
            Parameters[1].Value = where;
            return DbHelperSQL.RunProcLob("DelectCommon",Parameters);


        }



        /// <summary>
        /// 取网上展厅数据
        /// </summary>
        /// <param name="tblName"></param>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="doCount"></param>
        /// <param name="OrderType"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetWebSiteList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount,
            int OrderType, string strWhere)
        {
            DataSet ds = null;
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
            Parameters[1].Value = strGetFields;
            Parameters[2].Value = fldName;
            Parameters[3].Value = PageSize;
            Parameters[4].Value = PageIndex;
            Parameters[5].Value = doCount;
            Parameters[6].Value = OrderType;
            Parameters[7].Value = strWhere;

            ds = DbHelperSQL.GetWebSiteList("Sp_Conn_Sort", Parameters, "ds");
            if(ds != null && ds.Tables.Count != 0)
                return ds.Tables[0];
            return null;
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
        public DataTable GetList(string TableViewName, string Key,string SelectStr,string Criteria,string Sort,
            ref long CurrentPage, long PageSize,ref long TotalCount)
        {
            DataTable dt = null;
            SqlParameter[] parameters = {	
											new SqlParameter("@TableViewName",SqlDbType.VarChar,255),
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
            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = CurrentPage;
            parameters[6].Value = PageSize;
            parameters[7].Direction = ParameterDirection.InputOutput;
            //parameters[7].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure("GetDataList", parameters, "ds");

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0] == null)
            {
                return null;
            }
            dt = ds.Tables[0];
            if (dt != null)
            {
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[7].Value);
                    CurrentPage = Convert.ToInt64(parameters[5].Value);
                }
                else
                {
                    TotalCount = Convert.ToInt64(dt.Rows.Count);
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dt;
        }
        public bool Update(int psid, int IsChekUp)
        {

            SqlParameter[] parameters = {
					new SqlParameter("@Psid", SqlDbType.Int),
					new SqlParameter("@IsChekUp", SqlDbType.Int),
					};
            parameters[0].Value = psid;
            parameters[1].Value = IsChekUp;
            return DbHelperSQL.RunProcLob("RCUpdate", parameters);


        }

        /// <summary>
        /// 获取全部的信息列表
        /// </summary>
        /// <param name="SPName">存储过程的名字</param>
        /// <param name="SelectStr">选择列字符串</param>
        /// <param name="Criteria">查询条件</param>
        /// <param name="Sort">排序字符串</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">通过该查询条件，返回的查询记录的总页数</param>
        /// <returns>返回当前页的信息列表</returns>
        public DataView GetList(
            string SPName,
            string SelectStr,
            string Criteria,
            string Sort,
            ref long CurrentPage,
            long PageSize,
            ref long TotalCount
            )
        {
            DataView dv = null;
            TotalCount = 0;

            SqlParameter[] parameters = {	
											new SqlParameter("@SelectStr",SqlDbType.VarChar,500),
											new SqlParameter("@Criteria",SqlDbType.VarChar,8000),
											new SqlParameter("@Sort",SqlDbType.VarChar,255),
											new SqlParameter("@Page",SqlDbType.BigInt),
											new SqlParameter("@CurrentPageRow",SqlDbType.BigInt),
											new SqlParameter("@TotalCount",SqlDbType.BigInt),
			};

            parameters[0].Value = SelectStr;
            parameters[1].Value = Criteria;
            parameters[2].Value = Sort;

            parameters[3].Direction = ParameterDirection.InputOutput;
            parameters[3].Value = CurrentPage;

            parameters[4].Value = PageSize;

            parameters[5].Direction = ParameterDirection.InputOutput;
            parameters[5].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedure(SPName, parameters, "ds");

            if (ds != null && ds.Tables.Count>0)
            {
                dv = ds.Tables["ds"].DefaultView;
                if (PageSize > 0)
                {
                    TotalCount = Convert.ToInt64(parameters[5].Value);
                    CurrentPage = Convert.ToInt64(parameters[3].Value);
                }
                else
                {
                    TotalCount = dv.Count;
                    if (TotalCount > 0)
                    {
                        CurrentPage = 1;
                    }
                    else
                    {
                        CurrentPage = 0;
                    }
                }
            }
            return dv;
        }
    }
}
