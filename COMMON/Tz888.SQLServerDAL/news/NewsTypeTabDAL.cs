using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.news;
using Tz888.DBUtility;
using System.Data;
using Tz888.Model;
using System.Data.SqlClient;

namespace Tz888.SQLServerDAL.news
{
    public class NewsTypeTabDAL : INewsTypeTab
    {
        public List<Tz888.Model.NewsTypeTab> GetAllNewsType()
        {
            string sql = "select TypeID ,TypeName from NewsTypeTab where BoolStar=1 and outid=1";
            List<Tz888.Model.NewsTypeTab> list = new List<NewsTypeTab>();
            DataSet set = null;
            set = DBHelpe.Query(sql);
            foreach (DataRow row in set.Tables[0].Rows)
            {
                Tz888.Model.NewsTypeTab newstypetab = new Tz888.Model.NewsTypeTab();
                newstypetab.TypeID=Convert .ToInt32 (row["TypeID"]);
                newstypetab.TypeName = row["TypeName"].ToString().Trim();
                list.Add(newstypetab);
            }
            return list;
        }
        public Tz888.Model.NewsTypeTab GetNewsTypeByTypeId(int typeId)
        {
            string sql = "select TypeID ,TypeName from NewsTypeTab where TypeID=@typeid";
            DataSet set = DBHelpe.Query(sql,new SqlParameter("typeid",typeId));
            Tz888.Model.NewsTypeTab newstypetab=null;
            foreach (DataRow row in set.Tables[0].Rows)
            {
                newstypetab = new Tz888.Model.NewsTypeTab();
                newstypetab.TypeID = Convert.ToInt32(row["TypeID"]);
                newstypetab.TypeName = row["TypeName"].ToString().Trim();

            }
            return newstypetab;
        }
    }
}
