using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
	/// <summary>
    /// 实体类InnerInfoReceived 。(属性说明自动提取数据库字段的描述信息) 收件信息 己、未读的
	/// </summary>
    public class InnerInfoReceived
	{
		public InnerInfoReceived()
		{}
		#region Model
		private int _receivedid;
		private int _sendid;
		private string _receivedname;
		private string _topic;
		private string _context;
		private int _size;
		private int _isreaded;
		private string _sendedman;
		private DateTime _receivedtime;
		private string _changeby;
		private DateTime _changetime;
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
		public int SendID
		{
		set{ _sendid=value;}
		get{return _sendid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReceivedName
		{
		set{ _receivedname=value;}
		get{return _receivedname;}
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
		public int IsReaded
		{
		set{ _isreaded=value;}
		get{return _isreaded;}
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
		public DateTime ReceivedTime
		{
		set{ _receivedtime=value;}
		get{return _receivedtime;}
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

