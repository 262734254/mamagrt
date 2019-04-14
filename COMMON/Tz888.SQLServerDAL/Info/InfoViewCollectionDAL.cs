using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Info;

namespace Tz888.SQLServerDAL.Info
{
    public class InfoViewCollectionDAL : IInfoViewCollection
    {
        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        public DataTable GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Tz888.SQLServerDAL.Conn dal = new Tz888.SQLServerDAL.Conn();
            return (dal.GetList(
                "InfoViewCollectionVIW",
                "ID",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount));
        }
        #endregion
    }
}
