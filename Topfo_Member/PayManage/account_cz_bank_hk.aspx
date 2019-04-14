<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" Title="银行汇款充值-拓富中心-中国招商投资网"
    AutoEventWireup="true" CodeFile="account_cz_bank_hk.aspx.cs" Inherits="PayManage_account_cz_bank_hk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript">
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
	function $id(obj)
	{
	     return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
    </script>

    <link href="../css/common.css" rel="stylesheet" type="text/css" />
<div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;银行转帐充值</div>
            <div class="right">
            <img src="../images/publish/biao_01.gif" width="14" height="15" />
                <a href="http://www.topfo.com/web13/help/AccountCZ.shtml" target="_blank">充值流程详解</a> <a href="http://www.topfo.com/web13/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></div>
            <div class="clear">
            </div>
        </div>
        <!-- -->
        <div class="szxczbox">
            <h1 class="pad_1" style="padding-left:200px">
               请确认您的订单信息：</h1>
            <table width="100%" height="328" align="center" id="tabOrder" runat="server">
                <tr>
                    <td width="32%" height="30" align="right">
                        <span class="cheng">*</span> 充值帐户：</td>
                  <td colspan="3">
                        <input name="textfield92" type="text" size="18" id="txtLoginName1" onblur="valiLoginName()"
                            runat="server" />                    <span class="hui">请输入您要充值的帐号<span id="divmsg"></span></span></td>
                </tr>
                <tr>
                    <td width="32%" height="30" align="right">
                        <span class="cheng">*</span> 确认帐户：</td>
                  <td colspan="3">
                        <input name="textfield92" type="text" size="18" id="txtLoginName2" runat="server" />
                      <span class="hui">                      再次确认充值的帐号</span></td>
                </tr>
                <tr>
                    <td width="32%" height="30" align="right">
                        <span class="cheng">*</span> 充值金额：</td>
                    <td colspan="3">
                        <input name="textfield92" type="text" size="18" id="txtMoney" runat="server" />
                        元<span class="hui font12 "> </span>
                    </td>
                </tr>
                <tr>
                    <td height="30" align="right">
                        <span class="STYLE9"><span class="cheng">*</span></span> 请输入右边的验证码：</td>
                    <td width="16%" class="STYLE9">
                        <input name="textfield9" type="text" size="18" id="txtValiNo" runat="server" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle" id="imgVali">
                        <a onclick="refreshVerifyCode();return false;" class="font12 bule" href="javascript:;">
                            看不清楚换一张</a></td>
                </tr>
                <tr>
                    <td colspan="4" align="center" class="font12">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="128" align="center">&nbsp;
                  </td>
                    <td height="128" colspan="2" align="left" class="font12">
                        <font class="cheng">请认真记录以下汇款信息：</font>
                        <br>
                        对公户名: 深圳市贤泽投资有限公司
                        <br>
                        农 行: 深圳市农行国贸支行 41008900040016258
                       
                        <br>
                        工 行: 深圳市工商国贸支行 4000022819200018954
                        <br>
                        <br>
                        个人户名: 张新亮
                        <br>
                        农 行: 农业银行金穗通宝卡 6228480120057721116
                        <br>
                        招 行: 招商银行一卡通 5124257555525555
                        <br>
                        工 行: 工商银行牡丹灵通卡 9558804000111681363
                        <br>
                        汇款用途: 请在汇款单的附言栏注明订单号和用户名（<font class="cheng">切记！</font>）</td>
                    <td align="left" valign="bottom" class="font12" style="width: 113px">
                        <img src="../images/PayManage/biao_print.gif" width="15" height="14" />
                        <a href="javascript:;" onclick="window:print()">打印该页</a></td>
                </tr>
                <tr>
                    <td height="28" colspan="4" align="center" class="font12">
                        <div class="dottedlline">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center">&nbsp;
                  </td>
                    <td height="27" align="center">
                        <label>
                            &nbsp;<asp:Button ID="btnNext" runat="server" CssClass="buttomal" Text="下一步" Width="95px" OnClick="btnNext_Click" /></label></td>
                    <td width="37%" height="27">
                        &nbsp;<input id="Button1" style="width: 85px" type="button" value="返 回" class="buttomal" onclick="window.location.href='account_cz.aspx'" /></td>
                    <td height="27" align="center" style="width: 113px">&nbsp;
                  </td>
                </tr>
            </table>
            <table width="100%" height="328" align="center" id="tabOrderNext" runat="server">
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
                        <asp:Label ID="lblMoney" runat="server"></asp:Label>元                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        充值日期：</td>
                    <td align="left">
                        <asp:Label ID="lblTime" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2" height="33">
                        &nbsp;<img src="../images/icon_yb.gif" align="absmiddle" />
                        请正确填写您的个人资料。以便我们能及时通知您充值成功。</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> 联 系 人：</td>
                  <td align="left">
                        <input id="txtName" type="text" name="textarea" runat="server">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        <span class="cheng">*</span> 联系电话：</td>
                    <td align="left">
                        <input id="txtTel" type="text" name="textarea3" runat="server">&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        联系手机：</td>
                    <td align="left">
                        <input id="txtMobile" type="text" name="textarea3" runat="server"></td>
                </tr>
                <tr>
                    <td align="right" style="width: 236px">
                        电子邮件：</td>
                    <td align="left">
                        <input id="txtEmail" type="text" name="textarea32" runat="server"></td>
                </tr>
                <tr>
                    <td style="width: 236px">                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="btnEnter" runat="server" CssClass="buttomal" Text="提交订单" OnClick="btnEnter_Click"></asp:Button>&nbsp;
                        <asp:Button ID="btnExit" runat="server" Text="返回"  CssClass="buttomal" Width="75px" OnClick="btnExit_Click">                        </asp:Button></td>
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
			 <div class="blank20"></div>
        </div>
    </div>
</asp:Content>