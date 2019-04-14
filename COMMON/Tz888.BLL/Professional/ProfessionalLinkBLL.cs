using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Professional
{
    public class ProfessionalLinkBLL
    {
        ProfessionalLinkIDAL dal = DataAccess.CreateLinkInfo();
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ProfessionalLink GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
        }
    }
}
