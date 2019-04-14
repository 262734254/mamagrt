using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Info
{
  public   class ReleaseInsertBLL
    {
      Tz888.SQLServerDAL.Info.ReleaseInfoDAL dal = new Tz888.SQLServerDAL.Info.ReleaseInfoDAL();

      /// <summary>
      /// 发布需求信息



      /// </summary>
      /// <param name="mainInfoModel"></param>
      /// <param name="model">发布需求信息</param>
      /// <returns></returns>
      public long ReleaseInsert(
          Tz888.Model.Info.MainInfoModel mainInfoModel,
         Tz888.Model.BusinesProcess model,
         Tz888.Model.Info.ShortInfoModel shortInfoModel)
      {
          return dal.ReleaseInsert(mainInfoModel, model, shortInfoModel); 
      }
      public Tz888.Model.BusinesProcess getModel(int Id)
      {
          return dal.getModel(Id);
      }
      public bool update(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.BusinesProcess model,
           Tz888.Model.Info.ShortInfoModel shortInfoModel)
      {
          return dal.update(mainInfoModel, model, shortInfoModel);
      }
      /// <summary>
      /// 删除一条数据
      /// </summary>
      public bool Delete(long InfoID)
      {
        
          return dal.Delete(InfoID);
      }
      public Tz888.Model.SS_ProfessionalServicesModel getProModel(int id)
      {
          return dal.getProModel(id);
      }
    }
}
