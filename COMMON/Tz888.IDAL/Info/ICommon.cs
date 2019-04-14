using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Info;

namespace Tz888.IDAL.Info
{
    /// <summary>
    /// 信息处理公共方法接口
    /// </summary>
    public interface ICommon
    {
         /// <summary>
        /// 获取所有项目合作类型
        /// </summary>
        /// <returns>合作类型列表</returns>
        List<CooperationDemandTypeModel> GetCooperationDemandList(string InfoType);


        /// <summary>
        /// 获取所有招商类型
        /// </summary>
        /// <returns></returns>
        List<Tz888.Model.Info.MerchantAttributeModel> GetMerchantAttributeList();


        /// <summary>
        /// 获取信息类型所对应的代码
        /// </summary>
        /// <param name="InfoTypeID">信息类型</param>
        /// <returns></returns>
        string GetInfoTypeCode(string InfoTypeID);
    }
}
