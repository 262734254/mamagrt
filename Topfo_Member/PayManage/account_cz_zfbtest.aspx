<%@ Page Language="C#" AutoEventWireup="true" CodeFile="account_cz_zfbtest.aspx.cs" Inherits="PayManage_account_cz_zfbtest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
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
		/*if(getE("txtB_Name").value==""||getE("txtB_Name").value!=getE("txtB_ReName").value)
		{
			alert("充值帐户不为空并确认正确!");
			getE("txtB_Name").focus();
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
		}*/
		return true;
	}
    </script>
    
    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;支付宝充值</div>
            <div class="right">
                <img src="http://www.topfo.com/t/images/publish/biao_01.gif" alt="" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
            <div class="suggestbox lightc allxian ">
                <h1>
                    温馨提示</h1>
                <span class="tishiwb">拓富充值卡可以快速对指定账户进行充值，完成资源购买和其他消费行为。 <a href="http://www.topfo.com/help/AccountCZ.shtml"
                    target="_blank">了解更多</a>
                    <br />
                    我们准备了多种购买渠道供您选择，方便、快捷！
                    <br />
                    如果您有任何疑问，请拨打我们的客服电话：0755-82210116 82212980 <a href="http://www.topfo.com/tofocard_buy.aspx"
                        class="bule">立即购买</a> </span>
            </div>
            <div class="blank20">
            </div>
            <table id="tabOrder" width="100%" align="center" runat="server">
                <tr>
                    <td align="right" width="41%" height="30">
                        充值帐户：<span class="cheng">*</span></td>
                    <td colspan="2">
                        <span class="STYLE9">
                            <asp:TextBox ID="txtB_Name" runat="server" Text=""></asp:TextBox>
                            </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="41%" height="30">
                        确认充值帐户：<span class="cheng">*</span></td>
                    <td colspan="2">
                        <span class="STYLE9">
                            <asp:TextBox ID="txtB_ReName" runat="server" Text=""></asp:TextBox>
                            请输入你要充值的会员名</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="41%" height="30">
                        充值金额：<span class="cheng">*</span></td>
                    <td colspan="2">
                        <span class="STYLE9">
                            <asp:TextBox ID="txtB_PayPoint" runat="server" Text=""></asp:TextBox>
                            元 </span><span class="hui font12 ">您可以填写0－5000之间的任意金额 </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="30">
                        请输入验证码：<span class="cheng">*</span></td>
                    <td class="STYLE9" width="20%">
                        <asp:TextBox ID="txtB_yz" runat="server" Text=""></asp:TextBox>
                    </td>
                    <td width="39%">
                        <img id="imgVali" height="22" src="../ValidateNumber.aspx" width="60">&nbsp;<a class="blue"
                            onclick="refreshVerifyCode();return false;" href="javascript:;"><font size="2">看不清楚?</font></a>
                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td width="370" bgcolor="#fafafa">
                    </td>
                    <td bgcolor="#fafafa">
                        <asp:Button ID="Button1" runat="server" Text="确定" OnClientClick="return checkinfo();" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
