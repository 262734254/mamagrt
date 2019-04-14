using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalinfoTab:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProfessionalinfoTab
	{
		public ProfessionalinfoTab()
		{}
		#region Model
		private int _professionalid;
       
		private string _titel;
		private string _loginname;
		private int _typeid;
		private int _auditid;
		private int _stateid;
		private int _chargeid;
		private string _htmlurl;
		private DateTime _creatgedate;
		private int _fromid;
		private int  _clickid;
		private int _recommendid;
		private decimal  _price;
		private DateTime  _refreshtime;
		/// <summary>
        /// ����
		/// </summary>
		public int ProfessionalID
		{
			set{ _professionalid=value;}
			get{return _professionalid;}
		}
		/// <summary>
        /// ����
		/// </summary>
		public string Titel
		{
			set{ _titel=value;}
			get{return _titel;}
		}
		/// <summary>
        /// �ʺ�����
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// ���� 1 ��Ҫ����2�ṩרҵ
		/// </summary>
		public int typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// ��� 0δ  1 �Ѿ�2δͨ��
		/// </summary>
		public int auditId
		{
			set{ _auditid=value;}
			get{return _auditid;}
		}
		/// <summary>
        /// 0��Ч 1��Ч 2�ѹ���
		/// </summary>
		public int stateId
		{
			set{ _stateid=value;}
			get{return _stateid;}
		}
		/// <summary>
		/// �Ƿ��շ� 0 ��� 1�շ�
		/// </summary>
		public int chargeId
		{
			set{ _chargeid=value;}
			get{return _chargeid;}
		}
		/// <summary>
		/// ��̬ҳ���ַ
		/// </summary>
		public string htmlUrl
		{
			set{ _htmlurl=value;}
			get{return _htmlurl;}
		}
		/// <summary>
        /// ��������
		/// </summary>
		public DateTime  creatgeDate
		{
			set{ _creatgedate=value;}
			get{return _creatgedate;}
		}
		/// <summary>
		/// ��Դ 1 ��Ա����  2 ҵ��Ա 3 
		/// </summary>
		public int  FromId
		{
			set{ _fromid=value;}
			get{return _fromid;}
		}
		/// <summary>
        /// �����
		/// </summary>
		public int  clickId
		{
			set{ _clickid=value;}
			get{return _clickid;}
		}
		/// <summary>
        /// �Ƿ��Ƽ� 0 ���Ƽ� 1 �Ƽ� 
		/// </summary>
		public int recommendId
		{
			set{ _recommendid=value;}
			get{return _recommendid;}
		}
		/// <summary>
        /// �۸�
		/// </summary>
		public decimal  price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
        /// ˢ��ʱ��
		/// </summary>
		public DateTime  refreshTime
		{
			set{ _refreshtime=value;}
			get{return _refreshtime;}
		}
		#endregion Model

	}
}

