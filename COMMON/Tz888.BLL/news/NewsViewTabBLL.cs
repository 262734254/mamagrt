using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.news
{
   public class NewsViewTabBLL
    {
       Tz888.SQLServerDAL.news.NewsViewTabDAL newsviewtabdal = new Tz888.SQLServerDAL.news.NewsViewTabDAL();
       public Tz888.Model.NewsViewTab GetNewsViewByNewId(int NewId)
       {
           return newsviewtabdal.GetNewsViewByNewId(NewId);
       }
       public int DeleteNewsViewTab(int Newsid)
       {
           return newsviewtabdal.DeleteNewsViewTab(Newsid);
       }
       public int UpdateNewsViewTab(Tz888.Model.NewsViewTab newsviewtab, int newsid)
       {
           return newsviewtabdal.UpdateNewsViewTab(newsviewtab,newsid);
       }
    }
}
