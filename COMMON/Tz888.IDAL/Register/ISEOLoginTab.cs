using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Tz888.IDAL.Register;

namespace Tz888.IDAL.Register
{
    public interface ISEOLoginTab
    {
        void Add(Tz888.Model.Register.SEOLoginTabModel model);
    }
}
