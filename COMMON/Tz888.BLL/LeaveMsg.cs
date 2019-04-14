using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Tz888.DALFactory;
using Tz888.Model;
using Tz888.IDAL;


namespace Tz888.BLL
{
    public class LeaveMsg
    {
        private readonly Tz888.IDAL.ILeaveMsg dal = Tz888.DALFactory.DataAccess.CreateILeaveMsg();
        Tz888.BLL.SendNotice Noction = new Tz888.BLL.SendNotice();
        
        //读取留言
        public Tz888.Model.LeaveMsg GetComment(int ID, int type) //0 读取留言信息  1 读取回复留言
        {
            Tz888.Model.LeaveMsg model = new Tz888.Model.LeaveMsg();
            model = dal.ReadComment(ID,type);           
            return model;
        }
        
        //设置回复留言
        public bool SetResponse(Tz888.Model.LeaveMsg model)
        {
            bool result = false;
            result = dal.SetResponse(model);
            #region 留言回复通知
            if (result)
            {
                string Contents = model.LoginName+"回复了您的资源信息!";
                string Title = "留言回复通知";
                Noction.GetMaininfo(model.InfoID.ToString(), Contents, Title);
            }
            #endregion

            return result;
        }
        //删除留言
        public bool DeleteLeaveMsg(int ID, int flag)//flag 0 虚拟删除留言  1 永远删除留言
        {
            bool result = false;
            result = dal.DeleteLeaveMsg(ID,flag);
            return result;
        }
        //发布留言管理
        public bool PublishManageLeaveMsg(Tz888.Model.LeaveMsg model)
        {
            bool result = false;
            result = dal.PublishManageLeaveMsg(model);
            return result; 
        }
        //恢复至收到留言
        public bool RestoreLeaveMsg(int ID)
        {
            bool result = false;
            result = dal.RestoreLeaveMsg(ID);
            return result;
        }

        //统计信息的留言数目
        public int GetCount(long InfoID)
        {
            return dal.GetCount(InfoID);
        }

        public int IsAuditLeaveMsg(string IDStr, int audit)
        {
            return dal.IsAuditLeaveMsg(IDStr, audit);
        }
    }
}
