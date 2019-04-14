using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;


namespace Tz888.BLL
{
    public class ConsumeRepay
    {
        private readonly IConsumeRepay dal = DataAccess.CreateIConsumeRepay(); 
        public ConsumeRepay()
        { }

        /// <summary>
        /// ����һ������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(Tz888.Model.ConsumeRepay model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Tz888.Model.ConsumeRepay model)
        {
            return dal.Update(model);
        }
                /// <summary>
        /// ��ѯ�û�������ȡ��Ϣ
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataTable GetConsumeMess(int RepayID,string UserName)
        {
            return dal.GetConsumeMess(RepayID,UserName);
        }
                /// <summary>
        /// ��ѯ�û�ʣ����ȡ��
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public DataTable GetConsumeMoney(string UserName)
        {
          return  dal.GetConsumeMoney(UserName);
        }

        public DataTable GetAuditRelealseCount()
        {
            return dal.GetAuditRelealseCount();
        }
                /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllRelealseCount()
        {
            return dal.GetAllRelealseCount();
        }

    }
}
