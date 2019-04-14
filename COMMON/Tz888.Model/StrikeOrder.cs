using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类StrikeOrderTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class StrikeOrder
    {
        public StrikeOrder()
        { }
        #region Model
      
        
        #region Model
        private string _strikeloginname;
        private string _operationman;
        private int _orderno;
        private string _paytypecode;
        private string _loginname;
        private string _nickname;
        private string _email;
        private string _tel;
        private string _mobileno;
        private string _realname;
        private double _totalcount;
        private double _discount;
        private string _buytype;
        private DateTime _orderdate;
        private DateTime _paydate;
        private int _paystatus;
        private string _otherinfo;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        public string StrikeLoginName
        {
            set { _strikeloginname = value; }
            get { return _strikeloginname; }
        }
        public string OperationMan
        {
            set { _operationman = value; }
            get { return _operationman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayTypeCode
        {
            set { _paytypecode = value; }
            get { return _paytypecode; }
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
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
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
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MobileNo
        {
            set { _mobileno = value; }
            get { return _mobileno; }
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
        public double TotalCount
        {
            set { _totalcount = value; }
            get { return _totalcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double DisCount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyType
        {
            set { _buytype = value; }
            get { return _buytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PayDate
        {
            set { _paydate = value; }
            get { return _paydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PayStatus
        {
            set { _paystatus = value; }
            get { return _paystatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OtherInfo
        {
            set { _otherinfo = value; }
            get { return _otherinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model
        #endregion Model
    }
}

