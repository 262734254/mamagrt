<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>
<html>
 <head>
  <title>多文件上传</title>
 </HEAD>
 <body>
  <form id="attachme" method="post" encType="multipart/form-data" runat="server">
   <input class="bluebutton" id="FindFile" type="file" size="26" runat="server" NAME="FindFile" >
   <BR>
   <asp:listbox id="FileList" runat="server" CssClass="txtbox" Height="100px" Width="274px" ></asp:listbox><BR>
   <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加文件"/>&nbsp;<asp:button id="RemvFile" runat="server" CssClass="bluebutton" Height="23px" Width="72px" Text="删除文件" OnClick="RemvFile_Click"></asp:button>
   <input class="bluebutton" id="Upload" type="submit" value="上传" runat="server" onserverclick="Upload_ServerClick"
    name="Upload">
  </form>
  <asp:label id="TipInfo" runat="server" Height="25px" Width="249px"></asp:label>
 </body>
</html>