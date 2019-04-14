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

        #region ���ר���ƹ���Ϣ
        public int AddSubjectExtend(SubjectExtendModel model)
        {
            return dal.AddSubjectExtend(model);
        }
        #endregion

        #region �޸�ר���ƹ���Ϣ
        public int ModfiySubjectExtend(SubjectExtendModel model, int id)
        {
            return dal.ModfiySubjectExtend(model,id);
        }
        #endregion

        #region ɾ��ר���ƹ���Ϣ
        public int DeleteSubjectExtend(int id)
        {
            return dal.DeleteSubjectExtend(id);
        }
        #endregion

        #region ���ݱ�ŵó�ʵ������Ϣ
        public SubjectExtendModel SelSubject(int id)
        {
            return dal.SelSubject(id);
        }
        #endregion

        #region ��ҳ
        public DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort, ref long CurrentPage, long PageSize, ref long TotalCount)
        {
            return dal.GetListT(TableViewName,Key,SelectStr,Criteria,Sort,ref CurrentPage,PageSize,ref TotalCount);
        }
        #endregion
    }
}
