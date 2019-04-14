using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class InnerInfo
    {
        private int _infoId;
        private int _receivedId;
        private int _sendId;
        private string _receiveName;
        private string _sendName;
        private string _topic;
        private string _context;
        private int _size;
        private int _isRead;
        private int _isSend;
        private DateTime _infoTime;
        private string _changeBy;
        private DateTime _changeTime;


        public int InfoId
        {
            get { return _infoId; }
            set { _infoId = value; }
        }
        public int ReceiveId
        {
            get { return _receivedId; }
            set { _receivedId = value; }
        }
        public int SendId
        {
            get { return _sendId; }
            set { _sendId = value; }
        }
        public string ReceiveName
        {
            get { return _receiveName; }
            set { _receiveName = value; }
        }
        public string SendName
        {
            get { return _sendName; }
            set { _sendName = value; }
        }
        public string Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }
        public string Context
        {
            get { return _context; }
            set { _context = value; }
        }
        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public int IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }
        public int _IsSend
        {
            get { return _isSend; }
            set { _isSend = value; }
        }
        public DateTime InfoTime
        {
            get { return _infoTime; }
            set { _infoTime = value; }
        }
        public string ChangeBy
        {
            get { return _changeBy; }
            set { _changeBy = value; }
        }
        public DateTime ChangeTime
        {
            get { return _changeTime; }
            set { _changeTime = value; }
        }
    }
}
