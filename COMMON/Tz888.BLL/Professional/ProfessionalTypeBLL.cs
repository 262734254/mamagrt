using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Professional;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Professional
{
    public class ProfessionalTypeBLL
    {
        ProfessionalTypeIDAL typeIdal = DataAccess.CreateTypeInfo();
         /// <summary>
        /// 获得服务类型
        /// </summary>
        /// <returns></returns>
        public DataSet GetTypeAll()
        {
            return typeIdal.GetTypeAll();
        }
    }
}
