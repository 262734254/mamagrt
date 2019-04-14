<%@ Page Language="C#" AutoEventWireup="true" CodeFile="autoRegCenter.aspx.cs" Inherits="autoRegCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户跳转中心</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" border="0">
                <tr>
                    <td colspan="2" align="center">
                        <%=this.welMessage %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        用户名：</td>
                    <td align="left">
                        <%=this.welusername %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密码：</td>
                    <td align="left">
                        <%=this.welpwd %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <a href='<%=this.welUrl %>'>进入资源页</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="http://member.topfo.com/Publish/publishNavigate.aspx">
                            进入用户管理中心</a>
                    </td>
                </tr>
            </table>
            <a onclick="alert(document.cookie);">点击查看cookie</a><br />
        </div>
    </form>
</body>
</html>
