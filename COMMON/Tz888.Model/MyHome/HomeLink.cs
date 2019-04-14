using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.MyHome
{
    /// <summary>
    /// ʵ����M_HomeLink ����ַ�� (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class MyHomeLink
    {
        public MyHomeLink()
        { }
        #region Model
        private int _lid; //��ַ����
        private MyHomeType typeid = new MyHomeType();        //����ID
        private string _lname;   //��վ����
        private string _linkwww; //��վ��ַ
        private string _wdoc;//��ע
        private int _wsort;       //����
        private string _username;//�û��ʺ�
        private string _password; //�ʺ�����
        private int _states;    //״̬
        private DateTime _createtimes;//����ʱ��
        private string _loginname;    //�ʺ�����
        private int _loginid;//�ʺ�ID
        /// <summary>
        /// ��ַ����
        /// </summary>
        public int LID
        {
            set { _lid = value; }
            get { return _lid; }
        }
      
        /// <summary>
        /// ��վ����
        /// </summary>
        public string LName
        {
            set { _lname = value; }
            get { return _lname; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public MyHomeType Typeid
        {
            get { return typeid; }
            set { typeid = value; }
        }
        /// <summary>
        /// ��վ��ַ
        /// </summary>
        public string Linkwww
        {
            set { _linkwww = value; }
            get { return _linkwww; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string WDoc
        {
            set { _wdoc = value; }
            get { return _wdoc; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int WSort
        {
            set { _wsort = value; }
            get { return _wsort; }
        }
        /// <summary>
        /// �û��ʺ�
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// �ʺ�����
        /// </summary>
        public string PassWord
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// ״̬
        /// </summary>
        public int States
        {
            set { _states = value; }
            get { return _states; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateTimes
        {
            set { _createtimes = value; }
            get { return _createtimes; }
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
        /// �ʺ�ID
        /// </summary>
        public int LoginID
        {
            set { _loginid = value; }
            get { return _loginid; }
        }
        #endregion Model

    }
}
