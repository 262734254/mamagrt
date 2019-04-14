using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.advertise
{
    [Serializable]
    public class ADMessageInfo
    {
        #region Model
        private int _positionid;
        private int _bid;
        private string _typename;
        private string _serialid;
        private string _size;
        private float _price;
        private DateTime? _giving;
        private string _note;
        private int _checkid;
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
        public int BID
        {
            set { _bid = value; }
            get { return _bid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SerialID
        {
            set { _serialid = value; }
            get { return _serialid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? giving
        {
            set { _giving = value; }
            get { return _giving; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int checkid
        {
            set { _checkid = value; }
            get { return _checkid; }
        }
        #endregion Model
    }
}
