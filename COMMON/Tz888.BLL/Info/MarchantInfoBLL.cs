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
        /// ������Ϣ����
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
        /// ��ϵ����Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tz888.Model.Register.OrgContactModel SelLoginName(string name)
        {
            return dal.SelLoginName(name);
        }

        /// <summary>
        /// ����Ƽ���Դ
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public  int InsertResources(Tz888.Model.Info.ResourcesModel resourcesModel)
        {
            return dal.InsertResources(resourcesModel);
           
        }
        /// <summary>
        /// ɾ������Դ
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //public int DelRes(string ID)
        //{
        //    //�����ǲ��ô洢���̵ķ���
        //    string sql = "insert into RecommendTab (InfoID,ResourceID,OrderNumberID)values(@InfoID,@ResourceID,@OrderNumberID)";
        //    if (Tz888.DBUtility.DbHelperSQL.ExecuteSql(sql, parameters) > 0)
        //        return 1;
        //    else
        //        return 0;
          
        //}


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MerchantInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }

        /// <summary>
        /// �õ�һ���ɼ����̶���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.ExcavateMerchantInfoMode GetExcavateModel(long InfoID)
        {
            return dal.GetExcavateModel(InfoID);
        }
        /// <summary>
        /// �޸�һ���ɼ�����ʵ���ispublish�ֶ�
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
        /// �޸�һ���ɼ�����ʵ���isdelete�ֶ�
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        /// <summary>
        public bool ExcavateTabDeleteUpdate(long id)
        {
            return dal.ExcavateTabUpdateDelete(id);
        }
        /// �õ�һ������Ͷ����Դ��Ϣ�Ķ���ʵ��
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.MerchantSetModel GetIntegrityModel(long InfoID)
        {
            return dal.GetIntegrityModel(InfoID);
        }

        /// <summary>
        /// �޸�������Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.Info.MerchantSetModel model)
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
        /// ͳ����Ϣ������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int CountInfoInte(Tz888.Model.Info.MerchantInfoModel model,Tz888.Model.Info.InfoContactModel model1)
        {
            int allScore =82;
            //�ط�����ָ������
            if(model.EconomicIndicators.ToString().Length !=0)
            {
                allScore += 5;
            }
            //Ͷ�ʻ���
            if (model.InvestmentEnvironment.ToString().Length !=0)
            {
                allScore += 5;
            }
            //��Ŀ�а쵥λ
            //ְλ
            if (model1.Position.ToString().Length != 0)
            {
                allScore += 4;
            }
           
            //��ϵ��ַ
            if (model1.Address.ToString().Length != 0)
            {
                allScore += 4;
            }
            return allScore;
        
        }


        
    
    
    }
}
