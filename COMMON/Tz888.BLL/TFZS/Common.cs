using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL.TFZS;

namespace Tz888.BLL.TFZS
{
    public class Common
    {
        private readonly ICommon dal = DataAccess.CreateTFZS_Common();
    }
}
