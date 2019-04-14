using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Company;
using System.Data;

namespace Tz888.IDAL.Company
{
   public  interface ICompanyShow
    {
       /// <summary>
       /// �����ҵչ��
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int AddShow(CompanyShow com);

       /// <summary>
       /// �����Դ������Ϣ
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int ZylmAddShow(CompanyShow com);
       /// <summary>
       /// �������������Ϣ
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int rzAddShow(CompanyShow com);

       /// <summary>
       /// ���Ͷ��������Ϣ
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int tzAddShow(CompanyShow com);


       /// <summary>
       /// ���
       /// </summary>
       /// <param name="com"></param>
       /// <returns></returns>
       int zfAddShow(CompanyShow com);
       /// <summary>
       /// �жϸ��û��Ƿ��Ѿ���������ҵչ��
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfUserName(string name);
        /// <summary>
        /// ͨ���û������һ�Ա�ĵ�����Ϣ
        /// </summary>
        /// <returns></returns>
        DataSet GetMemberInfoByName(string loginName);
       /// <summary>
       /// �жϸ��û�������չ����Ϣ�Ƿ����ͨ��
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfAudit(string name);
       /// <summary>
       /// �����û����һ�Ա����Ч��
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       string OverdueTime(string name);

       /// <summary>
       /// �жϸ��û��Ƿ��Ѿ���������Դ����
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfUserName(string name, int roleid);

       /// <summary>
       /// �жϸ��û��Ƿ��Ѿ���������Դ����
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfUserNameAudit(string name, int roleid);
       
       /// <summary>  
       /// �жϸ��û���������Դ�����Ƿ����ͨ��
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
       int IfAudit(string name, int roleid);
       
    }
}
