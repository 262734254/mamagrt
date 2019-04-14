using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IVIPMemberRegister
    {
        //前台拓富通会员审请
        int AddVIPMember(Tz888.Model.Register.VIPMemberRegister model);       

        //后台会员申请列表
        DataTable GetMemberList(string tblName, string strGetFields, string fldName,
         int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);       

        //获取一条记录信息（查看）
        Tz888.Model.Register.VIPMemberRegister GetVIPMemberModel(int ApplyID);

        //审核
        bool AuditVIPMember(Tz888.Model.Register.VIPMemberRegister model);      

        //删除不正确的申请信息
        bool DeleteVIPMember(int ApplyID);       

        // 修改资料
        bool UpdateVIPMember(Tz888.Model.Register.VIPMemberRegister model);

        //审核拓富通会员
        bool UpdateVIPMember_sh(Tz888.Model.Register.VIPMemberRegister model);
        /// <summary>
        /// 获取拓富通购买价格
        /// </summary>
        /// <param name="ManageTypeID">会员类型</param>
        /// <param name="BuyTerm">购买期限</param>
        /// <returns></returns>
        string getPriceByType(string ManageTypeID, int BuyTerm);
        
       // 拓富通会员删除（只取消此人的拓富通会员资格）
        bool VIPMember_Delete(string LoginName, string ManageTypeID, int CycleID);

        //查询拓富通会员是否己申请
        bool VIP_IsExist(string loginName, string ManageTypeID, int BuyTerm);

        //修改拓富通申请赠送参数相关（参数设置）
        void UpdateVIPPrice(Tz888.Model.Register.SetVIPPriceModel model);

        //获取申请不同周期拓富通会员价格
        Tz888.Model.Register.SetVIPPriceModel getVIPPriceModel(int VIPPriceID);

        //参数设置删除
        void Delete(int VIPPriceID);
        
    }
}
