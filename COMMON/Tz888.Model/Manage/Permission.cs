using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Manage
{
    public class Permission
    {
        private string _loginName;

        #region --角色组--
        private string _roleGroup;//groupId
        private string _roleGroupName;//roleGroupName
        #endregion
        #region --角色--
        private string _workType;
        private string _workTypeName;
        private int _active;
        private string _remark;
        private string _infoTypeId;
        private int _value;
        private string _menuType;
        private string _menuTypeName;
        private string _infoPermissionTypeCode;
        private int _isDelete;
        private int _isMenu;
        private int _menuSequence;
        private string _url;

        #endregion

        #region --信息权限--
        private string _infoPermissionType;
        private string _infoPermissionTypeName;
        #endregion
        #region --权限--
        private string _changeBy;
        private DateTime _changeTime;
        #endregion

        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        #region --角色组--
        public string RoleGroup
        {
            get { return _roleGroup; }
            set { _roleGroup = value; }
        }

        public string RoleGroupName
        {
            get { return _roleGroupName; }
            set { _roleGroupName = value; }
        }
        #endregion

        #region --信息权限--
        public string InfoPermissionType
        {
            get { return _infoPermissionType; }
            set { _infoPermissionType = value; }
        }

        public string InfoPermissionTypeName
        {
            get { return _infoPermissionTypeName; }
            set { _infoPermissionTypeName = value; }
        }
        #endregion
        #region --角色--
        public string WorkType
        {
            get { return _workType; }
            set { _workType = value; }
        }
        public string WorkTypeName
        {
            get { return _workTypeName; }
            set { _workTypeName = value; }
        }
        public int Active
        {
            get { return _active; }
            set { _active = value; }
        }
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public string InfoTypeId
        {
            get { return _infoTypeId; }
            set { _infoTypeId = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public string MenuType
        {
            get { return _menuType; }
            set { _menuType = value; }
        }
        public string MenuTypeName
        {
            get { return _menuTypeName; }
            set { _menuTypeName = value; }
        }
        public string InfoPermissionTypeCode
        {
            get { return _infoPermissionTypeCode; }
            set { _infoPermissionTypeCode = value; }
        }
        public int IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
        public int IsMenu
        {
            get { return _isMenu; }
            set { _isMenu = value; }
        }
        public int MenuSequence
        {
            get { return _menuSequence; }
            set { _menuSequence = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        #endregion

        #region --权限--
        public string ChangeBy
        {
            get { return _changeBy; }
            set { _changeBy = value; }
        }

        public DateTime ChangeTime
        {
            get { return _changeTime; }
            set { _changeTime = value; }
        }
        #endregion
    }
}
