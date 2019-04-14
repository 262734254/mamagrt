<%@ Page Language="C#" AutoEventWireup="true" CodeFile="account_cz_tofoTest.aspx.cs" Inherits="PayManage_account_cz_tofoTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
        <link href="../css/accountinfo.css" rel="stylesheet" type="text/css" />
        <link href="../css/common.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">


    <script type="text/javascript" src="/JavaScript/pay.js"></script>

    <script language="javascript" type="text/javascript">
    function $id(obj)
	{
	      return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
	function chkInput()
	{
		var t=$id("txtToptocard");
		var p=$id("txtTopfoPwd");
		var v=$id("txtValiNo");
		if($id("txtLoginName2").value=="")
		{
		    alert("请输入需要充值的帐号!");
			$id("txtLoginName1").focus();
			return false;
		}
		if($id("txtLoginName2").value=="")
		{
		    alert("请再次输入需要充值的帐号!");
			$id("txtLoginName2").focus();
			return false;
		}
		if($id("txtLoginName1").value!=$id("txtLoginName2").value)
		{
		    alert("两次输入的帐号不一致!");
			$id("txtLoginName2").focus();
			return false;
		}
		if(t.value==""||isNaN(t.value))
	    {
			alert("请输入正确的卡号!");
			t.focus();
			return false;
		}
        if(t.value.length<11||t.value.length>13)
        {
            alert("请输入正确的卡号,长度为11-12位数字");
            t.focus();
            return false;
        }
		if(p.value==""||isNaN(p.value))
		{
			alert("请输入正确的密码!");
			p.focus();
			return false;
		}
		if(v.value=="")
		{
			alert("请输入验证码!");
			v.focus();
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

    <div class="mainconbox">
        <div class="titled">
            <div class="left">
                我要充值&gt;&gt;拓富通充值卡充值</div>
            <div class="right">
                <img src="../images/publish/biao_01.gif" width="14" height="15" />
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
                    <br>
                    我们准备了多种购买渠道供您选择，方便、快捷！
                    <br />
                    如果您有任何疑问，请拨打我们的客服电话：0755-82210116 82212980 <a href="tofocard_buy.aspx" class="bule">
                        立即购买</a> </span>
            </div>
            <div class="blank20">
            </div>
            <table id="tabOrder" runat="server" align="center" width="100%">
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> 充值帐户：</td>
                    <td colspan="3">
                        <input id="txtLoginName1" runat="server" name="textfield92" onblur="valiLoginName()"
                            size="18" type="text" />
                        <span class="hui">请输入您要充值的帐号</span><span id="divmsg"></span></td>
                </tr>
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> 确认帐户：</td>
                    <td colspan="3">
                        <input id="txtLoginName2" runat="server" name="textfield92" size="18" type="text" />
                        <span class="hui">再次确认充值的帐号</span></td>
                </tr>
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> 充值卡号：</td>
                    <td colspan="3">
                        <input id="txtToptocard" runat="server" name="textfield92" type="text" style="width: 237px" /></td>
                </tr>
                <tr>
                    <td align="right" height="30" width="32%">
                        <span class="cheng">*</span> 充值密码：</td>
                    <td colspan="3">
                        <input id="txtTopfoPwd" runat="server" name="textfield92" type="text" style="width: 237px" /></td>
                </tr>
                <tr>
                    <td align="right" height="30">
                        <span class="STYLE9"><span class="cheng">*</span></span> 请输入右边的验证码：</td>
                    <td class="STYLE9" width="16%">
                        <input id="txtValiNo" runat="server" name="textfield9" size="18" type="text" />
                    </td>
                    <td colspan="2">
                        <img src="../ValidateNumber.aspx" name="imgVali" width="60" height="20" align="absmiddle"
                            id="imgVali" />
                        <a class="font12 bule" href="javascript:;" onclick="refreshVerifyCode();return false;">
                            看不清楚换一张</a></td>
                </tr>
                <tr>
                    <td align="center" class="font12" colspan="4" height="28">
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
                            &nbsp;<asp:Button ID="btnNext" CssClass="buttomal" runat="server" OnClick="btnNext_Click"
                                Text="下一步" Width="95px" /></label></td>
                    <td height="27" width="37%">
                        &nbsp;<input id="Button1" class="buttomal" onclick="window.location.href='account_cz.aspx'"
                            style="width: 85px" type="button" value="返 回" /></td>
                    <td align="center" height="27" style="width: 113px">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
