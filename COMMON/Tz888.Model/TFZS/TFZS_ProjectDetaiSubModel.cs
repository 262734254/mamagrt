using System;

namespace Tz888.Model.TFZS
{
    /// <summary>
    /// 
    /// </summary>
    public class TFZS_ProjectDetaiSubModel
    {
        public TFZS_ProjectDetaiSubModel()
        { }
        #region Model
        private long _id;
        private long _infoid;
        private string _dicmaincode;
        private string _expresscode;
        private string _target_answer;
        private decimal _target_point;
        /// <summary>
        /// 
        /// </summary>
        public long id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long InfoID
        {
            set { _infoid = value; }
            get { return _infoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DicMainCode
        {
            set { _dicmaincode = value; }
            get { return _dicmaincode; }
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
        public string TARGET_ANSWER
        {
            set { _target_answer = value; }
            get { return _target_answer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal TARGET_POINT
        {
            set { _target_point = value; }
            get { return _target_point; }
        }
        #endregion Model
    }
}

