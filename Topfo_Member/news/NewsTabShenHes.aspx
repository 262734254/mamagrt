<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewsTabShenHes.aspx.cs" Inherits="news_NewsTabShenHes" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/payment.css" rel="stylesheet" type="text/css" />
    <link href="../offer/css/member.css" rel="stylesheet" type="text/css" />
     <script  src="../js/JScriptloans.js" type ="text/javascript" language="javascript"></script>
     
       <script type ="text/javascript" language ="javascript">
           function postnewtabs()
   {
  if(document.getElementById ("ctl00_ContentPlaceHolder1_txtnewsTitle").value.length==0)
   {
     document.getElementById ("showtxtnewsTitle").innerHTML="*";
     document.getElementById ("showtxtnewsTitle").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtnewsTitle").focus();
     return false;
   }  
      if(document.getElementById ("ctl00_ContentPlaceHolder1_FreeTextBox1").value.length==0)
   {
     document.getElementById ("showcontext").innerHTML="*";
     document.getElementById ("showcontext").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_FreeTextBox1").focus();
     return false;
   }
     if(document.getElementById ("ctl00_ContentPlaceHolder1_txtauthor").value.length==0)
   {
     document.getElementById ("showauthor").innerHTML="*";
     document.getElementById ("showauthor").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtauthor").focus();
     return false;
   }
   if(document.getElementById ("ctl00_ContentPlaceHolder1_txtform").value.length==0)
   {
     document.getElementById ("showlaiyuan").innerHTML="*";
     document.getElementById ("showlaiyuan").style .display ="inline";
     document.getElementById ("ctl00_ContentPlaceHolder1_txtform").focus();
     return false;
   }

   else
   {
  return true;
}
  }
    function s()
  {
      document.getElementById ("ctl00_ContentPlaceHolder1_imgLoding").style .display ="";
  }
         </script>
                  <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">修改资讯</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>

    <table width="100%"  cellpadding="0" cellspacing="0"    class="publica">
    <tr><td><span style ="color:Red">*</span>标题：</td><td >
        <asp:TextBox ID="txtnewsTitle" onblur="outpostcode(this,'showtxtnewsTitle')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showtxtnewsTitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>类型：</td><td >
        <asp:DropDownList ID="ddrtype" runat="server">
        </asp:DropDownList></td></tr>
    <tr><td><span style ="color:Red">*</span>内容：</td><td >
        <textarea id="FreeTextBox1" onblur="outpostcode(this,'showcontext')" runat="server" cols="48" rows="7"></textarea>
                        &nbsp;<div id="showcontext" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>作者：</td><td >
        <asp:TextBox ID="txtauthor" onblur="outpostcode(this,'showauthor')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showauthor" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>来源：</td><td >
        <asp:TextBox ID="txtform" onblur="outpostcode(this,'showlaiyuan')" Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showlaiyuan" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>

    <tr><td colspan="3" align="center">
        <asp:Button ID="btnSave" runat="server" CssClass="btn" OnClientClick="return postnewtabs()"  Text="修 改" OnClick="btnSave_Click" />&nbsp;&nbsp;
           <input type="button" id="Button3" onclick="history.back();" value="返 回" class="btn" /></td></tr>
    </table>
    </div>

             <div id="imgLoding" style="position: absolute; 
  display:none; background-color: #A9A9A9; 
  top: 0px; left: 0px; width: 100%;
   height:1135px; filter: 
   alpha(opacity=60);" runat="server">

               <div class="content" style="text-align:center; margin-top:200px">
                <p>
                    数据正在提交,请稍候...</p>
                <img src="../image/loading42.gif"alt="Loading" />
                </div>
   </div>
</asp:Content>

