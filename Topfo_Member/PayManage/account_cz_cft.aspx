<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="account_cz_cft.aspx.cs" Inherits="PayManage_account_cz_cft" Title="财付通充值" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
    function getE(eid)
    {
        if(document.getElementById(eid)==null)
        {
            return document.getElementById("ctl00_ContentPlaceHolder1_"+eid);
        }
        else
        {
            return document.getElementById(eid);
        }
    }
    
    function checkinfo()
	{
		if(getE("txtB_Name").value=="")
		{
			alert("财付通帐户不为空!");
			getE("txtB_Name").focus();
			return false;
		}
		if(getE("txtB_CzName").value==""||getE("txtB_CzName").value!=getE("txtB_ReCzName").value)
		{
			alert("充值帐户不为空并确认正确!");
			getE("txtB_CzName").focus();
			return false;
		}
		if(getE("txtB_PayPoint").value==""||Number(getE("txtB_PayPoint").value)>5000||Number(getE("txtB_PayPoint").value)<=0)
		{
			alert("充值金额不为空且不超过5000，请使用小额多充值几次");
			getE("txtB_PayPoint").focus();
			return false;
		}
		if(getE("txtB_yz").value=="")
		{
			alert("验证不能为空!");
			getE("txtB_yz").focus();
			return false;
		}
	}
    </script>

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;财付通充值</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="szxczbox">
            <div class="suggestbox lightc allxian">
                <h1>
                    温馨提示</h1>
                <span class="tishiwb">使用此充值方式，需要您开通财付通功能。如果您还没有开通，请&gt;&gt;<a href="http://www.topfo.com/web13/help/defray.shtml#14"
                    target="_blank">点此开通</a> &gt;&gt;<a href="#" class="bule">查看银行限额</a></span></div>
            <div class="blank20">
            </div>
            <table id="Table1" width="457" align="center" height="136">
                <tr>
                    <td align="right" width="33%" height="30">
                        财付通帐号：</td>
                    <td class="chengcu" align="left" colspan="2">
                        <span class="STYLE9">
                            <asp:TextBox ID="txtB_Name" runat="server"></asp:TextBox>（QQ或者E-mail） </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="41%" height="30">
                        充值帐户：<span class="cheng">*</span></td>
                    <td colspan="2">
                        <span class="STYLE9">
                            <asp:TextBox ID="txtB_CzName" runat="server" Text="">默认为本帐号</asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="41%" height="30">
                        确认充值帐户：<span class="cheng">*</span></td>
                    <td colspan="2">
                        <span class="STYLE9">
                            <asp:TextBox ID="txtB_ReCzName" runat="server" Text=""></asp:TextBox>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="33%" height="30">
                        充值总额：</td>
                    <td class="chengcu" align="left" colspan="2">
                        <asp:TextBox ID="txtB_PayPoint" runat="server"></asp:TextBox>元（金额不超过5000）</td>
                </tr>
                <tr>
                    <td align="right" width="41%" height="30">
                        </td>
                    <td colspan="2">
                        <span class="STYLE9">注意：充值金额请使用小数额,可分多次充值。
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="30">
                        请输入验证码：</td>
                    <td class="STYLE9" width="26%">
                        <asp:TextBox ID="txtB_yz" runat="server"></asp:TextBox>
                    </td>
                    <td align="left" width="41%">
                        <asp:Image ID="imgVali" runat="server" Height="22" ImageUrl="../ValidateNumber.aspx"
                            Width="60" />
                        &nbsp;<a class="font12 bule" onclick="refreshVerifyCode();return false;" href="javascript:;">看不清楚?</a></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="center" height="50">
                        <asp:ImageButton ID="ImageButton1" OnClick="ImageButton1_Click" OnClientClick="return checkinfo();"
                            runat="server" ImageUrl="../images/bankimg/buttom_next.gif"></asp:ImageButton></td>
                    <td align="center" height="50">
                        &nbsp;</td>
                </tr>
            </table>
            <div class="blank20">
            </div>
            <div class="helpbox">
                <div class="con">
                    <h1>
                        <img src="../images/icon_yb.gif" align="absmiddle" /><strong> 注意事项</strong></h1>
                    <p>
                        1. 款到后，我们将立即为您充值，并在充值后的第一时间给您电话或短信回馈
                        <br />
                        2. 如果您有任何疑问，请拨打我们的客服电话：<!--#include file="../common/custel.html"-->
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
