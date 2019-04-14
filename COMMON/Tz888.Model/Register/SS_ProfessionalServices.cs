using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Register
{
    public class SS_ProfessionalServices
    {
        private int _PSID;
        private string _LoginName;
        private string _NnitName;
        private string _CountryCode;
        private int _ProvinceID;
        private int _CityID;
        private int _AreaID;
        private string _Job;
        private int _TalentType;
        private int _ServiceBigtype;
        private string _ServiceSmalltype;
        private string _Resume;
        private string _Specialty;
        private string _BefCase;
        private string _Tel;
        private string _FAX;
        private string _Mobile;
        private string _Address;
        private string _Pic;
        private string _Email;
        private string _Doc;
        private DateTime _RegDate;
        private string _RealName;
        /// <summary>
        /// 注册人才服务表ID
        /// </summary>
        public int PSID
        {
            set { _PSID = value; }
            get { return _PSID; }
        }
        /// <summary>
        /// 帐号名称
        /// </summary>
        public string LoginName
        {
            set { _LoginName = value; }
            get { return _LoginName; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string  NnitName
        {
            set { _NnitName = value; }
            get { return _NnitName; }
        }
        /// <summary>
        /// 国家代号
        /// </summary>
        public string CountryCode
        {
            set { _CountryCode = value; }
            get { return _CountryCode; }
        }
        /// <summary>
        /// 省ID
        /// </summary>
        public int ProvinceID
        {
            set { _ProvinceID = value; }
            get { return _ProvinceID; }
        }
        /// <summary>
        /// 市ID
        /// </summary>
        public int CityID
        {
            set { _CityID = value; }
            get { return _CityID; }
        }
        /// <summary>
        /// 县ID
        /// </summary>
        public int AreaID
        {
            set { _AreaID = value; }
            get { return _AreaID; }
        }
        /// <summary>
        /// 职务
        /// </summary>
        public string Job
        {
            set { _Job = value; }
            get { return _Job; }
        }
        /// <summary>
        /// 人才类型
        /// </summary>
        public int TalentType
        {
            set { _TalentType = value; }
            get { return _TalentType; }
        }
        /// <summary>
        /// 服务大类
        /// </summary>
        public int ServiceBigtype
        {
            set { _ServiceBigtype = value; }
            get { return _ServiceBigtype; }
        }
        /// <summary>
        /// 服务小类
        /// </summary>
        public string ServiceSmalltype
        {
            set { _ServiceSmalltype = value; }
            get { return _ServiceSmalltype; }
        }
        /// <summary>
        ///简历
        /// </summary>
        public string Resume
        {
            set { _Resume = value; }
            get { return _Resume; }
        }
        /// <summary>
        /// 特长
        /// </summary>
        public string Specialty
        {
            set { _Specialty = value; }
            get { return _Specialty; }
        }
        /// <summary>
        ///案例
        /// </summary>
        public string BefCase
        {
            set { _BefCase = value; }
            get { return _BefCase; }
        }
        /// <summary>
        ///电话
        /// </summary>
        public string Tel
        {
            set { _Tel = value; }
            get { return _Tel; }
        }
        /// <summary>
        /// 传真
        /// </summary>
        public string FAX
        {
            set { _FAX = value; }
            get { return _FAX; }
        }
        /// <summary>
        ///手机
        /// </summary>
        public string Mobile
        {
            set { _Mobile = value; }
            get { return _Mobile; }
        }
        /// <summary>
        ///地址
        /// </summary>
        public string Address
        {
            set { _Address = value; }
            get { return _Address; }
        }
        /// <summary>
        ///照片
        /// </summary>
        public string Pic
        {
            set { _Pic = value; }
            get { return _Pic; }
        }
        /// <summary>
        ///Email
        /// </summary>
        public string Email
        {
            set { _Email = value; }
            get { return _Email; }
        }
        /// <summary>
        ///备注
        /// </summary>
        public string Doc
        {
            set { _Doc = value; }
            get { return _Doc; }
        }
        /// <summary>
        ///注册时间
        /// </summary>
        public DateTime RegDate
        {
            set { _RegDate = value; }
            get { return _RegDate; }
        }
        /// <summary>
        ///真实姓名
        /// </summary>
        public string RealName
        {
            set { _RealName = value; }
            get { return _RealName; }
        }
    }

}