using System;
using System.Data;

namespace Tz888.SQLServerDAL.Pay1
{
	/// <summary>
	/// ���ƣ�������
	/// ��;��Ϊ�������ṩ����
	/// �������ڣ�2005-10-5
	/// </summary>
	public class ErrorBase
	{
		protected int mintErrorID;
		protected string mstrErrorMsg;

		public ErrorBase()
		{
			mintErrorID = 0;
			mstrErrorMsg = "";
		}

		public int ErrorID
		{
			get
			{
				return( this.mintErrorID );
			}
			set
			{
				this.mintErrorID = value;
			}
		}

		public string ErrorMsg
		{
			get
			{
				return( this.mstrErrorMsg );
			}
			set
			{
				this.mstrErrorMsg = value;
			}
		}

		public virtual bool Insert()
		{
			return( false );
		}

		public virtual bool Update()
		{
			return( false );
		}

		public virtual bool Delete()
		{
			return( false );
		}

		public virtual bool GetDetail(string Key )
		{
			return( false );
		}

		public virtual DataView GetList(
			string SelectCol,
			string Criteria,
			string OrderBy,
			ref long CurrentPage,
			long PageSize,
			ref long PageCount )
		{
			return( null );
		}
	}
}
