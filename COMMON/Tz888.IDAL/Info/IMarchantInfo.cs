using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// 招商信息逻辑方法接口
    /// </summary>
    public interface IMarchantInfo
    {
        /// <summary>
        /// 添加招商资源信息
        /// </summary>
        long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.MerchantInfoModel merchantInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
           //List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            );

        /// <summary>
        /// 添加资源列表信息
        /// </summary>
        /// <param name="resourcesModel"></param>
        /// <returns></returns>
       int InsertResources( Tz888.Model.Info.ResourcesModel resourcesModel);
        /// <summary>
        /// 联系人信息查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       Tz888.Model.Register.OrgContactModel SelLoginName(string name);   


        /// <summary>
        /// 修改招商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.Info.MerchantSetModel model);

        /// <summary>
        /// 得到一个对象实体(只包含MerchantInfoTab的信息)
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.MerchantInfoModel GetModel(long InfoID);

        /// <summary>
        /// 得到一个招商采集对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ExcavateMerchantInfoMode GetExcavateModel(long InfoID);
        /// <summary>
        /// 修改一个招商采集对象的ispublish字段
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool ExcavateTabUpdatePublish(long id);
                /// <summary>
        /// 修改一个招商采集对象的isdelete字段
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool ExcavateTabUpdateDelete(long id);
        /// <summary>
        /// 得到一个完整的对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.MerchantSetModel GetIntegrityModel(long InfoID);


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
    }
}
