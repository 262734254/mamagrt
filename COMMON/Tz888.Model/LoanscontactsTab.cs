//============================================================
// Producnt name:		ExamSystem
// Version: 			1.0
// Coded by:			Eagle Lifeng
// Auto generated at: 	2011-3-7 9:12:20
//============================================================

using System;

namespace Tz888.Model
{
    [Serializable]
    public class LoanscontactsTab
    {
       	/// <summary>
		/// 
		/// </summary>
        private int _contactsID;
        //[DataField("contactsID")]
        public int ContactsID
        {
            get { return _contactsID; }
            set { _contactsID = value; }
        }
       

        private LoansInfoTab _loansInfoID;

        public LoansInfoTab LoansInfoID
        {
            get { return _loansInfoID; }
            set { _loansInfoID = value; }
        }
        //[DataField("loansInfoID")]
      	/// <summary>
		/// 
		/// </summary>

        
        private string _enterpriseName;
        //[DataField("enterpriseName")]
      	/// <summary>
		/// 
		/// </summary>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }
        
        private string _contactsName;
        //[DataField("contactsName")]
      	/// <summary>
		/// 
		/// </summary>
        public string ContactsName
        {
            get { return _contactsName; }
            set { _contactsName = value; }
        }
        
        private string _telephone;
        //[DataField("telephone")]
      	/// <summary>
		/// 
		/// </summary>
        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }
        
        private string _moblie;
        //[DataField("Moblie")]
      	/// <summary>
		/// 
		/// </summary>
        public string Moblie
        {
            get { return _moblie; }
            set { _moblie = value; }
        }
        private string _mail;

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        
        private string _address;
        //[DataField("Address")]
      	/// <summary>
		/// 
		/// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _loginname;

        public string Loginname
        {
            get { return _loginname; }
            set { _loginname = value; }
        }
        
    }
}
