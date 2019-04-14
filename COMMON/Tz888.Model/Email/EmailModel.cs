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
        	
        public int Email_ID;            //邮件表的ID
	    public string Email_Name;       //邮件主题
        public string Email_SUser;      //发件人：一般是固定的		"sender@tz888.cn"
        public string Email_ReSUser;    //发件人的名称：一般固定的  "中国招商投资网"
	    public string Email_RUser;      //收件人，Email用户的ID，ID用“，”隔开  【类型？？】
	    public string Email_Content;    //邮件内容								【类型？？】
	    public DateTime Email_AddTime;  //发送时间
        public int Email_IsSuc;         //是否成功 是否为草稿或者是否发送成功
        //public EmailAnnexModel[]  EmailAnnex;
    }
}
