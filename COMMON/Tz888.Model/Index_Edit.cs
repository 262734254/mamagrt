using System;
namespace Tz888.Model
{
    /// <summary>
    /// 实体类Index_Edit 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Index_Edit
    {
        public Index_Edit()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _titleurl;
        private string _titlecolor;
        private string _pic;
        private int _infotype;
        private int _indexno;
        private int _listtype;
        private DateTime _adddate;
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
        public string TitleUrl
        {
            set { _titleurl = value; }
            get { return _titleurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TitleColor
        {
            set { _titlecolor = value; }
            get { return _titlecolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pic
        {
            set { _pic = value; }
            get { return _pic; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfoType
        {
            set { _infotype = value; }
            get { return _infotype; }
        }
        public int IndexNo
        {
            set { _indexno = value; }
            get { return _indexno; }
        }
        public int ListType
        {
            set { _listtype = value; }
            get { return _listtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        #endregion Model

    }
}

