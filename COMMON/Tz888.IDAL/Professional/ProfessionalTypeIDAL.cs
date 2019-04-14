using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL.Professional
{
    public interface ProfessionalTypeIDAL
    {
        /// <summary>
        /// 获得服务类别
        /// </summary>
        /// <returns></returns>
        DataSet GetTypeAll();
    }
}
