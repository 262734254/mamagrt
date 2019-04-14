using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    public class EnterpriseInfoModel
    {
        public EnterpriseInfoModel()
        { }
        #region Model
        private int _enterpriseid;
        private string _loginname;
        private string _enterprisename;
        private string _comabout;
        private string _comaboutbrief;
        private int _setcomtypeid;
        private string _industrylist;
        private DateTime _registerdate;
        private string _countrycode;
        private string _provinceid;
        private string _cityid;
        private string _countyid;
        private string _currency;
        private decimal _regcapital;
        private string _mainproduct;
        private string _requirinfo;
        private int _auditingstatus;
        private string _exhibitionhall;
        private int _hits;
        private DateTime _enrolDate;
        private string _remark;
        /// <summary>
        /// ��ҵID
        /// </summary>
        public int EnterpriseID
        {
            set { _enterpriseid = value; }
            get { return _enterpriseid; }
        }
        /// <summary>
        /// LoginName
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// ��˾����
        /// </summary>
        public string EnterpriseName
        {
            set { _enterprisename = value; }
            get { return _enterprisename; }
        }
        /// <summary>
        /// ��˾����
        /// </summary>
        public string ComAbout
        {
            set { _comabout = value; }
            get { return _comabout; }
        }
        /// <summary>
        /// ��˾��������
        /// </summary>
        public string ComAboutBrief
        {
            set { _comaboutbrief = value; }
            get { return _comaboutbrief; }
        }
        /// <summary>
        /// ManageTypeID
        /// </summary>
        public int SetComTypeID
        {
            set { _setcomtypeid = value; }
            get { return _setcomtypeid; }
        }
        /// <summary>
        /// ��ҵ����
        /// </summary>
        public string Industrylist
        {
            set { _industrylist = value; }
            get { return _industrylist; }
        }
        /// <summary>
        /// ע��ʱ��
        /// </summary>
        public DateTime RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
        }
        /// <summary>
        /// ���Ҵ���
        /// </summary>
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
        }
        /// <summary>
        /// ʡ����
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public string CountyID
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        /// <summary>
        /// ע���ʱ�
        /// </summary>
        public decimal RegCapital
        {
            set { _regcapital = value; }
            get { return _regcapital; }
        }
        /// <summary>
        /// ��Ӫ��Ʒ
        /// </summary>
        public string MainProduct
        {
            set { _mainproduct = value; }
            get { return _mainproduct; }
        }
        /// <summary>
        /// �Ǽ�����
        /// </summary>
        public string RequirInfo
        {
            set { _requirinfo = value; }
            get { return _requirinfo; }
        }
        /// <summary>
        /// ���״̬(�����0 �ѷ�������1 δͨ�����2 ��ɾ��3 )
        /// </summary>
        public int AuditingStatus
        {
            set { _auditingstatus = value; }
            get { return _auditingstatus; }
        }
        /// <summary>
        /// չ����ַ
        /// </summary>
        public string ExhibitionHall
        {
            set { _exhibitionhall = value; }
            get { return _exhibitionhall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int hits
        {
            set { _hits = value; }
            get { return _hits; }
        }
        /// <summary>
        /// �������Ǽ�ʱ��
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
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

