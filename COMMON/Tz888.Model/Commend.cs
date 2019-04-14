using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{	
    /// <summary>
    /// 名称：推荐信息表
    /// 查询：CommendVIW
    /// 用途：为推荐信息处理提供相应的方法和属性
    /// 设计人：wangwei
    /// 创建日期：20090603
    /// </summary>
    public class Commend
    {
        private long mstrID;
        private long mstrInfoID;	//发送人
        private string mstrSendBy;//收件人
        private string mstrreceivedBy;
        private string mstrLoginName;
        private bool mstrIsCollect;//是否收藏

        public Commend()
        {

        }

        #region  -- 属性 -------------------
        public long ID
        {
            get
            {
                return this.mstrID;
            }
            set
            {
                this.mstrID = value;
            }
        }
        public long InfoID
        {
            get
            {
                return this.mstrInfoID;
            }
            set
            {
                this.mstrInfoID = value;
            }
        }
        public string SendBy
        {
            get
            {
                return this.mstrSendBy;
            }
            set
            {
                this.mstrSendBy = value;
            }
        }
        public string receivedBy
        {
            get
            {
                return this.mstrreceivedBy;
            }
            set
            {
                this.mstrreceivedBy = value;
            }
        }
        public string LoginName
        {
            get
            {
                return this.mstrLoginName;
            }
            set
            {
                this.mstrLoginName = value;
            }
        }
        public bool IsCollect
        {
            get { return this.mstrIsCollect; }
            set { this.mstrIsCollect = value; }
        }
        #endregion
    }
}
