using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL.Company
{
    public interface INarrowAdInfoTab
    {
        /// <summary>
        /// խ�����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int NaAdd(Tz888.Model.Company.NarrowAdInfoModel model);
        /// <summary>
        /// խ���������
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SearchAdd(Tz888.Model.Company.NarrowSearchModel model);
        /// <summary>
        /// ���ݻ�Ա��Ų�ѯ���û���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        string SelLoginName(int id);
        /// <summary>
        /// խ���������У�����խ���ţ��жϲ���ͬʱ�����ͬ���ʺ�
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        int SearchLoginName(int id, string name);
        /// <summary>
        /// �鿴����խ�������Ϣ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string NarrowName(string name);
        /// <summary>
        /// ����խ���Ų�ѯ����������ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string NarrowID(int Id);
        /// <summary>
        /// ɾ�����е���Ϣ
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);
    }
}
