using System;
using System.Collections.Generic;
using System.Text;

//组织审核
namespace Tz888.Model.Register
{
    /// <summary>
    /// 实体类OrgAuditTab 。(属性说明自动提取数据库字段的描述信息)
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
        /// 组织审核ID
        /// </summary>
        public int OrgAudID
        {
            set { _orgaudid = value; }
            get { return _orgaudid; }
        }
        /// <summary>
        /// 机构名称
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
        /// 审核说明（未通过审核原因）
        /// </summary>
        public string AuditingRemark
        {
            set { _auditingremark = value; }
            get { return _auditingremark; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditingBy
        {
            set { _auditingby = value; }
            get { return _auditingby; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AuditingDate
        {
            set { _auditingdate = value; }
            get { return _auditingdate; }
        }
        /// <summary>
        /// 反馈状态（0 可修改 1 将删除）
        /// </summary>
        public int FeedbackStatus
        {
            set { _feedbackstatus = value; }
            get { return _feedbackstatus; }
        }
        /// <summary>
        /// 反馈内容(邮件)
        /// </summary>
        public string FeedBackNote
        {
            set { _feedbacknote = value; }
            get { return _feedbacknote; }
        }
        /// <summary>
        /// 组织类型
        /// </summary>
        public int OrgType
        {
            set { _orgtype = value; }
            get { return _orgtype; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model

    }
}

