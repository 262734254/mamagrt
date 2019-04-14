using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// 融资信息逻辑方法接口
    /// </summary>
    public interface IProjectInfo
    {
        /// <summary>
        /// 最新添加融资信息
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <param name="infoContactModel"></param>
        /// <returns></returns>
        long InsertNew(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);
        /// <summary>
        /// 添加融资资源信息
        /// </summary>
        long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> InfoResourceModels
            );


        /// <summary>
        /// 修改项目信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.Info.ProjectSetModel model);

        /// <summary>
        /// 得到一个对象实体(只包含MerchantInfoTab的信息)
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ProjectInfoModel GetModel(long InfoID);

        /// <summary>
        /// 得到一个完整的对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ProjectSetModel GetIntegrityModel(long InfoID);

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


        #region 采集
        
        Tz888.Model.Info.ExcavateProjectModel GetExcavateProjectModel(long InfoID);

       
        bool excavateProjecttabUpdatePublish(long id);
        
        bool excavateProjecttabUpdateDelete(long id);
        #endregion


        long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel);
        bool PublishProjectZQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel);

        long PublishProjectGQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel);
        bool PublishProjectGQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel);

        bool ProjectInfoZQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);

        bool ProjectInfoGQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);




        //股权重构，新添加
        long PublishProjectGQ1(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.ProjectInfoModel projectInfoModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel,
           List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);

        //债权重构，新添加
        long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);
    }
}
 