using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace Tz888.IDAL
{
    /// <summary>
	/// 接口层IMemberResourceTab 的摘要说明。
	/// </summary>
    public interface  IMemberResource
    {
        #region  成员方法
		
		   /// <summary>
        ///  信息结果页面的上传（EnterpriseRegisterResult.aspx）
        /// </summary>       
        void AddFromResult(Tz888.Model.MemberResourceModel model);
        bool AddMemberCert(Tz888.Model.MemberResourceModel model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
        void Update(Tz888.Model.MemberResourceModel model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int ResourceID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        Tz888.Model.MemberResourceModel GetModel(string LoginName);

          /// <summary>
        /// 获取指定所有登记图片信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
         List<Tz888.Model.MemberResourceModel> GetModelList(string LoginName, int ResourceProperty);
        
		#endregion  成员方法
	}
}
