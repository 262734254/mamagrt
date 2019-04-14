using System;
using System.Data;
namespace Tz888.IDAL
{
    /// <summary>
    /// 接口层ItzIndex_Edit 的摘要说明。
    /// </summary>
    public interface IIndex_Edit
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Tz888.Model.Index_Edit model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Tz888.Model.Index_Edit model);

        int Delete(int ID);


        #endregion  成员方法
    }
}
