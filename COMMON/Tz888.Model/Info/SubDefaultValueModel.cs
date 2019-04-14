using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    public class SubDefaultValueModel
    {
        #region Private fields ------------------------------------------------------

        private long m_ID;
        private long m_SetDefaultValueID;
        private byte m_DefType;
        private string m_FromColumn;
        private string m_FromColumnName;
        private string m_FromValue;
        private byte m_IsDefaultSelect;
        private byte m_IsNeeded;
        private byte m_Seq;
        private string m_Remark;

        #endregion

        #region Properties ------------------------------------------------------

        public long ID
        {
            get { return m_ID; }
            set { m_ID = value; }
        }

        public long SetDefaultValueID
        {
            get { return m_SetDefaultValueID; }
            set { m_SetDefaultValueID = value; }
        }

        public byte DefType
        {
            get { return m_DefType; }
            set { m_DefType = value; }
        }

        public string FromColumn
        {
            get { return m_FromColumn; }
            set { m_FromColumn = value; }
        }

        public string FromColumnName
        {
            get { return m_FromColumnName; }
            set { m_FromColumnName = value; }
        }

        public string FromValue
        {
            get { return m_FromValue; }
            set { m_FromValue = value; }
        }

        public byte IsDefaultSelect
        {
            get { return m_IsDefaultSelect; }
            set { m_IsDefaultSelect = value; }
        }

        public byte IsNeeded
        {
            get { return m_IsNeeded; }
            set { m_IsNeeded = value; }
        }

        public byte Seq
        {
            get { return m_Seq; }
            set { m_Seq = value; }
        }

        public string Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        }

        #endregion
    }
}
