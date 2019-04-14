using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL.Company;
using System.Data;

namespace Tz888.BLL.Company
{
    public class CompanyMadeBLL
    {
        private readonly ICompanyMade dal = DataAccess.CreateCompanyMade();
        /// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(Tz888.Model.Company.CompanyMadeModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tz888.Model.Company.CompanyMadeModel model, int id)
        {
            return dal.Update(model,id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int MadeID)
        {
            return dal.Delete(MadeID);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.Company.CompanyMadeModel GetModel(int MadeID)
        {
            return dal.GetModel(MadeID);
        }
        #region 分页查询
        /// <summary>
        /// 用test数据库
        /// </summary>
        /// <param name="TableViewName">表名</param>
        /// <param name="Key">主键</param>
        /// <param name="SelectStr">查询字段</param>
        /// <param name="Criteria">条件</param>
        /// <param name="Sort">排序字段</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSize">页大小</param>
        /// <param name="TotalCount">总记录</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName,Key,SelectStr,Criteria,Sort,ref CurrentPage,PageSize,ref TotalCount);
        }
        #endregion
    }
}
