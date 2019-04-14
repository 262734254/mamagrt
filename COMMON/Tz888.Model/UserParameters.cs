using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类UserParametersTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class UserParameters
    {
        public UserParameters()
        { }
        #region Model
        private int _parid;
        private string _loginname;
        private int _mobilecount;
        private int _promotioncount;
        private string _noticeemail;
        private string _noticemobile;
        private string _infochecknotice;
        private string _subscribenotice;
        private string _rebacknotice;
        private string _infoexpirednotice;
        private string _vipexpirednotice;
        private string _friendaddnotice;
        private string _infocommentnotice;
        private string _infomatchingnotice;
        private string _paynotice;
        private string _strikenotice;
        /// <summary>
        /// 
        /// </summary>
        public int parID
        {
            set { _parid = value; }
            get { return _parid; }
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
        public int mobileCount
        {
            set { _mobilecount = value; }
            get { return _mobilecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PromotionCount
        {
            set { _promotioncount = value; }
            get { return _promotioncount; }
        }
        public string  RebackNotice
        {
            set { _rebacknotice = value; }
            get { return _rebacknotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NoticeEmail
        {
            set { _noticeemail = value; }
            get { return _noticeemail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NoticeMobile
        {
            set { _noticemobile = value; }
            get { return _noticemobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoCheckNotice
        {
            set { _infochecknotice = value; }
            get { return _infochecknotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubscribeNotice
        {
            set { _subscribenotice = value; }
            get { return _subscribenotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoExpiredNotice
        {
            set { _infoexpirednotice = value; }
            get { return _infoexpirednotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VipExpiredNotice
        {
            set { _vipexpirednotice = value; }
            get { return _vipexpirednotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FriendAddNotice
        {
            set { _friendaddnotice = value; }
            get { return _friendaddnotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoCommentNotice
        {
            set { _infocommentnotice = value; }
            get { return _infocommentnotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoMatchingNotice
        {
            set { _infomatchingnotice = value; }
            get { return _infomatchingnotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayNotice
        {
            set { _paynotice = value; }
            get { return _paynotice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StrikeNotice
        {
            set { _strikenotice = value; }
            get { return _strikenotice; }
        }
        #endregion Model
    }
}

