<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmaliTest.aspx.cs" Inherits="Message_EmaliTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="css/gray_topfo.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="width: 100px; height: 26px">
                    邮箱：</td>
                <td style="width: 123px; height: 26px">
                    <asp:TextBox ID="txtEmai" runat="server" Width="373px" TextMode="MultiLine" CssClass="inp_set"></asp:TextBox><br />
                    多个以"；"分号隔开。</td>
            </tr>
            <tr>
                <td style="width: 100px; height: 22px;">
                    标题：</td>
                <td style="width: 123px; height: 22px;">
                    <asp:TextBox ID="txtTitle" runat="server" Width="366px" CssClass="inp_set">深圳拓富网络有限公司恭祝您元旦快乐</asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" align="center">
        
                    <asp:Button ID="btnDouble" runat="server" OnClick="btnDouble_Click"  Text="发送" /></td>
            </tr>
        </table>
        &nbsp;
        </div>
    </form>

</body>
</html>
