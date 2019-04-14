<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" Title="更新资讯" CodeFile="UpdateNews.aspx.cs" Inherits="UpdateNews" %>

<%@ Register Src="../Controls/TPZoneSelectControl.ascx" TagName="ZoneSelectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server"> 
<style type="text/css">
        body{text-align:center;}
        .content{width:466px;height:300px;background:url(images/search_bg_03.jpg) no-repeat left top;margin:300px auto 0;text-align:center;padding-top:500px;}
        .content p{line-height:30px;        }
        </style>
        <link href="../css/memberdata.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript"> 
    function checkedTypeOK()
    {  
        var temp=document.getElementsByName("ctl00$ContentPlaceHolder1$radioType"); 
        var objhidradioType=document.getElementById("ctl00_ContentPlaceHolder1_hidradioType");
        for (i=0;i<temp.length;i++)
        {  
           if(temp[i].checked)      
	        {  
	           objhidradioType.value=temp[i].value;  //选择资讯类别       
   	        }  	
        }
    } 
 
	function chkInput()
	{ 
        var i;var j;
        var lenTitle = 0;
        var lenInstruction=0;
        var objTitle=document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value;
        var objInstruction=document.getElementById("ctl00_ContentPlaceHolder1_txtInstruction").value;
        for (i=0;i<objTitle.length;i++)
        { 
            if (objTitle.charCodeAt(i)>255) lenTitle+=2; else lenTitle++;
        }
        for (j=0;j<objInstruction.length;j++)
        {
            if (objInstruction.charCodeAt(i)>255) lenInstruction+=2; else lenInstruction++;
        }
        if(lenTitle==0||lenTitle>70) 
        {
                alert('标题不为空且不超过35个汉字!');
                document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").focus();
			    return false; 
        } 
        if(document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value=="")
        {
                alert('请选择所属地区!'); 
			    return false; 
        }
        if(lenInstruction>80) 
        {
                alert('图片说明不超过40个汉字!');
                document.getElementById("ctl00_ContentPlaceHolder1_txtInstruction").focus();
			    return false; 
        } 
		if(document.getElementById("ctl00_ContentPlaceHolder1_txtSource").value=="")
		{
			alert("资讯来源不为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_txtSource").focus();
			return false;
		}  
		if(document.getElementById("ctl00_ContentPlaceHolder1_txtContent").value=="")
		{
		    alert("资讯内容不为空!");
			document.getElementById("ctl00_ContentPlaceHolder1_txtContent").focus();
			return false;
		}
		  document.getElementById("imgLoding2").style.display = "block";
   
	}
	
	function chkArea()
	{
	      var objProvince= document.getElementById("ctl00_ContentPlaceHolder1_hidProvince").value;
	}

   function cancel()
   {
        document.getElementById("ctl00_ContentPlaceHolder1_ZoneSelectControl1_hideProvince").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtTitle").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtContent").value=""; 
        document.getElementById("ctl00_ContentPlaceHolder1_txtSource").value="";
        document.getElementById("ctl00_ContentPlaceHolder1_txtInstruction").value="";
   }
</script> 
<input type="hidden" id="hidradioType" name="hidradioType" value="01" runat="server" /> 
<input type="hidden" id="hidProvince" name="hidProvince" value="" runat="server" /> 
<input type="hidden" id="hidCity" name="hidCity" value="" runat="server" /> 
<input type="hidden" id="hidCounty" name="hidCounty" value="" runat="server" /> 
<div class="mainconbox"  id="mainconbox">
<div class="titled">
<div class="left"> 更新资讯
</div>
<div class="clear"></div>
</div>

<div>前面标有“<span class="hong">*</span>”的为必填选项</div>
<table border="1" cellpadding="0" cellspacing="0" class="tabbiank" runat="server" id="tbNews">
  <tr>
    <td align="right" bgcolor="#F7F7F7" style="width: 148px"><span class="hong">* </span><strong>资讯类别：</strong></td>
    <td width="606"> 
      <input name="radioType" type="radio" value="01" checked="true" id="radioType01"  disabled="true" onclick="checkedTypeOK()" runat="server" />   
      招商动态  <input type="radio" name="radioType" value="64" id="radioType64" disabled="true" onclick="checkedTypeOK()" runat="server"/>   投资环境  <input type="radio" id="radioType65" name="radioType" value="65" disabled="true" onclick="checkedTypeOK()" runat="server"/>   招商政策  <input type="radio" name="radioType"  id="radioType66"  value="66" disabled="true" onclick="checkedTypeOK()" runat="server"/>   投资指南  <input type="radio" name="radioType" id="radioType67"  value="67" disabled="true" onclick="checkedTypeOK()" runat="server"/>   招商活动</td>
  </tr>
  <tr>
    <td  align="right" bgcolor="#F7F7F7" style="width: 148px"><span class="hong">*</span> <strong>所属区域：</strong></td>
    <td width="606"> 
<uc1:ZoneSelectControl ID="ZoneSelectControl1" runat="server"></uc1:ZoneSelectControl>   </td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 148px"><span class="hong">*</span> <strong>标题：</strong></td>
    <td valign="top"><input name="txtTitle" type="text" id="txtTitle" value="" size="45" runat="server"  />
        <p class="hui">标题长度不超过35个汉字，两个字母或数字为一个汉字。</p></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 148px"><span class="hong">*</span> <strong>来源：</strong></td>
    <td width="606" valign="top">
     
      <input name="txtSource" type="text" id="txtSource" value="" size="45" runat="server" />
      <p class="hui">请填写您此篇文章的出处，如果该文为您的原创内容，来源可填写您的姓名。</p></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="height: 208px; width: 148px;"><span class="hong">*</span> <strong>正文：</strong></td>
    <td valign="top" style="height: 208px"><textarea name="txtContent" cols="80" rows="12" id="txtContent" runat="server"></textarea></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 148px"><strong>上传图片：</strong></td>
    <td valign="top">
        <asp:FileUpload ID="uploadPic" runat="server" Width="235px" />&nbsp;<asp:Button ID="btnUpload"
            runat="server" OnClick="btnUpload_Click" Text="上 传" />
        <asp:Label ID="LblMessage" runat="server" ForeColor="#C00000"></asp:Label><br />
   
          <span class="hui">图片须为jpg或gif格式，大小不超过100K </span></td>
  </tr>
  <tr>
    <td  align="right" valign="top" bgcolor="#F7F7F7" style="width: 148px"><strong>图片说明：</strong></td>
    <td valign="top"><input name="txtInstruction" type="text" id="txtInstruction" value="" size="45" runat="server" />
      <br />
      <span class="hui">图片说明不超过40个汉字</span></td>
  </tr>
</table>　
<div class="blank0"></div>
<div class="pad_1" align="center"><asp:Button ID="btnOK" runat="server" CssClass="buttomal" Text="提 交" OnClick="btnOK_Click" OnClientClick="return chkInput();"></asp:Button> 
   <input type="button" value="清 空" onclick="cancel();"  class ="buttomal"/>
</div>
</div>
<div id="imgLoding2" Style="position: absolute; 
   display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1350px; filter: 
   alpha(opacity=60);">

               <div class="content">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../images/loading42.gif" alt="Loading" />
                </div>
   </div>  
</asp:Content>