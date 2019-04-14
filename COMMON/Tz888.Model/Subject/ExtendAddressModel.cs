using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Subject
{
    /// <summary>
    /// �ƹ�λ�ñ�
    /// </summary>
    public class ExtendAddressModel
    {
        #region Model
        private int _extendid;
        private int? _subid;
        private string _extendaddress;
        private string _extendurl;
        /// <summary>
        /// ����
        /// </summary>
        public int ExtendID
        {
            set { _extendid = value; }
            get { return _extendid; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public int? SubID
        {
            set { _subid = value; }
            get { return _subid; }
        }
        /// <summary>
        /// �ƹ��ַ
        /// </summary>
        public string ExtendAddress
        {
            set { _extendaddress = value; }
            get { return _extendaddress; }
        }
        /// <summary>
        /// ����Ӧ��·��
        /// </summary>
        public string ExtendUrl
        {
            set { _extendurl = value; }
            get { return _extendurl; }
        }
        #endregion Model
    }
}
