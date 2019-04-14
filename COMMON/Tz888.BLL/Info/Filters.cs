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
	/// ��������
	/// </summary>
	public class Filters
	{
        private static readonly IConn dal = DataAccess.CreateIConn();
		public Filters()
		{

		}
		/// <summary>
		/// �ж��û��Ƿ񱻽��Ե�Ƶ��
		/// </summary>
		/// <param name="LoginName">��¼��</param>
		/// <param name="Menu">Ƶ��</param>
		/// <returns>�����Ե������ͽ��Եķ�ʽ�Լ����Ե�����</returns>
		public static string IsForbids(string LoginName,string Menu)
		{
			DataTable dtAll=dal.GetList("ForbidsTab","*","ForbidsDate",1,1,0,1,"FLoginName='"+LoginName+"' and ForbidsMenu='All'");//�����ж�ʱ��ȫ������
			if(dtAll.Rows.Count>0)
			{
				if(dtAll.Rows[0]["ForbidsType"].ToString()=="1")//���ý���
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
					if(dtMenu.Rows[0]["ForbidsType"].ToString()=="1")//���ý���
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
		/// ��ʾ
		/// </summary>
		/// <param name="str"></param>
		/// <returns>��ʾҳ��</returns>
		public static string MsgPage(string str)
		{

			string[] p=str.Split('|');
			return "../../msgPage.aspx?menu="+p[0].Trim()+"&type="+p[1].Trim()+"&days="+p[2].Trim();
		}
		/// <summary>
		/// �Ƿ����ý���
		/// </summary>
		/// <param name="LoginName"></param>
		/// <returns></returns>
		public static bool IsForbidsForEver(string LoginName,string Menu)
		{
            
			DataTable dt=dal.GetList("ForbidsTab","*","''",1,1,0,1,"FLoginName='"+LoginName+"' and ForbidsMenu='"+Menu+"'");
			if(dt.Rows[0]["ForbidsType"].ToString()=="1")//���ý���
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// ���㱻���Ե�����
		/// </summary>
		/// <param name="ForbidsDate">���Ե�����</param>
		/// <returns>ʱ����</returns>
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
			if(diff.Days<Days)//�����ڽ�����
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// ���췢���̻�������
		/// </summary>
		/// <param name="LoginName"></param>
		/// <returns>�Ƿ�ﵽ��������</returns>
		public static bool LimitCount(string LoginName)
		{
			StreamReader sr=new StreamReader(System.Web.HttpContext.Current.Request.PhysicalApplicationPath.ToString()+"OpporCount.txt",Encoding.GetEncoding("gb2312"));
			string strCount=sr.ReadToEnd().Trim();
			sr.Close();
			DataTable dt=dal.GetList("MainInfoTab","InfoID","InfoID",1,1,1,1,"LoginName='"+LoginName+"' and delstatus=0 and InfoTypeID='Oppor' and PublishT between '"+DateTime.Now.AddDays(-1)+"' and '"+DateTime.Now.AddDays(1)+"'");
			if(Convert.ToInt32(dt.Rows[0].ItemArray[0])>Convert.ToInt32(strCount))//������������ﵽ����
			{
				return true;
			}
			else
			{			
				return false;
			}
		}
		/// <summary>
		/// �ж��̻������Ƿ��ظ�  �Ƿ���ڹ��˴�
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
		/// ��Ϣ�ؼ��ֹ���
		/// </summary>
		/// <param name="str">���˵����</param>
		/// <returns>�����˴ʵĴ�</returns>
		public static string CheckWords(string str)
		{
			//����һ���飬д��Ҫ����֮�ַ���
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
					word=BadWords[i].Trim();//���صĹ��˴� Ϊ������Ϣ�Ϸ�
				}
			}
			return word;
		} 
		
	}
}
