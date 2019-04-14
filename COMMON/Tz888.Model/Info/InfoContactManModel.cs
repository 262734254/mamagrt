using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 信息联系人实体类
    /// </summary>
    public class InfoContactManModel
    {
        public InfoContactManModel()
        { }
        #region Model
        private long _contactmanid;
        private long _infoid;
        private string _name;
        private string _mobile;
        private string _remark;
        /// <summary>
        /// 
        /// </summary>
        public long ContactManID
        {
            set { _contactmanid = value; }
            get { return _contactmanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
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
        #endregion Model
    }
}
