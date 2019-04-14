using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{

    public class VoucherConvert
    {
        private readonly IVoucherConvert dal = DataAccess.CreateIVoucherConvert();
    
        public int ConvertTicket(string LoginName, int IntegralCount, string CustomerLoginName)
        {
            return dal.ConvertTicket(LoginName,IntegralCount,CustomerLoginName);
        }
    }
}
