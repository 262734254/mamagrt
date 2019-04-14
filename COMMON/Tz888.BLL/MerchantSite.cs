using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
    /// <summary>
    /// 业务逻辑类MerchantSiteTab 的摘要说明。
    /// </summary>
    public class MerchantSite
    {
        private readonly IMerchantSite dal = DataAccess.CreateMerchantSite();
        public MerchantSite()
        { }
        #region  成员方法
        

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Tz888.Model.MerchantSite model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Tz888.Model.MerchantSite model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }
        public int Auditing(int ID, int AuditStatus, string AuditLoginName)
        {
            return dal.Auditing(ID, AuditStatus, AuditLoginName);
        }

        #endregion  成员方法
    }
}

