using System;
using System.Collections.Generic;
using System.Text;


namespace Tz888.Model
{
    public class LoginInfo//:ErrorBase
    {
        public LoginInfo()
        { }
        #region Model
        private int _loginid;
        private string _loginname;
        private byte[] _password;
        private string _passwordquestion;
        private string _passwordanswer;
        private string _rolename;
        private string _nickname;
        private string _tel;
        private string _email;
        private string _requirinfo;
        private bool _ischeckup;
        private string _managetypeid;
        private string _membergradeid;
        private bool _enable;
        private DateTime _registertime;
        private string _realname;
        private bool _issinglelevel;
        private int _createplanmemberstatus;
        private int _isalliance;
        private bool _isemailnotify;
        private string _membergradeparamid;
        private int _setmealid;
        private int _isrefresh;
        private DateTime _vipinvaliddate;
        private int _trystatus;
        private string _headportrait;
        /// <summary>
        /// 
        /// </summary>
        public int LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
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
        public byte[] Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PasswordQuestion
        {
            set { _passwordquestion = value; }
            get { return _passwordquestion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PasswordAnswer
        {
            set { _passwordanswer = value; }
            get { return _passwordanswer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RequirInfo
        {
            set { _requirinfo = value; }
            get { return _requirinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCheckUp
        {
            set { _ischeckup = value; }
            get { return _ischeckup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManageTypeID
        {
            set { _managetypeid = value; }
            get { return _managetypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MemberGradeID
        {
            set { _membergradeid = value; }
            get { return _membergradeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RegisterTime
        {
            set { _registertime = value; }
            get { return _registertime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSingleLevel
        {
            set { _issinglelevel = value; }
            get { return _issinglelevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CreatePlanMemberStatus
        {
            set { _createplanmemberstatus = value; }
            get { return _createplanmemberstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsAlliance
        {
            set { _isalliance = value; }
            get { return _isalliance; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsEmailNotify
        {
            set { _isemailnotify = value; }
            get { return _isemailnotify; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MemberGradeParamID
        {
            set { _membergradeparamid = value; }
            get { return _membergradeparamid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SetMealID
        {
            set { _setmealid = value; }
            get { return _setmealid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsRefresh
        {
            set { _isrefresh = value; }
            get { return _isrefresh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime VipInvalidDate
        {
            set { _vipinvaliddate = value; }
            get { return _vipinvaliddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TryStatus
        {
            set { _trystatus = value; }
            get { return _trystatus; }
        }
        /// <summary>
        /// Í·Ïñ
        /// </summary>
        public string HeadPortrait
        {
            set { _headportrait = value; }
            get { return _headportrait; }
        }
        #endregion Model

    }
}

