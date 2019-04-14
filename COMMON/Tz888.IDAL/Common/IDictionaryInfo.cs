using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;

namespace Tz888.IDAL.Common
{
    public interface IDictionaryInfo
    {
        #region  ��Ա����
        /// <summary>
        /// ����һ������
        /// </summary>
        void Add(Tz888.Model.Common.DictionaryInfoModel model);

        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Tz888.Model.Common.DictionaryInfoModel model);   

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int DictionaryInfoId);

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Tz888.Model.Common.DictionaryInfoModel GetModel(string DictionaryCode);
        
        /// <summary>
        /// ��ѯ�б�
        /// </summary>
         DataView GetList();
        #endregion  ��Ա����

         string GetDetail(string Key);

         string GetDetailCarveout(string Key);

         string GetDetailOpportunity(string Key);

         string GetIndustryExhibitionName(string Key);

         string GetProvinceName(string Key);

    }
}
