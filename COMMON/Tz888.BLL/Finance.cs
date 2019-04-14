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
        /// ������վͳ������
        /// </summary>
        /// <returns></returns>
        public bool SiteInfoInsert()
        {
            return dal.SiteInfoInsert();
        }
        /// <summary>
        /// ��ѯ��վ����
        /// </summary>
        /// <returns></returns>
        public DataTable SiteInfoList()
        {
            return dal.SiteInfoList();
        }
        /// <summary>
        /// ������վ��������
        /// </summary>
        /// <returns></returns>
        public bool PayInfoInsert()
        {
            return dal.PayInfoInsert();
        }
        /// <summary>
        /// ��ȡ��վ��������
        /// </summary>
        /// <returns></returns>
        public DataTable PayInfoList() 
        {
            return dal.PayInfoList();
        }

    }
}
