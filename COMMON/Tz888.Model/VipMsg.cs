using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类VipMsgTrialLog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class VipMsg
    {
        public VipMsg()
        { }
        #region Model
        private int _id;
        private string _srcmobile;
        private string _loginname;
        private string _spmobile;
        private string _msg;
        private int _gateway;
        private string _svid;
        private string _linkid;
        private string _msgid;
        private string _cpid;
        private int _status;
        private DateTime _senddate;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string srcMobile
        {
            set { _srcmobile = value; }
            get { return _srcmobile; }
        }
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spMobile
        {
            set { _spmobile = value; }
            get { return _spmobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Msg
        {
            set { _msg = value; }
            get { return _msg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int gateway
        {
            set { _gateway = value; }
            get { return _gateway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string svid
        {
            set { _svid = value; }
            get { return _svid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string linkID
        {
            set { _linkid = value; }
            get { return _linkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MsgID
        {
            set { _msgid = value; }
            get { return _msgid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CPID
        {
            set { _cpid = value; }
            get { return _cpid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime sendDate
        {
            set { _senddate = value; }
            get { return _senddate; }
        }
        #endregion Model
    }
}

