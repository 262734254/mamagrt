<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegServiesStruct.aspx.cs" Inherits="Register_RegServiesStruct" %>

<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc3" %>
    <%@ Register Src="../Controls/ServiesControl.ascx" TagName="ServiesControl"
    TagPrefix="uc4" %>
<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>填写基本信息--中介机构</title>
    <link href="../css/jiben.css" rel="stylesheet" type="text/css" />
        <script src="../js/jquery.js" type="text/javascript"></script>
    <style  type="text/css">
        .char input { width:60px; margin:0px;}
    </style>
    <script language="javascript" type="text/javascript">
     
    //直接跳到相应的页，不需要点下一步再去跳到相应的页,20100310修改
    function GotoType(id)
    {
        if(id=='Pro')
            window.location="RegServiesProfessional.aspx";
        if(id=='Str')
            window.location="RegServiesStruct.aspx";
        
    }
       $(document).ready(function(){
 var str='<%=Request.QueryString["alt"]%>';

 if(str==1)
 {  document.getElementById("flower").style.display = "none"; 

 }   
});
    </script>

</head>
<body>
    <form id="form1" runat="server">
      <uc2:Header ID="Header1" runat="server" />
<div class="mainnav">
	<ul>
		<li>1．选择会员身份</li>
		<li class="up">2．填写基本信息</li>
		<li>3．注册成功 </li>
	</ul>
</div>
<div class="content">
<div id="flower">
	<div class="content_top">
		<div class="clew">
			<h4>您选择的会员身份是<font color="#FF6600">专业服务机构</font>！</h4><br />  
			  注册后您可以发布政府招商需求、投资需求、融资需求、查询对口资源等。 <a href="Register.aspx">重新选择会员类型</a>	  </div>
	</div>
	<div class="line_text"><div class="ltxt">帐户基本信息</div>
    <div class="rtxt">以下内容全为必填项</div></div>
	<table border="0" cellspacing="0" cellpadding="0" width="742" align="center">
      <tbody>
         <tr>
        <td class="t_title">会员类型：</td>
        <td align="left"><input name="radiobutton" id="Str" type="radio" value="radiobutton" checked="checked" onclick=GotoType("Str") />
        专业服务机构　　
        <input type="radio" name="radiobutton" value="radiobutton" id="Pro"   onclick=GotoType("Pro") />专业服务人才(个人)</td>
      </tr>
      </tbody>
  </table>
	<table width="0" border="0" cellpadding="0" cellspacing="0" class="inputtable">
	  <tr>
		<td class="t_title">帐户名称：</td>
		<td align="left"><input name="usrname" maxlength="16" id="usrname" type="text" runat="server" /></td>
		<td align="left"><div class="commonly" id="nameinfo">
        会员登陆名由4-16个英文字母、数字、下划线组成，不区分大小写。登录名不能修改，请谨慎填写。</div></td>
	  </tr>
	  <tr>
		<td class="t_title">密码：</td>
		<td align="left"><input name="pwd" id="pwd" type="password" /></td>
		<td align="left"><div class="commonly" id="pwdinfo">由6-20个英文字母或数字组成</div></td>
	  </tr>
	  <tr>
		<td class="t_title">重复输入密码：</td>
		<td align="left"><input name="repwd" id="repwd" type="password" /></td>
		<td align="left"><div class="commonly" id="repwdinfo">请再输入一遍您上面填写的密码</div></td>
	  </tr>
  </table></div>
	<div class="line_text">
	  <div class="ltxt">专业服务信息</div>
	  <div class="rtxt">手机和固定电话请至少填写一项</div></div>
	<table width="0" border="0" cellpadding="0" cellspacing="0" class="inputtable noborder">
	<tr>
		<td align="right" class="t_title">单位名称：</td>
		<td align="left"><input name="company" id="company" type="text" runat="server" /></td>
	  <td align="left"><div class="commonly">必填，请填写企业完整名称。</div></td>
	  </tr>
	  <tr>
	    <td class="t_title">所属地域：</td>
      <td colspan="2" align="left">
          
		 <uc3:ZoneSelectControl ID="ZoneSelectControl1" runat="server" /></td>
      </tr>
	  <tr>
		<td class="t_title">机构类别：</td>
		<td align="left" style="width: 250px"> <asp:DropDownList ID="structid" runat="server">
            </asp:DropDownList></td>
		<td align="left">&nbsp;</td>
	  </tr>
	  <tr>
		<td valign="top" class="t_title">服务类别：</td>
		<td align="left" colspan="2" class="char"><uc4:ServiesControl ID="ServiesControl" runat="server" /></td>
	  </tr>
	 <tr>
		<td class="t_title">企业规模：</td>
		<td align="left" style="width: 250px;">
          <input id="scale"  name="scale" type="text" runat="server"></td>
	   <td align="left">人</td>
	  </tr>
	  <tr>
		<td class="t_title">注册资金：</td>
		<td align="left" style="width: 250px"><input name="capital" type="text" id="capital" style="width:150px;" runat="server">
		  <select name="select8" style="width:80px;">
            <option>万元</option>
          </select></td>
		<td align="left"></td>
	  </tr>
	  <tr>
	    <td class="t_title">创建时间：</td>
	    <td align="left" style="width: 250px">
	      <input id="createdate" name="createdate" type="text" runat="server">
	    </td>
	    <td align="left">年</td>
      </tr>
	  <tr>
	    <td class="t_title">营业额：</td>
	    <td align="left" style="width: 250px"><input name="count" type="text" id="count" size="15" style="width:150px;" runat="server">
          <select name="select6" style="width:80px;">
            <option>万元</option>
          </select></td>
	    <td align="left">&nbsp;</td>
      </tr>
	  <tr>
	    <td valign="top" class="t_title">主营业务说明：</td>
	    <td align="left" colspan="2"><textarea id="directions" name="directions" rows="5" style="width:70%;" runat="server"></textarea></td>
      </tr>
	  <tr>
	    <td class="t_title">网址：</td>
	    <td align="left" style="width: 250px"><span style="width: 250px;">
	      <input id="website" name="website" type="text" runat="server">
	    </span></td>
	    <td align="left">&nbsp;</td>
      </tr>
	  <tr>
	    <td class="t_title">联系人：</td>
	    <td align="left" style="width: 250px"><span style="width: 250px;">
	      <input id="linkman" name="linkman" type="text"  runat="server"/>
	    </span></td>
	    <td align="left"><div class="commonly">必填</div></td>
      </tr>
	  <tr>
	    <td class="t_title">联系电话：</td>
	    <td align="left" style="width: 250px"><span style="width: 250px;">
	      <input id="linktel"  name="linktel" type="text" runat="server" />
	    </span></td>
	    <td align="left"><div class="commonly">必填</div></td>
      </tr>
	  <tr>
	    <td class="t_title">传真号码：</td>
	    <td align="left" style="width: 250px"><span style="width: 250px;">
	      <input id="fex" name="fex" type="text"  runat="server"/>
	    </span></td>
	    <td align="left">&nbsp;</td>
      </tr>
  </table>
	<table width="0" border="0" cellpadding="0" cellspacing="0" class="inputtable noborder">
		  <tr>
		<td class="t_title">电子邮箱：</td>
		<td align="left"><input name="email" id="email" type="text" runat="server"/></td>
		<td align="left"><div class="commonly" id="emailinfo">请填写您最常用的邮箱，这是客户联系您的重要方式。

如果您没有邮箱，<a href="http://mail.163.com" target="_blank">注册网易邮箱</a> <a href="http://mail.yahoo.com.cn" target="_blank">注册雅虎邮箱</a></div></td>
	  </tr>
		  <tr>
                    <td class="t_title">
                        验证码：</td>
                    <td align="left">
                        <input name="vercode" id="vercode" type="text"  /></td>
                    <td align="left">
                        <div class="commonly">
                            验证码不区分大小写<br />
                            <img src="../ValidateNumber.aspx" width="73" height="25" align="middle" id="validimg" />
                            <a href="javascript:" onclick="ChangeValidCode('validimg');return false;">换一张图片</a><span
                                style="padding-right: 1px" id="vercodeinfo"></span></div>
                    </td>
                </tr>
  </table>
  <div class="submit">  <p align="left"><input name="checkbox" checked type="checkbox" id="protocal" value="checkbox"/>
	我已阅读并同意<a href="http://www.topfo.com/Register/AgreeMent.shtml" target="_blank">《中国招商投资网服务协议》</a><span id="protocalinfo"></span></p>
	
	<p align="left"><input name="checkbox" type="checkbox" value="checkbox" checked="checked" />
	我愿意接收来自中国招商投资网的通知和消息（包括《中国招商投资网·电子杂志》等）</p>
	<p align="center"><asp:ImageButton ID="ImageButton1" ImageUrl="../images/btn_tijiao.gif" runat="server"
                    OnClick="ImageButton1_Click" OnClientClick="return chkPost()" />
                    </p><asp:Button ID="Update" runat="server" Text="修改" OnClick="btnUpdate_Click" />
  </div>
</div>
<uc1:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
         function $id(obj)
        {
           return document.getElementById(obj);
        }
        function chkPost()
        {
            if($id("usrname").value==""){alert("请填写账户名称.");$id("usrname").focus();return false;}
            if($id("pwd").value==""){alert("请填写密码.");$id("pwd").focus();return false;}
            if($id("repwd").value !=$id("pwd").value)
            {
               alert("两次密码输入不一致");
               $id("repwd").focus();
               return false;
            }
            if(($id("zone").value=="" & $id("phone").value=="") & $id("mobile").value=="" )
            {
                alert("手机和固定电话请至少填写一项");
                 $id("mobile").focus();
                return false;
            }
            if($id("email").value=="")
            {
            alert('请填写电子邮箱.');
            $id("email").focus();
            return false;
            }else
            {
               var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
               if(!filter.test($id("email").value))
               {
                 alert("电子邮件格式不正确，请输入正确的电子邮件地址！");
                 $id("email").focus();
                 return false;
               }
            }
            if($id("vercode").value==""){alert('请填写验证码.');$id("vercode").focus();return false;}
           
         
        }
         
        </script>
<script src="../js/commonReg.js" language="javascript" type="text/javascript"></script>

<script src="../js/Ajax.js" language="javascript" type="text/javascript"></script>