using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IConsumeRepay
    {
                /// <summary>
        /// 增加一条数据 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(Tz888.Model.ConsumeRepay model);

                /// <summary>
        /// 审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.ConsumeRepay model);

                /// <summary>
        /// 查询用户申请提取信息
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        DataTable GetConsumeMess(int RepayID, string UserName);

                /// <summary>
        /// 查询用户剩余提取额
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        DataTable GetConsumeMoney(string UserName);

        /// <summary>
        /// 获取审核状态的会员发放总数
        /// </summary>
        /// <returns></returns>
        DataTable GetAuditRelealseCount();
        
        /// <summary>
        /// 获取发放总数
        /// </summary>
        /// <returns></returns>
       DataTable GetAllRelealseCount();

    }
}
