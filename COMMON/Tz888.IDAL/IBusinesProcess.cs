using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IBusinesProcess
    {
        //发布需求
        bool Add(Tz888.Model.BusinesProcess model);

        //大小类加载
        DataSet SelectBig(int big);

        //所属行业
        DataSet SelectIndustry(int StructureCityID);
    }
}
