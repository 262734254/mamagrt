<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account_paypwd.aspx.cs" Inherits="PayManage_account_paypwd" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
    function chkPwd()
    {
      if($id("txtLoginPwd").value=="")
      {
        alert("请填旧的支付密码!");
        $id("txtLoginPwd").focus();
        return false;
      }
      if($id("txtPayPwd1").value==""||$id("txtPayPwd1").value.length<6||$id("txtPayPwd1").value.length>16)
      {
         alert("支付密码必须�?-16�?");
         $id("txtPayPwd1").focus();
        return false;
      }
      if($id("txtPayPwd2").value=="")
      {
         alert("请确认支付密�?");
         $id("txtPayPwd2").focus();
         return false;
      }
      if($id("txtPayPwd1").value!=$id("txtPayPwd2").value)
      {
        alert("两次输入的支付密码不一�?");
        $id("txtPayPwd2").focus();
        return false;
      }
     
    }
    function chksetpwd()
    {
      if($id("txtsetpwd1").value==""||$id("txtsetpwd1").value.length<6||$id("txtsetpwd1").value.length>16)
      {
         alert("支付密码必须�?-16�?");
         $id("txtsetpwd1").focus();
        return false;
      }
      if($id("txtsetpwd2").value==""||$id("txtsetpwd2").value.length<6||$id("txtsetpwd2").value.length>16)
      {
         alert("支付密码必须�?-16�?");
         $id("txtsetpwd2").focus();
        return false;
      }
      if($id("txtsetpwd1").value!=$id("txtsetpwd2").value)
      {
        alert("两次输入的支付密码不一�?");
        $id("txtsetpwd2").focus();
        return false;
      }
    }
    function changeQuestion(obj)
    {
        if(obj=="0")
        {
            $id("trQuestion").style.display="";
            $id("txtQuestion").value="";
        }
        else
        {
            $id("trQuestion").style.display="none";
            $id("txtQuestion").value=obj;
        }
    }
    function $id(obj)
    {
        return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
    }
    </script>
    
<div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">设置支付密码</span></span></h1>
    
    <div class="change-password " runat="server" id="divsetpwd">
                <p>
          提醒：您还没有设置支付密码，为保障您的交易安全，请尽快在下面设置�?
支付密码�?-16个字符组成，请尽量使用英文字母加数字或符号的组合密码
         </p>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="account-3-td-r">
                            支付密码�?/td>
                        <td class="account-3-td-l">
                            <input id="txtsetpwd1" runat="server" type="password" /></td>
                    </tr>
                    <tr>
                        <td class="account-3-td-r">
                            确认支付密码�?/td>
                        <td class="account-3-td-l">
                            <input id="txtsetpwd2" runat="server" type="password" /></td>
                    </tr>
                    <tr>
            <td>&nbsp;</td>
            <td height="40">
            <asp:ImageButton  runat="server" ID="btnsetpwd" OnClientClick="return chksetpwd();" OnClick="btnsetpwd_Click" ImageUrl="http://img2.topfo.com/member/images/member_btn-003.jpg"/>
            
            </td>
          </tr>
                </table>
            </div>
        <div class="change-password" id="divupdatepwd" runat="server">
         <p>
          提醒：支付密码由6-16个字符组成，请尽量使用英文字母加数字或符号的组合密码
         </p>
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="account-3-td-r">
        旧支付密码：</td>
    <td class="account-3-td-l"><input id="txtLoginPwd" type="password" runat="server" class="pawwword-input" />
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></td>
  </tr>
  <tr>
    <td class="account-3-td-r">
        输入新的支付密码�?/td>
    <td class="account-3-td-l"><input id="txtPayPwd1" type="password" runat="server" class="pawwword-input" /></td>
  </tr>
  <tr>
    <td class="account-3-td-r">
        再次输入支付密码�?/td>
    <td class="account-3-td-l"><input id="txtPayPwd2" type="password" runat="server" class="pawwword-input" /></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td height="40">
    <asp:ImageButton  runat="server" ID="btnChangePwd" OnClientClick="return chkPwd();" OnClick="btnChangePwd_Click" ImageUrl="http://img2.topfo.com/member/images/member_btn-003.jpg"/>
    
    </td>
  </tr>
</table>

        </div>
    
      </div>
</div>
</asp:Content>

