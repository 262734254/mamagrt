using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.MyHome
{
    /// <summary>
    /// ʵ����M_HomeType �����ͱ�(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class MyHomeType
    {
        public MyHomeType()
        { }
        #region Model
        private int _tid;  //����ID
        private string _typename;   //��������
        private string _loginname;  //�û�����
        private int _loginid;       //�û�ID
        private int? _sort;         //����
        private DateTime? _datatimes; //����ʱ��
        /// <summary>
        /// ����ID
        /// </summary>
        public int TID   
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        /// <summary>
        /// �û�ID
        /// </summary>
        public int LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int? sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? Datatimes
        {
            set { _datatimes = value; }
            get { return _datatimes; }
        }
        #endregion Model

    }
}
