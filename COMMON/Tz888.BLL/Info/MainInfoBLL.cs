using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
    public class MainInfoBLL
    {
        private readonly IMainInfo dal = DataAccess.CreateInfo_MainInfo();
        Tz888.BLL.SendNotice Notice = new SendNotice();

        #region 获取信息主表数据记录集
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="strGetFields">选择的列</param>
        /// <param name="fldName">排序字段</param>
        /// <param name="PageSize">分页记录条数</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderType">排序类型</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType, string strWhere)
        {
            return dal.GetList(strGetFields, fldName, PageSize, PageIndex, OrderType, strWhere);
        }
        #endregion
        public Tz888.Model.Info.MainInfoModel GetModel(long InfoID)
        {
            return dal.GetModel(InfoID);
        }
        #region 统计记录条数
        /// <summary>
        /// 统计记录条数
        /// </summary>
        /// <param name="strWhere">统计条件</param>
        /// <returns></returns>
        public int GetCount(string InfoType,string strWhere)
        {
            return dal.GetCount(InfoType,strWhere);
        }
        #endregion

        #region 拓富中心需求管理使用
        /// <summary>
        /// 根据需求管理类型获取列表（拓富中心需求管理使用）
        /// </summary>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="loginName"></param>
        /// <param name="RoleName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType,string loginName ,string RoleName,Tz888.BLL.Common.AuditStatus type)
        {
            string strWhere = "";
            switch ((int)type)
            {
                case 0:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE()";
                    break;
                default:
                    break;
            }

            return dal.GetList(strGetFields, fldName, PageSize, PageIndex, OrderType, strWhere);
        }

        /// <summary>
        /// 统计指定用户的某一类型的需求的数目
        /// </summary>
        /// <param name="Type">统计类型</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public int GetCount(Tz888.BLL.Common.AuditStatus Type, string loginName,string RoleName)
        {
            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    strWhere = "LoginName = '" + loginName + "' And InfoOriginRoleName = '" + RoleName + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE()";
                    break;
                default:
                    break;
            }
            return this.GetCount("",strWhere);
        }

        /// <summary>
        /// 获取带数目和需求类型的提示信息
        /// </summary>
        /// <param name="loginName">用户名称</param>
        /// <param name="model">信息模版[***{0}**{1}***],第一个参数为需求数目，第二个参数为需求类型名</param>
        /// <param name="Type">需求类型</param>
        /// <returns></returns>
        public string GetRemind(string loginName, string RoleName ,string model, Tz888.BLL.Common.AuditStatus type)
        {
            string remindInfo = "";
            switch ((int)type)
            {
                case 0:
                    remindInfo = "审核中";
                    break;
                case 1:
                    remindInfo = "通过审核";
                    break;
                case 2:
                    remindInfo = "未通过审核";
                    break;
                case 3:
                    remindInfo = "已过期";
                    break;
                default:
                    break;
            }
            int count = this.GetCount(type, loginName,RoleName);
            string request = string.Format(model, count.ToString(), remindInfo);
            return request;
        }

        /// <summary>
        /// 用户删除信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="LoginName"></param>
        /// <param name="ErrorID"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        public bool UserDelete(long InfoID, string LoginName, ref int ErrorID, ref string ErrorMsg)
        {
            return dal.UserDelete(InfoID, LoginName, ref ErrorID, ref ErrorMsg);
        }

        #endregion

        #region 总站后台需求管理使用
        /// <summary>
        /// 根据需求管理类型获取列表（总站后台需求管理使用）
        /// </summary>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="OrderType"></param>
        /// <param name="loginName"></param>
        /// <param name="RoleName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType, Tz888.BLL.Common.AuditStatus type,string InfoType)
        {
            string strWhere = "";
            switch ((int)type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }

            return dal.GetList(strGetFields, fldName, PageSize, PageIndex, OrderType, strWhere);
        }

        /// <summary>
        /// 统计需求的数目
        /// </summary>
        /// <param name="Type">统计类型</param>
        /// <param name="InfoType">信息类型</param>
        /// <returns></returns>
        public int GetCount(Tz888.BLL.Common.AuditStatus Type,string InfoType)
        {
            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if(!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }
            return this.GetCount(InfoType,strWhere);
        }

        /// <summary>
        /// 统计信息的数目
        /// </summary>
        /// <param name="Type">信息状态</param>
        /// <param name="InfoType">信息类型</param>
        /// <param name="strWhere">查询条件</param>
        /// <returns></returns>
        public int GetInfoCount(Tz888.BLL.Common.AuditStatus Type,Tz888.BLL.Common.InfoType InfoType, string Criteria)
        {
            string strInfoType = "";

            switch ((int)InfoType)
            {
                case 0:
                    strInfoType = "Merchant";
                    break;
                case 1:
                    strInfoType = "Project";
                    break;
                case 2:
                    strInfoType = "Capital";
                    break;
                default:
                    break;
            }

            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if (!string.IsNullOrEmpty(strInfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }
            if (string.IsNullOrEmpty(strWhere))
                strWhere = Criteria;
            else
                strWhere += " AND " + Criteria;
            return this.GetCount(strInfoType, strWhere);
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        public static string GetCriteria(Tz888.BLL.Common.AuditStatus Type, string InfoType)
        {
            string strWhere = "";
            switch ((int)Type)
            {
                case 0:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Auditing).ToString();
                    break;
                case 1:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) > GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 2:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.NoPass).ToString();
                    break;
                case 3:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    else
                        strWhere = "DelStatus <> 1 And DATEADD(Month, ValidateTerm, ValidateStartTime) <= GETDATE() And AuditingStatus = " + ((int)Tz888.BLL.Common.AuditStatus.Pass).ToString();
                    break;
                case 5:
                    if (!string.IsNullOrEmpty(InfoType))
                        strWhere = "InfoTypeID = '" + InfoType + "' And DelStatus <> 1";
                    else
                        strWhere = "DelStatus <> 1";
                    break;
                default:
                    break;
            }
            return strWhere;
        }
        /// <summary>
        /// 获取所有资源相应的查询条件重载
        /// </summary>
        ///2010-06-13
        /// <returns></returns>
        public static string GetCriteria()
        {
            string strWhere = "(InfoTypeID='Project' or InfoTypeID='Capital' or InfoTypeID='Merchant')";

            return strWhere;
        
        
        }

        /// <summary>
        /// 获取带数目和需求类型的提示信息
        /// </summary>
        /// <param name="loginName">用户名称</param>
        /// <param name="model">信息模版[***{0}**{1}***],第一个参数为需求数目，第二个参数为需求类型名</param>
        /// <param name="Type">需求类型</param>
        /// <returns></returns>
        public string GetRemind(string model, Tz888.BLL.Common.AuditStatus type,string InfoType)
        {
            string remindInfo = "";
            switch ((int)type)
            {
                case 0:
                    remindInfo = "待审核";
                    break;
                case 1:
                    remindInfo = "通过审核";
                    break;
                case 2:
                    remindInfo = "未通过审核";
                    break;
                case 3:
                    remindInfo = "已过期";
                    break;
                default:
                    break;
            }
            int count = this.GetCount(type, InfoType);
            string request = string.Format(model, count.ToString(), remindInfo);
            return request;
        }

        #endregion

        #region 从资源主表视图获取数据
        /// <summary>
        /// 从资源主表视图获取数据
        /// </summary>
        /// <param name="SelectCol"></param>
        /// <param name="Criteria"></param>
        /// <param name="OrderBy"></param>
        /// <param name="CurrentPage"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageCount"></param>
        /// <returns></returns>
        public DataTable GetMainInfoViewList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return dal.GetMainInfoViewList(SelectCol, Criteria, OrderBy, ref CurrentPage, PageSize, ref PageCount);
        }
        #endregion

        #region 资源刷新
        /// <summary>
        /// 资源刷新
        /// </summary>
        /// <returns></returns>
        public bool UpdateRefresh(long InfoID)
        {
            return dal.UpdateRefresh(InfoID);
        }
        #endregion

        #region 设置信息有效期
        /// <summary>
        /// 设置信息有效期
        /// </summary>
        /// <returns></returns>
        public bool SetValidateTerm(long InfoID, int ValidateTerm)
        {
            return dal.SetValidateTerm(InfoID, ValidateTerm);
        }

        #endregion

        #region 更新有效期
        /// <summary>
        /// 更新有效期
        /// </summary>
        /// <param name="infoId">信息ID</param>
        /// <param name="startDay">开始有效时间</param>
        /// <param name="terms">有效期限</param>
        /// <returns>是否更新成功</returns>
        public bool ChangeValidTerm(long infoId, DateTime startDay, int terms)
        {
            return dal.ChangeValidTerm(infoId, startDay, terms);
        }
        #endregion
        #region  更新推广状态
        /// <summary>
        /// 更新推广状态
        /// </summary>
        /// <param name="InfoId">该条资源ID</param>
        /// <param name="PromotionStatu">修改的列</param>
        /// <returns></returns>
        public bool UpdatePromotionStatu(long InfoId, int PromotionStatu)
        {
            return dal.UpdatePromotionStatu(InfoId, PromotionStatu);
        }
        #endregion
        #region 审核信息
        /// <summary>
        /// 审核信息 
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <param name="AuditingStatus">审核状态:0未审核， 1审核通过，2审核未通过</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public bool HasAuditing(long InfoID, byte AuditingStatus, bool IsCore, long Hit, string LoginName,
            string AuditingRemark, string HtmlFile, string HtmlFile1, short IsIntegral, float MainPointCount)
        {
            bool check = false;
            check=dal.HasAuditing(InfoID,AuditingStatus,IsCore,Hit,LoginName,
            AuditingRemark, HtmlFile, HtmlFile1, IsIntegral, MainPointCount);
            if (check)//如果审核成功就通知用户
            {
                GetMaininfo(InfoID.ToString()); 
            }
            return check;
        }
        #endregion

        #region 信息审核状态信息记录
        /// <summary>
        /// 信息审核状态记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InfoAuditNote(Tz888.Model.Info.InfoAuditModel model)
        {
            return dal.InfoAuditNote(model);
        }
        #endregion

        #region 获取信息审核状态信息
        /// <summary>
        /// 获取信息审核状态信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public Tz888.Model.Info.InfoAuditModel GetInfoAuditNote(long InfoID)
        {
            return dal.GetInfoAuditNote(InfoID);
        }
        #endregion

        #region 信息定价 HasFixPrice
        /// <summary>
        /// 信息定价
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <param name="FixPriceID">定价等级ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public bool HasFixPrice(long InfoID, string FixPriceID, string LoginName)
        {
            return dal.HasFixPrice(InfoID, FixPriceID, LoginName);
        }
        #endregion

        #region 设置购物券
        /// <summary>
        /// 设置购物券
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="flg"></param>
        /// <returns>返回购物券状态</returns>
        public int HasCost(long InfoID, int flg)
        {
            return dal.HasCost(InfoID, flg);
        }
        #endregion

        #region 完全删除信息 HasCompleteDelete
        /// <summary>
        /// 完全删除信息
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public virtual bool HasCompleteDelete(long InfoID, string LoginName)
        {
            return dal.HasCompleteDelete(InfoID, LoginName);
        }
        #endregion

        #region 删除信息 HasDelete
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        public bool HasDelete(long InfoID, string LoginName, bool IsMendaciousInfo, ref int ErrorID, ref string ErrorMsg)
        {
            //??
            return dal.HasDelete(InfoID, LoginName, IsMendaciousInfo,ref ErrorID, ref ErrorMsg);
        }
        #endregion.

        #region 更新信息评价指数
        public bool HasMainEvaluation(long InfoID, decimal MainEvaluation)
        {
            return dal.HasMainEvaluation(InfoID, MainEvaluation);
        }
        #endregion 更新信息评价指数

        #region 更新信息静态化地址
        public bool HasHtmlFile(long InfoID, string HtmlFile)
        {
            return dal.HasHtmlFile(InfoID, HtmlFile);
        }
        #endregion
		 
        #region 会员查看免费信息限制
		
        /// <summary>
        /// 会员查看免费信息限制
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="ip">用户所使用的IP</param>
        /// <param name="infoId">信息ID</param>
        /// <param name="viewOptions">--0未验证可通过,1 已经验证通过,2未验证不通过</param>
        /// <param name="validateOptions">--0未超出限制 ,1 会员规定取阅数超出限制,2 IP取阅数超出限制</param>
        /// <returns>是否执行成功</returns>
        public bool FreeInfoView(string loginName, string ip, long infoId, ref int viewOptions, ref int validateOptions)
        {
            return dal.FreeInfoView(loginName, ip,infoId, ref viewOptions, ref validateOptions);
        }

	    #endregion

        #region 获取指定信息的信息类型
        public string GetInfoTypeID(long InfoID)
        {
            return dal.GetInfoTypeID(InfoID);
        }
        #endregion

        #region 统计资源购买人数
        public int GetInfoBuyersCount(long InfoID)
        {
            return dal.GetInfoBuyersCount(InfoID);
        }
        #endregion

        #region 设置融资信息置顶
        public bool SetProjectInfoTop(long InfoID, int IsTop)
        {
            return dal.SetProjectInfoTop(InfoID, IsTop);
        }
        #endregion

        #region 增加点击
        public bool AddHit(long InfoID)
        {
            return dal.AddHit(InfoID);
        }
        #endregion


        /// <summary>
        /// 资源举报
        /// </summary>
        /// <param name="InfoID">举报信息</param>
        /// <param name="reportMan">举报人</param>
        /// <param name="Remark">说明</param>
        /// <returns></returns>
        public bool InfoReport(long InfoID, string reportMan, string Remark)
        {
            return dal.InfoReport(InfoID, reportMan, Remark);
        }
        /// <summary>
        /// 举报处理
        /// </summary>
        /// <param name="ID">举报号ID</param>
        /// <param name="chkMan">处理人</param>
        /// <param name="Remark">处理结果</param>
        /// <returns></returns>
        public bool InfoReportCheck(int ID, string chkMan, string Remark)
        {
            return dal.InfoReport(ID, chkMan, Remark);

        }

        /// <summary>
        /// 获取此条信息用户 然后发送通知
        /// </summary>
        /// <param name="infoid">该条资源ID</param>
        /// <returns></returns>
        public int  GetMaininfo(string infoid)
        {
            string loginname = dal.GetMaininfo(infoid);
            string Contents = "您发布的信息已审核成功,请登录您的拓富通查看！";
            return Notice.InfoCheck(loginname, Contents, "资源审核成功", Contents, Contents);
          
        }

        #region 获取资源积分
        public int GetInfoMainEvaluation(long InfoID, int MainEvaluation)
        {
            return dal.GetInfoMainEvaluation(InfoID, MainEvaluation);
        }
        #endregion

    }
}
