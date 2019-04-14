using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Common
{
    /// <summary>
    /// 账户类型
    /// </summary>
    public enum UserRole : int
    {
        /// <summary>
        /// 会员
        /// </summary>
        Member = 0,
        /// <summary>
        /// 分站
        /// </summary>
        Agent = 1, 
        /// <summary>
        /// 员工
        /// </summary>
        Employee = 2, 
        /// <summary>
        /// 专家
        /// </summary>
        Experts = 3, 
    }

    /// <summary>
    /// 信息审核状态
    /// </summary>
    public enum AuditStatus : int
    {
        /// <summary>
        /// 审核中
        /// </summary>
        Auditing = 0,
        /// <summary>
        /// 审核通过
        /// </summary>
        Pass = 1,
        /// <summary>
        /// 审核未通过
        /// </summary>
        NoPass = 2,
        /// <summary>
        /// 已过期
        /// </summary>
        Overdue = 3,
        /// <summary>
        /// 已删除
        /// </summary>
        IsDel = 4,
        /// <summary>
        /// 全部
        /// </summary>
        All = 5,
    }

    /// <summary>
    /// 信息类型
    /// </summary>
    public enum InfoType : int
    {
        /// <summary>
        /// 招商信息
        /// </summary>
        Merchant = 0,
        /// <summary>
        /// 融资信息
        /// </summary>
        Project = 1,
        /// <summary>
        /// 投资信息
        /// </summary>
        Capital = 2,
    }
}
