using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ILog
    {
        /// <summary>
        ///  ����һ������
        /// </summary>
        bool Insert(Tz888.Model.LogModel model);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(long LogID);
    }
}
