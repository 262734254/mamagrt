using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Search
{
    public class SearchInfo
    {         
		protected long mlgInfoID;						//��ϢID
		protected string mstrTitle;						//��Ϣ����
		protected string mstrInfoCode;					//��Ϣ����
		protected DateTime mtimePublishDate;			//��Ϣ����ʱ��
		protected long mlgHit;							//��Ϣ�����
		protected string mstrInfoTypeID;				//��Ϣ����[���š����̡���Ŀ��Ͷ��...]
		protected bool mblIsCore;						//��Ϣ�Ƿ��Ǻ�������
		
		protected long mlgIndexOrderNum;				//��Ϣ��ҳ�����
		protected int mintIndexTopValidateDate;			//��Ϣ�ö���Ч��
		protected long mlgIndexPicInfoNum;				//�Ƿ�ͼƬͷ��
		protected long mlgInfoTypeOrderNum;				//��Ŀ�е������ (�Ӵ�С����Խ��Խ��ǰ)
		protected int mintInfoTypeTopValidateDate;		//��Ŀ�ö���Ч��
		protected long mlgInfoTypePicInfoNum;			//�Ƿ�����Ŀ��ͼƬͷ��

		protected string mstrLoginName;					//�û���ʶ��
		protected string mstrInfoOriginRoleName;		//�û���ɫ����		
		protected string mstrGradeID;					//��Ϣ������ID
		protected string mstrGradeName;					//��Ϣ������
		protected string mstrFixPriceID;				//��Ϣ�Ķ���ID
		protected string mstrFixPriceName;				//��Ϣ�Ķ���
		protected byte mbtFeeStatus;					//0����,1δ����,2���踶��
		protected byte mbtAuditingStatus;				//0δ���,1���ͨ��,2���δͨ��
		protected byte mbtDelStatus;					//0������,1����,2��������
		protected string mstrApproveBy;                 //�����/�༭

		protected string mstrContentKeyword;                //�ؼ���
		protected string mstrKeyWord;                       //�ؼ���
		protected string mstrDescript;						//����
		protected string mstrDisplayTitle;					//��ʾ����
		protected DateTime mdtFrontDisplayTime;				//ǰ̨��ʾʱ��
		protected DateTime mdtValidateStartTime;             //��ʼ��Ч����
		protected int  miValidateTerm;					//��Ч��
		protected string mstrTemplateID;                   //ģ���

		protected string mstrHtmlFile;					//��̬ҳ���ļ���

		protected string mstrHtmlFile1;					//��̬ҳ���ļ���
		protected int mintUserEvaluation;               //�û�����ָ��

		protected short mIsIntegralInfo;//�Ƿ��ǻ���ϵͳ��Դ
		protected float mMainPointCoun;//������ֵ
		protected int mMainEvaluation;//��ֵ����ָ��	 

		#region ���ò���

		/// <summary>
		/// ��ֵ����ָ��
		/// </summary>
		public int MainEvaluation
		{
			get{return mMainEvaluation;}
			set{mMainEvaluation=value;}
		}

		/// <summary>
		/// ������ֵ
		/// </summary>
		public float MainPointCoun
		{
			get{return mMainPointCoun;}
			set{mMainPointCoun=value;}
		}
		/// <summary>
		/// �Ƿ��ǵ���ϵͳ��Դ
		/// </summary>
		public short IsIntegralInfo
		{
			get{return mIsIntegralInfo;}
			set{mIsIntegralInfo=value;}
		}
		public long InfoID//��ϢID
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

		public string Title//��Ϣ����
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

		public string InfoCode//��Ϣ����
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
		
		public DateTime PublishDate//��Ϣ����ʱ��
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
		
		public long Hit//��Ϣ�����
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

		public string InfoTypeID//��Ϣ����[���š����̡���Ŀ��Ͷ��...]
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
		
		public bool IsCore//��Ϣ�Ƿ��Ǻ�������
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

		public long IndexOrderNum//��Ϣ��ҳ�����
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
				
		public int IndexTopValidateDate//��Ϣ�ö���Ч��
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
		
		public long IndexPicInfoNum//�Ƿ�ͼƬͷ��
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

		public long InfoTypeOrderNum//��Ŀ�е������ (�Ӵ�С����Խ��Խ��ǰ)
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
		
		public int InfoTypeTopValidateDate//��Ŀ�ö���Ч��
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

		public long InfoTypePicInfoNum//�Ƿ�����Ŀ��ͼƬͷ��
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
				
		public string LoginName//�û���ʶ��
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
		
		public string InfoOriginRoleName//�û���ɫ����
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
		
		public string GradeID//��Ϣ������ID
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
		public string GradeName//��Ϣ������
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
		public string FixPriceID//��Ϣ�Ķ���ID
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
		public string FixPriceName//��Ϣ�Ķ���
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
		public byte FeeStatus//��Ϣ�ķ������
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

		public byte AuditingStatus//��Ϣ��������
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

		public byte DelStatus//��Ϣ��������Ϣ
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

		public string ContentKeyword                    //�ؼ���
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

		public string KeyWord                    //�ؼ���
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

		public string ApproveBy  //����ˡ��༭
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

		public string Descript				//����
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

		public string DisplayTitle					//ǰ̨��ʾ����
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

		public DateTime FrontDisplayTime			//ǰ̨��ʾʱ��
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

		public DateTime ValidateStartTime			//��ʼ��Чʱ��
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

		public int ValidateTerm			//��ʼ��Ч��
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

		public string TemplateID			//��ʼ��Чʱ��
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


		public string  HtmlFile			//��ʼ��Чʱ��
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
