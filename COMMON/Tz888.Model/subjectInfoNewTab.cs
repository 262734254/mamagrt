using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public  class subjectInfoNewTab
    {
        #region Model
		private long _id;
		private long _infoid;
		private int _subjectid;
		private int _menuid;
		private string _editorer;
		private int _istop;
		private DateTime _adddate;
		private string _titlestyle;
		/// <summary>
		/// 
		/// </summary>
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
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
		public int SubjectID
		{
			set{ _subjectid=value;}
			get{return _subjectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int MenuID
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Editorer
		{
			set{ _editorer=value;}
			get{return _editorer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isTop
		{
			set{ _istop=value;}
			get{return _istop;}
		}
		public string titleStyle
		{
			 set{ _titlestyle=value;}
			 get{return _titlestyle;}
		}
		public DateTime AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		#endregion Model
    }
    
}
