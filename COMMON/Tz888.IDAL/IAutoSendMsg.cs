using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IAutoSendMsg
    {
        bool SendMobileMsg(string LoginName, string To_Mobile, string Content);
    }
}
