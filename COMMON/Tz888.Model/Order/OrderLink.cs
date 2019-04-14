using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Orders
{
    [Serializable]
    public class OrderLink
    {
        #region Model
        private int _linkid;
        private string _orderno;
        private string _loginname;
        private string _phone;
        private string _tel;
        private string _email;
        /// <summary>
        /// 
        /// </summary>
        public int linkId
        {
            set { _linkid = value; }
            get { return _linkid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string orderNo
        {
            set { _orderno = value; }
            get { return _orderno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string loginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        #endregion Model
    }
}
