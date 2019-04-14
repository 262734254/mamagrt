using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
using Tz888.IDAL.Register;
using System.Data;
using Tz888.DALFactory;
namespace Tz888.BLL.Register
{
    public class GovernmentRegisterBLL
    {
        private readonly IGovernmentRegister dal = DataAccess.CreateGovernmentRegister();
        //ǰ̨��˾�Ǽ�
        public int GovernmentAdd(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels, 
            List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            return dal.GovernmentAdd(model, ContactModel, ContactManModels, infoResourceModels); 
        }

        //����ע��
        public void GovernmentReg(GovernmentInfoModel model)
        {
            dal.GovernmentReg(model);
        }

        //��ȡ��˾�Ǽ�һ��Ϣ(Ԥ��)
        public DataTable getGovernmentModel(string LoginName)
        {
            return dal.getGovernmentModel(LoginName);
        }
        //�޸�
        public int GovernmentUpdate(Tz888.Model.Register.GovernmentInfoModel model,
                Tz888.Model.Register.OrgContactModel ContactModel,
                List<Tz888.Model.Register.OrgContactMan> ContactManModels,
              List<Tz888.Model.MemberResourceModel> infoResourceModels)
        {
            return dal.GovernmentUpdate(model, ContactModel, ContactManModels, infoResourceModels);
        }

        //��ѯ
        public DataTable getGovernmentList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere)
        {
            return dal.getGovernmentList(tblName, strGetFields, fldName,
          PageSize, PageIndex, doCount, OrderType, strWhere);
        }

        //���
        public bool AuditGovernment()
        {
            return dal.AuditGovernment();
        }

         //ˢ��
        public bool UpdateRefresh(int EnterpriseID)
        {
            return dal.UpdateRefresh(EnterpriseID);
        }
        //ɾ��
        public bool DeleteGovernment(string loginName)
        {
            return dal.DeleteGovernment(loginName);
        }
   
        //��̬��

        //�Ƿ��ظ���ѯ

        //��������
        public DataTable getGovernmentSubjectType()
        {
            DataTable dt = null;
            //con.GetList();//���������û��
            return dt;
        }
        //�������
         public bool YuMing(string ExhibitionHall) 
         {
            return dal.YuMing(ExhibitionHall);
        }
        //��ȡ��������
        public DataTable getMerchantTypeTab()
        {
            return dal.getMerchantTypeTab();
        }

    }
}
