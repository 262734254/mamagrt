using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Manage
{
    public interface IMenuPermission
    {
        /// <summary>
        /// ≤È—Ø¡–±Ì
        /// </summary>
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
    }
}
