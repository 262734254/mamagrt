<%@ Page Language="C#" MasterPageFile="~/Retrieve.master"  Title="找回密码 拓富—中国招商投资网" AutoEventWireup="true" CodeFile="succeedByMobile.aspx.cs" Inherits="Register_succeedByMobile"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="NavTitle" style="text-align: right">
<h3 class="leftfloat"><span>找回密码</span></h3>
<div style="text-align: right" ><a href="RetrieveStep7.aspx">返回上一页</a></div>
<div class="redlineH1"></div>
</div>

<div class="blank0"></div>
<div class="mainbox">

<div class="bg1 bgimg12">

<b>您的身份得到确认！</b><br />
系统已经自动给您的手机发送了一条信息，请过几秒钟后查看您的手机。<br />
并在下面的输入框中输入您收到的验证码。 <span style="font-size: 14px; color: red;">
        请暂时不要关闭该页面！</span><div class="blank20"></div>
<div class="blank0"></div>
<span class="normal">请输入您收到的验证码：
    <asp:TextBox ID="TxtProof" runat="server" CssClass="oninpcss"></asp:TextBox>&nbsp;  
    <asp:Button ID="BtnConfirm" runat="server" CssClass="inputbtn" Text="确  定" OnClick="BtnConfirm_Click" />
    <asp:RequiredFieldValidator ID="rfcProof" runat="server" ControlToValidate="TxtProof"
        CssClass="font12 normal" ErrorMessage="验证码不能为空" Width="144px"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revMoible" runat="server" ControlToValidate="TxtProof"
        Display="Dynamic" ErrorMessage="验证码为6个数字" ValidationExpression="^\d{6}$"></asp:RegularExpressionValidator>
    <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label></span><br />
    <p class="MsoNormal" style="margin: 0cm 0cm 0pt">
        <span style="font-size: 14px"><b style="mso-bidi-font-weight: normal"><span style="color: #ff6600;
            font-family: 宋体; mso-ascii-font-family: 'Times New Roman'; mso-hansi-font-family: 'Times New Roman'">
            温馨提示：</span></b><span style="font-family: 宋体; mso-ascii-font-family: 'Times New Roman';
                mso-hansi-font-family: 'Times New Roman'">由于短信接口的问题，偶尔会出现需要几分钟甚至十几分钟才能收到短信的情况，请您耐心等待！您也可以<u><a href="RetrieveStep1.aspx"><span
                    style="color: #0033cc; text-decoration: underline;">点此重新选择找回密码的方式</span></a></u></span></span><span lang="EN-US" style="font-size: 6.5pt"><?xml
                        namespace="" ns="urn:schemas-microsoft-com:office:office" prefix="o" ?><o:p></o:p></span></p>
</div>
</div>
</asp:Content>

