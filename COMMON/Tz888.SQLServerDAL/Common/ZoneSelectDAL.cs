using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Common;
using Tz888.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Tz888.SQLServerDAL.Common
{
    /// <summary>
    /// 国家地区信息数据库访问逻辑类
    /// </summary>
    public class ZoneSelectDAL : IZoneSelect
    {
        private const string SP_GetCountryList = "SetCountryTab_GetList";
        private const string SP_GetProvinceList = "SetProvinceTab_GetList";
        private const string SP_GetCityList = "SetCityTab_GetList";
        private const string SP_GetCountyList = "SetCountyTab_GetList";

        private const string SP_GetCountryNameByCode = "SetCountryTab_GetNameByCode";
        private const string SP_GetProvinceNameByCode = "SetProvinceTab_GetNameByCode";
        private const string SP_GetCityNameByCode = "SetCityTab_GetNameByCode";
        private const string SP_GetCountyNameByCode = "SetCountyTab_GetNameByCode";


        /// <summary>
        /// 获取所有的国家信息
        /// </summary>
        /// <returns>所有国家信息列表</returns>
        public DataView GetCountryList()
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CountryID", SqlDbType.Char,10),
			};
            parameters[0].Value = "Null";
            DataSet ds = DbHelperSQL.RunProcedure(SP_GetCountryList, parameters,"ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 获取指定国家的所有省级行政区信息
        /// </summary>
        /// <param name="CountryID">国家代码</param>
        /// <returns>所有省级行政区信息</returns>
        public DataView GetProvinceList(string CountryID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CountryID", SqlDbType.Char,10),
			};
            parameters[0].Value = CountryID;
            DataSet ds = DbHelperSQL.RunProcedure(SP_GetProvinceList, parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 获取指定省的所有市级行政区信息
        /// </summary>
        /// <param name="ProvinceID">省级行政区代码</param>
        /// <returns>市级行政区信息</returns>
        public DataView GetCityList(string ProvinceID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@ProvinceID", SqlDbType.Char,10),
			};
            parameters[0].Value = ProvinceID;
            DataSet ds = DbHelperSQL.RunProcedure(SP_GetCityList, parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 获取指定市的所有县的信息
        /// </summary>
        /// <param name="CityID">城市代码</param>
        /// <returns>县信息</returns>
        public DataView GetCountyList(string CityID)
        {
            SqlParameter[] parameters = {
											new SqlParameter("@CityID", SqlDbType.Char,10),
			};
            parameters[0].Value = CityID;
            DataSet ds = DbHelperSQL.RunProcedure(SP_GetCountyList, parameters, "ds");
            if (ds == null || ds.Tables[0].Rows.Count == 0)
                return null;
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// 根据国家代码获取国家名称
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns></returns>
        public string GetCountryNameByCode(string CountryID)
        {
            SqlParameter para = new SqlParameter("@CountryID", SqlDbType.Char, 10);
            para.Value = CountryID;
            return Convert.ToString(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, SP_GetCountryNameByCode, para));
        }

        /// <summary>
        /// 根据省代码获取省名称
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public string GetProvinceNameByCode(string ProvinceID)
        {
            SqlParameter para = new SqlParameter("@ProvinceID", SqlDbType.Char, 10);
            para.Value = ProvinceID;
            return Convert.ToString(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, SP_GetProvinceNameByCode, para));
        }

        /// <summary>
        /// 根据城市代码获取城市名称
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        public string GetCityNameByCode(string CityID)
        {
            SqlParameter para = new SqlParameter("@CityID", SqlDbType.Char, 10);
            para.Value = CityID;
            return Convert.ToString(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, SP_GetCityNameByCode, para));
        }

        /// <summary>
        /// 根据县代码获取县名称
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public string GetCountyNameByCode(string CountyID)
        {
            SqlParameter para = new SqlParameter("@CountyID", SqlDbType.Char, 10);
            para.Value = CountyID;
            return Convert.ToString(SqlHelper.ExecuteScalar(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, SP_GetCountyNameByCode, para));
        }
    }
}
