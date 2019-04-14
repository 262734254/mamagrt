using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Subject
{
    /// <summary>
    /// 专题推广
    /// </summary>
    public class SubjectExtendModel
    {
        #region Model
        private int _subid;
        private string _loginname;
        private string _subtitle;
        private string _remark;
        private int? _audit;
        private int? _source;
        private string _htmlurl;
        private int? _sort;
        private int? _subtype;
        private DateTime? _subtime;
        private string _linkman;
        private string _phone;
        private string _picture;
        /// <summary>
        /// 主键
        /// </summary>
        public int SubID
        {
            set { _subid = value; }
            get { return _subid; }
        }
        /// <summary>
        /// 帐号名称
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 专题标题
        /// </summary>
        public string SubTitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }
        /// <summary>
        /// 专题说明
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
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
        /// 来源
        /// </summary>
        public int? Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 访问地址
        /// </summary>
        public string HtmlUrl
        {
            set { _htmlurl = value; }
            get { return _htmlurl; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int? SubType
        {
            set { _subtype = value; }
            get { return _subtype; }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string Picture
        {
            set { _picture = value; }
            get { return _picture; }
        }
        #endregion Model
    }
}
