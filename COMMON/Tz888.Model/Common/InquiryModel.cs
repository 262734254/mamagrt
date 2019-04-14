using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Common
{
    public class InquiryModel
    {
        public InquiryModel()
        { }
        #region Model
        private int _inquiid;
        private string _name;
        private string _address;
        private string _tel;
        private string _email;
        private string _messagetitle;
        private string _messagebody;
        private DateTime _postdate;
        private int _auditstatus;

        /// <summary>
        /// 
        /// </summary>
        public int InquiID
        {
            set { _inquiid = value; }
            get { return _inquiid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 地域
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
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
        /// Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string MessageTitle
        {
            set { _messagetitle = value; }
            get { return _messagetitle; }
        }
        /// <summary>
        /// 正文
        /// </summary>
        public string MessageBody
        {
            set { _messagebody = value; }
            get { return _messagebody; }
        }
        /// <summary>
        /// 提交日期
        /// </summary>
        public DateTime PostDate
        {
            set { _postdate = value; }
            get { return _postdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AuditStatus
        {
            set { _auditstatus = value; }
            get { return _auditstatus; }
        }
        #endregion Model
    }
}
