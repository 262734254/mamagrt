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
        #region ��ҳ
        public string SelMemberNews(string name)
        {
            return member.SelMemberNews(name);
        }
         //���һ���
        public int SelJiFen(string name)
        {
            return member.SelJiFen(name);
        }
        //�ҵ���Ŀ
        public string SelItem(string name)
        {
            return member.SelItem(name);
        }
        //����δ������
        public int SelInnerInfo(string name)
        {
            return member.SelInnerInfo(name);
        }
         //����������Ŀ
        public string SelLatest()
        {
            return member.SelLatest();
        }
        #endregion
        #region ����б������
        /// <summary>
        /// ��ѯ��Ա����
        /// </summary>
        /// <param name="name">��¼��</param>
        /// <param name="statu">���״̬</param>
        /// <param name="n">��ǰҳ����</param>
        /// <returns></returns>
        public string AjaxStatus(string name, int statu, int n, string InfoType, string title)
        {
            return member.AjaxStatus(name,statu,n,InfoType,title);

        }
        /// <summary>
        /// ��ѯ������
        /// </summary>
        /// <param name="name"></param>
        /// <param name="statu"></param>
        /// <returns></returns>
        public int pageIndex(string name, int statu, string InfoType, string title)
        {
            return member.pageIndex(name,statu,InfoType,title);
        }
        /// <summary>
        /// ��ҳ
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
        /// ɾ������
        /// </summary>
        /// <param name="InfoID"></param>
        /// <returns></returns>
        public int SelDelMain(string InfoID)
        {
            return member.SelDelMain(InfoID);
        }
        #endregion
        #region ��ֵ��Ϣ
                /// <summary>
        /// ��ֵ������Ϣ
        /// </summary>
        /// <param name="name">�û���</param>
        /// <param name="n">�ڼ�ҳ</param>
        /// <param name="time">ʱ��</param>
        /// <param name="Pay">֧����ʽ</param>
        /// <returns></returns>
        public string StrikeOrder(string name,int n,string time,string Pay)
        {
            return PayMg.StrikeOrder(name,n,time,Pay);
        }
        /// <summary>
        /// ��ѯ��ֵ�����ܹ�����������
        /// </summary>
        /// <returns></returns>
        public int PageOrder(string name,string time, string pay)
        {
            return PayMg.PageOrder(name,time,pay);
        }
        /// <summary>
        /// �󶨷�ҳ
        /// </summary>
        /// <returns></returns>
        public string PageOrderIndex(string name, int n, string time, string pay)
        {
            return PayMg.PageOrderIndex(name,n,time,pay);
        }
        #endregion

        #region ��ֵ��¼��
        /// <summary>
        /// ��ֵ��¼��Ϣ
        /// </summary>
        /// <param name="name">�û���</param>
        /// <param name="n">�ڼ�ҳ</param>
        /// <param name="time">ʱ��</param>
        /// <param name="Pay">֧����ʽ</param>
        /// <returns></returns>
        public string StrikeRec(string name, int n, string time, string pay)
        {
            return PayMg.StrikeRec(name,n,time,pay);
        }
        /// <summary>
        /// ��ѯ��ֵ��¼�����ܹ��ж���������
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
        /// �󶨷�ҳ
        /// </summary>
        /// <returns></returns>
        public string PageRecIndex(string name, int n, string time, string pay)
        {
            return PayMg.PageRecIndex(name,n,time,pay);
        }
        /// <summary>
        /// ��ѯ�ܹ����
        /// </summary>
        /// <param name="field">�������Ӧ���ֶ�����</param>
        /// <param name="table">������</param>
        /// <param name="wherer">����Ӧ������</param>
        /// <returns></returns>
        public int SumMoney(string field, string table, string wherer)
        {
            return PayMg.SumMoney(field,table,wherer);
        }
        #endregion

        #region ��Դ���׹���
        /// <summary>
        /// ���ﳵ����
        /// </summary>
        /// <returns></returns>
        public string SelWaitState(string name, int n, string time, string InfoType)
        {
            return wait.SelWaitState(name,n,time,InfoType);
        }

        /// <summary>
        /// ���ﳵ��ҳ
        /// </summary>
        /// <returns></returns>
        public string PageIndexWait(string name, int n, string time, string InfoType)
        {
            return wait.PageIndexWait(name,n,time,InfoType);
        }
        /// <summary>
        /// ���Ѽ�¼����
        /// </summary>
        /// <returns></returns>
        public string SelListStats(string name, int n, string time, string InfoType)
        {
            return wait.SelListStats(name,n,time,InfoType);
        }
        /// <summary>
        /// ���Ѽ�¼��ҳ
        /// </summary>
        /// <returns></returns>
        public string PageIndexList(string name, int n, string time, string InfoType)
        {
            return wait.PageIndexList(name,n,time,InfoType);
        }

        #endregion

        #region �ҵ��ղ�
        public string SelInfoView(string name, int n, string time, string state)
        {
            return info.SelInfoView(name,n,time,state);
        }
        /// <summary>
        /// ��ҳ
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

        #region �����¼
        public string SelBuylist(string name, int n, string time, string type)
        {
            return buy.SelBuylist(name,n,time,type);
        }

        public string SelBuyPageIndex(string name, int n, string time, string type)
        {
            return buy.SelBuyPageIndex(name,n,time,type);
        }
        #endregion

        #region ���յ�������
        /// <summary>
        /// ���յ�������
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
        /// ���յ������Է�ҳ
        /// </summary>
        public string IndexPageReceive(string name, int n, string time, string title)
        {
            return re.IndexPageReceive(name,n,time,title);
        }
        #endregion

        #region �ҷ���������
        /// <summary>
        /// �ҷ���������
        /// </summary>
        public string SelSend(string name, int n, string time, string title)
        {
            return re.SelSend(name,n,time,title);
        }

        /// <summary>
        /// �ҷ��������Է�ҳ
        /// </summary>
        public string IndexPageSend(string name, int n, string time, string title)
        {
            return re.IndexPageSend(name,n,time,title);
        }
        #endregion
    }
}
