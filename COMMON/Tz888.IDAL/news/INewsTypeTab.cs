using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.news
{
    public interface INewsTypeTab
    {
        List<Tz888.Model.NewsTypeTab> GetAllNewsType();
        Tz888.Model.NewsTypeTab GetNewsTypeByTypeId(int typeId);
    }
}
