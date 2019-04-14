using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.MeberLogin
{
    public class AccessBLL
    {
        Access ac = new Access();
        #region 访问信息
        /// <summary>
        /// 添加访问者信息
        /// </summary>
        /// <param name="InfoID">项目所对应的InfoID</param>
        /// <param name="Name">访问者</param>
        /// <param name="Time">访问时间</param>
        /// <param name="Ip">访问IP</param>
        /// <param name="Proince">访问者所在省名</param>
        /// <returns></returns>
        public int AccessInsert(string InfoID, string Name, string Time, string Ip, string Proince)
        {
            return ac.AccessInsert(InfoID,Name,Time,Ip,Proince);
        }
        /// <summary>
        /// 根据所对应的InfoID查找访问信息
        /// </summary>
        /// <returns></returns>
        public string SelAccess(string InfoID, int n)
        {
            return ac.SelAccess(InfoID,n);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string IndexAccess(string InfoID, int n)
        {
            return ac.IndexAccess(InfoID,n);
        }
        #endregion

        #region 我发布的项目
        /// <summary>
        /// 发布的内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string SelMainLoginName(string name, int n,string InfoType)
        {
            return ac.SelMainLoginName(name,n,InfoType);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        public string SelPageIndex(string name, int n,string InfoType)
        {
            return ac.SelPageIndex(name,n,InfoType);
        }
        #endregion

        /// <summary>
        /// 处理访问量
        /// </summary>
        /// <param name="id"></param>
        public int ModfiyHit(string InfoID)
        {
            return ac.ModfiyHit(InfoID);
        }
    }
}
