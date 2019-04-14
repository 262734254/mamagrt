<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CommentForInfo.aspx.cs" Inherits="helper_InfoComment_CommentForInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <link href="/css/blue.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server">
        <div class="message">
            <a href="/helper/InfoComment/CommentForeList.aspx?id=<%=InfoID %>" target="_blank">已有<asp:Literal ID="lblCount" runat="server"></asp:Literal>位用户留言，点击查看</a></div>
        <div class="message" style="left: 0px; top: 0px">
            <asp:TextBox ID="txtContent" runat="server" Height="89px" TextMode="MultiLine" Width="96%"></asp:TextBox></div>
        <div class="message" style="left: 0px; top: 0px">
            <table width="93%" border="0" cellspacing="5" cellpadding="0">
                <tr>
                    <td>
                        <table width="93%" border="0" cellspacing="1" cellpadding="0" runat="server" id="divLogin">
                            <tr>
                                <td>
                                    用户名：</td>
                                <td>
                                    <input id="txtLoginName" runat="server" class="hei1 w2" name="" style="width: 114px"
                                        type="text" /></td>
                                <td>
                                    密码：</td>
                                <td>
                                    <input id="txtPassWord" runat="server" class="hei1 w2" name="" style="width: 101px"
                                        type="password" /></td>
                                <td>
                                    <a href="http://member.topfo.com/Register/Register.aspx" target="_blank">免费注册</a></td>
                                <td>
                                    <asp:Button ID="btnLogin" runat="server" CssClass="btn06" Text="登陆" OnClick="btnLogin_Click1" />
                                </td>
                            </tr>
                        </table>
                        <table width="93%" border="0" cellspacing="1" cellpadding="0">
                            <tr runat="server" id="divLoginOk">
                                <td>
                                    尊敬的：<asp:Literal ID="lblNickName" runat="server"></asp:Literal>!您可以在对此资源留言.
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="提交评论" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
