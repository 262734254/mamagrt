using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.BLL
{
  public  class GetDataList
    {
      Tz888.SQLServerDAL.GetDataList myConn = new Tz888.SQLServerDAL.GetDataList();
      public GetDataList()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public DataTable GetList(string tblName,string strGetFields,string fldName,int PageSize,int PageIndex,int doCount,int OrderType,string strWhere)
		{
			
			return myConn.GetList( tblName, strGetFields, fldName, PageSize, PageIndex, doCount, OrderType, strWhere);
  
		}
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
			
			return myConn.GetList(TableViewName,Key,SelectStr,Criteria,Sort,ref CurrentPage, PageSize,ref TotalCount);
		}
	}
    
}
