using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;

namespace Tz888.IDAL.TFZS
{
    /// <summary>
    /// ����ָ�����ݷ����߼��ӿڶ���
    /// </summary>
    public interface IExpressTarget
    {
        /// <summary>
        /// ������ָ������ȡ���ж�Ӧ�ñ���ָ����Ϣ�б�
        /// </summary>
        /// <param name="mainTargetCode">����ָ�����</param>
        /// <returns>����ָ���б�</returns>
        List<TFZS_ExpressTarget> GetListByMainTargetCode(string mainTargetCode);



        /// <summary>
        /// ������ָ�����ͻ�ȡ���ж�Ӧ�ñ���ָ����Ϣ�б�
        /// </summary>
        /// <param name="mainTargetType">��������(ծȨZQ/��ȨGQ)</param>
        /// <returns>����ָ���б�</returns>
        List<TFZS_ExpressTarget> GetListByMainTargetType(string mainTargetType);
    }
}
