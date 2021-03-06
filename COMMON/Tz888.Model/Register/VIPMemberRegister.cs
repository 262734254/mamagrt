using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
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
        private string _managetypeid;
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
        private string _marketpersonname;
        private string _oprman;
        private DateTime _oprdate;
        private DateTime _vipvalidatedate;
        private string _memo;
        private int _money;
        private int _years;
        private string _servicetype;
        private int _price;
        /// <summary>
        /// ApplyID
        /// </summary>
        public int ApplyID
        {
            set { _applyid = value; }
            get { return _applyid; }
        }
        /// <summary>
        /// 会员登录名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 0 个人会员 1 企业会员 3 政府会员
        /// </summary>
        public string ManageTypeID
        {
            set { _managetypeid = value; }
            get { return _managetypeid; }
        }
        /// <summary>
        /// 1 3个月 2 半年 3 1年
        /// </summary>
        public int BuyTerm
        {
            set { _buyterm = value; }
            get { return _buyterm; }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string OrgName
        {
            set { _orgname = value; }
            get { return _orgname; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 职    务
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 0 male 1 female
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 电话国家码
        /// </summary>
        public string TelCountryCode
        {
            set { _telcountrycode = value; }
            get { return _telcountrycode; }
        }
        /// <summary>
        /// 电话区域码
        /// </summary>
        public string TelStateCode
        {
            set { _telstatecode = value; }
            get { return _telstatecode; }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string TelNum
        {
            set { _telnum = value; }
            get { return _telnum; }
        }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime ApplyDate
        {
            set { _applydate = value; }
            get { return _applydate; }
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
            set { _oprstatus = value; }
            get { return _oprstatus; }
        }
        /// <summary>
        /// 处理描述
        /// </summary>
        public string OprDescript
        {
            set { _oprdescript = value; }
            get { return _oprdescript; }
        }
        /// <summary>
        /// 鄴務園
        /// </summary>
        public string MarketPersonName
        {
            set { _marketpersonname = value; }
            get { return _marketpersonname; }
        }
        /// <summary>
        /// 处理人
        /// </summary>
        public string OprMan
        {
            set { _oprman = value; }
            get { return _oprman; }
        }
        /// <summary>
        /// 处理日期
        /// </summary>
        public DateTime OprDate
        {
            set { _oprdate = value; }
            get { return _oprdate; }
        }
        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime VIPValidateDate
        {
            set { _vipvalidatedate = value; }
            get { return _vipvalidatedate; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            set { _memo = value; }
            get { return _memo; }
        }
        /// <summary>
        /// 付款金额
        /// </summary>
        public int Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 服务年数
        /// </summary>
        public int Years
        {
            set { _years = value; }
            get { return _years; }
        }
        /// <summary>
        /// 套餐类型
        /// </summary>
        public string ServiceType
        {
            set { _servicetype = value; }
            get { return _servicetype; }
        }
        /// <summary>
        /// 付款金额
        /// </summary>
        public int Price
        {
            set { _price = value; }
            get { return _price; }
        }
        #endregion Model

    }
}

