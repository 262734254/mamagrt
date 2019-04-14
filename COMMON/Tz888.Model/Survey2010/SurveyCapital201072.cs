using System;
namespace Survey201072.Model
{
	/// <summary>
	/// ʵ����SurveyCapital201072 ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ������ID
		/// </summary>
		public int SurveyID
		{
			set{ _surveyid=value;}
			get{return _surveyid;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string OrgName
		{
			set{ _orgname=value;}
			get{return _orgname;}
		}
		/// <summary>
		/// �ʱ�����
		/// </summary>
		public string CaptialType
		{
			set{ _captialtype=value;}
			get{return _captialtype;}
		}
		/// <summary>
		/// Ͷ�ʷ���
		/// </summary>
		public string InvestDirect
		{
			set{ _investdirect=value;}
			get{return _investdirect;}
		}
		/// <summary>
		/// Ͷ�ʽ׶�
		/// </summary>
		public string InvestStage
		{
			set{ _investstage=value;}
			get{return _investstage;}
		}
		/// <summary>
		/// Ͷ�ʽ��
		/// </summary>
		public decimal InvestAmount
		{
			set{ _investamount=value;}
			get{return _investamount;}
		}
		/// <summary>
		/// Ͷ������
		/// </summary>
		public string InvestType
		{
			set{ _investtype=value;}
			get{return _investtype;}
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

