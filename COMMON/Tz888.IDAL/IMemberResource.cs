using System;
using System.Data;
using System.Collections.Generic;
using System.Text;


namespace Tz888.IDAL
{
    /// <summary>
	/// �ӿڲ�IMemberResourceTab ��ժҪ˵����
	/// </summary>
    public interface  IMemberResource
    {
        #region  ��Ա����
		
		   /// <summary>
        ///  ��Ϣ���ҳ����ϴ���EnterpriseRegisterResult.aspx��
        /// </summary>       
        void AddFromResult(Tz888.Model.MemberResourceModel model);
        bool AddMemberCert(Tz888.Model.MemberResourceModel model);
		/// <summary>
		/// ����һ������
		/// </summary>
        void Update(Tz888.Model.MemberResourceModel model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int ResourceID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        Tz888.Model.MemberResourceModel GetModel(string LoginName);

          /// <summary>
        /// ��ȡָ�����еǼ�ͼƬ��Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
         List<Tz888.Model.MemberResourceModel> GetModelList(string LoginName, int ResourceProperty);
        
		#endregion  ��Ա����
	}
}
