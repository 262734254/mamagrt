using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.MyHome
{
    /// <summary>
    /// 实体类M_HomeType 。类型表(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class MyHomeType
    {
        public MyHomeType()
        { }
        #region Model
        private int _tid;  //类型ID
        private string _typename;   //类型名称
        private string _loginname;  //用户名称
        private int _loginid;       //用户ID
        private int? _sort;         //排序
        private DateTime? _datatimes; //创建时间
        /// <summary>
        /// 类型ID
        /// </summary>
        public int TID   
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Datatimes
        {
            set { _datatimes = value; }
            get { return _datatimes; }
        }
        #endregion Model

    }
}
