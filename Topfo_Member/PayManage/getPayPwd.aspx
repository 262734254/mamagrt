<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ResponseEncoding="GB2312" Title="修改支付密码-拓富中心-中国招商投资网" AutoEventWireup="true" CodeFile="getPayPwd.aspx.cs" Inherits="PayManage_getPayPwd" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <link href="/css/common.css" rel="stylesheet" type="text/css" />
    <link href="/css/accountinfo.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    function chkpwd()
    {
       if($id("txtPayPwd1").value==""||$id("txtPayPwd1").value.length<6||$id("txtPayPwd1").value.length>16)
      {
         alert("支付密码必须要6-16位!");
         $id("txtPayPwd1").focus();
        return false;
      }
      if($id("txtPayPwd2").value=="")
      {
         alert("请确认支付密码!");
         $id("txtPayPwd2").focus();
         return false;
      }
      if($id("txtPayPwd1").value!=$id("txtPayPwd2").value)
      {
        alert("两次输入的支付密码不一致!");
        $id("txtPayPwd2").focus();
        return false;
      }
    }
   function $id(obj)
	{
	     return document.getElementById("ctl00$ContentPlaceHolder1$"+obj);
	}
    </script>
 
        <div id="divq" runat="server">
            支付密码问题：<asp:Label ID="lblQuestion" runat="server"></asp:Label><br />
            <br />
            支付密码答案：<input id="txtAnswer" runat="server" type="text" /><br />
            <br />
            <input id="Button1" type="button" value="提 交" onserverclick="Button1_ServerClick"
                runat="server" /><br />
            <br />
        </div>
        <div id="divp" runat="server" visible="false">
            设置新的支付密码：<br />
            &nbsp; &nbsp; &nbsp; 新的支付密码：<input id="txtPayPwd1" runat="server" type="password" /><br />
            &nbsp; &nbsp; &nbsp; 确认支付密码：<input id="txtPayPwd2" runat="server" type="password" /><br />
            <br />
            <asp:Button ID="btnSetPwd" runat="server" Text="设置" Width="68px" OnClick="btnSetPwd_Click" /><br />
        </div>
 
</asp:Content>