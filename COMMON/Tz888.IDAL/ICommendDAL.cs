using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    /// <summary>
    /// 名称：推荐信息表
    /// 查询：CommendVIW
    /// 用途：为推荐信息处理提供相应的方法和属性
    /// 设计人：wangwei
    /// 创建日期：2009-06-03
    /// </summary>
    public interface ICommendDAL
    {
        bool Send(Tz888.Model.Commend com);

        bool Update(Tz888.Model.Commend com);

        bool GetDetail(string Key);
        
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
        
        bool Insert(Tz888.Model.Commend commend);

        int GetListCount(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
    }
}
