using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Common
{
    public interface IParameter
    {
        /// <summary>
        /// ��ȡ����Ͷ����������
        /// </summary>
        /// <returns></returns>
        DataView GetAllCapitalType();

        DataView GetALLReturnMode();

        DataView GetALLStage();

        DataView GetALLfinancingTarget();

        DataView GetALLJoinManageTab();
    }
}
