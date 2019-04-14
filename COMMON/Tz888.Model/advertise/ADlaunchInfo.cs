using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.advertise
{
    [Serializable]
    public class ADlaunchInfo
    {
        #region Model
        private int _advertiserid;
        private int _bid;
        private int _positionid;
        private DateTime _stardate;
        private DateTime _enddate;
        private DateTime _givindate;
        private string _addoc;
        private DateTime _addates;
        private string _salesman;
        private string _loginname;
        private int? _countid;
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
        public int BID
        {
            set { _bid = value; }
            get { return _bid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int positionID
        {
            set { _positionid = value; }
            get { return _positionid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Stardate
        {
            set { _stardate = value; }
            get { return _stardate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime enddate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Givindate
        {
            set { _givindate = value; }
            get { return _givindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string addoc
        {
            set { _addoc = value; }
            get { return _addoc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Addates
        {
            set { _addates = value; }
            get { return _addates; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string salesman
        {
            set { _salesman = value; }
            get { return _salesman; }
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
        public int? countID
        {
            set { _countid = value; }
            get { return _countid; }
        }
        #endregion Model
    }
}
