using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    public class GovernmentInfoModel
    {
        public GovernmentInfoModel()
		{}
		#region Model
		private int _governmentid;
		private string _loginname;
		private string _governmentname;
		private string _govabout;
		private string _govaboutbrief;
		private string _subjecttype;
		private string _countrycode;
		private string _provinceid;
		private string _cityid;
		private string _countyid;
		private int _auditingstatus;
		private string _exhibitionhall;
        private int _hits;
        private DateTime _enrolDate;
		private string _remark;
		/// <summary>
		/// GovernmentID
		/// </summary>
		public int GovernmentID
		{
		set{ _governmentid=value;}
		get{return _governmentid;}
		}
		/// <summary>
		/// LoginName
		/// </summary>
		public string LoginName
		{
		set{ _loginname=value;}
		get{return _loginname;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string GovernmentName
		{
		set{ _governmentname=value;}
		get{return _governmentname;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string GovAbout
		{
		set{ _govabout=value;}
		get{return _govabout;}
		}
		/// <summary>
		/// ������������
		/// </summary>
		public string GovAboutBrief
		{
		set{ _govaboutbrief=value;}
		get{return _govaboutbrief;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string SubjectType
		{
		set{ _subjecttype=value;}
		get{return _subjecttype;}
		}
		/// <summary>
		/// ���Ҵ���
		/// </summary>
		public string CountryCode
		{
		set{ _countrycode=value;}
		get{return _countrycode;}
		}
		/// <summary>
		/// ʡ����
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
		/// ���״̬
		/// </summary>
		public int AuditingStatus
		{
		set{ _auditingstatus=value;}
		get{return _auditingstatus;}
		}
		/// <summary>
		/// չ����ַ
		/// </summary>
		public string ExhibitionHall
		{
		set{ _exhibitionhall=value;}
		get{return _exhibitionhall;}
		}

        /// <summary>
        /// �����
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// ��˾�������Ǽ�ʱ��
        /// </summary>
        public DateTime EnrolDate
        {
            set { _enrolDate = value; }
            get { return _enrolDate; }
        }

		/// <summary>
		/// ��ע
		/// </summary>
		public string remark
		{
		set{ _remark=value;}
		get{return _remark;}
		}
		#endregion Model

	}
}


