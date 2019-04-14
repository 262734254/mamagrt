using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
        /// <summary>
        /// ʵ����LogModel
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
        /// �¼����������ں�ʱ��
        /// </summary>
        public DateTime DateTime
        {
            set { _datetime = value; }
            get { return _datetime; }
        }
        /// <summary>
        /// �߳�ID
        /// </summary>
        public long ThreadID
        {
            set { _threadid = value; }
            get { return _threadid; }
        }
        /// <summary>
        /// �б�Ĳ���ID
        /// </summary>
        public int SettingID
        {
            set { _settingid = value; }
            get { return _settingid; }
        }
        /// <summary>
        /// �¼���ϸ��Ϣ
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }
        /// <summary>
        /// ��Ϣ����0:��ͨ��1:�ɹ�,2:����,
        /// </summary>
        public byte Level
        {
            set { _level = value; }
            get { return _level; }
        }
        /// <summary>
        /// �¼����͡�0:��������,1:�����˳�,2:�����б�
        /// </summary>
        public byte EventType
        {
            set { _eventtype = value; }
            get { return _eventtype; }
        }
        /// <summary>
        /// ������.���ڷ���:Service�������ֹ�����Ϊ���¼��
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        #endregion Model
    }
}
