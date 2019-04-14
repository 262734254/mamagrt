using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// Professionaltalents:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����
		/// </summary>
		public int talentsID
		{
			set{ _talentsid=value;}
			get{return _talentsid;}
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
        /// ְ��
		/// </summary>
		public string position
		{
			set{ _position=value;}
			get{return _position;}
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
        /// �˲����
		/// </summary>
		public int talentsTypeID
		{
			set{ _talentstypeid=value;}
			get{return _talentstypeid;}
		}
		/// <summary>
        /// ���˼���
		/// </summary>
		public string resume
		{
			set{ _resume=value;}
			get{return _resume;}
		}
		/// <summary>
        /// �����س�
		/// </summary>
		public string specialty
		{
			set{ _specialty=value;}
			get{return _specialty;}
		}
		/// <summary>
        /// �ɹ�����
		/// </summary>
		public string ScuccCase
		{
			set{ _scucccase=value;}
			get{return _scucccase;}
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

