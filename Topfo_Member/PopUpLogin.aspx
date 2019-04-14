<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUpLogin.aspx.cs" Inherits="PopUpLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登陆</title>
    <style type="text/css">
    body {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 18px;
	color: #333333;
	margin: 0 0 0 0;
}
a,td{
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
}
ul {
	list-style-type:square;
	margin-top: 10px;
	margin-right: 0px;
	margin-bottom: 10px;
	margin-left: 10px;
}
ul.l {
	width:180px;
}
li {
	width:100%;
	font-size: 12px;
	color: #FF6600;	
	margin-left: 15px;
}
input {
	height:16px;
}
    .greyguang { BORDER-RIGHT: #7d7d7d 1px solid; BORDER-TOP: #7d7d7d 1px solid; BORDER-LEFT: #7d7d7d 1px solid; BORDER-BOTTOM: #7d7d7d 1px solid }
	        .cheng { FONT-WEIGHT: bold; COLOR: #ff6600 }
		</style>
    
    <script language="javascript" type="text/javascript">
		function changeVerifyCode()
		{	
		   var randomnum = Math.random();
		   document.getElementById("verifycodeImg").src = "/ValidateNumber.aspx?d=" + randomnum;
		}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <font face="宋体"><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</strong></font>
        <table class="greyguang" height="187" cellspacing="0" cellpadding="0" width="428"
            align="center" border="0">
            <tr>
                <td valign="top" align="left" height="50">
                    <table bordercolor="#ffffff" height="50" cellspacing="0" cellpadding="0" width="100%"
                        bgcolor="#e9e9e9" border="1">
                        <tr>
                            <td style="font-size: 14px; color: #ff0000; line-height: 130%" align="center">
                                <strong>请登录后查看详细资料！</strong></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 70px" align="left" bgcolor="#f9f9f9" height="30">
                    <strong></strong>用户名：
                    <asp:TextBox ID="txtLoginName" runat="server" Height="20px" Width="120px" MaxLength="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="用户名不能为空"
                        ControlToValidate="txtLoginName">用户名不能为空</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="padding-left: 70px" align="left" bgcolor="#f9f9f9" height="30">
                    密&nbsp;&nbsp;&nbsp; 码：&nbsp;
                    <asp:TextBox ID="txtPassword" runat="server" Height="20px" Width="120px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="密码不能为空"
                        ControlToValidate="txtPassword">密码不能为空</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 70px" align="left" bgcolor="#f9f9f9" height="30">
                    验证号：&nbsp;
                    <asp:TextBox ID="txtValidate" runat="server" Height="20px" Width="48px" DESIGNTIMEDRAGDROP="159"></asp:TextBox><img
                        src="./ValidateNumber.aspx" alt="点击图片" name="verifycodeImg" align="absMiddle"
                        id="verifycodeImg" style="cursor: pointer" onclick="changeVerifyCode(id)">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 70px" align="left" bgcolor="#f9f9f9" height="30">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;
                    <asp:Button ID="btnLogin" runat="server" Height="24px" Text="确 认" OnClick="btnLogin_Click"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input style="width: 51px; color: #484848; height: 25px" type="reset" value="重 置"
                        name="Submit2"></td>
            </tr>
            <tr>
                <td style="padding-left: 70px; color: red" align="left" bgcolor="#f9f9f9" height="30">
                    还不是会员<a onclick="changeVerifyCode();return false" href="javascript:;">?</a>
                    <asp:HyperLink ID="hlnkRegister" runat="server" NavigateUrl="http://member.topfo.com/Register/Register.aspx"
                        Target="_blank" ForeColor="Red">免费注册</asp:HyperLink>
                    <asp:ValidationSummary ID="vs1" runat="server" Height="16px" Width="241px" DisplayMode="SingleParagraph">
                    </asp:ValidationSummary>
                    <asp:Label ID="lblPasswordWrong" runat="server" Height="16px" Width="240px" ForeColor="Red"
                        Visible="False">密码不能为空</asp:Label>
                    <asp:Label ID="lblValidate" runat="server" Height="16px" Width="248px" ForeColor="Red"
                        Visible="False">验证不通过</asp:Label></td>
            </tr>
            <tr>
                <td style="padding-bottom: 10px; color: #484848" valign="bottom" align="center" bgcolor="#ffffff"
                    height="45">
                    中国招商投资网有限公司 客服热线：0755-82210116</td>
            </tr>
        </table>
        <font face="宋体"><strong>&nbsp;&nbsp;&nbsp;&nbsp;</strong>
            <br>
        </font>
    </form>
</body>
</html>
