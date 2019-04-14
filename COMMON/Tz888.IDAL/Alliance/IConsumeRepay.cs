using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IConsumeRepay
    {
                /// <summary>
        /// ����һ������ 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(Tz888.Model.ConsumeRepay model);

                /// <summary>
        /// ���
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(Tz888.Model.ConsumeRepay model);

                /// <summary>
        /// ��ѯ�û�������ȡ��Ϣ
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        DataTable GetConsumeMess(int RepayID, string UserName);

                /// <summary>
        /// ��ѯ�û�ʣ����ȡ��
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        DataTable GetConsumeMoney(string UserName);

        /// <summary>
        /// ��ȡ���״̬�Ļ�Ա��������
        /// </summary>
        /// <returns></returns>
        DataTable GetAuditRelealseCount();
        
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
       DataTable GetAllRelealseCount();

    }
}
