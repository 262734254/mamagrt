using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalinfoTab:实体类(属性说明自动提取数据库字段的描述信息)
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
        /// 主键
		/// </summary>
		public int ProfessionalID
		{
			set{ _professionalid=value;}
			get{return _professionalid;}
		}
		/// <summary>
        /// 标题
		/// </summary>
		public string Titel
		{
			set{ _titel=value;}
			get{return _titel;}
		}
		/// <summary>
        /// 帐号名称
		/// </summary>
		public string LoginName
		{
			set{ _loginname=value;}
			get{return _loginname;}
		}
		/// <summary>
		/// 类型 1 需要服务2提供专业
		/// </summary>
		public int typeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 审核 0未  1 已经2未通过
		/// </summary>
		public int auditId
		{
			set{ _auditid=value;}
			get{return _auditid;}
		}
		/// <summary>
        /// 0无效 1有效 2已过期
		/// </summary>
		public int stateId
		{
			set{ _stateid=value;}
			get{return _stateid;}
		}
		/// <summary>
		/// 是否收费 0 免费 1收费
		/// </summary>
		public int chargeId
		{
			set{ _chargeid=value;}
			get{return _chargeid;}
		}
		/// <summary>
		/// 静态页面地址
		/// </summary>
		public string htmlUrl
		{
			set{ _htmlurl=value;}
			get{return _htmlurl;}
		}
		/// <summary>
        /// 创建日期
		/// </summary>
		public DateTime  creatgeDate
		{
			set{ _creatgedate=value;}
			get{return _creatgedate;}
		}
		/// <summary>
		/// 来源 1 会员中心  2 业务员 3 
		/// </summary>
		public int  FromId
		{
			set{ _fromid=value;}
			get{return _fromid;}
		}
		/// <summary>
        /// 点击量
		/// </summary>
		public int  clickId
		{
			set{ _clickid=value;}
			get{return _clickid;}
		}
		/// <summary>
        /// 是否推荐 0 不推荐 1 推荐 
		/// </summary>
		public int recommendId
		{
			set{ _recommendid=value;}
			get{return _recommendid;}
		}
		/// <summary>
        /// 价格
		/// </summary>
		public decimal  price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
        /// 刷新时间
		/// </summary>
		public DateTime  refreshTime
		{
			set{ _refreshtime=value;}
			get{return _refreshtime;}
		}
		#endregion Model

	}
}

