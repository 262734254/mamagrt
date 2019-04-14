using System;
namespace Survey201072.Model
{
	/// <summary>
	/// ʵ����SurveyMainInfo201072 ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class SurveyMainInfo201072
	{
		public SurveyMainInfo201072()
		{}
		#region Model
		private int _surveyid;
		private string _loginname;
		private string _companyname;
		private DateTime _founddate;
		private decimal _regcapital;
		private string _companyaddr;
		private string _personalusername;
		private string _sex;
		private string _position;
		private string _telephone;
		private string _emal;
		private string _memo;
		private string _opip;
		private DateTime _adddate;
		private string _isdeal;
		private string _ischeck;
		private string _isdel;
		private string _opuser;
		private DateTime _modifydate;
		/// <summary>
		/// 
		/// </summary>
		public int SurveyID
		{
			set{ _surveyid=value;}
			get{return _surveyid;}
		}
		/// <summary>
		/// ��Ա��
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// ��˾��
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime FoundDate
		{
			set{ _founddate=value;}
			get{return _founddate;}
		}
		/// <summary>
		/// ע���ʽ�
		/// </summary>
		public decimal Regcapital
		{
			set{ _regcapital=value;}
			get{return _regcapital;}
		}
		/// <summary>
		/// ��˾��ַ
		/// </summary>
		public string CompanyAddr
		{
			set{ _companyaddr=value;}
			get{return _companyaddr;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string PersonalUsername
		{
			set{ _personalusername=value;}
			get{return _personalusername;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Position
		{
			set{ _position=value;}
			get{return _position;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Emal
		{
			set{ _emal=value;}
			get{return _emal;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string Memo
		{
			set{ _memo=value;}
			get{return _memo;}
		}
		/// <summary>
		/// IP
		/// </summary>
		public string OPIP
		{
			set{ _opip=value;}
			get{return _opip;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public DateTime AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// �Ƿ����
		/// </summary>
		public string IsDeal
		{
			set{ _isdeal=value;}
			get{return _isdeal;}
		}
		/// <summary>
		/// �Ƿ����
		/// </summary>
		public string IsCheck
		{
			set{ _ischeck=value;}
			get{return _ischeck;}
		}
		/// <summary>
		/// �Ƿ�ɾ��
		/// </summary>
		public string IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// ������
		/// </summary>
		public string OPUser
		{
			set{ _opuser=value;}
			get{return _opuser;}
		}
		/// <summary>
		/// �޸�ʱ��
		/// </summary>
		public DateTime ModifyDate
		{
			set{ _modifydate=value;}
			get{return _modifydate;}
		}
		#endregion Model

	}
}

