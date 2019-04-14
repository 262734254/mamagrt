using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class LoansInfoTab
    {
       	/// <summary>
		/// 
		/// </summary>
        private int _loansInfoID;
        //[DataField("LoansInfoID")]
        public int LoansInfoID
        {
            get { return _loansInfoID; }
            set { _loansInfoID = value; }
        }
        


        private string _loginName;
        //[DataField("LoginName")]
      	/// <summary>
		/// 
		/// </summary>
        public string LoginName
        {
            get { return _loginName; }
            set { _loginName = value; }
        }
        
        private string _loansTitle;
        //[DataField("LoansTitle")]
      	/// <summary>
		/// 
		/// </summary>
        public string LoansTitle
        {
            get { return _loansTitle; }
            set { _loansTitle = value; }
        }
        
        private int _borrowingType;
        //[DataField("BorrowingType")]
      	/// <summary>
		/// 
		/// </summary>
        public int BorrowingType
        {
            get { return _borrowingType; }
            set { _borrowingType = value; }
        }
        
        private int _auditID;
        //[DataField("auditID")]
      	/// <summary>
		/// 
		/// </summary>
        public int AuditID
        {
            get { return _auditID; }
            set { _auditID = value; }
        }
        
        private int _chargeID;
        //[DataField("chargeID")]
      	/// <summary>
		/// 
		/// </summary>
        public int ChargeID
        {
            get { return _chargeID; }
            set { _chargeID = value; }
        }
        
        private int _recommendID;
        //[DataField("recommendID")]
      	/// <summary>
		/// 
		/// </summary>
        public int RecommendID
        {
            get { return _recommendID; }
            set { _recommendID = value; }
        }
        
        private string _url;
        //[DataField("url")]
      	/// <summary>
		/// 
		/// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        
        private string _loansdate;
        //[DataField("loansdate")]
      	/// <summary>
		/// 
		/// </summary>
        public string Loansdate
        {
            get { return _loansdate; }
            set { _loansdate = value; }
        }

        private string _updatetime;
    

        public string Updatetime
        {
          get { return _updatetime; }
          set { _updatetime = value; }
        }
        private int _formid;

        public int Formid
        {
            get { return _formid; }
            set { _formid = value; }
        }
        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private string refurbishtime;

        public string Refurbishtime
        {
            get { return refurbishtime; }
            set { refurbishtime = value; }
        }
        
    }
}
