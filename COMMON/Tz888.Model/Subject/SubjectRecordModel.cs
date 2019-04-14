using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Subject
{
    /// <summary>
    /// ר����ʼ�¼��
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
        /// ����
        /// </summary>
        public int RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public int? SubID
        {
            set { _subid = value; }
            get { return _subid; }
        }
        /// <summary>
        /// ����������
        /// </summary>
        public string RecordName
        {
            set { _recordname = value; }
            get { return _recordname; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? RecordTime
        {
            set { _recordtime = value; }
            get { return _recordtime; }
        }
        /// <summary>
        /// ����IP
        /// </summary>
        public string RecordIP
        {
            set { _recordip = value; }
            get { return _recordip; }
        }
        /// <summary>
        /// ���ʳ���
        /// </summary>
        public string RecordCity
        {
            set { _recordcity = value; }
            get { return _recordcity; }
        }
        #endregion Model
    }
}
