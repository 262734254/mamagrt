using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class ConsumeInfos
    {
        #region Model 收益信息 
        private long _id;
        private long _InfoID;
        private string _PublishUserName;
        private float _ExpendMoney;
        private float _GainMoney; 
        private string _ExpendUserName;
        private DateTime _createdate;
        private string _Remark;
        private int _Status;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public long InfoID
        {
            set { _InfoID = value; }
            get { return _InfoID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PublishUserName
        {
            set { _PublishUserName = value; }
            get { return _PublishUserName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public  float ExpendMoney
        {
            set { _ExpendMoney = value; }
            get { return _ExpendMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public float GainMoney
        {
            set { _GainMoney = value; }
            get { return _GainMoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExpendUserName
        {
            set { _ExpendUserName = value; }
            get { return _ExpendUserName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }   
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }
        #endregion 
    }
}
