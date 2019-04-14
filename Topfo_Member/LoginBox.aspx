<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginBox.aspx.cs" Inherits="LoginBox" %>

<link href="http://www.topfo.com/css/common.css" rel="stylesheet" type="text/css">
<link href="http://tz2.topfo.com/css/index.css" rel="stylesheet" type="text/css">
<form id="form_mini" name="form_mini" runat="server">
    <div class="channelLog" id="member_logout" runat="server">
        <asp:textbox id="txtUserName" runat="server" width="108px"></asp:textbox>
        <asp:imagebutton id="imbLogin" runat="server" align="absMiddle" imageurl="http://capital.topfo.com/images/button_denglu.gif"
            onclick="imbLogin_Click" style="margin-left:1px;"></asp:imagebutton>
        <div class="blank8">
        </div>
        <asp:textbox id="txtPsd" textmode="Password" runat="server" width="108px"></asp:textbox>
        <a href="/Register/Register.aspx" target="_blank">
            <img src="http://capital.topfo.com/images/button_zhuce.gif" align="absMiddle" style="margin-left:1px;"></a>
        <div class="blank4">
        </div>
        <a href="http://member.topfo.com/Register/RetrieveStep10.aspx" target="_blank"><span
            class="gray01">忘记用户名</span></a> <a href="http://www.topfo.com/Register/RetrieveMemberPassword.aspx"
                target="_blank"><span class="gray01">忘记密码?</span></a><br />
    </div>
    <div class="channelLog" id="member_login" runat="server" visible="false">
        <div style="padding: 5px 0 0 0;">
            欢迎您,
            <asp:label cssclass="cu" font-bold="true" id="lblNickName" runat="server"></asp:label>
            <asp:linkbutton id="linkout" runat="server" onclick="linkout_Click">>> 退出</asp:linkbutton>
        </div>
        <div class="atopt">
            你现在已成功登陆为：
            <asp:label id="lblUserType" runat="server"></asp:label>
        </div>
        <div class="m20">
            <p style="important; padding: 6px 0 6px 0">
                <img src="images/login/icon_biao.gif" width="10" height="9" />
                <a href="http://member.topfo.com/" target="_blank">进入拓富中心</a></p>
            <img src="images/login/icon_biao.gif" width="10" height="9" />
            <br />
        </div>
    </div>
</form>
