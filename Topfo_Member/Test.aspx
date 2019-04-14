<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<%@ Register Src="Controls/UpFileControl.ascx" TagName="UpFileControl" TagPrefix="uc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>多文件上传</title>
</head>
<body>
    <form id="form1" method="post" runat="server" enctype="multipart/form-data">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />&nbsp;
        <br />
        <asp:CheckBoxList ID="chkReturn" runat="server">
        </asp:CheckBoxList>    
    </form>
</body>
</html>
