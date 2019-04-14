using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalLink:实体类(属性说明自动提取数据库字段的描述信息)
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
        /// 主键
		/// </summary>
		public int Lid
		{
			set{ _lid=value;}
			get{return _lid;}
		}
		/// <summary>
        ///  外键（ProfessionalinfoTab）
		/// </summary>
		public int ProfessionalID
		{
			set{ _professionalid=value;}
			get{return _professionalid;}
		}
		/// <summary>
        /// 申请人
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
        /// 单位名称
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
        /// 地    址
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
        /// 联系电话
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
        /// 手机
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
        /// 传真号码
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
        /// 电子邮箱
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
        /// 网址
		/// </summary>
		public string Site
		{
			set{ _site=value;}
			get{return _site;}
		}
		#endregion Model

	}
}

