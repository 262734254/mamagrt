<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" EnableEventValidation="false" 
    Title="我要充值-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="account_cz_ebilling.aspx.cs"
    Inherits="PayManage_account_cz_ebilling" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/accountinfo.css" rel="stylesheet" type="text/css" />
 <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
    function chkInPut()
    {   
            
		    var p=$id("txtMoney");
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
		    if(u1.value!=u2.value)
		    {
		        alert("两次输入的帐号不一致");
			    $id("txtLoginName2").focus();
			    return false;
		    }
		    if(p.value=="")
		    {
			    alert("请填写金额!");
			    $id("txtMoney").focus();
			    return false;
		    }
		    if(isNaN(p.value))
		    {
			    alert("请填写正确的金额!");
			    $id("txtMoney").focus();
			    return false;
		    }
		    if(parseFloat(p.value)>50||parseFloat(p.value)<=0)
		    {
			    alert("请填写在0-50间的金额!");
			    $id("txtMoney").focus();
			    return false;
		    }
		    if($id("txtValiNo").value=="")
		    {
			    alert("验证码不能为空!!");
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
	function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    </script>

    <link href="../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;ebilling固话充值</div>
            <div class="right">
             <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/help/AccountCZ.shtml" target="_blank">充值流程详解</a> <a href="http://www.topfo.com/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
            <div class="suggestbox lightc allxian">
                <h1>
                    温馨提示</h1>
                <span class="tishi">此支付方式目前只适用于广东、广西、上海、福建、浙江、辽宁、重庆等地用户。</span><br />
                各地最大支付金额不同，单笔最高为50元，每部电话每月最大支出金额30-200元不等。
            </div>
			 <div class="blank20"></div>
            <table id="tabOrder" runat="server" align="center" width="100%">
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> 充值帐户：</td>
                  <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />                    <span class="hui">请输入您要充值的帐号</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> 确认帐户：</td>
                  <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                        <span class="hui">再次确认充值的帐号</span></td>
                </tr>
                <tr>
                    <td align="right"  width="32%">
                        <span class="cheng">*</span> 充值金额：</td>
                    <td colspan="3">
                        <select id="txtMoney" runat="server" style="width: 116px">
                            <option value="1">1.00元</option>
                            <option value="2">2.00元</option>
                            <option value="5">5.00元</option>
                            <option value="8">8.00元</option>
                            <option value="10">10.00元</option>
                            <option value="15">15.00元</option>
                            <option value="20">20.00元</option>
                            <option value="25">25.00元</option>
                            <option value="30">30.00元</option>
                            <option value="35">35.00元</option>
                            <option value="40">40.00元</option>
                            <option value="45">45.00元</option>
                            <option selected="selected" value="50">50.00元</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right" >
                        <span class="STYLE9"><span class="cheng">*</span></span> 请输入右边的验证码：</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali" />
                        <a class="font12 bule" href="javascript:;" onclick="refreshVerifyCode();return false;">
                            看不清楚换一张</a>&nbsp;&nbsp;( 验证码不区分大小写 )</td>
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
                        <asp:Button ID="btnNext" CssClass="buttomal" runat="server" OnClick="btnNext_Click"
                            Text="下一步" Width="95px" />
                    </td>
                    <td width="37%" style="height: 27px">
                        <input id="Button1" class="buttomal" onclick="window.location.href='account_cz.aspx'"
                            style="width: 85px" type="button" value="返 回" />&nbsp;</td>
                    <td align="center" style="width: 113px; height: 27px;">&nbsp;
                        </td>
                </tr>
            </table>
            <table id="tabOrderNext" runat="server" align="center" width="100%">
                <tr>
                    <td align="center" style="height: 50px">
                        <span style="font-size: 12pt"><strong>为帐户<asp:Label ID="lblLoginName" runat="server"></asp:Label>充值<asp:Label
                            ID="lblMoney" runat="server"></asp:Label>元</strong></span></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnEnter" CssClass="buttomal" runat="server" OnClick="btnEnter_Click"
                            Text="立即充值" />&nbsp;
                        <asp:Button ID="btnExit" CssClass="buttomal" runat="server" OnClick="btnExit_Click"
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
