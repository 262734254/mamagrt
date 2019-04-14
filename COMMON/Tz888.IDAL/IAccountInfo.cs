using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IAccountInfo
    {
        DataTable GetAccountInfo(string LoginName);
    }
    
}
