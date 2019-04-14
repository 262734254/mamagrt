<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateHomeType.aspx.cs" Inherits="MyHome_UpdateHomeType" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/jscript">
        function yjhkk() {           
          var txtNumebr = document.getElementById("txtScort").value;
		if(txtNumebr !="")
		{
		   var newPar=/^\d+$/ 
            if (!newPar.test(txtNumebr))
             { 
                alert("排序值只能为数字!");
			    document.getElementById("txtScort").focus();
                return false;
             }
		}
             	
        }
    </script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>中国招商投资网快捷桌面</title>
<meta name="keywords" content="招商，投资" />
<meta name="description" content="中国招商投资网快捷桌面" />
<link href="css/gray_topfo.css" rel="stylesheet" type="text/css" />
<%--<base target="_blank">--%>
</head>
 
<body >
<form id="form1" runat="server">
<!--鼠标触发效果JS-->
<script type="text/javascript" src="js/trigger.js"></script>
<!--邮箱登录JS-->
<script type="text/javascript" src="js/email.js"></script>
 
<div style="width:760px; margin:20px auto; overflow:hidden;">
 
<!--菜单分类切换-->
<div class="menu2">
	<ul>
		<li class="on">栏目分类管理</li>
		<li style="width:111px;"><a href="#" target="_parent">网站地址管理</a></li>
	</ul>
</div>
 
<!--栏目分类管理-->
<div class="con">
	<!--操作说明-->
	<div class="date f_date">
		<div class="date_l">请在此编辑您的栏目名称，带“*”号的为必填项。</div>
		<div class="date_r"><a href="#" target="_parent">&gt;&gt;管理我的快捷桌面</a>&nbsp;&nbsp;<a href="#">&gt;&gt;默认快捷桌面</a></div>
		<div class="clear"></div>
	</div>
	<table border="0" cellspacing="0" cellpadding="0" class="tab3 f_14">
      <tr>
        <td colspan="2" align="right" style="height:20px;"></td>
      </tr>
      <tr>
        <td width="30%" align="right"><span class="f_red">*</span> 分类栏目名称：</td>
        <td width="70%">
            &nbsp;<asp:DropDownList ID="ddlType" runat="server">
            </asp:DropDownList><span style="font-size:12px; color:#999;">名称长度请控制在1-5个字符之间；</span></td>
      </tr>
      <tr>
        <td align="right">排序：</td>
        <td>
            &nbsp;<asp:TextBox ID="txtScort" runat="server" Width="42px"></asp:TextBox><span style="font-size:12px; color:#999;">请输入“1-100”的数字,数值越小位置越靠前；</span></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td style="padding:5px 0 10px 0;">
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" OnClientClick="return yjhkk();"  class="btn4" Text="修改" /></td>
      </tr>
    </table>
</div>
 
</div>
 </form>
</body>
</html>
 
