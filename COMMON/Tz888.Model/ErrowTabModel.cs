using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    /// <summary>
    /// 实体类ErrowTab 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ErrowTab
    {
        public ErrowTab()
        { }
        #region Model
        private int _id;
        private string _linkurl;
        private string _questiondescript;
        private string _connetions;
        private int? _boolchuli;
        private int? _boolreturn;
        private string _returncontext;
        private string _descript;
        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private  string _createtime;
        private string _updatetime;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkURL
        {
            set { _linkurl = value; }
            get { return _linkurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuestionDescript
        {
            set { _questiondescript = value; }
            get { return _questiondescript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Connetions
        {
            set { _connetions = value; }
            get { return _connetions; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BoolChuLi
        {
            set { _boolchuli = value; }
            get { return _boolchuli; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BoolReturn
        {
            set { _boolreturn = value; }
            get { return _boolreturn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnContext
        {
            set { _returncontext = value; }
            get { return _returncontext; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Descript
        {
            set { _descript = value; }
            get { return _descript; }
        }
       
        /// <summary>
        /// 
        /// </summary>
        public string createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string updatetime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion Model

    }
}

