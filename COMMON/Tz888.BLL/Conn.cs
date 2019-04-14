using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class Conn
    {
       private readonly IConn dal = DataAccess.CreateIConn();
        public Conn()
        { }
        public DataTable GetList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return dal.GetList(tblName, strGetFields, fldName, PageSize, PageIndex, doCount, OrderType, strWhere);
        }
        public DataTable GetList(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetList(TableViewName, Key, SelectStr, Criteria, Sort, ref  CurrentPage, PageSize ,ref  TotalCount);
        }
        public int GetCount(string tblName, string fldName, string strWhere)
        { 
            return dal.GetCount(tblName, fldName, strWhere);
        }
       
        public DataTable GetWebSiteList(string tblName, string strGetFields, string fldName, int PageSize, int PageIndex, int doCount,
            int OrderType, string strWhere)
        {
            return dal.GetWebSiteList(tblName, strGetFields, fldName, PageSize, PageIndex, doCount, OrderType, strWhere);
        }

        public DataView GetList(string SPName, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetList(SPName, SelectStr, Criteria, Sort, ref CurrentPage, PageSize, ref TotalCount);
        }
        public bool Delect(string tablename, string where)
        {
            Tz888.SQLServerDAL.Conn con = new Tz888.SQLServerDAL.Conn();
            return con.Delect(tablename, where);
        }
        public bool Update(int psid, int ischeckup)
        {
            Tz888.SQLServerDAL.Conn con = new Tz888.SQLServerDAL.Conn();
            return con.Update(psid, ischeckup);
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
            Tz888.SQLServerDAL.Conn con = new Tz888.SQLServerDAL.Conn();
            return con.GetList(FileName, TableName, Where);
        }
    }
}
