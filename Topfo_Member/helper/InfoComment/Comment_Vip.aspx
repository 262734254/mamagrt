<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comment_Vip.aspx.cs" Inherits="helper_InfoComment_Comment_Vip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="/css/tuofu.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-right: 0;background:#ebf1fd;">
    <form id="form1" runat="server">
        <div class="message" style="background-color: #ebf1fd">
            <div class="leftsr">
                <a href="/helper/InfoComment/CommentForeList.aspx?id=<%=InfoID %>" target="_blank">已有<asp:Literal ID="lblCount" runat="server"></asp:Literal>位用户留言，点击查看</a>
                <asp:TextBox ID="txtContent" runat="server" Height="96px" TextMode="MultiLine" Width="96%"></asp:TextBox>
                <table width="93%" border="0" cellspacing="5" cellpadding="0">
                    <tr>
                        <td>
                            <table width="93%" border="0" cellspacing="1" cellpadding="0" runat="server" id="divLogin">
                                <tr>
                                    <td>
                                        用户名：</td>
                                    <td>
                                        <input id="txtLoginName" runat="server" class="hei1 w2" name="" style="width: 83px"
                                            type="text" /></td>
                                    <td>
                                        密码：</td>
                                    <td>
                                        <input id="txtPassWord" runat="server" class="hei1 w2" name="" style="width: 71px"
                                            type="password" /></td>
                                    <td>
                                        <a href="http://member.topfo.com/Register/Register.aspx" target="_blank">免费注册</a></td>
                                    <td style="width: 62px">
                                        <asp:Button ID="btnLogin" runat="server" CssClass="btn06" Text="登陆" OnClick="btnLogin_Click1" />
                                    </td>
                                </tr>
                            </table>
                            <table width="93%" border="0" cellspacing="1" cellpadding="0">
                                <tr runat="server" id="divLoginOk">
                                    <td style="height: 19px">
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
            <div class="rightsm">
                <span>·免责声明：</span>
                <br />
                以上内容由发布者提供，内容的真实性和合 法性由发布者负责，中国招商投资网对此不 承担任何责任。
                <br />
                <span>·风险防范：</span>
                <br />
                为确保您的权益，降低合作风险，请优先选 择<span><a href="#">拓富通会员</a></span></div>
        </div>
    </form>
</body>
</html>
