using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class LeaveMsg
    {
        private int _commentId;
        private int _infoID;
        private string _loginName;
        private string _commentContent;
        private DateTime _commentTime;
        private int _IsAudit;
        private int _IsDelete;
        private string _auditMan;
        private DateTime _auditTime;
        private string _auditRemark;
        private int _fatherID;
        private int _isResponse;

        public int CommentId
        {
            get { return _commentId; }
            set { _commentId = value; }
        }
        public int InfoID
        {
            get { return _infoID; }
            set { _infoID = value; }
        }

        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        public string CommentContent
        {
            get { return _commentContent; }
            set { _commentContent = value; }
        }
        public DateTime CommentTime
        {
            get { return _commentTime; }
            set { _commentTime = value; }
        }
        public int IsAudit
        {
            get { return _IsAudit; }
            set { _IsAudit = value; }
        }
        public int IsDelete
        {
            get { return _IsDelete; }
            set { _IsDelete = value; }
        }
        public string AuditMan
        {
            get { return _auditMan; }
            set { _auditMan = value; }
        }
        public DateTime AuditTime
        {
            get { return _auditTime; }
            set { _auditTime = value; }
        }
        public string AuditRemark
        {
            get { return _auditRemark; }
            set { _auditRemark = value; }
        }
        public int FatherID
        {
            get { return _fatherID; }
            set { _fatherID = value; }
        }
        public int IsResponse
        {
            get { return _isResponse; }
            set { _isResponse = value; }
        }

    }
}
