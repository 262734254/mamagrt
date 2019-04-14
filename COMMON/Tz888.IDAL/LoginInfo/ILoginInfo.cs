using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.LoginInfo
{
    public interface ILoginInfo
    {
        #region �޸�����       
        bool ChangePassword(string strLoginName,string strNewPassword);       
        #endregion 

        #region ͨ����¼����ȡ����������
        DataTable GetMemberNameByLoginName(string strLoginName, string strRoleName);	
		#endregion      

        #region  ��ȡ��Ϣ�б�        
        DataTable GetInfoList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);
        #endregion

        #region ��֤��Ա��¼
        DataTable AuthMemberLogin(string strLoginName,long lgCardNo,string strPassWord,bool IsOnlyCheck);
        #endregion
        
        #region ��̳��½��Ϣ����
        string BBSLoginUpdate(int userId, string ip, string truePassword);
        #endregion

        #region ����¼ʧ�ܴ���        
        int CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes);
        #endregion

        #region-- ��ѯ��¼��Ϣ�б�		
        DataTable GetLoginInfoList(string SelectCol, string Criteria, string Sort);
        #endregion

        #region
        DataTable GetLoginInfo(string LoginName);
        #endregion

        #region ��֤Ա����½
        DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            bool IsOnlyCheck);
        #endregion


        #region ��֤Ա����½
        DataTable  LmAuthMemberLogin(string strLoginName, long lgCardNo,  bool IsOnlyCheck);

        #endregion
        #region �����¼��־
        bool InsertLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP);
        #endregion

        bool CreateLoginErrorLog(string strLoginName, DateTime dtLoginTime, string strLoginIP, bool blFlag);
		
        
        ///--------------------------------------
        ///---20090811 wangwei
        ///--------------------------------------

        #region ��Ա������Ϣ��Ȩ����֤
        //��֤������ע���һ��Сʱ��������û�б��������ʻ�
        bool yanzheng(string loginName);
        #endregion

        #region �Ƿ��������û�
        int LockUser(string loginName, int AuditStatus);
        #endregion
    }
}
