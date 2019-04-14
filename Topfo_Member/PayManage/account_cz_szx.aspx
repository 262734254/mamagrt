<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="我要充值-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="account_cz_szx.aspx.cs"
    Inherits="PayManage_account_cz_szx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
    function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    function chkInPut()
    {
        var v=$id("txtValiNo");
		var u1=$id("txtLoginName1");
		var u2=$id("txtLoginName2");
		if(u1.value=="")
		{
		    alert("请填写需要充值的帐户");
			$id("txtLoginName1").focus();
			return false;
		}
		if(u2.value=="")
		{
		    alert("请确认需要充值的帐户");
			$id("txtLoginName2").focus();
			return false;
		}
		if(u2.value!=u1.value)
		{
		    alert("两次输入的帐号不一致!");
			$id("txtLoginName2").focus();
			return false;
		}
		if(v.value=="")
		{
		    alert("请输入验证码!");
		    $id("txtValiNo").focus();
		    return false;
		    
		}
    }
    function valiLoginName()
	{
	   
	    var u=$id("txtLoginName1");
	    AjaxMethod.ValiLoginName(u.value,backres);
	}
	function backres(res)
	{
	   if(!res.value)
	   {
	        document.getElementById("divmsg").innerHTML="<font color='red'>输入的帐户不存在!<font>";
	        $id("txtLoginName1").value="";
	   }
	   else
	   {
	        document.getElementById("divmsg").innerHTML="";
	   }
	}
    </script>

    <link href="../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;神州行充值</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a> <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="szxczbox">
            <div class="suggestbox lightc allxian ">
                <h1>
                    温馨提示</h1>
                目前神州行充值卡有50元、100元、300元、500元四种不同面值，请确保您选择的充值金额与您手上拥有 <span>的神州行充值卡面额相同。</span></div>
				 <div class="blank20"></div>
            <table width="100%" align="center" runat="server" id="tabOrder">
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> 充值帐户：</td>
                  <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />
                        <span class="hui">请输入您要充值的帐号</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> 确认帐户：</td>
                  <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                        <span class="hui">再次确认充值的帐号</span></td>
                </tr>
                <tr>
                    <td  align="right">
                        请选择充值金额：</td>
                    <td colspan="3" style="width: 100%">
                        <input checked="checked" name="payMoney" type="radio" value="50" />
                        50元
                        <input name="payMoney" type="radio" value="100" />
                        100元
                        <input name="payMoney" type="radio" value="300" />
                        300元
                        <input name="payMoney" type="radio" value="500" />
                        500元 <span class="hui font12">您选择的金额须与您拥有的充值卡面额相同</span></td>
                </tr>
                <tr>
                    <td align="right" >
                        <span class="STYLE9"><span class="cheng">*</span></span> 请输入右边的验证码：</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2" style="width: 442px">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali" />
                        <a class="font12 bule" href="javascript:;" onclick="refreshVerifyCode();return false;">
                            看不清楚换一张</a>&nbsp;&nbsp;( 验证码不区分大小写 )</td>
                </tr>
                <tr>
                    <td height="21" colspan="3" align="center" class="font12">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="33" align="center">&nbsp;
                        </td>
                    <td height="33" colspan="3" align="left" style="width: 442px">
                        <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" CssClass="buttomal"
                            Text="下一步" Width="95px" />
                        <input id="Button1" onclick="window.location.href='account_cz.aspx'" style="width: 85px"
                            type="button" value="返 回" class="buttomal" /></td>
                </tr>
            </table>
            <table id="tabOrderNext" runat="server" align="center" width="100%">
                <tr>
                    <td align="center" style="height: 50px">
                        <span style="font-size: 12pt"><strong>为帐户<asp:Label ID="lblLoginName" runat="server"></asp:Label>充值<asp:Label
                            ID="lblMoney" runat="server"></asp:Label><strong>元</strong></span></td>
                </tr>
                <tr>
                    <td align="center" style="height: 11px">
                        <asp:Button ID="btnEnter" runat="server" OnClick="btnEnter_Click" CssClass="buttomal"
                            Text="立即充值" />&nbsp;
                        <asp:Button ID="btnExit" runat="server" OnClick="btnExit_Click" CssClass="buttomal"
                            Text="上一步" Width="63px" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
