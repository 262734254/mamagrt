using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface IEnterprise
    {
        #region ǰ̨
        //��˾��Ϣ�Ǽ�
        bool AddEnterprise();
        //��˾��Ϣ���
        bool AuditEnterprise();        
        //��˾��Ϣ�޸�
        bool UpdateEnterprise();
        //����ϵ�����
        bool AddLinkMan();
        #endregion

        #region ��̨
        //��ѯ,Ԥ��
        Tz888.Model.Enterprise GetEnterprise();
        //ɾ��
        bool DeleteEnterprise();
        //��̬��

        #endregion
    }
}
