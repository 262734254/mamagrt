using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;
namespace Tz888.BLL
{
    /// <summary>
    /// ҵ���߼���MerchantSiteTab ��ժҪ˵����
    /// </summary>
    public class MerchantSite
    {
        private readonly IMerchantSite dal = DataAccess.CreateMerchantSite();
        public MerchantSite()
        { }
        #region  ��Ա����
        

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Tz888.Model.MerchantSite model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Tz888.Model.MerchantSite model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int ID)
        {
            return dal.Delete(ID);
        }
        public int Auditing(int ID, int AuditStatus, string AuditLoginName)
        {
            return dal.Auditing(ID, AuditStatus, AuditLoginName);
        }

        #endregion  ��Ա����
    }
}

