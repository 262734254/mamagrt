using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.MyHome
{
    /// <summary>
    /// 实体类M_HomeLink 。地址表 (属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MyHomeLink
    {
        public MyHomeLink()
        { }
        #region Model
        private int _lid; //网址主键
        private MyHomeType typeid = new MyHomeType();        //类型ID
        private string _lname;   //网站名称
        private string _linkwww; //网站地址
        private string _wdoc;//备注
        private int _wsort;       //排序
        private string _username;//用户帐号
        private string _password; //帐号密码
        private int _states;    //状态
        private DateTime _createtimes;//创建时间
        private string _loginname;    //帐号名称
        private int _loginid;//帐号ID
        /// <summary>
        /// 网址主键
        /// </summary>
        public int LID
        {
            set { _lid = value; }
            get { return _lid; }
        }
      
        /// <summary>
        /// 网站名称
        /// </summary>
        public string LName
        {
            set { _lname = value; }
            get { return _lname; }
        }
        /// <summary>
        /// 类型ID
        /// </summary>
        public MyHomeType Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }
        /// <summary>
        /// 网站地址
        /// </summary>
        public string Linkwww
        {
            set { _linkwww = value; }
            get { return _linkwww; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string WDoc
        {
            set { _wdoc = value; }
            get { return _wdoc; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int WSort
        {
            set { _wsort = value; }
            get { return _wsort; }
        }
        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 帐号密码
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int States
        {
            set { _states = value; }
            get { return _states; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTimes
        {
            set { _createtimes = value; }
            get { return _createtimes; }
        }
        /// <summary>
        /// 帐号名称
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 帐号ID
        /// </summary>
        public int LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        #endregion Model

    }
}
