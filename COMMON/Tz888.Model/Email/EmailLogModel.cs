using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Email
{
    public class EmailLogModel
    {
        public EmailLogModel()
        {

        }

        public int Log_ID;//发送邮件的日志（发送记录）
        public int Log_EmailID;//发送的邮件
        public int Log_UserID;//收件人
        public int Log_IsRead;//是否已阅
        public DateTime Log_AddTime;//发送时间
    }
}
