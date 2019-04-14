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
        //���÷�ɧ��
        public void SetFriendSet(Tz888.Model.GoodFriend model)
        {
            dal.SetFriendSet(model);
        }
        //��ȡ����
        public Tz888.Model.GoodFriend GetFriendSet(string loginName)
        {
            Tz888.Model.GoodFriend model = new Tz888.Model.GoodFriend();
            model = dal.GetFriendSet(loginName);
            return model;
        }
         //��Ӻ���
         public void AddFriend(Tz888.Model.GoodFriend model)
         {
             dal.AddFriend(model);
             SendNotice obj = new SendNotice();
             Conn con = new Conn();
             DataTable dt1 = con.GetList("LoginInfoTab", "NickName", "LoginID", 1, 1, 0, 1, "LoginName='"+model.LoginName+"'");
             DataTable dt2 = con.GetList("LoginInfoTab", "NickName", "LoginID", 1, 1, 0, 1, "LoginName='" + model.ContactName + "'");

             if (dt1.Rows.Count > 0&&dt2.Rows.Count > 0)
             {
                 string loginname1 = dt1.Rows[0]["NickName"].ToString().Trim();//�����
                 string loginname2 = dt2.Rows[0]["NickName"].ToString().Trim();//�������
                 string MobileText = "���ѱ���" + loginname1 + "�����Ϊ����,[������Ϣ���]";
                 string EmailText = "�𾴵�" + loginname2 + "�����ѱ���" + loginname1 + "�����Ϊ����";
                 string Title = "�������֪ͨ";
                 string SiteText = "���ѱ���" + loginname1 + "�����Ϊ����,[������Ϣ���]";
                 obj.SendSms(model.ContactName, MobileText, Title, SiteText, EmailText, "FriendAddNotice");
             }
         }
         //�������û��������û�
         public bool IsSpecies(string loginName, string contactName, int type)
         {
             bool result=dal.IsSpecices(loginName, contactName, type);
             return result;
         }
         //����������
         public void BlackListManage(int contactId, int flag)  //flag:0 ���������    1 �������ָ�����
         {
             dal.BlackListManage(contactId, flag);
         }
         //����ɾ������
         public void DeleteFriend(int contactId)
         {
             dal.DeleteFriend(contactId);
         }
         //�������ϸ�����ʾ
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
                     result = "����޸���";
                 }
                 else
                 {
                     result = dtInfomation.Rows[0]["remarks"].ToString();
                 }
             }
             else
             {
                 result = "����޸���";
             }
             return result;
         }
         //������Դ�����б�
         public DataTable ResourceRefreshDT(Tz888.Model.GoodFriend model)
         {
             return dal.ResourceRefresh(model);
         }
         //������Դ������ʾ
         
         public string  ResourceRefresh(Tz888.Model.GoodFriend model)
         {
             string result = "";
             DataTable dtResource = dal.ResourceRefresh(model);
             if (dtResource != null && dtResource.Rows.Count >= 0)
             {
                 int resourceCnt = dtResource.Rows.Count;
                 if (resourceCnt == 0)
                 {
                     result = "����޸���";
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
                 result = "����޸���";
             }
             return result;
         }
         //��˾�Ǽ�
         public bool EnterpriseResfresh(Tz888.Model.GoodFriend model)
         {
             return dal.EnterpriseRefresh(model);
         }
         //���Ѹ�����ʾ
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
         //        result = "����޸���";
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
         //        result = "����...";
         //    }
         //    return result;
         //}

    }
}
