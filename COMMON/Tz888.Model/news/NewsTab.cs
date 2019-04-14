//============================================================
// Producnt name:		ExamSystem
// Version: 			1.0
// Coded by:			Eagle Lifeng
// Auto generated at: 	2011-3-17 14:16:36
//============================================================

using System;

namespace Tz888.Model
{
    [Serializable]
    public class NewsTab
    {
       	/// <summary>
		/// 
		/// </summary>
        private int _newsid;
        //[DataField("Newsid")]
        public int Newsid
        {
            get { return _newsid; }
            set { _newsid = value; }
        }
        


        private string _userName;
        //[DataField("UserName")]
      	/// <summary>
		/// 
		/// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        
        private string _nTitle;
        //[DataField("NTitle")]
      	/// <summary>
		/// 
		/// </summary>
        public string NTitle
        {
            get { return _nTitle; }
            set { _nTitle = value; }
        }
        
        private int _typeID;
        //[DataField("TypeID")]
      	/// <summary>
		/// 
		/// </summary>
        public int TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }
        
        private int _audit;
        //[DataField("audit")]
      	/// <summary>
		/// 
		/// </summary>
        public int Audit
        {
            get { return _audit; }
            set { _audit = value; }
        }
        
        private int _fromID;
        //[DataField("FromID")]
      	/// <summary>
		/// 
		/// </summary>
        public int FromID
        {
            get { return _fromID; }
            set { _fromID = value; }
        }
        
        private string _urlhtml;
        //[DataField("urlhtml")]
      	/// <summary>
		/// 
		/// </summary>
        public string Urlhtml
        {
            get { return _urlhtml; }
            set { _urlhtml = value; }
        }
        
        private string  _createdate;
        //[DataField("createdate")]
      	/// <summary>
		/// 
		/// </summary>
        public string Createdate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        private int _recommendID;

        public int RecommendID
        {
            get { return _recommendID; }
            set { _recommendID = value; }
        }
        
    }
}
