using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Tz888.Model
{
    public class MemberManageInfo
    {
        private string mstrCardID;						//创富卡号
        private string mstrLoginName;					//登录名
        private float mintWorthPoint;						//帐户余额
        private int mintIntegralSum;					//奖励积分
        private float mintStrikeSum;						//充值总额
        private float mintConsumeSum;						//消费总额
        private int mintConsumeSum_Integral;						//消费总额
        private float mintIncomeSum;	//点数收益总额
        private int mintIncomeSum_Integral;	//积分收益总额


        private int mintMatchCount;                     //匹配信息数
        private int mintInfoFavoriteCount;				//信息收藏记录数
        private int mintShopCarCount;					//我的购物车记录数
        private int mintCardCount;						//互动名片数目
        private int mintMemberCount;					//会员数
        private int mintonLineMemberCount;				//在线会员数

        private int mintInfoPublishNoFreeCount;			//已发布付费记录数目和
        private int mintInfoPublishNoFreeIntegralSum;	//已发布付费记录积分和
        private float mintInfoPublishNoFreePointSum;		//已发布付费记录点数和
        private int mintInfoViewNoFreeCount;			//已浏览付费记录数目和
        private int mintInfoViewNoFreeIntegralSum;		//已浏览付费记录积分和
        private float mintInfoViewNoFreePointSum;			//已浏览付费记录点数和

        private int mintInfoPublishCommendCount;		//已发布推荐记录数目和
        private int mintInfoViewCommendCount;			//已浏览推荐记录数目和

        private int mintInfoPublishFreeCount;			//已发布免费记录数目和
        private int mintInfoPublishFreeIntegralSum;		//已发布免费记录积分和
        private int mintInfoViewFreeCount;				//已浏览免费记录数目和

        private string mstrChangeBy;					//接收者
        private long mlgInfoID;							//信息ID
        private string mstrSendBy;						//接受者
        private string mstrReceivedBy;					//发送者
        private long mlgShopCarID;
        private long mlgID;
        private bool mblIsPay = false;					//信息是否付费(对免费信息无效)

        private int mintInfoAllCount; //用户发布信息总数




        //用户发布信息总数
        public int InfoAllCount
        {
            get { return mintInfoAllCount; }
            set { mintInfoAllCount = value; }
        }
        public MemberManageInfo()
        {
        }

        #region-- 属性设置 ----------------------
        public int MemberCount				//会员数
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

        public int onLineMemberCount				//在线会员数
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
        public string CardID             //创富卡号
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
        public string LoginName             //登录名
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
        public float WorthPoint             //帐户余额
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
        public int IntegralSum           //奖励积分
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
        public float StrikeSum           //充值总额
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
        public float ConsumeSum           //消费总额
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
        public int ConsumeSum_Integral           //消费总额
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

        public float IncomeSum           //收益点数总额
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
        public int IncomeSum_Integral           //收益积分总额
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
        public int MatchCount           //消费总额
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
        public int InfoFavoriteCount         //信息收藏记录数
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
        public int ShopCarCount              //我的购物车记录数
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
        public string ChangeBy            //接受者
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
        public int InfoPublishNoFreeCount            //已发布付费记录数目和
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
        public int InfoPublishNoFreeIntegralSum            //已发布付费记录积分和
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
        public float InfoPublishNoFreePointSum           //已发布付费记录积分和
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

        public int InfoViewNoFreeCount            //已浏览付费记录数目和
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
        public int InfoViewNoFreeIntegralSum            //已浏览付费记录积分和
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
        public float InfoViewNoFreePointSum            //已浏览付费记录点数和
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
        public int InfoPublishCommendCount            //已发布推荐记录数目和
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

        public int InfoViewCommendCount            //已浏览推荐记录数目和
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

        public int InfoPublishFreeCount            //已发布免费记录数目和
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
        public int InfoPublishFreeIntegralSum            //已发布免费记录积分和
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
        public int InfoViewFreeCount            //已浏览免费记录数目和
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

        #region  -- 属性 --------------------------
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
