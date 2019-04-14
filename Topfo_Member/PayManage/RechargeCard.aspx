<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RechargeCard.aspx.cs" Inherits="PayManage_RechargeCard" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="../../css/publish.css" rel="stylesheet" type="text/css" />
  <link href="../../offer/css/member.css"rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
      function checkinfo()
	{
    var DDes=document.getElementById("ctl00_ContentPlaceHolder1_txtLoginName");
             if(DDes.value=="")
   	        {
   	           alert("请输入充值帐号");
   	           DDes.focus();
   	           return false;
   	        }
   	        
   	         var number=document.getElementById("ctl00_ContentPlaceHolder1_txtNumber");
             if(number.value=="")
   	        {
   	           alert("请输入充值卡号");
   	           number.focus();
   	           return false;
   	        }
   	               var pass=document.getElementById("ctl00_ContentPlaceHolder1_txtpassword");
             if(pass.value=="")
   	        {
   	           alert("请输入充值卡密码");
   	           pass.focus();
   	           return false;
   	        }
   	        
   	    
   	        
   	       
   	            var telMobile=document.getElementById("ctl00_ContentPlaceHolder1_txtMobile");
   	        if(telMobile.value!="")
            {
           
                var filtMobile = /^(13|15|18)[0-9]{9}$/;
                if(!filtMobile.test(telMobile.value))
                {
                    alert("请正确填写手机号码");
                    telMobile.focus();
                    return false;
                }
            }
             var Emiatset=document.getElementById("ctl00_ContentPlaceHolder1_txtEmail");
   	        if(Emiatset.value!="")
            {
               var filtEmial = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
               if(!filtEmial.test(document.getElementById("txtEmail").value))
               {
   	                 alert("电子邮箱格式不正确，请重新输入");
   	                 document.getElementById("txtEmail").focus();
   	                 return false;
   	           }
   	       }
   	     }
    </script>
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">我要充值 >> 充值卡充值</span></span><span class="fr"><img src="http://member.topfo.com/images/jygl.gif" width="16" align="middle" /> 
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
    <td class="account-3-td-r" style="height: 31px"><span class="hong">*</span> 充值帐户：</td>
    <td class="account-3-td-l" style="height: 31px"><asp:TextBox ID="txtLoginName" runat="server" Text="" CssClass="pawwword-input"></asp:TextBox>
     <span class="f_12px fc30">请输入您要充值的会员名</span></td>
  </tr>
  <tr>
    <td class="account-3-td-r"><span class="hong">*</span>充值卡号：</td>
    <td class="account-3-td-l"><asp:TextBox ID="txtNumber" runat="server" Text="" CssClass="pawwword-input"></asp:TextBox>
    <span class="f_12px fc30">输入充值卡卡号</span></td>
  </tr>
    <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 充值卡密码：</td>
    <td class="account-3-td-l"> <asp:TextBox ID="txtpassword" runat="server" Text="" CssClass="pawwword-input" TextMode="Password"></asp:TextBox>
                             <span class="f_12px fc30">请输入充值卡密码 </span>
    </td>
  </tr>

   <tr>
    <td class="account-3-td-r"><span class="hong"></span> 电子邮箱：</td>
    <td class="account-3-td-l"> <asp:TextBox ID="txtEmail" runat="server" Text="" CssClass="pawwword-input" ></asp:TextBox>
                             <span class="f_12px fc30">请输入电子邮箱 </span>
    </td>
  </tr>
  <tr>
    <td class="account-3-td-r"><span class="hong"></span> 电话号码：</td>
    <td class="account-3-td-l">  <input id="txtTelCountry" runat="server" type="text" size='4' value="+86" onkeyup="value=value.replace(/[^\d]/g,'')"  />
                        <input id="txtTelZoneCode" runat="server" type="text" size='7' onkeyup="value=value.replace(/[^\d]/g,'')"  />
                        <input id="txtTelNumber" runat="server" type="text" size='18' onkeyup="value=value.replace(/[^\d]/g,'')"  />
                             <span class="f_12px fc30">请输入电话号码 </span>
    </td>
  </tr>
  <tr>
    <td class="account-3-td-r"> 手机号码：</td>
    <td class="account-3-td-l">          <input runat="server" id="txtMobile" type="text"  onkeyup="value=value.replace(/[^\d]/g,'')" />
                             <span class="f_12px fc30">请输入手机号码 </span>
    </td>
  </tr>
  <tr>
    <td class="account-3-td-r"><span class="hong">*</span> 备注信息：</td>
    <td class="account-3-td-l">  <asp:TextBox ID="txtBank" runat="server" Height="44px" TextMode="MultiLine" Width="208px"></asp:TextBox>
                             <span class="f_12px fc30">请输入备注信息</span>
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
</asp:Content>
