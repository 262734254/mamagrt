using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 资源信息短信息实体类
    /// </summary>
    public class ShortInfoModel
    {
        public ShortInfoModel()
        { }
        #region Model
        private long _id;
        private long _infoid;
        private string _infotype;
        private string _shortinfocontrolid;
        private string _shorttitle;
        private string _shortcontent;
        private string _remark;
        private string _changeby;
        private DateTime _changetime;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
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
        public string InfoType
        {
            set { _infotype = value; }
            get { return _infotype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortInfoControlID
        {
            set { _shortinfocontrolid = value; }
            get { return _shortinfocontrolid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortTitle
        {
            set { _shorttitle = value; }
            get { return _shorttitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShortContent
        {
            set { _shortcontent = value; }
            get { return _shortcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChangeBy
        {
            set { _changeby = value; }
            get { return _changeby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ChangeTime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }
        #endregion Model
    }
}
