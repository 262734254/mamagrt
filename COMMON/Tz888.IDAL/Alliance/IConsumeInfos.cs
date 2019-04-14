using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IConsumeInfos
    {    
        /// <summary>
         /// 用户发布资源信息列表
         /// </summary>
         /// <param name="SelectStr"></param>
         /// <param name="Criteria"></param>
         /// <param name="Sort"></param>
         /// <param name="Page"></param>
         /// <param name="CurrentPageRow"></param>
         /// <param name="TotalCount"></param>
         /// <param name="start"></param>
         /// <param name="end"></param>
         /// <returns></returns>
        DataSet dsGetConsumeCountList(
                                string SelectStr,
                                string Criteria,
                                string Sort,
                                long Page,
                                long CurrentPageRow,
                                out long TotalCount,
                                string start,
                                string end
                               );

                /// <summary>
        /// 资源联盟收益总数信息 
        /// </summary>
        /// <returns></returns>
        DataSet GetCountMess();

        DataTable GetConsumeCount(string UserName);

        DataTable GetAuditingStatusCount(string UserName);

        bool Add(Tz888.Model.ConsumeInfos model);
        bool Update(Tz888.Model.ConsumeInfos model);


    }
}
