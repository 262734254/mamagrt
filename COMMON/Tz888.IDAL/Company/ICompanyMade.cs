using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.Company
{
   public  interface ICompanyMade
    {
       /// <summary>
       /// �������
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
        int Add(Tz888.Model.Company.CompanyMadeModel model);
       /// <summary>
       /// ��ҳ��ѯ
       /// </summary>
       /// <returns></returns>
       DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
           ref long CurrentPage, long PageSize, ref long TotalCount);
       /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Tz888.Model.Company.CompanyMadeModel model, int id);
       /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int MadeID);

       /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       Tz888.Model.Company.CompanyMadeModel GetModel(int MadeID);
    }
}
