<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" Title="短信试用-拓富中心-中国招商投资网"
    AutoEventWireup="true" CodeFile="try_sms.aspx.cs" Inherits="helper_try_sms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--   <link href="/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/css/messagemanage.css" rel="stylesheet" type="text/css" />--%>
    <div id="mainconbox">
        <div class="topzi">
            <div class="left">
                短信试用</div>
            <div class="right">
                <img src="../images/AccountInfo/handbiao.gif" width="16" height="10" />
                <a href="#">短信试用指引</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank6">
        </div>
        <div class="smsconbox cshibiank">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="4" style="height: 60px">
                        短信试用已停止, 若有任何问题,请联系本站客服人员,电话:0755-82210116
                    </td>
                </tr>
            </table>
            <div style="display: none">
                <h1 class="lightc dottedl">
                    发送短信，<span class="hong font14">拓富通会员服务 </span>就能轻松试用！每次可试用一天，最多可以试用三次！
                </h1>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" style="height: 60px">
                            请发送手机短信 M+帐号(如：Mtopfo)到号码93891291，成功后您将获得短信通知。</td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td colspan="4" style="height: 60px">
                            提醒：1、手机短信发送支持中国移动和中国联通。<br />
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 2、每次试用服务收取1元短信费用，不成功不扣费。
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
