using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{ 
    public interface ITPMerchant
    {
        /// <summary>
        ///  ����һ����Ѷ��Ϣ
        /// </summary>
        bool InsertMerchantNews(Tz888.Model.TPMerchant model);

        /// <summary>
        ///  ����һ�����Ѷ��Ϣ
        /// </summary>
        bool InsertMerchantActiveNews(Tz888.Model.TPMerchant model);

        /// <summary>
        ///  ����һ����Ѷ��Ϣ
        /// </summary>
        bool UpdateMerchantNews(Tz888.Model.TPMerchant model);

        /// <summary>
        /// ɾ����Ѷ��Ϣ
        /// </summary>
       // bool DeleteMerchantNews(long infoID);
        bool DeleteMerchantNews(string idLST);

        /// <summary>
        /// ��Ѷ��Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        DataSet dsGetNewsList(
                                string SelectStr,
                                 string Criteria,
                                 string Sort,
                                 long Page,
                                 long CurrentPageRow,
                                 ref long TotalCount

                                );
        /// <summary>
        /// ɾ���ղؼ���Ϣ
        /// </summary> 
        bool DeleteCollectionList(string idLST);

        /// <summary>
        /// �ղؼ���Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        DataSet dsGetCollectionList(
                                string SelectStr,
                                 string Criteria,
                                 string Sort,
                                 long Page,
                                 long CurrentPageRow,
                                 ref long TotalCount

                                );

        Tz888.Model.TPMerchant objGetNewsInfoByInfoID(long InfoID);
        bool UpdateHtmlFile(long infoID, string htmlfile);

        DataSet GetHostArea();
        DataSet GetHostCity();
        int  GetCountResources(string ProvinceID);
        int GetCountCityResources(string CityID);
        DataSet GetAllCountList();
        DataSet GetCountList(string ProvinceID);
    /// <summary>
    /// ר���б�
    /// </summary>
    /// <returns></returns>
        DataTable GetList();
        DataTable GetList(int subjectID);
    }
}
