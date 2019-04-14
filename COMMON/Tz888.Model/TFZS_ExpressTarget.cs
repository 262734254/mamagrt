using System;
namespace Tz888.Model
{
    /// <summary>
    /// 拓富指数表现指标实体类
    /// </summary>
    public class TFZS_ExpressTarget
    {
        public TFZS_ExpressTarget()
        { }
        #region Model
        private string _expresscode;
        private int _sortid;
        private string _maintargetcode;
        private string _expressname;
        private string _expressdescript;
        private decimal _expresspoint;
        private string _expresstype;
        private bool _ismulti;
        private string _expressremark;
        /// <summary>
        /// 
        /// </summary>
        public string ExpressCode
        {
            set { _expresscode = value; }
            get { return _expresscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainTargetCode
        {
            set { _maintargetcode = value; }
            get { return _maintargetcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressName
        {
            set { _expressname = value; }
            get { return _expressname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressDescript
        {
            set { _expressdescript = value; }
            get { return _expressdescript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal ExpressPoint
        {
            set { _expresspoint = value; }
            get { return _expresspoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressType
        {
            set { _expresstype = value; }
            get { return _expresstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsMulti
        {
            set { _ismulti = value; }
            get { return _ismulti; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpressRemark
        {
            set { _expressremark = value; }
            get { return _expressremark; }
        }
        #endregion Model
    }
}

