using System;
using System.Collections.Generic;
using System.Text;

namespace Tz888.BLL.Search
{
    public class SearchCommonBLL
    {
      
        #region  查询条件函数
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

        //查询条件中查询的关键字为数组
        public static void AddKeyWordCriteria(
           ref System.Text.StringBuilder Criteria,
           string Left,
           string[] KeyWords,
           bool IsQuote,
           bool IsRange,
           string InfoType,
           bool IsUserContextSearch)
        {
            StringBuilder KeyCriteria = new StringBuilder("");
           
            for (int i = 0; i < KeyWords.Length; i++)
            {

                //增加标题条件
                AddORCriteria(ref  KeyCriteria, Left, KeyWords[i], IsQuote, IsRange);
                //增加关键词条件
                AddORCriteria(ref  KeyCriteria, "KeyWord", KeyWords[i], IsQuote, IsRange);
            }

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


        private static void SearchContext(
            ref System.Text.StringBuilder KeyCriteria,
            string[] KeyWords,
            bool IsQuote,
            bool IsRange,
            string InfoType,
            bool IsUserContextSearch)
        {
            if (IsUserContextSearch && InfoType != null)
            {
                for (int i = 0; i < KeyWords.Length; i++)
                {
                    AddORCriteria(ref  KeyCriteria, "ContentKeyWord", KeyWords[i].Trim(), IsQuote, IsRange);
                    switch (InfoType.Trim())
                    {

                        case "Bid":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "BidFinish":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Capital":
                            AddORCriteria(ref  KeyCriteria, "ComAbout", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Strategy", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ComAboutBrief", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "StrategyBrief", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "IncomeAbout", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "IncomeAboutBrief", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "CarveOut":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "InvestReturn", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Cases":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Elite":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Exhibition":
                            AddORCriteria(ref  KeyCriteria, "Entrepreneur", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Assistant", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Undertake", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ExhibitionScale", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ExhibitionBrief", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Fee", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Expert":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ReplyContent", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Merchant":
                            AddORCriteria(ref  KeyCriteria, "ZoneAbout", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ZoneAboutBrief", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "News":
                            AddORCriteria(ref  KeyCriteria, "Summary", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Oppor":
                            AddORCriteria(ref  KeyCriteria, "Analysis", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Request", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Flow", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Policy":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Project":
                            AddORCriteria(ref  KeyCriteria, "ComAbout", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ComAboutBrief", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ProjectAbout", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "ProjectAboutBrief", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Property":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Transform":
                            AddORCriteria(ref  KeyCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            AddORCriteria(ref  KeyCriteria, "Remark", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        default:
                            break;
                    }
                }
            }
        }





        //全部关键字查询
        private static void SearchContextAllKeyword(
            ref System.Text.StringBuilder KeyCriteria,
            string[] KeyWords,
            bool IsQuote,
            bool IsRange,
            string InfoType,
            bool IsUserContextSearch)
        {
            if (IsUserContextSearch && InfoType != null)
            {

                string strCriteria = "";
                StringBuilder ContentKeyWordCriteria = new StringBuilder("");
                StringBuilder ContentCriteria = new StringBuilder("");


                for (int i = 0; i < KeyWords.Length; i++)
                {

                    AddCriteria(ref  ContentKeyWordCriteria, "ContentKeyWord", KeyWords[i].Trim(), IsQuote, IsRange);
                }

                if (ContentKeyWordCriteria.ToString().ToString() != "")
                {
                    strCriteria = "(" + ContentKeyWordCriteria.ToString() + ") ";
                }

                for (int i = 0; i < KeyWords.Length; i++)
                {
                    #region
                    switch (InfoType.Trim())
                    {

                        case "Bid":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);


                            break;
                        case "BidFinish":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Capital":

                            AddCriteria(ref  ContentCriteria, "Strategy", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "CarveOut":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Cases":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Elite":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Exhibition":
                            AddCriteria(ref  ContentCriteria, "Entrepreneur", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Expert":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Merchant":
                            AddCriteria(ref  ContentCriteria, "ZoneAbout", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "News":

                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Oppor":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Policy":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Project":
                            AddCriteria(ref  ContentCriteria, "ProjectAbout", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Property":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Transform":
                            AddCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        default:
                            break;

                    }
                    #endregion
                }

                if (ContentCriteria.ToString().ToString() != "")
                {
                    strCriteria = strCriteria + "or (" + ContentCriteria.ToString() + ")";
                }



                if (KeyCriteria.ToString().Trim() != "")
                {
                    KeyCriteria.Append(" AND (" + strCriteria.ToString().Trim() + ")");
                }
                else
                {
                    KeyCriteria.Append("(" + strCriteria.ToString().Trim() + ")");
                }




            }
        }




        //不包含关键字查询
        private static void SearchNonContextAllKeyword(
            ref System.Text.StringBuilder KeyCriteria,
            string[] KeyWords,
            bool IsQuote,
            bool IsRange,
            string InfoType,
            bool IsUserContextSearch)
        {
            if (IsUserContextSearch && InfoType != null)
            {

                string strCriteria = "";
                StringBuilder ContentKeyWordCriteria = new StringBuilder("");
                StringBuilder ContentCriteria = new StringBuilder("");


                for (int i = 0; i < KeyWords.Length; i++)
                {

                    AddNonCriteria(ref  ContentKeyWordCriteria, "ContentKeyWord", KeyWords[i].Trim(), IsQuote, IsRange);
                }

                if (ContentKeyWordCriteria.ToString().ToString() != "")
                {
                    strCriteria = "(" + ContentKeyWordCriteria.ToString() + ") ";
                }

                for (int i = 0; i < KeyWords.Length; i++)
                {
                    #region
                    switch (InfoType.Trim())
                    {

                        case "Bid":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);


                            break;
                        case "BidFinish":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Capital":

                            AddNonCriteria(ref  ContentCriteria, "Strategy", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "CarveOut":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Cases":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Elite":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Exhibition":
                            AddNonCriteria(ref  ContentCriteria, "Entrepreneur", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Expert":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Merchant":
                            AddNonCriteria(ref  ContentCriteria, "ZoneAbout", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "News":

                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Oppor":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Policy":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);

                            break;
                        case "Project":
                            AddNonCriteria(ref  ContentCriteria, "ProjectAbout", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Property":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        case "Transform":
                            AddNonCriteria(ref  ContentCriteria, "Content", KeyWords[i].Trim(), IsQuote, IsRange);
                            break;
                        default:
                            break;

                    }
                    #endregion
                }

                if (ContentCriteria.ToString().ToString() != "")
                {
                    strCriteria = strCriteria + "and (" + ContentCriteria.ToString() + ")";
                }

                if (KeyCriteria.ToString().Trim() != "")
                {
                    KeyCriteria.Append(" AND (" + strCriteria.ToString().Trim() + ")");
                }
                else
                {
                    KeyCriteria.Append("(" + strCriteria.ToString().Trim() + ")");
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
