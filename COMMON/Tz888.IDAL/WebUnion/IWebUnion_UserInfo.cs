using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IWebUnion_UserInfo 
    {

                /// <summary>
        ///  增加一条数据
        /// </summary>
        bool Add(Tz888.Model.WebUnion_UserInfo model);

                /// <summary>
        /// 更新用户资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpdateWebUnion_UserInfo(Tz888.Model.WebUnion_UserInfo model);

                /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        bool UpdatePassWord(string UserName, string PassWord);

                /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        bool ValidatePassWord(string UserName, string PassWord);

                /// <summary>
        /// 插入登录日志
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="LoginIP"></param>
        bool InsertLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP);

                /// <summary>
        /// 用户详细信息
        /// </summary>
        Tz888.Model.WebUnion_UserInfo GetModel(string UserName);

                /// <summary>
        /// 联盟申请信息
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
        /// 删除一条数据
        /// </summary>
        bool Delete(int UserID);
    }
}
