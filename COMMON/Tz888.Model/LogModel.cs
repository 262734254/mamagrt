using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
        /// <summary>
        /// 实体类LogModel
        /// </summary>
    public class LogModel
    {
        public LogModel()
        { }
        #region Model
        private long _logid;
        private DateTime _datetime;
        private long _threadid;
        private int _settingid;
        private string _message;
        private byte _level;
        private byte _eventtype;
        private string _loginname;
        /// <summary>
        /// 
        /// </summary>
        public long LogID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 事件发生的日期和时间
        /// </summary>
        public DateTime DateTime
        {
            set { _datetime = value; }
            get { return _datetime; }
        }
        /// <summary>
        /// 线程ID
        /// </summary>
        public long ThreadID
        {
            set { _threadid = value; }
            get { return _threadid; }
        }
        /// <summary>
        /// 列表的参数ID
        /// </summary>
        public int SettingID
        {
            set { _settingid = value; }
            get { return _settingid; }
        }
        /// <summary>
        /// 事件详细信息
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// 信息级别。0:普通，1:成功,2:错误,
        /// </summary>
        public byte Level
        {
            set { _level = value; }
            get { return _level; }
        }
        /// <summary>
        /// 事件类型。0:服务启动,1:服务退出,2:生成列表
        /// </summary>
        public byte EventType
        {
            set { _eventtype = value; }
            get { return _eventtype; }
        }
        /// <summary>
        /// 更新者.对于服务:Service。对于手工，则为其登录名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        #endregion Model
    }
}
