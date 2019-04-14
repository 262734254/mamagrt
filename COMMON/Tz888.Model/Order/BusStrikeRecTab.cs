using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Orders
{
    [Serializable]
  public  class BusStrikeRecTab
   {
       /// <summary>
       /// 实体类M_BusStrikeRecTab 。(属性说明自动提取数据库字段的描述信息)
       /// </summary>
  
      public BusStrikeRecTab()
		{}
		#region Model
		private int _id;
		private string _loginname;
		private long _cardno;
		private decimal? _pointcount;
		private string _remark;
		private string _changeby;
		private DateTime _changetime;
		private string _foreigntradeno;
		private string _email;
		private string _tel;
		private string _mobile;
		private string _striketype;
        private int _free;
        private string cardNumber;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }

        public int Free
        {
            get { return _free; }
            set { _free = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public long CardNo
		{
			set{ _cardno=value;}
			get{return _cardno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PointCount
		{
			set{ _pointcount=value;}
			get{return _pointcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChangeBy
		{
			set{ _changeby=value;}
			get{return _changeby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ChangeTime
		{
			set{ _changetime=value;}
			get{return _changetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ForeignTradeNo
		{
			set{ _foreigntradeno=value;}
			get{return _foreigntradeno;}
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
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StrikeType
		{
			set{ _striketype=value;}
			get{return _striketype;}
		}
		#endregion Model

	}
}


