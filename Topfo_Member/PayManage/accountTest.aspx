<%@ Page Language="C#" AutoEventWireup="true" CodeFile="accountTest.aspx.cs" Inherits="PayManage_accountTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="http://img2.topfo.com/member/css/payment.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" />
 <link href="../offer/css/member.css"rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="zfliucheng"><img src="http://img2.topfo.com/img/payment2_03.jpg"  /></div>
<div class="payment1">
  <h1> 多种支付方式任你选择</h1>
  <div class="payment1-1">
    <ul>
      <li><span class="payment1-1-a">应付总额：</span><span class="f_red strong"><asp:Label
          ID="lblorder_no" runat="server"></asp:Label></span></li>
      <li><span class="payment1-1-a">您的账户余额：</span><span class="f_red strong"><asp:Label
          ID="lblUser_no" runat="server"></asp:Label></span></li>
    </ul>
  </div>
</div>

<div class="payment2">
<h1>
  <span class="payment2-a">使用账户余额进行支付</span> <span><a href="#" class="f_lan">我想使用其他支付方式</a></span></h1>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="account-3-td-r">应付款总额：</td>
  <td class="account-3-td-l f_red strong"> <asp:Label ID="lblorderby_no" runat="server"></asp:Label></td>
  </tr>
  <tr>
    <td class="account-3-td-r">支付密码：</td>
    <td class="account-3-td-l"><input name="" type="password" class="pawwword-input" id="txtPwd" runat="server" /></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td style="padding-top:8px"><%--<input name="" type="image" src="http://img2.topfo.com/img/payment2_11.jpg" />--%>
        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" /></td>
  </tr>
</table>

</div>
    </form>
</body>
</html>
