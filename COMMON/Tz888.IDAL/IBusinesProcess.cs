using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IBusinesProcess
    {
        //��������
        bool Add(Tz888.Model.BusinesProcess model);

        //��С�����
        DataSet SelectBig(int big);

        //������ҵ
        DataSet SelectIndustry(int StructureCityID);
    }
}
