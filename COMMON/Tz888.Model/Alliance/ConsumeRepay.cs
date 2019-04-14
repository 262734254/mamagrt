using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class ConsumeRepay
    {
        #region Model Ö§¸¶ĞÅÏ¢
        private int _repayid;
        private string _username;
        private string _repayway;
        private  float _repaymoney;
        private int _repaystatus;
        private DateTime _createdate;
        private string _auditman;
        private DateTime _repaydate;
        private int _auditstatus;
        private string _auditdescript;

        /// <summary>
        /// 
        /// </summary>
        public int RepayID
        {
            set { _repayid = value; }
            get { return _repayid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RepayWay
        {
            set { _repayway = value; }
            get { return _repayway; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float RepayMoney
        {
            set { _repaymoney = value; }
            get { return _repaymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RepayStatus
        {
            set { _repaystatus = value; }
            get { return _repaystatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Createdate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditMan
        {
            set { _auditman = value; }
            get { return _auditman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RepayDate
        {
            set { _repaydate = value; }
            get { return _repaydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AuditStatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AuditDescript
        {
            set { _auditdescript = value; }
            get { return _auditdescript; }
        }
        #endregion
    }
}
