using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalPlease:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProfessionalPlease
	{
		public ProfessionalPlease()
		{}
		#region Model
		private int _provideid;
		private int _professionalid;
		private string _countrycode;
		private string _provinceid;
		private string _cityid;
		private string _countyid;
		private int _servicetypeid;
		private int _institutionsid;
		private string _enterprisesize;
		private string _funds;
		private string _turnover;
		private DateTime _companydate;
		private int _validityid;
		private string _description;
		private string _title;
		private string _keywords;
		private string _webdescription;
        //private string _companyName;

        //public string CompanyName
        //{
        //    get { return _companyName; }
        //    set { _companyName = value; }
        //}
		/// <summary>
        /// 主键
		/// </summary>
		public int provideID
		{
			set{ _provideid=value;}
			get{return _provideid;}
		}
		/// <summary>
        ///  外键（ProfessionalinfoTab）
		/// </summary>
		public int ProfessionalID
		{
			set{ _professionalid=value;}
			get{return _professionalid;}
		}
		/// <summary>
        /// 国家
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
        /// 省
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
        /// 市
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
        /// 区
		/// </summary>
		public string CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
        /// 服务类型
		/// </summary>
		public int servicetypeID
		{
			set{ _servicetypeid=value;}
			get{return _servicetypeid;}
		}
		/// <summary>
        /// 机构类别
		/// </summary>
		public int institutionsID
		{
			set{ _institutionsid=value;}
			get{return _institutionsid;}
		}
		/// <summary>
        /// 企业规模
		/// </summary>
		public string Enterprisesize
		{
			set{ _enterprisesize=value;}
			get{return _enterprisesize;}
		}
		/// <summary>
        /// 注册资金
		/// </summary>
		public string funds
		{
			set{ _funds=value;}
			get{return _funds;}
		}
		/// <summary>
        /// 营业额
		/// </summary>
		public string turnover
		{
			set{ _turnover=value;}
			get{return _turnover;}
		}
		/// <summary>
        /// 创建时间
		/// </summary>
        public DateTime companydate
		{
			set{ _companydate=value;}
			get{return _companydate;}
		}
		/// <summary>
        /// 有效期
		/// </summary>
		public int validityID
		{
			set{ _validityid=value;}
			get{return _validityid;}
		}
		/// <summary>
        /// 申请描述
		/// </summary>
        public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
        /// 网页title
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
        /// 网页keywords
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
        /// 网页Description 
		/// </summary>
		public string webdescription
		{
			set{ _webdescription=value;}
			get{return _webdescription;}
		}
		#endregion Model

	}
}

