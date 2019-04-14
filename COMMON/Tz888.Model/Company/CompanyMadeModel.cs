using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class CompanyMadeModel
    {
        #region Model
        private int _madeid;
        private string _companyid;
        private string _price;
        private string _sumprice;
        private string _username;
        private DateTime? _createdate;
        private DateTime? _begintime;
        private DateTime? _endtime;
        private string _linkname;
        private string _telphone;
        private string _email;
        private int? _audit;
        private string _auditname;
        private int? _hit;
        private int? _visitHit;

        /// <summary>
        /// 编号
        /// </summary>
        public int MadeID
        {
            set { _madeid = value; }
            get { return _madeid; }
        }
        /// <summary>
        /// 广告编号
        /// </summary>
        public string CompanyID
        {
            set { _companyid = value; }
            get { return _companyid; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public string Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 总价格
        /// </summary>
        public string SumPrice
        {
            set { _sumprice = value; }
            get { return _sumprice; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkName
        {
            set { _linkname = value; }
            get { return _linkname; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelPhone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int? Audit
        {
            set { _audit = value; }
            get { return _audit; }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AuditName
        {
            set { _auditname = value; }
            get { return _auditname; }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        public int? Hit
        {
            get { return _hit; }
            set { _hit = value; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int? VisitHit
        {
            get { return _visitHit; }
            set { _visitHit = value; }
        }

        #endregion Model
    }
}
