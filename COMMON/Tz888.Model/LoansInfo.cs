//============================================================
// Producnt name:		ExamSystem
// Version: 			1.0
// Coded by:			Eagle Lifeng
// Auto generated at: 	2011-3-7 9:12:56
//============================================================

using System;

namespace Tz888.Model
{
    [Serializable]
    public class LoansInfo
    {
       	/// <summary>
		/// 
		/// </summary>
        private int _loanID;
        //[DataField("LoanID")]
        public int LoanID
        {
            get { return _loanID; }
            set { _loanID = value; }
        }
        


        private LoansInfoTab _loansInfoID;

        public LoansInfoTab LoansInfoID
        {
            get { return _loansInfoID; }
            set { _loansInfoID = value; }
        }
        //[DataField("LoansInfoID")]
      	/// <summary>
		/// 
		/// </summary>

        
        private int _validityID;
        //[DataField("ValidityID")]
      	/// <summary>
		/// 
		/// </summary>
        public int ValidityID
        {
            get { return _validityID; }
            set { _validityID = value; }
        }
        
        private string _countryID;
        //[DataField("CountryID")]
      	/// <summary>
		/// 
		/// </summary>
        public string CountryID
        {
            get { return _countryID; }
            set { _countryID = value; }
        }
        
        private string _provinceID;
        //[DataField("ProvinceID")]
      	/// <summary>
		/// 
		/// </summary>
        public string ProvinceID
        {
            get { return _provinceID; }
            set { _provinceID = value; }
        }
        
        private string _cityID;
        //[DataField("CityID")]
      	/// <summary>
		/// 
		/// </summary>
        public string CityID
        {
            get { return _cityID; }
            set { _cityID = value; }
        }
        
        private string _countyID;
        //[DataField("CountyID")]
      	/// <summary>
		/// 
		/// </summary>
        public string CountyID
        {
            get { return _countyID; }
            set { _countyID = value; }
        }
        
        private int _amount;
        //[DataField("amount")]
      	/// <summary>
		/// 
		/// </summary>
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        
        private int _deadline;
        //[DataField("deadline")]
      	/// <summary>
		/// 
		/// </summary>
        public int Deadline
        {
            get { return _deadline; }
            set { _deadline = value; }
        }
        
        private int _reimbursement;
        //[DataField("reimbursement")]
      	/// <summary>
		/// 
		/// </summary>
        public int Reimbursement
        {
            get { return _reimbursement; }
            set { _reimbursement = value; }
        }
        
        private int _guarantee;
        //[DataField("guarantee")]
      	/// <summary>
		/// 
		/// </summary>
        public int Guarantee
        {
            get { return _guarantee; }
            set { _guarantee = value; }
        }
        
        private string _borrowingUse;
        //[DataField("BorrowingUse")]
      	/// <summary>
		/// 
		/// </summary>
        public string BorrowingUse
        {
            get { return _borrowingUse; }
            set { _borrowingUse = value; }
        }
        
        private string _title;
        //[DataField("title")]
      	/// <summary>
		/// 
		/// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        private string _keywords;
        //[DataField("keywords")]
      	/// <summary>
		/// 
		/// </summary>
        public string Keywords
        {
            get { return _keywords; }
            set { _keywords = value; }
        }
        
        private string _description;
        //[DataField("description")]
      	/// <summary>
		/// 
		/// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        private string _reason;
        //[DataField("reason")]
      	/// <summary>
		/// 
		/// </summary>
        public string Reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        
    }
}
