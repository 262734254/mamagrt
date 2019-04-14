using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IPay
    {
        int CreateInfoOrder(long InfoID, string LoginName);

        int CreateCardOrder(Tz888.Model.Pay model);

        int CreateVipOrder(string LoginName, string @VipType);

        int CreateUserInfoOrder(string loginName, int point);
            
        int ConsumePayUserInfo(long orderno, long view_ID, string loginName, int pointTatol, string payType);

        int MemberStrike(string LoginName, double PointCount, string ForeignTradeNo, string StrikeType);

        int ConsumePay(long OrderNo, string LoginName, string PayType);

        DataTable getOrderDetails(long OrderNo, string LoginName);

        bool ShopCar_Add(long InfoID, string LoginName);

        bool ShopCar_Delete(long ShopCarID);
    }
}
