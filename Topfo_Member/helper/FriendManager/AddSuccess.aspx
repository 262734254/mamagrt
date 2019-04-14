<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSuccess.aspx.cs" Inherits="helper_FriendManager_AddSuccess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>添加好友成功</title><link href="../../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<table width="500" height="139" border="0" align="center" cellpadding="0" cellspacing="0" class="cshibiank" >
  <tr>
    <td align="left" valign="top" style="padding:0"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin:1px">
      <tr>
        <td height="38" colspan="3" class="lightc" style="padding-left:15px" ><strong> 恭喜，您已经成功添加<asp:HyperLink runat="server" ID="hplName" ></asp:HyperLink>为您的好友了！</strong></td>
        </tr>
      <tr>
        <td height="27">&nbsp;</td>
        <td colspan="2">&nbsp;</td>
      </tr>
      <tr>
        <td width="117" height="33">&nbsp;</td>
        <td colspan="2" class="font14">现在您可以：</td>
        </tr>
      <tr>
        <td height="32">&nbsp;</td>
        <td colspan="2"><img src="../../images/AccountInfo/biao_yuan.gif" width="15" height="15" /> <a href="friendList.aspx" class="lanlink">查看您的好友列表</a></td>
        </tr>
      <tr>
        <td height="33">&nbsp;</td>
        <td colspan="2"><img src="../../images/AccountInfo/biao_yuan.gif" width="15" height="15" /> <asp:HyperLink
                ID="hplSendInfo" runat="server"></asp:HyperLink></td>
        </tr>
      <tr>
        <td>&nbsp;</td>
        <td height="20" align="center" valign="top">&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td width="128" height="70" align="center" valign="top"><input type="button"   name="button" value="关 闭" onclick="window.close()" />
            </td>
        <td width="251">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
    </form>
</body>
</html>

