using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Common
{
    public interface IParameter
    {
        /// <summary>
        /// 获取所有投资类型设置
        /// </summary>
        /// <returns></returns>
        DataView GetAllCapitalType();

        DataView GetALLReturnMode();

        DataView GetALLStage();

        DataView GetALLfinancingTarget();

        DataView GetALLJoinManageTab();
    }
}
