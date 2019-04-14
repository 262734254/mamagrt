using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalPlease:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����
		/// </summary>
		public int provideID
		{
			set{ _provideid=value;}
			get{return _provideid;}
		}
		/// <summary>
        ///  �����ProfessionalinfoTab��
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
		public int servicetypeID
		{
			set{ _servicetypeid=value;}
			get{return _servicetypeid;}
		}
		/// <summary>
        /// �������
		/// </summary>
		public int institutionsID
		{
			set{ _institutionsid=value;}
			get{return _institutionsid;}
		}
		/// <summary>
        /// ��ҵ��ģ
		/// </summary>
		public string Enterprisesize
		{
			set{ _enterprisesize=value;}
			get{return _enterprisesize;}
		}
		/// <summary>
        /// ע���ʽ�
		/// </summary>
		public string funds
		{
			set{ _funds=value;}
			get{return _funds;}
		}
		/// <summary>
        /// Ӫҵ��
		/// </summary>
		public string turnover
		{
			set{ _turnover=value;}
			get{return _turnover;}
		}
		/// <summary>
        /// ����ʱ��
		/// </summary>
        public DateTime companydate
		{
			set{ _companydate=value;}
			get{return _companydate;}
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
		public string webdescription
		{
			set{ _webdescription=value;}
			get{return _webdescription;}
		}
		#endregion Model

	}
}

