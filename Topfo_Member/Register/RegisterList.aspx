<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterList.aspx.cs" Inherits="Register_RegisterList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>填写基本信息--政府会员
</title>


<link href="css/common.css" rel="stylesheet" type="text/css" />
<link href="css/login.css" rel="stylesheet" type="text/css" />
<link href="../css/publish.css" rel="stylesheet" type="text/css" />
<link href="../offer/css/member.css" rel="stylesheet" type="text/css" />

<script  type ="text/javascript" language ="javascript" src="Js/commonReg.js"></script>
<script  type ="text/javascript" language ="javascript" src ="Js/Ajax.js"></script>
<script language="javascript" type ="text/javascript"  src ="Js/JScriptYanzheng.js"></script>
<script language="javascript" type="text/javascript" src="../js/jquery.js"></script>
<script  type ="text/javascript" language ="javascript" src ="Js/JSEmail.js"></script>
<script language="javascript" type ="text/javascript">

</script>
</head>
<body onload="createCode();">
<form id="tijiaoform" runat="server">
<div class="head">
  <div class="head1">
    <div class="logo"><img src="img/member_06.gif" /></div>
    <div class="cd1"> <a href="http://www.topfo.com/">返回首页</a>│<a href="http://member.topfo.com/login.aspx">扣富中心</a>│<a href="http://www.topfo.com/Sys/Message.aspx">留言反馈</a>│<a href="http://www.topfo.com/help/index.shtml">帮助中心</a> </div>
    <div class="hepe">如遇到问题，<a href="http://www.topfo.com/help/register.shtml" id="f_lan">请点击这里</a></div>
  </div>
</div>
<div class="step">
  <ul>
    <li class="step3">注册成功</li>
    <li class="step2 strong" style="background-image:url(http://img2.topfo.com/topfo/img/member_13-1.gif)"> 填写基本信息</li>
    <li class="step1" style="background-image:url(http://img2.topfo.com/topfo/img/member_11-1.gif)"> 选择会员身份</li>
  </ul>
</div>
<div class="login">
  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="zc">
    <tr>
      <td width="25%" class="zc1">
          会员帐号<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>:</td>
      <td width="75%"><label>
        <input type="text" name="textfield" onblur="VName(this,'showloginname');" onkeydown ="return checkinputloginname(this,16,'showloginname')" onkeyup="return checkinputloginname(this,16,'showloginname')"  id="txtloginName" runat="server"  class="input" />&nbsp;<div id="showloginname" style ="display:none; color:Red ; font-size:12px">请输入数字,英文字母或者下划线</div>
        <span id="LgName" style="color:Red"></span>
        </label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td class="tishi">会员登陆名由4-16个英文字母、数字、下划线组成，不区分大小写。登录名不能修改，请谨慎填写。</td>
    </tr>
    <tr>
      <td width="25%" class="zc1" style="height: 24px">密码<asp:Label ID="Label2" runat="server" ForeColor="Red" Text="*"></asp:Label>:</td>
      <td width="75%" style="height: 24px"><label>
        <input type="password" name="textfield" id="txtpassword" onblur ="outpass(this,6,'showpass')"   onkeydown ="return checkinputpass(this,20,'showpass')" onkeyup="return checkinputpass(this,20,'showpass')" runat="server"  class="input" />&nbsp;<div id="showpass" style ="display:none; color:Red ; font-size:12px">请输入数字,英文字母</div>
        </label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td class="tishi">由6-20个英文字母或数字组成</td>
    </tr>
    <tr>
      <td width="25%" class="zc1" style="height: 40px">确认密码<asp:Label ID="Label3" runat="server" ForeColor="Red" Text="*"></asp:Label>:</td>
      <td width="75%" style="height: 40px"><label>
        <input type="password" name="textfield" id="txtpassWords" onblur="outpasses('txtpassword',this,'showpasses')" onkeydown ="return checkinputpass(this,20,'showpasses')" onkeyup="return checkinputpass(this,20,'showpasses')"  runat="server"  class="input" />&nbsp;<div id="showpasses" style ="display:none; color:Red ; font-size:12px">请输入数字,英文字母</div>
        </label></td>
    </tr>
    <tr>
      <td style="height: 19px">&nbsp;</td>
      <td class="tishi" style="height: 19px">请再输入一遍您上面填写的密码</td>
    </tr>
    <tr>
      <td width="25%" class="zc1" style="height: 24px">手机:</td>
      <td width="75%" style="height: 24px"><label>
        <input type="text" name="textfield" id="txtMoblie" onblur="outphone(this,'showMoblie')"  onkeydown ="return checkinputphone(this,11,'showMoblie')" onkeyup="return checkinputphone(this,11,'showMoblie')" runat="server"  class="input" />&nbsp;<div id="showMoblie" style ="display:none; color:Red ; font-size:12px">请输入数字</div>
        </label></td>
    </tr>
    <tr>
      <td style="height: 15px">&nbsp;</td>
      <td style="height: 15px"><font color="red">手机和固定电话请至少填写一项</font></td>
    </tr>
    <tr>
      <td width="25%" class="zc1">电话:</td>
      <td width="75%"><label>
        <input type="text" name="textfield" id="txtCount" runat="server"  onblur="outTel('txtMoblie',this,'showTel')" onkeydown ="return checkinputTel('showTel')" onkeyup="return checkinputTel('showTel')"  class="input" style="width: 42px" value="86" maxlength="4" />区号<input type="text" name="textfield" id="txtStatCount" runat="server"  onblur="outTel('txtMoblie',this,'showTel')" onkeydown ="return checkinputTel('showTel')" onkeyup="return checkinputTel('showTel')"  class="input" style="width: 41px" maxlength="5"  />电话号码<input type="text" name="txtTel" id="txtTel" runat="server"  onblur="outTel('txtMoblie',this,'showTel')" onkeydown ="return checkinputTel('showTel')" onkeyup="return checkinputTel('showTel')"  class="input" style="width: 64px" maxlength="9" />如：（86-0755-82210116）&nbsp;<div id="showTel" style ="display:none; color:Red ; font-size:12px">请输入'/'或下划线或数字</div>
        </label></td>
    </tr>
    <tr>
      <td>&nbsp;</td>
      <td class="tishi">如果要输入多个电话号码,请使用“/”分隔，分机号码用“-”分隔。</td>
    </tr>
    <tr>
      <td width="25%" class="zc1">邮箱<asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*"></asp:Label>:</td>
      <td width="75%"><label>
        <input type="text" name="textfield" id="txtemail" onblur="Email();"   onkeydown="outemail(this,'showemail')" runat="server"  class="input" />&nbsp;<div id="showemail" >示例:xxx@xx.com</div>
        </label></td>
    </tr>

        <tr>
      <td width="25%" class="zc1" style="height: 39px">验证<asp:Label ID="Label5" runat="server" ForeColor="Red" Text="*"></asp:Label>:</td>
      <td width="75%" style="height: 39px"> <input  type="text"  name="txtyanzheng"  id="txtyanzheng" runat="server"  onblur ="outpostcode(this,'showyanzheng')" /> 
                   <input type="text"  onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />&nbsp;<div id="showyanzheng" style ="display:none; color:Red ; font-size:12px">*</div></td>
    </tr>          
    <tr>
      <td>&nbsp;</td>
      <td class="tishi">请填写您最常用的邮箱，这是客户联系您的重要方式。 如果您没有邮箱，注册网易邮箱 注册雅虎邮箱</td>
    </tr>
  </table>
  <p>
    <input name="" type="checkbox" value="" checked ="checked" />
    我已经同意<a href="http://www.topfo.com/Register/AgreeMent.shtml" id="A1">《中国招商投资网协议》</a> <br />
    <input name="" type="checkbox" value="" checked ="checked" />
  我愿意接收来自中国招商投资网的通知和消息（包括《中国招商投资网·电子杂志》等） </p>
  <p style="margin:20px 0 0 220px">
     <asp:ImageButton ID="imgbtnSave" width="241" height="41" CausesValidation ="true"  ImageUrl="http://img2.topfo.com/member/Img/btn-zc-tj.gif" runat="server" OnClientClick="return chkPost();return Hand('txtloginName','showloginname');" OnClick="imgbtnSave_Click" /></p>
</div>
<div class="foot">
  <p> 中国招商投资网有限公司 版权所有<br />
    如有任何意见或建议，请惠赐E-mail至<a href="mailto::webmaster@tz888.cn" id="A2">webmaster@tz888.cn</a><br />
    <img src="img/pic.gif" /></p>
</div>
</form>
</body>
</html>