using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ICard
    {
        int Insert(Tz888.Model.Card model);

        int Update(Tz888.Model.Card model);

        bool Delete(long CardNo);
    }
}
