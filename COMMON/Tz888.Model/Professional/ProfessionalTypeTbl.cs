using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalTypeTbl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class ProfessionalTypeTbl
	{
		public ProfessionalTypeTbl()
		{}
		#region Model
		private int _typeid;
		private string _typename;
		private int _orderid;
		/// <summary>
        /// 主键
		/// </summary>
		public int typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
        /// 类别名称
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
        /// 排序
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

