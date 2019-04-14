using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
   /// <summary>
	/// ʵ����MemberResourceTab ����Ա���ϱ�  (����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class MemberResourceModel
	{
		public MemberResourceModel()
		{}
		#region Model
		private int _resourceid;
		private string _loginname;
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
		/// <summary>
		/// 
		/// </summary>
		public int ResourceID
		{
		set{ _resourceid=value;}
		get{return _resourceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LoginName
		{
		set{ _loginname=value;}
		get{return _loginname;}
		}
		/// <summary>
		/// ��Դ����
		/// </summary>
		public string ResourceName
		{
		set{ _resourcename=value;}
		get{return _resourcename;}
		}
		/// <summary>
		/// ��Դ�̱���
		/// </summary>
		public string ResourceTitle
		{
		set{ _resourcetitle=value;}
		get{return _resourcetitle;}
		}
		/// <summary>
		/// ��Դ����
		/// </summary>
		public string ResourceDescrib
		{
		set{ _resourcedescrib=value;}
		get{return _resourcedescrib;}
		}
		/// <summary>
        /// ��Դ����
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
		/// ��Դ��ַ
		/// </summary>
		public string ResourceAddr
		{
		set{ _resourceaddr=value;}
		get{return _resourceaddr;}
		}
		/// <summary>
        ///0 ��˾���ܣ���ͼƬ��
        ///1Ӫҵִ��
        ///2˰��Ǽ�֤(��˰)
        ///3˰��Ǽ�֤(��˰)
        ///4������֤��
        ///5����*/
		/// </summary>
		public int ResourceProperty
		{
		set{ _resourceproperty=value;}
		get{return _resourceproperty;}
		}
		/// <summary>
		/// ��Դ����
		/// </summary>
		public byte[] ResourcePassword
		{
		set{ _resourcepassword=value;}
		get{return _resourcepassword;}
		}
		/// <summary>
		/// �ϴ�����
		/// </summary>
		public DateTime UpDate
		{
		set{ _update=value;}
		get{return _update;}
		}
		/// <summary>
		/// �Ƿ�ɾ��
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

        public MemberResourceModel( string ResourceAddr,string ResourceDescrib)//���� ��ַ ����
        {
            this._resourceproperty = ResourceProperty;
            this._resourceaddr = ResourceAddr;
            this.ResourceDescrib = ResourceDescrib;
        }
		#endregion Model

	}
}