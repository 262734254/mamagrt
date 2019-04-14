using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    [Serializable]
   public class LmOrderTab
    {
        /// <summary>
        /// 实体类M_LmOrderTab 。(属性说明自动提取数据库字段的描述信息)
        /// </summary>
        
       public LmOrderTab()
		{}
		#region Model
		private long _lmorderid;
		private long _orderno;
		private string _loginname;
		private string _buyname;
		private long _infoid;
		private decimal _totalamount;
		private decimal _shareamount;
		private DateTime _paydate;
		/// <summary>
		/// 
		/// </summary>
		public long lmorderid
		{
			set{ _lmorderid=value;}
			get{return _lmorderid;}
		}
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
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BuyName
		{
			set{ _buyname=value;}
			get{return _buyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long InfoID
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TotalAmount
		{
			set{ _totalamount=value;}
			get{return _totalamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ShareAmount
		{
			set{ _shareamount=value;}
			get{return _shareamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Paydate
		{
			set{ _paydate=value;}
			get{return _paydate;}
		}
		#endregion Model
    }
}
