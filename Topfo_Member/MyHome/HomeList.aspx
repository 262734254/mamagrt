<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeList.aspx.cs" Inherits="MyHome_HomeList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Tz888.BLL" Namespace="OurControl" TagPrefix="cc1" %>
<%@ Register Assembly="Tz888.Pager" Namespace="Tz888.Pager" TagPrefix="cc2" %>
 
 <script type="text/jscript">

 function hidd()
  {           
       var txtNumebr = document.getElementById("txtTypeSort").value;
		if(txtNumebr !="")
		{
		   var newPar=/^\d+$/ 
            if (!newPar.test(txtNumebr))
             { 
                alert("排序值只能为数字!");
			    document.getElementById("txtTypeSort").focus();
                return false;
             }
		}
		if (document.getElementById("txtType").value == "") 
		{
                alert('请输入网站类型！');
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
             
         var objWebSite = document.getElementById("txtlink").value;
		if(objWebSite !="")
		{
		    var filter =/^.*(.com|.cn|.com.cn|.org|.net)$/;	
            if (!filter.test(objWebSite))
             { 
                alert("网址填写不正确!");
			    document.getElementById("txtlink").focus();
                return false;
             }
		}
            if (document.getElementById("txtlink").value = "") {
                alert('请输入您的网址！');
                document.getElementById("txtlink").focus();
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
            if (document.getElementById("ddlType").value == "") {
                alert('您还未添加类别，不能进行添加！');
                document.getElementById("ddlType").focus();
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
<head runat="server">
    <title>中国招商投资网快捷桌面</title> 
<meta name="keywords" content="招商，投资" />
<meta name="description" content="中国招商投资网快捷桌面" />
<link href="css/gray_topfo.css" rel="stylesheet" type="text/css" />

</head>

<body>
 <form id="Fist" runat="server">
<!--鼠标触发效果JS-->
<script type="text/javascript" src="js/trigger.js"></script>
<!--邮箱登录JS-->
<script type="text/javascript" src="js/email.js"></script>

<div style="width:760px; margin:20px auto; overflow:hidden;">

<!--菜单分类切换-->
<div class="menu2">
	<ul>
		<li class="on" id="nav_btn_1" onclick="SetBtn('nav',1);">栏目分类管理</li>
		<li id="nav_btn_2" onclick="SetBtn('nav',2);" style="width:111px;">网站地址管理</li>
	</ul>
</div>

<!--栏目分类管理-->
<div class="con" id="nav_con_1">
	<!--操作说明-->
	<div class="date f_date">
		<div class="date_l">请在此自定义您的栏目分类。最多可添加/编辑/删除6个分类。</div>
		<div class="date_r"><a href="#" target="_parent">&gt;&gt;管理我的快捷桌面</a>&nbsp;&nbsp;<a href="#">&gt;&gt;默认快捷桌面</a></div>
		<div class="clear"></div>
	</div>
	<!--网址列表-->
	<table border="0" cellspacing="0" cellpadding="0" class="tab3 f_14">
      <tr>
        <td colspan="2" align="right" style="height:20px;"></td>
      </tr>
      <tr>
        <td width="30%" align="right"><span class="f_red">*</span> 分类栏目名称：</td>
        <td width="70%">
            &nbsp;<asp:TextBox ID="txtType" runat="server" CssClass="inp_set"></asp:TextBox><span style="font-size:12px; color:#999;">名称长度请控制在1-5个字符之间；</span></td>
      </tr>
      <tr>
        <td align="right" style="height: 30px">排序：</td>
        <td style="height: 30px">
            &nbsp;<asp:TextBox ID="txtTypeSort" runat="server" CssClass="inp_set" MaxLength="3"
                Width="20px">1</asp:TextBox><span style="font-size:12px; color:#999;">请输入“1-100”的数字,数值越小位置越靠前；</span></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td style=" padding:5px 0 10px 0;">
            <asp:Button ID="btnType" runat="server" class="btn4"   OnClick="btnType_Click" OnClientClick="return hidd();"   Text="提交" /></td>
            
      </tr>
    </table>
  <table border="0" cellspacing="0" cellpadding="0" class="tab1 f_14 f_line" style="margin-top:10px;">
      <tr style="background:#FFF5DF;" class="strong">
        <td align="center">分类名称</td>
        <td align="center">数量</td>
        <td align="center">排序</td>
        <td colspan="4" align="center"> 操作</td>
      </tr>
      <asp:Repeater ID="Repeater2" runat="server">
        <ItemTemplate>     
        <tr>
          <td align="center"> <%# Eval("TypeName")%></td>
          <td align="center"><%#GetAllNumber(Eval("TypeName").ToString(),Eval("LoginName").ToString())%></td>                                                             
          <td align="center"><%#Eval("sort")%></td>         
           <td align="center"> 
            <asp:LinkButton ID="lbdel" CommandArgument='<%#Eval("TID")%>' CommandName="del"  runat="server" OnCommand="LnkdelteType_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此信息?');">删除</asp:LinkButton>
          <%--  <asp:LinkButton ID="lknUpdateType" runat="server"  CommandArgument='<%# Eval("TID") %>' OnClick="lknUpdateType_Click">修改</asp:LinkButton>--%>
            <a href="UpdateHomeType.aspx?id=<%#Eval("TID")%>" target="_blank">修改</a>
            <a href="HomeDetail.aspx?Nid=<%#Eval("Tid") %>" target="_blank">查看</a>                                                          
           </td>    
        </tr>        
        </ItemTemplate>
        </asp:Repeater>
        <tr>
        <cc2:AspNetPager ID="AspNetPager2" runat="server" OnPageChanged="AspNetPager2_PageChanged" >
        </cc2:AspNetPager>
        </tr>
     
  </table>
</div>

<!--网站地址管理-->
<div class="con" id="nav_con_2" style="display:none;">
	<!--操作说明-->
	<div class="date f_date">
		<div class="date_l">请在此添加/编辑/删除您的网址，带“*”号的为必填项。</div>
		<div class="date_r"><a href="#" target="_parent">&gt;&gt;管理我的快捷桌面</a>&nbsp;&nbsp;<a href="#">&gt;&gt;默认快捷桌面</a></div>
		<div class="clear"></div>
	</div>
	<table border="0" cellspacing="0" cellpadding="0" class="tab3 f_14">
      <tr>
        <td colspan="2" align="right" style="height:20px;"></td>
      </tr>
      <tr>
        <td width="15%" align="right"><span class="f_red">*</span> 网站名称：</td>
        <td width="85%">
            <asp:TextBox ID="txtName" runat="server" CssClass="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right"><span class="f_red">*</span> 链接地址：</td>
        <td>
            <asp:TextBox ID="txtlink" runat="server" CssClass="inp_set" Width="512px"></asp:TextBox></td>
      </tr>
	  <tr>
        <td align="right"><span class="f_red">*</span> 类别：</td>
        <td>
            <asp:DropDownList ID="ddlType" runat="server" CssClass="inp_set" Width="61px">
            </asp:DropDownList></td>
      </tr>
	  <tr>
        <td align="right">网站备注：</td>
        <td>
            <asp:TextBox ID="txtDOC" runat="server" CssClass="inp_set" Width="510px"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">排序：</td>
        <td>
            &nbsp;<asp:TextBox ID="txtsorct" runat="server" CssClass="inp_set" Width="41px">1</asp:TextBox><span style="font-size:12px; color:#999;">请输入“1-100”的数字,数值越小位置越靠前；</span></td>
      </tr>
      <tr>
        <td align="right">网站帐号：</td>
        <td>
            <asp:TextBox ID="txtNumber" runat="server" CssClass="inp_set"></asp:TextBox></td>
      </tr>
      <tr>
        <td align="right">帐号密码：</td>
        <td>
            <asp:TextBox ID="txtPass" runat="server" CssClass="inp_set" TextMode="Password"></asp:TextBox><span style="font-size:12px; color:#999;">请输入您在该网站的密码,您的密码将是安全的；</span></td>
      </tr>
      <tr>
        <td align="right">状态：</td>
        <td>
            <asp:RadioButtonList ID="rdostate" runat="server" CssClass="inp_set" RepeatDirection="Horizontal"
                Width="124px">
                <asp:ListItem Selected="True">启用</asp:ListItem>
                <asp:ListItem>禁用</asp:ListItem>
            </asp:RadioButtonList></td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td style="padding:5px 0 10px 0;">
            <asp:Button Button ID="Button1" runat="server" class="btn4" OnClick="btnAdHomelist_Click" Text="添加" OnClientClick="return yjhkk();"  /></td>
      </tr>
    </table>
	<table border="0" cellspacing="0" cellpadding="0" class="tab1 f_14 f_line" style="margin-top:10px;">
      <tr>
        <td colspan="7" align="right">&gt;&gt;<a href="ListExcel.aspx" target="_blank" >导出网址</a>&nbsp;&nbsp;</td>
      </tr>
      <tr style="background:#FFF5DF;" class="strong">
        <td align="center">网站名称</td>
        <td align="center">地址</td>
        <td align="center">类别</td>
        <td align="center">创建时间</td>
        <td align="center">排序</td>
        <td align="center" >操作</td>
      </tr>
            <asp:Repeater ID="Repeater1" runat="server" EnableViewState="True" EnableTheming="True" Visible="True">
        <ItemTemplate>
        <tr>
          <td align="center"><%#GetTitle(Eval("LName").ToString(),10)%></td>
       
          <td align="center"><a href="http://<%#Eval("Linkwww")%> " target="_blank"><%#GetTitle(Eval("Linkwww").ToString(),100)%></a></td>
          <td align="center"><%#ShowUserName(Eval("nid").ToString())%></td>
          <td align="center"><%#Eval("CreateTimes","{0:yyyy-MM-dd}")%></td>
          <td align="center" ><%# Eval("WSort") %>  </td>
           <td align="center">
           <asp:LinkButton ID="lbdelHome" CommandArgument='<%#Eval("LID")%>' CommandName="del"  runat="server" OnCommand="LinkButton1_Command" ToolTip="删除本条记录" OnClientClick="return confirm('确认删除此文件?');">删除</asp:LinkButton>
      <%--   <asp:LinkButton ID="lbDetail" runat="server" CommandArgument='<%# Eval("LID") %>' onclick="lkUpdate_Click">修改</asp:LinkButton>--%>
       <a href="UpdateMyHome.aspx?id=<%#Eval("LID")%>" target="_blank">修改</a>
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
</div>
 </form>
</body>
</html>

