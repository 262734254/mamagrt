using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.InfoStatic
{
    /// <summary>
    ///  µÃÂ¿‡SetInfoPageStaticTab 
    /// </summary>
    public class SetInfoPageStaticTab
    {
        public SetInfoPageStaticTab()
        { }
        #region Model
        private int _id;
        private DateTime _lastupdatetime;
        private int _minupdatetime;
        private bool _isactive;
        private string _runtime;
        private DateTime _starttime;
        private DateTime _endtime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastUpdateTime
        {
            set { _lastupdatetime = value; }
            get { return _lastupdatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MinUpdateTime
        {
            set { _minupdatetime = value; }
            get { return _minupdatetime; }
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
        public string RunTime
        {
            set { _runtime = value; }
            get { return _runtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        #endregion Model
    }
}
