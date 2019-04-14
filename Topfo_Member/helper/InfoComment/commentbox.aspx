<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commentbox.aspx.cs" Inherits="helper_InfoComment_commentbox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>评论</title>
    <link href="http://www.topfo.com/css/common.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="2%" style="height: 24px">
                </td>
                <td>
                    <div runat="server" id="divLogin">
                        用户名：<input name="" type="text" class="hei1 w2" id="txtLoginName" runat="server" />
                        密 码：<input name="" type="password" class="hei1 w2" id="txtPassWord" runat="server" /><asp:Button
                            ID="btnLogin" CssClass="btn06" runat="server" Text="登陆" OnClick="btnLogin_Click" />&nbsp;
                        <a class="ablue01" href="http://member.topfo.com/Register/Register.aspx" target="_blank">
                            免费注册</a>
                    </div>
                    <div runat="server" id="divLoginOk">
                        尊敬的：<asp:Literal ID="lblNickName" runat="server"></asp:Literal>!您可以在对此资讯发布评论.
                    </div>
                </td>
            </tr>
            <tr>
                <td width="2%">
                </td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="89px" Width="98%"></asp:TextBox></td>
            </tr>
            <tr>
                <td width="2%">
                </td>
                <td align="right">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Button ID="btnSend" runat="server" Text="提交评论" OnClick="btnSend_Click" /></td>
            </tr>
        </table>

        <script language="javascript">
var id = "<%=this.lblMsg.ClientID %>";
var txtid = "<%=this.txtContent.ClientID %>";
function loading()
{
    var obj = document.getElementById(id);
    if(document.getElementById(txtid).value=="")
    {
      obj.innerHTML ="<font color='red'>评论不能为空.</font>";
      return;
    }
    else
    {
        obj.innerHTML ="<img src=\"http://www.topfo.com/Web13/images/down.gif\" />正在加载....";
    }
}

        </script>

    </form>
</body>
</html>
