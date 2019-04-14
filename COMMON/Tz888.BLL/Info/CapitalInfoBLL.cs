using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
    public class CapitalInfoBLL
    {
        private readonly ICapitalInfo dal = DataAccess.CreateInfo_CapitalInfo();

        /// <summary>
        /// 投资信息发布
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="capitalInfoModel"></param>
        /// <param name="infoContactModel"></param>
        /// <param name="shortInfoModel"></param>
        /// <param name="capitalInfoAreaModels"></param>
        /// <param name="infoContactManModels"></param>
        /// <param name="infoResourceModels"></param>
        /// <returns></returns>
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.CapitalInfoModel capitalInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.CapitalInfoAreaModel> capitalInfoAreaModels,
           // List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
           // return dal.Insert(mainInfoModel, capitalInfoModel, infoContactModel, shortInfoModel, capitalInfoAreaModels, infoContactManModels, infoResourceModels);
            return dal.Insert(mainInfoModel, capitalInfoModel, infoContactModel, shortInfoModel, capitalInfoAreaModels, infoResourceModels);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.CapitalInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }
        /// <summary>
        /// 得到一个采集投资对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ExcavateCapitalInfoModel GetExcavateCapitalModel(long ID)
        {
            return dal.GetExcavateCapitalModel( ID);
        }

        /// <summary>
        /// 修改一个采集招商实体的ispublish字段
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool excavateCapitaltabPublishUpdate(long id)
        {
            bool result = false;
            result = dal.excavateCapitaltabUpdatePublish(id);
            return result;
        }
        /// <summary>
        /// 修改一个采集招商实体的isdelete字段
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        /// <summary>
        public bool excavateCapitaltabDeleteUpdate(long id)
        {
            return dal.excavateCapitaltabUpdateDelete(id);
        }
        /// <summary>
        /// 得到一个完整投资资源信息的对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.CapitalSetModel GetIntegrityModel(long InfoID)
        {
            return dal.GetIntegrityModel(InfoID);
        }

        /// <summary>
        /// 修改投资信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.CapitalSetModel model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 判断某一用户是否购买了某一条信息
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="InfoID">信息InfoID</param>
        /// <returns></returns>
        public bool bIsBuyInfoOfUser(string UserName, string InfoID)
        {
            return dal.bBuyInfoOfUserName(UserName,InfoID);
        }


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
        public DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return dal.GetList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
        }
        #endregion

    }
}
