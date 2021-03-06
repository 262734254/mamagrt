﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidSuccessGov.aspx.cs" Inherits="Register_ValidSuccessGov" %>

<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>注册成功</title>
    <link href="../css/regstep.css" rel="stylesheet" type="text/css" />
   <%-- <script type="text/javascript" language="javascript">
    function go()
    {
      var cc= document.getElementById("showId").value;
      this.location.href='/indexTof.aspx?cid=1&name='+cc;
    }
    </script>--%>

</head>
<body>
    <uc2:Header ID="Header1" runat="server" />


<div class="mainnav">
	<ul>
		<li>1．选择会员类型</li>
		<li>2．填写基本信息</li>
		<li class="up">3．注册成功 </li>
		</ul>
</div>

<form id="Form1" runat="server" >
<div class="content">
	<div class="content_top">
	
	<input type="hidden" id="showId" runat="server" name="showId" />
		<div class="clew_step4" style="display:none" id="divvalid" runat="server">
			<h4>恭喜,您的E-Mail验证成功</h4>	
			<h5>找资金，寻项目，成功尽在中国招商投资网！</h5>		
	    </div>
	
	    <div class="leftbgset4" id="divreg" runat="server">
	        <h4 class="fontcss">
                注册成功，恭喜您<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>成为中国招商投资网会员！</h4>	
	        <p style="margin:0;padding:0;font-size:14px;">建议您立即进行E-mail验证，以确保您的账户更加安全，规避业务风险！</p>
	        <h3 class="linkcss"><a href="#" id="hpvalidurl" runat="server">立即验证</a></h3>
	        <div class="clear"></div>
	    </div>
	    
<%--</form>	 --%>
	</div>
	<div style="clear: both; FONT-SIZE: 1px; OVERFLOW: hidden; HEIGHT: 6px"></div>
<!--验证成功显示部分START-->  
	<div class="bigclew clewbg" id="divafter" runat="server">
		<p>您现在可以：</p>
        
	
	   <h4><a href="#">进入会员中心</a>，体验我们为您提供的贴心服务！</h4>
		<h4><a href="http://www.topfo.com/help/index.shtml">了解拓富通服务</a> ，成为贵宾会员，享受更多特权，彰显尊贵身份！</h4>
		<h4><a href="http://www.topfo.com/">进入网站首页</a> ，在资本世界中徜徉！</h4>
		<h4><a href="http://bbs.topfo.com"> 进入拓富论坛</a> ，结识行业人士，交流生意经！</h4>
		<h5 style="font-size:15px">找资本 寻项目 尽在拓富&middot;中国招商投资网！</h5>
	</div>
<!--验证成功显示部分END-->  
<!--验证成功前显示部分START-->  
	<div id="divahead" runat="server">
	<div class="bigclew clewbg">
		<p>您现在即可享受以下服务：</p>
		<h4><a href="#">  登记招商机构</a> ，全面展示您的实力和优势！</h4>
		<h4><a href="#">发布招商需求</a> ，进入资源智能匹配系统，让投资方和项目单位主动找到您！</h4>
		<h4><a href="http://zycs.topfo.com/">查找对口资源</a> ，主动联系对口对象，提高招商效率！</h4>
		<h4><a href="http://bbs.topfo.com"> 进入拓富论坛</a> ，结识行业人士，交流生意经！</h4>
		<%--<h5><a href="/indexTof.aspx"><img src="../images/reg_step/topfocenter.gif" border="0" /></a></h5>--%>
		<%--<h5><a href="#" onclick="go()"><img  src="../images/reg_step/topfocenter.gif" border="0" /></a></h5>--%>
		<h5><asp:LinkButton runat="server" ID="lbltn" OnClick="lbltn_Click"><img  src="../images/reg_step/topfocenter.gif" border="0" /></asp:LinkButton></h5>
	</div>
	<div class="bigclew">
	<p>升级拓富通会员，享受更多特权，彰显尊贵身份！</p>
	<h3>拓富通会员专享特权:</h3>
	<table width="0" cellpadding="0" cellspacing="0" class="franchisetable">
		<thead>
		 <tr>
			<td style="width: 253px">功能</td>
			<td style="width: 223px">拓富通会员</td>
			<td>普通会员</td>
		  </tr>
		</thead>	
		  <tr>
			<th style="width: 253px">刷新设置，优先排序</th>
			<td style="width: 223px"><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th style="width: 253px">身份认证，潜在客户更信任</th>
			<td style="width: 223px"><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th style="width: 253px">网上展厅（暂不对个人会员开放）</th>
			<td style="width: 223px"><img src="../images/reg_step/right.gif" width="19" height="16" />功能强大</td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" />仅有基础功能</td>
		  </tr>
		  <tr>
			<th style="width: 253px">VIP价格享受所有收费服务，超值回报</th>
			<td style="width: 223px"><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th style="width: 253px">定向推广</th>
			<td style="width: 223px"><img src="../images/reg_step/right.gif" width="19" height="16" />享受一定额度的定向推广服务</td>
			<td><img src="../images/reg_step/no.gif" width="12" height="12" /></td>
		  </tr>
		  <tr>
			<th style="width: 253px">定制资源 抢占先机</th>
			<td style="width: 223px"><img src="../images/reg_step/right.gif" width="19" height="16" /></td>
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
  
<!--验证成功前显示部分END-->  
	<div class="content_bottom"></div>
</div>
</form>
    <uc1:Footer ID="Footer1" runat="server" />
</body>
</html>
