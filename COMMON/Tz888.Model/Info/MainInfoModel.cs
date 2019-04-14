using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// 资源主体信息实体类
    /// </summary>
    public class MainInfoModel
    {
        public MainInfoModel()
        { }
        #region Model
        private long _id;
        private long _infoid;
        private string _title;
        private string _infocode;
        private DateTime _publisht;
        private int _hit;
        private string _infotypeid;
        private bool _iscore;
        private int _indexordernum;
        private int _indextopvalidatedate;
        private int _indexpicinfonum;
        private int _infotypeordernum;
        private int _infotypetopvalidatedate;
        private int _infotypepicinfonum;
        private string _loginname;
        private string _infooriginrolename;
        private string _gradeid;
        private string _fixpriceid;
        private int _feestatus;
        private int _auditingstatus;
        private int _delstatus;
        private string _approveby;
        private DateTime _approvetime;
        private string _contentkeyword;
        private string _keyword;
        private string _descript;
        private string _displaytitle;
        private DateTime _frontdisplaytime;
        private DateTime _validatestarttime;
        private int _validateterm;
        private string _templateid;
        private string _htmlfile;
        private string _htmlfile1;
        private int _userevaluation;
        private int _isintegralinfo;
        private decimal _mainpointcount;
        private int _mainevaluation;
        private bool _refreshtag;
        private bool _isvoucherinfo;
        private int _isvip;
        

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
            set { _infoid = value; }
            get { return _infoid; }
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
        public string InfoCode
        {
            set { _infocode = value; }
            get { return _infocode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime publishT
        {
            set { _publisht = value; }
            get { return _publisht; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Hit
        {
            set { _hit = value; }
            get { return _hit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoTypeID
        {
            set { _infotypeid = value; }
            get { return _infotypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCore
        {
            set { _iscore = value; }
            get { return _iscore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IndexOrderNum
        {
            set { _indexordernum = value; }
            get { return _indexordernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IndexTopValidateDate
        {
            set { _indextopvalidatedate = value; }
            get { return _indextopvalidatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IndexPicInfoNum
        {
            set { _indexpicinfonum = value; }
            get { return _indexpicinfonum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfoTypeOrderNum
        {
            set { _infotypeordernum = value; }
            get { return _infotypeordernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfoTypeTopValidateDate
        {
            set { _infotypetopvalidatedate = value; }
            get { return _infotypetopvalidatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InfoTypePicInfoNum
        {
            set { _infotypepicinfonum = value; }
            get { return _infotypepicinfonum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InfoOriginRoleName
        {
            set { _infooriginrolename = value; }
            get { return _infooriginrolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GradeID
        {
            set { _gradeid = value; }
            get { return _gradeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FixPriceID
        {
            set { _fixpriceid = value; }
            get { return _fixpriceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int FeeStatus
        {
            set { _feestatus = value; }
            get { return _feestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AuditingStatus
        {
            set { _auditingstatus = value; }
            get { return _auditingstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DelStatus
        {
            set { _delstatus = value; }
            get { return _delstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ApproveBy
        {
            set { _approveby = value; }
            get { return _approveby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ApproveTime
        {
            set { _approvetime = value; }
            get { return _approvetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContentKeyword
        {
            set { _contentkeyword = value; }
            get { return _contentkeyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KeyWord
        {
            set { _keyword = value; }
            get { return _keyword; }
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
        public string DisplayTitle
        {
            set { _displaytitle = value; }
            get { return _displaytitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FrontDisplayTime
        {
            set { _frontdisplaytime = value; }
            get { return _frontdisplaytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ValidateStartTime
        {
            set { _validatestarttime = value; }
            get { return _validatestarttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ValidateTerm
        {
            set { _validateterm = value; }
            get { return _validateterm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TemplateID
        {
            set { _templateid = value; }
            get { return _templateid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlFile
        {
            set { _htmlfile = value; }
            get { return _htmlfile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HtmlFile1
        {
            set { _htmlfile1 = value; }
            get { return _htmlfile1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserEvaluation
        {
            set { _userevaluation = value; }
            get { return _userevaluation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsIntegralInfo
        {
            set { _isintegralinfo = value; }
            get { return _isintegralinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal MainPointCount
        {
            set { _mainpointcount = value; }
            get { return _mainpointcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int MainEvaluation
        {
            set { _mainevaluation = value; }
            get { return _mainevaluation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool refreshtag
        {
            set { _refreshtag = value; }
            get { return _refreshtag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsVoucherInfo
        {
            set { _isvoucherinfo = value; }
            get { return _isvoucherinfo; }
        }
        public int IsVip
        {
            set { _isvip = value; }
            get { return _isvip; }
        }
        #endregion Model
    }
}
