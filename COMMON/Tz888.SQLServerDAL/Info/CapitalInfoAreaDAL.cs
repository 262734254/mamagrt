using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.DBUtility;
using Tz888.IDAL.Info;

namespace Tz888.SQLServerDAL.Info
{
    /// <summary>
    /// 投资区域数据库访问逻辑类
    /// </summary>
    public class CapitalInfoAreaDAL : ICapitalInfoArea
    {
        private const string SP_CapitalInfoArea_Insert = "CapitalInfoAreaTab_Insert";

        #region 获取投资资源的投资区域信息
        /// <summary>
        /// 获取投资资源的投资区域信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public List<Tz888.Model.Info.CapitalInfoAreaModel> GetModelList(long InfoID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            List<Tz888.Model.Info.CapitalInfoAreaModel> lists = new List<Tz888.Model.Info.CapitalInfoAreaModel>();

            DataSet ds = DbHelperSQL.RunProcedure("CapitalInfoAreaTab_GetListByInfoID", parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Tz888.Model.Info.CapitalInfoAreaModel model = new Tz888.Model.Info.CapitalInfoAreaModel();
                model.InfoID = InfoID;
                if (ds.Tables[0].Rows[i]["InfoAreaID"].ToString() != "")
                {
                    model.InfoAreaID = Convert.ToInt32(ds.Tables[0].Rows[i]["InfoAreaID"]);
                }
                model.CountryCode = ds.Tables[0].Rows[i]["CountryCode"].ToString();
                model.CountryName = ds.Tables[0].Rows[i]["CountryName"].ToString();
                model.ProvinceID = ds.Tables[0].Rows[i]["ProvinceID"].ToString();
                model.ProvinceName = ds.Tables[0].Rows[i]["ProvinceName"].ToString();
                model.CityID = ds.Tables[0].Rows[i]["CityID"].ToString();
                model.CityName = ds.Tables[0].Rows[i]["CityName"].ToString();
                model.CountyID = ds.Tables[0].Rows[i]["CountyID"].ToString();
                model.CountyName = ds.Tables[0].Rows[i]["CountyName"].ToString();

                lists.Add(model);
            }
            return lists;
        }

        #endregion

        #region 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int InfoAreaID)
        {

            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoAreaID", SqlDbType.Int,4)
				};
            parameters[0].Value = InfoAreaID;
            DbHelperSQL.RunProcedure("CapitalInfoAreaTab_Delete", parameters, out rowsAffected);
            if (rowsAffected == 0)
                return true;
            return false;
        }
        #endregion

        #region 删除指定信息的所有区域信息
        /// <summary>
        /// 删除指定信息的所有区域信息
        /// </summary>
        public void DeleteByInfoID(long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure("CapitalInfoAreaTab_DeleteByInfoID", parameters, out rowsAffected);
        }
        #endregion

        #region 带事务的方法
        /// <summary>
        /// 添加信息联系人(使用事务控制)
        /// </summary>
        public bool Insert(SqlConnection sqlConn, SqlTransaction sqlTran, Tz888.Model.Info.CapitalInfoAreaModel model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoAreaID", SqlDbType.Int,4),
					new SqlParameter("@InfoID", SqlDbType.BigInt,8),
					new SqlParameter("@CountryCode", SqlDbType.Char,10),
					new SqlParameter("@ProvinceID", SqlDbType.Char,10),
					new SqlParameter("@CityID", SqlDbType.Char,10),
					new SqlParameter("@CountyID", SqlDbType.Char,10)};
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.InfoID;
            parameters[2].Value = model.CountryCode;
            parameters[3].Value = model.ProvinceID;
            parameters[4].Value = model.CityID;
            parameters[5].Value = model.CountyID;

            DbHelperSQL.RunProcedure(sqlConn, sqlTran, SP_CapitalInfoArea_Insert, parameters, out rowsAffected);

            if (rowsAffected > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 删除指定信息的所有区域信息
        /// </summary>
        public bool DeleteByInfoID(SqlConnection sqlConn, SqlTransaction sqlTran, long InfoID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@InfoID", SqlDbType.BigInt,8)
				};
            parameters[0].Value = InfoID;
            DbHelperSQL.RunProcedure(sqlConn, sqlTran, "CapitalInfoAreaTab_DeleteByInfoID", parameters, out rowsAffected);
            if (rowsAffected > 0)
                return true;
            return false;
        }
        #endregion
    }
}
