using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class SubscribeSetTabLog
    {
        private int _logId;

        public int LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }
        private string _loginName;

        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        private int _sid;

        public int Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
        private DateTime _logTimes;

        public DateTime LogTimes
        {
            get { return _logTimes; }
            set { _logTimes = value; }
        }
        private string _subType;

        public string SubType
        {
            get { return _subType; }
            set { _subType = value; }
        }
    }
}
