using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;

namespace Tz888.IDAL.TFZS
{
    /// <summary>
    /// 衡量目标数据访问逻辑接口定义
    /// </summary>
    public interface IMeasureStandard
    {
        /// <summary>
        /// 根据表现指标代码获取衡量目标信息列表
        /// </summary>
        /// <param name="expressCode">表现指标代码</param>
        /// <returns>衡量目标信息列表</returns>
        List<TFZS_MeasureStandard> GetListByExpressCode(string expressCode);
    }
}
