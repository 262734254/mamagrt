using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.advertise;
using Tz888.SQLServerDAL.advertise;
using Tz888.DALFactory;
using Tz888.IDAL.advertise;

namespace Tz888.BLL.advertise
{
    public class ADlaunchInfoBLL
    {
        private readonly IADlaunchInfo dal = DataAccess.AD_ADlaunchInfo();
        public string SelBName(int id)
        {
            return dal.SelBName(id);
        }

    }
}
