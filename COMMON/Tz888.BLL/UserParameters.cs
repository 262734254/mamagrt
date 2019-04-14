using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using Tz888.IDAL;
namespace Tz888.BLL
{
    public class UserParameters
    {
        private static readonly IUserParameters dal = Tz888.DALFactory.DataAccess.CreateUserParameters();
        /// <summary>
        /// 设置通知号码和通知邮箱
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="NoticeEmail"></param>
        /// <param name="NoticeMobile"></param>
        /// <returns></returns>
        public bool NoticeSet(string LoginName, string NoticeEmail, string NoticeMobile)
        {
            return dal.NoticeSet(LoginName, NoticeEmail, NoticeMobile);
        }
        public bool MachSet(Tz888.Model.UserParameters model)
        {
            return dal.MachSet(model);
        }
        /// <summary>
        /// 通知方式设置
        /// </summary>
        /// <returns></returns>
        public bool NoticeTypeSet(Tz888.Model.UserParameters model)
        {
            return dal.NoticeTypeSet(model);
        }

    }
}
