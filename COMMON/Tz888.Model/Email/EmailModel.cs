using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Email
{
    public class EmailModel
    {
        public EmailModel()
        {

        }
        	
        public int Email_ID;            //�ʼ����ID
	    public string Email_Name;       //�ʼ�����
        public string Email_SUser;      //�����ˣ�һ���ǹ̶���		"sender@tz888.cn"
        public string Email_ReSUser;    //�����˵����ƣ�һ��̶���  "�й�����Ͷ����"
	    public string Email_RUser;      //�ռ��ˣ�Email�û���ID��ID�á���������  �����ͣ�����
	    public string Email_Content;    //�ʼ�����								�����ͣ�����
	    public DateTime Email_AddTime;  //����ʱ��
        public int Email_IsSuc;         //�Ƿ�ɹ� �Ƿ�Ϊ�ݸ�����Ƿ��ͳɹ�
        //public EmailAnnexModel[]  EmailAnnex;
    }
}
