using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IVIPMemberRegister
    {
        //ǰ̨�ظ�ͨ��Ա����
        int AddVIPMember(Tz888.Model.Register.VIPMemberRegister model);       

        //��̨��Ա�����б�
        DataTable GetMemberList(string tblName, string strGetFields, string fldName,
         int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);       

        //��ȡһ����¼��Ϣ���鿴��
        Tz888.Model.Register.VIPMemberRegister GetVIPMemberModel(int ApplyID);

        //���
        bool AuditVIPMember(Tz888.Model.Register.VIPMemberRegister model);      

        //ɾ������ȷ��������Ϣ
        bool DeleteVIPMember(int ApplyID);       

        // �޸�����
        bool UpdateVIPMember(Tz888.Model.Register.VIPMemberRegister model);

        //����ظ�ͨ��Ա
        bool UpdateVIPMember_sh(Tz888.Model.Register.VIPMemberRegister model);
        /// <summary>
        /// ��ȡ�ظ�ͨ����۸�
        /// </summary>
        /// <param name="ManageTypeID">��Ա����</param>
        /// <param name="BuyTerm">��������</param>
        /// <returns></returns>
        string getPriceByType(string ManageTypeID, int BuyTerm);
        
       // �ظ�ͨ��Աɾ����ֻȡ�����˵��ظ�ͨ��Ա�ʸ�
        bool VIPMember_Delete(string LoginName, string ManageTypeID, int CycleID);

        //��ѯ�ظ�ͨ��Ա�Ƿ�����
        bool VIP_IsExist(string loginName, string ManageTypeID, int BuyTerm);

        //�޸��ظ�ͨ�������Ͳ�����أ��������ã�
        void UpdateVIPPrice(Tz888.Model.Register.SetVIPPriceModel model);

        //��ȡ���벻ͬ�����ظ�ͨ��Ա�۸�
        Tz888.Model.Register.SetVIPPriceModel getVIPPriceModel(int VIPPriceID);

        //��������ɾ��
        void Delete(int VIPPriceID);
        
    }
}
