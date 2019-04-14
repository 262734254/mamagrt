using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Orders
{
    [Serializable]
    public class IndustryReport
    {
        public IndustryReport()
        { }
        #region Model
        private int _industryid;
        private string _reportPrice;
        private string _orderNo;
        private string _company;
        private string _address;
        private bool _sex;
        private string _fax;
        private string _position;
        private string _note;
        private string linkName;
        private int _reportID;
        public string reportPrice
        {
            set { _reportPrice = value; }
            get { return _reportPrice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkName
        {
            set { linkName = value; }
            get { return linkName; }
        }
        public int reportID
        {
            set { _reportID = value; }
            get { return _reportID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int industryId
        {
            set { _industryid = value; }
            get { return _industryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string orderNo
        {
            set { _orderNo = value; }
            get { return _orderNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Note
        {
            set { _note = value; }
            get { return _note; }
        }
        #endregion Model
    }
}
