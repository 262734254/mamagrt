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
        /// �õ�һ������ʵ��
        /// </summary>
        public ProfessionalLink GetModel(int ProfessionalID)
        {
            return dal.GetModel(ProfessionalID);
        }
    }
}
