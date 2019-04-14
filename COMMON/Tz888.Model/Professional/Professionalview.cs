using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// Professionalview:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����
		/// </summary>
		public int pvid
		{
			set{ _pvid=value;}
			get{return _pvid;}
		}
		/// <summary>
        /// �����ProfessionalinfoTab��
		/// </summary>
		public int ProfessionalID
		{
			set{ _professionalid=value;}
			get{return _professionalid;}
		}
		/// <summary>
        /// ����
		/// </summary>
		public string CountryCode
		{
			set{ _countrycode=value;}
			get{return _countrycode;}
		}
		/// <summary>
        /// ʡ
		/// </summary>
		public string ProvinceID
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
        /// ��
		/// </summary>
		public string CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
        /// ��
		/// </summary>
		public string CountyID
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
        /// ��������
		/// </summary>
		public int typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
        /// ��Ч��
		/// </summary>
		public int validityID
		{
			set{ _validityid=value;}
			get{return _validityid;}
		}
		/// <summary>
        /// ��������
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
        /// ��ҳtitle
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
        /// ��ҳkeywords
		/// </summary>
		public string keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
        /// ��ҳDescription 
		/// </summary>
		public string Webdescription
		{
			set{ _webdescription=value;}
			get{return _webdescription;}
		}
		#endregion Model

	}
}

