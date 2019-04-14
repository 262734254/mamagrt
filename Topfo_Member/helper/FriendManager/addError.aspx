<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addError.aspx.cs" Inherits="helper_FriendManager_addError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>添加好友失败</title><link href="../../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<table width="500" height="139" border="0" align="center" cellpadding="0" cellspacing="0" class="cshibiank" >
  <tr>
    <td align="left" valign="top" style="padding:0"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="margin:1px">
      <tr>
        <td height="38" colspan="3" class="lightc" style="padding-left:15px" ><strong> 对不起，<asp:HyperLink runat="server" ID="hplName" CssClass="lanlink"></asp:HyperLink>  设置只有拓富通会员才能将他加为好友！</strong></td>
        </tr>
      <tr>
        <td width="71" height="27">&nbsp;</td>
        <td colspan="2">&nbsp;</td>
      </tr>
      <tr>
        <td height="44">&nbsp;</td>
        <td width="177"><img src="../../images/AccountInfo/biao_yuan.gif" width="15" height="15" /> <a href="http://www.topfo.com/help/TopfoServer.shtml#a5" class="lanlink">了解一下拓富通会员服务 </a></td>
        <td width="248"><img src="../../images/AccountInfo/biao_yuan.gif" width="15" height="15" /> <a href="http://member.topfo.com/Register/VIPMemberRegister_In.aspx" class="lanlink">立即申请拓富通会员服务</a></td>
      </tr>
      <tr>
        <td height="33">&nbsp;</td>
        <td colspan="2">咨询热线：0755-89805589 咨询QQ：526541518 </td>
        </tr>
      <tr>
        <td>&nbsp;</td>
        <td height="20" align="right" valign="top">&nbsp;</td>
        <td align="center">&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td height="70" align="right" valign="top"><label>
          <input type="button" name="button" value="关 闭"  onclick="javascript:history.go(-1)"/>
        </label></td>
        <td align="center">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>
    </form>
</body>
</html>
