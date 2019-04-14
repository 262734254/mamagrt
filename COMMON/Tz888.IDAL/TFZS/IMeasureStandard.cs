using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.TFZS;

namespace Tz888.IDAL.TFZS
{
    /// <summary>
    /// ����Ŀ�����ݷ����߼��ӿڶ���
    /// </summary>
    public interface IMeasureStandard
    {
        /// <summary>
        /// ���ݱ���ָ������ȡ����Ŀ����Ϣ�б�
        /// </summary>
        /// <param name="expressCode">����ָ�����</param>
        /// <returns>����Ŀ����Ϣ�б�</returns>
        List<TFZS_MeasureStandard> GetListByExpressCode(string expressCode);
    }
}
