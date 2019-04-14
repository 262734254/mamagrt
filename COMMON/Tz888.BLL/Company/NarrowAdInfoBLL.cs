using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;
using Tz888.IDAL.Company;
using Tz888.DALFactory;

namespace Tz888.BLL.Company
{
    public class NarrowAdInfoBLL
    {
        private readonly INarrowAdInfoTab dal = DataAccess.CreateNarrow();
        /// <summary>
        /// խ����Ϣ���
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int NaAdd(NarrowAdInfoModel model)
        {
            return dal.NaAdd(model);
        }
        /// <summary>
        /// խ��������Ϣ���
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SearchAdd(NarrowSearchModel model)
        {
            return dal.SearchAdd(model);
        }
        /// <summary>
        /// ���ݻ�Ա��Ų�ѯ���û���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelLoginName(int id)
        {
            return dal.SelLoginName(id);
        }
        /// <summary>
        /// խ���������У�����խ���ţ��жϲ���ͬʱ�����ͬ���ʺ�
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SearchLoginName(int id, string name)
        {
            return dal.SearchLoginName(id,name);
        }
        /// <summary>
        /// �鿴����խ�������Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string NarrowName(string name)
        {
            return dal.NarrowName(name);
        }
        /// <summary>
        /// ɾ�����е���Ϣ
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            return dal.Delete(Id);
        }
    }
}
