using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Subject
{
    /// <summary>
    /// ר���ƹ�
    /// </summary>
    public class SubjectExtendModel
    {
        #region Model
        private int _subid;
        private string _loginname;
        private string _subtitle;
        private string _remark;
        private int? _audit;
        private int? _source;
        private string _htmlurl;
        private int? _sort;
        private int? _subtype;
        private DateTime? _subtime;
        private string _linkman;
        private string _phone;
        private string _picture;
        /// <summary>
        /// ����
        /// </summary>
        public int SubID
        {
            set { _subid = value; }
            get { return _subid; }
        }
        /// <summary>
        /// �ʺ�����
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// ר�����
        /// </summary>
        public string SubTitle
        {
            set { _subtitle = value; }
            get { return _subtitle; }
        }
        /// <summary>
        /// ר��˵��
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// ���״̬
        /// </summary>
        public int? Audit
        {
            set { _audit = value; }
            get { return _audit; }
        }
        /// <summary>
        /// ��Դ
        /// </summary>
        public int? Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// ���ʵ�ַ
        /// </summary>
        public string HtmlUrl
        {
            set { _htmlurl = value; }
            get { return _htmlurl; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int? SubType
        {
            set { _subtype = value; }
            get { return _subtype; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }
        /// <summary>
        /// ��ϵ��
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// �绰
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// ͼƬ
        /// </summary>
        public string Picture
        {
            set { _picture = value; }
            get { return _picture; }
        }
        #endregion Model
    }
}
