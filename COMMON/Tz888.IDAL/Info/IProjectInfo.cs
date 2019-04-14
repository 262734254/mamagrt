using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// ������Ϣ�߼������ӿ�
    /// </summary>
    public interface IProjectInfo
    {
        /// <summary>
        /// �������������Ϣ
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="projectInfoModel"></param>
        /// <param name="infoContactModel"></param>
        /// <returns></returns>
        long InsertNew(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.InfoContactModel infoContactModel, List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);
        /// <summary>
        /// ���������Դ��Ϣ
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
        /// �޸���Ŀ��Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.Info.ProjectSetModel model);

        /// <summary>
        /// �õ�һ������ʵ��(ֻ����MerchantInfoTab����Ϣ)
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ProjectInfoModel GetModel(long InfoID);

        /// <summary>
        /// �õ�һ�������Ķ���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ProjectSetModel GetIntegrityModel(long InfoID);

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
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);


        #region �ɼ�
        
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




        //��Ȩ�ع��������
        long PublishProjectGQ1(
           Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.ProjectInfoModel projectInfoModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel,
           List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);

        //ծȨ�ع��������
        long PublishProjectZQ1(
            Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.ProjectInfoModel projectInfoModel,
            Tz888.Model.Info.ShortInfoModel shortInfoModel,
            List<Tz888.Model.Info.InfoResourceModel> infoResourceModels);
    }
}
 