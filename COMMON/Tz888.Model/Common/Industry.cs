using System;
namespace Tz888.Model.Common
{
    /// <summary>
    /// 行业信息实体类
    /// </summary>
    public class Industry
    {
        public Industry()
        { }
        #region Model
        private string _industrybid;
        private string _industrybname;
        private string _remark;
        private int _sort;
        /// <summary>
        /// 
        /// </summary>
        public string IndustryBID
        {
            set { _industrybid = value; }
            get { return _industrybid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IndustryBName
        {
            set { _industrybname = value; }
            get { return _industrybname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }

        public Industry(
            string industrybid,
            string industrybname,
            string remark,
            int sort
            )
        {
            this._industrybid = industrybid;
            this._industrybname = industrybname;
            this._remark = remark;
            this._sort = sort;
        }
        #endregion Model
    }
}

