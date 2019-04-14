using System;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;

namespace Tz888.BLL
{
     public class GoodFriend
    {      
        private readonly IGoodFriend dal = DataAccess.CreateIGoodFriend(); 
        //设置防骚扰
        public void SetFriendSet(Tz888.Model.GoodFriend model)
        {
            dal.SetFriendSet(model);
        }
        //读取设置
        public Tz888.Model.GoodFriend GetFriendSet(string loginName)
        {
            Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
            model = dal.GetFriendSet(loginName);
            return model;
        }
         //添加好友
         public void AddFriend(Tz888.Model.GoodFriend model)
         {
             dal.AddFriend(model);
             SendNotice obj = new SendNotice();
             Conn con = new Conn();
             DataTable dt1 = con.GetList("LoginInfoTab", "NickName", "LoginID", 1, 1, 0, 1, "LoginName='"+model.LoginName+"'");
             DataTable dt2 = con.GetList("LoginInfoTab", "NickName", "LoginID", 1, 1, 0, 1, "LoginName='" + model.ContactName + "'");

             if (dt1.Rows.Count > 0&&dt2.Rows.Count > 0)
             {
                 string loginname1 = dt1.Rows[0]["NickName"].ToString().Trim();//添加人
                 string loginname2 = dt2.Rows[0]["NickName"].ToString().Trim();//被添加人
                 string MobileText = "您已被“" + loginname1 + "”添加为好友,[此条信息免费]";
                 string EmailText = "尊敬的" + loginname2 + "，您已被“" + loginname1 + "”添加为好友";
                 string Title = "好友添加通知";
                 string SiteText = "您已被“" + loginname1 + "”添加为好友,[此条信息免费]";
                 obj.SendSms(model.ContactName, MobileText, Title, SiteText, EmailText, "FriendAddNotice");
             }
         }
         //黑名单用户、好友用户
         public bool IsSpecies(string loginName, string contactName, int type)
         {
             bool result=dal.IsSpecices(loginName, contactName, type);
             return result;
         }
         //黑名单管理
         public void BlackListManage(int contactId, int flag)  //flag:0 加入黑名单    1 黑名单恢复好友
         {
             dal.BlackListManage(contactId, flag);
         }
         //彻底删除好友
         public void DeleteFriend(int contactId)
         {
             dal.DeleteFriend(contactId);
         }
         //好友资料更新显示
         public DataTable MemberInfoRefreshDt(Tz888.Model.GoodFriend model)
         {
             return dal.MemberInfoRefresh(model);
         }
         public string  MemberInfoRefresh(Tz888.Model.GoodFriend model)
         {
             string result = "";
             DataTable dtInfomation = dal.MemberInfoRefresh(model);
             if (dtInfomation != null && dtInfomation.Rows.Count >= 0)
             {
                 int InfomationCnt = dtInfomation.Rows.Count;


                 if (InfomationCnt == 0)
                 {
                     result = "最近无更新";
                 }
                 else
                 {
                     result = dtInfomation.Rows[0]["remarks"].ToString();
                 }
             }
             else
             {
                 result = "最近无更新";
             }
             return result;
         }
         //好友资源更新列表
         public DataTable ResourceRefreshDT(Tz888.Model.GoodFriend model)
         {
             return dal.ResourceRefresh(model);
         }
         //好友资源更新显示
         
         public string  ResourceRefresh(Tz888.Model.GoodFriend model)
         {
             string result = "";
             DataTable dtResource = dal.ResourceRefresh(model);
             if (dtResource != null && dtResource.Rows.Count >= 0)
             {
                 int resourceCnt = dtResource.Rows.Count;
                 if (resourceCnt == 0)
                 {
                     result = "最近无更新";
                 }
                 else if (resourceCnt == 1)
                 {
                     result = dtResource.Rows[0]["htmlFile"].ToString();
                 }
                 else
                 {
                     result = resourceCnt.ToString();
                 }
             }
             else
             {
                 result = "最近无更新";
             }
             return result;
         }
         //公司登记
         public bool EnterpriseResfresh(Tz888.Model.GoodFriend model)
         {
             return dal.EnterpriseRefresh(model);
         }
         //好友更新显示
         //public string FriendRefresh(Tz888.Model.GoodFriend model)
         //{
         //    DataTable dtResource = dal.ResourceRefresh(model);
         //    DataTable dtInfomation = dal.MemberInfoRefresh(model);
             
         //    int resourceCnt=dtResource.Rows.Count;
         //    int InfomationCnt=dtInfomation.Rows.Count;
         //    int refreshCnt = resourceCnt + InfomationCnt;
         //    string result = "";
         //    if (refreshCnt == 0)
         //    {
         //        result = "最近无更新";
         //    }
         //    else if (refreshCnt == 1)
         //    {
         //        if (resourceCnt == 1)
         //        {
         //            result = dtResource.Rows[0]["htmlFile"].ToString();
         //        }
         //        else if (InfomationCnt == 1)
         //        {
         //            result = dtInfomation.Rows[0]["remarks"].ToString();
         //        }
         //    }
         //    else
         //    {
         //        result = "更多...";
         //    }
         //    return result;
         //}

    }
}
