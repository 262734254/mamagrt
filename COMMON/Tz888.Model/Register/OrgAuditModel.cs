using System;
using System.Collections.Generic;
using System.Text;

//��֯���
namespace Tz888.Model.Register
{
    /// <summary>
    /// ʵ����OrgAuditTab ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class OrgAuditModel
    {
        public OrgAuditModel()
        { }
        #region Model
        private int _orgaudid;
        private string _orgname;
        private string _loginname;
        private string _auditingremark;
        private string _auditingby;
        private DateTime _auditingdate;
        private int _feedbackstatus;
        private string _feedbacknote;
        private int _orgtype;
        private string _memo;
        /// <summary>
        /// ��֯���ID
        /// </summary>
        public int OrgAudID
        {
            set { _orgaudid = value; }
            get { return _orgaudid; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string OrgName
        {
            set { _orgname = value; }
            get { return _orgname; }
        }
        /// <summary>
        /// LoginName
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// ���˵����δͨ�����ԭ��
        /// </summary>
        public string AuditingRemark
        {
            set { _auditingremark = value; }
            get { return _auditingremark; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public string AuditingBy
        {
            set { _auditingby = value; }
            get { return _auditingby; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime AuditingDate
        {
            set { _auditingdate = value; }
            get { return _auditingdate; }
        }
        /// <summary>
        /// ����״̬��0 ���޸� 1 ��ɾ����
        /// </summary>
        public int FeedbackStatus
        {
            set { _feedbackstatus = value; }
            get { return _feedbackstatus; }
        }
        /// <summary>
        /// ��������(�ʼ�)
        /// </summary>
        public string FeedBackNote
        {
            set { _feedbacknote = value; }
            get { return _feedbacknote; }
        }
        /// <summary>
        /// ��֯����
        /// </summary>
        public int OrgType
        {
            set { _orgtype = value; }
            get { return _orgtype; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model

    }
}

