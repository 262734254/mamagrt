using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Info;
using Tz888.DALFactory;
using System.Data;

namespace Tz888.BLL.Info
{

    public class CarveOutInformationBLL
    {
        private readonly ICarveOutInformationService dal = DataAccess.CreateInfo_CarveOutInformation();
        /// <summary>
        /// ��ҵ��Ϣ����
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="opportunity"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        public long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.CarveOutInfoTabModel CarveMode,
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            )
        {
            return dal.Insert(mainInfoModel, CarveMode, shortInfoModel);
        }
        /// <summary>
        /// ��ҵ��Ϣ�޸�
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="opportunity"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        public long Update(Tz888.Model.Info.MainInfoModel mainInfoModel,
            Tz888.Model.Info.CarveOutInfoTabModel CarveMode,
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            )
        {
            return dal.Update(mainInfoModel, CarveMode, shortInfoModel);
        }
        /// <summary>
        /// ������ҵ
        /// </summary>
        public DataView GetIndustry()
        {
            return dal.GetIndustry();
        }

    }
}
