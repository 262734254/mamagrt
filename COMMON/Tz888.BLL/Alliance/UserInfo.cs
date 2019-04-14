using System;
using System.Collections.Generic;
using System.Text;
using System.Data; 
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
    public class UserInfo
    {
        private readonly IUserInfo dal = DataAccess.CreateIUserInfo(); 
        /// <summary>
        /// 添加一个用户
        /// </summary>
        public bool Add(Tz888.Model.UserInfo model)
        { 
            return dal.Add(model);
        }
        /// <summary>
        /// 修改用户资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateUserInfo(Tz888.Model.UserInfo model)
        { 
            return dal.UpdateUserInfo(model);
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool UpdatePassWord(string UserName, string PassWord)
        { 
            return dal.UpdatePassWord(UserName, PassWord);
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public bool ValidatePassWord(string UserName, string PassWord)
        { 
            return dal.ValidatePassWord(UserName, PassWord);
        }

        /// <summary>
        /// 登陆记录
        /// </summary>
        /// <param name="UsreName"></param>
        /// <param name="LoginIP"></param>
        public bool InsertLoginLog(string strLoginName, string strRoleName, DateTime dtLoginTime, string strLoginIP)
        { 
           return dal.InsertLoginLog(strLoginName,strRoleName,dtLoginTime,strLoginIP);
        }

        /// <summary>
        /// 用户详细资料
        /// </summary>
        public Tz888.Model.UserInfo GetModel(string UserName)
        { 
            return dal.GetModel(UserName);
        }

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
        public DataSet dsGetUserTabList(
                                     string SelectStr,
                                     string Criteria,
                                     string Sort,
                                     long Page,
                                     long CurrentPageRow,
                                     out long TotalCount
                                    )
        { 
            return dal.dsGetUserTabList(SelectStr, Criteria, Sort, Page, CurrentPageRow, out TotalCount);
        }

                /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
            return dal.Delete(UserID);
        }
    }
}
