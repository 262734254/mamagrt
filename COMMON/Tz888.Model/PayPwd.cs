using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类PayPwdTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class PayPwd
    {
        public PayPwd()
        { }
        #region Model
        private int _qid;
        private string _loginname;
        private byte[] _paypassword;
        private string _question;
        private string _answer;
        private string _email;
        private string _realname;
        private string _cardid;
        /// <summary>
        /// 
        /// </summary>
        public int QID
        {
            set { _qid = value; }
            get { return _qid; }
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
        public byte[] PayPassword
        {
            set { _paypassword = value; }
            get { return _paypassword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Question
        {
            set { _question = value; }
            get { return _question; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Answer
        {
            set { _answer = value; }
            get { return _answer; }
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
        public string realName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        #endregion Model
    }
}

