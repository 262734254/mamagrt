<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceReport.aspx.cs" Inherits="ResourceReport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全部资源--资源超市--中国招商投资网</title>
    <link href="css/resource3.0.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <table width="500" border="0" align="center" cellpadding="0" cellspacing="0" class="con21 f_14px">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="f_tit3" style="padding: 20px 0 5px 0;">
                    举报此资源</td>
            </tr>
            <tr>
                <td height="30" align="right">
                    资源标题：</td>
                <td>
                    <input id="tbTitle" type="text" name="textfield" style="width: 250px; height: 19px;"
                        runat="server" /></td>
            </tr>
            <tr>
                <td align="right">
                    内容：</td>
                <td>
                    <asp:TextBox ID="tbContent" runat="server" Rows="5" Style="width: 90%;" TextMode="multiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td style="padding: 5px 0 20px 0;">
                    <input type="submit" name="Submit" value=" 提交 " class="btn2" runat="server" id="Submit1"
                        onserverclick="Submit1_ServerClick"></td>
            </tr>
        </table>
    </form>
</body>
</html>
