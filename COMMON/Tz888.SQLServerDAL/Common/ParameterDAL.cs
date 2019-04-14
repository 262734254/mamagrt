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
        /// ��ȡ����Ͷ����������
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


        #region ��ȡͶ����Ŀ�˳���ʽ
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

        #region ��ȡͶ����Ŀ�׶�
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

        #region ��ȡ�ʱ�����
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

        #region ��ȡ������Ŀ����ķ�ʽ
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
