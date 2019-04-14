using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class Notice
    {
        public Notice()
        { }
        #region model
        private int _id;
        private string _title;
        private string _details;
        private DateTime _createdate;

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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Details
        {
            set { _details = value; }
            get { return _details; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion
    }
}
