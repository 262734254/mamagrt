using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.Model.Info
{
    public class InfoDefaultDEFModel
    {
		private long m_ID;
		private long m_InfoID;
		private long m_SubDefaultValueID;
		private byte m_IsSelect;
		private byte m_DefType;

        public InfoDefaultDEFModel()
        {

        }
		
		public InfoDefaultDEFModel(long InfoID, long SubDefaultValueID, byte IsSelect, byte DefType)
		{
			m_InfoID = InfoID;
			m_SubDefaultValueID = SubDefaultValueID;
			m_IsSelect = IsSelect;
			m_DefType = DefType;
		}
		
		
		public long ID
		{
			get	{ return m_ID; }
			set	{ m_ID = value; }
		}
		
		public long InfoID
		{
			get	{ return m_InfoID; }
			set	{ m_InfoID = value; }
		}
		
		public long SubDefaultValueID
		{
			get	{ return m_SubDefaultValueID; }
			set	{ m_SubDefaultValueID = value; }
		}
		
		public byte IsSelect
		{
			get	{ return m_IsSelect; }
			set	{ m_IsSelect = value; }
		}
		
		public byte DefType
		{
			get	{ return m_DefType; }
			set	{ m_DefType = value; }
		}
						
    }
}
