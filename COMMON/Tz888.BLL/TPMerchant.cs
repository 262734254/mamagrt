using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

/// <summary>
/// TPMerchant 的摘要说明
/// </summary>
///
namespace Tz888.BLL
{
    public class TPMerchant
    {
        private readonly ITPMerchant dal = DataAccess.CreateITPMerchant();
        public TPMerchant()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取资讯信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetNewsList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                      )
        {
            long lgTotalCount = 0;

            DataSet ds;

            ds = dal.dsGetNewsList(
                               SelectStr,
                               Criteria,
                               Sort,
                               Page,
                               CurrentPageRow,
                               ref lgTotalCount
                               );

            TotalCount = lgTotalCount;
            return (ds);
        }
 

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idLST">编号列表以“，”隔开但不以“，”结尾</param>
        /// <returns></returns>
        #region------------删除
        public bool DeleteMerchantNews(string idLST)
        {
            if (idLST.EndsWith(","))
            {
                idLST = idLST.Substring(0, idLST.Length - 1);
            }
            return dal.DeleteMerchantNews(idLST);
        }
        #endregion


        /// <summary>
        /// 获取收藏夹信息
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        public DataSet dsGetCollectionList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                      )
        {
            long lgTotalCount = 0;

            DataSet ds;

            ds = dal.dsGetCollectionList(
                               SelectStr,
                               Criteria,
                               Sort,
                               Page,
                               CurrentPageRow,
                               ref lgTotalCount
                               );

            TotalCount = lgTotalCount;
            return (ds);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="idLST">编号列表以“，”隔开但不以“，”结尾</param>
        /// <returns></returns>
        #region------------删除收藏夹信息 
        public bool DeleteCollectionList(string idLST)
        {
            if (idLST.EndsWith(","))
            {
                idLST = idLST.Substring(0, idLST.Length - 1);
            }
            return dal.DeleteCollectionList(idLST);
        }
        #endregion

        /// <summary>
        /// 获取招商热门区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetHostCity()
        {
            DataSet dt = dal.GetHostCity();
            return dt;
        }

        /// <summary>
        /// 获取招商热门产业园区域
        /// </summary>
        /// <returns></returns>
        public DataSet GetHostArea()
        {
            DataSet dt = dal.GetHostArea();
            return dt;
        }

        public int  GetCountResources(string ProvinceID)
        {
            int count = 0;
            count = dal.GetCountResources(ProvinceID);
            return count;
        
        }

        public int GetCountCityResources(string CityID)
        {
            int count = 0;
            count = dal.GetCountCityResources(CityID);
            return count;
        }

        public DataSet GetAllCountList()
        {
            DataSet dt = dal.GetAllCountList();
            return dt;

        }
        public DataSet GetCountList(string ProvinceID)
        {
            DataSet ds = dal.GetCountList(ProvinceID);
            return ds;
        }
/// <summary>
        /// 专题列表
/// </summary>
/// <returns></returns>
        public DataTable GetList()
        {
            DataTable dt = dal.GetList();
            return dt;
        }

        public DataTable GetList(int subjectID)
        {
            DataTable dt = dal.GetList(subjectID);
            return dt;
        }

                /// <summary>
        ///  添加资讯信息 
        /// </summary>
        public bool InsertMerchantNews(Tz888.Model.TPMerchant model)
        {
            return dal.InsertMerchantNews(model);
        }

        /// <summary>
        ///  添加活动资讯信息 
        /// </summary>
        public bool InsertMerchantActiveNews(Tz888.Model.TPMerchant model)
        {
            return dal.InsertMerchantActiveNews(model);
        }
                /// <summary>
        ///  更新资讯信息 
        /// </summary>
        public bool UpdateMerchantNews(Tz888.Model.TPMerchant model)
        {
            return dal.UpdateMerchantNews(model);
        }
 

    }
}