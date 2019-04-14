using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类StrikeCardTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Card
    {
        public Card()
        { }
        #region Model
        private int _id;
        private long _cardno;
        private string _password;
        private decimal _pointcount;
        private int _ispublish;
        private int _isstriked;
        private int _isgift;
        private int _isvirtual;
        private string _changeby;
        private DateTime _changetime;
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
        public long CardNo
        {
            set { _cardno = value; }
            get { return _cardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal PointCount
        {
            set { _pointcount = value; }
            get { return _pointcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsPublish
        {
            set { _ispublish = value; }
            get { return _ispublish; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsStriked
        {
            set { _isstriked = value; }
            get { return _isstriked; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsGift
        {
            set { _isgift = value; }
            get { return _isgift; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsVirtual
        {
            set { _isvirtual = value; }
            get { return _isvirtual; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChangeBy
        {
            set { _changeby = value; }
            get { return _changeby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ChangeTime
        {
            set { _changetime = value; }
            get { return _changetime; }
        }
        #endregion Model

    }
}

