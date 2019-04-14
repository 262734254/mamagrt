<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidSuccessEnter.aspx.cs" Inherits="Register_ValidSuccessEnter" %>

<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>注册成功</title>
    <link href="../css/regstep.css" rel="stylesheet" type="text/css" />
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


<div class="content">

	<div class="content_top" >
	<form id="Form1" runat="server" >
		<div class="clew_step4" style="display:none" id="divvalid" runat="server">
			<h4>恭喜,您的E-Mail验证成功</h4>	
			<h5>找资金，寻项目，成功尽在中国招商投资网！</h5>		
	    </div>
	
	    <div class="leftbgset4" id="divreg" runat="server">
	        <h4 class="fontcss">注册成功，恭喜您成为中国招商投资网会员！</h4>	
	        <p style="margin:0;padding:0;font-size:14px;">建议您立即进行E-mail验证，以确保您的账户更加安全，规避业务风险！</p>
	        <h3 class="linkcss"><a href="#" id="hpvalidurl" runat="server">立即验证</a></h3>
	        <div class="clear" ></div>
	    </div>
</form>	 
	</div>
<div style="clear: both; FONT-SIZE: 1px; OVERFLOW: hidden; HEIGHT: 6px"></div>
<!--验证成功显示部分START-->  
	<div class="bigclew clewbg" id="divafter" runat="server">
		<p>您现在可以：</p>
		<h4><a href="../login.aspx"> 进入拓富中心</a> ，体验我们为您提供的贴心服务！</h4>
		<h4><a href="http://www.topfo.com/help/index.shtml">了解拓富通服务</a> ，成为贵宾会员，享受更多特权，彰显尊贵身份！</h4>
		<h4><a href="http://www.topfo.com/">进入网站首页</a> ，在资本世界中徜徉！</h4>
		<h4><a href="http://bbs.topfo.com"> 进入拓富论坛</a> ，结识行业人士，交流生意经！</h4>
		<h5 style="font-size:15px">找资本 寻项目 尽在拓富&middot;中国招商投资网！</h5>
	</div>
<!--验证成功显示部分END-->  
    
  <!--验证前显示部分START-->  
  <div id="divahead" runat="server">
	<div class="bigclew clewbg">
		<p>您现在即可享受以下服务:</p>
		<h4><a href="../Publish/publishNavigate.aspx"> 免费发布需求</a> ，进入资源智能匹配系统，让对口对象主动找到您！</h4>
		<h4><a href="../Publish/PublishMerchant1.aspx">登记公司</a> ，全面展示您的实力和优势！</h4>
		<h4><a href="/">查找对口资源</a> ，主动出击，寻找合作机会！</h4>
		<h4><a href="http://bbs.topfo.com"> 进入拓富论坛</a> ，结识行业人士，交流生意经！</h4>
		<h5><a href="../login.aspx"><img src="../images/reg_step/topfocenter.gif" border="0" /></a></h5>
	</div>
	
	<div class="bigclew">
	<p>升级拓富通会员，享受更多特权，彰显尊贵身份！</p>
	<h3>拓富通会员专享特权:</h3>
	<table width="0" cellpadding="0" cellspacing="0" class="franchisetable">
		<thead>
		<tr>
			<td>功能</td>
			<td>拓富通会员</td>
			<td>普通会员</td>
		</tr>
		</thead>	
		  <tr>
			<th style="height: 37px">刷新设置，优先排序</th>
			<td style="height: 37px"><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td style="height: 37px"><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
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


	<div class="join">
		<h3><span class="joinnow"></span>&nbsp;</h3>
		
		<p><a href="VIPMemberRegister.aspx" target="_blank"><img src="../images/reg_step/join.gif" border="0" /></a></p>
        <div class="con">咨询热线：0755-89805558</div>
	</div>
</div>
  <!--验证前显示部分END-->  
	<div class="content_bottom"></div>
</div>
<div class="footer">
中国招商投资网有限公司 版权所有<br/>如有任何意见或建议，请惠赐E-mail至<a href="mailto::webmaster@tz888.cn">:webmaster@tz888.cn</a>
</div>
</body>
</html>
