using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.IDAL.Common;
using Tz888.IDAL;
 
using Tz888.Model;

namespace Tz888.BLL
{
    public class MemberManageInfoBll
    {
        private readonly ICommonFunction dal = Tz888.DALFactory.DataAccess.CreateICommon_CommonFunction();
        private readonly IMemberInfo dalMemberInfo = Tz888.DALFactory.DataAccess.CreateIMemberManageInfo();

        #region-- 已发布付费记录数，积分和，点数和 ---------
        /// <summary>
        /// 取已发布付费记录数，积分和，点数和
        /// </summary>	
        /// <returns>是否操作成功（true成功，false失败）</returns>
        public bool GetInfoPublishNoFree(string LoginName)
        {
            Tz888.Model.MemberManageInfo memberInfo = new Tz888.Model.MemberManageInfo();

            
            bool blReturn = false;
            long lgCurrentPage = 1;
            long lgPageCount = 0;
            DataView dv = dal.GetListSet("ConsumeRecTabList",
                "COUNT(ID) AS Count,SUM(IntegralNum) AS IntegralSum, SUM(PointCount) AS Point",
                "LoginName='" + LoginName + "' AND IsPublishItem=1 AND InfoID IS NOT NULL",
                "",
                ref lgCurrentPage,
                -1,
                ref lgPageCount);

            if (dv != null && dv.Count == 1)
            {
                memberInfo.InfoAllCount = Convert.ToInt32(dv[0]["Count"]);
                int iTempTest = memberInfo.InfoPublishNoFreeIntegralSum;
                blReturn = true;
            }
            return (blReturn);
        }
        #endregion  

             
        public DataView GetMemberInfoByLoginName(string LoginName)
        {
            return dalMemberInfo.GetMemberInfoByLoginName(LoginName);
        }

        /// <summary>
        /// Search for an MemberManage given it's unique identifier
        /// </summary>
        /// <param name="itemId">Unique identifier for an MemberManage</param>
        /// <returns>An MemberManageInfo business entity</returns>
        public MemberManageInfo GetMemberManageInfo(string LoginName)
        {
            // Validate input
            if (string.IsNullOrEmpty(LoginName))
                return null;

            // Use the dal to search by LoginName
            MemberManageInfo objMMI  = dalMemberInfo.objGetMemberInfoByLoginName(LoginName);
            return objMMI;
        }
        #region ------会员删除------
        public void DeleteLogin(string loginName)
        {
            dalMemberInfo.DeleleMember(loginName);
            return;
        }
        #endregion
    }
}
