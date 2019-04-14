using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Common
{
    /// <summary>
    /// 国家地区信息数据库访问逻辑类接口定义
    /// </summary>
    public interface IZoneSelect
    {
        /// <summary>
        /// 获取所有的国家信息
        /// </summary>
        /// <returns>所有国家信息列表</returns>
        DataView GetCountryList();

        /// <summary>
        /// 获取指定国家的所有省级行政区信息
        /// </summary>
        /// <param name="CountryID">国家代码</param>
        /// <returns>所有省级行政区信息</returns>
        DataView GetProvinceList(string CountryID);

        /// <summary>
        /// 获取指定省的所有市级行政区信息
        /// </summary>
        /// <param name="ProvinceID">省级行政区代码</param>
        /// <returns>市级行政区信息</returns>
        DataView GetCityList(string ProvinceID);

        /// <summary>
        /// 获取指定市的所有县的信息
        /// </summary>
        /// <param name="CityID">城市代码</param>
        /// <returns>县信息</returns>
        DataView GetCountyList(string CityID);

        /// <summary>
        /// 根据国家代码获取国家名称
        /// </summary>
        /// <param name="CountryID"></param>
        /// <returns></returns>
        string GetCountryNameByCode(string CountryID);

        /// <summary>
        /// 根据省代码获取省名称
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        string GetProvinceNameByCode(string ProvinceID);

        /// <summary>
        /// 根据城市代码获取城市名称
        /// </summary>
        /// <param name="CityID"></param>
        /// <returns></returns>
        string GetCityNameByCode(string CityID);

        /// <summary>
        /// 根据县代码获取县名称
        /// </summary>
        /// <param name="CountyID"></param>
        /// <returns></returns>
        string GetCountyNameByCode(string CountyID);
    }
}
