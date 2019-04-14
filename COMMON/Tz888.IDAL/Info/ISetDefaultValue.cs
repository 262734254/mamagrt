using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface ISetDefaultValue
    {
        #region-- 添加 -------------------
        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        long Insert(Tz888.Model.Info.DefaultValueModel model);
        #endregion

        #region-- 修改 -------------------
        /// <summary>
        /// 修改职务类型类别
        /// </summary>
        /// <returns>是否操作成功（true成功，false失败）</returns>
        bool Update(Tz888.Model.Info.DefaultValueModel model);
        #endregion

        #region-- 删除 -------------------
        /// <summary>
        /// 删除
        /// </summary>		
        /// <returns>是否操作成功（true成功，false失败）</returns>
        bool Delete(long ID);
        #endregion

        #region-- 取值 -------------------
        /// <summary>
        /// 取值
        /// </summary>		
        /// <returns>返回Dataview</returns>
        DataView GetValue(Tz888.Model.Info.DefaultValueModel model);
        #endregion

        #region-- 查询对应记录 -----------
        /// <summary>
        /// 查询对应记录
        /// </summary>
        /// <param name="Key">关键字</param>		
        /// <returns>是否操作成功（true成功，false失败）</returns>
        Tz888.Model.Info.DefaultValueModel GetDetail(string Key);

        #endregion

        #region-- 查询列表 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="SelectCol">选择列</param>		
        /// <param name="Criteria">查询条件</param>
        /// <param name="OrderBy">排序</param>
        /// <param name="CurrentPage">显示的当前页号</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="PageCount">通过该查询条件，返回的查询记录的页数</param>
        /// <returns>查询列表</returns>
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
        #endregion

        #region
        /// <summary>
        /// 复制数据,
        /// </summary>
        /// <param name="sourceID">源ID</param>
        /// <returns></returns>
        long Clone(long sourceID, Tz888.Model.Info.DefaultValueModel model);
        #endregion

    }
}
