using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.MeberLogin
{
    public class MemberIndexBLL
    {
        MemberIndex member = new MemberIndex();
        PayManage PayMg = new PayManage();
        WaitList wait = new WaitList();
        InfoView info = new InfoView();
        BuyList buy = new BuyList();
        Receive re = new Receive();
        #region 首页
        public string SelMemberNews(string name)
        {
            return member.SelMemberNews(name);
        }
         //查找积分
        public int SelJiFen(string name)
        {
            return member.SelJiFen(name);
        }
        //我的项目
        public string SelItem(string name)
        {
            return member.SelItem(name);
        }
        //查找未读短信
        public int SelInnerInfo(string name)
        {
            return member.SelInnerInfo(name);
        }
         //查找最新项目
        public string SelLatest()
        {
            return member.SelLatest();
        }
        #endregion
        #region 审核中表格内容
        /// <summary>
        /// 查询会员内容
        /// </summary>
        /// <param name="name">登录名</param>
        /// <param name="statu">审核状态</param>
        /// <param name="n">当前页面数</param>
        /// <returns></returns>
        public string AjaxStatus(string name, int statu, int n, string InfoType, string title)
        {
            return member.AjaxStatus(name,statu,n,InfoType,title);

        }
        /// <summary>
        /// 查询总条数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statu"></param>
        /// <returns></returns>
        public int pageIndex(string name, int statu, string InfoType, string title)
        {
            return member.pageIndex(name,statu,InfoType,title);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statu"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string pageCont(string name, int statu, int n, string InfoType, string title)
        {
            return member.pageCont(name,statu,n,InfoType,title);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public int SelDelMain(string InfoID)
        {
            return member.SelDelMain(InfoID);
        }
        #endregion
        #region 充值信息
                /// <summary>
        /// 充值订单信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="n">第几页</param>
        /// <param name="time">时间</param>
        /// <param name="Pay">支付方式</param>
        /// <returns></returns>
        public string StrikeOrder(string name,int n,string time,string Pay)
        {
            return PayMg.StrikeOrder(name,n,time,Pay);
        }
        /// <summary>
        /// 查询充值订单总共多少条数据
        /// </summary>
        /// <returns></returns>
        public int PageOrder(string name,string time, string pay)
        {
            return PayMg.PageOrder(name,time,pay);
        }
        /// <summary>
        /// 绑定分页
        /// </summary>
        /// <returns></returns>
        public string PageOrderIndex(string name, int n, string time, string pay)
        {
            return PayMg.PageOrderIndex(name,n,time,pay);
        }
        #endregion

        #region 充值记录表
        /// <summary>
        /// 充值记录信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="n">第几页</param>
        /// <param name="time">时间</param>
        /// <param name="Pay">支付方式</param>
        /// <returns></returns>
        public string StrikeRec(string name, int n, string time, string pay)
        {
            return PayMg.StrikeRec(name,n,time,pay);
        }
        /// <summary>
        /// 查询充值记录表有总共有多少条数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <param name="pay"></param>
        /// <returns></returns>
        public int PageRec(string name, string time, string pay)
        {
            return PayMg.PageRec(name,time,pay);
        }
        /// <summary>
        /// 绑定分页
        /// </summary>
        /// <returns></returns>
        public string PageRecIndex(string name, int n, string time, string pay)
        {
            return PayMg.PageRecIndex(name,n,time,pay);
        }
        /// <summary>
        /// 查询总共金额
        /// </summary>
        /// <param name="field">金额所对应的字段名称</param>
        /// <param name="table">表名称</param>
        /// <param name="wherer">所对应的条件</param>
        /// <returns></returns>
        public int SumMoney(string field, string table, string wherer)
        {
            return PayMg.SumMoney(field,table,wherer);
        }
        #endregion

        #region 资源交易管理
        /// <summary>
        /// 购物车内容
        /// </summary>
        /// <returns></returns>
        public string SelWaitState(string name, int n, string time, string InfoType)
        {
            return wait.SelWaitState(name,n,time,InfoType);
        }

        /// <summary>
        /// 购物车分页
        /// </summary>
        /// <returns></returns>
        public string PageIndexWait(string name, int n, string time, string InfoType)
        {
            return wait.PageIndexWait(name,n,time,InfoType);
        }
        /// <summary>
        /// 消费记录内容
        /// </summary>
        /// <returns></returns>
        public string SelListStats(string name, int n, string time, string InfoType)
        {
            return wait.SelListStats(name,n,time,InfoType);
        }
        /// <summary>
        /// 消费记录分页
        /// </summary>
        /// <returns></returns>
        public string PageIndexList(string name, int n, string time, string InfoType)
        {
            return wait.PageIndexList(name,n,time,InfoType);
        }

        #endregion

        #region 我的收藏
        public string SelInfoView(string name, int n, string time, string state)
        {
            return info.SelInfoView(name,n,time,state);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public string PageIndexInfo(string name, int n, string time, string state)
        {
            return info.PageIndex(name,n,time,state);
        }
        #endregion

        #region 购买记录
        public string SelBuylist(string name, int n, string time, string type)
        {
            return buy.SelBuylist(name,n,time,type);
        }

        public string SelBuyPageIndex(string name, int n, string time, string type)
        {
            return buy.SelBuyPageIndex(name,n,time,type);
        }
        #endregion

        #region 我收到的留言
        /// <summary>
        /// 我收到的留言
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public string SelReceive(string name, int n, string time, string title)
        {
            return re.SelReceive(name,n,time,title);
        }

        /// <summary>
        /// 我收到的留言分页
        /// </summary>
        public string IndexPageReceive(string name, int n, string time, string title)
        {
            return re.IndexPageReceive(name,n,time,title);
        }
        #endregion

        #region 我发出的留言
        /// <summary>
        /// 我发出的留言
        /// </summary>
        public string SelSend(string name, int n, string time, string title)
        {
            return re.SelSend(name,n,time,title);
        }

        /// <summary>
        /// 我发出的留言分页
        /// </summary>
        public string IndexPageSend(string name, int n, string time, string title)
        {
            return re.IndexPageSend(name,n,time,title);
        }
        #endregion
    }
}
