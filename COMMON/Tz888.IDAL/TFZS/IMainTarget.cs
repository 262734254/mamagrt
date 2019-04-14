using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;

namespace Tz888.IDAL.TFZS
{
    /// <summary>
    /// ��ָ�����ݷ����߼��ӿڶ���
    /// </summary>
    public interface IMainTarget
    {
        /// <summary>
        /// �����������ͻ�ȡ��ָ���б�
        /// </summary>
        /// <param name="mainTargetType">�������ʹ��룺ծȨ->ZQ ��Ȩ->GQ</param>
        /// <returns>��Ӧ�������͵�������ָ����Ϣ</returns>
        List<TFZS_MainTarget> GetListByTargetType(string mainTargetType);

        /// <summary>
        /// ��ȡ����ָ�������
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="DicMainCode"></param>
        /// <returns></returns>
        decimal GetEvaluateCount(long InfoID, string DicMainCode);
    }
}
