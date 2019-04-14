using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class Pay
    {
        public Pay()
		{}
		#region Model
		private long _orderno;
		private string _paytypecode;
		private string _loginname;
		private string _nickname;
		private string _email;
		private string _tel;
		private string _mobileno;
		private string _realname;
		private decimal _totalcount;
		private DateTime _orderdate;
		private DateTime _paydate;
		private int _paystatus;
		private string _otherinfo;
		private string _remark;
        private int _card1;
        private int _card2;
        private int _card3;
        private int _card4;
		/// <summary>
		/// 
		/// </summary>
		public long OrderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PayTypeCode
		{
			set{ _paytypecode=value;}
			get{return _paytypecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NickName
		{
			set{ _nickname=value;}
			get{return _nickname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MobileNo
		{
			set{ _mobileno=value;}
			get{return _mobileno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
			set{ _realname=value;}
			get{return _realname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TotalCount
		{
			set{ _totalcount=value;}
			get{return _totalcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime OrderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PayDate
		{
			set{ _paydate=value;}
			get{return _paydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PayStatus
		{
			set{ _paystatus=value;}
			get{return _paystatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OtherInfo
		{
			set{ _otherinfo=value;}
			get{return _otherinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        public int card1
        {
            set { _card1 = value; }
            get { return _card1; }
        }
        public int card2
        {
            set { _card2 = value; }
            get { return _card2; }
        }
        public int card3
        {
            set { _card3 = value; }
            get { return _card3; }
        }
        public int card4
        {
            set { _card4 = value; }
            get { return _card4; }
        }
		#endregion Model
    }
}
