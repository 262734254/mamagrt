using System;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections;
using System.Globalization;
using System.Security.Cryptography;
using System.Data;

namespace Tz888.BLL.PageStatic
{
    public class Common
    {
        private static System.Text.Encoding m_CurrentEncoding;//编码
		static Common()
		{
			string encodingName = ""; 
			try
			{
				encodingName =ConfigurationManager.AppSettings["EncodingName"].Trim();
			}
			catch
			{
				encodingName = "";
			}
			if(encodingName == "")
			{
				m_CurrentEncoding = System.Text.Encoding.Default;
			}
			else
			{
				try
				{
					m_CurrentEncoding = System.Text.Encoding.GetEncoding(encodingName);
				}
				catch
				{
					m_CurrentEncoding = System.Text.Encoding.Default;
				}
			}
		}

	    public Common()
		{
		}


		public static System.Text.Encoding GetEncoding()
		{
			return m_CurrentEncoding;
		}

		#region 转换字符中的反叙杠
		/// <summary>
		/// 将输入的文本字符串转换成HTML代码，转换以下字符
		/// "\n\b" -> "<br>"
		/// 
		/// </summary>
		/// <param name="strTxt">来自文本框的字符串</param>
		/// <returns>返回HTML可识别字符串</returns>
		public static string TxtConvert(string strTxt)
		{
			string strTmp = strTxt;
			strTmp = strTmp.Replace("\\","/");
			return strTmp;
		}
		#endregion

		#region 将输入的文本字符串转换成HTML代码
		/// <summary>
		/// 将输入的文本字符串转换成HTML代码，转换以下字符
		/// "\n\b" -> "<br>"
		/// 
		/// </summary>
		/// <param name="strTxt">来自文本框的字符串</param>
		/// <returns>返回HTML可识别字符串</returns>
		public static string TxtToHtml(string strTxt)
		{
			string strTmp = strTxt;
			strTmp = strTmp.Replace("<","&lt;");
			strTmp = strTmp.Replace(">"," &gt;");
			strTmp = strTmp.Replace(" ","&nbsp;");
			strTmp = strTmp.Replace("\r\n","<br>");
			return strTmp;
		}
		#endregion

		#region 将输入的HTML转换为可以被文本框识别的格式
		/// <summary>
		/// 将输入的HTML转换为可以被文本框识别的格式
		/// </summary>
		/// <param name="strHtml">输入HTML的字符串</param>
		/// <returns></returns>
		public static string HtmlToTxt(string strHtml)
		{
			string strTmp = strHtml;
			strTmp = strTmp.Replace("<br>", "\r\n");
			strTmp = strTmp.Replace("&lt;", "<");
			strTmp = strTmp.Replace("&gt;", ">");
			strTmp = strTmp.Replace("&nbsp;", " ");
			strTmp = strTmp.Replace("&nbsp", " ");
			return strTmp;
		}
		#endregion
		
		#region 创建上传文件的文件名
		/// <summary>
		/// 创建上传文件的文件名
		/// 文件名规则
		/// 年月日时分秒+５位随机数［共１９位］
		/// </summary>
		/// <param name="InfoTypeID">信息的类型</param>
		/// <returns></returns>
		public static string CreatePicName()
		{
			DateTime CurrentTime = DateTime.Now;
			string TimeName = CurrentTime.Year.ToString() + CurrentTime.Month.ToString("00") 
				+ CurrentTime.Day.ToString("00") + CurrentTime.Hour.ToString("00") 
				+ CurrentTime.Minute.ToString("00") + CurrentTime.Second.ToString("00");
			Random rnd = new Random();			
			TimeName += rnd.Next(100000).ToString("00000");			
			return TimeName;
		}
		#endregion

		#region 将指定目录的所有文件全部COPY另一个目录下 --------------------------------- [代理商使用]
		/// <summary>
		/// 将指定目录的所有文件全部COPY另一个目录下
		/// </summary>
		/// <param name="localPath">要copy的目录夹,代理商根目录以下的路径</param>
		/// <param name="DestPath">目标文件夹</param>
		/// <returns></returns>
		public static int CopyAll(string localPath, string DestPath, ref string DestFullPath)
		{
            string localFullPath = (string)ConfigurationManager.AppSettings["AgentWebRootPath"];
			localFullPath += localPath;
			if (!Directory.Exists(localFullPath))
				return 0;

            DestFullPath = (string)ConfigurationManager.AppSettings["AgentWebRootPath"];
			DestFullPath += DestPath;
			if (!Directory.Exists(DestFullPath))//不存在则
				Directory.CreateDirectory(DestFullPath);
			
			// Create a reference to the current directory.
			DirectoryInfo di = new DirectoryInfo(localFullPath);
			// Create an array representing the files in the current directory.
			FileInfo[] fi = di.GetFiles();			
			// 开始COPY文件
			string localFile = "";
			string destFile = "";
			foreach (FileInfo fiTemp in fi)
			{
				localFile = localFullPath + "\\" + fiTemp.Name;
				destFile = DestFullPath + "\\" + fiTemp.Name;
				try
				{
					File.Copy(localFile, destFile, true);				
				}
				catch
				{
					//pass
				}
			}

			return 1;				
		}
		#endregion

		#region 获取某信息类型的图片上传路径
		/// <summary>
		/// 获取某信息类型的图片上传路径
		/// </summary>
		/// <param name="InfoType">信息类型[如news]</param>
		/// <param name="IsFullPath">是否是全路径</param>
		/// <returns>返回d:\upload\News\200508\dd.gif</returns>
		public static string GetUploadPath(string InfoType, bool IsFullPath)
		{
			string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
			ServerPath = "InfoImage\\" + InfoType;
			DateTime timeC = DateTime.Now;			
			ServerPath += "\\" + timeC.Year.ToString() + timeC.Month.ToString() + "\\";
			//根据当前月创建文件夹
			if (!Directory.Exists(ServerRootPath + ServerPath))
				Directory.CreateDirectory(ServerRootPath + ServerPath);
			#region 检查整个目录是否存在
			#endregion
			if (IsFullPath)
				return ServerRootPath + ServerPath;
			else
				return ServerPath;
		}
		#endregion

		#region 获取某信息类型的图片上传跟目录路径
		public static string GetUploadRootPath()
		{
            string ServerPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
			return ServerPath;
		}
		#endregion

		#region 获取某信息类型的图片临时文件路径
		/// <summary>
		/// 获取某信息类型的图片临时文件路径
		/// </summary>
		/// <param name="IsFullPath">是否是全路径</param>
		/// <returns>临时目录</returns>
		public static string GetTmpUploadPath(bool IsFullPath)
		{
			string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
			ServerPath = "InfoImage\\TmpFile\\";			
			//根据当前月创建文件夹
			if (!Directory.Exists(ServerRootPath + ServerPath))
				Directory.CreateDirectory(ServerRootPath + ServerPath);
			#region 检查整个目录是否存在
			#endregion
			if (IsFullPath)
				return ServerRootPath + ServerPath;
			else
				return ServerPath;
		}
		#endregion

		#region 获取图片的域名
		public static string GetImageDomain()
		{
            string ImageDomain = (string)ConfigurationManager.AppSettings["ImageDomain"];
			return ImageDomain;
		}
		#endregion

		#region 获取本地运行程序的位置（用于取模版）
		public static string GetLocalApplicationRoot()
		{
            string GetLocalApplicationRoot = (string)ConfigurationManager.AppSettings["LocalApplicationRoot"];
			GetLocalApplicationRoot = GetLocalApplicationRoot.Replace("/","\\");
			if(!GetLocalApplicationRoot.EndsWith("\\"))
			{
				GetLocalApplicationRoot += "\\";
			}
			return GetLocalApplicationRoot;
		}
		#endregion

		#region 获取前台运行程序的位置（用于写模版等）
		public static string GetApplicationRootPath()
		{
            string applicationRootPath = (string)ConfigurationManager.AppSettings["ApplicationRootPath"];
			applicationRootPath = applicationRootPath.Replace("/","\\");
			if(!applicationRootPath.EndsWith("\\"))
			{
				applicationRootPath = applicationRootPath + "\\";
			}
			return applicationRootPath;
		}
		#endregion
		#region
		public static string GetUpdateTimeFileName()
		{
			const string UPDATETIMEFILENAME = "log/LastestUpdateTime.txt";
			return GetApplicationRootPath() + UPDATETIMEFILENAME;	
		}

		#endregion

		#region  查询条件函数

		public static void AddTwoCriteria(
			ref System.Text.StringBuilder Criteria,
			string SecondCriteria,
			bool IsAnd)
		{
			string strJoin = "";
			if(IsAnd)
			{//AND 连接
				strJoin = " AND ";
			}
			else
			{
				strJoin = " OR ";
			}

			if ( SecondCriteria.Trim() == string.Empty)
			{
				return;
			}

			if(Criteria.ToString().Trim() != string.Empty)
			{
				Criteria.Append( strJoin ) ;
			}
			
			Criteria.Append("(" + SecondCriteria.Trim() + ")");	
			Criteria.Insert(0,"(");
			Criteria.Append(")");
		}


		public static void AddCriteria( 
			ref System.Text.StringBuilder Criteria,
			string Left,
			string Right,
			bool IsQuote,
			bool IsRange )
		{
			if( Right.Trim() != "" )
			{
				if( Criteria.ToString().Trim() != "" )
				{
					Criteria.Append(" AND ");
				}

				if( IsRange )
				{
					Criteria.Append( "(CHARINDEX('" + Right + "'," + Left + ")>0)" );
				}
				else
				{
					if( IsQuote )
					{
						Criteria.Append( "(" + Left + "'" + Right + "')" );
					}
					else
					{
						Criteria.Append( "(" + Left + Right + ")" );
					}
				}
			}
		}

		public static void AddDTCriteria( 
			ref System.Text.StringBuilder Criteria,
			string DataField,
			string FromValue,
			string ToValue )
		{
			AddCriteria( ref  Criteria, DataField + ">=", FromValue, true, false );
			AddCriteria( ref  Criteria, DataField + "<=", ToValue, true, false );
		}

		public static void AddORCriteria( 
			ref System.Text.StringBuilder Criteria,
			string Left,
			string Right,
			bool IsQuote,
			bool IsRange )
		{
			if( Right.Trim() != "" )
			{				
				if( Criteria.ToString().Trim() != "" )
				{
					Criteria.Append(" OR ");
				}

				if( IsRange )
				{
					Criteria.Append( "(CHARINDEX('" + Right + "'," + Left + ")>0)" );
				}
				else
				{
					if( IsQuote )
					{
						Criteria.Append( "(" + Left + "'" + Right + "')" );
					}
					else
					{
						Criteria.Append( "(" + Left + Right + ")" );
					}
				}

				if( Criteria.ToString().Trim() != "" )
				{
					Criteria.Insert(0,"(");//插入左括号
					Criteria.Append(")");//插入右括号
				}
			}
		}

		#endregion

		#region  提示信息函数
		public static void ShowMessage( 
			System.Web.UI.Page page,
			string Msg)
		{
			string script="<script language='javascript'>alert('" + Msg + "');</script>";
			page.RegisterClientScriptBlock("SetList",script);
		}
		public static void ShowMessage( 
			System.Web.HttpResponse response,
			string Msg)
		{
			response.Write("<script>alert('" + Msg + "');</script>");
		}
		public static void ShowMessage( 
			System.Web.UI.Page page,
			string Msg,
			string Url)
		{
			page.Response.Write("<script>alert('" + Msg + "');location.href='" + Url + "';</script>");
		}

		//只限内部员工系统使用
		public static bool SessionKeep(
			System.Web.UI.Page page,
			string Url)
		{
			//SESSION丢失
			if(page.Session.Count==0 ||
				page.Session["LoginName"] ==null ||
				page.Session["WorkType"] ==null)
			{
				page.Response.Write("<script>alert('操作超时！请重新登陆！');location.href='" + Url + "';</script>");
				return false ;
			}
			else
			{
				return true;
			}
		}
		#endregion

		#region 截获定长的字符串
		/// <summary>
		/// 截获定长的字符串
		/// </summary>
		/// <param name="source">源字符串</param>
		/// <param name="length">需要截获的长度</param>
		/// <param name="postfix">如果字符串被截短，需要添加什么样的后缀</param>
		/// <returns>截获后的字符串</returns>
		public static string FixLenth ( string source, int length, string postfix)
		{
			int postfixLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount( postfix);
			int srcLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount( source);

			if ( srcLength > length)
			{
				for ( int i = source.Length; i>0; i--)
				{
					srcLength = System.Text.Encoding.GetEncoding("GB2312").GetByteCount( source.Substring(0,i) );

					if ( srcLength <= length - postfixLength)
						return source.Substring(0,i) + postfix;
				}
				return "";
			}
			else
				return source;			
		}
		#endregion

		#region 返回热门指数 ----------------------------------------------------
		public static long  GetHotIndex( long hit, long ReplyTimes)
		{			
			return (hit / 10 + ReplyTimes / 2);
		}
		#endregion

		#region 返回投资、招商指数[价值指数] ----------------------------------------------------
		public static string  GetStrPriceIndex( string FixPriceID)
		{			
			int starNum = 0;
			switch (FixPriceID)
			{
				case "2" :
					starNum = 5;
					break;
				case "3":
					starNum = 4;
					break;
				case "4" :
					starNum = 3;
					break;
				default:
					starNum = 0;
					break;
			}

			string strStar = "";
			for(int i = 0; i< starNum; i++)
			{
				strStar += "☆";
			}
			return (strStar);
		}
		#endregion

		#region 根据输入的物理路径判断文件夹是否存在，如果不存在则创建
		public static bool BulidFolder(string path, bool HasFileName)
		{	
			string tmpPath = path.Replace("/", "\\");
			if (HasFileName)
			{
				//contain the file name
				tmpPath = tmpPath.Substring(0,tmpPath.LastIndexOf("\\"));
			}

			if (tmpPath.LastIndexOf("\\") != tmpPath.Length)
				tmpPath += "\\";

			if (Directory.Exists(tmpPath))
				return true;
			else
			{
				//没有找到指定的路径,需要逐层替换
				string tmpTestPath;
				string[] PathArr;				
				PathArr = tmpPath.Split(new char[]{'\\'});
				if (PathArr.Length < 2) //不是有效的物理路径(如不是 c:\)
					return false;
				
				tmpTestPath = PathArr[0] + "\\" + PathArr[1];

				if (!Directory.Exists(tmpTestPath)) 
					return false; // 没有需要的盘符 F:\

				try
				{
					for (int i = 2; i < PathArr.Length - 1; i++)
					{
						tmpTestPath += "\\" + PathArr[i];
						if (!Directory.Exists(tmpTestPath)) 
							Directory.CreateDirectory(tmpTestPath);
					}
				}
				catch
				{
					return false;
				}

				return true;

				//TmpFileName.LastIndexOf
			}
		}
		#endregion

		#region 返回某图片的所略图地址 ----------------------------------------------------
		public static string GetMiniPic( string Pic)
		{			
			//增加所略_S标识 
			string picOut = "";
			try
			{
				picOut = Pic.Insert(Pic.LastIndexOf("."),"_s");
			}
			catch
			{
				picOut = Pic;
			}
			return picOut;
		}
		#endregion

		#region 删除指定文件的操作 --------------------------------------------------
		/// <summary>
		/// 删除指定文件的操作
		/// </summary>
		/// <param name="htmlFilePath">不包含根目录的网站目录地址</param>
		/// <returns></returns>
		public static bool DeleteWebFile(string htmlFilePath, ref string deleteMsg)
		{
			if (htmlFilePath == "")
			{
				deleteMsg = "文件地址错误！无法删除文件！";
				return false;
			}
            string ApplicationRoot = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString();
			if (ApplicationRoot == "")
			{
				deleteMsg = "系统配置错误，请与管理员联系！";
				return false;
			}
			string TmpFilePath = ApplicationRoot + htmlFilePath;
			if (File.Exists(TmpFilePath))
			{
				File.Delete(TmpFilePath);
				deleteMsg = "已经删除指定的文件 -- " + htmlFilePath;
				return true;
			}
			else
			{
				deleteMsg = "系统配置错误，请与管理员联系！";
				return false;
			}

		}
		#endregion 

		#region 生成文件 --------------------------
		public static string createStaticPageFileName(string InfoTypeID, string InfoCode, long InfoID)
		{
            string prefix = ConfigurationManager.AppSettings[InfoTypeID].ToString().Trim();
			DateTime theDate = DateTime.Now;	
			if( prefix=="Capital/" || prefix =="Project/" || prefix =="Merchant/")
			{
				return prefix + theDate.Year.ToString("0000") + theDate.Month.ToString("00") + @"/" + InfoCode + "_" + InfoID + ".aspx";
			}
			else
			{
				return prefix + theDate.Year.ToString("0000") + theDate.Month.ToString("00") + @"/" + InfoCode + "_" + InfoID + ".shtml";
			}
		}
		#endregion

		#region　判断给定的字符串是否是数字

		public static bool IsNum(String str)
		{
			for(int i=0;i<str.Length;i++)
			{
				if(!Char.IsNumber(str,i))
					return false;
			}
			return true;
		}

		#endregion

		#region 获取缓存依赖的文件所在的文件夹
		public static string GetADDepDir()
		{
            string depDir = ConfigurationManager.AppSettings["ADCacheDependencyDIR"].Trim();
			if (!Directory.Exists(depDir))
				Directory.CreateDirectory(depDir);
           
			return depDir;
		}
		#endregion

		#region 注册日历
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Field">文本框</param>
		/// <returns>返回一个javascript的代码</returns>

		public static string InvokePopupCal(System.Web.UI.WebControls.TextBox Field )
		{
			//' Define character array to trim from language strings
			char[] TrimChars  = new char[]{',', ' '};

			//' Get culture array of month names and convert to string for
			//' passing to the popup calendar
			string MonthNameString = "";
			// string Month ;
			foreach(string Month in DateTimeFormatInfo.CurrentInfo.MonthNames)
			{
				MonthNameString += Month + ",";
			}

			MonthNameString = MonthNameString.TrimEnd(TrimChars);

			// ' Get culture array of day names and convert to string for
			// ' passing to the popup calendar
			string DayNameString = "";
    
			foreach(string Day in DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames)
			{
				DayNameString += Day + ",";
    
			}

			DayNameString = DayNameString.TrimEnd(TrimChars);

			//' Get the short date pattern for the culture
			string FormatString = DateTimeFormatInfo.CurrentInfo.ShortDatePattern.ToString();
			if(!Field.Page.IsClientScriptBlockRegistered("PopupCalendar"))
			{
				Field.Page.RegisterClientScriptBlock("PopupCalendar",@"<script src=""\common\js\PopupCalendar.js""></script>");
			}


			// return "javascript:popupCal('Cal','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "今天" + "','" + "关闭" + "','" + "日历" + "'," + DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek + ");";
			return "javascript:popupCal('\\\\common\\\\js\\\\','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "今天" + "','" + "关闭" + "','" + "日历" + "');" ;
		}
		#endregion

		#region DES加密解密
		#region 加密方法
		//pToEncrypt为需要加密字符串,sKey为密钥
		public static string Encrypt(string pToEncrypt)
		{
			string sKey ="";
			int[] tmp=new int[8]{23,234,195,165,201,240,143,198};
			foreach(int i in tmp)
			{
				sKey+=((char)i).ToString();
			}
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			//把字符串放到byte数组中
			//原来使用的UTF8编码，我改成Unicode编码了，不行
			byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

			//建立加密对象的密钥和偏移量
			//使得输入密码必须输入英文文本
			des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(),CryptoStreamMode.Write);

			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			StringBuilder ret = new StringBuilder();
			foreach(byte b in ms.ToArray())
			{
				ret.AppendFormat("{0:X2}", b);
			}
			ret.ToString();
			return ret.ToString();
		}
		#endregion
		#region 解密方法
		//pToDecrypt为需要解密字符串,sKey为密钥
		public static string Decrypt(string pToDecrypt)
		{
			string sKey = "";
			int[] tmp=new int[8]{23,234,195,165,201,240,143,198};
			foreach(int i in tmp)
			{
				sKey+=((char)i).ToString();
			}
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
			for(int x = 0; x < pToDecrypt.Length / 2; x++)
			{
				int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
				inputByteArray[x] = (byte)i;
			}

			//建立加密对象的密钥和偏移量，此值重要，不能修改
			des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(),CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			//建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象
			StringBuilder ret = new StringBuilder();
			return System.Text.Encoding.Default.GetString(ms.ToArray());
		}
		#endregion
		#endregion

		#region 按指定长度截断字符串
		public static string  ShortenString(int intLength , string strString)
		{
			if(intLength == 0 )
			{
				return strString;
			}

			strString = strString.Replace( "&nbsp;", "" );
			if (strString.Length > 0 && strString.Length > intLength)
			{
				if(intLength>=25)
				{
					strString = strString.Substring(0,intLength);
				}
				else
				{
					//					string tmpString = strString.Substring(0,intLength);
					//					System.Text.Encoding encoder = System.Text.Encoding.Default; 
					//				
					//					int byteLength = encoder.GetByteCount(tmpString);
					//				while(bytes.Length  < intLength * 2 && tmpString.Length < strString.Length)
					//				{
					//					byteLength ++;
					//					byteLength ++;
					//					tmpString = strString.Substring(0,Convert.ToInt32(byteLength/2));
					//					 
					//					bytes = encoder.GetBytes(tmpString);
					//					
					//				}
					//strString = tmpString;

					string str="";
					if(strString.Length >30)
					{
						str = strString.Substring(0,30);
					}
					else
					{
						str = strString;
					}
					System.Text.Encoding encoder = System.Text.Encoding.Default;
					byte[] bytes=encoder.GetBytes(str);
					if(bytes.Length > intLength * 2)
					{
						str = encoder.GetString(bytes,0,intLength*2);
					}
					//					else
					//					{
					//						str = encoder.GetString(bytes);
					//					}
					strString = str.TrimEnd();
				}
				
			
			}
			//strString = strString.Replace( " ", "&nbsp;" );
			return strString;

		}
		#endregion

		#region 按指定长度截断字符串（内容)
		public static string  ShortenContentString(int intLength , string strString)
		{
			
			if(intLength == 0)
			{
				return strString;
			}
			int maxLength = 200;

			if(strString.Length < maxLength)
			{
				maxLength = strString.Length;
			}
			string tmpString = "";
			if (strString.Length > 0)
			{
				tmpString = strString.Substring(0,maxLength);
				tmpString = System.Text.RegularExpressions.Regex.Replace(tmpString,@"</?strong>|<p[^>]*>|</p>|<br>|<br/>","",System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				tmpString = System.Text.RegularExpressions.Regex.Replace(tmpString,"&lt;", "<",System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				tmpString = System.Text.RegularExpressions.Regex.Replace(tmpString,"&gt;",">",System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				tmpString = System.Text.RegularExpressions.Regex.Replace(tmpString,"&nbsp;"," ",System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				tmpString = System.Text.RegularExpressions.Regex.Replace(tmpString," +"," ",System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				//tmpString = tmpString.TrimEnd();
				
				
				if  (tmpString.Length > intLength)
				{
					System.Text.Encoding encoder = System.Text.Encoding.Default;
					byte[] bytes=encoder.GetBytes(tmpString);
					if(bytes.Length > intLength * 2)
					{
						tmpString = encoder.GetString(bytes,0,intLength*2);
					}

					//tmpString = tmpString.Substring(0,intLength);
				}
				//tmpString = TxtToHtml(tmpString);
			}
			return tmpString;

		}
		#endregion

		#region 获取tz888和tzWeb共享文件夹
		public static string GetShareDir()
		{
            string shareFolder = ConfigurationManager.AppSettings["ShareFolder"].Trim();
			if (!Directory.Exists(shareFolder))
			{
				Directory.CreateDirectory(shareFolder);
			}
			if(!shareFolder.EndsWith("\\"))
			{
				shareFolder += "\\";
			}
			return shareFolder;
		}
		#endregion

		#region 将ENUM转化为DATATABLE，以便绑定
		public static ICollection ConvertEnumToDataTable(Type aEnumType) 
		{
			if(aEnumType.BaseType != typeof(Enum))
			{
				throw new ArgumentException("此类型不是enum类型!");
			}
			DataTable dt = new DataTable();
			DataRow dr;
 
			dt.Columns.Add(new DataColumn("Name", typeof(string)));
			dt.Columns.Add(new DataColumn("Value", typeof(int)));

			//Invest.PageStaticRule.PageStatic.LogLevel log=new Invest.PageStaticRule.PageStatic.LogLevel();
			Array names = Enum.GetNames(aEnumType);
			Array values = Enum.GetValues(aEnumType);
 
			for (int i = 0; i < names.Length; i++) 
			{
				dr = dt.NewRow();
				string name = (string) names.GetValue(i);
				dr["Name"] = name;
				//string a = (string)values.GetValue(i);
				dr["Value"] = values.GetValue(i);

				dt.Rows.Add(dr);
			}
 
			DataView dv = new DataView(dt);
			return dv;
		}

		#endregion

		#region 获取发送邮件帐户
		public static string GetSenderEmail()
		{
            string SenderEmail = (string)ConfigurationManager.AppSettings["ASSenderEmail"];
			return SenderEmail;
		}
		public static string GetSenderEmailFolder()
		{
            string SenderEmailFolder = (string)ConfigurationManager.AppSettings["SenderEmailFolder"];
			return SenderEmailFolder;
		}
		#endregion

		#region 获取发送邮件帐户的密码
		public static string GetEmailPassword()
		{
            string EmailPassword = (string)ConfigurationManager.AppSettings["ASEmailPassword"];
			return EmailPassword;
		}
		#endregion

		#region 获取前台域名
		public static string GetDomain()
		{
            string Domain = (string)ConfigurationManager.AppSettings["Domain"];
			return Domain;
		}
		#endregion


		/// <summary>
		/// 通过等级类别编码,获取用户等级类别的前台展示字符串，可放到公共业务层，kevin 06-12-30
		/// </summary>
		/// <param name="gradeId">等级编码</param>
		/// <returns>展示字符串</returns>
		public static string  GetGradeTypeDisplay(string gradeType)
		{
			string rvalStr = "<span style='color:#666666;'>会员类别：</span>";
			switch( gradeType)
			{
//				case "0":	
//					rvalStr  += "putong.gif' alt='普通会员' >";
//					break;
//				case "1":	
//					rvalStr  += "tongpai.gif' alt='铜牌会员' >";
//					break;
//				case "2":	
//					rvalStr  += "yingpai.gif' alt='银牌会员' >";
//					break;
//				case "3":	
//					rvalStr  += "jingpai.gif' alt='金牌会员' >";
//					break;
//				case "4":	
//					rvalStr  += "zuanshi.gif' alt='钻石会员' >";
//					break;
//				default:
//					rvalStr += "putong.gif' alt='普通会员' > ";
//					break;

				case "1001":
					rvalStr  += "<a href='/Service/Free.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/putong.gif' alt='会员类别：普通会员' >";
					break;
				case "1002":
					rvalStr  += "<a href='/Service/VIPproject.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/vipproject.gif' alt='会员类别：VIP融资会员' >";
					break;
				case "1003":
					rvalStr  += "<a href='/Service/VIPmerchant.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/vipmerchant.gif' alt='会员类别：VIP招商会员 ' >";
					break;
				default:
					rvalStr  += "<a href='/Service/Free.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/putong.gif' alt='会员类别：普通会员' >";
					break;

			}
			return rvalStr+="</a>";
		}

		/// <summary>
		/// 通过等级编码,获取用户等级的前台展示字符串，可放到公共业务层，kevin 06-12-30
		/// </summary>
		/// <param name="gradeId">等级编码</param>
		/// <returns>展示字符串</returns>
		public static string  GetGradeDisplay(string gradeId)
		{
			string rvalStr ="<a href='/Rookie/MemberGrades.aspx' target='_blank'>";
			switch(gradeId)
			{
				case "0":	
					rvalStr  += "★";
					break;
				case "1":	
					rvalStr  += "★★";
					break;
				case "2":	
					rvalStr  += "★★★";
					break;
				case "3":	
					rvalStr  += "★★★★";
					break;
				case "4":	
					rvalStr  += "★★★★★";
					break;
				default:
					rvalStr += "★";
					break;
			}
			return rvalStr += "</a>";
		}

		/// <summary>
		/// 获取用户展示字符串
		/// </summary>
		/// <param name="RoleName">角色代码</param>
		/// <param name="loginName">登陆名</param>
		/// <param name="nickname">昵称</param>
		/// <returns>用户展示字符串</returns>
		public static string GetUserDisplay(string loginName)
		{
			 
			 
			return "";
		}

		/// <summary>
		/// 用户评价指数显示
		/// </summary>
		/// <param name="evaluationValue">用户评价指数</param>
		/// <returns>显示字符串</returns>
		public static string GetUserEvaluationDisplay(int evaluationValue)
		{
			string str = evaluationValue.ToString();
			if(evaluationValue<=-50)
			{
				str +=" [黑榜]";
			}
			else if(evaluationValue>=50)
			{
				str +=" <font color='red'>[红榜]</font>";
			}
			return str;
		}
		/// <summary>
		/// 统一控制浮点小数位,2007-06-17
		/// </summary>
		/// <param name="f">浮点数</param>
		/// <param name="digit">小数位数</param>
		/// <returns>转换后的字符串</returns>
		public static string GetFloatToString(float f,int digit)
		{
			return f.ToString("f0");
		}
    }
}
