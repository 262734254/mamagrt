using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface ICarveOutInformationService
    {
        /// <summary>
        /// ��ҵ��Ϣ����
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="opportunity"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.CarveOutInfoTabModel CarveModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel);

        /// <summary>
        /// ��ҵ��Ϣ�޸�
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="opportunity"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Update(Tz888.Model.Info.MainInfoModel mainInfoModel,
           Tz888.Model.Info.CarveOutInfoTabModel CarveModel,
           Tz888.Model.Info.ShortInfoModel shortInfoModel);
       
        DataView GetIndustry();
    }
}
