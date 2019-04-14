using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
	/// <summary>
	/// 实体类InnerInfoSend 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class InnerInfoSend
	{
		public InnerInfoSend()
		{}
		#region Model
		private int _sendid;
		private int _receivedid;
		private string _loginname;
		private string _topic;
		private string _context;
		private int _size;
		private int _issended;
		private int _isreaded;
		private string _receivedman;
		private DateTime _sendtime;
		private string _changeby;
		private DateTime _changetime;
		/// <summary>
		/// 
		/// </summary>
		public int SendID
		{
		set{ _sendid=value;}
		get{return _sendid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ReceivedID
		{
		set{ _receivedid=value;}
		get{return _receivedid;}
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
		public string Topic
		{
		set{ _topic=value;}
		get{return _topic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Context
		{
		set{ _context=value;}
		get{return _context;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Size
		{
		set{ _size=value;}
		get{return _size;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsSended
		{
		set{ _issended=value;}
		get{return _issended;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsReaded
		{
		set{ _isreaded=value;}
		get{return _isreaded;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceivedMan
		{
		set{ _receivedman=value;}
		get{return _receivedman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime SendTime
		{
		set{ _sendtime=value;}
		get{return _sendtime;}
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
		#endregion Model

	}
}



