using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    /// <summary>
    /// �ظ�ͨ��Աʵ����VipApplyTab ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    public class VIPMemberRegister
    {
        public VIPMemberRegister()
		{}
        #region Model
        private int _applyid;
        private string _loginname;
        private string _managetypeid;
        private int _buyterm;
        private string _orgname;
        private string _realname;
        private string _position;
        private bool _sex;
        private string _telcountrycode;
        private string _telstatecode;
        private string _telnum;
        private string _mobile;
        private string _email;
        private DateTime _applydate;
        private int _ispay;
        private int _oprstatus;
        private string _oprdescript;
        private string _marketpersonname;
        private string _oprman;
        private DateTime _oprdate;
        private DateTime _vipvalidatedate;
        private string _memo;
        private int _money;
        private int _years;
        private string _servicetype;
        private int _price;
        /// <summary>
        /// ApplyID
        /// </summary>
        public int ApplyID
        {
            set { _applyid = value; }
            get { return _applyid; }
        }
        /// <summary>
        /// ��Ա��¼��
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 0 ���˻�Ա 1 ��ҵ��Ա 3 ������Ա
        /// </summary>
        public string ManageTypeID
        {
            set { _managetypeid = value; }
            get { return _managetypeid; }
        }
        /// <summary>
        /// 1 3���� 2 ���� 3 1��
        /// </summary>
        public int BuyTerm
        {
            set { _buyterm = value; }
            get { return _buyterm; }
        }
        /// <summary>
        /// ��λ����
        /// </summary>
        public string OrgName
        {
            set { _orgname = value; }
            get { return _orgname; }
        }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// ְ    ��
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 0 male 1 female
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// �绰������
        /// </summary>
        public string TelCountryCode
        {
            set { _telcountrycode = value; }
            get { return _telcountrycode; }
        }
        /// <summary>
        /// �绰������
        /// </summary>
        public string TelStateCode
        {
            set { _telstatecode = value; }
            get { return _telstatecode; }
        }
        /// <summary>
        /// �绰����
        /// </summary>
        public string TelNum
        {
            set { _telnum = value; }
            get { return _telnum; }
        }
        /// <summary>
        /// �ֻ�
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime ApplyDate
        {
            set { _applydate = value; }
            get { return _applydate; }
        }
        /// <summary>
        /// �Ƿ񸶷�
        /// </summary>
        public int IsPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// 0  �ύ����� 1 ��ǩ��Э�� 2 �Ѹ��� 3 ͨ�������֤  4 �ѿ�ͨ�ظ�ͨ����
        /// </summary>
        public int OprStatus
        {
            set { _oprstatus = value; }
            get { return _oprstatus; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string OprDescript
        {
            set { _oprdescript = value; }
            get { return _oprdescript; }
        }
        /// <summary>
        /// ���Ո@
        /// </summary>
        public string MarketPersonName
        {
            set { _marketpersonname = value; }
            get { return _marketpersonname; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string OprMan
        {
            set { _oprman = value; }
            get { return _oprman; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime OprDate
        {
            set { _oprdate = value; }
            get { return _oprdate; }
        }
        /// <summary>
        /// ��Ч����
        /// </summary>
        public DateTime VIPValidateDate
        {
            set { _vipvalidatedate = value; }
            get { return _vipvalidatedate; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int Years
        {
            set { _years = value; }
            get { return _years; }
        }
        /// <summary>
        /// �ײ�����
        /// </summary>
        public string ServiceType
        {
            set { _servicetype = value; }
            get { return _servicetype; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int Price
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}

