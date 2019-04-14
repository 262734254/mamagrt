using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface ISetSubDefaultValue
    {
        long Insert(Tz888.Model.Info.SubDefaultValueModel model);

        bool Update(Tz888.Model.Info.SubDefaultValueModel model);

        bool Delete(long ID);

        Tz888.Model.Info.SubDefaultValueModel GetDetail(string Key);

        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
    }
}
