using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.TFZS;
using Tz888.DALFactory;

namespace Tz888.BLL.TFZS
{
    public class TFZS_ProjectDetaiSubBLL
    {
        private readonly ITFZS_ProjectDetaiSub dal = DataAccess.CreateTFZS_ProjectDetaiSub();

        /// <summary>
        /// �����ظ�ָ����
        /// </summary>
        /// <param name="model">����Ϣʵ��</param>
        /// <param name="IsSave">�Ƿ����ݱ��������ݿ�</param>
        /// <returns></returns>
        public decimal Save(Tz888.Model.TFZS.TFZS_ProjectDetaiSubModel model, bool IsSave)
        {
            return dal.Save(model,IsSave);
        }
    }
}
