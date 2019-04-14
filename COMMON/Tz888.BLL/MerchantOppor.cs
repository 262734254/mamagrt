using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;

namespace Tz888.BLL
{
    public class MerchantOppor
    {
        private readonly IMerchantOppor dal = DataAccess.CreateMerchantOppor();
        /// <summary>
        /// 设置重大投资商机
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="isVip">1 重大商机 0 取消</param>
        /// <param name="VipAbout"></param>
        /// <returns></returns>
        public bool IsVip(long InfoID, int isVip, string VipAbout)
        {
            return dal.IsVip(InfoID, isVip, VipAbout);
        }
        /// <summary>
        /// 设置置顶
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="isTop">1 置顶 取消置顶</param>
        /// <returns></returns>
        public bool isTop(long InfoID, int isTop)
        {
            return dal.isTop(InfoID, isTop);
        }
    }
}
