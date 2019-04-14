using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model.Subject;
using Tz888.IDAL.Subject;

namespace Tz888.BLL.Subject
{
    
    public class SubjectExtendBLL
    {
        private readonly ISubjectExtend dal = DataAccess.CreateSubject();

        #region 添加专题推广信息
        public int AddSubjectExtend(SubjectExtendModel model)
        {
            return dal.AddSubjectExtend(model);
        }
        #endregion

        #region 修改专题推广信息
        public int ModfiySubjectExtend(SubjectExtendModel model, int id)
        {
            return dal.ModfiySubjectExtend(model,id);
        }
        #endregion

        #region 删除专题推广信息
        public int DeleteSubjectExtend(int id)
        {
            return dal.DeleteSubjectExtend(id);
        }
        #endregion

        #region 根据编号得出实体类信息
        public SubjectExtendModel SelSubject(int id)
        {
            return dal.SelSubject(id);
        }
        #endregion

        #region 分页
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName,Key,SelectStr,Criteria,Sort,ref CurrentPage,PageSize,ref TotalCount);
        }
        #endregion
    }
}
