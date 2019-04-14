using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
   public class SEOLoginTabModel
    {
        public SEOLoginTabModel()
		{}
		#region Model
		private int _seologinid;
		private string _title;
		private string _subtitle;
		private string _keyword;
		private string _summary;
		private int _loginid;
		/// <summary>
		/// 
		/// </summary>
		public int SEOLoginID
		{
		set{ _seologinid=value;}
		get{return _seologinid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
		set{ _title=value;}
		get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SubTitle
		{
		set{ _subtitle=value;}
		get{return _subtitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword
		{
		set{ _keyword=value;}
		get{return _keyword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Summary
		{
		set{ _summary=value;}
		get{return _summary;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LoginID
		{
		set{ _loginid=value;}
		get{return _loginid;}
		}
		#endregion Model

	}
}
