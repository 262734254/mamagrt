<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegServiesProfessional.aspx.cs" Inherits="Register_RegServiesProfessional" %>
<%@ Register Src="Control/Header.ascx" TagName="Header" TagPrefix="uc2" %>
<%@ Register Src="../Controls/ZoneSelectControl.ascx" TagName="ZoneSelectControl"
    TagPrefix="uc3" %>
    <%@ Register Src="../Controls/ServiesControl.ascx" TagName="ServiesControl"
    TagPrefix="uc4" %>
<%@ Register Src="Control/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="../Controls/FilesUploadControl.ascx" TagName="FilesUploadControl"
    TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>填写基本信息--中介机构</title>
    <link href="../css/jiben.css" rel="stylesheet" type="text/css" />
    <style  type="text/css">
        .char input { width:60px; margin:0px;}
    </style>
    <script src="../js/jquery.js" type="text/javascript"></script>
     <script type="text/javascript">
    
    //直接跳到相应的页，不需要点下一步再去跳到相应的页,20100310修改
    function GotoType(id)
    {
        if(id=='Pro')
            window.location="RegServiesProfessional.aspx";
        if(id=='Str')
            window.location="RegServiesStruct.aspx";
        
    }
     function isOpen(id) {
              open('upload.aspx?id=' + id + '', '', 'width=300,height=100');
        }
       
      $(document).ready(function(){
 var str='<%=Request.QueryString["alt"]%>';

 if(str==1)
 {  document.getElementById("flower").style.display = "none"; document.getElementById('img').src="../"+'<%=p %>';
// $("#flower").attr("display","none");
// $("#flower").attr("style","color:Red");

 }
    
});
    </script>
</head>
<body style="font-size:12px;">
    <form id="form1" runat="server" >
   <div class="header" style=" color:Red">
	<div class="logo">
		<a href="http://www.topfo.com"><img src="http://www.topfo.com/web13/images/logo.jpg" border="0" /></a>
		<span>全球最大的招商投资融资门户</span>	</div>
	<div class="rightfont">
		<div class="nav">
		<h5><a href="http://www.topfo.com">返回首页</a> |  <a href="../login.aspx">拓富中心</a> |  <a href="http://www.topfo.com/Sys/Message.aspx">留言反馈</a>  |<a href="http://www.topfo.com/help/index.shtml">帮助中心</a></h5>
		<h6>如遇到注册问题，<a href="http://www.topfo.com/help/register.shtml">请点击这里</a></h6>
		</div>
	</div>
	<br class="clear" />
</div>
<div class="mainnav">
	<ul>
		<li>1．选择会员身份</li>
		<li class="up">2．填写基本信息</li>
		<li>3．注册成功 </li>
	</ul>
</div>
<div class="content">
	<div id="flower"  ><div class="content_top">
		<div class="clew">
			<h4>您选择的会员身份是<font color="#FF6600">专业服务人才</font>！</h4><br />  
			  注册后您可以发布政府招商需求、投资需求、融资需求、查询对口资源等。 <a href="Register.aspx">重新选择会员类型</a>	  </div>
	</div>
    
	<div class="line_text"><div class="ltxt">帐户基本信息</div>
    <div class="rtxt">以下内容全为必填项</div></div>

	<table width="742" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td class="t_title">会员类型：</td>
        <td align="left"><input name="radiobutton" id="Str" type="radio" value="radiobutton"  onclick=GotoType("Str") />
        专业服务机构　　
        <input type="radio" name="radiobutton" value="radiobutton" id="Pro"  checked="checked" onclick=GotoType("Pro") />专业服务人才(个人)</td>
      </tr>
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
		<td class="t_title">姓名：</td>
		<td align="left"><input id="contactname" name="contactname" type="text" runat="server" /></td>
	  <td align="left"><div class="commonly">必填</div></td>
	  </tr>
	  <tr>
		<td class="t_title">单位名称：</td>
		<td align="left"><input id="comname" name="comname" type="text"  runat="server"/></td>
	  <td align="left"><div class="commonly">必填</div></td>
	  </tr>
	  <tr>
	    <td class="t_title">所属地域：</td>
      <td colspan="2" align="left">
          <uc3:ZoneSelectControl ID="ZoneSelectControl1" runat="server" /></td>
      </tr>
	  <tr>
		<td class="t_title">职务：</td>
		<td align="left" style="width: 250px"><input id="contacttitle" name="contacttitle" type="text" runat="server" /></td>
		<td align="left">&nbsp;</td>
	  </tr>
	  
	  <tr>
	    <td class="t_title">人才类别：</td>
        <td align="left" style="width: 250px">
          <asp:DropDownList ID="structid" runat="server">
            </asp:DropDownList></td>
	    <td align="left">&nbsp;</td>
	  </tr>
	  <tr>
		<td valign="top" class="t_title">服务类别：</td>
		<td colspan="2"  align="left" class="char"><uc4:ServiesControl ID="ServiesControl" runat="server" /></td>
	  </tr>
	 <tr>
		<td class="t_title">个人简历：</td>
		<td align="left" style="width: 350px;">
		  <textarea name="Resume" id="Resume" rows="5" style="width:100%;" runat="server"></textarea></td>
	   <td align="left"></td>
	  </tr>
	  <tr>
		<td class="t_title">个人特长：</td>
		<td align="left" style="width: 350px"><textarea name="Specialty"  id="Specialty" rows="5" style="width:100%;" runat="server"></textarea></td>
		<td align="left"></td>
	  </tr>
	  <tr>
	    <td class="t_title">成功案例：</td>
	    <td align="left" style="width: 350px"><textarea name="BefCase" id="BefCase" rows="5" style="width:100%;" runat="server"></textarea></td>
	    <td align="left">&nbsp;</td>
      </tr>
	   <tr style="width: 550px;">
                    <td class="t_title">
                        固定电话：</td>
                    <td align="left" style="width: 250px;font-size:12px;">
                        <menu class="menulw">
                            国家</menu>
                        <menu>
                            城市区号</menu>
                        <menu class="menulw3">
                            电话号码</menu>
                        <br />
                        <input name="country" id="country" type="text" value="86" size="4" class="country" runat="server" />
                        <input name="zone" id="zone" type="text" size="7" class="area" runat="server">
                        <input name="phone" id="phone" type="text" size="18" class="phone" runat="server" />
                    </td>
                    <td align="left">
                        <div class="commonly" id="phoneinfo">
                            如果要输入多个电话号码,请使用“/”分隔，分机号码用“-”分隔。</div>
                        <span id="zoneinfo"></span>
                    </td>
                </tr>
               
	  <tr>
	    <td class="t_title">传真：</td>
	    <td align="left" style="width: 250px">
	      <input name="fax" id="fax" type="text" runat="server" />	    </td>
	    <td align="left"></td>
      </tr>
	   <tr>
                    <td class="t_title">
                        手机：</td>
                    <td align="left" style="width: 250px">
                        <input name="mobile" id="mobile" type="text"   runat="server"/>
                    </td>
                    <td align="left">
                        <div class="commonly" id="mobileinfo">
                            手机和固定电话请至少填写一项</div>
                    </td>
                </tr>
	  <tr>
	    <td class="t_title">地址：</td>
	    <td align="left" style="width: 250px"><input name="address" id="address" type="text" style="width:100%;" runat="server"></td>
	    <td align="left">&nbsp;</td>
      </tr>
	     <tr>
	    <td class="t_title">上传相片：</td>
	    <td align="left" style="width: 250px"><asp:TextBox ID="txtAds1" runat="server" Columns="30" runat="server"></asp:TextBox> 
            </td>
	    <td align="left"><input id="Button2" type="button" value="上传图片" onclick="isOpen('txtAds1')" style="width:65px;">&nbsp;</td>
      </tr> 
            <tr>
	    <td colspan="3" style="text-align:center">
          <img width="100px" height="90px" id="img" alt="" src="../img/member_bg1_on.gif" />
            
        </td>
	    
	    
      </tr>          
  </table>
	<table width="0" border="0" cellpadding="0" cellspacing="0" class="inputtable noborder">
		  <tr>
		<td class="t_title">电子邮箱：</td>
		<td align="left"><input name="email" id="email" type="text"  runat="server"/></td>
		<td align="left"><div class="commonly" id="emailinfo">请填写您最常用的邮箱，这是客户联系您的重要方式。
如果您没有邮箱，<a href="http://mail.163.com" target="_blank">注册网易邮箱</a> <a href="http://mail.yahoo.com.cn" target="_blank">注册雅虎邮箱</a></div></td>
	  </tr>
		  <tr>
                    <td class="t_title">
                        验证码：</td>
                    <td align="left">
                        <input name="vercode" id="vercode" type="text" /></td>
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
	<p align="center"><a href="#" >
	<asp:ImageButton ID="ImageButton1" ImageUrl="../images/btn_tijiao.gif" runat="server"
               OnClientClick="return chkPost()"      OnClick="ImageButton1_Click" /></a><asp:Button ID="Update" runat="server" Text="修改" OnClick="btnUpdate_Click"  /></p>
  </div>
</div>
<div class="footer">
中国招商投资网有限公司 版权所有<br/>如有任何意见或建议，请惠赐E-mail至<a href="mailto::webmaster@tz888.cn">webmaster@tz888.cn</a><div style="display:none">
<script language="javascript" type="text/javascript" src="http://js.users.51.la/2428175.js"></script>
<noscript><a href="http://www.51.la/?2428175" target="_blank"><img alt="&#x6211;&#x8981;&#x5566;&#x514D;&#x8D39;&#x7EDF;&#x8BA1;" src="http://img.users.51.la/2428175.asp" style="border:none"/></a></noscript>
</div>
</div>
    </form>
</body>
</html>

<script src="../js/commonReg.js" language="javascript" type="text/javascript"></script>
 <script language="javascript" type="text/javascript">
         function $id(obj)
        {
           return document.getElementById(obj);
        }
        function chkPost()
        {
            if($id("usrname").value==""){alert("请填写账户名称.");$id("usrname").focus();return false;}
            
            if($id("contactname").value==""){alert('请填写姓名.');$id("contactname").focus();return false;}
            if($id("comname").value==""){alert('请填写单位名称.');$id("comname").focus();return false;}
            if($id("contacttitle").value==""){alert('请填写职位.');$id("contacttitle").focus();return false;}
          
        }
         
        </script>
<script src="../js/Ajax.js" language="javascript" type="text/javascript"></script>