using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;
using Tz888.DALFactory;
using Tz888.IDAL.TFZS;

namespace Tz888.BLL.TFZS
{
    public class MainTarget
    {
        private readonly IMainTarget dal = DataAccess.CreateTFZS_MainTarget();

        /// <summary>
        /// 根据评估类型获取主指标列表
        /// </summary>
        /// <param name="mainTargetType">评估类型代码：债权->ZQ 股权->GQ</param>
        /// <returns>对应评估类型的所有主指标信息</returns>
        public List<TFZS_MainTarget> GetListByTargetType(string mainTargetType)
        {
            return dal.GetListByTargetType(mainTargetType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="DicMainCode"></param>
        /// <returns></returns>
        public decimal GetEvaluateCount(long InfoID, string DicMainCode)
        {
            return dal.GetEvaluateCount(InfoID, DicMainCode);
        }
    }
}
