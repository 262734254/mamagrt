<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Title="资讯发布" CodeFile="PublishVideo.aspx.cs" Inherits="PublishVideo" %>

<%@ Register Src="../Controls/TPZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<%@ Register TagPrefix="radU" Namespace="Telerik.WebControls" Assembly="RadUpload.Net2" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
<script language="javascript" type="text/javascript"> 
    function checkedTypeOK()
    {  
        var temp=document.getElementsByName("ctl00$ContentPlaceHolder1$radioType"); 
        var objhidradioType=document.getElementById("ctl00_ContentPlaceHolder1_hidradioType");
        for (i=0;i<temp.length;i++)
        {  
           if(temp[i].checked)      
	        {  
	           objhidradioType.value=temp[i].value;  //选择视频类别       
   	        }  	
        }
        
    } 
   function cancel()
   {
        document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtContent").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtKeyWord").value="";
   }
    
 	function chkInput()
	{  
        var i;var j;
        var lenTitle = 0;
        var lenContent=0;
        var objTitle=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value;
        var objContent=document.getElementById("ctl00_ContentPlaceHolder1_txtContent").value;
        for (i=0;i<objTitle.length;i++)
        { 
            if (objTitle.charCodeAt(i)>255) lenTitle+=2; else lenTitle++;
        }
        for (j=0;j<objContent.length;j++)
        {
            if (objContent.charCodeAt(i)>255) lenContent+=2; else lenContent++;
        }
        if(lenTitle==0||lenTitle>50) 
        {
                alert('标题不为空且不超过25个汉字!');
                document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").focus();
			    return false; 
        } 
        if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
        {
                alert('请选择所属地区!'); 
			    return false; 
        }
        if(lenContent>1000) 
        {
                alert('图片说明不超过500个汉字!');
                document.getElementById("ctl00_ContentPlaceHolder1_txtContent").focus();
			    return false; 
        } 
        
        if(document.getElementById("ctl00_ContentPlaceHolder1_FileUploader").value=="")
	    {
	        alert("请选择上传的文件");
	        return false;
	    }
	    var ext = "";
	    try {
		    ext = document.getElementById("ctl00_ContentPlaceHolder1_FileUploader").value.substring(document.getElementById("ctl00_ContentPlaceHolder1_FileUploader").value.lastIndexOf("."));
	    } catch(e) {
		    alert("上传视频只支持wmv、rm格式");
		    return false;
	    }
	    if(".wmv.rm".indexOf(ext) == -1) {
		    alert("上传视频只支持wmv、rm格式");
		    return false;
	    } else {
		    return true;
	    }
     }
</script> 
<input type="hidden" id="hidradioType" name="hidradioType" value="转载" runat="server" /> 
<!--融资发布 -->
<div class="mainconbox"  id="mainconbox">
<div class="titled">
<div class="left"> 视频上传 </div>
<div class="clear"></div>
</div>
<div class="suggestbox lightc allxian"><h1><strong>上传帮助</strong></h1>
  <p>1. 大小：所上传的视频文件大小不能超过20M。 <br />
    2. 时长：时长无限制。但5分钟以内的视频，可以达到最流畅的上传及观赏效果。 </p>
  3.  支持格式：支持wmv、rm的视频格式。</div>
<DIV class="blank0"></DIV>
<div>前面标有“<span class="hong">*</span>”的为必填选项</div>
<table border="1" cellpadding="0" cellspacing="0" class="tabbiank">
<tr>
    <td  align="right" bgcolor="#F7F7F7"><span class="hong">*</span> <strong>所属区域：</strong></td>
    <td width="606"><uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server"></uc1:ZoneSelectControl> </td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7"><span class="hong">*</span> <strong>标题：</strong></td>
    <td width="606" valign="top">
     
      <input name="txtTitle" type="text" id="txtTitle" value="" size="45" runat="server" />
      <p class="hui">标题长度不超过25个汉字，两个字母或数字为一个汉字</P></td>
  </tr>
  <tr>
    <td width="148" align="right" bgcolor="#F7F7F7"><span class="hong">* </span><strong>版权所有：</strong></td>
    <td width="606"><label>
      <input name="radioType" type="radio" value="转载" checked="checked" onclick="checkedTypeOK()"/>
      </label> 
      转载 
      <input type="radio" name="radioType" value="原创"  onclick="checkedTypeOK()" />
      原创<label>
      <input name="txtAuthor" id="txtAuthor" type="text" value="请填写该视频的版权所有者" onclick="this.value='';" runat="server" size="26" />
      </label></td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7"><span class="hong">*</span> <strong>上传视频：</strong></td>
<td>	  &nbsp;<radu:radprogressmanager id="Radprogressmanagerer" runat="server" width="100%"></radu:radprogressmanager>
	      <radu:radprogressarea id="progressAreaer" runat="server" width="100%"></radu:radprogressarea>
<asp:FileUpload ID="FileUploader" runat="server" /></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7"><strong>视频简介：</strong></td>
    <td valign="top"><textarea name="txtContent" cols="80" rows="12" id="txtContent" runat="server"></textarea>
      <br />
      <span class="hui">视频简介不超过500个汉字</span></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7"><strong>标签：</strong></td>
    <td valign="top"><input name="txtKeyWord" type="text" id="txtKeyWord" value="" size="45"  runat="server"/>
      <br />
      <span class="hui">每个标签最少要有两个汉字，标签间使用空格进行分隔。每个视频最多可以有五个标签。<a href="http://www.topfo.com/help/Tags.shtml" target="_blank"> 什么是标签？</a></span></td>
  </tr>
</table>
<!--联系方式 --><!--申请域名 建立我的展厅 -->
<div class="blank0"></div>
<div class="pad_1" align="center">
  <label>
  <input name="chkYes" id="chkYes" type="checkbox" value="checkbox" checked="checked" runat="server" />
   </label>
   我的视频符合Topfo的上传条款： <br />
    <p style="text-align:left; padding: 5px 0 15px 280px;" class="hui"> * 不含有反动政治、黄色、严重暴力的内容。 <br />
    * 不侵犯其他任何人的合法权益。<br />
    * 不含有涉及版权问题的视频片断。 </p>  
  <asp:Button ID="BtnAddVideo"   runat="server" Text="上传视频" CssClass="buttomal" OnClick="BtnAddVideo_Click"/>
  <input type="button" value="清 空" onclick="cancel();"  class ="buttomal"/>
</div>
</div>
</asp:Content>
