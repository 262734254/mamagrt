<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="accountpay.aspx.cs" Inherits="PayManage_VipPay_accountpay" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />
 <script src="../../offer/js/yanz.js" type="text/javascript" ></script>
<script language="javascript"type="text/javascript" >
function check()
{
var inputCode = document.getElementById("validCode").value;   
       if(inputCode.length <=0)   
       {   
           alert("请输入验证码！"); 
            document.getElementById("validCode").focus();
       	         return false;  
       }   
       else if(inputCode.toUpperCase() != code )   
       {   
          alert("验证码输入错误！");   
          createCode();//刷新验证码   
           document.getElementById("validCode").focus();
       	         return false;
       } 
      
      
 } 
</script>
<div class="zfliucheng"><img src="http://img2.topfo.com/member/img/payment2_03.jpg"  /></div>
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
  <span class="payment2-a">使用支付宝进行支付</span> <span ><a href="#" class="f_lan">我想使用其他支付方式</a></span></h1>
<div class="pagment2-liuc">
<ul>
<li class="f_12px">支付宝付款流程 </li>
<li>
 <img src="http://img2.topfo.com/member/img/payment2_07.jpg" /> <span class=" strong"><a href="#" class="f_cen">查看演示</a></span></li>
<li class="f_cen f_12px"> 提示：您支付宝账户余额必须大于您购买的资源价格，您可以使用支付宝余额支付。</li>
</ul>
</div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
   <tr>
    <td class="account-3-td-r">应付款总额：</td>
    <td class="account-3-td-l f_red strong">
        <asp:Label ID="lblorderby_no" runat="server"></asp:Label></td>
  </tr>
 <tr>
    <td class="account-3-td-r">
        验证码：</td>
    <td class="account-3-td-l">
    <input  type="text"   id="validCode" /> 
     <input type="text" onclick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />
       </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td style="padding-top:8px"> <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick=" return check();" ImageUrl="http://img2.topfo.com/member/img/payment2_11.jpg" OnClick="ImageButton1_Click" /></td>
  </tr>
</table>



</div>

       <script language="javascript">  createCode();</script>

</asp:Content>

