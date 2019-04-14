using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IConn
    {
        DataTable GetList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount,
            int OrderType, string strWhere);

        DataTable GetList(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount);

       
        DataTable GetWebSiteList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount,
            int OrderType, string strWhere);

        int GetCount(string tblName, string fldName, string strWhere);

        DataView GetList(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount);
    }
    
}
