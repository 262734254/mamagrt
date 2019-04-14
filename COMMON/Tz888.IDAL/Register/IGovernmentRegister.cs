using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IGovernmentRegister
    {
        #region ���̻����Ǽ�
        //�����Ǽǣ���ӣ�
        int GovernmentAdd(Tz888.Model.Register.GovernmentInfoModel model,
                 Tz888.Model.Register.OrgContactModel ContactModel,
                 List<Tz888.Model.Register.OrgContactMan> ContactManModels,
                 List<Tz888.Model.MemberResourceModel> infoResourceModels);

        //�����û�ID��ȡ��˾��Ϣ
        DataTable getGovernmentModel(string LoginName);

        //��������ע��
        void GovernmentReg(GovernmentInfoModel model);

        //�޸�
        int GovernmentUpdate(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels);

        //��ѯ
        DataTable getGovernmentList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);

        //���
        bool AuditGovernment();

        bool UpdateRefresh(int GovernmentID);
        
        //ɾ��
        bool DeleteGovernment(string loginName);

        //��̬����չ����

        //�Ƿ��ظ���ѯ
         DataTable getMerchantTypeTab();
        bool YuMing(string ExhibitionHall);

        #endregion 

        
    }
} 
