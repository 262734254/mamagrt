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
        /// ������ָ������ȡ���ж�Ӧ�ñ���ָ����Ϣ�б�
        /// </summary>
        /// <param name="mainTargetCode">����ָ�����</param>
        /// <returns>����ָ���б�</returns>
        public List<TFZS_ExpressTarget> GetListByMainTargetCode(string mainTargetCode)
        {
            return dal.GetListByMainTargetCode(mainTargetCode);
        }


        /// <summary>
        /// ������ָ�����ͻ�ȡ���ж�Ӧ�ñ���ָ����Ϣ�б�
        /// </summary>
        /// <param name="mainTargetType">��������(ծȨZQ/��ȨGQ)</param>
        /// <returns>����ָ���б�</returns>
        public List<TFZS_ExpressTarget> GetListByMainTargetType(string mainTargetType)
        {
            return dal.GetListByMainTargetType(mainTargetType);
        }
    }
}
