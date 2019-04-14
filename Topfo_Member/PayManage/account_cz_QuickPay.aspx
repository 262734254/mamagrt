<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account_cz_QuickPay.aspx.cs" Inherits="PayManage_account_cz_QuickPay" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../css/publish.css" rel="stylesheet" type="text/css" />
  <link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />
  <script src="../../offer/js/yanz.js"></script>
      <script type="text/javascript" language="javascript">
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
		if(getE("txtB_Name").value==""||getE("txtB_Name").value!=getE("txtB_ReName").value)
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
    </script>
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">我要充值 >> 银联在线支付</span></span><span class="fr"><img src="http://member.topfo.com/images/jygl.gif" width="16" align="middle" /> 
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
    <td class="account-3-td-l"><asp:TextBox ID="txtB_Name" runat="server" Text="" CssClass="pawwword-input"></asp:TextBox>
     <span class="f_12px fc30">请输入您要充值的会员名</span></td>
  </tr>
  <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 确认充值帐户：</td>
    <td class="account-3-td-l"><asp:TextBox ID="txtB_ReName" runat="server" Text="" CssClass="pawwword-input"></asp:TextBox>
    <span class="f_12px fc30">再次确认充值的帐号</span></td>
  </tr>
    <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 充值金额：</td>
    <td class="account-3-td-l"> <asp:TextBox ID="txtB_PayPoint" runat="server" Text="" CssClass="pawwword-input"></asp:TextBox>
                            元 <span class="hui font12 ">您可以填写0－5000之间的任意金额 </span>
    </td>
  </tr>

    <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 请输入右边的验证码：</td>
    <td class="account-3-td-l"><input type="text" id="validCode"  /> 
    <input onClick="createCode()" readonly="readonly" id="checkCode" type="text"  />
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td height="40">
    <asp:Button ID="Button1" CssClass="btn-002 f_14px" OnClick="Button1_Click" OnClientClick="return checkinfo();"  runat="server"  Text="确定"  />
    <input id="Button2" class="btn-002 f_14px" onclick="window.location.href='account_cz.aspx'" type="button" value="返 回" />
    </td>
  </tr>
</table>

        </div>
      </div>
</div>
<script language="javascript" type="text/javascript"> createCode();</script>
</asp:Content>

