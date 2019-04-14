using System;
using System.Collections.Generic;
using System.Text;
using Tz888.DALFactory;
using Tz888.IDAL.Company;
using System.Data;

namespace Tz888.BLL.Company
{
     public class CompanyShowBLL
    {
         private readonly ICompanyShow dal = DataAccess.CreateCompanyShow();
         /// <summary>
         /// ���չ��
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int AddShow(Tz888.Model.Company.CompanyShow model)
         {
             return dal.AddShow(model);
         }
         /// <summary>
         /// ���չ��
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int ZylmAddShow(Tz888.Model.Company.CompanyShow model)
         {
             return dal.ZylmAddShow(model);
         }
         /// <summary>
        /// ��������ظ�ͨ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         public int rzAddShow(Tz888.Model.Company.CompanyShow model)
         {
             try
             {
                 return dal.rzAddShow(model);
             }
             catch (Exception)
             {
                 
                 throw;
             }
         }

         /// <summary>
         /// ���Ͷ���ظ�ͨ
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int tzAddShow(Tz888.Model.Company.CompanyShow model)
         {
             try
             {
                 return dal.tzAddShow(model);
             }
             catch (Exception)
             {

                 throw;
             }
         }

         /// <summary>
         /// ���רҵ�����ظ�ͨ
         /// </summary>
         /// <param name="model"></param>
         /// <returns></returns>
         public int zfAddShow(Tz888.Model.Company.CompanyShow model)
         {
             try
             {
                 return dal.zfAddShow(model);
             }
             catch (Exception)
             {

                 throw;
             }
         }
         /// <summary>
        /// �жϸ��û��Ƿ��Ѿ���������ҵչ��
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         public int IfUserName(string name)
         {
             return dal.IfUserName(name);
         }
              /// <summary>
        /// ͨ���û������һ�Ա�ĵ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetMemberInfoByName(string loginName)
        {
            return dal.GetMemberInfoByName(loginName);
        }
        /// <summary>
        /// �жϸ��û��Ƿ��Ѿ���������Դ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfUserName(string name, int roleid)
        {
            return dal.IfUserName(name, roleid);
        }
        /// <summary>  
        /// �жϸ��û���������Դ�����Ƿ����ͨ��
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int IfAudit(string name, int roleid)
        {
            
            return dal.IfAudit(name,roleid);
        }
         /// <summary>
         /// �жϸ��û�������չ����Ϣ�Ƿ����ͨ��
         /// </summary>
         /// <param name="name"></param>
         /// <returns></returns>
         public int IfAudit(string name)
         {
             return dal.IfAudit(name);
         } /// <summary>
        /// �жϸ��û��Ƿ��Ѿ���������Դ����
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
         public int IfUserNameAudit(string name, int roleid)
        {
            return dal.IfUserNameAudit(name, roleid);
        }
         
    }
}
