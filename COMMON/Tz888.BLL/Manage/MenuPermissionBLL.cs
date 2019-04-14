using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Manage;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Manage
{
    public class MenuPermissionBLL
    {
        private readonly IMenuPermission dal = DataAccess.CreateMenuPermission();

        #region-- 取有权限的菜单列表 --------------------
        /// <summary>
        /// 菜单	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView GetMenuList(string workType)
        {
            long CurrentPage = 1;
            long PageCount = 0;
            return dal.GetList(
                "*",
                "WorkType='" + workType + "' AND IsMenu<>0 AND Value<>0 AND Active<>0",
                "Sequence ASC,MenuType ASC",
                ref CurrentPage,
                -1,
                ref PageCount);
        }
        #endregion
    }
}
