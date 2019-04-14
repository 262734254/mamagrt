using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class CustomInfoModel
    {
        public CustomInfoModel()
        { }

        #region Model
        private int _id;
        private string _title;
        private string _loginname;
        private bool _accept;
        private string _email;
        private int _customcyc;
        private int _customtype;
        private string _type;
        private string _genre;
        private string _currency;
        private string _money;
        private string _calling;
        private string _callingtxt;
        private string _smallcalling;
        private string _smallcallingtxt;
        private string _city;
        private string _citytxt;
        private string _keyword;
        private int _validateterm;
        private int _itemcount;
        private string _cooperationdemandtypeid;
        //---------------------2010-06新增属性------------------------
        private string _stageForenterpriseDevelop;
        private string _financingObject;
        private string _trade;


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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Accept
        {
            set { _accept = value; }
            get { return _accept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CustomCyc
        {
            set { _customcyc = value; }
            get { return _customcyc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CustomType
        {
            set { _customtype = value; }
            get { return _customtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Genre
        {
            set { _genre = value; }
            get { return _genre; }
        }
        /// <summary>
        /// 币种
        /// </summary>
        public string currency
        {
            set { _currency = value; }
            get { return _currency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Calling
        {
            set { _calling = value; }
            get { return _calling; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CallingTxt
        {
            set { _callingtxt = value; }
            get { return _callingtxt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmallCalling
        {
            set { _smallcalling = value; }
            get { return _smallcalling; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmallCallingTxt
        {
            set { _smallcallingtxt = value; }
            get { return _smallcallingtxt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityTxt
        {
            set { _citytxt = value; }
            get { return _citytxt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Keyword
        {
            set { _keyword = value; }
            get { return _keyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ValidateTerm
        {
            set { _validateterm = value; }
            get { return _validateterm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ItemCount
        {
            set { _itemcount = value; }
            get { return _itemcount; }
        }
        /// <summary>
        /// 合作方式
        /// </summary>
        public string CooperationDemandTypeID
        {
            set { _cooperationdemandtypeid = value; }
            get { return _cooperationdemandtypeid; }
        }
        #endregion Model

        //---------2010-06新增属性----------
        public string Trade
        {
            get { return _trade; }
            set { _trade = value; }
        }
        public string FinancingObject
        {
            get { return _financingObject; }
            set { _financingObject = value; }
        }
        public string StageForenterpriseDevelop
        {
            get { return _stageForenterpriseDevelop; }
            set { _stageForenterpriseDevelop = value; }
        }
    }
}
