using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{ 
    public interface ITPMerchant
    {
        /// <summary>
        ///  增加一条资讯信息
        /// </summary>
        bool InsertMerchantNews(Tz888.Model.TPMerchant model);

        /// <summary>
        ///  增加一条活动资讯信息
        /// </summary>
        bool InsertMerchantActiveNews(Tz888.Model.TPMerchant model);

        /// <summary>
        ///  更新一条资讯信息
        /// </summary>
        bool UpdateMerchantNews(Tz888.Model.TPMerchant model);

        /// <summary>
        /// 删除资讯信息
        /// </summary>
       // bool DeleteMerchantNews(long infoID);
        bool DeleteMerchantNews(string idLST);

        /// <summary>
        /// 资讯信息
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
        /// 删除收藏夹信息
        /// </summary> 
        bool DeleteCollectionList(string idLST);

        /// <summary>
        /// 收藏夹信息
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
    /// 专题列表
    /// </summary>
    /// <returns></returns>
        DataTable GetList();
        DataTable GetList(int subjectID);
    }
}
