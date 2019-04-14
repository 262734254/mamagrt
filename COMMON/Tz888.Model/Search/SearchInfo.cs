using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Search
{
    public class SearchInfo
    {         
		protected long mlgInfoID;						//信息ID
		protected string mstrTitle;						//信息标题
		protected string mstrInfoCode;					//信息编码
		protected DateTime mtimePublishDate;			//信息发布时间
		protected long mlgHit;							//信息点击数
		protected string mstrInfoTypeID;				//信息类型[新闻、招商、项目、投资...]
		protected bool mblIsCore;						//信息是否是核心数据
		
		protected long mlgIndexOrderNum;				//信息首页排序号
		protected int mintIndexTopValidateDate;			//信息置顶有效期
		protected long mlgIndexPicInfoNum;				//是否图片头条
		protected long mlgInfoTypeOrderNum;				//栏目中的排序号 (从大到小排序，越大越在前)
		protected int mintInfoTypeTopValidateDate;		//栏目置顶有效期
		protected long mlgInfoTypePicInfoNum;			//是否是栏目内图片头条

		protected string mstrLoginName;					//用户标识名
		protected string mstrInfoOriginRoleName;		//用户角色种类		
		protected string mstrGradeID;					//信息的评分ID
		protected string mstrGradeName;					//信息的评分
		protected string mstrFixPriceID;				//信息的定价ID
		protected string mstrFixPriceName;				//信息的定价
		protected byte mbtFeeStatus;					//0付费,1未付费,2无需付费
		protected byte mbtAuditingStatus;				//0未审核,1审核通过,2审核未通过
		protected byte mbtDelStatus;					//0不隐藏,1隐藏,2彻底隐藏
		protected string mstrApproveBy;                 //审核人/编辑

		protected string mstrContentKeyword;                //关键词
		protected string mstrKeyWord;                       //关键字
		protected string mstrDescript;						//描述
		protected string mstrDisplayTitle;					//显示标题
		protected DateTime mdtFrontDisplayTime;				//前台显示时间
		protected DateTime mdtValidateStartTime;             //开始有效日期
		protected int  miValidateTerm;					//有效期
		protected string mstrTemplateID;                   //模板号

		protected string mstrHtmlFile;					//静态页面文件名

		protected string mstrHtmlFile1;					//静态页面文件名
		protected int mintUserEvaluation;               //用户评价指数

		protected short mIsIntegralInfo;//是否是积分系统资源
		protected float mMainPointCoun;//点数数值
		protected int mMainEvaluation;//价值评估指数	 

		#region 设置参数

		/// <summary>
		/// 价值评估指数
		/// </summary>
		public int MainEvaluation
		{
			get{return mMainEvaluation;}
			set{mMainEvaluation=value;}
		}

		/// <summary>
		/// 点数数值
		/// </summary>
		public float MainPointCoun
		{
			get{return mMainPointCoun;}
			set{mMainPointCoun=value;}
		}
		/// <summary>
		/// 是否是点数系统资源
		/// </summary>
		public short IsIntegralInfo
		{
			get{return mIsIntegralInfo;}
			set{mIsIntegralInfo=value;}
		}
		public long InfoID//信息ID
		{
			get
			{
				return mlgInfoID;
			}

			set
			{	
				mlgInfoID = value;
			}
		}

		public string Title//信息标题
		{
			get
			{
				return mstrTitle;
			}

			set
			{	
				mstrTitle = value;
			}
		}

		public string InfoCode//信息编码
		{
			get
			{
				return mstrInfoCode;
			}

			set
			{	
				mstrInfoCode = value;
			}
		}
		
		public DateTime PublishDate//信息发布时间
		{
			get
			{
				return mtimePublishDate;
			}

			set
			{	
				mtimePublishDate = value;
			}
		}
		
		public long Hit//信息点击数
		{
			get
			{
				return mlgHit;
			}

			set
			{	
				mlgHit = value;
			}
		}

		public string InfoTypeID//信息类型[新闻、招商、项目、投资...]
		{
			get
			{
				return mstrInfoTypeID;
			}

			set
			{	
				mstrInfoTypeID = value;
			}
		}
		
		public bool IsCore//信息是否是核心数据
		{
			get
			{
				return mblIsCore;
			}

			set
			{	
				mblIsCore = value;
			}
		}

		public long IndexOrderNum//信息首页排序号
		{
			get
			{
				return mlgIndexOrderNum;
			}

			set
			{	
				mlgIndexOrderNum = value;
			}
		}
				
		public int IndexTopValidateDate//信息置顶有效期
		{
			get
			{
				return mintIndexTopValidateDate;
			}

			set
			{	
				mintIndexTopValidateDate = value;
			}
		}
		
		public long IndexPicInfoNum//是否图片头条
		{
			get
			{
				return mlgIndexPicInfoNum;
			}

			set
			{	
				mlgIndexPicInfoNum = value;
			}
		}

		public long InfoTypeOrderNum//栏目中的排序号 (从大到小排序，越大越在前)
		{
			get
			{
				return mlgInfoTypeOrderNum;
			}

			set
			{	
				mlgInfoTypeOrderNum = value;
			}
		}
		
		public int InfoTypeTopValidateDate//栏目置顶有效期
		{
			get
			{
				return mintInfoTypeTopValidateDate;
			}

			set
			{	
				mintInfoTypeTopValidateDate = value;
			}
		}

		public long InfoTypePicInfoNum//是否是栏目内图片头条
		{
			get
			{
				return mlgInfoTypePicInfoNum;
			}

			set
			{	
				mlgInfoTypePicInfoNum = value;
			}
		}
				
		public string LoginName//用户标识名
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
		
		public string InfoOriginRoleName//用户角色种类
		{
			get
			{
				return mstrInfoOriginRoleName;
			}

			set
			{	
				mstrInfoOriginRoleName = value;
			}
		}
		
		public string GradeID//信息的评分ID
		{
			get
			{
				return mstrGradeID;
			}

			set
			{	
				mstrGradeID = value;
			}
		}
		public string GradeName//信息的评分
		{
            set
			{
                GradeName=value;
			}
			get
			{
				return mstrGradeName;
			}
		}
		public string FixPriceID//信息的定价ID
		{
			get
			{
				return mstrFixPriceID;
			}

			set
			{	
				mstrFixPriceID = value;
			}
		}
		public string FixPriceName//信息的定价
		{
            set
            {
                FixPriceName = value;
            }
			get
			{
				return mstrFixPriceName;
			}
		}
		public byte FeeStatus//信息的费用情况
		{
			get
			{
				return mbtFeeStatus;
			}

			set
			{	
				mbtFeeStatus = value;
			}
		}

		public byte AuditingStatus//信息的审核情况
		{
			get
			{
				return mbtAuditingStatus;
			}

			set
			{	
				mbtAuditingStatus = value;
			}
		}

		public byte DelStatus//信息的隐藏信息
		{
			get
			{
				return mbtDelStatus;
			}

			set
			{	
				mbtDelStatus = value;
			}
		}

		public string ContentKeyword                    //关键词
		{
			get
			{
				return mstrContentKeyword;
			}

			set
			{	
				mstrContentKeyword = value;
			}
		}

		public string KeyWord                    //关键字
		{
			get
			{
				return mstrKeyWord;
			}

			set
			{	
				mstrKeyWord = value;
			}
		}

		public string ApproveBy  //审核人、编辑
		{
			get
			{
				return this.mstrApproveBy;
			}
			set
			{
				this.mstrApproveBy = value;
			}
		}

		public string Descript				//描述
		{
			get
			{
				return mstrDescript;
			}

			set
			{	
				mstrDescript = value;
			}
		}

		public string DisplayTitle					//前台显示标题
		{
			get
			{
				return mstrDisplayTitle;
			}

			set
			{	
				mstrDisplayTitle = value;
			}
		}

		public DateTime FrontDisplayTime			//前台显示时间
		{
			get
			{
				return mdtFrontDisplayTime;
			}

			set
			{	
				mdtFrontDisplayTime = value;
			}
		}

		public DateTime ValidateStartTime			//起始有效时间
		{
			get
			{
				return mdtValidateStartTime;
			}

			set
			{	
				mdtValidateStartTime = value;
			}
		}

		public int ValidateTerm			//起始有效期
		{
			get
			{
				return miValidateTerm;
			}

			set
			{	
				miValidateTerm = value;
			}
		}

		public string TemplateID			//起始有效时间
		{
			get
			{
				return mstrTemplateID;
			}

			set
			{	
				mstrTemplateID = value;
			}
		}


		public string  HtmlFile			//起始有效时间
		{
			get
			{
				return mstrHtmlFile;
			}

			set
			{	
				mstrHtmlFile = value;
			}
		}


		public string  HtmlFile1			
		{
			get
			{
				return mstrHtmlFile1;
			}

			set
			{	
				mstrHtmlFile1 = value;
			}
		}

		public int UserEvaluation
		{
			get
			{
				return mintUserEvaluation;
			}
			set
			{
				mintUserEvaluation = value;
			}
		}
		#endregion
    }
}
