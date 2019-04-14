using System;
namespace Survey201072.Model
{
	/// <summary>
	/// 实体类SurveyProject201072 。(属性说明自动提取数据库字段的描述信息)
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
		/// 调查主ID
		/// </summary>
		public int SurveyID
		{
			set{ _surveyid=value;}
			get{return _surveyid;}
		}
		/// <summary>
		/// 网址
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 网站类型
		/// </summary>
		public string WebType
		{
			set{ _webtype=value;}
			get{return _webtype;}
		}
		/// <summary>
		/// 经营范围
		/// </summary>
		public string BusinessArea
		{
			set{ _businessarea=value;}
			get{return _businessarea;}
		}
		/// <summary>
		/// 公司规模
		/// </summary>
		public string CompanySize
		{
			set{ _companysize=value;}
			get{return _companysize;}
		}
		/// <summary>
		/// 年收入
		/// </summary>
		public decimal InComeYear
		{
			set{ _incomeyear=value;}
			get{return _incomeyear;}
		}
		/// <summary>
		/// 净利润
		/// </summary>
		public decimal NetProfit
		{
			set{ _netprofit=value;}
			get{return _netprofit;}
		}
		/// <summary>
		/// 融资金额
		/// </summary>
		public decimal FinanceAmount
		{
			set{ _financeamount=value;}
			get{return _financeamount;}
		}
		/// <summary>
		/// 融资类型
		/// </summary>
		public string FinanceType
		{
			set{ _financetype=value;}
			get{return _financetype;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		#endregion Model

	}
}

