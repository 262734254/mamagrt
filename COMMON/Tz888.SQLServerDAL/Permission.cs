using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// ����
    /// </summary>
    public class Permission : IPermission
    {

        /// <summary>
        /// ��ȡ���в˵���
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllMenu()
        {
            SqlParameter[] parms = new SqlParameter[0];
            DataSet ds = DbHelperSQL.RunProcedure("MemberMenuTab_List", parms, "Menus");
            if (ds.Tables["Menus"].Rows.Count > 0)
                return ds.Tables["Menus"];
            else
                return null;
        }

        /// <summary>
        /// ��ȡ���в˵�Ȩ����
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenuPermission()
        {
            SqlParameter[] parms = new SqlParameter[0];
            DataSet ds = DbHelperSQL.RunProcedure("MemberMenuPermissionTab_List", parms, "MenuPermissions");
            if (ds.Tables["MenuPermissions"].Rows.Count > 0)
                return ds.Tables["MenuPermissions"];
            else
                return null;
        }

        /// <summary>
        /// ��ȡ���й���Ȩ����
        /// </summary>
        /// <returns></returns>
        public DataTable GetPowerPermission()
        {
            SqlParameter[] parms = new SqlParameter[0];
            DataSet ds = DbHelperSQL.RunProcedure("MemberPowerPermissionTab_List", parms, "PowerPermissions");
            if (ds.Tables["PowerPermissions"].Rows.Count > 0)
                return ds.Tables["PowerPermissions"];
            else
                return null;
        }
    }
}
