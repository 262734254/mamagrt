using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// ������Ϣ�߼������ӿ�
    /// </summary>
    public interface IMarchantInfo
    {
        /// <summary>
        /// ���������Դ��Ϣ
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
        /// �����Դ�б���Ϣ
        /// </summary>
        /// <param name="resourcesModel"></param>
        /// <returns></returns>
       int InsertResources( Tz888.Model.Info.ResourcesModel resourcesModel);
        /// <summary>
        /// ��ϵ����Ϣ��ѯ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       Tz888.Model.Register.OrgContactModel SelLoginName(string name);   


        /// <summary>
        /// �޸�������Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.Info.MerchantSetModel model);

        /// <summary>
        /// �õ�һ������ʵ��(ֻ����MerchantInfoTab����Ϣ)
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.MerchantInfoModel GetModel(long InfoID);

        /// <summary>
        /// �õ�һ�����̲ɼ�����ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ExcavateMerchantInfoMode GetExcavateModel(long InfoID);
        /// <summary>
        /// �޸�һ�����̲ɼ������ispublish�ֶ�
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool ExcavateTabUpdatePublish(long id);
                /// <summary>
        /// �޸�һ�����̲ɼ������isdelete�ֶ�
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        bool ExcavateTabUpdateDelete(long id);
        /// <summary>
        /// �õ�һ�������Ķ���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.MerchantSetModel GetIntegrityModel(long InfoID);


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
    }
}
