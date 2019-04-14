using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.news
{
    public interface INewsViewTab
    {
        Tz888.Model.NewsViewTab GetNewsViewByNewId(int NewId);
        int DeleteNewsViewTab(int Newsid);
        int UpdateNewsViewTab(Tz888.Model.NewsViewTab newsviewtab, int newsid);
    }
}
