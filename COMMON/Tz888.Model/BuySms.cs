using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类SmsConsumeRecTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class SmsConsume
    {
        public SmsConsume()
        { }
        #region Model
        private int _recid;
        private int _orderno;
        private string _loginname;
        private string _consumetype;
        private int _quantity;
        private decimal _amount;
        private decimal _dicamount;
        private int _status;
        private DateTime _paydate;
        private string _paytype;
        /// <summary>
        /// 
        /// </summary>
        public int RecID
        {
            set { _recid = value; }
            get { return _recid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OrderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
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
        public string ConsumeType
        {
            set { _consumetype = value; }
            get { return _consumetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal dicAmount
        {
            set { _dicamount = value; }
            get { return _dicamount; }
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
        public DateTime PayDate
        {
            set { _paydate = value; }
            get { return _paydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        #endregion Model
    }
}

