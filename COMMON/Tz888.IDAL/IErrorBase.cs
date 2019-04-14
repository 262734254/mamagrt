using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public class IErrorBase
    {
        public virtual bool Insert()
        {
            return (false);
        }

        public virtual bool Update()
        {
            return (false);
        }

        public virtual bool Delete()
        {
            return (false);
        }

        public virtual bool GetDetail(string Key)
        {
            return (false);
        }

        public virtual DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return (null);
        }

    }
}
