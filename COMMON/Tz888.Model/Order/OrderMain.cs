using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Orders
{
    [Serializable]
    public class OrderMain
    {
        public OrderMain()
        { }
        #region Model
        private int _orderid;
        private string _orderNo;
        private int _typeid;
        private int _state;
        private DateTime  _orderdate;
        private decimal  _amount;
        private int  _paysate;
        private string _payment;
        private int _num;
        public int num
        {
            set { _num = value; }
            get { return _num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int orderId
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        public string orderNo 
        {
            set { _orderNo = value; }
            get { return _orderNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int typeId
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime  orderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int  paySate
        {
            set { _paysate = value; }
            get { return _paysate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string payMent
        {
            set { _payment = value; }
            get { return _payment; }
        }
        #endregion Model
    }
}
