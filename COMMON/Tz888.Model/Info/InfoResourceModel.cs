using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    /// <summary>
    /// ��Ϣ��Դʵ����
    /// </summary>
    public class InfoResourceModel
    {
        public InfoResourceModel()
        { }
        #region Model
        private long _resourceid;
        private long _infoid;
		private string _resourcename;
		private string _resourcetitle;
		private string _resourcedescrib;
        private int _resourcetype;
		private string _resourceaddr;
		private int _resourceproperty;
		private byte[] _resourcepassword;
		private DateTime _update;
		private bool _isdel;
		private string _remark;
        private int _promotionStatu;

        public int PromotionStatu
        {
            get { return _promotionStatu; }
            set { _promotionStatu = value; }
        }
		/// <summary>
		/// 
		/// </summary>
        public long ResourceID
		{
			set{ _resourceid=value;}
			get{return _resourceid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public long InfoID
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResourceName
		{
			set{ _resourcename=value;}
			get{return _resourcename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResourceTitle
		{
			set{ _resourcetitle=value;}
			get{return _resourcetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResourceDescrib
		{
			set{ _resourcedescrib=value;}
			get{return _resourcedescrib;}
		}
		/// <summary>
		/// 0 -�����ĵ�
        /// 1 -ͼƬ
        /// 2 -��Ƶ
		/// </summary>
		public int ResourceType
		{
			set{ _resourcetype=value;}
			get{return _resourcetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResourceAddr
		{
			set{ _resourceaddr=value;}
			get{return _resourceaddr;}
		}
		/// <summary>
		/// 0 --����
        /// 1--��������
        /// 2--��ҵ�ƻ���
        /// 3 --��Ŀ��Ƶչ��
		/// </summary>
		public int ResourceProperty
		{
			set{ _resourceproperty=value;}
			get{return _resourceproperty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] ResourcePassword
		{
			set{ _resourcepassword=value;}
			get{return _resourcepassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpDate
		{
			set{ _update=value;}
			get{return _update;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
        #endregion Model
    }
}
