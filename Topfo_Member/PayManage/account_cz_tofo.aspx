<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account_cz_tofo.aspx.cs" Inherits="PayManage_account_cz_tofo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../css/publish.css" rel="stylesheet" type="text/css" />
  <link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />
  <script src="../../offer/js/yanz.js"></script>
      <script language="javascript" type="text/javascript">
    function $id(obj)
	{
	      return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
	}
	function chkInput()
	{
		var t=$id("txtToptocard");
		var p=$id("txtTopfoPwd");

		if($id("txtLoginName1").value=="")
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
		var inputCode = document.getElementById("validCode").value;   
       if(inputCode.length <=0)   
       {   
           alert("请输入验证码！"); 
            document.getElementById("validCode").focus();
       	         return false;  
       }   
       else if(inputCode.toUpperCase() != code )   
       {   
          alert("验证码输入错误！");   
          createCode();//刷新验证码  
          document.getElementById("validCode").value=""; 
           document.getElementById("validCode").focus();
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
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">我要充值 >> 拓富通充值卡充值</span></span><span class="fr"><img src="http://member.topfo.com/images/jygl.gif" width="16" align="middle" /> 
      <a href="http://www.topfo.com/help/AccountCZ.shtml" class="publica-fbxq" target="_blank">充值流程详解</a> <a class="publica-fbxq" href="http://www.topfo.com/help/AccountInfo.shtml#16" target="_blank">安全交易须知</a></span></h1>

        <div class="chongzhi01">
          <h3>提醒：</h3>
          <ul>
       <li>拓富充值卡可以快速对指定账户进行充值，完成资源购买和其他消费行为。 <a href="http://www.topfo.com/help/AccountCZ.shtml" target="_blank" class="lan1">了解更多</a></li> 
<li>我们准备了多种购买渠道供您选择，方便、快捷！</li> 
<li>如果您有任何疑问，请拨打我们的客服电话：0755-82210116 82212980 <a href="tofocard_buy.aspx" target="_blank" class="lan1">立即购买</a></li>
</ul> 
    
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 充值帐户：</td>
    <td class="account-3-td-l"><input id="txtLoginName1" runat="server" type="text" onblur="valiLoginName()" class="pawwword-input" />
     <span class="f_12px fc30" >请输入您要充值的帐号</span><span id="divmsg"></span></td>
  </tr>
  <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 确认帐户：</td>
    <td class="account-3-td-l"><input id="txtLoginName2" runat="server" type="text" class="pawwword-input" /> 
    <span class="f_12px fc30">再次确认充值的帐号</span></td>
  </tr>
    <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 充值卡号：</td>
    <td class="account-3-td-l"><input id="txtToptocard" runat="server" type="text" class="pawwword-input" /></td>
  </tr>
    <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 充值密码：</td>
    <td class="account-3-td-l"><input id="txtTopfoPwd" runat="server" type="password"  class="pawwword-input" /></td>
  </tr>
    <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 请输入右边的验证码：</td>
    <td class="account-3-td-l"><input type="text" id="validCode" /> 
    <input onClick="createCode()" readonly="readonly" id="checkCode" type="text"  />
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td height="40">
    <asp:Button ID="btnNext" CssClass="btn-002 f_14px" OnClientClick="return chkInput();" runat="server" OnClick="btnNext_Click" Text="下一步"  />
    <input id="Button1" class="btn-002 f_14px" onclick="window.location.href='account_cz.aspx'" type="button" value="返 回" />
    </td>
  </tr>
</table>

        </div>
      </div>
</div>
<script language="javascript" type="text/javascript"> createCode();</script>
</asp:Content>

