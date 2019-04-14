using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Common;

namespace Tz888.IDAL.Common
{
    /// <summary>
    /// 行业类别数据库访问逻辑接口定义
    /// </summary>
    public interface IIndustry
    {
        /// <summary>
        /// 取得行业分类的所有列表
        /// </summary>
        /// <returns>行业分类列表</returns>
        List<IndustryModel> GetAllList();


        /// <summary>
        /// 根据行业代码获取行业名称
        /// </summary>
        /// <param name="IndustryID">行业代码</param>
        /// <returns></returns>
        string GetNameByID(string IndustryID);

        /// <summary>
        /// 修改时根据行业代码获取行业名称
        /// </summary>
        /// <param name="IndustryID">list</param>
        /// <returns></returns>
        List<IndustryModel> GetIndustryList(string IndustryList);


        /// <summary>
        /// 获取所有行业信息
        /// </summary>
        /// <returns></returns>
        DataView dvGetAllIndustry();
    }
}
