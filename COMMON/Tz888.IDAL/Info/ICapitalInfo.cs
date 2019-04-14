using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// Ͷ����Ϣ�߼������ӿ�
    /// </summary>
    public interface ICapitalInfo
    {
        /// <summary>
        /// ���������Դ��Ϣ
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
        /// �õ�һ������ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.CapitalInfoModel GetModel(long InfoID);
        /// <summary>
        /// �õ�һ���ɼ�Ͷ����Դʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.ExcavateCapitalInfoModel GetExcavateCapitalModel(long InfoID);

        bool excavateCapitaltabUpdatePublish(long id);
        bool excavateCapitaltabUpdateDelete(long id);
        /// <summary>
        /// �õ�һ������Ͷ����Դ��Ϣ�Ķ���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.CapitalSetModel GetIntegrityModel(long InfoID);

        /// <summary>
        /// �޸�Ͷ����Դ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.Info.CapitalSetModel model);

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

         #region �ж�ĳһ���û��Ƿ�����ĳһ����Ϣ
        /// <summary>
        /// �ж�ĳһ���û��Ƿ�����ĳһ����Ϣ;
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="InfoID">��Ϣ��InfoID</param>
        /// <returns></returns>
        bool bBuyInfoOfUserName(string UserName, string InfoID);
        #endregion
    }
}
