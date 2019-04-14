<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ComentForCapitalVIP.aspx.cs"
    Inherits="helper_InfoComment_ComentForCapitalVIP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    body{ text-align:center; font-family:"宋体", arial; margin:0; padding:0; font-size:12px; color:#000; line-height:130%; background-color: #E1EDFD; }
    a:link {color: #000000; text-decoration:none;}
a:visited {color: #FF6600;text-decoration:none;}
a:hover {color: #ee2306; text-decoration:underline;}
a:active {color: #FF0000;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtContent" runat="server" cols="88" rows="7" TextMode="MultiLine" Width="96%" onfocus="if (value =='输入留言内容...'){this.value=''}"
            onblur="if (value ==''){this.value='输入留言内容...'}">输入留言内容...</asp:TextBox>
        <table width="100%" border="0" cellspacing="5" cellpadding="0">
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
                                    尊敬的：<asp:Literal ID="lblNickName" runat="server"></asp:Literal>,您可以在对此资源留言.
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSend" runat="server" OnClick="btnSend_Click" Text="提交评论" /></td>
                </tr>
        </table>
    </form>
</body>
</html>
