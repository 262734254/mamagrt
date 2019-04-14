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
        /// Ͷ����Ϣ����
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
        /// �õ�һ������ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.CapitalInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }
        /// <summary>
        /// �õ�һ���ɼ�Ͷ�ʶ���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ExcavateCapitalInfoModel GetExcavateCapitalModel(long ID)
        {
            return dal.GetExcavateCapitalModel( ID);
        }

        /// <summary>
        /// �޸�һ���ɼ�����ʵ���ispublish�ֶ�
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
        /// �޸�һ���ɼ�����ʵ���isdelete�ֶ�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        /// <summary>
        public bool excavateCapitaltabDeleteUpdate(long id)
        {
            return dal.excavateCapitaltabUpdateDelete(id);
        }
        /// <summary>
        /// �õ�һ������Ͷ����Դ��Ϣ�Ķ���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.CapitalSetModel GetIntegrityModel(long InfoID)
        {
            return dal.GetIntegrityModel(InfoID);
        }

        /// <summary>
        /// �޸�Ͷ����Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.CapitalSetModel model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// �ж�ĳһ�û��Ƿ�����ĳһ����Ϣ
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="InfoID">��ϢInfoID</param>
        /// <returns></returns>
        public bool bIsBuyInfoOfUser(string UserName, string InfoID)
        {
            return dal.bBuyInfoOfUserName(UserName,InfoID);
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

    }
}
