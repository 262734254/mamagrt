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
        /// ������ҵ����
        /// </summary>
        /// <param name="InfoID"></param>
        /// <param name="InfoType"></param>
        /// <returns></returns>
        public string IndustyID(string InfoID, string InfoType)
        {
            return per.IndustyID(InfoID, InfoType);
        }
        /// <summary>
        /// �󶨶Աȵ���Դ
        /// </summary>
        /// <param name="InfoType">��Դ����Ӧ�����</param>
        /// <param name="n">��ǰ�ڼ�ҳ</param>
        /// <param name="Industy">��ҵ���</param>
        /// <returns></returns>
        public string Balance(string InfoType, int n, string IndustyBID)
        {
            return per.Balance(InfoType,n,IndustyBID);
        }
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <returns></returns>
        public string SelPageIndex(string InfoType, int n, string Industy)
        {
            return per.SelPageIndex(InfoType,n,Industy);
        }
    }
}
