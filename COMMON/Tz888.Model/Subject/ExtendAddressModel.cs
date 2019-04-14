using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Subject
{
    /// <summary>
    /// 推广位置表
    /// </summary>
    public class ExtendAddressModel
    {
        #region Model
        private int _extendid;
        private int? _subid;
        private string _extendaddress;
        private string _extendurl;
        /// <summary>
        /// 主键
        /// </summary>
        public int ExtendID
        {
            set { _extendid = value; }
            get { return _extendid; }
        }
        /// <summary>
        /// 外键
        /// </summary>
        public int? SubID
        {
            set { _subid = value; }
            get { return _subid; }
        }
        /// <summary>
        /// 推广地址
        /// </summary>
        public string ExtendAddress
        {
            set { _extendaddress = value; }
            get { return _extendaddress; }
        }
        /// <summary>
        /// 所对应的路径
        /// </summary>
        public string ExtendUrl
        {
            set { _extendurl = value; }
            get { return _extendurl; }
        }
        #endregion Model
    }
}
