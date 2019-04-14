using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL.Company;
using System.Data;

namespace Tz888.BLL.Company
{
    public class CompanyMadeBLL
    {
        private readonly ICompanyMade dal = DataAccess.CreateCompanyMade();
        /// <summary>
		/// ����һ������
		/// </summary>
        public int Add(Tz888.Model.Company.CompanyMadeModel model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Tz888.Model.Company.CompanyMadeModel model, int id)
        {
            return dal.Update(model,id);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int MadeID)
        {
            return dal.Delete(MadeID);
        }


        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Tz888.Model.Company.CompanyMadeModel GetModel(int MadeID)
        {
            return dal.GetModel(MadeID);
        }
        #region ��ҳ��ѯ
        /// <summary>
        /// ��test���ݿ�
        /// </summary>
        /// <param name="TableViewName">����</param>
        /// <param name="Key">����</param>
        /// <param name="SelectStr">��ѯ�ֶ�</param>
        /// <param name="Criteria">����</param>
        /// <param name="Sort">�����ֶ�</param>
        /// <param name="CurrentPage">��ǰҳ</param>
        /// <param name="PageSize">ҳ��С</param>
        /// <param name="TotalCount">�ܼ�¼</param>
        /// <returns></returns>
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName,Key,SelectStr,Criteria,Sort,ref CurrentPage,PageSize,ref TotalCount);
        }
        #endregion
    }
}
