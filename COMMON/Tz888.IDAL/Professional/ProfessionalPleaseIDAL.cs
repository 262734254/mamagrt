using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
   public interface ProfessionalPleaseIDAL
    {
       bool InsertProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link);
       /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       ProfessionalPlease GetModel(int ProfessionalID);
       bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link);
        
       
    }
}
