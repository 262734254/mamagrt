using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DBUtility;
using System.Data.SqlClient;
using Tz888.IDAL.Info;

namespace Tz888.SQLServerDAL.Info
{
    public class InfoDefaultDEF : IInfoDefaultDEF
    {
        public long Insert(Tz888.Model.Info.InfoDefaultDEFModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[4];

            parameters[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            parameters[0].Value = model.ID;
            parameters[0].Direction = ParameterDirection.InputOutput;
            parameters[1] = new SqlParameter("@InfoID", SqlDbType.BigInt);
            parameters[1].Value = model.InfoID;

            parameters[2] = new SqlParameter("@SubDefaultValueID", SqlDbType.BigInt);
            parameters[2].Value = model.SubDefaultValueID;

            parameters[3] = new SqlParameter("@DefType", SqlDbType.TinyInt);
            parameters[3].Value = model.DefType;


            DbHelperSQL.RunProcedure("InfoDefaultDEFTab_Insert", parameters, out rowsAffected);
            return Convert.ToInt64(parameters[0].Value);
        }
        /// <summary>
        /// 将所选择的项全部置为不选择状态
        /// </summary>
        /// <returns></returns>
        public bool DeSelect(long ID)
        {
            int rowsAffected;

            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@InfoID", SqlDbType.BigInt);
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("InfoDefaultDEFTab_DeSelect", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        public bool Delete(long ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("@ID", SqlDbType.BigInt);
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("InfoDefaultDEFTab_Delete", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 选择infoID的关键字等的定义
        /// </summary>
        /// <param name="infoID">信息ID</param>
        /// <param name="defType">标题：1，关键字：2，网页描述：4</param>
        /// <returns></returns>
        public DataView GetList(
            long infoID,
            byte defType
            )
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@InfoID", SqlDbType.BigInt);
            parameters[0].Value = infoID;

            parameters[1] = new SqlParameter("@DefType", SqlDbType.TinyInt);
            parameters[1].Value = defType;

            DataSet ds = DbHelperSQL.RunProcedure("InfoDefaultDEFTabList", parameters,"ds");

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables["ds"].DefaultView;

            return null;
        }
    }
}
