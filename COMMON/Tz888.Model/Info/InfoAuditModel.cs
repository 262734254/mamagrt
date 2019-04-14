using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 信息审核状态记录实体
    /// </summary>
    public class InfoAuditModel
    {
        public InfoAuditModel()
        { }
        #region Model
        private long _infoid;
        private string _title;
        private string _loginname;
        private string _infotypeid;
        private DateTime _postdate;
        private int _auditstatus;
        private string _auditingremark;
        private string _auditingby;
        private DateTime _auditingdate;
        private int _feedbackstatus;
        private string _feedbacknote;
        private string _memo;
        /// <summary>
        /// 
        /// </summary>
        public long InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoTypeID
        {
            set { _infotypeid = value; }
            get { return _infotypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PostDate
        {
            set { _postdate = value; }
            get { return _postdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AuditStatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditingRemark
        {
            set { _auditingremark = value; }
            get { return _auditingremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditingBy
        {
            set { _auditingby = value; }
            get { return _auditingby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AuditingDate
        {
            set { _auditingdate = value; }
            get { return _auditingdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FeedbackStatus
        {
            set { _feedbackstatus = value; }
            get { return _feedbackstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FeedBackNote
        {
            set { _feedbacknote = value; }
            get { return _feedbacknote; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        #endregion Model
    }
}

