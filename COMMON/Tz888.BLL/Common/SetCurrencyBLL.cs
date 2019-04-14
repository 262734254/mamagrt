using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Common;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Common
{
    public class SetCurrencyBLL
    {
        private readonly ISetCurrency dal = DataAccess.CreateSetCurrency();


        public DataView GetList()
        {
            return dal.GetList();
        }
    }
}
