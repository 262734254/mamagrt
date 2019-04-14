using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace Tz888.SQLServerDAL
{
    /// <summary>
    /// ���ƣ�������
    /// ��;��Ϊ�������ṩ����
    /// �������ڣ�2007-8-20
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
                return (this.mintErrorID);
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
                return (this.mstrErrorMsg);
            }
            set
            {
                this.mstrErrorMsg = value;
            }
        }

        public virtual bool Insert()
        {
            return (false);
        }

        public virtual bool Update()
        {
            return (false);
        }

        public virtual bool Delete()
        {
            return (false);
        }

        public virtual bool GetDetail(string Key)
        {
            return (false);
        }

        public virtual DataView GetList(
            string SelectCol,
            string Criteria,
            string OrderBy,
            ref long CurrentPage,
            long PageSize,
            ref long PageCount)
        {
            return (null);
        }
    }
}
