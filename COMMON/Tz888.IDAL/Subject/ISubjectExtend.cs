using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.Model.Subject;

namespace Tz888.IDAL.Subject
{
    public  interface ISubjectExtend
    {
        /// <summary>
        /// 添加专题推广信息
        /// </summary>
        /// <returns></returns>
        int AddSubjectExtend(SubjectExtendModel model);
        /// <summary>
        /// 修改推广信息
        /// </summary>
        /// <returns></returns>
        int ModfiySubjectExtend(SubjectExtendModel model, int id);
        /// <summary>
        /// 删除推广信息
        /// </summary>
        /// <returns></returns>
        int DeleteSubjectExtend(int id);
        /// <summary>
        /// 根据编号查询出所对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SubjectExtendModel SelSubject(int id);
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount);
        
    }
}
