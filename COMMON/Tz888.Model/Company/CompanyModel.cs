using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    [Serializable]
    public class CompanyModel
    {
        private int _companyid;
		private string _loginname;
		private string _companyname;
		private int? _industryid;
		private string _industryname;
		private int? _rangeid;
		private string _rangename;
		private int? _natureid;
		private string _naturename;
		private DateTime? _createdate;
		private int? _hit;
		private int? _integrity;
		private string _establishment;
		private long _employees;
		private long _capital;
		private string _linkname;
		private string _email;
		private string _url;
		private string _address;
		private string _logo;
		private string _introduction;
		private string _serviceproce;
		private string _title;
		private string _keywords;
		private string _description;
        private string _telphone;
        private string _mobile;
        private int? _auditingstatus;
        private string _htmlfile;
        private int _ismake;
        private int _isDelete;
        private int _Provice;
        private int _City;
        private int _FromId;

        /// <summary>
        /// ʡ��
        /// </summary>
        public int Provice 
        {
            get { return _Provice; }
            set { _Provice = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public int City
        {
            get { return _City; }
            set { _City = value; }
        }

        /// <summary>
        /// ��Դ
        /// </summary>
        public int FromId
        {
            get { return _FromId; }
            set { _FromId = value; }
        }
      
		/// <summary>
		/// ��ҵID
		/// </summary>
		public int CompanyID
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// �û���
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// ��ҵ����
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// ��ҵID
		/// </summary>
		public int? IndustryID
		{
			set{ _industryid=value;}
			get{return _industryid;}
		}
		/// <summary>
		/// ��ҵ����
		/// </summary>
		public string IndustryName
		{
			set{ _industryname=value;}
			get{return _industryname;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int? RangeID
		{
			set{ _rangeid=value;}
			get{return _rangeid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string RangeName
		{
			set{ _rangename=value;}
			get{return _rangename;}
		}
		/// <summary>
		/// ��ҵ����ID
		/// </summary>
		public int? NatureID
		{
			set{ _natureid=value;}
			get{return _natureid;}
		}
		/// <summary>
		/// ��ҵ��������
		/// </summary>
		public string NatureName
		{
			set{ _naturename=value;}
			get{return _naturename;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime? CreateDate
		{
			set{ _createdate=value;}
			get{return _createdate;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int? Hit
		{
			set{ _hit=value;}
			get{return _hit;}
		}
		/// <summary>
		/// ����ָ��
		/// </summary>
		public int? Integrity
		{
			set{ _integrity=value;}
			get{return _integrity;}
		}
		/// <summary>
        /// ��������
		/// </summary>
		public string EstablishMent
		{
			set{ _establishment=value;}
			get{return _establishment;}
		}
		/// <summary>
		/// Ա������
		/// </summary>
		public long Employees
		{
			set{ _employees=value;}
			get{return _employees;}
		}
		/// <summary>
		/// ע���ʽ�
		/// </summary>
		public long Capital
		{
			set{ _capital=value;}
			get{return _capital;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string LinkName
		{
			set{ _linkname=value;}
			get{return _linkname;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
        /// ��ҵ��ַ
		/// </summary>
		public string URL
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// ��ϵ��ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// Logo
		/// </summary>
		public string Logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// ��ҵ���
		/// </summary>
		public string Introduction
		{
			set{ _introduction=value;}
			get{return _introduction;}
		}
		/// <summary>
		/// ��Ӫ��Ʒ/����
		/// </summary>
		public string ServiceProce
		{
			set{ _serviceproce=value;}
			get{return _serviceproce;}
		}
		/// <summary>
		/// ��ҳ����
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// �ؼ���
		/// </summary>
		public string Keywords
		{
			set{ _keywords=value;}
			get{return _keywords;}
		}
		/// <summary>
		/// ��ҳ�̱���
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
        /// <summary>
        /// �绰����
        /// </summary>
        public string Telphone
        {
            get { return _telphone; }
            set { _telphone = value; }
        }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// ���״̬
        /// </summary>
        public int? Auditingstatus
        {
            get { return _auditingstatus; }
            set { _auditingstatus = value; }
        }
        /// <summary>
        /// ��̬·��
        /// </summary>
        public string Htmlfile
        {
            get { return _htmlfile; }
            set { _htmlfile = value; }
        }
        /// <summary>
        /// �Ƿ��ƹ�
        /// </summary>
        public int Ismake
        {
            get { return _ismake; }
            set { _ismake = value; }
        }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public int IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
    }
}
