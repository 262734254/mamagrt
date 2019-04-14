using System;
namespace Survey201072.Model
{
	/// <summary>
	/// ʵ����SurveyProject201072 ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SurveyProject201072
	{
		public SurveyProject201072()
		{}
		#region Model
		private int _id;
		private int _surveyid;
		private string _website;
		private string _webtype;
		private string _businessarea;
		private string _companysize;
		private decimal _incomeyear;
		private decimal _netprofit;
		private decimal _financeamount;
		private string _financetype;
		private string _memo;
        private string _loginname;

        public string Loginname
        {
            get { return _loginname; }
            set { _loginname = value; }
        }
        private string _tel;

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ������ID
		/// </summary>
		public int SurveyID
		{
			set{ _surveyid=value;}
			get{return _surveyid;}
		}
		/// <summary>
		/// ��ַ
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// ��վ����
		/// </summary>
		public string WebType
		{
			set{ _webtype=value;}
			get{return _webtype;}
		}
		/// <summary>
		/// ��Ӫ��Χ
		/// </summary>
		public string BusinessArea
		{
			set{ _businessarea=value;}
			get{return _businessarea;}
		}
		/// <summary>
		/// ��˾��ģ
		/// </summary>
		public string CompanySize
		{
			set{ _companysize=value;}
			get{return _companysize;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public decimal InComeYear
		{
			set{ _incomeyear=value;}
			get{return _incomeyear;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public decimal NetProfit
		{
			set{ _netprofit=value;}
			get{return _netprofit;}
		}
		/// <summary>
		/// ���ʽ��
		/// </summary>
		public decimal FinanceAmount
		{
			set{ _financeamount=value;}
			get{return _financeamount;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string FinanceType
		{
			set{ _financetype=value;}
			get{return _financetype;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		#endregion Model

	}
}

