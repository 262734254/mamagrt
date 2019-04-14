using System;
using System.Collections.Generic;
using System.Text;
using Tz888.IDAL.Company;
using Tz888.DALFactory;
using Tz888.Model.Company;
using System.Data;

namespace Tz888.BLL.Company
{
    
    public class CompanyBLL
    {
        private readonly ICompanyInfoTab dal = DataAccess.CreateCompany();
        /// <summary>
        /// ��ҵ��Ƭ���
        /// </summary>
        /// <returns></returns>
        public int Company_Add(CompanyModel model)
        {
            return dal.Company_Add(model);
        }
        /// <summary>
        /// ��ҵ��Ƭ�޸�
        /// </summary>
        /// <returns></returns>
        public int Company_Update(CompanyModel model, int id)
        {
            return dal.Company_Update(model,id);
        }
        #region �ж��Ƿ񷢲�����ҵ��Ƭ
        /// <summary>
        /// �ж��Ƿ񷢲�����ҵ��Ƭ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfCompany(string name)
        {
            return dal.IfCompany(name);
        }
        #endregion

        #region �����û����������״̬
        /// <summary>
        /// �����û����������״̬
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SelAdution(string name)
        {
            return dal.SelAdution(name);
        }
         #endregion
        /// <summary>
        /// �����û���������ص���Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public CompanyModel SelCompany(string name)
        {
            return dal.SelCompany(name);
        }

        /// <summary>
        /// ��ȡʡ���б�
        /// </summary>
        /// <returns></returns>
        public DataTable GetProvinceList()
        {
            return dal.GetProvinceList();
        }

        /// <summary>
        /// �����б�
        /// </summary>
        /// <param name="ProvinceID"></param>
        /// <returns></returns>
        public DataTable GetCity(string ProvinceID)
        {
            return dal.GetCity(ProvinceID);
        }

        ///// <summary>
        ///// ��ѯ��ϵ����Ϣ
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string SelLinkName(int id)
        //{
        //    return dal.SelLinkName(id);
        //}
    }
}
