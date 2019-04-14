using System;
namespace Tz888.Model
{
    /// <summary>
    /// 拓富指数衡量标准实体类
    /// </summary>
    public class TFZS_MeasureStandard
    {
        public TFZS_MeasureStandard()
        { }
        #region Model
        private string _measurecode;
        private int _sortid;
        private string _expresscode;
        private string _measurename;
        private decimal _measurepoint;
        private string _expressremark;
        /// <summary>
        /// 
        /// </summary>
        public string MeasureCode
        {
            set { _measurecode = value; }
            get { return _measurecode; }
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
        public string ExpressCode
        {
            set { _expresscode = value; }
            get { return _expresscode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MeasureName
        {
            set { _measurename = value; }
            get { return _measurename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MeasurePoint
        {
            set { _measurepoint = value; }
            get { return _measurepoint; }
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

