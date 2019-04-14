<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest ="false" CodeFile="NewsTabShenHe.aspx.cs" Inherits="news_NewsTabShenHe" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>资讯审核页</title>
     <link href="../css/CRM.css" rel="stylesheet" type="text/css" />
     <script  src="../js/JScriptloans.js" type ="text/javascript" language="javascript"></script>
       <script type ="text/javascript" language ="javascript">
           function postnewtabs()
   {
  if(document.getElementById ("txtnewsTitle").value.length==0)
   {
     document.getElementById ("showtxtnewsTitle").innerHTML="*";
     document.getElementById ("showtxtnewsTitle").style .display ="inline";
     document.getElementById ("txtnewsTitle").focus();
     return false;
   }
     if(document.getElementById ("txtzhaiyao").value.length==0)
   {
     document.getElementById ("showzhaiyao").innerHTML="*";
     document.getElementById ("showzhaiyao").style .display ="inline";
     document.getElementById ("txtzhaiyao").focus();
     return false;
   }     if(document.getElementById ("txttitle").value.length==0)
   {
     document.getElementById ("showtitle").innerHTML="*";
     document.getElementById ("showtitle").style .display ="inline";
     document.getElementById ("txttitle").focus();
     return false;
   }
     if(document.getElementById ("txtkeywords").value.length==0)
   {
     document.getElementById ("showkeywords").innerHTML="*";
     document.getElementById ("showkeywords").style .display ="inline";
     document.getElementById ("txtkeywords").focus();
     return false;
   }
     if(document.getElementById ("txtdescript").value.length==0)
   {
     document.getElementById ("showdescript").innerHTML="*";
     document.getElementById ("showdescript").style .display ="inline";
     document.getElementById ("txtdescript").focus();
     return false;
   }
      if(document.getElementById ("FreeTextBox1").value.length==0)
   {
     document.getElementById ("showcontext").innerHTML="*";
     document.getElementById ("showcontext").style .display ="inline";
     document.getElementById ("FreeTextBox1").focus();
     return false;
   }
     if(document.getElementById ("txtauthor").value.length==0)
   {
     document.getElementById ("showauthor").innerHTML="*";
     document.getElementById ("showauthor").style .display ="inline";
     document.getElementById ("txtauthor").focus();
     return false;
   }
   if(document.getElementById ("txtform").value.length==0)
   {
     document.getElementById ("showlaiyuan").innerHTML="*";
     document.getElementById ("showlaiyuan").style .display ="inline";
     document.getElementById ("txtform").focus();
     return false;
   }

   else
   {
    document.getElementById ("imgLoding").style .display ="";
  return true;
}
  }
         </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table border="0" cellpadding="0" cellspacing="0"    class="one_table">
    			<tr >
				<th colSpan="2">
					<div  align="center">资讯审核</div>
				</th>
			</tr>
    <tr><td><span style ="color:Red">*</span>标题：</td><td >
        <asp:TextBox ID="txtnewsTitle" onblur="outpostcode(this,'showtxtnewsTitle')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showtxtnewsTitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>摘要：</td><td >
        <asp:TextBox ID="txtzhaiyao" onblur="outpostcode(this,'showzhaiyao')" TextMode="MultiLine" runat="server" Height="64px" Width="351px"></asp:TextBox>&nbsp;<div id="showzhaiyao" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Title：</td><td >
        <asp:TextBox ID="txttitle" onblur="outpostcode(this,'showtitle')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showtitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Keywords：</td><td >
        <asp:TextBox ID="txtkeywords" onblur="outpostcode(this,'showkeywords')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showkeywords" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>Descript：</td><td >
        <asp:TextBox ID="txtdescript" onblur="outpostcode(this,'showdescript')" Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showdescript" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>类型：</td><td >
        <asp:DropDownList ID="ddrtype" runat="server">
        </asp:DropDownList></td></tr>
    <tr><td><span style ="color:Red">*</span>内容：</td><td >
        <textarea id="FreeTextBox1" onblur="outpostcode(this,'showcontext')" runat="server" cols="48" rows="7"></textarea>
                        &nbsp;<div id="showcontext" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>作者：</td><td >
        <asp:TextBox ID="txtauthor" onblur="outpostcode(this,'showauthor')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showauthor" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>来源：</td><td >
        <asp:TextBox ID="txtform" onblur="outpostcode(this,'showlaiyuan')" Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showlaiyuan" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
        <tr><td><span style ="color:Red"></span>是否推荐：</td><td >
            <asp:RadioButtonList ID="radiotui" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                <asp:ListItem Value="1">是</asp:ListItem>
            </asp:RadioButtonList>&nbsp;</td></tr>
    <tr><td colspan="3" align="center">
        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClientClick="return postnewtabs()"  Text="审 核" OnClick="btnSave_Click" />&nbsp;&nbsp;
           <input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn" /></td></tr>
    </table>
    </div>
    </form>
             <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1135px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>
</body>
</html>
