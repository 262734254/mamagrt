using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Common
{
    /// <summary>
    /// 币种参数设置
    /// </summary>
    public interface ISetCurrency
    {
        /// <summary>
        /// 获取所有参数信息
        /// </summary>
        /// <returns></returns>
        DataView GetList();
    }
}
