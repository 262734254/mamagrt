using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
    public class ProjectInfoBLL
    {
        private readonly IProjectInfo dal = DataAccess.CreateInfo_ProjectInfo();

        /// <summary>
        /// 添加融资资源信息
        /// </summary>
        public long Insert(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoContactManModel> infoContactManModels,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            return dal.Insert(mainInfoModel, projectInfoModel, infoContactModel, shortInfoModel, infoContactManModels, infoResourceModels);
        }

        /// <summary>
        /// 添加融资资源信息最新
        /// </summary>
        public long InsertNew(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            
            )
        {
            return dal.InsertNew(mainInfoModel, projectInfoModel, infoContactModel, infoResourceModels);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ProjectInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }

        /// <summary>
        /// 得到一个完整投资资源信息的对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ProjectSetModel GetIntegrityModel(long InfoID)
        {
            return dal.GetIntegrityModel(InfoID);
        }

        /// <summary>
        /// 修改招商信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.ProjectSetModel model)
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
        /// 修改一个采集项目实体的isdelete字段
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        /// <summary>
        public bool ExcavateProjectTabDeleteUpdate(long id)
        {
            return dal.excavateProjecttabUpdateDelete(id);
        }

        /// <summary>
        /// 得到一个采集项目对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ExcavateProjectModel GetExcavateProjectModel(long InfoID)
        {
            return dal.GetExcavateProjectModel(InfoID);
        }

        /// <summary>
        /// 修改一个采集项目实体的ispublish字段
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool ExcavateProjectTabPublishUpdate(long id)
        {
            bool result = false;
            result = dal.excavateProjecttabUpdatePublish(id);
            return result;
        }
        /// <summary>
        /// 新属性 债券 发布 第一步
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <returns></returns>
        public long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            return dal.PublishProjectZQ1(mainInfoModel, projectInfoModel, shortInfoModel, infoResourceModels);
        }

        /// <summary>
        /// 新属性 债券 发布(包括上传文件写入表中)
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <returns></returns>
        public long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            return dal.PublishProjectZQ1(mainInfoModel, projectInfoModel, shortInfoModel);
        }



        /// <summary>
        /// 新属性 债券 发布 第二步
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <returns></returns>
        public bool PublishProjectZQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel)
        {
            return dal.PublishProjectZQ2(projectInfoModel);

        }
        /// <summary>
        /// 债券融资修改
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool ProjectInfoZQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            return dal.ProjectInfoZQ_Update(model, infoResourceModels);
        }
        /// <summary>
        /// 新属性 股权 发布 第一步
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <returns></returns>
        public long PublishProjectGQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel)
        {
            return dal.PublishProjectGQ1(mainInfoModel, projectInfoModel, shortInfoModel);
        }


        /// <summary>
        /// 新属性 股权 发布(包括上传文件)
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <returns></returns>
        public long PublishProjectGQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel, 
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels
            )
        {
            return dal.PublishProjectGQ1(mainInfoModel, projectInfoModel, shortInfoModel, infoResourceModels);
        }


        /// <summary>
        /// 新属性 股权 发布 第二步
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <returns></returns>
        public bool PublishProjectGQ2(
            Tz888.Model.Info.ProjectInfoModel projectInfoModel)
        {
            return dal.PublishProjectGQ2(projectInfoModel);

        }
        /// <summary>
        /// 股权融资修改
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool ProjectInfoGQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            return dal.ProjectInfoGQ_Update(model,infoResourceModels);
        }

    }
}
