using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;
using System.Data;
namespace Tz888.IDAL.Company
{
    public interface ILMOrderTab
    {
        /// <summary>
        /// 添加联盟订单分红信息
        /// </summary>
        /// <param name="com"></param>
        /// <returns></returns>
        int AddLMOrder(LmOrderTab order);

    }
}
