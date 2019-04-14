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
        /// ���������Դ��Ϣ
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
        /// ���������Դ��Ϣ����
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
        /// �õ�һ������ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ProjectInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }

        /// <summary>
        /// �õ�һ������Ͷ����Դ��Ϣ�Ķ���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ProjectSetModel GetIntegrityModel(long InfoID)
        {
            return dal.GetIntegrityModel(InfoID);
        }

        /// <summary>
        /// �޸�������Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.ProjectSetModel model)
        {
            return dal.Update(model);
        }

        #region-- ��ѯ�б� ---------------
        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        /// <param name="SelectCol">ѡ����</param>		
        /// <param name="Criteria">��ѯ����</param>
        /// <param name="OrderBy">����</param>
        /// <param name="CurrentPage">��ʾ�ĵ�ǰҳ��</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="PageCount">ͨ���ò�ѯ���������صĲ�ѯ��¼��ҳ��</param>
        /// <returns>��ѯ�б�</returns>
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
        /// �޸�һ���ɼ���Ŀʵ���isdelete�ֶ�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        /// <summary>
        public bool ExcavateProjectTabDeleteUpdate(long id)
        {
            return dal.excavateProjecttabUpdateDelete(id);
        }

        /// <summary>
        /// �õ�һ���ɼ���Ŀ����ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ExcavateProjectModel GetExcavateProjectModel(long InfoID)
        {
            return dal.GetExcavateProjectModel(InfoID);
        }

        /// <summary>
        /// �޸�һ���ɼ���Ŀʵ���ispublish�ֶ�
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
        /// ������ ծȯ ���� ��һ��
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
        /// ������ ծȯ ����(�����ϴ��ļ�д�����)
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
        /// ������ ծȯ ���� �ڶ���
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
        /// ծȯ�����޸�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool ProjectInfoZQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            return dal.ProjectInfoZQ_Update(model, infoResourceModels);
        }
        /// <summary>
        /// ������ ��Ȩ ���� ��һ��
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
        /// ������ ��Ȩ ����(�����ϴ��ļ�)
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
        /// ������ ��Ȩ ���� �ڶ���
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
        /// ��Ȩ�����޸�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public bool ProjectInfoGQ_Update(Tz888.Model.Info.ProjectSetModel model, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels)
        {
            return dal.ProjectInfoGQ_Update(model,infoResourceModels);
        }

    }
}
