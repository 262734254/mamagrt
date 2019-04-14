using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using Tz888.IDAL.Register;
using System.Data;
using Tz888.DALFactory;

namespace Tz888.BLL.Register
{
    public class VIPMemberRegister
    {
        private readonly IVIPMemberRegister dal = DataAccess.CreateVIPMemberRegister();

        #region 前台拓富通会员审请
        public int AddVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.AddVIPMember(model);
        }
        #endregion
         
        #region 后台会员申请列表
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0未审核、1审核为拓富通会员、2已审核(已审基本信息)、3审核不通过、4退款、  </param>
        /// <param name="tblName"></param>
        /// <param name="strGetFields"></param>
        /// <param name="fldName"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="doCount"></param>
        /// <param name="OrderType"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>

        public DataTable GetMemberList(string tblName, string strGetFields, string fldName,
         int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {   
            return dal.GetMemberList(tblName, strGetFields, fldName,
          PageSize, PageIndex,doCount,OrderType,strWhere);

        }
        #endregion

        #region 获取一条记录信息（查看）
        public Tz888.Model.Register.VIPMemberRegister GetVIPMemberModel(int ApplyID)
        {
            return dal.GetVIPMemberModel(ApplyID);

        }
        #endregion

        #region 审核
        public bool AuditVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.AuditVIPMember(model);
        }
        #endregion

        #region 删除
        public bool DeleteVIPMember(int ApplyID)
        {
            return dal.DeleteVIPMember(ApplyID);
        }
        #endregion

        #region 逻辑删除
        public bool VIPMember_Delete(string LoginName, string ManageTypeID, int BuyTerm)
        {
            return dal.VIPMember_Delete(LoginName, ManageTypeID, BuyTerm);
        }
        #endregion

        #region 修改
        public bool UpdateVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.UpdateVIPMember(model);
        }
        #endregion
             
        //审核拓富通会员

        public bool UpdateVIPMember_sh(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.UpdateVIPMember_sh(model);
        }

        /// <summary>
        /// 获取拓富通购买价格
        /// </summary>
        /// <param name="ManageTypeID">会员类型</param>
        /// <param name="BuyTerm">购买期限</param>
        /// <returns></returns>
        public string getPriceByType(string ManageTypeID, int BuyTerm)
        {
            return dal.getPriceByType(ManageTypeID,BuyTerm);
        }

        #region 判断是否己存在
        public bool VIP_IsExist(string loginName, string ManageTypeID, int BuyTerm)
        {
            return dal.VIP_IsExist(loginName, ManageTypeID, BuyTerm);
        }
        #endregion

        #region 修改拓富通申请赠送参数相关
        public void UpdateVIPPrice(Tz888.Model.Register.SetVIPPriceModel model)
        {
             dal.UpdateVIPPrice(model);
        }
        #endregion

        #region  读取一条信息
        public Tz888.Model.Register.SetVIPPriceModel getVIPPriceModel(int VIPPriceID)
        {
            return dal.getVIPPriceModel(VIPPriceID);
        }
        #endregion

        

        public void Delete(int VIPPriceID)
        {
            dal.Delete(VIPPriceID);
        }

    }
}