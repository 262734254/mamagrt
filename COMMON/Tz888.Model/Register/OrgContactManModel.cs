using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    /// <summary>
    /// 实体类OrgContactMan 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class OrgContactMan
    {
        public OrgContactMan()
        { }
        #region Model
        private int _contactmanid;
        private string _loginname;
        private string _name;
        private string _mobile;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public int ContactManID
        {
            set { _contactmanid = value; }
            get { return _contactmanid; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
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
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        public OrgContactMan(string name, string mobile)
        {
           this._name = name;
           this._mobile = mobile;
        }
        #endregion Model

    }
}

