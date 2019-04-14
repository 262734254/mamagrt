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
        private static System.Text.Encoding m_CurrentEncoding;//����
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

		#region ת���ַ��еķ����
		/// <summary>
		/// ��������ı��ַ���ת����HTML���룬ת�������ַ�
		/// "\n\b" -> "<br>"
		/// 
		/// </summary>
		/// <param name="strTxt">�����ı�����ַ���</param>
		/// <returns>����HTML��ʶ���ַ���</returns>
		public static string TxtConvert(string strTxt)
		{
			string strTmp = strTxt;
			strTmp = strTmp.Replace("\\","/");
			return strTmp;
		}
		#endregion

		#region ��������ı��ַ���ת����HTML����
		/// <summary>
		/// ��������ı��ַ���ת����HTML���룬ת�������ַ�
		/// "\n\b" -> "<br>"
		/// 
		/// </summary>
		/// <param name="strTxt">�����ı�����ַ���</param>
		/// <returns>����HTML��ʶ���ַ���</returns>
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

		#region �������HTMLת��Ϊ���Ա��ı���ʶ��ĸ�ʽ
		/// <summary>
		/// �������HTMLת��Ϊ���Ա��ı���ʶ��ĸ�ʽ
		/// </summary>
		/// <param name="strHtml">����HTML���ַ���</param>
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
		
		#region �����ϴ��ļ����ļ���
		/// <summary>
		/// �����ϴ��ļ����ļ���
		/// �ļ�������
		/// ������ʱ����+��λ������۹�����λ��
		/// </summary>
		/// <param name="InfoTypeID">��Ϣ������</param>
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

		#region ��ָ��Ŀ¼�������ļ�ȫ��COPY��һ��Ŀ¼�� --------------------------------- [������ʹ��]
		/// <summary>
		/// ��ָ��Ŀ¼�������ļ�ȫ��COPY��һ��Ŀ¼��
		/// </summary>
		/// <param name="localPath">Ҫcopy��Ŀ¼��,�����̸�Ŀ¼���µ�·��</param>
		/// <param name="DestPath">Ŀ���ļ���</param>
		/// <returns></returns>
		public static int CopyAll(string localPath, string DestPath, ref string DestFullPath)
		{
            string localFullPath = (string)ConfigurationManager.AppSettings["AgentWebRootPath"];
			localFullPath += localPath;
			if (!Directory.Exists(localFullPath))
				return 0;

            DestFullPath = (string)ConfigurationManager.AppSettings["AgentWebRootPath"];
			DestFullPath += DestPath;
			if (!Directory.Exists(DestFullPath))//��������
				Directory.CreateDirectory(DestFullPath);
			
			// Create a reference to the current directory.
			DirectoryInfo di = new DirectoryInfo(localFullPath);
			// Create an array representing the files in the current directory.
			FileInfo[] fi = di.GetFiles();			
			// ��ʼCOPY�ļ�
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

		#region ��ȡĳ��Ϣ���͵�ͼƬ�ϴ�·��
		/// <summary>
		/// ��ȡĳ��Ϣ���͵�ͼƬ�ϴ�·��
		/// </summary>
		/// <param name="InfoType">��Ϣ����[��news]</param>
		/// <param name="IsFullPath">�Ƿ���ȫ·��</param>
		/// <returns>����d:\upload\News\200508\dd.gif</returns>
		public static string GetUploadPath(string InfoType, bool IsFullPath)
		{
			string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
			ServerPath = "InfoImage\\" + InfoType;
			DateTime timeC = DateTime.Now;			
			ServerPath += "\\" + timeC.Year.ToString() + timeC.Month.ToString() + "\\";
			//���ݵ�ǰ�´����ļ���
			if (!Directory.Exists(ServerRootPath + ServerPath))
				Directory.CreateDirectory(ServerRootPath + ServerPath);
			#region �������Ŀ¼�Ƿ����
			#endregion
			if (IsFullPath)
				return ServerRootPath + ServerPath;
			else
				return ServerPath;
		}
		#endregion

		#region ��ȡĳ��Ϣ���͵�ͼƬ�ϴ���Ŀ¼·��
		public static string GetUploadRootPath()
		{
            string ServerPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
			return ServerPath;
		}
		#endregion

		#region ��ȡĳ��Ϣ���͵�ͼƬ��ʱ�ļ�·��
		/// <summary>
		/// ��ȡĳ��Ϣ���͵�ͼƬ��ʱ�ļ�·��
		/// </summary>
		/// <param name="IsFullPath">�Ƿ���ȫ·��</param>
		/// <returns>��ʱĿ¼</returns>
		public static string GetTmpUploadPath(bool IsFullPath)
		{
			string ServerPath;
            string ServerRootPath = (string)ConfigurationManager.AppSettings["ImageServerPath"];
			ServerPath = "InfoImage\\TmpFile\\";			
			//���ݵ�ǰ�´����ļ���
			if (!Directory.Exists(ServerRootPath + ServerPath))
				Directory.CreateDirectory(ServerRootPath + ServerPath);
			#region �������Ŀ¼�Ƿ����
			#endregion
			if (IsFullPath)
				return ServerRootPath + ServerPath;
			else
				return ServerPath;
		}
		#endregion

		#region ��ȡͼƬ������
		public static string GetImageDomain()
		{
            string ImageDomain = (string)ConfigurationManager.AppSettings["ImageDomain"];
			return ImageDomain;
		}
		#endregion

		#region ��ȡ�������г����λ�ã�����ȡģ�棩
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

		#region ��ȡǰ̨���г����λ�ã�����дģ��ȣ�
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

		#region  ��ѯ��������

		public static void AddTwoCriteria(
			ref System.Text.StringBuilder Criteria,
			string SecondCriteria,
			bool IsAnd)
		{
			string strJoin = "";
			if(IsAnd)
			{//AND ����
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
					Criteria.Insert(0,"(");//����������
					Criteria.Append(")");//����������
				}
			}
		}

		#endregion

		#region  ��ʾ��Ϣ����
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

		//ֻ���ڲ�Ա��ϵͳʹ��
		public static bool SessionKeep(
			System.Web.UI.Page page,
			string Url)
		{
			//SESSION��ʧ
			if(page.Session.Count==0 ||
				page.Session["LoginName"] ==null ||
				page.Session["WorkType"] ==null)
			{
				page.Response.Write("<script>alert('������ʱ�������µ�½��');location.href='" + Url + "';</script>");
				return false ;
			}
			else
			{
				return true;
			}
		}
		#endregion

		#region �ػ񶨳����ַ���
		/// <summary>
		/// �ػ񶨳����ַ���
		/// </summary>
		/// <param name="source">Դ�ַ���</param>
		/// <param name="length">��Ҫ�ػ�ĳ���</param>
		/// <param name="postfix">����ַ������ض̣���Ҫ���ʲô���ĺ�׺</param>
		/// <returns>�ػ����ַ���</returns>
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

		#region ��������ָ�� ----------------------------------------------------
		public static long  GetHotIndex( long hit, long ReplyTimes)
		{			
			return (hit / 10 + ReplyTimes / 2);
		}
		#endregion

		#region ����Ͷ�ʡ�����ָ��[��ֵָ��] ----------------------------------------------------
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
				strStar += "��";
			}
			return (strStar);
		}
		#endregion

		#region �������������·���ж��ļ����Ƿ���ڣ�����������򴴽�
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
				//û���ҵ�ָ����·��,��Ҫ����滻
				string tmpTestPath;
				string[] PathArr;				
				PathArr = tmpPath.Split(new char[]{'\\'});
				if (PathArr.Length < 2) //������Ч������·��(�粻�� c:\)
					return false;
				
				tmpTestPath = PathArr[0] + "\\" + PathArr[1];

				if (!Directory.Exists(tmpTestPath)) 
					return false; // û����Ҫ���̷� F:\

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

		#region ����ĳͼƬ������ͼ��ַ ----------------------------------------------------
		public static string GetMiniPic( string Pic)
		{			
			//��������_S��ʶ 
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

		#region ɾ��ָ���ļ��Ĳ��� --------------------------------------------------
		/// <summary>
		/// ɾ��ָ���ļ��Ĳ���
		/// </summary>
		/// <param name="htmlFilePath">��������Ŀ¼����վĿ¼��ַ</param>
		/// <returns></returns>
		public static bool DeleteWebFile(string htmlFilePath, ref string deleteMsg)
		{
			if (htmlFilePath == "")
			{
				deleteMsg = "�ļ���ַ�����޷�ɾ���ļ���";
				return false;
			}
            string ApplicationRoot = ConfigurationManager.AppSettings["ApplicationRootPath"].ToString();
			if (ApplicationRoot == "")
			{
				deleteMsg = "ϵͳ���ô����������Ա��ϵ��";
				return false;
			}
			string TmpFilePath = ApplicationRoot + htmlFilePath;
			if (File.Exists(TmpFilePath))
			{
				File.Delete(TmpFilePath);
				deleteMsg = "�Ѿ�ɾ��ָ�����ļ� -- " + htmlFilePath;
				return true;
			}
			else
			{
				deleteMsg = "ϵͳ���ô����������Ա��ϵ��";
				return false;
			}

		}
		#endregion 

		#region �����ļ� --------------------------
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

		#region���жϸ������ַ����Ƿ�������

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

		#region ��ȡ�����������ļ����ڵ��ļ���
		public static string GetADDepDir()
		{
            string depDir = ConfigurationManager.AppSettings["ADCacheDependencyDIR"].Trim();
			if (!Directory.Exists(depDir))
				Directory.CreateDirectory(depDir);
           
			return depDir;
		}
		#endregion

		#region ע������
		/// <summary>
		/// 
		/// </summary>
		/// <param name="Field">�ı���</param>
		/// <returns>����һ��javascript�Ĵ���</returns>

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


			// return "javascript:popupCal('Cal','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "����" + "','" + "�ر�" + "','" + "����" + "'," + DateTimeFormatInfo.CurrentInfo.FirstDayOfWeek + ");";
			return "javascript:popupCal('\\\\common\\\\js\\\\','" + Field.ClientID + "','" + FormatString + "','" + MonthNameString + "','" + DayNameString + "','" + "����" + "','" + "�ر�" + "','" + "����" + "');" ;
		}
		#endregion

		#region DES���ܽ���
		#region ���ܷ���
		//pToEncryptΪ��Ҫ�����ַ���,sKeyΪ��Կ
		public static string Encrypt(string pToEncrypt)
		{
			string sKey ="";
			int[] tmp=new int[8]{23,234,195,165,201,240,143,198};
			foreach(int i in tmp)
			{
				sKey+=((char)i).ToString();
			}
			DESCryptoServiceProvider des = new DESCryptoServiceProvider();
			//���ַ����ŵ�byte������
			//ԭ��ʹ�õ�UTF8���룬�Ҹĳ�Unicode�����ˣ�����
			byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

			//�������ܶ������Կ��ƫ����
			//ʹ�����������������Ӣ���ı�
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
		#region ���ܷ���
		//pToDecryptΪ��Ҫ�����ַ���,sKeyΪ��Կ
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

			//�������ܶ������Կ��ƫ��������ֵ��Ҫ�������޸�
			des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
			des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
			MemoryStream ms = new MemoryStream();
			CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(),CryptoStreamMode.Write);
			cs.Write(inputByteArray, 0, inputByteArray.Length);
			cs.FlushFinalBlock();
			//����StringBuild����CreateDecryptʹ�õ��������󣬱���ѽ��ܺ���ı����������
			StringBuilder ret = new StringBuilder();
			return System.Text.Encoding.Default.GetString(ms.ToArray());
		}
		#endregion
		#endregion

		#region ��ָ�����Ƚض��ַ���
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

		#region ��ָ�����Ƚض��ַ���������)
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

		#region ��ȡtz888��tzWeb�����ļ���
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

		#region ��ENUMת��ΪDATATABLE���Ա��
		public static ICollection ConvertEnumToDataTable(Type aEnumType) 
		{
			if(aEnumType.BaseType != typeof(Enum))
			{
				throw new ArgumentException("�����Ͳ���enum����!");
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

		#region ��ȡ�����ʼ��ʻ�
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

		#region ��ȡ�����ʼ��ʻ�������
		public static string GetEmailPassword()
		{
            string EmailPassword = (string)ConfigurationManager.AppSettings["ASEmailPassword"];
			return EmailPassword;
		}
		#endregion

		#region ��ȡǰ̨����
		public static string GetDomain()
		{
            string Domain = (string)ConfigurationManager.AppSettings["Domain"];
			return Domain;
		}
		#endregion


		/// <summary>
		/// ͨ���ȼ�������,��ȡ�û��ȼ�����ǰ̨չʾ�ַ������ɷŵ�����ҵ��㣬kevin 06-12-30
		/// </summary>
		/// <param name="gradeId">�ȼ�����</param>
		/// <returns>չʾ�ַ���</returns>
		public static string  GetGradeTypeDisplay(string gradeType)
		{
			string rvalStr = "<span style='color:#666666;'>��Ա���</span>";
			switch( gradeType)
			{
//				case "0":	
//					rvalStr  += "putong.gif' alt='��ͨ��Ա' >";
//					break;
//				case "1":	
//					rvalStr  += "tongpai.gif' alt='ͭ�ƻ�Ա' >";
//					break;
//				case "2":	
//					rvalStr  += "yingpai.gif' alt='���ƻ�Ա' >";
//					break;
//				case "3":	
//					rvalStr  += "jingpai.gif' alt='���ƻ�Ա' >";
//					break;
//				case "4":	
//					rvalStr  += "zuanshi.gif' alt='��ʯ��Ա' >";
//					break;
//				default:
//					rvalStr += "putong.gif' alt='��ͨ��Ա' > ";
//					break;

				case "1001":
					rvalStr  += "<a href='/Service/Free.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/putong.gif' alt='��Ա�����ͨ��Ա' >";
					break;
				case "1002":
					rvalStr  += "<a href='/Service/VIPproject.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/vipproject.gif' alt='��Ա���VIP���ʻ�Ա' >";
					break;
				case "1003":
					rvalStr  += "<a href='/Service/VIPmerchant.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/vipmerchant.gif' alt='��Ա���VIP���̻�Ա ' >";
					break;
				default:
					rvalStr  += "<a href='/Service/Free.shtml' target='_blank'><img  align='absmiddle' border='0' src='/images/CapitalImg/putong.gif' alt='��Ա�����ͨ��Ա' >";
					break;

			}
			return rvalStr+="</a>";
		}

		/// <summary>
		/// ͨ���ȼ�����,��ȡ�û��ȼ���ǰ̨չʾ�ַ������ɷŵ�����ҵ��㣬kevin 06-12-30
		/// </summary>
		/// <param name="gradeId">�ȼ�����</param>
		/// <returns>չʾ�ַ���</returns>
		public static string  GetGradeDisplay(string gradeId)
		{
			string rvalStr ="<a href='/Rookie/MemberGrades.aspx' target='_blank'>";
			switch(gradeId)
			{
				case "0":	
					rvalStr  += "��";
					break;
				case "1":	
					rvalStr  += "���";
					break;
				case "2":	
					rvalStr  += "����";
					break;
				case "3":	
					rvalStr  += "�����";
					break;
				case "4":	
					rvalStr  += "������";
					break;
				default:
					rvalStr += "��";
					break;
			}
			return rvalStr += "</a>";
		}

		/// <summary>
		/// ��ȡ�û�չʾ�ַ���
		/// </summary>
		/// <param name="RoleName">��ɫ����</param>
		/// <param name="loginName">��½��</param>
		/// <param name="nickname">�ǳ�</param>
		/// <returns>�û�չʾ�ַ���</returns>
		public static string GetUserDisplay(string loginName)
		{
			 
			 
			return "";
		}

		/// <summary>
		/// �û�����ָ����ʾ
		/// </summary>
		/// <param name="evaluationValue">�û�����ָ��</param>
		/// <returns>��ʾ�ַ���</returns>
		public static string GetUserEvaluationDisplay(int evaluationValue)
		{
			string str = evaluationValue.ToString();
			if(evaluationValue<=-50)
			{
				str +=" [�ڰ�]";
			}
			else if(evaluationValue>=50)
			{
				str +=" <font color='red'>[���]</font>";
			}
			return str;
		}
		/// <summary>
		/// ͳһ���Ƹ���С��λ,2007-06-17
		/// </summary>
		/// <param name="f">������</param>
		/// <param name="digit">С��λ��</param>
		/// <returns>ת������ַ���</returns>
		public static string GetFloatToString(float f,int digit)
		{
			return f.ToString("f0");
		}
    }
}
