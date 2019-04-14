using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{	
    /// <summary>
    /// ���ƣ��Ƽ���Ϣ��
    /// ��ѯ��CommendVIW
    /// ��;��Ϊ�Ƽ���Ϣ�����ṩ��Ӧ�ķ���������
    /// ����ˣ�wangwei
    /// �������ڣ�20090603
    /// </summary>
    public class Commend
    {
        private long mstrID;
        private long mstrInfoID;	//������
        private string mstrSendBy;//�ռ���
        private string mstrreceivedBy;
        private string mstrLoginName;
        private bool mstrIsCollect;//�Ƿ��ղ�

        public Commend()
        {

        }

        #region  -- ���� -------------------
        public long ID
        {
            get
            {
                return this.mstrID;
            }
            set
            {
                this.mstrID = value;
            }
        }
        public long InfoID
        {
            get
            {
                return this.mstrInfoID;
            }
            set
            {
                this.mstrInfoID = value;
            }
        }
        public string SendBy
        {
            get
            {
                return this.mstrSendBy;
            }
            set
            {
                this.mstrSendBy = value;
            }
        }
        public string receivedBy
        {
            get
            {
                return this.mstrreceivedBy;
            }
            set
            {
                this.mstrreceivedBy = value;
            }
        }
        public string LoginName
        {
            get
            {
                return this.mstrLoginName;
            }
            set
            {
                this.mstrLoginName = value;
            }
        }
        public bool IsCollect
        {
            get { return this.mstrIsCollect; }
            set { this.mstrIsCollect = value; }
        }
        #endregion
    }
}
