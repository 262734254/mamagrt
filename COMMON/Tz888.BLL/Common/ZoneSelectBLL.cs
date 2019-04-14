using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Common;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Common
{
    public class ZoneSelectBLL
    {
        private readonly IZoneSelect dal = DataAccess.CreateZoneSelect();

        /// <summary>
        /// 获取所有的国家信息
        /// </summary>
        /// <returns>所有国家信息列表</returns>
        public DataView GetCountryList()
        {
            return dal.GetCountryList();
        }

        /// <summary>
        /// 获取指定国家的所有省级行政区信息
        /// </summary>
        /// <param name="CountryID">国家代码</param>
        /// <returns>所有省级行政区信息</returns>
        public DataView GetProvinceList(string CountryID)
        {
            return dal.GetProvinceList(CountryID);
        }

        /// <summary>
        /// 获取指定省的所有市级行政区信息
        /// </summary>
        /// <param name="ProvinceID">省级行政区代码</param>
        /// <returns>市级行政区信息</returns>
        public DataView GetCityList(string ProvinceID)
        {
            return dal.GetCityList(ProvinceID);
        }

        /// <summary>
        /// 获取指定市的所有县的信息
        /// </summary>
        /// <param name="CityID">城市代码</param>
        /// <returns>县信息</returns>
        public DataView GetCountyList(string CityID)
        {
            return dal.GetCountyList(CityID);
        }

        /// <summary>
        /// 根据国家代码获取国家名称
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns></returns>
        public string GetCountryNameByCode(string CountryID)
        {
            return dal.GetCountryNameByCode(CountryID);
        }

        /// <summary>
        /// 根据省代码获取省名称
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public string GetProvinceNameByCode(string ProvinceID)
        {
            return dal.GetProvinceNameByCode(ProvinceID);
        }

        /// <summary>
        /// 根据城市代码获取城市名称
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        public string GetCityNameByCode(string CityID)
        {
            return dal.GetCityNameByCode(CityID);
        }

        /// <summary>
        /// 根据县代码获取县名称
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        public string GetCountyNameByCode(string CountyID)
        {
            return dal.GetCountyNameByCode(CountyID);
        }
    }
}
