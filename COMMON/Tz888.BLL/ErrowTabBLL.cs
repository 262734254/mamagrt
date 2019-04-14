using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;

namespace Tz888.BLL
{
   public class ErrowTabBLL
    {
       Tz888.SQLServerDAL.ErrowTabDAL dal = new Tz888.SQLServerDAL.ErrowTabDAL();
       public int Add(ErrowTab model)
       {
           return dal.Add(model);
       }
       public int Update(ErrowTab model)
       {
           return dal.Update(model);
       }

       public ErrowTab GetModel(int Id)
       {
           return dal.GetModel(Id);
       }
       public List<ErrowTab> GetModelList()
       {
           return dal.GetModelList();
       }
    }
}
