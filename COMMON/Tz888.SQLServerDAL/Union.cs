using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL
{
  public   class Union
    {

        /// <summary>
        /// 获取服务信息 /需求，机构，人才
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
        public DataTable GetList(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
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
            //parameters[7].Value = 1;

            DataSet ds = DbHelperSQL.RunProcedures0("GetDataList", parameters, "ds");

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
        ///获取服务信息 /需求，机构，人才 从各表 查询单列  并需要查询条件
        /// </summary>
        /// <returns></returns>
        public DataTable  GetList(string FileName, string TableName, string Where,int Top)
        {
            SqlParameter[] parameters = {
                                    new SqlParameter("@FileName", SqlDbType.VarChar,300),
                new SqlParameter("@TableName", SqlDbType.VarChar,30),
                new SqlParameter("@Where", SqlDbType.VarChar,300),
                new SqlParameter("@Top", SqlDbType.Int),
			};
            parameters[0].Value = FileName;
            parameters[1].Value = TableName;
            parameters[2].Value = Where;
            parameters[3].Value = Top;
            DataSet ds = DbHelperSQL.RunProcedures0("Common_Top", parameters, "Top");
           
            return ds.Tables["Top"];
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string table,string where )
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar,60),
                     new SqlParameter("@Where", SqlDbType.VarChar,300),

				};
            parameters[0].Value = table;
            parameters[1].Value = where;
            bool b = DbHelperSQL.RunProcLobs0("Common_Delete", parameters);
            return b;
        }
        /// <summary>
        /// 服务二级分类列表
        /// </summary>
        /// <returns></returns>
        public DataView GetServiesList(int ServiesBID, bool isShow)
        {
            SqlParameter[] parameters = {
									new SqlParameter("@ServiesBID", SqlDbType.Int),
                                    new SqlParameter("@flag", SqlDbType.VarChar,30),
                                    new SqlParameter("@isShow", SqlDbType.Bit),
			};
            parameters[0].Value = ServiesBID;
            parameters[1].Value = "GetM";
            parameters[2].Value = isShow;
            DataSet ds = DbHelperSQL.RunProcedures0("ServiesTypeGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        /// <summary>
        /// 服务一级分类列表
        /// </summary>
        /// <returns></returns>
        public DataView GetServiesList(bool isShow)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@flag", SqlDbType.VarChar,30),
                new SqlParameter("@isShow", SqlDbType.Bit),
			};
            parameters[0].Value = "GetB";
            parameters[1].Value = isShow;
            DataSet ds = DbHelperSQL.RunProcedures0("ServiesTypeGetList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

    }
}
