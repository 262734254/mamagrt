<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResourceOver.aspx.cs" Inherits="helper_ResourceOver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>拓富中心-拓富·中国招商投资网</title>

<link href="../css/common.css"rel="stylesheet" type="text/css" />
<link href="../css/index.css" rel="stylesheet" type="text/css" />
<link href="../css/right_style.css" rel="stylesheet" type="text/css" />
<link href="../css/paymanage.css" rel="stylesheet" type="text/css" />
<link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
<link rel="/css/stylesheet" href="/css/cm.css" type="text/css" >
</head>

<body>
<DIV class="mainconbox">
  <div class="topzi">
    <div class="left">定向资源查看</div>
    <div class="clear"></div>
  </div>
  <table cellspacing="0" class="mem_tab1" style="width: 560px; height: 228px">
    <tr>
      <td class="tdbg" style="width: 106px"><strong>推广资源标题：</strong></td>
      <td style="width: 244px">
          <asp:Label ID="lblTitle" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="tdbg" style="width: 106px"><strong>推广目标用户：</strong></td>
      <td style="width: 244px">
          <asp:Label ID="lblMember" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="tdbg" style="width: 106px"><strong>受众用户属性：</strong></td>
      <td style="width: 244px">
          <asp:Label ID="lblProject" runat="server"></asp:Label></td>
    </tr>
    <tr>
      <td class="tdbg" style="width: 106px; height: 52px;"><strong>受众区域：</strong></td>
      <td style="width: 244px;">
          <asp:Label ID="lblCountry" runat="server"></asp:Label></td>
    </tr>
    <tr>
    
      <td class="tdbg" style=" width: 106px;"><strong>推广方式和数量：</strong></td>
      <td style="width: 244px;">
          1,Email 2,站内短信 3,手机<br />
          <asp:Label ID="lblcount" runat="server"></asp:Label></td>
    </tr>
  </table>
    <input  onclick="history.back();" class="buttomal" type="button" value="返回" />
    </DIV>
</body>
</html>

