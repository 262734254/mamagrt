using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// 投资信息逻辑方法接口
    /// </summary>
    public interface ICapitalInfo
    {
        /// <summary>
        /// 添加融资资源信息
        /// </summary> 
        long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.CapitalInfoModel capitalInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels,
           // List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            );
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.CapitalInfoModel GetModel(long InfoID);
        /// <summary>
        /// 得到一个采集投资资源实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ExcavateCapitalInfoModel GetExcavateCapitalModel(long InfoID);

        bool excavateCapitaltabUpdatePublish(long id);
        bool excavateCapitaltabUpdateDelete(long id);
        /// <summary>
        /// 得到一个完整投资资源信息的对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.CapitalSetModel GetIntegrityModel(long InfoID);

        /// <summary>
        /// 修改投资资源
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.Info.CapitalSetModel model);

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

         #region 判断某一个用户是否购买了某一条信息
        /// <summary>
        /// 判断某一个用户是否购买了某一条信息;
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="InfoID">信息的InfoID</param>
        /// <returns></returns>
        bool bBuyInfoOfUserName(string UserName, string InfoID);
        #endregion
    }
}
