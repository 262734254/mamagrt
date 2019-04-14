<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeDetail.aspx.cs" Inherits="MyHome_Default" %>

<<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Tz888.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc2" %>
 
 <script type="text/jscript">
  function hidd(a,b){
   
      var  a=document.getElementById(a);
      var more_section=document.getElementById(b)
  
            if (a.style.display=="block"){
                a.style.display="none";
    more_section.innerText='添加主页信息';
    
            } else {
                a.style.display="block";
    more_section.innerText='隐藏主页信息';
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
             
         var objWebSite = document.getElementById("txtURL").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("网址填写不正确!");
			    document.getElementById("txtURL").focus();
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
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>中国招商投资网快捷桌面</title>
<meta name="keywords" content="招商，投资" />
<meta name="description" content="中国招商投资网快捷桌面" />
<%--<base target="_blank"/>--%>
<link href="css/yellow.css" rel="stylesheet" type="text/css" />
</head>

<body>
 <form id="form1" runat="server">
<!--鼠标触发效果JS-->
<script type="text/javascript" src="js/trigger.js"></script>
<!--邮箱登录JS-->
<script type="text/javascript" src="js/email.js"></script>

<!--Top部分-->
<div class="logo">
	<div class="logo_r">
		<div class="inl">
			<ul>
				<%--<li class="n1"><a href="#">帮助中心</a></li>
				<li class="n2"><a href="#">登录</a></li>
				<li class="n3"><a href="#">用户注册</a></li>
				<li class="n4"><a href="#">首页</a></li>--%>
			</ul>
			<div class="clear"></div>
		</div>
		<div class="clear"></div>
		<div class="log">
			<%--用户名：<input type="text" name="textfield2" class="inp_lo">
			密码：<input type="password" name="textfield2" class="inp_lo">
			<input type="submit" name="Submit2" value="" class="btn1">--%>
	    </div>
	</div>
	<div class="clear"></div>
</div>

<!--菜单分类切换-->
<div class="menu2 f_14">
	<ul>
		<li id="nav_btn_2" onclick="SetBtn('nav',2);">网站地址管理</li>
	</ul>
</div>
<!--网站地址管理-->
<div class="con" id="nav_con_2" >
	<!--操作说明-->
	<div class="date f_date" style="padding:40px 0 5px 0;">
<%--		<div class="date_l"><span class="f_red strong">[本拉登]</span>欢迎您来到拓富快捷桌面管理中心！</div>--%>
		<div class="clear"></div>
	</div>

	<table border="0" cellspacing="0" cellpadding="0" class="tab1 f_14 f_line" style="margin-top:10px;">
      <tr>
        <td colspan="8" align="center" class="strong"  bgcolor="#FFFFFF">类别信息</td>
      </tr>
      <tr align="center" style="background:#FFF5DF;" class="strong">
        <td align="center" style="width: 167px; height: 30px;">网站名称</td>
        <td align="center" style="width: 133px; height: 30px;">地址</td>
        <td align="center" style="width: 137px; height: 30px;">类别</td>
        <td  align="center"style="width: 137px; height: 30px;">创建时间</td>
        <td align="center" style="width: 169px; height: 30px;">排序</td>
        <td  align="center"colspan="3" style="height: 30px">操作</td>
      </tr>
      <asp:Repeater ID="Repeater1" runat="server" EnableViewState="True" EnableTheming="True" Visible="True">
        <ItemTemplate>
        <tr>
          <td align="center" ><%#GetTitle(Eval("LName").ToString(),10)%></td>
       
          <td align="center"><a href="http://<%#Eval("Linkwww")%> " target="_blank"><%#GetTitle(Eval("Linkwww").ToString(),50)%></a></td>
        <td align="center"><%#ShowUserName(Eval("nid").ToString())%></td>
          <td align="center"><%#Eval("CreateTimes","{0:yyyy-MM-dd}")%></td>
          <td align="center"><%# Eval("WSort") %>  </td>
           <td align="center">
           <asp:LinkButton ID="lbdelHome" CommandArgument='<%#Eval("LID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
         <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("LID") %>' onclick="lkUpdate_Click" target="_blank">修改</asp:LinkButton>
           </td>
        </tr>
        </ItemTemplate>
        </asp:Repeater>
        <tr>
        <cc2:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged" >
    </cc2:AspNetPager>
    </tr>
    </table>
</div>

<!--Bottom部分-->
<div class="con">
	<div class="link"><a href="#">关于我们</a> - <a href="#">联系我们</a> - <a href="#">我们的服务</a> - <a href="#">支付方式</a> - <a href="#">广告服务</a> - <a href="#">服务条款</a> - <a href="#">网站地图</a> - <a href="#">诚聘英才</a> - <a href="#">留言反馈</a> - <a href="#">友情链接</a></div>
	<div class="copy">
		Copyright &copy; 1998-2010 <a href="http://www.topfo.com/">www.investguide.cn</a> All Rights Reserved<br>
		拓富网络：中国招商投资网 英文站 专业服务网 互告网 贤泽投资　支持合作：联合国工业发发展组织中国投资促进会 唯一授权合作网站<br>
		经营许可证编号：粤B2-20040428  ICP编号：粤B2-19981001<br>
		客服热线:0755-82210116
	</div>
</div>
</form>
</body>
</html>