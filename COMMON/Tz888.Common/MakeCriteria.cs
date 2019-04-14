using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace Tz888.Common
{
    public class MakeCriteria
    {
        #region  ��ѯ��������
        /// <summary>
        /// AND OR��ѯ
        /// </summary>
        /// <param name="Criteria"></param>
        /// <param name="SecondCriteria"></param>
        /// <param name="IsAnd"></param>
        public static void AddTwoCriteria(
            ref System.Text.StringBuilder Criteria,
            string SecondCriteria,
            bool IsAnd)
        {
            string strJoin = "";
            if (IsAnd)
            {//AND ����
                strJoin = " AND ";
            }
            else
            {
                strJoin = " OR ";
            }

            if (SecondCriteria.Trim() == string.Empty)
            {
                return;
            }

            if (Criteria.ToString().Trim() != string.Empty)
            {
                Criteria.Append(strJoin);
            }

            Criteria.Append("(" + SecondCriteria.Trim() + ")");
            Criteria.Insert(0, "(");
            Criteria.Append(")");
        }
        /// <summary>
        /// ���ȺŲ�ѯ
        /// </summary>
        /// <param name="Criteria">��������</param>
        /// <param name="Left">������ߵ��ֶ�</param>
        /// <param name="Right">�����ұߵĲ���</param>
        /// <param name="IsQuote">�Ƿ������(true ����������)</param>
        /// <param name="IsRange">�Ƿ�ģ��ƥ��(true ģ��ƥ�� false ��ȷƥ��)</param>
        public static void AddCriteria(
            ref System.Text.StringBuilder Criteria,
            string Left,
            string Right,
            bool IsQuote,
            bool IsRange)
        {
            if (Right.Trim() != "")
            {
                if (Criteria.ToString().Trim() != "")
                {
                    Criteria.Append(" AND ");
                }

                if (IsRange)
                {
                    Criteria.Append("(CHARINDEX('" + Right + "'," + Left + ")>0)");
                }
                else
                {
                    if (IsQuote)
                    {
                        Criteria.Append("(" + Left + "'" + Right + "')");
                    }
                    else
                    {
                        Criteria.Append("(" + Left + Right + ")");
                    }
                }
            }
        }
        /// <summary>
        /// �������ںŲ�ѯ
        /// </summary>
        /// <param name="Criteria">��������</param>
        /// <param name="Left">������ߵ��ֶ�</param>
        /// <param name="Right">�����ұߵĲ���</param>
        /// <param name="IsQuote">�Ƿ������(true ����������)</param>
        /// <param name="IsRange">�Ƿ�ģ��ƥ��(true ģ��ƥ�� false ��ȷƥ��)</param>
        public static void AddNonCriteria(
            ref System.Text.StringBuilder Criteria,
            string Left,
            string Right,
            bool IsQuote,
            bool IsRange)
        {
            if (Right.Trim() != "")
            {
                if (Criteria.ToString().Trim() != "")
                {
                    Criteria.Append(" AND ");
                }

                if (IsRange)
                {
                    Criteria.Append("(CHARINDEX('" + Right + "'," + Left + ")<=0)");
                }
                else
                {
                    if (IsQuote)
                    {
                        Criteria.Append("(" + Left + "'" + Right + "')");
                    }
                    else
                    {
                        Criteria.Append("(" + Left + Right + ")");
                    }
                }
            }
        }
        /// <summary>
        /// between
        /// </summary>
        /// <param name="Criteria">��������</param>
        /// <param name="DataField">�Ƚ��ֶ�</param>
        /// <param name="FromValue"></param>
        /// <param name="ToValue"></param>
        public static void AddDTCriteria(
            ref System.Text.StringBuilder Criteria,
            string DataField,
            string FromValue,
            string ToValue)
        {
            AddCriteria(ref  Criteria, DataField + ">=", FromValue, true, false);
            AddCriteria(ref  Criteria, DataField + "<=", ToValue, true, false);
        }

        public static void AddKeyWordCriteria(
            ref System.Text.StringBuilder Criteria,
            string Left,
            string Right,
            bool IsQuote,
            bool IsRange,
            string InfoType,
            bool IsUserContextSearch)
        {
            StringBuilder KeyCriteria = new StringBuilder("");

            //���ӱ�������
            //AddCriteria( ref  KeyCriteria, Left, Right, IsQuote, IsRange );

            //	string KeyWords[1] = Right.Trim();
            //	for( int i=0; i<KeyWords.Length; i++ )
            //	{

            //���ӱ�������
            AddORCriteria(ref  KeyCriteria, Left, Right.Trim(), IsQuote, IsRange);
            //���ӹؼ�������
            AddORCriteria(ref  KeyCriteria, "KeyWord", Right.Trim(), IsQuote, IsRange);
            //AddORCriteria( ref  KeyCriteria, "ContentKeyWord", KeyWords[i].Trim(), IsQuote, IsRange );
            //	}

            //��������
            //	SearchContext( ref  KeyCriteria, KeyWords, IsQuote, IsRange, InfoType, IsUserContextSearch );   

            if (KeyCriteria.ToString().Trim() != "")
            {
                if (Criteria.ToString().Trim() != "")
                {
                    Criteria.Append(" AND (" + KeyCriteria.ToString().Trim() + ")");
                }
                else
                {
                    Criteria.Append("(" + KeyCriteria.ToString().Trim() + ")");
                }
            }
        }




        //ȫ���ؼ��ֲ�ѯ
        public static void AddAllKeyWordCriteria(
            ref System.Text.StringBuilder Criteria,
            string Left,
            string Right,
            bool IsQuote,
            bool IsRange,
            string InfoType,
            bool IsUserContextSearch)
        {
            StringBuilder KeyCriteria = new StringBuilder("");

            StringBuilder titleCriteri = new StringBuilder("");

            StringBuilder SearchContextCriteria = new StringBuilder("");

            string strCriteria = "";

            //���ӱ�������
            //AddCriteria( ref  KeyCriteria, Left, Right, IsQuote, IsRange );

            //string[] KeyWords = Right.Trim().Split(' ');


            //for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //���ӱ�������	
            AddCriteria(ref  titleCriteri, Left, Right.Trim(), IsQuote, IsRange);
            //	}

            if (titleCriteri.ToString().Trim() != "")
            {

                strCriteria = "(" + titleCriteri.ToString() + ") ";
            }




            //for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //���ӹؼ�������
            AddCriteria(ref  KeyCriteria, "KeyWord", Right.Trim(), IsQuote, IsRange);
            //	}

            if (KeyCriteria.ToString().Trim() != "")
            {

                strCriteria = strCriteria + "or (" + KeyCriteria.ToString() + ")";
            }


            //��������
            //	SearchContextAllKeyword( ref  SearchContextCriteria, KeyWords, IsQuote, IsRange, InfoType, IsUserContextSearch ); 

            if (SearchContextCriteria.ToString().Trim() != "")
            {
                strCriteria = strCriteria + "or (" + SearchContextCriteria.ToString() + ")";
            }

            if (strCriteria.ToString().Trim() != "")
            {
                if (Criteria.ToString().Trim() != "")
                {
                    Criteria.Append(" AND (" + strCriteria.ToString().Trim() + ")");
                }
                else
                {
                    Criteria.Append("(" + strCriteria.ToString().Trim() + ")");
                }
            }
        }


        //�������ؼ��ֲ�ѯ
        public static void AddNonKeyWordCriteria(
            ref System.Text.StringBuilder Criteria,
            string Left,
            string Right,
            bool IsQuote,
            bool IsRange,
            string InfoType,
            bool IsUserContextSearch)
        {
            StringBuilder KeyCriteria = new StringBuilder("");

            StringBuilder titleCriteri = new StringBuilder("");

            StringBuilder SearchContextCriteria = new StringBuilder("");

            string strCriteria = "";

            //���ӱ�������
            //AddCriteria( ref  KeyCriteria, Left, Right, IsQuote, IsRange );

            //string[] KeyWords = Right.Trim().Split(' ');


            //	for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //���ӱ�������	
            AddNonCriteria(ref  titleCriteri, Left, Right.Trim(), IsQuote, IsRange);
            //	}

            if (titleCriteri.ToString().Trim() != "")
            {

                strCriteria = "(" + titleCriteri.ToString() + ") ";
            }




            //	for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //���ӹؼ�������
            AddNonCriteria(ref  KeyCriteria, "KeyWord", Right.Trim(), IsQuote, IsRange);
            //	}

            if (KeyCriteria.ToString().Trim() != "")
            {

                strCriteria = strCriteria + "and (" + KeyCriteria.ToString() + ")";
            }


            //��������
            //	SearchNonContextAllKeyword( ref  SearchContextCriteria, KeyWords, IsQuote, IsRange, InfoType, IsUserContextSearch ); 

            if (SearchContextCriteria.ToString().Trim() != "")
            {
                strCriteria = strCriteria + "and (" + SearchContextCriteria.ToString() + ")";
            }

            if (strCriteria.ToString().Trim() != "")
            {
                if (Criteria.ToString().Trim() != "")
                {
                    Criteria.Append(" AND (" + strCriteria.ToString().Trim() + ")");
                }
                else
                {
                    Criteria.Append("(" + strCriteria.ToString().Trim() + ")");
                }
            }
        }
        #endregion

        #region  ��ѯ��������(OR��ϵ)
        public static void AddORCriteria(
            ref System.Text.StringBuilder Criteria,
            string Left,
            string Right,
            bool IsQuote,
            bool IsRange)
        {
            if (Right.Trim() != "")
            {
                if (Criteria.ToString().Trim() != "")
                {
                    Criteria.Append(" OR ");
                }

                if (IsRange)
                {
                    Criteria.Append("(CHARINDEX('" + Right + "'," + Left + ")>0)");
                }
                else
                {
                    if (IsQuote)
                    {
                        Criteria.Append("(" + Left + "'" + Right + "')");
                    }
                    else
                    {
                        Criteria.Append("(" + Left + Right + ")");
                    }
                }

                if (Criteria.ToString().Trim() != "")
                {
                    Criteria.Insert(0, "(");//����������
                    Criteria.Append(")");//����������
                }
            }
        }

        #endregion
    }
}
