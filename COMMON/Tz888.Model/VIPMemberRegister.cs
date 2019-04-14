using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    /// <summary>
    /// 拓富通会员实体类VipApplyTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class VIPMemberRegister
    {
        public VIPMemberRegister()
		{}
		#region Model
		private int _applyid;
		private string _loginname;
		private int _infomanagetype;
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
		private string _oprman;
		private DateTime _oprdate;
		private string _memo;
		/// <summary>
		/// 
		/// </summary>
		public int ApplyID
		{
		set{ _applyid=value;}
		get{return _applyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginName
		{
		set{ _loginname=value;}
		get{return _loginname;}
		}
		/// <summary>
		/// 0 个人会员 1 企业会员 3 政府会员
		/// </summary>
		public int InfoManageType
		{
		set{ _infomanagetype=value;}
		get{return _infomanagetype;}
		}
		/// <summary>
		/// 1 3个月 2 半年 3 1年
		/// </summary>
		public int BuyTerm
		{
		set{ _buyterm=value;}
		get{return _buyterm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrgName
		{
		set{ _orgname=value;}
		get{return _orgname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RealName
		{
		set{ _realname=value;}
		get{return _realname;}
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
		/// 0 male 1 female
		/// </summary>
		public bool Sex
		{
		set{ _sex=value;}
		get{return _sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelCountryCode
		{
		set{ _telcountrycode=value;}
		get{return _telcountrycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelStateCode
		{
		set{ _telstatecode=value;}
		get{return _telstatecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TelNum
		{
		set{ _telnum=value;}
		get{return _telnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
		set{ _mobile=value;}
		get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
		set{ _email=value;}
		get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ApplyDate
		{
		set{ _applydate=value;}
		get{return _applydate;}
		}
        /// <summary>
        /// 是否付费
        /// </summary>
        public int IsPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
		/// <summary>
		/// 0  提交申请表 1 已签订协议 2 已付款 3 通过身份认证  4 已开通拓富通服务
		/// </summary>
		public int OprStatus
		{
		set{ _oprstatus=value;}
		get{return _oprstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OprDescript
		{
		set{ _oprdescript=value;}
		get{return _oprdescript;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OprMan
		{
		set{ _oprman=value;}
		get{return _oprman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime OprDate
		{
		set{ _oprdate=value;}
		get{return _oprdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Memo
		{
		set{ _memo=value;}
		get{return _memo;}
		}
		#endregion Model

	}
}

