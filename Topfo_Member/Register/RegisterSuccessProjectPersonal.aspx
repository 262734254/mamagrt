﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterSuccessProjectPersonal.aspx.cs" Inherits="Register_RegisterSuccessProjectPersonal" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>注册成功</title>
    <link href="../css/regstep.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/Register.js"></script>
    </head>
<body>
    <uc1:Header ID="Header1" runat="server" />


<div class="mainnav">
	<ul>
		<li>1．选择会员类型</li>
		<li>2．填写基本信息</li>
		<li class="up">3．注册成功 </li>
  </ul>
</div>
    <form id="form1" runat="server">
<div class="content">
<div class="choose">
    <div class="leftbgset4" >
        <h4 class="fontcss">注册成功，恭喜您成为中国招商投资网的会员！</h4>	
	</div>
    <div class="bigclew clewbg">
		<p>您现在可享受以下服务：</p>
		<h4><a href="http://member.topfo.com/Publish/project/gq1.aspx">发布项目融资需求</a> ，立即匹配对口资源！</h4>
		<h4><a href="http://zycs.topfo.com/">查找对口资源</a> ，主动出击，提高融资效率！</h4>
		<h5><a href="/Publish/publishNavigate.aspx"><img src="../images/reg_step/topfocenter.gif" border="0" /></a></h5>
	</div>
<%--<div class="succes">注册成功，恭喜您成为中国招商投资网的会员！</div>
<div class="services">您现在可享受以下服务：</div>
<div class="module"><!--
<div class="yello"><strong>登记公司信息</strong><br />
  让投资方全面了解您的公司</div>-->
<div class="hot"><a href="http://member.topfo.com/Publish/project/gq1.aspx" target="_blank"><strong>发布项目融资需求</strong></a><br />
  立即匹配对口资源</div>
<div class="whit"><a href="http://www.topfo.com/help/inquireDK.shtml" target="_blank"><strong>查找对口资源</strong></a><br />
  主动出击 提高融资效率</div><!--
<div class="whit"><strong>进入拓富论坛</strong><br />
  结交行业人士 交流生意经</div>-->
</div>
<div class="nextmore">
<div class="ltext">进入<a href="http://member.topfo.com">拓富中心</a>，体验更多精彩服务！</div><div class="rimg"><img src="../images/succe_14.jpg" width="19" height="19" /></div>
</div>
--%>
<div class="upgrade" style="font-size:14px;">升级拓富通会员，享受更多特权，彰显尊贵身份！ </div>
<div class="liuda"><img src="../images/succe_26.jpg" /></div>
<div class="franchisetable">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td bgcolor="#f7f7f7" class="td_szx">功能	</td>
      <td bgcolor="#f7f7f7" class="td_sx">拓富通会员 </td>
      <td bgcolor="#f7f7f7" class="td_syx">普通会员</td>
    </tr>
    <tr>
      <td class="td_zyx">刷新设置，优先排序	</td>
      <td class="td_xy"><img src="../images/right.gif" width="19" height="16" /></td>
      <td class="td_xy"><img src="../images/no.gif" width="12" height="12" /></td>
    </tr>
    <tr>
      <td class="td_zyx">身份认证，潜在客户更信任	

</td>
      <td class="td_xy"><img src="../images/right.gif" width="19" height="16" /></td>
      <td class="td_xy"><img src="../images/no.gif" width="12" height="12" /></td>
    </tr>
    <tr>
      <td class="td_zyx">精美网上展厅</td>
      <td class="td_xy"><img src="../images/right.gif" width="19" height="16" /></td>
      <td class="td_xy"><img src="../images/no.gif" width="12" height="12" /></td>
    </tr>
    <tr>
      <td class="td_zyx">VIP价格享受所有收费服务 </td>
      <td class="td_xy"><img src="../images/right.gif" width="19" height="16" /></td>
      <td class="td_xy"><img src="../images/no.gif" width="12" height="12" /></td>
    </tr>
    <tr>
      <td class="td_zyx">享受一定额度的定向推广服务	</td>
      <td class="td_xy"><img src="../images/right.gif" width="19" height="16" /></td>
      <td class="td_xy"><img src="../images/no.gif" width="12" height="12" /></td>
    </tr>
    <tr>
      <td class="td_zyx" style="height: 14px">申请专业服务的资格</td>
      <td class="td_xy" style="height: 14px">享受所有专业服务的申请权利</td>
      <td class="td_xy" style="height: 14px">仅享受部分专业服务申请权利</td>
    </tr>
    <tr>
        <td colspan="3" align="right" class=td_zyx><a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml">了解更多特权</a></td>
    </tr>
  </table>
</div>

<div class="tftong">
  <div class="lefttxtt"><a class=spaces  href="http://member.topfo.com/Register/VIPMemberRegister.aspx" target="_blank"><img src="../images/succe_29.jpg" alt="加入富通拓" width="312" height="112" border="0" /></a></div>
<div class="lefttxt"><font color="#000">咨询热线：</font>0755-89805558</div>
</div>
    <uc2:Footer ID="Footer1" runat="server" />
</div>
</div>
    </form>
</body>
</html>
