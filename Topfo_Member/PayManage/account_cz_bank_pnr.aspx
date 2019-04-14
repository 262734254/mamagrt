<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="网上银行充值-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="account_cz_bank_pnr.aspx.cs"
    Inherits="PayManage_account_cz_bank_pnr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
   
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;网上银行充值</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a> <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
          <div class="suggestbox lightc allxian">
                <h1>
                    温馨提示</h1>
              <span class="tishiwb">使用此充值方式，需要您开通网上银行功能。如果您还没有开通，请&gt;&gt;<a href="http://www.topfo.com/web13/help/defray.shtml#14" target="_blank" >点此开通</a>
                  &gt;&gt;<a href="#" class="bule">查看银行限额</a></span></div>
					<div class="blank20"></div>
            <table id="tabOrder" runat="server" align="center" width="100%">
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> 充值帐户：</td>
                  <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />                    <span class="hui">请输入您要充值的帐号</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> 确认帐户：</td>
                  <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                     <span class="hui"> 再次确认充值的帐号</span></td>
                </tr>
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> 充值金额：</td>
                    <td colspan="3">
                        <input id="txtMoney" runat="server" name="textfield92" size="18" type="text" />
                        元<span class="hui font12 "> </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="30">
                        <span class="STYLE9"><span class="cheng">*</span></span> 请输入右边的验证码：</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali" />
                        <a class="font12 bule" href="javascript:;" onclick="refreshVerifyCode();return false;">
                            看不清楚换一张</a></td>
                </tr>
                <tr>
                    <td align="center" class="font12" colspan="4">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" style="height: 27px">&nbsp;
                        </td>
                    <td align="center" style="height: 27px">
                        <label>
                            &nbsp;<asp:Button ID="btnNext" runat="server" CssClass="buttomal" OnClick="btnNext_Click"
                                Text="下一步" Width="95px" /></label></td>
                    <td width="37%" style="height: 27px">
                        &nbsp;<input id="Button1" onclick="window.location.href='account_cz.aspx'" style="width: 85px"
                            type="button" value="返 回" class="buttomal" /></td>
                    <td align="center" style="width: 113px; height: 27px;">&nbsp;
                        </td>
                </tr>
            </table>
			<div class="blank20"></div>
            <table id="tabOrderNext" runat="server" align="center" width="100%">
                <tr>
                    <td align="center" style="height: 40px">
                        <span style="font-size: 12pt">为帐户
                            <asp:Literal ID="lblLoginName" runat="server">
                            </asp:Literal>充值<asp:Literal ID="lblMoney" runat="server"></asp:Literal>元</span></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnEnter" runat="server" CssClass="buttomal" OnClick="btnEnter_Click"
                            Text="立即充值" />&nbsp;
                        <asp:Button ID="btnExit" runat="server" CssClass="buttomal" OnClick="btnExit_Click"
                            Text="上一步" Width="63px" /></td>
                </tr>
            </table>
			<div class="blank20"></div>
            <div class="helpbox">
                <div class="con">
                    <h1>
                        <img src="../images/icon_yb.gif" align="absmiddle" /><strong> 注意事项</strong></h1>
                    <p>
                        1. 汇款后，请将汇款凭证传真到0755-82213698（网上银行支付客户请打印支付成功页面）
                        <br />
                        2. 款到后，我们将立即为您充值，并在充值后的第一时间给您电话或短信回馈
                        <br />
                        3. 如果您有任何疑问，请拨打我们的客服电话：<!--#include file="../common/custel.html"-->
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
