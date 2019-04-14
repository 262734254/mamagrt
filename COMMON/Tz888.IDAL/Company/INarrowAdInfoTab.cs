using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Company
{
    public interface INarrowAdInfoTab
    {
        /// <summary>
        /// 窄告添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int NaAdd(Tz888.Model.Company.NarrowAdInfoModel model);
        /// <summary>
        /// 窄告搜索添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SearchAdd(Tz888.Model.Company.NarrowSearchModel model);
        /// <summary>
        /// 根据会员编号查询出用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelLoginName(int id);
        /// <summary>
        /// 窄告搜索表中，根据窄告编号，判断不能同时添加相同的帐号
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        int SearchLoginName(int id, string name);
        /// <summary>
        /// 查看别人窄告你的信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string NarrowName(string name);
        /// <summary>
        /// 根据窄告编号查询出搜索表中ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string NarrowID(int Id);
        /// <summary>
        /// 删除表中的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);
    }
}
