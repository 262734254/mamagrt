using System;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using Tz888.IDAL;
using Tz888.DALFactory;
using Tz888.Model.Info;

namespace Tz888.BLL.Info
{
	/// <summary>
	/// 发布过滤
	/// </summary>
	public class Filters
	{
        private static readonly IConn dal = DataAccess.CreateIConn();
		public Filters()
		{

		}
		/// <summary>
		/// 判断用户是否被禁言的频道
		/// </summary>
		/// <param name="LoginName">登录名</param>
		/// <param name="Menu">频道</param>
		/// <returns>被禁言的天数和禁言的方式以及禁言的天数</returns>
		public static string IsForbids(string LoginName,string Menu)
		{
			DataTable dtAll=dal.GetList("ForbidsTab","*","ForbidsDate",1,1,0,1,"FLoginName='"+LoginName+"' and ForbidsMenu='All'");//首先判断时候全部禁言
			if(dtAll.Rows.Count>0)
			{
				if(dtAll.Rows[0]["ForbidsType"].ToString()=="1")//永久禁言
				{
					return dtAll.Rows[0]["ForbidsDate"].ToString()+"|"+dtAll.Rows[0]["ForbidsType"].ToString()+"|"+dtAll.Rows[0]["ForbidsDays"].ToString();
				}
				else
				{
					if(FDays(Convert.ToDateTime(dtAll.Rows[0]["ForbidsDate"]),Convert.ToInt32(dtAll.Rows[0]["ForbidsDays"])))
					{
						return dtAll.Rows[0]["ForbidsDate"].ToString()+"|"+dtAll.Rows[0]["ForbidsType"].ToString()+"|"+dtAll.Rows[0]["ForbidsDays"].ToString();
					}
					else
					{
						return "";
					}
				}
			}
			else
			{
				DataTable dtMenu=dal.GetList("ForbidsTab","*","ForbidsDate",1,1,0,1,"FLoginName='"+LoginName+"' and ForbidsMenu='"+Menu+"'");
				if(dtMenu.Rows.Count>0)
				{
					if(dtMenu.Rows[0]["ForbidsType"].ToString()=="1")//永久禁言
					{
						return dtMenu.Rows[0]["ForbidsDate"].ToString()+"|"+dtMenu.Rows[0]["ForbidsType"].ToString()+"|"+dtMenu.Rows[0]["ForbidsDays"].ToString();
					}
					else
					{
						if(FDays(Convert.ToDateTime(dtMenu.Rows[0]["ForbidsDate"]),Convert.ToInt32(dtMenu.Rows[0]["ForbidsDays"])))
						{
							return dtMenu.Rows[0]["ForbidsMenu"].ToString()+"|"+dtMenu.Rows[0]["ForbidsType"].ToString()+"|"+dtMenu.Rows[0]["ForbidsDays"].ToString();
						}
						else
						{
							return "";
						}
					}
				}
				else
				{
					return "";
				}
			}
		}
		/// <summary>
		/// 提示
		/// </summary>
		/// <param name="str"></param>
		/// <returns>提示页面</returns>
		public static string MsgPage(string str)
		{

			string[] p=str.Split('|');
			return "../../msgPage.aspx?menu="+p[0].Trim()+"&type="+p[1].Trim()+"&days="+p[2].Trim();
		}
		/// <summary>
		/// 是否被永久禁言
		/// </summary>
		/// <param name="LoginName"></param>
		/// <returns></returns>
		public static bool IsForbidsForEver(string LoginName,string Menu)
		{
            
			DataTable dt=dal.GetList("ForbidsTab","*","''",1,1,0,1,"FLoginName='"+LoginName+"' and ForbidsMenu='"+Menu+"'");
			if(dt.Rows[0]["ForbidsType"].ToString()=="1")//永久禁言
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 计算被禁言的天数
		/// </summary>
		/// <param name="ForbidsDate">禁言的日期</param>
		/// <returns>时间间隔</returns>
//		public static int FDays(DateTime ForbidsDate)
//		{
//			DateTime  date1   =   new    DateTime(Convert.ToDateTime(ForbidsDate).Year,Convert.ToDateTime(ForbidsDate).Month,Convert.ToDateTime(ForbidsDate).Day);   
//			DateTime  date2 =   new   DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);   
//			System.TimeSpan   diff   =   date2   -  date1 ;
//			return diff.Days;
//		}
		public static bool FDays(DateTime ForbidsDate,int Days)
		{
			DateTime  date1   =   new    DateTime(Convert.ToDateTime(ForbidsDate).Year,Convert.ToDateTime(ForbidsDate).Month,Convert.ToDateTime(ForbidsDate).Day);   
			DateTime  date2 =   new   DateTime(System.DateTime.Now.Year,System.DateTime.Now.Month,System.DateTime.Now.Day);   
			System.TimeSpan   diff   =   date2   -  date1 ;
			if(diff.Days<Days)//还处于禁言期
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 当天发布商机的条数
		/// </summary>
		/// <param name="LoginName"></param>
		/// <returns>是否达到发布上限</returns>
		public static bool LimitCount(string LoginName)
		{
			StreamReader sr=new StreamReader(System.Web.HttpContext.Current.Request.PhysicalApplicationPath.ToString()+"OpporCount.txt",Encoding.GetEncoding("gb2312"));
			string strCount=sr.ReadToEnd().Trim();
			sr.Close();
			DataTable dt=dal.GetList("MainInfoTab","InfoID","InfoID",1,1,1,1,"LoginName='"+LoginName+"' and delstatus=0 and InfoTypeID='Oppor' and PublishT between '"+DateTime.Now.AddDays(-1)+"' and '"+DateTime.Now.AddDays(1)+"'");
			if(Convert.ToInt32(dt.Rows[0].ItemArray[0])>Convert.ToInt32(strCount))//如果发布数量达到上限
			{
				return true;
			}
			else
			{			
				return false;
			}
		}
		/// <summary>
		/// 判断商机标题是否重复  是否存在过滤词
		/// </summary>
		/// <param name="TitleText"></param>
		/// <returns></returns>
		public static bool JudgeTitle(string TitleText)
		{
			DataTable dt=dal.GetList("MainInfoTab","InfoID","InfoID",1,1,1,1,"Title='"+TitleText+"' and infoTypeID='Oppor'");
			if(Convert.ToInt32(dt.Rows[0].ItemArray[0])>0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 信息关键字过滤
		/// </summary>
		/// <param name="str">过滤的语句</param>
		/// <returns>被过滤词的词</returns>
		public static string CheckWords(string str)
		{
			//创建一数组，写入要过滤之字符串
			StreamReader sr=new StreamReader(System.Web.HttpContext.Current.Request.PhysicalApplicationPath.ToString()+"strFilters.txt",Encoding.GetEncoding("gb2312"));
			string strFilter=sr.ReadToEnd().Trim();
			sr.Close();
			string[] BadWords=strFilter.Split(',');
			string word="";
			System.Text.RegularExpressions.Regex re;
			for(int i=0;i<BadWords.Length;i++)
			{
				re=new System.Text.RegularExpressions.Regex(BadWords[i]);
				if(re.Match(str).Success)
				{
					word=BadWords[i].Trim();//返回的过滤词 为空则信息合法
				}
			}
			return word;
		} 
		
	}
}
