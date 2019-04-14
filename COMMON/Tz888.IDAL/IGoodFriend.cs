using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Tz888.IDAL
{
    public interface IGoodFriend
    {
        void BlackListManage(int contactId,int flag);//黑名单管理  flag:0 加入黑名单    1 黑名单恢复好友 
        void DeleteFriend(int contactId);//彻底删除好友
        void AddFriend(Tz888.Model.GoodFriend model);//添加好友

        bool IsSpecices(string loginName, string contactName, int type);//黑名单用户，好友用户

        #region  防骚扰设置
        //读取设置
        Tz888.Model.GoodFriend GetFriendSet(string loginName);     
        //设置防骚扰
        void SetFriendSet(Tz888.Model.GoodFriend model);
        //好友需求更新
        DataTable ResourceRefresh(Tz888.Model.GoodFriend model);
        //好友资料更新
        DataTable MemberInfoRefresh(Tz888.Model.GoodFriend model);
        // --好友公司登记--
         bool EnterpriseRefresh(Tz888.Model.GoodFriend model);
        #endregion
    }
}
