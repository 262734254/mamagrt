using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Common;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Common
{
    public class SetMerchantAttribute
    {
        private readonly ISetMerchantAttribute dal = DataAccess.CreateSetMerchantAttribute();

        /// <summary>
        /// 获取投融资金额的预设信息
        /// </summary>
        /// <returns>投融资金额的预设信息</returns>
        public DataView GetList()
        {
            return dal.GetList();
        }
    }
}
