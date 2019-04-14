using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Common
{
    /// <summary>
    /// �˻�����
    /// </summary>
    public enum UserRole : int
    {
        /// <summary>
        /// ��Ա
        /// </summary>
        Member = 0,
        /// <summary>
        /// ��վ
        /// </summary>
        Agent = 1, 
        /// <summary>
        /// Ա��
        /// </summary>
        Employee = 2, 
        /// <summary>
        /// ר��
        /// </summary>
        Experts = 3, 
    }

    /// <summary>
    /// ��Ϣ���״̬
    /// </summary>
    public enum AuditStatus : int
    {
        /// <summary>
        /// �����
        /// </summary>
        Auditing = 0,
        /// <summary>
        /// ���ͨ��
        /// </summary>
        Pass = 1,
        /// <summary>
        /// ���δͨ��
        /// </summary>
        NoPass = 2,
        /// <summary>
        /// �ѹ���
        /// </summary>
        Overdue = 3,
        /// <summary>
        /// ��ɾ��
        /// </summary>
        IsDel = 4,
        /// <summary>
        /// ȫ��
        /// </summary>
        All = 5,
    }

    /// <summary>
    /// ��Ϣ����
    /// </summary>
    public enum InfoType : int
    {
        /// <summary>
        /// ������Ϣ
        /// </summary>
        Merchant = 0,
        /// <summary>
        /// ������Ϣ
        /// </summary>
        Project = 1,
        /// <summary>
        /// Ͷ����Ϣ
        /// </summary>
        Capital = 2,
    }
}
