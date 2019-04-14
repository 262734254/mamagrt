using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IPermission
    {

        /// <summary>
        /// 获取所有菜单项
        /// </summary>
        DataTable GetAllMenu();

        /// <summary>
        /// 获取所有菜单权限项
        /// </summary>
        /// <returns></returns>
        DataTable GetMenuPermission();

        /// <summary>
        /// 获取所有功能权限项
        /// </summary>
        /// <returns></returns>
        DataTable GetPowerPermission();
    }
}
