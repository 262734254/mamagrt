using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface INotice
    {
                /// <summary>
        ///  ���ӻ������Դ������ҳ���� 
        /// </summary>
        bool Add(Tz888.Model.Notice model);

        /// <summary>
        ///   ����
        /// </summary>
        /// <returns></returns>
        DataSet GetNoticeMess();
    }
}
