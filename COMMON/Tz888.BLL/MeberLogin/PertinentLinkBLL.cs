using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.MeberLogin
{
    
    public class PertinentLinkBLL
    {
        PertinentLink per = new PertinentLink();
        public string SelMainInfoId(string InfoID, string InfoType)
        {
            return per.SelMainInfoId(InfoID,InfoType);
        }
        /// <summary>
        /// 查找行业名称
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string IndustyID(string InfoID, string InfoType)
        {
            return per.IndustyID(InfoID, InfoType);
        }
        /// <summary>
        /// 绑定对比的资源
        /// </summary>
        /// <param name="InfoType">资源所对应的类别</param>
        /// <param name="n">当前第几页</param>
        /// <param name="Industy">行业编号</param>
        /// <returns></returns>
        public string Balance(string InfoType, int n, string IndustyBID)
        {
            return per.Balance(InfoType,n,IndustyBID);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public string SelPageIndex(string InfoType, int n, string Industy)
        {
            return per.SelPageIndex(InfoType,n,Industy);
        }
    }
}
