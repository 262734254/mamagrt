//============================================================
// Producnt name:		ExamSystem
// Version: 			1.0
// Coded by:			Eagle Lifeng
// Auto generated at: 	2011-3-17 14:17:05
//============================================================

using System;

namespace Tz888.Model
{
    [Serializable]
    public class NewsViewTab
    {
       	/// <summary>
		/// 
		/// </summary>
        private int _nViewID;
        //[DataField("NViewID")]
        public int NViewID
        {
            get { return _nViewID; }
            set { _nViewID = value; }
        }
        
       	/// <summary>
		/// 
		/// </summary>
        private NewsTab _newsid;

        public NewsTab Newsid
        {
            get { return _newsid; }
            set { _newsid = value; }
        }
        //[DataField("Newsid")]

        

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
        public string  Description
        {
            get { return _description; }
            set { _description = value; }
        }
        
        private string  _newView;
        //[DataField("NewView")]
      	/// <summary>
		/// 
		/// </summary>
        public string NewView
        {
            get { return _newView; }
            set { _newView = value; }
        }
        private string _formid;

        public string Formid
        {
            get { return _formid; }
            set { _formid = value; }
        }
        private string _author;

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }
        private string _zhaiyao;

        public string Zhaiyao
        {
            get { return _zhaiyao; }
            set { _zhaiyao = value; }
        }
        
    }
}
