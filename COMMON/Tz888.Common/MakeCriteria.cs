using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web.UI.HtmlControls;

namespace Tz888.Common
{
    public class MakeCriteria
    {
        #region  查询条件函数
        /// <summary>
        /// AND OR查询
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
            {//AND 连接
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
        /// 带等号查询
        /// </summary>
        /// <param name="Criteria">返回条件</param>
        /// <param name="Left">符号左边的字段</param>
        /// <param name="Right">符号右边的参数</param>
        /// <param name="IsQuote">是否带引号(true 参数带引号)</param>
        /// <param name="IsRange">是否模糊匹配(true 模糊匹配 false 精确匹配)</param>
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
        /// 带不等于号查询
        /// </summary>
        /// <param name="Criteria">返回条件</param>
        /// <param name="Left">符号左边的字段</param>
        /// <param name="Right">符号右边的参数</param>
        /// <param name="IsQuote">是否带引号(true 参数带引号)</param>
        /// <param name="IsRange">是否模糊匹配(true 模糊匹配 false 精确匹配)</param>
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
        /// <param name="Criteria">返回条件</param>
        /// <param name="DataField">比较字段</param>
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

            //增加标题条件
            //AddCriteria( ref  KeyCriteria, Left, Right, IsQuote, IsRange );

            //	string KeyWords[1] = Right.Trim();
            //	for( int i=0; i<KeyWords.Length; i++ )
            //	{

            //增加标题条件
            AddORCriteria(ref  KeyCriteria, Left, Right.Trim(), IsQuote, IsRange);
            //增加关键词条件
            AddORCriteria(ref  KeyCriteria, "KeyWord", Right.Trim(), IsQuote, IsRange);
            //AddORCriteria( ref  KeyCriteria, "ContentKeyWord", KeyWords[i].Trim(), IsQuote, IsRange );
            //	}

            //搜索内容
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




        //全部关键字查询
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

            //增加标题条件
            //AddCriteria( ref  KeyCriteria, Left, Right, IsQuote, IsRange );

            //string[] KeyWords = Right.Trim().Split(' ');


            //for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //增加标题条件	
            AddCriteria(ref  titleCriteri, Left, Right.Trim(), IsQuote, IsRange);
            //	}

            if (titleCriteri.ToString().Trim() != "")
            {

                strCriteria = "(" + titleCriteri.ToString() + ") ";
            }




            //for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //增加关键词条件
            AddCriteria(ref  KeyCriteria, "KeyWord", Right.Trim(), IsQuote, IsRange);
            //	}

            if (KeyCriteria.ToString().Trim() != "")
            {

                strCriteria = strCriteria + "or (" + KeyCriteria.ToString() + ")";
            }


            //搜索内容
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


        //不包含关键字查询
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

            //增加标题条件
            //AddCriteria( ref  KeyCriteria, Left, Right, IsQuote, IsRange );

            //string[] KeyWords = Right.Trim().Split(' ');


            //	for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //增加标题条件	
            AddNonCriteria(ref  titleCriteri, Left, Right.Trim(), IsQuote, IsRange);
            //	}

            if (titleCriteri.ToString().Trim() != "")
            {

                strCriteria = "(" + titleCriteri.ToString() + ") ";
            }




            //	for( int i=0; i<KeyWords.Length; i++ )
            //	{
            //增加关键词条件
            AddNonCriteria(ref  KeyCriteria, "KeyWord", Right.Trim(), IsQuote, IsRange);
            //	}

            if (KeyCriteria.ToString().Trim() != "")
            {

                strCriteria = strCriteria + "and (" + KeyCriteria.ToString() + ")";
            }


            //搜索内容
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

        #region  查询条件函数(OR关系)
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
                    Criteria.Insert(0, "(");//插入左括号
                    Criteria.Append(")");//插入右括号
                }
            }
        }

        #endregion
    }
}
