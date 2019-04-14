using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// Professionaltalents:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Professionaltalents
	{
		public Professionaltalents()
		{}
		#region Model
		private int _talentsid;
		private int _professionalid;
		private string _countrycode;
		private string _provinceid;
		private string _cityid;
		private string _countyid;
		private string _position;
		private int _servicetypeid;
		private int _talentstypeid;
		private string _resume;
		private string _specialty;
		private string _scucccase;
        private DateTime _companydate;
		private int _validityid;
		private string _title;
		private string _keywords;
		private string _webdescription;
        private string _images;
        public string Images
        {
            set { _images = value; }
            get { return _images; }
        }
		/// <summary>
        /// 主键
		/// </summary>
		public int talentsID
		{
			set{ _talentsid=value;}
			get{return _talentsid;}
		}
		/// <summary>
        /// 外键（ProfessionalinfoTab）
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
        /// 职务
		/// </summary>
		public string position
		{
			set{ _position=value;}
			get{return _position;}
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
        /// 人才类别
		/// </summary>
		public int talentsTypeID
		{
			set{ _talentstypeid=value;}
			get{return _talentstypeid;}
		}
		/// <summary>
        /// 个人简历
		/// </summary>
		public string resume
		{
			set{ _resume=value;}
			get{return _resume;}
		}
		/// <summary>
        /// 个人特长
		/// </summary>
		public string specialty
		{
			set{ _specialty=value;}
			get{return _specialty;}
		}
		/// <summary>
        /// 成功案例
		/// </summary>
		public string ScuccCase
		{
			set{ _scucccase=value;}
			get{return _scucccase;}
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
		public string Webdescription
		{
			set{ _webdescription=value;}
			get{return _webdescription;}
		}
		#endregion Model

	}
}

