<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Inquiry_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>欢迎来到中国招商投资网</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">BODY {
	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-SIZE: 12px; BACKGROUND: url(images/topfo1.gif) repeat-x 50% bottom; PADDING-BOTTOM: 50px; MARGIN: 0px; PADDING-TOP: 0px; FONT-FAMILY: "宋体"; TEXT-ALIGN: center
}
H3 {
	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-WEIGHT: bold; FONT-SIZE: 16px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px
}
P {
	FONT-SIZE: 14px; LINE-HEIGHT: 24px
}
IMG {
	BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none
}
SPAN {
	COLOR: #ff6600
}
A {
	FONT-WEIGHT: bold; FONT-SIZE: 16px
}
A:hover {
	coloer: red
}
.wrap {
	PADDING-RIGHT: 100px; PADDING-LEFT: 100px; BACKGROUND: url(images/topfo.gif) no-repeat center top; MARGIN: 0px auto; WIDTH: 650px; PADDING-TOP: 150px; TEXT-ALIGN: left
}
.content {
	FONT-SIZE: 13px; MARGIN-LEFT: 30px; COLOR: #1e2278; LINE-HEIGHT: 18px; MARGIN-RIGHT: 30px
}
.content TD {
	PADDING-RIGHT: 3px; PADDING-LEFT: 3px; PADDING-BOTTOM: 3px; WIDTH: 260px; PADDING-TOP: 3px
}
.content TH {
	PADDING-RIGHT: 3px; PADDING-LEFT: 3px; PADDING-BOTTOM: 3px; VERTICAL-ALIGN: top; WIDTH: 130px; PADDING-TOP: 3px; TEXT-ALIGN: right
}
.content INPUT {
	BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 260px; BORDER-BOTTOM: #7f9db9 1px solid
}
.content TEXTAREA {
	BORDER-RIGHT: #7f9db9 1px solid; BORDER-TOP: #7f9db9 1px solid; BORDER-LEFT: #7f9db9 1px solid; WIDTH: 260px; BORDER-BOTTOM: #7f9db9 1px solid; HEIGHT: 180px
}
.footer {
	FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: red; TEXT-ALIGN: center
}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
            <div>
                <h3>
                    尊敬的用户：</h3>
                <p>
                    您好！恭喜您成为我们新版网站的体验嘉宾。 由于本网站新版正在体验测试中，存在一些问题有待发现并解决。如果您发现了问题，说明您已经是我们的幸运嘉宾。如果您急需使用某些功能，请先<a
                        href="#">
                        <img height="16" src="images/zi.gif" width="31">
                        进入旧版继续访问 </a>。</p>
                <p class="content">
                    请将您发现的问题或建议迅速反馈给被我们，一旦确认属实并采纳，您将会获得我们的一份小礼物 --- 价值<span>50元的拓富充值卡</span>，凭此卡可以随意购买我们的优质服务。同时非常感谢您再次体验新版的其它服务。
                </p>
                <table class="content" width="80%" border="0">
                    <tbody>
                        <tr>
                            <th>
                                问题或建议主题：</th>
                            <td>
                                <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                问题或建议描述：</th>
                            <td>
                                <textarea id="txtDesc" runat="server"></textarea></td>
                            <td style="width: 260px">
                                这里请输入您的问题或建议的详细描述及相关信息，最多不超过500个字。您描述越详细，您的建议就越可能被采纳并受理。</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                填写电话联系方式和E-mail信息，将有助于我们尽快解决您提出的问题，并及时与您沟通处理结果。</td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                您的姓名：</th>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                所在地区：</th>
                            <td>
                                <asp:TextBox ID="txtZone" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                联系电话：</th>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                E-mail：</th>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td align="center">
                                <asp:ImageButton ID="manage" runat="server" ImageUrl = "images/te.gif" Height="37px" OnClick="manage_Click" Width="119px" />
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                    </tbody>
                </table>
                <p class="footer">
                    <img height="20" alt="您也可以直接来电，我们会立即受理。惊喜热线：0755 - 82212313" src="images/foot.gif"
                        width="507">
                </p>
            </div>
        </div>
    </form>
</body>
</html>
