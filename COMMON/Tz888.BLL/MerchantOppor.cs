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
        /// �����ش�Ͷ���̻�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="isVip">1 �ش��̻� 0 ȡ��</param>
        /// <param name="VipAbout"></param>
        /// <returns></returns>
        public bool IsVip(long InfoID, int isVip, string VipAbout)
        {
            return dal.IsVip(InfoID, isVip, VipAbout);
        }
        /// <summary>
        /// �����ö�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="isTop">1 �ö� ȡ���ö�</param>
        /// <returns></returns>
        public bool isTop(long InfoID, int isTop)
        {
            return dal.isTop(InfoID, isTop);
        }
    }
}
