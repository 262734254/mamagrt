using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// ��Ŀ��Ϣʵ����
    /// </summary>
    public class ProjectInfoModel
    {
        public ProjectInfoModel()
        { }
        #region Model
        private long _infoid;
        private string _projectname;
        private string _projectnamebrief;
        private string _comabout;
        private string _combrief;
        private string _countrycode;
        private string _countryname;
        private string _provinceid;
        private string _provincename;
        private string _cityid;
        private string _cityname;
        private string _countyid;
        private string _countyname;

        private string _industrybid;
        private List<string> _industryBName = new List<string>();

        private string _cooperationdemandtype;
        private List<string> _cooperationdemandtypename = new List<string>();


        private string _capitalcurrency;
        private decimal _capitaltotal;
        private string _projectcurrency;
        private string _capitalid;
        private string _capitalname;
        private string _remrk;
        private bool _isrec;
        private bool _istop;
        private DateTime _rectime;
        private string _recremark;
        private int _recterm;

        /// <summary>
        /// ������ҵ
        /// </summary>
        public List<string> IndustryBName
        {
            set { _industryBName = value; }
            get { return _industryBName; }
        }

        /// <summary>
        /// ������ʽ
        /// </summary>
        public List<string> CooperationDemandTypeName
        {
            set { _cooperationdemandtypename = value; }
            get { return _cooperationdemandtypename; }
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
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectNameBrief
        {
            set { _projectnamebrief = value; }
            get { return _projectnamebrief; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ComAbout
        {
            set { _comabout = value; }
            get { return _comabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ComBrief
        {
            set { _combrief = value; }
            get { return _combrief; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryCode
        {
            set { _countrycode = value; }
            get { return _countrycode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryName
        {
            get { return _countryname; }
            set { _countryname = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }

        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }

        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountyID
        {
            set { _countyid = value; }
            get { return _countyid; }
        }

        public string CountyName
        {
            set { _countyname = value; }
            get { return _countyname; }

        }
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
        public string CooperationDemandType
        {
            set { _cooperationdemandtype = value; }
            get { return _cooperationdemandtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CapitalCurrency
        {
            set { _capitalcurrency = value; }
            get { return _capitalcurrency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CapitalTotal
        {
            set { _capitaltotal = value; }
            get { return _capitaltotal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectCurrency
        {
            set { _projectcurrency = value; }
            get { return _projectcurrency; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CapitalID
        {
            set { _capitalid = value; }
            get { return _capitalid; }
        }

        public string CapitalName
        {
            set { _capitalname = value; }
            get { return _capitalname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remrk
        {
            set { _remrk = value; }
            get { return _remrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsRec
        {
            set { _isrec = value; }
            get { return _isrec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsTop
        {
            set { _istop = value; }
            get { return _istop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RecRemark
        {
            set { _recremark = value; }
            get { return _recremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RecTerm
        {
            set { _recterm = value; }
            get { return _recterm; }
        }

        //�޸�����08.6.2
        private string _areaid;
        private decimal _financingamount;
        private int _sellstockshare;
        private string _returnmodeid;
        private string _projectabout;
        private string _marketabout;
        private string _competitioabout;
        private string _bussinessmodeabout;
        private string _manageteamabout;
        private string _attachfile1;
        private string _attachfile2;
        private string _attachfile3;
        private string _warrant;
        private decimal _companyyearincome;
        private decimal _companyng;
        private decimal _companytotalcapital;
        private decimal _companytotaldebet;
        private string _financingid;
        /// <summary>
        /// 
        /// </summary>
        public string AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal financingAmount
        {
            set { _financingamount = value; }
            get { return _financingamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SellStockShare
        {
            set { _sellstockshare = value; }
            get { return _sellstockshare; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReturnModeID
        {
            set { _returnmodeid = value; }
            get { return _returnmodeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProjectAbout
        {
            set { _projectabout = value; }
            get { return _projectabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string marketAbout
        {
            set { _marketabout = value; }
            get { return _marketabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string competitioAbout
        {
            set { _competitioabout = value; }
            get { return _competitioabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BussinessModeAbout
        {
            set { _bussinessmodeabout = value; }
            get { return _bussinessmodeabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManageTeamAbout
        {
            set { _manageteamabout = value; }
            get { return _manageteamabout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AttachFile1
        {
            set { _attachfile1 = value; }
            get { return _attachfile1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AttachFile2
        {
            set { _attachfile2 = value; }
            get { return _attachfile2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AttachFile3
        {
            set { _attachfile3 = value; }
            get { return _attachfile3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string warrant
        {
            set { _warrant = value; }
            get { return _warrant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyYearIncome
        {
            set { _companyyearincome = value; }
            get { return _companyyearincome; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyNG
        {
            set { _companyng = value; }
            get { return _companyng; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyTotalCapital
        {
            set { _companytotalcapital = value; }
            get { return _companytotalcapital; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal CompanyTotalDebet
        {
            set { _companytotaldebet = value; }
            get { return _companytotaldebet; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string financingID
        {
            set { _financingid = value; }
            get { return _financingid; }
        }


        //##���ڹ�Ȩ�ķ���
        //##20100603�¼�����ֶ�,��Դ���еڶ��ڸİ�,
        private string _sXmlxqk;
        private string _sXmgjz;
        private string _sTcfs;
        private string _sQyfzjd;
        private int _iYqzjdwqk;
        private int _iSczylfy;
        private int _iHysczzl;
        private int _iZcfzl;
        private int _iXmtzfbzq;
        private decimal _nDwlyysy;
        private decimal _nDwljly;
        private decimal _nDwzzc;
        private decimal _nDwzfz;
        private string _sXmqxms;

        public string sXmlxqk
        {
            set { _sXmlxqk = value; }
            get { return _sXmlxqk; }
        }

        public string sXmgjz
        {
            set { _sXmgjz = value; }
            get { return _sXmgjz; }
        }

        public string sTcfs
        {
            set { _sTcfs = value; }
            get { return _sTcfs; }
        }
        public string sQyfzjd
        {
            set { _sQyfzjd= value; }
            get { return _sQyfzjd; }
        }

        public int iYqzjdwqk
        {
            set { _iYqzjdwqk= value; }
            get { return _iYqzjdwqk; }
        }
        public int iSczylfy
        {
            set { _iSczylfy=value; }
            get { return _iSczylfy; }
        }
        public int iHysczzl
        {
            set { _iHysczzl=value; }
            get { return _iHysczzl; }
        }
        public int iZcfzl
        {
            set { _iZcfzl=value; }
            get { return _iZcfzl; }
        }
        public int iXmtzfbzq
        {
            set { _iXmtzfbzq=value; }
            get { return _iXmtzfbzq; }
        }
        public decimal  nDwlyysy
        {
            set { _nDwlyysy=value; }
            get { return _nDwlyysy; }
        }
        public decimal nDwljly
        {
            set { _nDwljly=value; }
            get { return _nDwljly; }
        }
        public decimal nDwzzc
        {
            set { _nDwzzc=value; }
            get { return _nDwzzc; }
        }
        public decimal  nDwzfz
        {
            set { _nDwzfz=value; }
            get { return _nDwzfz; }
        }
        public string sXmqxms
        {
            set { _sXmqxms=value; }
            get { return _sXmqxms; }
        }
        //-----------END--------------



        //##����ծȨ�ķ���
        //##20100603�¼�����ֶ�,��Դ���еڶ��ڸİ�
        private string _cZqXmlxqkb;	//��Ŀ�������
        private string _cZqQyfzjd;	//��ҵ��չ�׶�
        private int _iZqYqjjdwqk;//Ҫ���ʽ�λ���
        private int _iZqCpsczzl;	//��Ʒ�г�������
        private int _iZqCpscYl;	    //��Ʒ�г�����
        private int _iZqZcfzl;	    //�ʲ���ծ��
        private int _iZqYdbl;	    //��������
        private int _iZqTzsl;	    //Ͷ��������
        private int _iZqXslyl;	    //����������
        private int _iZqTzfbq;	    //Ͷ�ʻر���
        private int _iZqXmyxqs;	    //��Ŀ��Ч����
        private string _cZqXmzy;	//��ĿժҪ
        private string _cZqXmgjz;	//��Ŀ�ؼ���
        private string _cZqCpks;	//��Ʒ����
        private string _cZqJzfx;	//��������
        private string _cZqSyms;	//��ҵģʽ
        private string _cZqGltd;	//�����Ŷ�
        /// <summary>
        /// //��Ŀ�������
        /// </summary>
        public  string cZqXmlxqkb	
        {
            set { _cZqXmlxqkb = value; }
            get { return _cZqXmlxqkb; }
        }
        /// <summary>
        /// //��ҵ��չ�׶�
        /// </summary>
        public string cZqQyfzjd	
        {
            set { _cZqQyfzjd = value; }
            get { return _cZqQyfzjd; }
        }
        /// <summary>
        /// //Ҫ���ʽ�λ���
        /// </summary>
        public int iZqYqjjdwqk
        {
            set { _iZqYqjjdwqk = value; }
            get { return _iZqYqjjdwqk; }
        }
        /// <summary>
        /// 	//��Ʒ�г�������
        /// </summary>
        public int iZqCpsczzl	
        {
            set { _iZqCpsczzl = value; }
            get { return _iZqCpsczzl; }
        }
        /// <summary>
        /// //��Ʒ�г�����
        /// </summary>
        public int iZqCpscYl	  
        {
            set { _iZqCpscYl = value; }
            get { return _iZqCpscYl; }
        }
        /// <summary>
        ///   //�ʲ���ծ��
        /// </summary>
        public int iZqZcfzl	  
        {
            set { _iZqZcfzl = value; }
            get { return _iZqZcfzl; }
        }
        /// <summary>
        /// 	    //��������
        /// </summary>
        public int iZqYdbl
        {
            set { _iZqYdbl = value; }
            get { return _iZqYdbl; }
        }
        /// <summary>
        ///   //Ͷ��������
        /// </summary>
        public int iZqTzsl	  
        {
            set { _iZqTzsl = value; }
            get { return _iZqTzsl; }
        }
        /// <summary>
        ///     //����������
        /// </summary>
        public int iZqXslyl
        {
            set { _iZqXslyl = value; }
            get { return _iZqXslyl; }
        }
        /// <summary>
        /// //Ͷ�ʻر���
        /// </summary>
        public int iZqTzfbq	    
        {
            set { _iZqTzfbq = value; }
            get { return _iZqTzfbq; }
        }
        /// <summary>
        /// //��Ŀ��Ч����
        /// </summary>
        public int iZqXmyxqs	    
        {
            set { _iZqXmyxqs = value; }
            get { return _iZqXmyxqs; }
        }
        /// <summary>
        /// //��ĿժҪ
        /// </summary>
        public string cZqXmzy	
        {
            set { _cZqXmzy = value; }
            get { return _cZqXmzy; }
        }
        /// <summary>
        /// //��Ŀ�ؼ���
        /// </summary>
        public string cZqXmgjz	
        {
            set { _cZqXmgjz = value; }
            get { return _cZqXmgjz; }
        }
        /// <summary>
        /// //��Ʒ����
        /// </summary>
        public string cZqCpks	
        {
            set { _cZqCpks = value; }
            get { return _cZqCpks; }
        }
        /// <summary>
        /// //��������
        /// </summary>
        public string cZqJzfx	
        {
            set { _cZqJzfx = value; }
            get { return _cZqJzfx; }
        }
        /// <summary>
        /// //��ҵģʽ
        /// </summary>
        public string cZqSyms	
        {
            set { _cZqSyms = value; }
            get { return _cZqSyms; }
        }
        /// <summary>
        /// //�����Ŷ�
        /// </summary>
        public string cZqGltd	
        {
            set { _cZqGltd = value; }
            get { return _cZqGltd; }
        }
        //--------------END-----------


        //-------------201006���¾��ӵ������ֶ�
        private int _iEvaluationPop;  //��������(1.2.3.4.5��)
        private int _iTopCertification; //�ظ���֤��0 δ 1�� ��֤��
        private int _iInformationIntegrity; //��Ϣ�����ȣ�%��
        /// <summary>
        /// ��������(1.2.3.4.5��)
        /// </summary>
        public int EvaluationPop
        {
            set { _iEvaluationPop = value; }
            get { return _iEvaluationPop; }
        }
        /// <summary>
        /// �ظ���֤��0 δ 1�� ��֤��
        /// </summary>
        public int TopCertification
        {
            set { _iTopCertification = value; }
            get { return _iTopCertification; }
        }
        /// <summary>
        /// ��Ϣ�����ȣ�%��
        /// </summary>
        public int InformationIntegrity
        {
            set { _iInformationIntegrity = value; }
            get { return _iInformationIntegrity; }
        }
        //--------------------END-----------------


        #endregion Model
    }
    public class ExcavateProjectModel
    {
        public ExcavateProjectModel()
        {
        }
        #region ExcavateModel
        private string _title;
        private string _infoId;
        private string _com;
        private string _comInfo;
        private string _comMan;

        private string _comTel;
        private string _industry;
        private string _country;
        private string _province;
        private string _prjmoney;

        private string _mode;
        private string _projectInfo;
        private string _intent;
        private string _man;
        private string _manTel;

        private string _manMobile;
        private string _manAddress;
        private string _manCode;
        private string _manTax;
        private string _manEmail;

        private string _sourceName;
        private string _webUrl;
        private DateTime _publishTime;
       
        public DateTime PublishTime
        {
            get { return _publishTime; }
            set { _publishTime = value; }
        }
       
        public string WebUrl
        {
            get { return _webUrl; }
            set { _webUrl = value; }
        }
        public string SourceName
        {
            get { return _sourceName; }
            set { _sourceName = value; }
        }

        public string ManEmail
        {
            get { return _manEmail; }
            set { _manEmail = value; }
        }
        public string ManTax
        {
            get { return _manTax; }
            set { _manTax = value; }
        }
        public string ManCode
        {
            get { return _manCode; }
            set { _manCode = value; }
        }
        public string ManAddress
        {
            get { return _manAddress; }
            set { _manAddress = value; }
        }
        public string ManMobile
        {
            get { return _manMobile; }
            set { _manMobile = value; }
        }

        public string ManTel
        {
            get { return _manTel; }
            set { _manTel = value; }
        }
        public string Man
        {
            get { return _man; }
            set { _man = value; }
        }
        public string Intent
        {
            get { return _intent; }
            set { _intent = value; }
        }
        public string ProjectInfo
        {
            get { return _projectInfo; }
            set { _projectInfo = value; }
        }
        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        public string Prjmoney
        {
            get { return _prjmoney; }
            set { _prjmoney = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Industry
        {
            get { return _industry; }
            set { _industry = value; }
        }
        public string ComTel
        {
            get { return _comTel; }
            set { _comTel = value; }
        }

        public string ComMan
        {
            get { return _comMan; }
            set { _comMan = value; }
        }
        public string ComInfo
        {
            get { return _comInfo; }
            set { _comInfo = value; }
        }
        public string Com
        {
            get { return _com; }
            set { _com = value; }
        }
        public string InfoId 
        {
            get { return _infoId; }
            set { _infoId = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        #endregion
    }
}
