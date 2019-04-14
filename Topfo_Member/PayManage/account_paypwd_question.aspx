<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="account_paypwd_question.aspx.cs" Inherits="PayManage_account_paypwd_question" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript">
    function chkQuestion()
    {
         if($id("txtQuestion").value=="")
        {
        
            alert("请填写密码保护问题");
            $id("txtQuestion").focus();
            return false;
        }
        if($id("txtAnswer").value=="")
        {
            alert("请填写密码保护答案!");
            $id("txtAnswer").focus();
            return false;
        }
        if($id("txtEmail").value=="")
        {
            alert("请填写密码保护邮箱,用于取回你的密码!");
            $id("txtEmail").focus();
            return false;
        }
    }
    function changeQuestion(obj)
    {
        if(obj=="0")
        {
           
            $id("txtQuestion").value="";
        }
        else
        {
           
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
      <h1><span class="fl"><span class="f_14px strong f_cen">设置密码保护</span></span></h1>
    
        <div class="change-password " runat="server" id="divAnswer">
                    <p>
                        请输入您原来的安全保护问题答案</p>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="account-3-td-r">
                                您的问题：</td>
                            <td class="account-3-td-l">
                                &nbsp;<asp:Label ID="lblquestion" CssClass="pawwword-input" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="account-3-td-r">
                                答案：</td>
                            <td class="account-3-td-l">
                                &nbsp;<input id="txtAsk" class="pawwword-input" type="text" runat="server" /></td>
                        </tr>
                          <tr>
                        <td >&nbsp;</td>
                        <td >
                        <asp:ImageButton runat="server" ID="btnNext" OnClick="btnNext_Click" ImageUrl="http://img2.topfo.com/member/images/member_btn-003.jpg" />
                        </td>
                      </tr>
                    </table>
                </div>
        <div class="change-password" runat="server" id="divQuestion">
         <p>
          提醒：您还没有设置密码保护，为了您的帐号安全，请尽快在下面设置。
         </p>
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td class="account-3-td-r">密码保护问题：</td>
    <td class="account-3-td-l">
    <select name="select" id="sQuestion" runat="server" onchange="changeQuestion(this.value)">
    <option selected="selected" value="">请选择密码保护问题!</option>
    <option value="您最喜欢的历史人物是谁">您最喜欢的历史人物是谁?</option>
    <option value="您毕业的中学叫什么名字">您毕业的中学叫什么名字?</option>
    <option value="您毕业的大学叫什么名字">您毕业的大学叫什么名字?</option>
    <option value="0">自定义问题</option>
</select>
    </td>
  </tr>
  <tr>
    <td class="account-3-td-r">密码保护问题：</td>
    <td class="account-3-td-l"><input id="txtQuestion" runat="server" type="text"  class="pawwword-input"/></td>
  </tr>
  <tr>
    <td class="account-3-td-r">密码保护答案：</td>
    <td class="account-3-td-l"><input id="txtAnswer" runat="server" type="text" class="pawwword-input"/></td>
  </tr>
  <tr>
    <td class="account-3-td-r">安全电子邮箱：</td>
    <td class="account-3-td-l"><input id="txtEmail" runat="server" type="text" class="pawwword-input"/></td>
  </tr>
  <tr>
    <td >&nbsp;</td>
    <td ><asp:ImageButton runat="server" ID="btnEnter" OnClientClick="return chkQuestion();" OnClick="btnEnter_Click" ImageUrl="http://img2.topfo.com/member/images/member_btn-003.jpg" />
   </td>
  </tr>
</table>
        </div>
      </div>
</div>
</asp:Content>

