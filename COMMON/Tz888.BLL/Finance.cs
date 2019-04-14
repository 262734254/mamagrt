using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class Finance
    {
        private readonly IFinance dal = DataAccess.CreateFinance();
        /// <summary>
        /// 生成网站统计数据
        /// </summary>
        /// <returns></returns>
        public bool SiteInfoInsert()
        {
            return dal.SiteInfoInsert();
        }
        /// <summary>
        /// 查询网站数据
        /// </summary>
        /// <returns></returns>
        public DataTable SiteInfoList()
        {
            return dal.SiteInfoList();
        }
        /// <summary>
        /// 生成网站交易数据
        /// </summary>
        /// <returns></returns>
        public bool PayInfoInsert()
        {
            return dal.PayInfoInsert();
        }
        /// <summary>
        /// 获取网站交易数据
        /// </summary>
        /// <returns></returns>
        public DataTable PayInfoList() 
        {
            return dal.PayInfoList();
        }

    }
}
