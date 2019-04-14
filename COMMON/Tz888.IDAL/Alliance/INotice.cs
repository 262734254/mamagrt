using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface INotice
    {
                /// <summary>
        ///  增加或更新资源联盟首页公告 
        /// </summary>
        bool Add(Tz888.Model.Notice model);

        /// <summary>
        ///   公告
        /// </summary>
        /// <returns></returns>
        DataSet GetNoticeMess();
    }
}
