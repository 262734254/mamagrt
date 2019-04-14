using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;

namespace Tz888.IDAL.TFZS
{
    /// <summary>
    /// 主指标数据访问逻辑接口定义
    /// </summary>
    public interface IMainTarget
    {
        /// <summary>
        /// 根据评估类型获取主指标列表
        /// </summary>
        /// <param name="mainTargetType">评估类型代码：债权->ZQ 股权->GQ</param>
        /// <returns>对应评估类型的所有主指标信息</returns>
        List<TFZS_MainTarget> GetListByTargetType(string mainTargetType);

        /// <summary>
        /// 获取单项指标的评分
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="DicMainCode"></param>
        /// <returns></returns>
        decimal GetEvaluateCount(long InfoID, string DicMainCode);
    }
}
