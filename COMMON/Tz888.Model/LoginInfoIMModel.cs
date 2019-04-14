using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
     public class LoginInfoIMModel
    {
        #region Model
		private string _loginname;
		private string _imtype;
		private string _imaccount;
		private int _isdisable;
		private string _remark;
		/// <summary>
		/// LoginName
		/// </summary>
		public string LoginName
		{
		set{ _loginname=value;}
		get{return _loginname;}
		}
		/// <summary>
		/// IM工具类型QQ,MSN
		/// </summary>
		public string IMType
		{
		set{ _imtype=value;}
		get{return _imtype;}
		}
		/// <summary>
		/// IM帐号
		/// </summary>
		public string IMAccount
		{
		set{ _imaccount=value;}
		get{return _imaccount;}
		}
		/// <summary>
		/// 是否禁用
		/// </summary>
		public int IsDisable
		{
		set{ _isdisable=value;}
		get{return _isdisable;}
		}
		/// <summary>
		/// Remark
		/// </summary>
		public string Remark
		{
		set{ _remark=value;}
		get{return _remark;}
		}
		#endregion Model
	}
}


