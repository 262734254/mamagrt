using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL
{
    public interface IPageIniControl
    { 
        #region 大行业	数据绑定
        /// <summary>
        /// 大行业	数据绑定
        /// </summary>
        /// <returns></returns>
        DataTable IndustryBDataBind();
        DataView IndustryBDataBind2();
        #endregion

        #region 创业行业类型	数据绑定
        /// <summary>
        /// 创业行业	数据绑定
        /// </summary>
        /// 			/// <returns></returns>
        DataView IndustryCarveOutDataBind();
        #endregion

        #region 商机行业类型	数据绑定
        /// <summary>
        /// 创商机行业	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView IndustryOpportunityDataBind();

        #endregion

        #region 成功案例类型	数据绑定
        /// <summary>
        /// 成功案例类型	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView CaseDataBind();

        #endregion

        #region 公告类型	数据绑定
        /// <summary>
        /// 成功案例类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView BulletinDataBind();

        #endregion

        #region 广告位置	数据绑定
        /// <summary>
        /// 广告类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView ADLocationDataBind();

        #endregion

        #region 行业精英类型	数据绑定
        /// <summary>
        /// 行业精英类型	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView EliteDataBind();
        #endregion

        #region 展会行业类型	数据绑定
        /// <summary>
        /// 展会行业类型	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView ExhibitionDataBind();

        #endregion

        #region 投资金额	数据绑定
        /// <summary>
        /// 投资金额	数据绑定
        /// </summary>
        /// <returns></returns>
        DataTable CaptitalDataBind();
        #endregion

        #region 投资金额	数据绑定
        /// <summary>
        /// 投资金额	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView MemberQuantityDataBind();
        #endregion

        #region 创业资金类型	数据绑定
        /// <summary>
        /// 资本类型	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView CapitalCarveOutDataBind();
        #endregion

        #region 发布时效	数据绑定
        /// <summary>
        /// 发布时效	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView ValidateDateDataBind();
        #endregion

        #region 发布时效	数据绑定
        /// <summary>
        /// 发布时效	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView OpportunityTypeDataBind();
        #endregion

        #region 信息评定	数据绑定
        /// <summary>
        /// 信息评定	数据绑定 
        /// </summary>
        /// <returns></returns>
        DataView FixPriceDataBind();
        #endregion

        #region 信息评分	数据绑定
        /// <summary>
        /// 信息评分	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView GradeDataBind();
        #endregion

        #region 招商类型	数据绑定
        /// <summary>
        /// 招商类型	数据绑定
        /// </summary>
        /// <returns></returns>
        DataTable MerchantTypeDataBind();
        #endregion

        #region 资本类型	数据绑定
        /// <summary>
        /// 资本类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataTable CaptitalTypeDataBind();
        #endregion

        #region 新闻类型	数据绑定
        /// <summary>
        /// 新闻类型	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView NewsTypeDataBind();
        #endregion

        #region 大区域类型	数据绑定
        /// <summary>
        /// 大区域类型	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView AreaDataBind();
        #endregion

        #region 新闻行业类型	数据绑定
        /// <summary>
        /// 信息评分	数据绑定
        /// </summary>
        /// <returns></returns>
        DataView NewsIndustyDataBind();
        #endregion

        #region 国家  数据绑定
        /// <summary>
        /// 国家  数据绑定
        /// </summary>
        /// <returns></returns>
        DataView CountryDataBind();
        #endregion

        #region 省份 数据绑定
        /// <summary>
        /// 省份 数据绑定
        /// </summary>
        /// <returns></returns>
        DataTable ProvinceDataBind(string CountryCode);
        
        #endregion

        #region-- 创业行业 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>		
        /// <returns>列表</returns>
         DataTable GetListIndustryCarveout();
        #endregion
         #region-- 商机 ---------------
         /// <summary>
         /// 查询列表
         /// </summary>		
         /// <returns>列表</returns>
         DataTable GetListIndustryOppor();
         #endregion

        #region-- 资讯类型 ---------------
        /// <summary>
        /// 查询列表
        /// </summary>		
        /// <returns>列表</returns>
         DataTable GetList();
        #endregion
        #region 地级市 数据绑定
        /// <summary>
        /// 地级市 数据绑定
        /// </summary>
        /// <returns></returns>
         DataView CapitalCityDataBind(string ProvinceID);
        #endregion

        #region 县级市  数据绑定
        /// <summary>
        /// 县级市  数据绑定
        /// </summary>
        /// <returns></returns>
         DataView CountyDataBind(string CapitalCityID);
        #endregion

        #region 县级市  数据绑定
        /// <summary>
        /// 县级市  数据绑定
        /// </summary>
        /// <returns></returns>
         DataView AreaByCapitalCityDataBind(string CapitalCityID);
        #endregion

        #region 证件类型	数据绑定
        /// <summary>
        /// 证件类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView CertificateDataBind();
        #endregion

        #region 部门类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView DeptInfoDataBind();
        #endregion

        #region 职务类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView WorkTypeDataBind();
        #endregion

        #region 学历类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView DegreeInfoDataBind();
        #endregion

        #region 角色组类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView RoleGroupDataBind();
        #endregion

        #region 菜单权限操作类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView MenuTypeDataBind();
        #endregion

        #region 系统权限操作类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView SystemTypeDataBind();
        #endregion

        #region 信息权限操作类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoOPPDataBind();
        #endregion

        #region 信息类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoTypeDataBind();
        #endregion

        #region 角色类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView WorkTypeActiveDataBind();
        #endregion

        #region 信息显示栏目控件	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoControlDataBind(string InfoTypeID, string WebSiteLoginName);
        #endregion

        #region 信息显示栏目控件	数据绑定
        /// <summary>
        ///	  根据信息类型来选择栏目控件
        /// </summary>
        /// <returns></returns>
         DataView InfoControlDataBindByInfoType(string InfoTypeID);
        #endregion

        #region 信息显示分站所有控件	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView InfoControlDataBind(string WebSiteLoginName);
        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView ExpertTypeDataBind();

        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView ExpertTypeDataBind(string strExpertTypeID);

        #endregion

        #region 读取名片类型表
         DataView GetCardTypeList();
        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView ExpertInfoDataBind(string strLoginName);

        #endregion

        #region 专家类型	数据绑定
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView ExpertNameDataBind(string loginid);

        #endregion

        #region 会员职位类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataView PositionDataBind();

        #endregion

        #region 查询专家相关信息
        /// <summary>
        /// 专家类型	数据绑定
        /// </summary>
        /// <returns></returns>
         DataView GetExpertMessage(string ExpertLoginName);
        #endregion

        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataView AttractCapitalTypeDataBind();
        #endregion

        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
         DataView FeedbackSDataBind();
        #endregion

        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataView FeedbackBDataBind();
        #endregion
        

        #region 引资类型	数据绑定
        /// <summary>
        /// </summary>
        /// <returns></returns>
        DataTable IndustryMDataBind(string IndustryBID);
        #endregion


        #region 对DATAVIEW操作，清除空格
        DataTable CleanSpace(DataTable DealDV, string DealCol);
        #endregion

        #region 初始化广告等下拉框
        DataView ADTypeDataBind();//广告类型
        /// <summary>
        /// 广告位绑定
        /// </summary>
        /// <param name="SiteType">广告位类型.0:总站 1：分站 空字符串：全部</param>
        /// <returns>返回DV</returns>
        DataView ADLocationDataBind(string SiteType);//广告位

        /// <summary>
        /// 站 点绑定
        /// </summary>
        /// <param name="roleType">角色类型 0:代理商 2:内部员工</param>
        /// <param name="loginName">登录名,对于内部员工，此参数不被使用</param>
        /// <returns></returns>

         DataView ADSiteDataBind(string roleType, string loginName);//站点
        

        #endregion

        #region 关键字等参数绑定
         DataView DefaultViewDataBind();
        #endregion


    }

}

