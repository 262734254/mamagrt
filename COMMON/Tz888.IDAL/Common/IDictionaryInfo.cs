using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;

namespace Tz888.IDAL.Common
{
    public interface IDictionaryInfo
    {
        #region  成员方法
        /// <summary>
        /// 增加一条数据
        /// </summary>
        void Add(Tz888.Model.Common.DictionaryInfoModel model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Tz888.Model.Common.DictionaryInfoModel model);   

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int DictionaryInfoId);

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Tz888.Model.Common.DictionaryInfoModel GetModel(string DictionaryCode);
        
        /// <summary>
        /// 查询列表
        /// </summary>
         DataView GetList();
        #endregion  成员方法

         string GetDetail(string Key);

         string GetDetailCarveout(string Key);

         string GetDetailOpportunity(string Key);

         string GetIndustryExhibitionName(string Key);

         string GetProvinceName(string Key);

    }
}
