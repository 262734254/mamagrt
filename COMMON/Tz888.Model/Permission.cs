using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    class Permission
    {
    }

    /// <summary>
    /// 实体类MemberMenuTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class MemberMenuTab
    {
        public MemberMenuTab()
        { }
        #region Model
        private string _membermenucode;
        private string _name;
        private bool _ismenu;
        private string _parentcode;
        private string _url;
        private string _cssclass;
        private bool _isactive;
        private int _sequence;
        private string _remark;
        private string _updateby;
        private DateTime _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public string MemberMenuCode
        {
            set { _membermenucode = value; }
            get { return _membermenucode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsMenu
        {
            set { _ismenu = value; }
            get { return _ismenu; }
        }
        /// <summary>
        /// 默认为一级，'top'
        /// </summary>
        public string ParentCode
        {
            set { _parentcode = value; }
            get { return _parentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CssClass
        {
            set { _cssclass = value; }
            get { return _cssclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive
        {
            set { _isactive = value; }
            get { return _isactive; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sequence
        {
            set { _sequence = value; }
            get { return _sequence; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UpdateBy
        {
            set { _updateby = value; }
            get { return _updateby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model
    }
}
