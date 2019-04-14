<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateMyHome.aspx.cs" Inherits="MyHome_UpdateMyHome" %>
 <script type="text/jscript">
 function hidd1(){
 if (document.getElementById("txtType").value = "") {
                alert('请输入您网站类型！');
                document.getElementById("txtType").focus();
                return false;
            }
 }

        function yjhkk() {           
          var txtNumebr = document.getElementById("txtsorct").value;
		if(txtNumebr !="")
		{
		   var newPar=/^\d+$/ 
            if (!newPar.test(txtNumebr))
             { 
                alert("排序值只能为数字!");
			    document.getElementById("txtsorct").focus();
                return false;
             }
		}
             
         var objWebSite = document.getElementById("txtWan").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("网址填写不正确!");
			    document.getElementById("txtWan").focus();
                return false;
             }
		}
            if (document.getElementById("txtURL").value = "") {
                alert('请输入您的网址！');
                document.getElementById("txtURL").focus();
                return false;
            }
            if (document.getElementById("txtName").value == "") {
                alert('请输入网站名称！');
                document.getElementById("txtName").focus();
                return false;
            }
            
              if (document.getElementById("txtDOC").value == "") {
                alert('请输入网站备注！');
                document.getElementById("txtDOC").focus();
                return false;
            }
              if (document.getElementById("txtsorct").value == "") {
                alert('请输入排序值！');
                document.getElementById("txtsorct").focus();
                return false;
            }
              if (document.getElementById("txtNumber").value == "") {
                alert('请输入网站帐号！');
                document.getElementById("txtNumber").focus();
                return false;
            }
              if (document.getElementById("txtPass").value == "") {
                alert('请输入网站密码！');
                document.getElementById("txtPass").focus();
                return false;
            }

        }
    </script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>中国招商投资网快捷桌面</title>
<meta name="keywords" content="招商，投资" />
<meta name="description" content="中国招商投资网快捷桌面" />
<link href="css/gray_topfo.css" rel="stylesheet" type="text/css" />
<%--<base target="_blank">--%>
</head>
 
<body>
<form id="form1" runat="server">
<!--鼠标触发效果JS-->
<script type="text/javascript" src="js/trigger.js"></script>
<!--邮箱登录JS-->
<script type="text/javascript" src="js/email.js"></script>
 
<div style="width:760px; margin:20px auto; overflow:hidden;">
 
<!--菜单分类切换-->
<div class="menu2">
	<ul>
		<li><a href="#" target="_parent">栏目分类管理</a></li>
		<li class="on" style="width:111px;">网站地址管理</li>
	</ul>
</div>
 
<!--网址分类管理-->
<div class="con">
	<!--操作说明-->
	<div class="date f_date">
		<div class="date_l">请在此编辑您的网址，带“*”号的为必填项。</div>
		<div class="date_r"><a href="#" target="_parent">&gt;&gt;管理我的快捷桌面</a>&nbsp;&nbsp;<a href="#">&gt;&gt;默认快捷桌面</a></div>
		<div class="clear"></div>
	</div>
	<table border="0" cellspacing="0" cellpadding="0" class="tab3 f_14">
      <tr>
        <td colspan="2" align="right" style="height:20px;"></td>
      </tr>
      <tr>
        <td width="15%" align="right" style="height: 30px"><span class="f_red">*</span> 网站名称：</td>
        <td width="85%" style="height: 30px">
            <asp:TextBox ID="txtName" runat="server" class="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right" style="height: 30px"><span class="f_red">*</span> 链接地址：</td>
        <td style="height: 30px">
            <asp:TextBox ID="txtWan" runat="server" Width="516px" class="inp_set"></asp:TextBox></td>
      </tr>
	  <tr>
        <td align="right"><span class="f_red">*</span> 类别：</td>
        <td> <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList></td>
      </tr>
	  <tr>
        <td align="right">网站备注：</td>
        <td>
            <asp:TextBox ID="txtDOC" runat="server" Width="516px" class="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">排序：</td>
        <td>
            &nbsp;<asp:TextBox ID="txtsorct" runat="server" Width="49px" class="inp_set"></asp:TextBox><span style="font-size:12px; color:#999;">请输入“1-100”的数字,数值越小位置越靠前；</span></td>
      </tr>
      <tr>
        <td align="right">网站帐号：</td>
        <td>
            <asp:TextBox ID="txtNumber" runat="server" class="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">帐号密码：</td>
        <td>
            &nbsp;<asp:TextBox ID="txtPass" runat="server" class="inp_set"></asp:TextBox><span style="font-size:12px; color:#999;">请输入您在该网站的密码,您的密码将是安全的；</span></td>
      </tr>
      <tr>
        <td align="right">状态：</td>
        <td>
            <asp:RadioButton ID="rdostar" runat="server" class="inputs" GroupName="a" Text="启用" />
            &nbsp;<asp:RadioButton ID="rdostop" runat="server" class="inputs" GroupName="a" Text="禁用" />
        </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td style="padding:5px 0 10px 0;">
            <asp:Button ID="btnUpdate" runat="server" OnClick="Button1_Click" class="btn4" Text="修改"  OnClientClick="return yjhkk();" /></td>
      </tr>
    </table>
</div>
 
</div>
 </form>
</body>
</html>
 
