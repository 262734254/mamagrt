using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.MeberLogin
{
    public class PromotionBLL
    {
        Promotion pr = new Promotion();
        /// <summary>
        /// 查询推广信息
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public string SelTitleTime(string InfoID)
        {
            return pr.SelTitleTime(InfoID);
        }
        /// <summary>
        /// 修改推广状态
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="time"></param>
        /// <param name="RecordID"></param>
        /// <returns></returns>
        public int UpdateRecord(string InfoID,string RecordID)
        {
            return pr.UpdateRecord(InfoID,RecordID);
        }
        /// <summary>
        /// 修改推广时间
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int UpdateTime(string InfoID, string time)
        { 
           return pr.UpdateTime(InfoID,time);
        }
    }
}
