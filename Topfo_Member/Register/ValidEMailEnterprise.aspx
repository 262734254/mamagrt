<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidEMailEnterprise.aspx.cs" Inherits="Register_ValidEMailEnterprise" %>

<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>邮箱验证－－企业会员</title>
    <link href="../css/regstep_2.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/ReValidEmail.js"></script>

</head>
<body>
    <uc1:Header ID="Header1" runat="server" />

<div class="mainnav">
	<ul>
		<li>1．选择会员类型</li>
		<li>2．填写基本信息</li>
		<li >3．注册成功 </li>
	</ul>
</div>


<div class="content">
	<div class="content_top">
		<div class="clew_step3">
			<h4>安全电子邮箱验证</h4>			
	  </div>
	</div>
	<div class="clewbox">
		<div class="clewbox_top"></div>
		<div class="clewbox_content">
		<h4>您的邮箱还没经过验证！现在请按以下步骤操作：</h4>
	    <h1>第一步：查收验证信</h1>
      <h2>我们已发送验证信到：<asp:Label ID="lblMail" runat="server"></asp:Label><br />
        如果您的邮箱有误， <a href="javascript:" onclick="ShowMessageWin('modify')">&gt;&gt; 请点此修改</a></h2>
	    <h1>第二步：点击信中确认按钮</h1>
      <h2>打开您收到的验证邮件，然后点击页面中的“<span>点此确认</span>”按钮，即可验证成功！</h2>
        <h2>如果没有收到验证邮件，<a href="javascript:" onclick="ShowMessageWin('resend')">&gt;&gt; 请点此重新验证</a></h2>
		 </div>
	<div class="clewbox_bot">
	<input type="hidden" id="name" value="<%=name %>" />
	<input type="hidden" id="domain" value="<%=domain %>" />
	<input type="hidden" id="validurl" value="<%=validurl %>" />
	
	</div>
</div>
	<div class="bigclew" style="display:none">
		<p>通过邮箱验证后，您即可享受以下服务：</p>
		<div class="item">
		<h5>免费发布各种需求 </h5>
		<h6>免费发布需求，让潜在的合作方找到您！</h6>
		</div>
		<div class="item">
		<h5>免费推广招商机构 </h5>
		<h6>免费登记您的公司，创建网上展厅，让60多万会员关注您的企业！</h6>
		</div>
		<div class="clear"></div>
	</div>
	<div class="bigclew"  style="display:none">
	<p>升级拓富通会员，享受更多特权，彰显尊贵身份！</p>
	<h3>拓富通会员专享特权:</h3>
	<table width="0" border="0" cellpadding="0" cellspacing="0" class="franchisetable">
		<thead>
			<tr>
			<td>功能</td>
			<td>拓富通会员</td>
			<td>普通会员</td>
			</tr>
		</thead>	
		  <tr>
			<th>刷新设置，优先排序</th>
			<td><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th>身份认证，潜在客户更信任</th>
			<td><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th>网上展厅（暂不对个人会员开放）</th>
			<td><img src="../images/reg_step/right.gif" width="19" height="16" />功能强大</td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" />仅有基础功能</td>
		  </tr>
		  <tr>
			<th>VIP价格享受所有收费服务，超值回报</th>
			<td><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th>定向推广</th>
			<td><img src="../images/reg_step/right.gif" width="19" height="16" />享受一定额度的定向推广服务</td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th>定制资源 抢占先机</th>
			<td><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tfoot>
		  	<tr>
  			  <td colspan="3"><a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml">&gt;&gt; 了解更多特权</a></td>
		    </tr>
		  </tfoot>
	</table>

  </div>


	<div class="join"  style="display:none">
		
		<p><a href="VIPMemberRegister.aspx" target="_blank"><img src="../images/reg_step/join.gif" border="0" /></a></p>
        <div class="con">咨询热线：0755-89805558</div>
	</div>
	
	<div class="content_bottom"></div>
</div>
    <uc2:Footer ID="Footer1" runat="server" />
</body>
</html>
<script language="javascript" src="../js/Ajax.js" type="text/javascript"></script>
