using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.advertise
{
    [Serializable]
    public class ADchannelInfo
    {
        #region Model
        private int _bid;
        private string _bname;
        private string _bdoc;
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
        public string BName
        {
            set { _bname = value; }
            get { return _bname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BDoc
        {
            set { _bdoc = value; }
            get { return _bdoc; }
        }
        #endregion Model
    }
}
