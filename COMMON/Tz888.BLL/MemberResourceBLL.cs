using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// ҵ���߼���MemberResourceTab ��ժҪ˵����
    /// </summary>
    public class MemberResourceBLL
    {
        private readonly IMemberResource dal = DataAccess.CreateMemberResource();
        public MemberResourceBLL()
        { }
        #region  ��Ա����  
       
        /// <summary>
        ///  ��Ϣ���ҳ����ϴ���EnterpriseRegisterResult.aspx��
        /// </summary>       
        public void AddFromResult(Tz888.Model.MemberResourceModel model)
        {
            dal.AddFromResult(model);
        }
        public bool AddMemberCert(Tz888.Model.MemberResourceModel model)
        {
            return dal.AddMemberCert(model);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Tz888.Model.MemberResourceModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ResourceID)
        {
            dal.Delete(ResourceID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tz888.Model.MemberResourceModel GetModel(string LoginName)
        {
            return dal.GetModel(LoginName.ToString().Trim());
        }

        public List<Tz888.Model.MemberResourceModel> GetModelList(string LoginName, int ResourceProperty)
        {
            return dal.GetModelList(LoginName, ResourceProperty);
        }
        #endregion  ��Ա����
    }
}


