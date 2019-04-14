using System;
namespace Tz888.Model.SendMsg
{
	/// <summary>
	/// 实体类DYHIKEMESSAGES 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class MobileMsg
	{
        public MobileMsg()
		{}
		#region Model
		private int _dymsgid;
		private string _from_mobile;
		private string _to_mobile;
		private string _pay_mobile_tel;
		private string _msg_content;
		private int _cost;
		private DateTime _create_date;
		private DateTime _send_time;
		private string _send_out_flag;
		private string _username;
		private string _password;
		private string _prefix;
		private DateTime _presend_time;
		private string _epid;
		/// <summary>
		/// 
		/// </summary>
		public int DYMSGID
		{
			set{ _dymsgid=value;}
			get{return _dymsgid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FROM_MOBILE
		{
			set{ _from_mobile=value;}
			get{return _from_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TO_MOBILE
		{
			set{ _to_mobile=value;}
			get{return _to_mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PAY_MOBILE_TEL
		{
			set{ _pay_mobile_tel=value;}
			get{return _pay_mobile_tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MSG_CONTENT
		{
			set{ _msg_content=value;}
			get{return _msg_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int COST
		{
			set{ _cost=value;}
			get{return _cost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime CREATE_DATE
		{
			set{ _create_date=value;}
			get{return _create_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SEND_TIME
		{
			set{ _send_time=value;}
			get{return _send_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SEND_OUT_FLAG
		{
			set{ _send_out_flag=value;}
			get{return _send_out_flag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERNAME
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PASSWORD
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PREFIX
		{
			set{ _prefix=value;}
			get{return _prefix;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PRESEND_TIME
		{
			set{ _presend_time=value;}
			get{return _presend_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EPID
		{
			set{ _epid=value;}
			get{return _epid;}
		}
		#endregion Model
	}
}

