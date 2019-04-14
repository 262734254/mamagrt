using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model
{
   /// <summary>
	/// 实体类MemberResourceTab 。会员资料表  (属性说明自动提取数据库字段的描述信息)
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
		/// 资源名称
		/// </summary>
		public string ResourceName
		{
		set{ _resourcename=value;}
		get{return _resourcename;}
		}
		/// <summary>
		/// 资源短标题
		/// </summary>
		public string ResourceTitle
		{
		set{ _resourcetitle=value;}
		get{return _resourcetitle;}
		}
		/// <summary>
		/// 资源介绍
		/// </summary>
		public string ResourceDescrib
		{
		set{ _resourcedescrib=value;}
		get{return _resourcedescrib;}
		}
		/// <summary>
        /// 资源类型
		/// 0 -其他文档
        /// 1 -图片
        /// 2 -视频
		/// </summary>
		public int ResourceType
		{
		set{ _resourcetype=value;}
		get{return _resourcetype;}
		}
		/// <summary>
		/// 资源地址
		/// </summary>
		public string ResourceAddr
		{
		set{ _resourceaddr=value;}
		get{return _resourceaddr;}
		}
		/// <summary>
        ///0 公司介绍（多图片）
        ///1营业执照
        ///2税务登记证(国税)
        ///3税务登记证(地税)
        ///4荣誉和证书
        ///5其它*/
		/// </summary>
		public int ResourceProperty
		{
		set{ _resourceproperty=value;}
		get{return _resourceproperty;}
		}
		/// <summary>
		/// 资源密码
		/// </summary>
		public byte[] ResourcePassword
		{
		set{ _resourcepassword=value;}
		get{return _resourcepassword;}
		}
		/// <summary>
		/// 上传日期
		/// </summary>
		public DateTime UpDate
		{
		set{ _update=value;}
		get{return _update;}
		}
		/// <summary>
		/// 是否删除
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

        public MemberResourceModel( string ResourceAddr,string ResourceDescrib)//性质 地址 描述
        {
            this._resourceproperty = ResourceProperty;
            this._resourceaddr = ResourceAddr;
            this.ResourceDescrib = ResourceDescrib;
        }
		#endregion Model

	}
}