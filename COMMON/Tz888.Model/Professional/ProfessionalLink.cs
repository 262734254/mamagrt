using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalLink:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class ProfessionalLink
	{
		public ProfessionalLink()
		{}
		#region Model
		private int _lid;
		private int _professionalid;
		private string _username;
		private string _companyname;
		private string _address;
		private string _tel;
		private string _phone;
		private string _fax;
		private string _email;
		private string _site;
		/// <summary>
        /// ����
		/// </summary>
		public int Lid
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
        ///  �����ProfessionalinfoTab��
		/// </summary>
		public int ProfessionalID
		{
			set{ _professionalid=value;}
			get{return _professionalid;}
		}
		/// <summary>
        /// ������
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
        /// ��λ����
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
        /// ��    ַ
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
        /// ��ϵ�绰
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
        /// �ֻ�
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
        /// �������
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
        /// ��������
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
        /// ��ַ
		/// </summary>
		public string Site
		{
			set{ _site=value;}
			get{return _site;}
		}
		#endregion Model

	}
}

