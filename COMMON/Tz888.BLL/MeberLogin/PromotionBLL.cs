using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.MeberLogin
{
    public class PromotionBLL
    {
        Promotion pr = new Promotion();
        /// <summary>
        /// ��ѯ�ƹ���Ϣ
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public string SelTitleTime(string InfoID)
        {
            return pr.SelTitleTime(InfoID);
        }
        /// <summary>
        /// �޸��ƹ�״̬
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
        /// �޸��ƹ�ʱ��
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
