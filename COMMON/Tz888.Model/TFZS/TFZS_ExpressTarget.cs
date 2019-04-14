using System;
namespace Tz888.Model.TFZS
{
    /// <summary>
    /// 拓富指数表现指标实体类
    /// </summary>
    public class TFZS_ExpressTarget
    {
        public TFZS_ExpressTarget()
        { }
        #region Model
		private string _expresscode;
		private string _maintargetcode;
		private string _expressname;
		private string _expressdescript;
		private decimal _expresspoint;
		private string _expresstype;
		private bool _ismulti;
		private string _expressremark;
		private int _sortid;
		/// <summary>
		/// 
		/// </summary>
		public string ExpressCode
		{
			set{ _expresscode=value;}
			get{return _expresscode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MainTargetCode
		{
			set{ _maintargetcode=value;}
			get{return _maintargetcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExpressName
		{
			set{ _expressname=value;}
			get{return _expressname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExpressDescript
		{
			set{ _expressdescript=value;}
			get{return _expressdescript;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal ExpressPoint
		{
			set{ _expresspoint=value;}
			get{return _expresspoint;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExpressType
		{
			set{ _expresstype=value;}
			get{return _expresstype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsMulti
		{
			set{ _ismulti=value;}
			get{return _ismulti;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ExpressRemark
		{
			set{ _expressremark=value;}
			get{return _expressremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SortID
		{
			set{ _sortid=value;}
			get{return _sortid;}
		}

        public TFZS_ExpressTarget(
            string expresscode,
            string maintargetcode,
            string expressname,
            string expressdescript,
            decimal expresspoint,
            string expresstype,
            bool ismulti,
            string expressremark,
            int sortid)
        {
            this._expresscode = expresscode;
            this._maintargetcode = maintargetcode;
            this._expressname = expressname;
            this._expressdescript = expressdescript;
            this._expresspoint = expresspoint;
            this._expresstype = expresstype;
            this._ismulti = ismulti;
            this._expressremark = expressremark;
            this._sortid = sortid;
        }
        #endregion Model
    }
}

