using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IPayPwd
    {
        bool changePayPwd(string LoginName, string PayPassword);

        bool setPwdQuestion(string LoginName, string Question, string Answer,string Email);

        bool setCardID(string LoginName, string RealName, string CardID);

        DataTable valiPayPwd(string LoginName, string PayPwd);

        DataTable valiPayAsk(string LoginName, string Question, string Answer);
        DataTable valiLoginPwd(string LoginName, string PayPwd);
            
	

    }
}
