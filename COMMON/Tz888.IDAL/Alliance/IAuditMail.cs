using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IAuditMail
    {

                /// <summary>
        /// ��������ͳ����Ϣ��Ŀ
        /// </summary> 
        /// <param name="strWhere"></param>
        /// <returns></returns>
        int GetCount(string InfoType, string strWhere);

        int GetCount(string tblName, string fldName, string strWhere);


    }
}
