using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Manage;

namespace Tz888.SQLServerDAL.Manage
{
    public class MenuPermissionDAL : IMenuPermission
    {

        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>
        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            Tz888.SQLServerDAL.Conn dal = new Tz888.SQLServerDAL.Conn();
            return (dal.GetList(
                "MenuPermissionTabList",
                "ID",
                SelectCol,
                Criteria,
                OrderBy,
                ref CurrentPage,
                PageSize,
                ref PageCount).DefaultView);
        }
        #endregion
    }
}
