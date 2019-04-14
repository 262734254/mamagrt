using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.IDAL
{
    public interface ILeaveMsg
    {
        //读取回复留言
        Tz888.Model.LeaveMsg ReadComment(int ID, int type);//0 读取留言信息  1 读取回复留言
        //设置回复留言
        bool SetResponse(Tz888.Model.LeaveMsg model);
        //删除留言
        bool DeleteLeaveMsg(int ID, int flag);//0 虚拟删除留言  1 永远删除留言
        //发布留言管理
        bool PublishManageLeaveMsg(Tz888.Model.LeaveMsg model);
        //恢复留言至收件箱
        bool RestoreLeaveMsg(int ID);
        //统计留言条数
        int GetCount(long InfoID);
        //留言是否公开
        int IsAuditLeaveMsg(string IDStr, int audit);
    }
}
