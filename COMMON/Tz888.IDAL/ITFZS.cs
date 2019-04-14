using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;

namespace Tz888.IDAL
{
    public interface ITFZS
    {
        /// <summary>
        /// �����������ͻ�ȡ��ָ���б�
        /// </summary>
        /// <param name="mainTargetType">�������ʹ��룺ծȨ->ZQ ��Ȩ->GQ</param>
        /// <returns>��Ӧ�������͵�������ָ����Ϣ</returns>
        List<TFZS_MainTarget> GetListByTargetType(string mainTargetType);
    }
}
