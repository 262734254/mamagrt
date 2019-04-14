using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Subject
{
    /// <summary>
    /// 专题访问记录表
    /// </summary>
    public class SubjectRecordModel
    {
        #region Model
        private int _recordid;
        private int? _subid;
        private string _recordname;
        private DateTime? _recordtime;
        private string _recordip;
        private string _recordcity;
        /// <summary>
        /// 主键
        /// </summary>
        public int RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        /// <summary>
        /// 外键
        /// </summary>
        public int? SubID
        {
            set { _subid = value; }
            get { return _subid; }
        }
        /// <summary>
        /// 访问者名称
        /// </summary>
        public string RecordName
        {
            set { _recordname = value; }
            get { return _recordname; }
        }
        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime? RecordTime
        {
            set { _recordtime = value; }
            get { return _recordtime; }
        }
        /// <summary>
        /// 访问IP
        /// </summary>
        public string RecordIP
        {
            set { _recordip = value; }
            get { return _recordip; }
        }
        /// <summary>
        /// 访问城市
        /// </summary>
        public string RecordCity
        {
            set { _recordcity = value; }
            get { return _recordcity; }
        }
        #endregion Model
    }
}
