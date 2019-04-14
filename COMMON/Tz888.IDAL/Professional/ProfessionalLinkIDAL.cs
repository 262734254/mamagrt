using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Professional;
namespace Tz888.IDAL.Professional
{
    public interface ProfessionalLinkIDAL
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        ProfessionalLink GetModel(int Lid);


    }
}
