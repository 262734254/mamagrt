using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IWebUnion_UserInfo 
    {

                /// <summary>
        ///  ����һ������
        /// </summary>
        bool Add(Tz888.Model.WebUnion_UserInfo model);

                /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateWebUnion_UserInfo(Tz888.Model.WebUnion_UserInfo model);

                /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        bool UpdatePassWord(string UserName, string PassWord);

                /// <summary>
        /// ��֤����
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        bool ValidatePassWord(string UserName, string PassWord);

                /// <summary>
        /// �����¼��־
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="LoginIP"></param>
        bool InsertLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP);

                /// <summary>
        /// �û���ϸ��Ϣ
        /// </summary>
        Tz888.Model.WebUnion_UserInfo GetModel(string UserName);

                /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="SelectStr"></param>
        /// <param name="Criteria"></param>
        /// <param name="Sort"></param>
        /// <param name="Page"></param>
        /// <param name="CurrentPageRow"></param>
        /// <param name="TotalCount"></param>
        /// <returns></returns>
        DataSet dsGetNetUserTabList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                    );
         

                /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int UserID);
    }
}
