using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
namespace Tz888.BLL.Common
{
   public class DictionaryInfoBLL
    {
       private readonly IDictionaryInfo dal = DataAccess.CreateDictionaryInfo();

        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Tz888.Model.Common.DictionaryInfoModel model)
        {
             dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Tz888.Model.Common.DictionaryInfoModel model)
        {
             dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int DictionaryInfoId)
        {
            return dal.Delete(DictionaryInfoId);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       public Tz888.Model.Common.DictionaryInfoModel GetModel(string DictionaryCode)
        {
            return dal.GetModel(DictionaryCode);
       }

        /// <summary>
        /// ��ѯ�б�
        /// </summary>
        public DataView GetList()
        {
            return dal.GetList();
        }
        #endregion  ��Ա����



       public string GetDetail(string Key)
       {
           return dal.GetDetail(Key);
       }

       public string GetDetailCarveout(string Key)
       {
           return dal.GetDetailCarveout(Key);
       }

       public string GetDetailOpportunity(string Key)
       {
           return dal.GetDetailOpportunity(Key);
       }

       public string GetIndustryExhibitionName(string Key)
       {
           return dal.GetIndustryExhibitionName(Key);
       }

       public string GetProvinceName(string Key)
       {
           return dal.GetProvinceName(Key);
       }
       public Tz888.Model.Common.DictionaryInfoModel objGetDicByCode(string DictionaryCode)
       {
           return dal.GetModel(DictionaryCode.Trim());
       }
    }
}
