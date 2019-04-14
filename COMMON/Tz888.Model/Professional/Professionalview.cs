using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// Professionalview:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class Professionalview
	{
		public Professionalview()
		{}
		#region Model
		private int _pvid;
		private int _professionalid;
		private string _countrycode;
		private string _provinceid;
		private string _cityid;
		private string _countyid;
		private int _typeid;
		private int _validityid;
		private string _description;
		private string _title;
		private string _keywords;
		private string _webdescription;
		/// <summary>
        /// 主键
		/// </summary>
		public int pvid
		{
			set{ _pvid=value;}
			get{return _pvid;}
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
        /// 服务类型
		/// </summary>
		public int typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
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
		public string Webdescription
		{
			set{ _webdescription=value;}
			get{return _webdescription;}
		}
		#endregion Model

	}
}

