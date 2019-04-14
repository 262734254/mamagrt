<%@ Page Language="C#" AutoEventWireup="true" CodeFile="accountpaytest.aspx.cs" Inherits="PayManage_VipPay_accountpaytest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
<link href="http://img2.topfo.com/member/css/payment.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" />
 <link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />
 <script src="../../offer/js/yanz.js" ></script>
<script language="javascript" >
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
</head>
<body>
    <form id="form1" runat="server">
<%--<div class="head-bg">
  <div class="head">
    <div class="logo"> <img src="images/member_14.jpg" /> </div>
    <div class="head-list">
      <ul>
        <li><a href="#">融资</a></li>
        <li><a href="#">投资</a></li>
        <li><a href="#">政府招商</a></li>
        <li><a href="#">资源超市</a></li>
        <li><a href="#">资源联盟</a></li>
        <li id="head-kf-bg"><a href="#">客服中心</a></li>
        <li id="head-fh-bg"><a href="#">返回首页</a></li>
      </ul>
    </div>
    <div class="head-phon"><img src="images/member_20.jpg" /> </div>
  </div>
</div>--%>
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
  <span class="payment2-a">使用账户余额进行支付</span> <span><a href="#" class="f_lan">我想使用其他支付方式</a></span></h1>

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
    <td style="padding-top:8px">  
        <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick=" return check();" ImageUrl="http://img2.topfo.com/member/img/payment2_11.jpg" OnClick="ImageButton1_Click" />
   <%-- <input name="" type="image"  src="http://img2.topfo.com/member/img/payment2_11.jpg" />--%></td>
  </tr>
</table>

</div>
<div class="foot-fg">
  <div class="foot">
    <p> <a href="#">关于我们</a> | <a href="#">平台介绍</a> | <a href="#">我们的服务</a> | <a href="#">支付方式</a> | <a href="#">广告服务</a> | <a href="#">服务条款</a> | <a href="#">联系我们</a> | <a href="#">留言反馈</a> | <a href="#">友情链接</a> </p>
    <p> 1998-2009 版权所有    InvestGuide.cn <br />
      拓富科技 中国招商投资网  英文站  拓富网  贤泽投资 支持合作：联合国工业发展组织中国投资促进处唯一授权合作网站<br />
      经营许可证编号为:粤B2-20040428 　ICP编号：粤B2-19981001
      E-Mial:advise@tz888.cn </p>
  </div>
</div>
    </form>
</body>
       <script language="javascript">  createCode();</script>

</html>
