using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Tz888.IDAL.Company;
using Tz888.Model.Company;
using Tz888.DBUtility;
namespace Tz888.SQLServerDAL.Company
{
    public class LmOrderTabDal : ILMOrderTab
    {
        #region 添加联盟分红信息
        /// <summary>
        /// 添加联盟分红信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int AddLMOrder(LmOrderTab order)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
