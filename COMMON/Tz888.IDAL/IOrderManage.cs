using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IOrderManage
    {
        bool deleInfoOrder(long OrderNo, int action);

        bool deleOtherOrder(long OrderNo, int action);

        bool deleStrikeOrder(string StrikeOrder, int action);

        bool ConfirmendLog(long OrderNo, double PayMoney, string OperationMan, string Remark);
    }
}
