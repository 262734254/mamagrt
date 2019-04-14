using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;
using Tz888.DALFactory;
using Tz888.IDAL.TFZS;

namespace Tz888.BLL.TFZS
{
    public class MeasureStandard
    {
        private readonly IMeasureStandard dal = DataAccess.CreateTFZS_MeasureStandard();
        /// <summary>
        /// 根据表现指标代码获取衡量目标信息列表
        /// </summary>
        /// <param name="expressCode">表现指标代码</param>
        /// <returns>衡量目标信息列表</returns>
        public List<TFZS_MeasureStandard> GetListByExpressCode(string expressCode)
        {
            return dal.GetListByExpressCode(expressCode);
        }
    }
}
