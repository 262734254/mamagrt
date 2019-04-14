using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Info
{
    public class SetInfoTypeRef
    {
        static string[] m_InfoTypeIDs =
            new string[]{
							"AD",
							"Attract",
							"Bid",
							"BidFinish",
							"Bulletin",
							"Capital",
							"CarveOut",
							"Cases",
							"Elite",
							"Exhibition",
							"Expert",
							"Merchant",
							"News",
							"Oppor",
							"Policy",
							"Project",
							"Property",
							"Transform"
						};
        static string[] m_SubTypeID1s =
            new string[]{
							"",						   
							"CountryCode",
							"IndustryBID",
							"",
							"TypeID",
							"IndustryBID",
							"CarveOutInfoType",
							"CasesTypeID",
							"EliteTypeID",
							"Industry",
							"ExpertTypeID",
							"MerchantTypeID",
							"NewsTypeID",
							"OpportunityType",
							"CountryCode",
							"IndustryBID",
							"",
							"CountryCode",
		};
        static string[] m_SubTypeID2s =
            new string[]{
							"",							  
							"ProvinceID",
							"IndustryMID",
							"",
							"",
							"IndustryMID",
							"IndustryCarveOutID",
							"",
							"",
							"ProvinceID",
							"",
							"ProvinceID",
							"",
							"ProvinceID",
							"ProvinceID",
							"IndustryMID",
							"",
							"ProvinceID"
						};
        static System.Collections.Hashtable m_InfotypeHT = new System.Collections.Hashtable();
        static SetInfoTypeRef()
        {
            for (int i = 0; i < m_InfoTypeIDs.Length; i++)
            {
                m_InfotypeHT[m_InfoTypeIDs[i]] = i;
            }
        }

        /// <summary>
        /// 返回信息类型对应的子类型字段名
        /// </summary>
        /// <param name="infoTypeID">信息类型ID</param>
        /// <param name="subTypeID1">子类型字段名1</param>
        /// <param name="subTypeID2">子类型字段名2</param>
        public static void GetSubTypeID(string infoTypeID, ref string subTypeID1, ref string subTypeID2)
        {
            Object v = m_InfotypeHT[infoTypeID];
            if (v != null)
            {
                int i = Convert.ToInt32(v);
                subTypeID1 = m_SubTypeID1s[i];
                subTypeID2 = m_SubTypeID2s[i];
            }
        }
    }
}
