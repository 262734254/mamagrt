using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{
   public class OpportunityInfoBLL
    {
       private readonly IOpportunityInfol dal = DataAccess.CreateInfo_OpporTunity();
       /// <summary>
       /// �̻���Ϣ����
       /// </summary>
       /// <param name="mainInfoModel"></param>
       /// <param name="opportunity"></param>
       /// <param name="shortInfoModel"></param>
       /// <returns></returns>
       public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.OpportunityInfoModel opportunity,
           Tz888.Model.Info.ShortInfoModel shortInfoModel
           )
       {
           return dal.Insert(mainInfoModel, opportunity, shortInfoModel);
       }
       /// <summary>
       /// ������ҵ
       /// </summary>
       public DataView GetIndustry()
       {
           return dal.GetIndustry();
       }
       /// <summary>
       /// �̻����
       /// </summary>
       public DataView GetOpportun()
       {
           return dal.GetOpportun();
       }
    }
}
