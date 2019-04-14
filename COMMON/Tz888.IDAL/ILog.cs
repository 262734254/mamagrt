using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ILog
    {
        /// <summary>
        ///  增加一条数据
        /// </summary>
        bool Insert(Tz888.Model.LogModel model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(long LogID);
    }
}
