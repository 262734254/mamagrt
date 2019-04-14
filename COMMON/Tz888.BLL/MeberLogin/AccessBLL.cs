using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.MeberLogin
{
    public class AccessBLL
    {
        Access ac = new Access();
        #region ������Ϣ
        /// <summary>
        /// ��ӷ�������Ϣ
        /// </summary>
        /// <param name="InfoID">��Ŀ����Ӧ��InfoID</param>
        /// <param name="Name">������</param>
        /// <param name="Time">����ʱ��</param>
        /// <param name="Ip">����IP</param>
        /// <param name="Proince">����������ʡ��</param>
        /// <returns></returns>
        public int AccessInsert(string InfoID, string Name, string Time, string Ip, string Proince)
        {
            return ac.AccessInsert(InfoID,Name,Time,Ip,Proince);
        }
        /// <summary>
        /// ��������Ӧ��InfoID���ҷ�����Ϣ
        /// </summary>
        /// <returns></returns>
        public string SelAccess(string InfoID, int n)
        {
            return ac.SelAccess(InfoID,n);
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string IndexAccess(string InfoID, int n)
        {
            return ac.IndexAccess(InfoID,n);
        }
        #endregion

        #region �ҷ�������Ŀ
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string SelMainLoginName(string name, int n,string InfoType)
        {
            return ac.SelMainLoginName(name,n,InfoType);
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <returns></returns>
        public string SelPageIndex(string name, int n,string InfoType)
        {
            return ac.SelPageIndex(name,n,InfoType);
        }
        #endregion

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="id"></param>
        public int ModfiyHit(string InfoID)
        {
            return ac.ModfiyHit(InfoID);
        }
    }
}
