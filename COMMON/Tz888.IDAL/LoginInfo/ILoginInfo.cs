using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL.LoginInfo
{
    public interface ILoginInfo
    {
        #region 修改密码       
        bool ChangePassword(string strLoginName,string strNewPassword);       
        #endregion 

        #region 通过登录名获取代理商名称
        DataTable GetMemberNameByLoginName(string strLoginName, string strRoleName);	
		#endregion      

        #region  获取信息列表        
        DataTable GetInfoList(string tblName, string strGetFields, string fldName,
            int PageSize, int PageIndex, int doCount, int OrderType, string strWhere);
        #endregion

        #region 验证会员登录
        DataTable AuthMemberLogin(string strLoginName,long lgCardNo,string strPassWord,bool IsOnlyCheck);
        #endregion
        
        #region 论坛登陆信息更新
        string BBSLoginUpdate(int userId, string ip, string truePassword);
        #endregion

        #region 检查登录失败次数        
        int CheckLoginErrorTime(string strLoginName, int LoginTimeRange, int AllowErrorTimes);
        #endregion

        #region-- 查询登录信息列表		
        DataTable GetLoginInfoList(string SelectCol, string Criteria, string Sort);
        #endregion

        #region
        DataTable GetLoginInfo(string LoginName);
        #endregion

        #region 验证员工登陆
        DataTable Authenticate(
            string strLoginName,
            string strPassWord,
            bool IsOnlyCheck);
        #endregion


        #region 验证员工登陆
        DataTable  LmAuthMemberLogin(string strLoginName, long lgCardNo,  bool IsOnlyCheck);

        #endregion
        #region 插入登录日志
        bool InsertLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP);
        #endregion

        bool CreateLoginErrorLog(string strLoginName, DateTime dtLoginTime, string strLoginIP, bool blFlag);
		
        
        ///--------------------------------------
        ///---20090811 wangwei
        ///--------------------------------------

        #region 会员发布信息的权限验证
        //验证条件：注册后一个小时、必须是没有被锁定的帐户
        bool yanzheng(string loginName);
        #endregion

        #region 是否锁定该用户
        int LockUser(string loginName, int AuditStatus);
        #endregion
    }
}
