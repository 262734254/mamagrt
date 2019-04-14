using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL;

namespace Tz888.BLL
{
    /// <summary>
    /// 业务逻辑类MemberResourceTab 的摘要说明。
    /// </summary>
    public class MemberResourceBLL
    {
        private readonly IMemberResource dal = DataAccess.CreateMemberResource();
        public MemberResourceBLL()
        { }
        #region  成员方法  
       
        /// <summary>
        ///  信息结果页面的上传（EnterpriseRegisterResult.aspx）
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
        /// 更新一条数据
        /// </summary>
        public void Update(Tz888.Model.MemberResourceModel model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ResourceID)
        {
            dal.Delete(ResourceID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Tz888.Model.MemberResourceModel GetModel(string LoginName)
        {
            return dal.GetModel(LoginName.ToString().Trim());
        }

        public List<Tz888.Model.MemberResourceModel> GetModelList(string LoginName, int ResourceProperty)
        {
            return dal.GetModelList(LoginName, ResourceProperty);
        }
        #endregion  成员方法
    }
}


