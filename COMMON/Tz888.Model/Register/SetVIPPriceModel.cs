using System;
using System.Collections.Generic;
using System.Text;
using Tz888.Model.Register;
namespace Tz888.Model.Register
{
   public class SetVIPPriceModel
    {
       public SetVIPPriceModel()
		{}
		#region Model
		private int _vippriceid;
		private string _pricecode;
		private int _cycleid;
		private string _managetypeid;
		private decimal _price;
		private decimal _presentpoint;
		private int _presentintegral;
		private int _presentextension;
		private int _presentcustommessage;
		private string _remark;
		/// <summary>
		/// �ظ�ͨ��Ա�۸�ID
		/// </summary>
		public int VIPPriceID
		{
		set{ _vippriceid=value;}
		get{return _vippriceid;}
		}
		/// <summary>
		/// �۸����
		/// </summary>
		public string PriceCode
		{
		set{ _pricecode=value;}
		get{return _pricecode;}
		}
		/// <summary>
		/// ��Ա����ID
		/// </summary>
		public int CycleID
		{
		set{ _cycleid=value;}
		get{return _cycleid;}
		}
		/// <summary>
		/// ��Ա����
		/// </summary>
		public string ManageTypeID
		{
		set{ _managetypeid=value;}
		get{return _managetypeid;}
		}
		/// <summary>
		/// �۸�
		/// </summary>
		public decimal Price
		{
		set{ _price=value;}
		get{return _price;}
		}
		/// <summary>
		/// ���͵���
		/// </summary>
		public decimal PresentPoint
		{
		set{ _presentpoint=value;}
		get{return _presentpoint;}
		}
		/// <summary>
		/// ���ͻ���
		/// </summary>
		public int PresentIntegral
		{
		set{ _presentintegral=value;}
		get{return _presentintegral;}
		}
		/// <summary>
		/// ���Ͷ����ƹ�����
		/// </summary>
		public int PresentExtension
		{
		set{ _presentextension=value;}
		get{return _presentextension;}
		}
		/// <summary>
		/// ���Ͷ��ƶ���
		/// </summary>
		public int PresentCustomMessage
		{
		set{ _presentcustommessage=value;}
		get{return _presentcustommessage;}
		}
		/// <summary>
		/// ��ע
		/// </summary>
		public string remark
		{
		set{ _remark=value;}
		get{return _remark;}
		}
		#endregion Model

	}
}

