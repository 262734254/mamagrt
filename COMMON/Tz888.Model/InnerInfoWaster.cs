using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
	/// <summary>
	/// 实体类InnerInfoWaster 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class InnerInfoWaster
	{
		public InnerInfoWaster()
		{}
		#region Model
		private int _wasterid;
		private string _loginname;
		private string _topic;
		private string _context;
		private int _size;
		private string _sendedman;
		private string _receivedman;
		private DateTime _timestatus;
		private string _changeby;
		private DateTime _changetime;
		/// <summary>
		/// 
		/// </summary>
		public int WasterID
		{
		set{ _wasterid=value;}
		get{return _wasterid;}
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
		public string SendedMan
		{
		set{ _sendedman=value;}
		get{return _sendedman;}
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
		public DateTime TimeStatus
		{
		set{ _timestatus=value;}
		get{return _timestatus;}
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

