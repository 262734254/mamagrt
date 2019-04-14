using System;
namespace Tz888.Model.Professional
{
	/// <summary>
	/// ProfessionalTypeTbl:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����
		/// </summary>
		public int typeId
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
        /// �������
		/// </summary>
		public string typeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
        /// ����
		/// </summary>
		public int OrderId
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

