using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using Tz888.Model.Professional;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Professional
{
   public class ProfessionalPleaseBLL
    {
       ProfessionalPleaseIDAL dal = DataAccess.CreatePleaseInfo();
         /// <summary>
        /// ����һ��רҵ��������
        /// </summary>
        /// <returns></returns>
       public bool InsertProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link)
       {
           return dal.InsertProFessionlView(mainInfo,viewInfo,link);
       }
         /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       public ProfessionalPlease GetModel(int ProfessionalID)
       {
           return dal.GetModel(ProfessionalID);
       }
       public bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link)
       {
           return dal.UpdateProFessionlView(mainInfo, viewInfo, link);
       }

    }
}
