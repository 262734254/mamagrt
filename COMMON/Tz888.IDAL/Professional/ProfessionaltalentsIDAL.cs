using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
    public interface ProfessionaltalentsIDAL
    {
        /// <summary>
        /// 插入一条专业服务数据
        /// </summary>
        /// <returns></returns>
        bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link);
        /// <summary>
        /// 修改一条专业人才数据
        /// </summary>
        /// <returns></returns>

        bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Professionaltalents GetModel(int ProfessionalID);
    }
}
