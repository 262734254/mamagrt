using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    /// <summary>
    /// ���ƣ��Ƽ���Ϣ��
    /// ��ѯ��CommendVIW
    /// ��;��Ϊ�Ƽ���Ϣ�����ṩ��Ӧ�ķ���������
    /// ����ˣ�wangwei
    /// �������ڣ�2009-06-03
    /// </summary>
    public interface ICommendDAL
    {
        bool Send(Tz888.Model.Commend com);

        bool Update(Tz888.Model.Commend com);

        bool GetDetail(string Key);
        
        DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
        
        bool Insert(Tz888.Model.Commend commend);

        int GetListCount(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount);
    }
}
