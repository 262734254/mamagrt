using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.advertise
{
    [Serializable]
    public class AdvisitInfo
    {
        #region Model
        private int _visitid;
        private int _advertiserid;
        private string _loginid;
        private DateTime _vdate;
        /// <summary>
        /// 
        /// </summary>
        public int visitID
        {
            set { _visitid = value; }
            get { return _visitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int advertiserID
        {
            set { _advertiserid = value; }
            get { return _advertiserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime VDate
        {
            set { _vdate = value; }
            get { return _vdate; }
        }
        #endregion Model
    }
}
