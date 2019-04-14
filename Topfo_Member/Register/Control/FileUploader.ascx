<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUploader.ascx.cs" Inherits="Register_Control_FileUploader" %>
<div id="UploadFiles" runat="server">
	<div id="divInitFile" runat="server"></div>
</div>
<INPUT id="hfMaxFile" type="hidden" size="1" value="100" name="hfMaxFile" runat="server"/>
<INPUT id="initFileList" type="hidden" size="1" name="initFileList" runat="server"/>
<INPUT id="deletedFileList" type="hidden" size="1" name="deletedFileList" runat="server"/>
<img src="<%=Img%>"  id="<%= this.ClientID %>_imgLoad"  />
<input style="BORDER-RIGHT: 1px solid; BORDER-TOP: 1px solid; BORDER-LEFT: 1px solid; BORDER-BOTTOM: 1px solid"  id ="<%= this.ClientID %>_ButAdd" onclick="<%= this.ClientID %>_uploader.addFile();" type="button" value="<%= ButtonName%>"/>
<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传" /><div id="<%= this.ClientID %>msg" style="COLOR: red"></div>
<script language="JavaScript" type="text/javascript">

	function UploaderFile(msgID,fileType,maxFileSize,checkerIndex,fileInputCount,maxPics,deletedFileListID,uploadFilesID,prefix,name,buttonName,img,isUp)
	{
		this.MsgID = msgID;//显示消息的ID
		this.FileType = fileType;//允许的文件类型
		this.MaxFileSize = maxFileSize;//字节为单位 //parseInt(document.getElementById("<%= hfMaxFile.ClientID %>").value)
		this.CheckerIndex = checkerIndex;//File计数器
		this.FileInputCount=fileInputCount;//已有的File Input数
		this.MaxPics = maxPics;//可上传的最大图片数
		this.DeletedFileListID = deletedFileListID;//删除文件列表的隐藏域ID
		this.UploadFilesID = uploadFilesID;//File的容器
		this.Prefix = prefix;//生成DOM元素ID的前缀
		this.Name = name;//对象变量名		this.ButtonName = buttonName;
		this.Img = img; //加载图片或默认图片		this.IsUp= isUp;
		
		//图片的高，长
		var img =  new Image();   
        img.src = this.Img;   
        var w=<%=ImgWidth%> ;      
        if(img.width>w)
        { 
            var imgload=document.getElementById("<%= this.ClientID %>_imgLoad");
            imgload.src=this.Img;       
            imgload.width=<%=ImgWidth%>;
            imgload.height=<%=ImgHeight%>;
        }
        
		if(this.ButtonName=="")//当按扭的值为空时不会显示此按扭，只加载图片		{
		    document.getElementById("<%= this.ClientID %>_ButAdd").style.display="none";
		}		
		 document.getElementById("<%= this.ClientID %>_Button1").style.display="none";
	}
	
	UploaderFile.prototype.checkFile =  function(fileInput,strFileChecker)
	{
		var fileName = fileInput.value;
		var fileCheckerEL = document.getElementById(strFileChecker);		
		//图片的高，长
		var img =  new Image();   
        img.src = fileName;       
//        if(img.height><%=ImgHeight%> || img.width><%=ImgWidth%>)
//        { 
//            alert("图片过大（220*160PX）,请重新上传！");
//            fileInput.CanUp = false;
//			return false;
			
//            var imgload=document.getElementById("<%= this.ClientID %>_imgLoad");
//            imgload.src="";
//            imgload.Width=<%=ImgWidth%>;
//            imgload.Height=<%=ImgHeight%>;
//        }
        
		fileCheckerEL.src = fileName;
		fileCheckerEL.alt = fileName;
		fileCheckerEL.style.visibility = "visible";
		
		if(this.existFile(fileInput))
		{
			document.getElementById(this.MsgID).innerHTML = "你已经选择了该文件。";
			fileInput.CanUp = false;
			return false;
		}	
		var loc = fileName.lastIndexOf(".");
		if(loc > 0)
		{
			var extstr = fileName.substring(loc).toLowerCase();
			if((this.FileType).indexOf(extstr)>= 0 ) //(extstr == "jpg" || extstr == "png" || extstr == "gif")
			{
				//检验文件大小
				var fileSize = 10;
				try
				{
					setTimeout(fileSize = fileCheckerEL.fileSize,1000);
				}
				catch (e)
				{
					fileSize = 10;
				}
			
				if( fileSize >= this.MaxFileSize)
				{
					document.getElementById(this.MsgID).innerHTML = "文件大小超过" + maxFileSize +"K。";
					fileInput.CanUp = false;
					return false;
				}
				document.getElementById(this.MsgID).innerHTML = "";
				fileInput.CanUp = true;
				return true;
			}
		}
		//document.getElementById(this.MsgID).innerHTML = fileName + "文件类型不是" +this.FileType + "类型。";
		alert( fileName + "文件类型不是" +this.FileType + "类型//");
		fileCheckerEL.style.visibility = "hidden";
		fileInput.CanUp = false;
		return false;		
	}

	UploaderFile.prototype.addFile=function() 
	{	   
		if(this.FileInputCount < this.MaxPics )
		{
			var strTmp = '<div id="divFile"><img id=checkImg height="100" style="visibility:hidden"  /><br/><INPUT type="file" size="50" name="fileNo" id="fileNo"  onchange="checkFile(this,checkImg);" onblur="if(this.CanUp != null && !this.CanUp) this.focus();" style="border:solid; border-width:1px;width:100%" /></div>' ;
			//<input type="button" onclick="removeFile(\'divFile\')" value="取消" style="border:solid; border-width:1px" /> 暂去掉取消功能
			var str = strTmp.replace(/checkImg/g , "'" + this.Prefix + "FC" + this.CheckerIndex + "'");
			str = str.replace(/divFile/g,this.Prefix +"DF" + this.CheckerIndex);
			str = str.replace(/fileNo/g,this.Prefix +"FN" + this.CheckerIndex);
			str = str.replace(/checkFile/g,this.Name + ".checkFile");
			str = str.replace(/removeFile/g,this.Name + ".removeFile");
			
			document.getElementById(this.UploadFilesID).insertAdjacentHTML("beforeEnd",str)
			
			this.CheckerIndex ++;
			this.FileInputCount ++;
			if(this.FileInputCount=this.MaxPics) 	
			{
			    document.getElementById("<%= this.ClientID %>_ButAdd").style.display="none";
			    document.getElementById("<%= this.ClientID %>_imgLoad").style.display="none";	
			}
			if(this.IsUp=="1")
			{
			    document.getElementById("<%= this.ClientID %>_Button1").style.display="";
			}
			else
			{
			     document.getElementById("<%= this.ClientID %>Button1").style.display="none";
			}
		}
		else
		{	
			alert("已经到达可上传的最大的图片数.");
		}
	}
	
	UploaderFile.prototype.existFile =function(fileInput)
	{
		for(i=0;i<this.CheckerIndex ;i++)
		{
			var el = document.getElementById(this.Prefix + "FN" + i);
			if(el && el != fileInput && el.value == fileInput.value)
			{
				return true;
			}
		}
		return false;
	}
	
	UploaderFile.prototype.removeFile=function(fileEL,fileName)
	{
		document.getElementById("<%= this.ClientID %>_ButAdd").style.display="block";
		if(fileName)
		{
			if(confirm( "您真的要删除" + fileName + "文件吗?"))
			{
				var el = document.getElementById(this.DeletedFileListID);
				if(el.value == "")
				{
					el.value =  fileName;
				}
				else
				{
					el.value += "|" + fileName;
				}
				document.getElementById(fileEL).outerHTML = "";
				this.FileInputCount--;
			}
		}
		else
		{
			if(confirm( "您真的要取消上传吗?"))
			{
				//document.getElementById(fileEL).outerHTML = "";
				var el = document.getElementById(fileEL);
				el.parentElement.removeChild(el);
				this.FileInputCount--;								
			    <%= this.ClientID %>_imgLoad.src=this.Img;	
			}
			  document.getElementById("<%= this.ClientID %>_ButAdd").style.display="none";
		}
	}
var	<%= this.ClientID %>_uploader = new UploaderFile("<%= this.ClientID %>msg","<%= FileType%>",parseInt(document.getElementById("<%= hfMaxFile.ClientID %>").value)*1024,<%= UploadedCount %>,<%= UploadedCount %>,<%= MaxPics%>,"<%= deletedFileList.ClientID %>","<%= UploadFiles.ClientID %>","<%= this.ClientID %>","<%= this.ClientID %>_uploader","<%= ButtonName%>","<%= Img%>","<%=IsUp%>");
	
</script>