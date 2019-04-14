using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IResourcesNotice
    {
                /// <summary>
        ///  增加一条数据
        /// </summary>
        bool Add(Tz888.Model.ResourcesNotice model);

                /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.ResourcesNotice model);

                /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        DataSet Select(int ID);

                /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int ID);
    }
}
