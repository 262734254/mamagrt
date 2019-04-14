using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// 主体信息数据库访问接口定义
    /// </summary>
    public interface IMainInfo
    {
        /// <summary>
        /// 获取一个对象实体
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.MainInfoModel GetModel(long InfoID);
 
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
        DataSet GetList(string strGetFields, string fldName, int PageSize, int PageIndex, int OrderType, string strWhere);

        /// <summary>
        /// 统计记录条数
        /// </summary>
        /// <param name="strWhere">统计条件</param>
        /// <returns>记录总数</returns>
        int GetCount(string InfoType,string strWhere);

        /// <summary>
        /// 用户删除信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="LoginName"></param>
        /// <param name="ErrorID"></param>
        /// <param name="ErrorMsg"></param>
        /// <returns></returns>
        bool UserDelete(long InfoID, string LoginName, ref int ErrorID, ref string ErrorMsg);

        /// <summary>
        /// 完全删除信息
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        bool HasCompleteDelete(long InfoID, string LoginName);

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        bool HasDelete(long InfoID, string LoginName, bool IsMendaciousInfo, ref int ErrorID, ref string ErrorMsg);
        bool UpdatePromotionStatu(long InfoId, int PromotionStatu);
       /// <summary>
        /// 资源刷新
        /// </summary>
        /// <returns></returns>
        bool UpdateRefresh(long InfoID);

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
        DataTable GetMainInfoViewList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);


        /// <summary>
        /// 设置信息有效期
        /// </summary>
        /// <returns></returns>
        bool SetValidateTerm(long InfoID, int ValidateTerm);
        /// <summary>
        /// 更新购物券状态
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="flg">0为取消购物券 1为设置购物券</param>
        /// <returns></returns>
        int HasCost(long InfoID, int flg);
        /// <summary>
        /// 更新有效期
        /// </summary>
        /// <param name="infoId">信息ID</param>
        /// <param name="startDay">开始有效时间</param>
        /// <param name="terms">有效期限</param>
        /// <returns>是否更新成功</returns>
        bool ChangeValidTerm(long infoId, DateTime startDay, int terms);
        

        /// <summary>
        /// 审核信息 
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <param name="AuditingStatus">审核状态:0未审核， 1审核通过，2审核未通过</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        bool HasAuditing(long InfoID, byte AuditingStatus, bool IsCore, long Hit, string LoginName,
            string AuditingRemark, string HtmlFile, string HtmlFile1, short IsIntegral, float MainPointCount);


        /// <summary>
        /// 信息审核状态记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool InfoAuditNote(Tz888.Model.Info.InfoAuditModel model);

        /// <summary>
        /// 获取资源审核记录
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        Tz888.Model.Info.InfoAuditModel GetInfoAuditNote(long InfoID);


        #region 信息定价 HasFixPrice
        /// <summary>
        /// 信息定价
        /// </summary>
        /// <param name="InfoID">信息ID</param>
        /// <param name="FixPriceID">定价等级ID</param>
        /// <returns>如果操作成功返回true，否则返回false</returns>
        bool HasFixPrice(long InfoID, string FixPriceID, string LoginName);
        #endregion

        bool HasMainEvaluation(long InfoID, decimal MainEvaluation);

        //更新信息的静态化页面地址
        bool HasHtmlFile(long InfoID, string HtmlFile);

                /// <summary>
        /// 会员查看免费信息限制
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="ip">用户所使用的IP</param>
        /// <param name="infoId">信息ID</param>
        /// <param name="viewOptions">--0未验证可通过,1 已经验证通过,2未验证不通过</param>
        /// <param name="validateOptions">--0未超出限制 ,1 会员规定取阅数超出限制,2 IP取阅数超出限制</param>
        /// <returns>是否执行成功</returns>
        bool FreeInfoView(string loginName, string ip, long infoId, ref int viewOptions, ref int validateOptions);

        /// <summary>
        /// 获取信息的资源类型
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        string GetInfoTypeID(long InfoID);

        /// <summary>
        /// 统计资源购买人数
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        int GetInfoBuyersCount(long InfoID);

        /// <summary>
        /// 设置融资信息置顶
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="IsTop"></param>
        /// <returns></returns>
        bool SetProjectInfoTop(long InfoID, int IsTop);


        bool AddHit(long InfoID);


        /// <summary>
        /// 资源举报
        /// </summary>
        /// <param name="InfoID">举报信息</param>
        /// <param name="reportMan">举报人</param>
        /// <param name="Remark">说明</param>
        /// <returns></returns>
        bool InfoReport(long InfoID, string reportMan, string Remark);


         /// <summary>
        /// 举报处理
        /// </summary>
        /// <param name="ID">举报号ID</param>
        /// <param name="chkMan">处理人</param>
        /// <param name="Remark">处理结果</param>
        /// <returns></returns>
         bool InfoReportCheck(int ID, string chkMan, string Remark);

         /// <summary>
         /// 获取此条信息用户 然后发送通知
         /// </summary>
         /// <param name="infoid">该条资源ID</param>
         /// <returns></returns>
        string GetMaininfo(string InfoID);

        /// <summary>
        /// 获取资源积分
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        int GetInfoMainEvaluation(long InfoID, int MainEvaluation);
        
    }
}
