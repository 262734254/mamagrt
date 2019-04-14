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

        #region ǰ̨�ظ�ͨ��Ա����
        public int AddVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.AddVIPMember(model);
        }
        #endregion
         
        #region ��̨��Ա�����б�
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">0δ��ˡ�1���Ϊ�ظ�ͨ��Ա��2�����(���������Ϣ)��3��˲�ͨ����4�˿  </param>
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

        #region ��ȡһ����¼��Ϣ���鿴��
        public Tz888.Model.Register.VIPMemberRegister GetVIPMemberModel(int ApplyID)
        {
            return dal.GetVIPMemberModel(ApplyID);

        }
        #endregion

        #region ���
        public bool AuditVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.AuditVIPMember(model);
        }
        #endregion

        #region ɾ��
        public bool DeleteVIPMember(int ApplyID)
        {
            return dal.DeleteVIPMember(ApplyID);
        }
        #endregion

        #region �߼�ɾ��
        public bool VIPMember_Delete(string LoginName, string ManageTypeID, int BuyTerm)
        {
            return dal.VIPMember_Delete(LoginName, ManageTypeID, BuyTerm);
        }
        #endregion

        #region �޸�
        public bool UpdateVIPMember(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.UpdateVIPMember(model);
        }
        #endregion
             
        //����ظ�ͨ��Ա

        public bool UpdateVIPMember_sh(Tz888.Model.Register.VIPMemberRegister model)
        {
            return dal.UpdateVIPMember_sh(model);
        }

        /// <summary>
        /// ��ȡ�ظ�ͨ����۸�
        /// </summary>
        /// <param name="ManageTypeID">��Ա����</param>
        /// <param name="BuyTerm">��������</param>
        /// <returns></returns>
        public string getPriceByType(string ManageTypeID, int BuyTerm)
        {
            return dal.getPriceByType(ManageTypeID,BuyTerm);
        }

        #region �ж��Ƿ񼺴���
        public bool VIP_IsExist(string loginName, string ManageTypeID, int BuyTerm)
        {
            return dal.VIP_IsExist(loginName, ManageTypeID, BuyTerm);
        }
        #endregion

        #region �޸��ظ�ͨ�������Ͳ������
        public void UpdateVIPPrice(Tz888.Model.Register.SetVIPPriceModel model)
        {
             dal.UpdateVIPPrice(model);
        }
        #endregion

        #region  ��ȡһ����Ϣ
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