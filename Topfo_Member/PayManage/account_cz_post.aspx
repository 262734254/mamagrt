<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312"
    Title="我要充值-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="account_cz_post.aspx.cs"
    Inherits="PayManage_account_cz_post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
--%>
    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
    function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
	function chkPostOrder()
	{
		if($id("txtName").value=="")
		{
			alert("姓名不能为空!");
			$id("txtName").focus();
			return false;
		}
		if($id("txtTel").value==""&&$id("txtMobile").value=="")
		{
			alert("电话或手机选填一个!"); 
			$id("txtTel").focus();
			return false;
	    }
	    if($id("txtMobile").value!="")
        {
            if($id("txtMobile").value.length!=11)
            {
                alert("手机格式错误!");
                $id("txtMobile").focus();
                return false;
            }
            if(isNaN($id("txtMobile").value))
            {
                 alert("手机格式错误!");
                $id("txtMobile").focus();
                return false;
            }
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

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;邮政汇款充值</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a>
                <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
            <h1 class="pad_1" style="padding-left: 200px">
                看请认真填写以获得订单号，<span class="cheng">*</span>为必填项</h1>
            <table width="100%" height="336" align="center" cellpadding="0" cellspacing="0" id="tabOrder"
                runat="server">
                <tr>
                    <td align="right" width="32%">
                        <span class="cheng">*</span> 充值帐户：</td>
                    <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />
                        <span class="hui">请输入您要充值的帐号</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right" width="32%">
                        <span class="cheng">*</span> 确认帐户：</td>
                    <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                        <span class="hui">再次确认充值的帐号</span></td>
                </tr>
                <tr>
                    <td align="right" width="32%">
                        <span class="cheng">*</span> 充值金额：</td>
                    <td colspan="3">
                        <input id="txtMoney" runat="server" name="textfield92" size="18" type="text" />
                        元<span class="hui font12 "> </span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="STYLE9"><span class="cheng">*</span></span> 请输入右边的验证码：</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle"
                            id="imgVali" />
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
                    <td align="center" height="128">
                        &nbsp;
                    </td>
                    <td align="left" class="font12" colspan="2" height="128">
                        <font class="cheng">请认真记录以下汇款信息：</font>
                        <br />
                        储蓄卡号: 6221 8858 40000 3803 934<br />
                        
                        <br />
                        收款人: 张新亮
                        <br />
                       
                        汇款用途: 请在汇款单的附言栏注明订单号和用户名(<span class="cheng">切记</span>)
                    </td>
                    <td align="left" class="font12" style="width: 113px" valign="bottom">
                        <img height="14" src="../images/PayManage/biao_print.gif" width="15" />
                        <a href="javascript:;" onclick="window:print()">打印该页</a></td>
                </tr>
                <tr>
                    <td align="center" class="font12" colspan="4" height="11">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center" height="27">
                        &nbsp;
                    </td>
                    <td align="center" height="27">
                        <label>
                            &nbsp;<asp:Button ID="btnNext" runat="server" CssClass="buttomal" OnClick="btnNext_Click"
                                Text="下一步" Width="95px" /></label></td>
                    <td height="27" width="37%">
                        &nbsp;<input id="Button1" onclick="window.location.href='account_cz.aspx'" style="width: 85px"
                            type="button" value="返 回" class="buttomal" /></td>
                    <td align="center" height="27" style="width: 113px">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <table id="tabOrderNext" runat="server" align="center" height="328" width="100%">
                <tr>
                    <td align="right" style="width: 236px">
                        充值帐户：</td>
                    <td align="left">
                        <asp:Label ID="lblLoginName" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        充值金额：</td>
                    <td align="left">
                        <asp:Label ID="lblMoney" runat="server"></asp:Label>元
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        充值日期：</td>
                    <td align="left">
                        <asp:Label ID="lblTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" height="33">
                        &nbsp;<img align="absMiddle" src="../images/icon_yb.gif" />
                        请正确填写您的个人资料。以便我们能及时通知您充值成功。</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> 联 系 人：</td>
                    <td align="left">
                        <input id="txtName" runat="server" name="textarea" type="text" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> 联系电话：</td>
                    <td align="left">
                        <input id="txtTel" runat="server" name="textarea3" type="text" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        联系手机：</td>
                    <td align="left">
                        <input id="txtMobile" runat="server" name="textarea3" type="text" /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        电子邮件：</td>
                    <td align="left">
                        <input id="txtEmail" runat="server" name="textarea32" type="text" /></td>
                </tr>
                <tr>
                    <td style="width: 236px">
                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="btnEnter" CssClass="buttomal" runat="server" OnClick="btnEnter_Click"
                            Text="提交订单" />&nbsp;
                        <asp:Button ID="btnExit" CssClass="buttomal" runat="server" OnClick="btnExit_Click"
                            Text="返回" Width="75px" /></td>
                </tr>
            </table>
            <br />
            <div class="helpbox">
                <div class="con">
                    <h1>
                        <img align="absMiddle" src="../images/icon_yb.gif" /><strong> 注意事项</strong></h1>
                    <p>
                        1. 汇款后，请将汇款凭证传真到0755-82213698（网上银行支付客户请打印支付成功页面）
                        <br />
                        2. 款到后，我们将立即为您充值，并在充值后的第一时间给您电话或短信回馈
                        <br />
                        3. 如果您有任何疑问，请拨打我们的客服电话：<!--#include file="../common/custel.html"-->
                    </p>
                </div>
            </div>
            <div class="blank20">
            </div>
        </div>
    </div>
</asp:Content>
