using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Company
{
   public  interface ICompanyMade
    {
       /// <summary>
       /// 添加数据
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        int Add(Tz888.Model.Company.CompanyMadeModel model);
       /// <summary>
       /// 分页查询
       /// </summary>
       /// <returns></returns>
       DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount);
       /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Tz888.Model.Company.CompanyMadeModel model, int id);
       /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int MadeID);

       /// <summary>
        /// 得到一个对象实体
        /// </summary>
       Tz888.Model.Company.CompanyMadeModel GetModel(int MadeID);
    }
}
