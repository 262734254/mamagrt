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
        /// 窄告信息添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int NaAdd(NarrowAdInfoModel model)
        {
            return dal.NaAdd(model);
        }
        /// <summary>
        /// 窄告搜索信息添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SearchAdd(NarrowSearchModel model)
        {
            return dal.SearchAdd(model);
        }
        /// <summary>
        /// 根据会员编号查询出用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string SelLoginName(int id)
        {
            return dal.SelLoginName(id);
        }
        /// <summary>
        /// 窄告搜索表中，根据窄告编号，判断不能同时添加相同的帐号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int SearchLoginName(int id, string name)
        {
            return dal.SearchLoginName(id,name);
        }
        /// <summary>
        /// 查看别人窄告你的信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string NarrowName(string name)
        {
            return dal.NarrowName(name);
        }
        /// <summary>
        /// 删除表中的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            return dal.Delete(Id);
        }
    }
}
