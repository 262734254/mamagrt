using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.IDAL.Professional
{
    public interface ProfessionalTypeIDAL
    {
        /// <summary>
        /// ��÷������
        /// </summary>
        /// <returns></returns>
        DataSet GetTypeAll();
    }
}
