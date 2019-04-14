using System;
namespace Survey201072.Model
{
	/// <summary>
	/// 实体类SurveyCapital201072 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SurveyCapital201072
	{
		public SurveyCapital201072()
		{}
		#region Model
		private int _id;
		private int _surveyid;
		private string _orgname;
		private string _captialtype;
		private string _investdirect;
		private string _investstage;
		private decimal _investamount;
		private string _investtype;
		private string _memo;
        private string _loginanme;

        public string Loginanme
        {
            get { return _loginanme; }
            set { _loginanme = value; }
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
		/// 机构名
		/// </summary>
		public string OrgName
		{
			set{ _orgname=value;}
			get{return _orgname;}
		}
		/// <summary>
		/// 资本类型
		/// </summary>
		public string CaptialType
		{
			set{ _captialtype=value;}
			get{return _captialtype;}
		}
		/// <summary>
		/// 投资方向
		/// </summary>
		public string InvestDirect
		{
			set{ _investdirect=value;}
			get{return _investdirect;}
		}
		/// <summary>
		/// 投资阶段
		/// </summary>
		public string InvestStage
		{
			set{ _investstage=value;}
			get{return _investstage;}
		}
		/// <summary>
		/// 投资金额
		/// </summary>
		public decimal InvestAmount
		{
			set{ _investamount=value;}
			get{return _investamount;}
		}
		/// <summary>
		/// 投资类型
		/// </summary>
		public string InvestType
		{
			set{ _investtype=value;}
			get{return _investtype;}
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

