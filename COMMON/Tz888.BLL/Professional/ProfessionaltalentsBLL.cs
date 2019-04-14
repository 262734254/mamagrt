using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Professional
{
    public class ProfessionaltalentsBLL
    {
        ProfessionaltalentsIDAL dal = DataAccess.CreatetalentsInfo();
        /// <summary>
        /// 插入一条专业服务数据
        /// </summary>
        /// <returns></returns>
        public bool InsertProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link)
        {
            return dal.InsertProFessionlView(mainInfo, viewInfo, link);
        }

        /// <summary>
        /// 修改一条专业人才数据
        /// </summary>
        /// <returns></returns>
        public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, Professionaltalents viewInfo, ProfessionalLink link)
        {
            return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Professionaltalents GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
        }
    }
}
