using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Company
{
    public class NarrowSearchModel
    {
        #region Model
        private int _id;
        private int? _adid;
        private string _loginname;
        private DateTime? _createdate;
        /// <summary>
        /// ���
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// խ����
        /// </summary>
        public int? AdID
        {
            set { _adid = value; }
            get { return _adid; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        #endregion Model
    }
}
