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
        /// 得到一个对象实体
        /// </summary>
       ProfessionalPlease GetModel(int ProfessionalID);
       bool UpdateProFessionlView(ProfessionalinfoTab mainInfo, ProfessionalPlease viewInfo, ProfessionalLink link);
        
       
    }
}
