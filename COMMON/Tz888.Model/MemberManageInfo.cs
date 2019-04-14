using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.Model
{
    public class MemberManageInfo
    {
        private string mstrCardID;						//��������
        private string mstrLoginName;					//��¼��
        private float mintWorthPoint;						//�ʻ����
        private int mintIntegralSum;					//��������
        private float mintStrikeSum;						//��ֵ�ܶ�
        private float mintConsumeSum;						//�����ܶ�
        private int mintConsumeSum_Integral;						//�����ܶ�
        private float mintIncomeSum;	//���������ܶ�
        private int mintIncomeSum_Integral;	//���������ܶ�


        private int mintMatchCount;                     //ƥ����Ϣ��
        private int mintInfoFavoriteCount;				//��Ϣ�ղؼ�¼��
        private int mintShopCarCount;					//�ҵĹ��ﳵ��¼��
        private int mintCardCount;						//������Ƭ��Ŀ
        private int mintMemberCount;					//��Ա��
        private int mintonLineMemberCount;				//���߻�Ա��

        private int mintInfoPublishNoFreeCount;			//�ѷ������Ѽ�¼��Ŀ��
        private int mintInfoPublishNoFreeIntegralSum;	//�ѷ������Ѽ�¼���ֺ�
        private float mintInfoPublishNoFreePointSum;		//�ѷ������Ѽ�¼������
        private int mintInfoViewNoFreeCount;			//��������Ѽ�¼��Ŀ��
        private int mintInfoViewNoFreeIntegralSum;		//��������Ѽ�¼���ֺ�
        private float mintInfoViewNoFreePointSum;			//��������Ѽ�¼������

        private int mintInfoPublishCommendCount;		//�ѷ����Ƽ���¼��Ŀ��
        private int mintInfoViewCommendCount;			//������Ƽ���¼��Ŀ��

        private int mintInfoPublishFreeCount;			//�ѷ�����Ѽ�¼��Ŀ��
        private int mintInfoPublishFreeIntegralSum;		//�ѷ�����Ѽ�¼���ֺ�
        private int mintInfoViewFreeCount;				//�������Ѽ�¼��Ŀ��

        private string mstrChangeBy;					//������
        private long mlgInfoID;							//��ϢID
        private string mstrSendBy;						//������
        private string mstrReceivedBy;					//������
        private long mlgShopCarID;
        private long mlgID;
        private bool mblIsPay = false;					//��Ϣ�Ƿ񸶷�(�������Ϣ��Ч)

        private int mintInfoAllCount; //�û�������Ϣ����




        //�û�������Ϣ����
        public int InfoAllCount
        {
            get { return mintInfoAllCount; }
            set { mintInfoAllCount = value; }
        }
        public MemberManageInfo()
        {
        }

        #region-- �������� ----------------------
        public int MemberCount				//��Ա��
        {
            get
            {
                return mintMemberCount;
            }
            set
            {
                mintMemberCount = value;
            }
        }

        public int onLineMemberCount				//���߻�Ա��
        {
            get
            {
                return mintonLineMemberCount;
            }
            set
            {
                mintonLineMemberCount = value;
            }
        }
        public string CardID             //��������
        {
            get
            {
                return mstrCardID;
            }
            set
            {
                mstrCardID = value;
            }
        }
        public long ShopCarID
        {
            get
            {
                return mlgShopCarID;
            }
            set
            {
                mlgShopCarID = value;
            }
        }
        public string LoginName             //��¼��
        {
            get
            {
                return mstrLoginName;
            }
            set
            {
                mstrLoginName = value;
            }
        }
        public float WorthPoint             //�ʻ����
        {
            get
            {
                return mintWorthPoint;
            }
            set
            {
                mintWorthPoint = value;
            }
        }
        public int IntegralSum           //��������
        {
            get
            {
                return mintIntegralSum;
            }
            set
            {
                mintIntegralSum = value;
            }
        }
        public float StrikeSum           //��ֵ�ܶ�
        {
            get
            {
                return mintStrikeSum;
            }
            set
            {
                mintStrikeSum = value;
            }
        }
        public float ConsumeSum           //�����ܶ�
        {
            get
            {
                return mintConsumeSum;
            }
            set
            {
                mintConsumeSum = value;
            }
        }
        public int ConsumeSum_Integral           //�����ܶ�
        {
            get
            {
                return mintConsumeSum_Integral;
            }
            set
            {
                mintConsumeSum_Integral = value;
            }
        }

        public float IncomeSum           //��������ܶ�
        {
            get
            {
                return mintIncomeSum;
            }
            set
            {
                mintIncomeSum = value;
            }
        }
        public int IncomeSum_Integral           //��������ܶ�
        {
            get
            {
                return mintIncomeSum_Integral;
            }
            set
            {
                mintIncomeSum_Integral = value;
            }
        }
        public int MatchCount           //�����ܶ�
        {
            get
            {
                return mintMatchCount;
            }
            set
            {
                mintMatchCount = value;
            }
        }
        public int InfoFavoriteCount         //��Ϣ�ղؼ�¼��
        {
            get
            {
                return mintInfoFavoriteCount;
            }
            set
            {
                mintInfoFavoriteCount = value;
            }
        }
        public int ShopCarCount              //�ҵĹ��ﳵ��¼��
        {
            get
            {
                return mintShopCarCount;
            }
            set
            {
                mintShopCarCount = value;
            }
        }
        public string ChangeBy            //������
        {
            get
            {
                return mstrChangeBy;
            }
            set
            {
                mstrChangeBy = value;
            }
        }
        public int InfoPublishNoFreeCount            //�ѷ������Ѽ�¼��Ŀ��
        {
            get
            {
                return mintInfoPublishNoFreeCount;
            }
            set
            {
                mintInfoPublishNoFreeCount = value;
            }
        }
        public int InfoPublishNoFreeIntegralSum            //�ѷ������Ѽ�¼���ֺ�
        {
            get
            {
                return mintInfoPublishNoFreeIntegralSum;
            }
            set
            {
                mintInfoPublishNoFreeIntegralSum = value;
            }
        }
        public float InfoPublishNoFreePointSum           //�ѷ������Ѽ�¼���ֺ�
        {
            get
            {
                return mintInfoPublishNoFreePointSum;
            }
            set
            {
                mintInfoPublishNoFreePointSum = value;
            }
        }

        public int InfoViewNoFreeCount            //��������Ѽ�¼��Ŀ��
        {
            get
            {
                return mintInfoViewNoFreeCount;
            }
            set
            {
                mintInfoViewNoFreeCount = value;
            }
        }
        public int InfoViewNoFreeIntegralSum            //��������Ѽ�¼���ֺ�
        {
            get
            {
                return mintInfoViewNoFreeIntegralSum;
            }
            set
            {
                mintInfoViewNoFreeIntegralSum = value;
            }
        }
        public float InfoViewNoFreePointSum            //��������Ѽ�¼������
        {
            get
            {
                return mintInfoViewNoFreePointSum;
            }
            set
            {
                mintInfoViewNoFreePointSum = value;
            }
        }
        public int InfoPublishCommendCount            //�ѷ����Ƽ���¼��Ŀ��
        {
            get
            {
                return mintInfoPublishCommendCount;
            }
            set
            {
                mintInfoPublishCommendCount = value;
            }
        }

        public int InfoViewCommendCount            //������Ƽ���¼��Ŀ��
        {
            get
            {
                return mintInfoViewCommendCount;
            }
            set
            {
                mintInfoViewCommendCount = value;
            }
        }

        public int InfoPublishFreeCount            //�ѷ�����Ѽ�¼��Ŀ��
        {
            get
            {
                return mintInfoPublishFreeCount;
            }
            set
            {
                mintInfoPublishFreeCount = value;
            }
        }
        public int InfoPublishFreeIntegralSum            //�ѷ�����Ѽ�¼���ֺ�
        {
            get
            {
                return mintInfoPublishFreeIntegralSum;
            }
            set
            {
                mintInfoPublishFreeIntegralSum = value;
            }
        }
        public int InfoViewFreeCount            //�������Ѽ�¼��Ŀ��
        {
            get
            {
                return mintInfoViewFreeCount;
            }
            set
            {
                mintInfoViewFreeCount = value;
            }
        }
        public int CardCount
        {
            get
            {
                return this.mintCardCount;	//
            }
            set
            {
                mintCardCount = value;
            }
        }
        #endregion

        #region  -- ���� --------------------------
        public long ID
        {
            get
            {
                return this.mlgID;
            }
            set
            {
                this.mlgID = value;
            }
        }
        public long InfoID
        {
            get
            {
                return this.mlgInfoID;
            }
            set
            {
                this.mlgInfoID = value;
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
        public string ReceivedBy
        {
            get
            {
                return this.mstrReceivedBy;
            }
            set
            {
                this.mstrReceivedBy = value;
            }
        }
        public bool IsPay
        {
            get
            {
                return this.mblIsPay;
            }
            set
            {
                this.mblIsPay = value;
            }
        }
        #endregion
    }

}
