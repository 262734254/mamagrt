using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Common
{
    /// <summary>
    /// ���ֲ�������
    /// </summary>
    public interface ISetCurrency
    {
        /// <summary>
        /// ��ȡ���в�����Ϣ
        /// </summary>
        /// <returns></returns>
        DataView GetList();
    }
}
