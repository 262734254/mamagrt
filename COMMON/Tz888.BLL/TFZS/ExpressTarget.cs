using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;
using Tz888.DALFactory;
using Tz888.IDAL.TFZS;

namespace Tz888.BLL.TFZS
{
    public class ExpressTarget
    {
        private readonly IExpressTarget dal = DataAccess.CreateTFZS_ExpressTarget();

        /// <summary>
        /// 根据主指标代码获取所有对应得表现指标信息列表
        /// </summary>
        /// <param name="mainTargetCode">表现指标代码</param>
        /// <returns>表现指标列表</returns>
        public List<TFZS_ExpressTarget> GetListByMainTargetCode(string mainTargetCode)
        {
            return dal.GetListByMainTargetCode(mainTargetCode);
        }


        /// <summary>
        /// 根据主指标类型获取所有对应得表现指标信息列表
        /// </summary>
        /// <param name="mainTargetType">评价类型(债权ZQ/股权GQ)</param>
        /// <returns>表现指标列表</returns>
        public List<TFZS_ExpressTarget> GetListByMainTargetType(string mainTargetType)
        {
            return dal.GetListByMainTargetType(mainTargetType);
        }
    }
}
