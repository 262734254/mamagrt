using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
    public class MarchantInfoBLL
    {
        private readonly IMarchantInfo dal = DataAccess.CreateInfo_MarchantInfo();

        /// <summary>
        /// 招商信息发布
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="merchantInfoModel"></param>
        /// <param name="infoContactModel"></param>
        /// <param name="shortInfoModel"></param>
        /// <param name="infoContactManModels"></param>
        /// <param name="infoResourceModels"></param>
        /// <returns></returns>
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.MerchantInfoModel merchantInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
           // List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            return dal.Insert(mainInfoModel, merchantInfoModel, infoContactModel, shortInfoModel, infoResourceModels);
        }
        /// <summary>
        /// 联系人信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tz888.Model.Register.OrgContactModel SelLoginName(string name)
        {
            return dal.SelLoginName(name);
        }

        /// <summary>
        /// 添加推荐资源
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public  int InsertResources(Tz888.Model.Info.ResourcesModel resourcesModel)
        {
            return dal.InsertResources(resourcesModel);
           
        }
        /// <summary>
        /// 删除该资源
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //public int DelRes(string ID)
        //{
        //    //以下是不用存储过程的方法
        //    string sql = "insert into RecommendTab (InfoID,ResourceID,OrderNumberID)values(@InfoID,@ResourceID,@OrderNumberID)";
        //    if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql, parameters) > 0)
        //        return 1;
        //    else
        //        return 0;
          
        //}


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MerchantInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }

        /// <summary>
        /// 得到一个采集招商对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ExcavateMerchantInfoMode GetExcavateModel(long InfoID)
        {
            return dal.GetExcavateModel(InfoID);
        }
        /// <summary>
        /// 修改一个采集招商实体的ispublish字段
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool ExcavateTabPublishUpdate(long id)
        {
            bool result = false;
            result=dal.ExcavateTabUpdatePublish(id);
            return result;
        }
        /// <summary>
        /// 修改一个采集招商实体的isdelete字段
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        /// <summary>
        public bool ExcavateTabDeleteUpdate(long id)
        {
            return dal.ExcavateTabUpdateDelete(id);
        }
        /// 得到一个完整投资资源信息的对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MerchantSetModel GetIntegrityModel(long InfoID)
        {
            return dal.GetIntegrityModel(InfoID);
        }

        /// <summary>
        /// 修改招商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.MerchantSetModel model)
        {
            return dal.Update(model);
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


        /// <summary>
        /// 统计信息完整度
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int CountInfoInte(Tz888.Model.Info.MerchantInfoModel model,Tz888.Model.Info.InfoContactModel model1)
        {
            int allScore =82;
            //地方经济指标描述
            if(model.EconomicIndicators.ToString().Length !=0)
            {
                allScore += 5;
            }
            //投资环境
            if (model.InvestmentEnvironment.ToString().Length !=0)
            {
                allScore += 5;
            }
            //项目承办单位
            //职位
            if (model1.Position.ToString().Length != 0)
            {
                allScore += 4;
            }
           
            //联系地址
            if (model1.Address.ToString().Length != 0)
            {
                allScore += 4;
            }
            return allScore;
        
        }


        
    
    
    }
}
