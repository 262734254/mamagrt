using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Manage
{
    public interface IPermission
    {
        bool PermissionSet(Tz888.Model.Manage.Permission model, int IsDelete);//Ȩ������
        #region --��ɫ��--
        bool RoleGroupDelete(Tz888.Model.Manage.Permission model);
        bool RoleGroupUpdate(Tz888.Model.Manage.Permission model);
        bool RoleGroupInsert(Tz888.Model.Manage.Permission model);
        #endregion

        #region --��ɫ--
        bool WorkTypeDelete(Tz888.Model.Manage.Permission model);
        bool WorkTypeUpdate(Tz888.Model.Manage.Permission model);
        bool WorkTypeAdd(Tz888.Model.Manage.Permission model);
        #endregion

        bool InfoTypeSet(Tz888.Model.Manage.Permission model);//��ϢȨ������

        bool MeneSysTypeSet(Tz888.Model.Manage.Permission model);//�˵���ϵͳ����

        bool MenuDelete(Tz888.Model.Manage.Permission model);//�˵�ɾ��
        bool MenuInsert(Tz888.Model.Manage.Permission model);//�˵����
        bool MenuUpdate(Tz888.Model.Manage.Permission model);// �˵��޸�

        #region --��ϢȨ��--
        bool InfoPermissionUpdate(Tz888.Model.Manage.Permission model);
        bool InfoPermissionInsert(Tz888.Model.Manage.Permission model);
        bool InfoPermissionDelete(Tz888.Model.Manage.Permission model);
        bool Check(Tz888.Model.Manage.Permission model);
        #endregion
    }
}
