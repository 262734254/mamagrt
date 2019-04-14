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
        /// ���ר���ƹ���Ϣ
        /// </summary>
        /// <returns></returns>
        int AddSubjectExtend(SubjectExtendModel model);
        /// <summary>
        /// �޸��ƹ���Ϣ
        /// </summary>
        /// <returns></returns>
        int ModfiySubjectExtend(SubjectExtendModel model, int id);
        /// <summary>
        /// ɾ���ƹ���Ϣ
        /// </summary>
        /// <returns></returns>
        int DeleteSubjectExtend(int id);
        /// <summary>
        /// ���ݱ�Ų�ѯ������Ӧ����Ϣ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SubjectExtendModel SelSubject(int id);
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <returns></returns>
        DataTable GetListT(string TableViewName, string Key, string SelectStr, string Criteria, string Sort,
            ref long CurrentPage, long PageSize, ref long TotalCount);
        
    }
}
