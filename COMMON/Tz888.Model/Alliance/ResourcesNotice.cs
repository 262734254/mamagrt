using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class ResourcesNotice
    {
        #region Model
        private int _resourcesnoticeID;
        private string _username;
        private string _noticetitle;
        private string _noticedetails;
        private DateTime _createdate;
        private string _respath;
        private string _filesize;
        private int _auditstatus;
        /// <summary>
        /// 
        /// </summary>
        public int ResourcesNoticeID
        {
            set { _resourcesnoticeID = value; }
            get { return _resourcesnoticeID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NoticeTitle
        {
            set { _noticetitle = value; }
            get { return _noticetitle; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NoticeDetails
        {
            set { _noticedetails = value; }
            get { return _noticedetails; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResPath
        {
            set { _respath = value; }
            get { return _respath; }
        }
                /// <summary>
        /// 
        /// </summary>
        public string FileSize
        {
            set { _filesize = value; }
            get { return _filesize; }
        }
                /// <summary>
        /// 
        /// </summary>
        public int AuditStatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }

        #endregion
    }
}
