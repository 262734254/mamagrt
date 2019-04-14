using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Manage
{
    public interface IPermission
    {
        bool PermissionSet(Tz888.Model.Manage.Permission model, int IsDelete);//权限设置
        #region --角色组--
        bool RoleGroupDelete(Tz888.Model.Manage.Permission model);
        bool RoleGroupUpdate(Tz888.Model.Manage.Permission model);
        bool RoleGroupInsert(Tz888.Model.Manage.Permission model);
        #endregion

        #region --角色--
        bool WorkTypeDelete(Tz888.Model.Manage.Permission model);
        bool WorkTypeUpdate(Tz888.Model.Manage.Permission model);
        bool WorkTypeAdd(Tz888.Model.Manage.Permission model);
        #endregion

        bool InfoTypeSet(Tz888.Model.Manage.Permission model);//信息权限设置

        bool MeneSysTypeSet(Tz888.Model.Manage.Permission model);//菜单、系统设置

        bool MenuDelete(Tz888.Model.Manage.Permission model);//菜单删除
        bool MenuInsert(Tz888.Model.Manage.Permission model);//菜单添加
        bool MenuUpdate(Tz888.Model.Manage.Permission model);// 菜单修改

        #region --信息权限--
        bool InfoPermissionUpdate(Tz888.Model.Manage.Permission model);
        bool InfoPermissionInsert(Tz888.Model.Manage.Permission model);
        bool InfoPermissionDelete(Tz888.Model.Manage.Permission model);
        bool Check(Tz888.Model.Manage.Permission model);
        #endregion
    }
}
