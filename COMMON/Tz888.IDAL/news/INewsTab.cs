using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.news
{
    public interface INewsTab
    {
        int InsertNewsTab(Tz888.Model.NewsTab newstab,Tz888.Model.NewsTypeTab newstypetab,Tz888.Model.NewsViewTab newsviewtab);
        Tz888.Model.NewsTab GetNewsTabByNewId(int NewId);
        int DeleteNewsTab(int Newsid);
        int UpdateNewsTab(Tz888.Model.NewsTab newstab, int newsid);
        string GetMaxNewsId();
        int UpdateNewsTabUrl(string url, int newsid);
        int UpdateNewsTabaudit(int newsid);
    }
}
