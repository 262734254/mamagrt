using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Email
{
    public class EmailAnnexModel
    {
        public EmailAnnexModel()
        {
        }

        public int Annex_ID;//邮件的附件ID
        public int Annex_EmailID;//-所属邮件名
        public string Annex_Name;//附件文件名称
        public string Annex_Addr;//-附件地址
        public DateTime Annex_AddTime;//上传时间
    }
}
