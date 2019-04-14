<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TEST2.aspx.cs" Inherits="Message_TEST2" Async="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
<asp:FileUpload ID="FileUpload1" runat="server" />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" EnableTheming="False" TextMode="MultiLine"
        Width="386px"></asp:TextBox>标题<br />
    <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox>发件人邮箱<br />
    <asp:TextBox ID="txtShoujianren" runat="server" Height="99px" OnTextChanged="txtShoujianren_TextChanged"
        TextMode="MultiLine" Width="394px"></asp:TextBox>收件人邮箱多个以；分号隔开<br />
    <asp:TextBox ID="txtContent" runat="server" Height="99px" TextMode="MultiLine" Width="394px"></asp:TextBox>内容<br />
    <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>163邮箱帐号<br />
    <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
    163邮箱密码<br />
    <asp:TextBox ID="TextBox2" runat="server">smtp.163.com</asp:TextBox>邮箱主机默认是smtp.163.com<br />
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="发送" /></div>
</form>
</body>

</html>
