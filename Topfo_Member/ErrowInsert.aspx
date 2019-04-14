<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ErrowInsert.aspx.cs" Inherits="ErrowInsert" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>错误显示提交页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table >
    <tr><td>链接地址：</td><td>
        <asp:TextBox ID="txtlinkurl" runat="server" Width="385px"></asp:TextBox></td><td></td></tr>
    <tr><td>问题描述：</td><td>
        <asp:TextBox ID="txtdescrption" runat="server" TextMode="MultiLine" Width="385px" Height="70px"></asp:TextBox></td><td></td></tr>
    <tr><td>联系方式</td><td>
        <asp:TextBox ID="txtconnection" runat="server" Width="250px" ></asp:TextBox></td><td></td></tr>
    <tr><td colspan="3" align ="center">
        <asp:Button ID="btnSave" runat="server" Text="提 交" OnClick="btnSave_Click" /></td></tr>
    </table>
    </div>
    </form>
</body>
</html>
