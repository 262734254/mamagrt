using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model;
using System.Data;

namespace Tz888.IDAL.Register
{
    public interface IOrgRegister
    {
        #region ��˾�Ǽ�
        //ǰ̨��˾�Ǽ�
        int EnterpriseAdd(Tz888.Model.Register.EnterpriseInfoModel model);

        //��ȡ��˾�Ǽ�һ��Ϣ(Ԥ��)
        Tz888.Model.Register.EnterpriseInfoModel getEnterpriseModel(int EnterpriseID);

        //�޸�
        int EnterpriseUpdate(int EnterpriseID);

        //��ѯ
        DataTable getEnterpriseList();
        
        //���
        bool AuditEnterprise();

        //ɾ��
        bool DeleteEnterprise(int EnterpriseID);

        //��̬��

        #endregion 

        #region ���̻����Ǽ�
        //ǰ̨��˾�Ǽ�
        int GovernmentAdd(Tz888.Model.Register.GovernmentInfoModel model);

        //��ȡ��˾�Ǽ�һ��Ϣ(Ԥ��)
        Tz888.Model.Register.GovernmentInfoModel getGovernmentModel(int GovernmentID);

        //�޸�
        int GovernmentUpdate(int GovernmentID);

        //��ѯ
        DataTable getGovernmentList();

        //���
        bool AuditGovernment();

        //ɾ��
        bool DeleteGovernment(int GovernmentID);

        //��̬��

        //�Ƿ��ظ���ѯ

        #endregion 

    }
}
