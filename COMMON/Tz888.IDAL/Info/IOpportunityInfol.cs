using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Info
{
    public interface IOpportunityInfol
    {
        /// <summary>
        /// �����̻���Ϣ
        /// </summary>
        /// <param name="mainInfoModel"></param>
        /// <param name="opportunity"></param>
        /// <param name="shortInfoModel"></param>
        /// <returns></returns>
        long Insert(Tz888.Model.Info.MainInfoModel mainInfoModel,//����Ϣ��
            Tz888.Model.Info.OpportunityInfoModel opportunity,//�̻���
            Tz888.Model.Info.ShortInfoModel shortInfoModel
            );//���ű�
        /// <summary>
        /// ������ҵ
        /// </summary>
        DataView GetIndustry();

        /// <summary>
        /// �̻����
        /// </summary>
        DataView GetOpportun();
    }
}
