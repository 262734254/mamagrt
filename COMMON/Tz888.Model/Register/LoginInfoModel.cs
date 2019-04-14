using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
   public class LoginInfoModel
    {
       public LoginInfoModel()
       { }

      
        private string _loginname;
        private byte[] _password;
        private string _rolename;
        private string _nickname;
        private string _tel;
        private string _email;
        private string _requirinfo;
        private bool _ischeckup;
        private string _managetypeid;
        private string _membergradeid;
        private string _pwdquestion;
        private string _pwdanswer;
        private string _companyname;
        private string _contactname;
        private string _contacttitle;
        private int _propertyid;
        private string _adsiteID;
       private int _autoreg;
       private string introducer;

       public string Introducer
       {
           get { return introducer; }
           set { introducer = value; }
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
        public byte[] Password
        {
            set { _password = value; }
            get { return _password; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RequirInfo
        {
            set { _requirinfo = value; }
            get { return _requirinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsCheckUp
        {
            set { _ischeckup = value; }
            get { return _ischeckup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ManageTypeID
        {
            set { _managetypeid = value; }
            get { return _managetypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MemberGradeID
        {
            set { _membergradeid = value; }
            get { return _membergradeid; }
        }


       public string PWDQuestion
       {
           set { _pwdquestion = value; }
           get { return _pwdquestion; }
       }

       public string PWDAnswere
       {
           set { _pwdanswer = value; }
           get { return _pwdanswer; }
       }


       public string CompanyName
       {
           set { _companyname = value; }
           get { return _companyname; }
       }

       public string ContactName
       {
           set { _contactname = value; }
           get { return _contactname; }
       }

       public string ContactTitle
       {
           set { _contacttitle = value; }
           get { return _contacttitle; }
       }

       public int PropertyID
       {
           set { _propertyid = value; }
           get { return _propertyid; }
       }



       public string adsiteID
       {
           set { _adsiteID = value; }
           get { return _adsiteID; }
       }

       public int autoReg
       {
           set { _autoreg = value; }
           get { return _autoreg; }
       }
   }
}
