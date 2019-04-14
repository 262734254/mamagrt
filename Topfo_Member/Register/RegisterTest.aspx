<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterTest.aspx.cs" Inherits="Register_TegisterTest" %>

<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>用户注册首页
</title>
<link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/login.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    
    function GotoType(id)
    {
        if(id=='GOV')
            window.location="RegisterList.aspx?str="+id;
        if(id=='PRO')
            window.location="RegisterList.aspx?str="+id;
        if(id=='INV')
            window.location="RegisterList.aspx?str="+id;
        if(id=='SER')
            window.location="RegisterList.aspx?str="+id;
        if(id=='SEROWNER')
            window.location="RegisterList.aspx?str="+id;
        if(id=='INT')
            window.location="RegisterList.aspx?str="+id;
    }
    </script>

</head>
<body>
<div class="head">
  <div class="head1">
    <div class="logo"><img src="http://img2.topfo.com/topfo/img/logo.gif" /></div>
    <div class="cd1"> <a href="http://www.topfo.com/">返回首页</a>│<a href="http://member.topfo.com/login.aspx">扣富中心</a>│<a href="http://www.topfo.com/Sys/Message.aspx">留言反馈</a>│<a href="http://www.topfo.com/help/index.shtml">帮助中心</a> </div>
    <div class="hepe">如遇到问题，<a href="http://www.topfo.com/help/register.shtml" id="f_lan">请点击这里</a></div>
  </div>
</div>
<div class="step">
  <ul>
    <li class="step3">注册成功</li>
    <li class="step2"> 填写基本信息</li>
    <li class="step1 strong"> 选择会员身份</li>
  </ul>
</div>
<div class="separated"> </div>
<div class="note"></div>
<div class="content">
  <h1>请根据您的身份慎重选择，这将影响到您注册后的诸多操作！</h1>
  <div class="content-1">
    <div class="j1"></div>
    <ul>
      <li> <span class=" list-1"><img src="http://img2.topfo.com/member/img/member_32.gif" /></span><span class=" list-2"> <input type="radio" id="GOV"  onclick="GotoType(this.id)"; checked="checked" name="radiobutton" value="radiobutton" /></span> <span class=" list-3">政府招商机构</span><span class=" list-4">适用于需要招商的政府职能部门，包括招商局外经局、开发区、科技园、工业区、产业基地、保税区等机构</span> </li>
      <li> <span class=" list-1"><img src="http://img2.topfo.com/member/img/member_40.gif" /></span><span class=" list-2"> <input type="radio" id="PRO"  onclick="GotoType(this.id)"; name="radiobutton" value="radiobutton" /></span> <span class=" list-3">项 目 方</span><span class=" list-4">适用于需要融资的各企事业单位、社会团体、商会协会以及个人创业群体等</span> </li>
      <li> <span class=" list-1"><img src="http://img2.topfo.com/member/img/member_46.gif" /></span><span class=" list-2"> <input type="radio" id="INV" onclick="GotoType(this.id)"; name="radiobutton" value="radiobutton" /></span> <span class=" list-3">投 资 方</span><span class=" list-4">适用于风险投资机构、投资基金、投资中介以及有投资需求的企业或个人投资者 </span> </li>
      <li> <span class=" list-1"><img src="http://img2.topfo.com/member/img/member_48.gif" /></span><span class=" list-2"> <input type="radio" id="SER"  onclick="GotoType(this.id)"; name="radiobutton" value="radiobutton" /></span> <span class=" list-3">专业服务机构</span><span class=" list-4">适用于各类资本运作专业机构与个人,如:会计师事务所\律师事务所\上市辅导咨询等</span> </li>
      <li> <span class=" list-1"><img src="http://img2.topfo.com/member/img/member_51.gif" /></span><span class=" list-2"> <input type="radio" id="SEROWNER" onclick="GotoType(this.id)"; name="radiobutton" value="radiobutton" /></span> <span class=" list-3">专业服务人才(个人)</span><span class=" list-4">适用于各类资本运作专业机构与个人,如:会计师事务所\律师事务所\上市辅导咨询等</span> </li>
      <li> <span class=" list-1"><img src="http://img2.topfo.com/member/img/member_53.gif" /></span><span class=" list-2"> <input type="radio" id="INT"  onclick="GotoType(this.id)"; name="radiobutton" value="radiobutton" /></span> <span class=" list-3">中介机构</span><span class=" list-4">适用于各类招商、投资、融资的中介机构</span> </li>
    </ul>
    <div class="j2"></div>
  </div>
</div>
<div class="foot">
  <p> 中国招商投资网有限公司 版权所有<br />
    如有任何意见或建议，请惠赐E-mail至<a href="mailto::webmaster@tz888.cn" id="A1">webmaster@tz888.cn</a><br />
 <script src="http://s16.cnzz.com/stat.php?id=2629166&web_id=2629166&show=pic" language="JavaScript"></script></p>
</div>
</body>
</html>

