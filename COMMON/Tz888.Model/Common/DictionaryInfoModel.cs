using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Common
{
    public class DictionaryInfoModel
    {
        public DictionaryInfoModel()
		{}
        #region 父类Model 
        private string _dictionarytypecode;
        private string _dictionarytypename;
        private string _dictionarytyperemark;
        /// <summary>
        /// 
        /// </summary>
        public string DictionaryTypeCode
        {
            set { _dictionarytypecode = value; }
            get { return _dictionarytypecode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DictionaryTypeName
        {
            set { _dictionarytypename = value; }
            get { return _dictionarytypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DictionaryTypeRemark
        {
            set { _dictionarytyperemark = value; }
            get { return _dictionarytyperemark; }
        }
        #endregion 子类Model

		#region 子类Model
		private int _dictionaryinfoid;
		private string _dictionarycode;
		private string _dictionaryinfoname;
		//private string _dictionarytypecode;
		private string _dictionaryinfoparam;
		private string _dictionaryinforemark;
		/// <summary>
		/// 
		/// </summary>
		public int DictionaryInfoId
		{
		set{ _dictionaryinfoid=value;}
		get{return _dictionaryinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DictionaryCode
		{
		set{ _dictionarycode=value;}
		get{return _dictionarycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DictionaryInfoName
		{
		set{ _dictionaryinfoname=value;}
		get{return _dictionaryinfoname;}
		}
		/// <summary>
		/// 
		/// </summary>
        //public string DictionaryTypeCode
        //{
        //set{ _dictionarytypecode=value;}
        //get{return _dictionarytypecode;}
        //}
		/// <summary>
		/// 
		/// </summary>
		public string DictionaryInfoParam
		{
		set{ _dictionaryinfoparam=value;}
		get{return _dictionaryinfoparam;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DictionaryInfoRemark
		{
		set{ _dictionaryinforemark=value;}
		get{return _dictionaryinforemark;}
		}
		#endregion Model

	}
}

