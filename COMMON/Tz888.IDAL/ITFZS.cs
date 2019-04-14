using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;

namespace Tz888.IDAL
{
    public interface ITFZS
    {
        /// <summary>
        /// 根据评估类型获取主指标列表
        /// </summary>
        /// <param name="mainTargetType">评估类型代码：债权->ZQ 股权->GQ</param>
        /// <returns>对应评估类型的所有主指标信息</returns>
        List<TFZS_MainTarget> GetListByTargetType(string mainTargetType);
    }
}
