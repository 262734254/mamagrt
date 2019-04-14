using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class CompanyMadeModel
    {
        #region Model
        private int _madeid;
        private string _companyid;
        private string _price;
        private string _sumprice;
        private string _username;
        private DateTime? _createdate;
        private DateTime? _begintime;
        private DateTime? _endtime;
        private string _linkname;
        private string _telphone;
        private string _email;
        private int? _audit;
        private string _auditname;
        private int? _hit;
        private int? _visitHit;

        /// <summary>
        /// ���
        /// </summary>
        public int MadeID
        {
            set { _madeid = value; }
            get { return _madeid; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public string CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// �۸�
        /// </summary>
        public string Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// �ܼ۸�
        /// </summary>
        public string SumPrice
        {
            set { _sumprice = value; }
            get { return _sumprice; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// ��ʼʱ��
        /// </summary>
        public DateTime? BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string LinkName
        {
            set { _linkname = value; }
            get { return _linkname; }
        }
        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// ���״̬
        /// </summary>
        public int? Audit
        {
            set { _audit = value; }
            get { return _audit; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public string AuditName
        {
            set { _auditname = value; }
            get { return _auditname; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public int? Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int? VisitHit
        {
            get { return _visitHit; }
            set { _visitHit = value; }
        }

        #endregion Model
    }
}
