using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Common;
using System.Data;
using System.Data.SqlClient;
using Tz888.DBUtility;

namespace Tz888.SQLServerDAL.Common
{
    public class ParameterDAL : IParameter
    {
        /// <summary>
        /// 获取所有投资类型设置
        /// </summary>
        /// <returns></returns>
        public DataView GetAllCapitalType()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CapitalTypeID", SqlDbType.Char,10),
			};
            parameters[0].Value = "Null";
            DataSet ds = DbHelperSQL.RunProcedure("SetCapitalTypeTab_GetAllList", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }


        #region 获取投资项目退出方式
        public DataView GetALLReturnMode()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ActionType", SqlDbType.Char,10),
			};
            parameters[0].Value = "ALL";
            DataSet ds = DbHelperSQL.RunProcedure("SetReturnModeTAB_Get", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        #endregion

        #region 获取投资项目阶段
        public DataView GetALLStage()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ActionType", SqlDbType.Char,10),
			};
            parameters[0].Value = "ALL";
            DataSet ds = DbHelperSQL.RunProcedure("SETStageTAB_Get", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        #endregion

        #region 获取资本类型
        public DataView GetALLfinancingTarget()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ActionType", SqlDbType.Char,10),
			};
            parameters[0].Value = "ALL";
            DataSet ds = DbHelperSQL.RunProcedure("SETfinancingTargetTab_Get", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        #endregion

        #region 获取参与项目管理的方式
        public DataView GetALLJoinManageTab()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ActionType", SqlDbType.Char,10),
			};
            parameters[0].Value = "ALL";
            DataSet ds = DbHelperSQL.RunProcedure("SETJoinManageTab_Get", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }
        #endregion
    }
}
