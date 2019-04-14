using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
    public class TPPicture
    {
        #region 图片
        private long _infoID;
        private string _Title;
        private string _InfoCode;
        private string _infotypeID;
        private string _subTitle;
        private string _HtmlURL;
        private string _Origin;
        private string _Author;
        private string _RedirectUrl;
        private int _IsRedirect;
        private string _Summary;
        private string _Content;
        private DateTime _Created;
        private string _Createby;
        private string _ProvinceID;
        private string _CityID;
        private string _CountyID;
        private string _strRemark;
        private string _LoginName;
        private string _KeyWord;
        private string _MiniatureUrl;
        private DateTime _publishT;
        private long _Hit;
        private int _IsCore;
        private string _Descript;
        private int _AuditingStatus;
        private string _AuditingRemark;
        /// <summary>
        /// 图片ID
        /// </summary>
        public long infoID
        {
            set { _infoID = value; }
            get { return _infoID; }
        }
        /// <summary>
        /// 图片标题
        /// </summary>
        public string Title
        {
            set { _Title = value; }
            get { return _Title; }
        }

        /// <summary>
        ///  图片标识
        /// </summary>
        public string InfoCode
        {
            set { _InfoCode = value; }
            get { return _InfoCode; }

        }

        /// <summary>
        /// 图片类型
        /// </summary>
        public string infotypeID
        {
            set { _infotypeID = value; }
            get { return _infotypeID; }
        }
        /// <summary>
        /// 短标题 
        /// </summary>
        public string subTitle
        {
            set { _subTitle = value; }
            get { return _subTitle; }
        }

        /// <summary>
        /// 图片路径 
        /// </summary>
        public string HtmlURL
        {
            set { _HtmlURL = value; }
            get { return _HtmlURL; }
        }

        /// <summary>
        /// 图片来源
        /// </summary>
        public string Origin
        {
            set { _Origin = value; }
            get { return _Origin; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            set { _Author = value; }
            get { return _Author; }
        }
        /// <summary>
        /// 转向链接
        /// </summary>
        public string RedirectUrl
        {
            set { _RedirectUrl = value; }
            get { return _RedirectUrl; }
        }
        /// <summary>
        /// 是否使用转向链接
        /// </summary>
        public int IsRedirect
        {
            set { _IsRedirect = value; }
            get { return _IsRedirect; }
        }
        /// <summary>
        /// 图片摘要
        /// </summary>
        public string Summary
        {
            set { _Summary = value; }
            get { return _Summary; }
        }
        /// <summary>
        /// 图片内容 
        /// </summary>
        public string Content
        {
            set { _Content = value; }
            get { return _Content; }
        }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime Created
        {
            set { _Created = value; }
            get { return _Created; }
        }

        /// <summary>
        ///　上传者
        /// </summary>
        public string Createby
        {
            set { _Createby = value; }
            get { return _Createby; }
        }

        /// <summary>
        /// 所属省份
        /// </summary>
        public string ProvinceID
        {
            set { _ProvinceID = value; }
            get { return _ProvinceID; }

        }
        /// <summary>
        /// 所属市级
        /// </summary>
        public string CityID
        {
            set { _CityID = value; }
            get { return _CityID; }

        }
        /// <summary>
        /// 所属县级
        /// </summary>
        public string CountyID
        {
            set { _CountyID = value; }
            get { return _CountyID; }

        }

        /// <summary>
        /// 备注
        /// </summary>
        public string strRemark
        {
            set { _strRemark = value; }
            get { return _strRemark; }

        }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string LoginName
        {
            set { _LoginName = value; }
            get { return _LoginName; }
        }

        /// <summary>
        /// 标签
        /// </summary>
        public string KeyWord
        {
            set { _KeyWord = value; }
            get { return _KeyWord; }
        }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string MiniatureUrl
        {
            set { _MiniatureUrl = value; }
            get { return _MiniatureUrl; }
        }

        /// <summary>
        ///　发布时间
        /// </summary>
        public DateTime publishT
        {
            set { _publishT = value; }
            get { return _publishT; }
        }

        /// <summary>
        /// 浏览量
        /// </summary>
        public long Hit
        {
            set { _Hit = value; }
            get { return _Hit; }
        }

        /// <summary>
        /// 是否重点
        /// </summary>
        public int IsCore
        {
            set { _IsCore = value; }
            get { return _IsCore; }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Descript
        {
            set { _Descript = value; }
            get { return _Descript; }
        }

        /// <summary>
        /// 状态 
        /// </summary>
        public int AuditingStatus
        {
            set { _AuditingStatus = value; }
            get { return _AuditingStatus; }
        }

        /// <summary>
        /// 审核描述 
        /// </summary>
        public string AuditingRemark
        {
            set { _AuditingRemark = value; }
            get { return _AuditingRemark; }
        }
        #endregion
    }
}
 