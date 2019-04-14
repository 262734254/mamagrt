<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodePage="936"
    Title="通知设置-拓富中心-中国招商投资网" CodeFile="try_vip.aspx.cs" Inherits="helper_try_vip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/messagemanage.css" rel="stylesheet" type="text/css" />
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                短信试用</div>
            <div class="right" style="display:none">
                <img src="../images/AccountInfo/handbiao.gif" width="16" height="10" />
                <a href="#">短信试用指引</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank6">
        </div>
        <!--申请试用-->
        <div class="smsconbox cshibiank">
            <h1 class="lightc dottedl">
                <asp:Literal runat="server" ID="lblMsg"></asp:Literal>
            </h1>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="height: 60px">
                        <font size="2">请发送手机短信“M#帐号”(如：M#<asp:Literal runat="server" ID="lblLoginName"></asp:Literal>)到号码106693891291，成功后您将获得短信通知。</font></td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="height: 60px">
                        <font size="2">提醒:1、手机短信发送支持中国移动和中国联通。<br />
                            &nbsp; &nbsp; &nbsp;2、每次试用服务收取1元短信费用，不成功不扣费。</font>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
