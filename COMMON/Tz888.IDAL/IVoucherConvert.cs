using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
   public interface IVoucherConvert
    {
       int ConvertTicket(string LoginName, int IntegralCount, string CustomerLoginName);
    }
}
