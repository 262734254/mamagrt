using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IOpportunityInfol
    {
        /// <summary>
        /// 发布商机信息
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="opportunity"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,//主信息表
            Tz888.Model.Info.OpportunityInfoModel opportunity,//商机表
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            );//短信表
        /// <summary>
        /// 所属行业
        /// </summary>
        DataView GetIndustry();

        /// <summary>
        /// 商机类别
        /// </summary>
        DataView GetOpportun();
    }
}
