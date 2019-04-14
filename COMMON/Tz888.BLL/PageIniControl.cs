using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class PageIniControl
    {
        private readonly IPageIniControl dal = DataAccess.CreateIPageIniControl();
        public PageIniControl()
        {

        }
        #region 大行业	数据绑定
        /// <summary>
        /// 大行业	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataTable IndustryBDataBind()
        {
            return dal.IndustryBDataBind();
        }

        public DataView IndustryBDataBind2()
        {

            return new DataView();
        }
        #endregion

        #region 创业行业类型	数据绑定
        /// <summary>
        /// 创业行业	数据绑定
        /// </summary>
        /// 			/// <returns></returns>
        public DataView IndustryCarveOutDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 商机行业类型	数据绑定
        /// <summary>
        /// 创商机行业	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView IndustryOpportunityDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 成功案例类型	数据绑定
        /// <summary>
        /// 成功案例类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView CaseDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 公告类型	数据绑定
        /// <summary>
        /// 成功案例类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public static DataView BulletinDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 广告位置	数据绑定
        /// <summary>
        /// 广告类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public static DataView ADLocationDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 行业精英类型	数据绑定
        /// <summary>
        /// 行业精英类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView EliteDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 展会行业类型	数据绑定
        /// <summary>
        /// 展会行业类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView ExhibitionDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 投资金额	数据绑定
        /// <summary>
        /// 投资金额	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataTable CaptitalDataBind()
        {
            return dal.CaptitalDataBind();
        }
        #endregion

        #region 投资金额	数据绑定
        /// <summary>
        /// 投资金额	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView MemberQuantityDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 创业资金类型	数据绑定
        /// <summary>
        /// 资本类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView CapitalCarveOutDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 发布时效	数据绑定
        /// <summary>
        /// 发布时效	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView ValidateDateDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 发布时效	数据绑定
        /// <summary>
        /// 发布时效	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView OpportunityTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 信息评定	数据绑定
        /// <summary>
        /// 信息评定	数据绑定 
        /// </summary>
        /// <returns></returns>
        public DataView FixPriceDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 信息评分	数据绑定
        /// <summary>
        /// 信息评分	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView GradeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 招商类型	数据绑定
        /// <summary>
        /// 招商类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataTable MerchantTypeDataBind()
        {
            return dal.MerchantTypeDataBind();
        }
        #endregion

        #region 资本类型	数据绑定
        /// <summary>
        /// 资本类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataTable CaptitalTypeDataBind()
        {
            return dal.CaptitalTypeDataBind();
        }
        #endregion

        #region 新闻类型	数据绑定
        /// <summary>
        /// 新闻类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView NewsTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 大区域类型	数据绑定
        /// <summary>
        /// 大区域类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView AreaDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 新闻行业类型	数据绑定
        /// <summary>
        /// 信息评分	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView NewsIndustyDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 国家  数据绑定
        /// <summary>
        /// 国家  数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView CountryDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 省份 数据绑定

        /// <summary>
        /// 省份 数据绑定
        /// </summary>
        /// <returns></returns>
        public DataTable ProvinceDataBind(string CountryCode)
        {
            return dal.ProvinceDataBind(CountryCode);
        }
        #endregion

        #region-- 资讯类型 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>		
        /// <returns>列表</returns>
        public DataTable GetList()
        {
            return dal.GetList();
        }
        #endregion

        #region-- 创业行业 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>		
        /// <returns>列表</returns>
        public DataTable GetListIndustryCarveout()
        {
            return dal.GetListIndustryCarveout();
        }
        #endregion

        #region-- 商机 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>		
        /// <returns>列表</returns>
        public DataTable GetListIndustryOppor()
        {
            return dal.GetListIndustryOppor();
        }
        #endregion

        #region 地级市 数据绑定
        /// <summary>
        /// 地级市 数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView CapitalCityDataBind(string ProvinceID)
        {
            return new DataView();
        }
        #endregion

        #region 县级市  数据绑定
        /// <summary>
        /// 县级市  数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView CountyDataBind(string CapitalCityID)
        {
            return new DataView();
        }
        #endregion

        #region 县级市  数据绑定
        /// <summary>
        /// 县级市  数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView AreaByCapitalCityDataBind(string CapitalCityID)
        {
            return new DataView();
        }
        #endregion

        #region 证件类型	数据绑定
        /// <summary>
        /// 证件类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView CertificateDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 部门类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView DeptInfoDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 职务类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView WorkTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 学历类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView DegreeInfoDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 角色组类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView RoleGroupDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 菜单权限操作类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView MenuTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 系统权限操作类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView SystemTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 信息权限操作类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoOPPDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 信息类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 角色类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView WorkTypeActiveDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 信息显示栏目控件	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoControlDataBind(string InfoTypeID, string WebSiteLoginName)
        {
            return new DataView();
        }
        #endregion

        #region 信息显示栏目控件	数据绑定
        /// <summary>
        ///	  根据信息类型来选择栏目控件
        /// </summary>
        /// <returns></returns>
        public DataView InfoControlDataBindByInfoType(string InfoTypeID)
        {
            return new DataView();
        }
        #endregion

        #region 信息显示分站所有控件	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView InfoControlDataBind(string WebSiteLoginName)
        {
            return new DataView();
        }
        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView ExpertTypeDataBind()
        {
            return new DataView();
        }

        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView ExpertTypeDataBind(string strExpertTypeID)
        {
            return new DataView();
        }

        #endregion

        #region 读取名片类型表
        public DataView GetCardTypeList()
        {
            return new DataView();
        }
        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView ExpertInfoDataBind(string strLoginName)
        {
            return new DataView();
        }

        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView ExpertNameDataBind(string loginid)
        {
            return new DataView();
        }

        #endregion

        #region 会员职位类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView PositionDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 查询专家相关信息
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
        public DataView GetExpertMessage(string ExpertLoginName)
        {
            return new DataView();
        }
        #endregion

        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView AttractCapitalTypeDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView FeedbackSDataBind()
        {
            return new DataView();
        }
        #endregion

        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataView FeedbackBDataBind()
        {
            return new DataView();
        }
        #endregion


        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        public DataTable IndustryMDataBind(string IndustryBID)
        {
            return dal.IndustryMDataBind(IndustryBID);
        }
        #endregion


        #region 对DATAVIEW操作，清除空格
        public DataTable CleanSpace(DataTable DealDV, string DealCol)
        {
            return dal.CleanSpace(DealDV, DealCol);
        }
        #endregion

        #region 初始化广告等下拉框
        public static DataView ADTypeDataBind()//广告类型
        {
            return new DataView();
        }
        /// <summary>
        /// 广告位绑定
        /// </summary>
        /// <param name="SiteType">广告位类型.0:总站 1：分站 空字符串：全部</param>
        /// <returns>返回DV</returns>
        public static DataView ADLocationDataBind(string SiteType)//广告位
        {
            return new DataView();

        }

        /// <summary>
        /// 站 点绑定
        /// </summary>
        /// <param name="roleType">角色类型 0:代理商 2:内部员工</param>
        /// <param name="loginName">登录名,对于内部员工，此参数不被使用</param>
        /// <returns></returns>

        public static DataView ADSiteDataBind(string roleType, string loginName)//站点
        {
            return new DataView();
        }


        #endregion

        #region 关键字等参数绑定
        public DataView DefaultViewDataBind(Tz888.Model.Info.MainInfoModel model)
        {
            Tz888.BLL.Info.SetDefaultValue bll = new Tz888.BLL.Info.SetDefaultValue();
            DataView dv = bll.GetValue(model);
            if (dv != null && dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    if (dv[i]["FromColumn"].ToString().Trim() != "")
                    {
                        dv[i]["FromColumnName"] = dv[i]["FromColumnName"].ToString().Trim() + "[字段]";
                    }
                }
            }
            return dv;
        }
        #endregion

        #region 融资类型 数据绑定
        public DataTable SETfinancingTargetTabBind()
        {
            Tz888.SQLServerDAL.PageIniControlDAL Dal = new Tz888.SQLServerDAL.PageIniControlDAL();
            return Dal.SETfinancingTargetTabBind();
        }
        #endregion
    }

}


