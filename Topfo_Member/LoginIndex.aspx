<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginIndex.aspx.cs" Inherits="LoginIndex" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style>
		.login{ background:url(/web13/images/home/bg_login.gif) no-repeat 0 0;height:108px;font-size:12px;font-family:"宋体"}
.login h3{font-size:14px;color:#ff6600;font-weight:bold; text-align:center;padding:10px 0px 6px 0px;}
.login h3 span{margin:0px 6px;}
.login h3 img{ position:relative;top:2px;}
.login .inputbox{_height:0;zoom:1;margin:0 0 0 16px}
.login .inputbox div{width:84px;float:left;text-align:center;line-height:32px;}
.login .inputbox div img{margin-bottom:4px;}
.login .inputbox div input{width:84px;}


.login .inputbox ul{margin-top:8px;}
.login .inputbox li.li01{width:50px;float:left;}
.login .inputbox li.li01 img{ border:1px solid #cccccc;}
.login .inputbox li.li02{float:left;width:230px;}
.login .inputbox li.li02 a{margin-right:6px;}

.login img a{border:0px;}
		</style>
		 <link href="css/load.css" rel="stylesheet" type="text/css" />
		<link href="http://www.topfo.com/web13/css/home.css" rel="stylesheet" type="text/css">	
		    <script src="javascript/OPCookie.js"></script>	
		
	</HEAD>
	<body>
		  <form id="Form1" method="post" runat="server">
		 <div class="login" id="member_logout" runat="server">
				<h3><img src="http://www.topfo.com/web13/images/home/arrow_04.gif" /><span>网络招商投融资</span>成功由此起步</h3>
				<div class="inputbox">
				<div>
				 <asp:TextBox ID="txtUserName" runat="server" Height="22px" onmouseout="this.className='inpcss'" onclick="this.value=''" 
                        onmouseover="this.className='oninpcss'" Width="80px">请输入用户名</asp:TextBox><br />
				<a href="http://www.topfo.com/Register/RetrieveMemberLoginName.aspx" target="_blank">忘记用户名</a>
				</div>
				<div>
				<asp:TextBox ID="txtPsd" runat="server"  Height="22px" onmouseout="this.className='inpcss'"
                            onmouseover="this.className='oninpcss'" TextMode="Password" Width="80px" TabIndex="1"></asp:TextBox><br />
                   <a href="http://www.topfo.com/Register/RetrieveMemberPassword.aspx" target="_blank">忘记密码</a>         
				</div>
				<div>
						<asp:ImageButton id="imbLogin" runat="server" ImageUrl="http://www.topfo.com/web13/images/home/login.gif" OnClick="imbLogin_Click"></asp:ImageButton>
						<a href="http://member.topfo.com/Register/Register.aspx" target="_blank"><img src="http://www.topfo.com/web13/images/home/login_reg.gif"></a><br />
                        <asp:Label ID="lblPasswordWrong" runat="server" ForeColor="#C00000"></asp:Label><asp:Label
                         ID="lblValidate" runat="server" ForeColor="#C00000"></asp:Label>
                  </div>
              </div>
		</div>
	
		  <div class="login" id="member_login" runat="server" >
				<h3>
					<img src="http://www.topfo.com/web13/images/home/arrow_04.gif"><span>网络招商投融资</span>成功由此起步</h3>
				<div class="inputbox">
					<p class="li01" style="LINE-HEIGHT:30px;POSITION:relative;TOP:3px">
						欢迎您,<span class="bold"><a href="#" id="loginNickname" style="COLOR: #ff720a">
								<asp:Label id="lblNickName" runat="server"></asp:Label></a> ,您现在的身份是
							<asp:Label id="lblUserType" runat="server"></asp:Label></span><br>
                        <a href="http://member.topfo.com/" target="_blank"><strong><span style="color: #000000">
                            [进入拓富中心]</span></strong></a> &nbsp;
                        <asp:LinkButton ID="linkout" runat="server" OnClick="linkout_Click">退出</asp:LinkButton></p>
				</div>
			</div>
		</form>
	</body>
</HTML>
