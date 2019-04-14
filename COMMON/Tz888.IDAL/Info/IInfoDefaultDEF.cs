using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IInfoDefaultDEF
    {
        long Insert(Tz888.Model.Info.InfoDefaultDEFModel model);
        /// <summary>
        /// 将所选择的项全部置为不选择状态
        /// </summary>
        /// <returns></returns>
        bool DeSelect(long ID);

        bool Delete(long ID);
        /// <summary>
        /// 选择infoID的关键字等的定义
        /// </summary>
        /// <param name="infoID">信息ID</param>
        /// <param name="defType">标题：1，关键字：2，网页描述：4</param>
        /// <returns></returns>
        DataView GetList(
            long infoID,
            byte defType
            );
    }
}
