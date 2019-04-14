using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Text.RegularExpressions;
using SharpICTCLAS;

namespace Tz888.Common
{
    public class Ictclas
    {
        private static WordSegment wordSegment = null;
        public static WordSegment GetWordSegmentInstance()
        {
            if (wordSegment == null)
            {
                wordSegment = new WordSegment();
                wordSegment.InitWordSegment(ConfigurationManager.AppSettings["IctclasData"]);
                return wordSegment;
            }
            else
                return wordSegment;
        }
        public static string GetIctclasResult(string KeyWord)
        {
            string sWord = "";
            string str2 = KeyWord.Replace("“", "|").Replace("”", "|");
            if ((str2.IndexOf("|") == 0) && (str2.LastIndexOf("|") == (str2.Length - 1)))
            {
                return str2;
            }
            string[] strArray = Regex.Split(ConfigurationManager.AppSettings["Neuter"], ",", RegexOptions.IgnoreCase);
            string str3 = KeyWord;
            string str4 = "";
            string str5 = "";
            foreach (string str6 in strArray)
            {
                if (KeyWord.IndexOf(str6) == 0)
                {
                    str3 = KeyWord.Substring(str6.Length);
                    break;
                }
            }
            if ((str3 == "") || (str3 == null))
            {
                str5 = KeyWord;
            }
            else
            {
                str4 = str3;
                foreach (string str6 in strArray)
                {
                    if ((str4.Length >= str6.Length) && (str4.LastIndexOf(str6) == (str4.Length - str6.Length)))
                    {
                        str4 = str3.Substring(0, str4.Length - str6.Length);
                        break;
                    }
                }
            }
            if ((str4 == "") || (str4 == null))
            {
                str5 = KeyWord;
            }
            else
            {
                str5 = str4;
            }
            List<WordResult[]> list = GetWordSegmentInstance().Segment(str5);
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < (list[i].Length - 1); j++)
                {
                    if (!ClearZao(list[i][j].sWord))
                    {
                        if (sWord == "")
                        {
                            sWord = list[i][j].sWord;
                        }
                        else
                        {
                            sWord = sWord + "," + list[i][j].sWord;
                        }
                    }
                }
            }
            return sWord;
        }

        public static bool ClearZao(string OldStr)
        {
            string[] strArray = "(,),（,）,',“,”,\",，,。,.,<,《,>,》,/,？,?,;,；,[,],[,],{,},!,@,#,$,%,^,&,*,！,\x00b7,#,￥,\\,、,……,——,or,and,的,地,得,不,以,了,再".Split(new char[] { ',' });
            foreach (string str3 in strArray)
            {
                if (OldStr.Trim() == str3.Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public static string ParseText(string htmlText, string regText, string groupName)
        {
            StringBuilder builder = new StringBuilder();
            MatchCollection matchs = new Regex(regText).Matches(htmlText);
            foreach (Match match in matchs)
            {
                GroupCollection groups = match.Groups;
                builder.Append(groups[groupName].Value + "\r\n");
            }
            return builder.ToString();
        }
    }
}
