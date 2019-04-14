using System;
namespace Tz888.Model.TFZS
{
    /// <summary>
    /// 拓富指数主指标实体类
    /// </summary>
    public class TFZS_MainTarget
    {
        public TFZS_MainTarget()
        {}
        #region Model
        private string _dicmaincode;
        private int _sortid;
        private string _maintargetname;
        private string _maintargetdescript;
        private decimal _maintargetpoint;
        private string _maintargettype;
        private string _maintargetremark;
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
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainTargetName
        {
            set { _maintargetname = value; }
            get { return _maintargetname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainTargetDescript
        {
            set { _maintargetdescript = value; }
            get { return _maintargetdescript; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MainTargetPoint
        {
            set { _maintargetpoint = value; }
            get { return _maintargetpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainTargetType
        {
            set { _maintargettype = value; }
            get { return _maintargettype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MainTargetRemark
        {
            set { _maintargetremark = value; }
            get { return _maintargetremark; }
        }

        public TFZS_MainTarget(
            string dicmaincode, 
            int sortid,
            string maintargetname,
            string maintargetdescript,
            decimal maintargetpoint,
            string maintargettype,
            string maintargetremark
            )
        {
            this._dicmaincode = dicmaincode;
            this._sortid = sortid;
            this._maintargetname = maintargetname;
            this._maintargetdescript = maintargetdescript;
            this._maintargetpoint = maintargetpoint;
            this._maintargettype = maintargettype;
            this._maintargetremark = maintargetremark;
        }
        #endregion Model
    }
}

