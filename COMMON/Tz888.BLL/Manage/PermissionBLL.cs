using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.BLL.Manage
{
    public class PermissionBLL
    {
        private readonly Tz888.IDAL.Manage.IPermission dal = Tz888.DALFactory.DataAccess.CreateIPermission();
        #region --Ȩ�޼���--
        public static bool Check(string LoginName,string WorkType,string InfoTypeID,string InfoPermissionTypeCode)
        {
            Tz888.Model.Manage.Permission model = new Tz888.Model.Manage.Permission();
            Tz888.IDAL.Manage.IPermission permission = Tz888.DALFactory.DataAccess.CreateIPermission();

            model.LoginName = LoginName;
            model.WorkType = WorkType;
            model.InfoTypeId = InfoTypeID;
            model.InfoPermissionTypeCode = InfoPermissionTypeCode;
            bool result=permission.Check(model);
            return result;
        }
        public static DataTable CheckRole(string loginName, string roleGroup)
        {
            Tz888.IDAL.IConn IConn = Tz888.DALFactory.DataAccess.CreateIConn();
            bool result = false;
            long CurrPage = 0;
            long TotalCount = 0;
            string strWhere = "loginName='" + loginName + "' and roleGroup='" + roleGroup + "'" ;
            DataTable dt = IConn.GetList("permissionVIW", "id",
                "*", strWhere, "id ", ref CurrPage, 0, ref TotalCount);
            return dt;
        }
        #endregion
        #region Ȩ������
        public bool PermissionSet(Tz888.Model.Manage.Permission model, int IsDelete)
        {
            bool result = dal.PermissionSet(model, IsDelete);
            return result;
        }
        #endregion

        #region ��ɫ��
        public bool RoleGroupDelete(Tz888.Model.Manage.Permission model)
        {
            bool result = dal.RoleGroupDelete(model);
            return result;
        }
        public bool RoleGroupUpdate(Tz888.Model.Manage.Permission model)
        {
            bool result = dal.RoleGroupUpdate(model);
            return result;
        }
        public bool RoleGroupInsert(Tz888.Model.Manage.Permission model)
        {
            bool result = dal.RoleGroupInsert(model);
            return result;
        }

        public static bool IsRoleGroupPermission(string loginName, int roleGroup)//�ж��Ƿ���н�ɫ��Ȩ��
        {
            Tz888.BLL.Conn dal = new Conn();
            DataTable dt = new DataTable();

            long CurrPage = 0;
            long TotalCount = 0;
            string strWhere = "loginName='"+loginName+"' and roleGroup='"+roleGroup+"'";
            dt = dal.GetList("PermissionTab", "id",
                "*", strWhere, "id ", ref CurrPage, 0, ref TotalCount);
            if (dt != null && dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region  --��ɫ--
        public bool WorkTypeAdd(Tz888.Model.Manage.Permission model)
        {
            bool result = dal.WorkTypeAdd(model);
            return result;
        }
        public bool WorkTypeUpdate(Tz888.Model.Manage.Permission model)
        {
            bool result = dal.WorkTypeUpdate(model);
            return result;
        }
        public bool WorkTypeDelete(Tz888.Model.Manage.Permission model)
        {
            bool result = dal.WorkTypeDelete(model);
            return result;
        }

        public static bool IsMenuPermission(string loginName, string menuType)//�ж��Ƿ���в˵�Ȩ��
        {
            Tz888.BLL.Conn dal = new Conn();
            DataTable dt = new DataTable();
            string workType = "";
            long CurrPage = 0;
            long TotalCount = 0;
            string strWhere = "loginName='" + loginName + "'";
            dt = dal.GetList("PermissionTab", "id",
                "workType", strWhere, "id ", ref CurrPage, 0, ref TotalCount);
            if (dt != null && dt.Rows.Count > 0)
            {
                workType=dt.Rows[0][0].ToString();
                dt = null;
                strWhere = "workType='" + workType + "' and menuType='"+menuType+"'";
                dt = dal.GetList("MenuPermissionViw", "id",
                 "*", strWhere, "id ", ref CurrPage, 0, ref TotalCount);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region --�˵�Ȩ��--
        public bool InfoTypeSet(Tz888.Model.Manage.Permission model)//��ϢȨ������
        {
            bool result = dal.InfoTypeSet(model);
            return result;
        }

        public bool MeneSysTypeSet(Tz888.Model.Manage.Permission model)//�˵���ϵͳ����
        {
            bool result = dal.MeneSysTypeSet(model);
            return result;
        }
        public bool MenuDelete(Tz888.Model.Manage.Permission model)
        {
            bool result=dal.MenuDelete(model);
            return result;
            
        }
        public bool MenuInsert(Tz888.Model.Manage.Permission model)//�˵����
        {
            bool result = dal.MenuInsert(model);
            return result;
        }
        public bool MenuUpdate(Tz888.Model.Manage.Permission model)// �˵��޸�
        {
            bool result = dal.MenuUpdate(model);
            return result;
        }
        #endregion

        #region --��ϢȨ��--
        public bool InfoPermissionUpdate(Tz888.Model.Manage.Permission model)
        {
            bool resut = dal.InfoPermissionUpdate(model);
            return resut;
        }
        public bool InfoPermissionInsert(Tz888.Model.Manage.Permission model)
        {
            bool resut = dal.InfoPermissionInsert(model);
            return resut;
        }
        public bool InfoPermissionDelete(Tz888.Model.Manage.Permission model)
        {
            bool resut = dal.InfoPermissionDelete(model);
            return resut;
        }
        #endregion
    }
}
