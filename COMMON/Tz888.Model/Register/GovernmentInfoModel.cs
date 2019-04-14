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
		/// 机构名称
		/// </summary>
		public string GovernmentName
		{
		set{ _governmentname=value;}
		get{return _governmentname;}
		}
		/// <summary>
		/// 机构介绍
		/// </summary>
		public string GovAbout
		{
		set{ _govabout=value;}
		get{return _govabout;}
		}
		/// <summary>
		/// 机构介绍提炼
		/// </summary>
		public string GovAboutBrief
		{
		set{ _govaboutbrief=value;}
		get{return _govaboutbrief;}
		}
		/// <summary>
		/// 主体类型
		/// </summary>
		public string SubjectType
		{
		set{ _subjecttype=value;}
		get{return _subjecttype;}
		}
		/// <summary>
		/// 国家代码
		/// </summary>
		public string CountryCode
		{
		set{ _countrycode=value;}
		get{return _countrycode;}
		}
		/// <summary>
		/// 省代码
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
		/// 县
		/// </summary>
		public string CountyID
		{
		set{ _countyid=value;}
		get{return _countyid;}
		}
		/// <summary>
		/// 审核状态
		/// </summary>
		public int AuditingStatus
		{
		set{ _auditingstatus=value;}
		get{return _auditingstatus;}
		}
		/// <summary>
		/// 展厅地址
		/// </summary>
		public string ExhibitionHall
		{
		set{ _exhibitionhall=value;}
		get{return _exhibitionhall;}
		}

        /// <summary>
        /// 点击数
        /// </summary>
        public int Hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// 公司在我网登记时间
        /// </summary>
        public DateTime EnrolDate
        {
            set { _enrolDate = value; }
            get { return _enrolDate; }
        }

		/// <summary>
		/// 备注
		/// </summary>
		public string remark
		{
		set{ _remark=value;}
		get{return _remark;}
		}
		#endregion Model

	}
}


