<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Inquiry_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>��ӭ�����й�����Ͷ����</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <style type="text/css">BODY {
	PADDING-RIGHT: 0px; PADDING-LEFT: 0px; FONT-SIZE: 12px; BACKGROUND: url(images/topfo1.gif) repeat-x 50% bottom; PADDING-BOTTOM: 50px; MARGIN: 0px; PADDING-TOP: 0px; FONT-FAMILY: "����"; TEXT-ALIGN: center
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
                    �𾴵��û���</h3>
                <p>
                    ���ã���ϲ����Ϊ�����°���վ������α��� ���ڱ���վ�°�������������У�����һЩ�����д����ֲ��������������������⣬˵�����Ѿ������ǵ����˼α������������ʹ��ĳЩ���ܣ�����<a
                        href="#">
                        <img height="16" src="images/zi.gif" width="31">
                        ����ɰ�������� </a>��</p>
                <p class="content">
                    �뽫�����ֵ��������Ѹ�ٷ����������ǣ�һ��ȷ����ʵ�����ɣ������������ǵ�һ��С���� --- ��ֵ<span>50Ԫ���ظ���ֵ��</span>��ƾ�˿��������⹺�����ǵ����ʷ���ͬʱ�ǳ���л���ٴ������°����������
                </p>
                <table class="content" width="80%" border="0">
                    <tbody>
                        <tr>
                            <th>
                                ����������⣺</th>
                            <td>
                                <asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                �������������</th>
                            <td>
                                <textarea id="txtDesc" runat="server"></textarea></td>
                            <td style="width: 260px">
                                ������������������������ϸ�����������Ϣ����಻����500���֡�������Խ��ϸ�����Ľ����Խ���ܱ����ɲ�����</td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                ��д�绰��ϵ��ʽ��E-mail��Ϣ�������������Ǿ���������������⣬����ʱ������ͨ��������</td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                ����������</th>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                ���ڵ�����</th>
                            <td>
                                <asp:TextBox ID="txtZone" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                ��ϵ�绰��</th>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                            <td style="width: 260px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <th>
                                E-mail��</th>
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
                    <img height="20" alt="��Ҳ����ֱ�����磬���ǻ�����������ϲ���ߣ�0755 - 82212313" src="images/foot.gif"
                        width="507">
                </p>
            </div>
        </div>
    </form>
</body>
</html>
