using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Koubei;

namespace Tz888.IDAL.Koubei
{
    public interface IJoinkoubei
    {
        string insertData(JoinKoubeiModel model);

        void updateData(JoinKoubeiModel model);

        bool deleteData(int JoinID);

        JoinKoubeiModel selectOneById(long JoinID);

        JoinKoubeiModel selectOne(JoinKoubeiModel model);

        JoinKoubeiModel getInfoFromMainInfo(string InfoType, long InfoID, string AreaAll);

        string[] getTitleAndContent(string InfoType, long InfoID);

        bool checkKoubeiByInfoID(string InfoType, long InfoID);

        bool updateStateById(long JoinID, int state);
    }
}
