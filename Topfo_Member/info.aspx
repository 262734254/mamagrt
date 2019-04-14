<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info.aspx.cs" Inherits="info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>中国招商投资网</title>
    <meta http-equiv="refresh" content="" />
    <script type="text/javascript">
    //setTimeout("location.href='<%=infoURL %>';",5000);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server">
        欢迎光临中国招商投资网，您没有登陆网站，如购买资源需注册登陆。<br />
        您可以选择如下操作：<br />
        <a href="http://member.topfo.com/Register/Register.aspx">注册</a>　　或者继续查看资源信息（<a href="<%=infoURL %>"><%=infoTitle.Trim() %></a>）
        <br />
        <br />
        如果你没有选择，5秒后将自动跳转到您的资源信息页面
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        欢迎光临中国招商投资网，您已成功注册成为中国招商投资网会员并已经登陆，注册信息已经发至您的邮箱。<br />
        您的注册信息如下：<br />
        您现在可以做如下操作：<br />
        <a href="<%=manageurl %>">后台管理</a>　　<a href="http://member.topfo.com/Register/Register.aspx">修改密码</a>　　
        或者继续查看资源信息（<a href="<%=infoURL %>"><%=infoTitle.Trim() %></a>）
        <br />
        <br />
        如果你没有选择，5秒后将自动跳转到您的资源信息页面
    </asp:Panel>
    </div>
    </form>
</body>
</html>
