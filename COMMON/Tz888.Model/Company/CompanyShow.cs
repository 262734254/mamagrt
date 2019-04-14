using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class CompanyShow
    {
        public CompanyShow()
        {

        }
        #region Model
        private int _companyid;//���
        private string _username;//�û���
        private byte[] _userpwd;//����
        private string _telphone;//�绰����
        private string _mobile;//�ֻ�����
        private string _email;//��������
        private int _audit;//���״̬
        private DateTime _starttime;//����ʱ��
        private int _valid;//��Ч��
        private string _typename;//����Ӧ������
        private string _companyName; //��ҵ����
        private string _countrycode;//����
        private string _provinceid;//ʡ
        private string _cityid;//��
        private string _countyid;//����
        private int _orderId;//����
        private string _recomm; //�Ƽ�
        private string _roleId;//��ɫ
        private string industry;

        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }
        /// <summary>
        /// ��ɫ
        /// </summary>
        public string RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Countrycode
        {
            get { return _countrycode; }
            set { _countrycode = value; }
        }
        /// <summary>
        /// ʡ
        /// </summary>
        public string Provinceid
        {
            get { return _provinceid; }
            set { _provinceid = value; }
        }
        /// <summary>
        /// ��
        /// </summary>
        public string Cityid
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Countyid
        {
            get { return _countyid; }
            set { _countyid = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        /// <summary>
        /// �Ƽ�
        /// </summary>
        public string Recomm
        {
            get { return _recomm; }
            set { _recomm = value; }
        }



        /// <summary>
        /// ��ҵ����
        /// </summary>
        public string CompanyName
        {
            set { _companyName = value; }
            get { return _companyName; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public int CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
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
        /// ����
        /// </summary>
        public byte[] UserPwd
        {
            set { _userpwd = value; }
            get { return _userpwd; }
        }
        /// <summary>
        /// �绰����
        /// </summary>
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// �ֻ�����
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
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
        public int Audit
        {
            set { _audit = value; }
            get { return _audit; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// ��Ч��
        /// </summary>
        public int Valid
        {
            set { _valid = value; }
            get { return _valid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Typename
        {
            get { return _typename; }
            set { _typename = value; }
        }

        #endregion Model
    }
}
