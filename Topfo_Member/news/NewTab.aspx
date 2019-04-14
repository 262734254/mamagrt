<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewTab.aspx.cs" Inherits="news_NewTab" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="http://img2.topfo.com/member/css/payment.css" rel="stylesheet" type="text/css" />

<link href="http://img2.topfo.com/member/css/common.css" rel="stylesheet" type="text/css" />
<link href="http://img2.topfo.com/member/css/frist-page.css" rel="stylesheet" type="text/css" />
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
      if(document.getElementById ("txtyanzheng").value.length==0)
   {
     document.getElementById ("showpostcode").innerHTML="*";
     document.getElementById ("showpostcode").style .display ="inline";
     document.getElementById ("txtyanzheng").focus();
     return false;
   }
    if(document.getElementById("txtyanzheng").value.toUpperCase()!=document.getElementById("checkCode").value)
     {
     document.getElementById ("showpostcode").innerHTML ="验证码错误";
     document.getElementById ("showpostcode").style .display ="inline";
     document.getElementById ("txtyanzheng").focus();
     createCode()  ;
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
         <div>
          <div class="member-right">
    <div class="publication">
      <h1><span class="fl"><span class="f_14px strong f_cen">发布资讯</span>(带<span class="hong">*</span>为必填项)</span><span class="fr"><img src="http://img2.topfo.com/member/images/biao_01.gif" align="absMiddle"/> <a href="http://www.topfo.com/help/demandrelease.shtml#16" class="publica-fbxq">需求发布规则</a></span></h1>

    <table width="100%"  cellpadding="0" cellspacing="0"    class="publica">
    			<tr >
				<th colSpan="2">
				</th>
			</tr>
    <tr><td><span style ="color:Red">*</span>标题：</td><td >
        <asp:TextBox ID="txtnewsTitle"  onblur="outpostcode(this,'showtxtnewsTitle')"  runat="server" Width="278px"></asp:TextBox>&nbsp;<div id="showtxtnewsTitle" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
        <tr><td><span style ="color:Red">*</span>类型：</td><td >
        <asp:DropDownList ID="ddrtype" runat="server">
        </asp:DropDownList></td></tr>
    <tr><td><span style ="color:Red">*</span>内容：</td><td >
        <textarea id="FreeTextBox1" onblur="outpostcode(this,'showcontext')" runat="server"  cols="48" rows="7"></textarea>
                        &nbsp;<div id="showcontext" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>作者：</td><td >
        <asp:TextBox ID="txtauthor" onblur="outpostcode(this,'showauthor')" Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showauthor" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
    <tr><td><span style ="color:Red">*</span>来源：</td><td >
        <asp:TextBox ID="txtform" onblur="outpostcode(this,'showlaiyuan')"  Width="278px" runat="server"></asp:TextBox>&nbsp;<div id="showlaiyuan" style ="display:none; color:Red ; font-size:12px">*</div></td></tr>
              <tr>
                <td>
                    <span style ="color:Red">* </span>验证：</td>
                <td >
                <input  type="text" id="txtyanzheng" onblur ="outpostcode(this,'showpostcode')" /> 
                   <input type="text"  onClick="createCode()" readonly="readonly" id="checkCode" class="unchanged" style="width: 80px;cursor:pointer"  />&nbsp;<div id="showpostcode" style ="display:none; color:Red ; font-size:12px">*</div>
     <!-- </label>-->
                </td>
            </tr>
    <tr><td colspan="2" align="center">
                 <input name="" type="checkbox" value="" checked />
             <a href="#" class="publica-fbxq" >我已阅读并同意《拓富中国招商投资网服务协议》</a>  <br />
        <asp:ImageButton ID="ImageButton1" OnClientClick="return postnewtabs()" runat="server"  ImageUrl="http://img2.topfo.com/member/images/member-btn-tj.jpg" OnClick="btnSave_Click"/>
       </td></tr>
    </table>
    </div>
    </div></div>

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
          <script language="javascript">  createCode();</script>
</asp:Content>

