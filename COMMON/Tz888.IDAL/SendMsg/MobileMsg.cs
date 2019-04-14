using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.SendMsg
{
    public interface ISendMobileMsg
    {
        bool SendMobileMsg(string LoginName, string To_Mobile, string Content);
    }
}
