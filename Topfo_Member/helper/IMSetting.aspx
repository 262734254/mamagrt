<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMSetting.aspx.cs" Inherits="helper_IMSetting" MasterPageFile="~/MasterPage.master" %>
<%@ Register Assembly="Tz888.Common" Namespace="Tz888.Common.Pager" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />

        <div class="mainconbox">
            <div class="topzi">
                <div class="left">
                    在线洽谈设置</div>
                <div class="right">
                    <img src="http://member.topfo.com/images/jygl.gif" width="16" align="absmiddle" />
                    <a href="http://www.topfo.com/help/chatonline.shtml" target="_blank">在线洽谈设置的好处</a></div>
                <div class="clear">
                </div>
            </div>
            <div class="blank6">
            </div>
            <div class="smsconbox cshibiank">
                <h1 class="lightc dottedl">
                    <span class="chengcu">把握机会就在瞬间</span>——请启用你最常用的在线交流工具，启用后将在网页上显示你的在线状态，对口客户可以即时与你联系或者进行留言。如未设置将自动启用在线留言。
                </h1>
                <div class="blank20">
                </div>
                <table width="78%" height="75" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="40" align="center">&nbsp;                            </td>
                        <td height="40" colspan="2" align="left" class="chengcu">
                            请选择您的在线洽谈工具：<span style="font-size: 10pt; color: #000000; font-weight:normal; font-family: 宋体";><asp:Label
                                ID="lbMessage" runat="server" Text=""></asp:Label></span></td>
                    </tr>
                    <tr>
                        <td width="20%" align="right" style="height: 24px">&nbsp;                            </td>
                        <td width="14%" align="left" style="height: 24px">
                            <input id="radioQQ" name="a" type="radio" runat="server" onclick='setting("QQ")'/>QQ</td>
                        <td width="66%" style="height: 24px">
                                <input id="tbQQ" style="width: 154px" type="text" runat="server" onblur="checkIM()" />
                            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 27px">&nbsp;                            </td>
                        <td align="left" style="height: 27px">
                            <input id="radioMSN" name="a" type="radio" runat="server" onclick='setting("MSN")'  />MSN                            </td>
                        <td style="height: 27px">
                            <input id="tbMSN" style="width: 155px" type="text" runat="server" onblur="checkIM()" />
                            <asp:Label ID="Label2" runat="server" ForeColor="Red"></asp:Label></td>
                        <tr>
                            <td align="right" style="height: 27px">&nbsp;                                </td>
                            <td align="left" style="height: 27px">
                                <input id="radioWW" name="a" type="radio" runat="server"  onclick='setting("旺旺")' />旺旺                                </td>
                            <td style="height: 27px">
                                <input id="tbWW" style="width: 156px" type="text" runat="server" onblur="checkIM()" />
                                <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 27px">&nbsp;                                </td>
                            <td align="left" style="height: 27px">
                                <input id="radioYHT" name="a" type="radio" runat="server" onclick='setting("雅虎通")' />雅虎通                            </td>
                            <td style="height: 27px">
                                <input id="tbYHT" style="width: 155px" type="text" runat="server" onblur="checkIM()" />
                                <asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 27px">&nbsp;                                </td>
                            <td colspan="2" align="left" style="height: 27px">
                                <asp:CheckBox ID="cbIsDisable" runat="server" Text="取消在线洽谈" />
                                </td>
                        </tr>
						<tr>
                            <td align="right" style="height: 35px">&nbsp;</td>
                            <td align="left" style="height: 35px"><asp:Button CssClass="buttomal" ID="btSet" runat="server" Text=" 设 置 " OnClick="btSet_Click" /></td>
                            <td valign="bottom" style="height: 35px">
                                <asp:Label ID="lbCheck" runat="server" ForeColor="Red"></asp:Label></td>
                        </tr>
                </table>
                <div class="blank20">
                </div>
            </div>
        </div>
<script>

function setting(str)
{
      var lb = $id("lbMessage");
      var lb2 = $id("Label1");
      var tbQQ =$id("tbQQ");
      var tbMSN =$id("tbMSN");     
      var tbWW = $id("tbWW");     
      var tbYHT = $id("tbYHT"); 
      
      var lb1 = $id("Label1");lb1.innerHTML="";
      var lb2 = $id("Label2");lb2.innerHTML="";
      var lb3 = $id("Label3");lb3.innerHTML="";
      var lb4 = $id("Label4");lb4.innerHTML="";
    /*           
      var tbQQ =$id("tbQQ");
      var tbMSN =$id("tbMSN");     
      var tbWW = $id("tbWW");     
      var tbYHT = $id("tbYHT"); 
      
      if(str=="QQ") { tbQQ.disabled=true;tbMSN.disabled=false;tbWW.disabled=false;tbYHT.disabled=false;}
      else if(str=="MSN") {tbQQ.disabled=false;tbMSN.disabled=true;tbWW.disabled=false;tbYHT.disabled=false;}
      else if(str=="旺旺"){ tbQQ.disabled=false;tbMSN.disabled=false;tbWW.disabled=true;tbYHT.disabled=false;}
      else(str=="雅虎通") {tbQQ.disabled=false;tbMSN.disabled=false;tbWW.disabled=false;tbYHT.disabled=true;}*/
      
      lb.innerHTML = "请输入您的<font color='red'>"+str+"</font>账号"; lb2.innerHTML ="";
      tbQQ.value = "";     tbMSN.value = "";     tbWW.value = "";     tbYHT.value = "";      
}
function $id(obj)
{
    return document.getElementById("ctl00_ContentPlaceHolder1_"+obj);
}
function checkIM()
{
      var lb1 = $id("Label1");
      var lb2 = $id("Label2");
      var lb3 = $id("Label3");
      var lb4 = $id("Label4");
      var lb = $id("lbMessage");
            
      var tbQQ =$id("tbQQ");
      var tbMSN =$id("tbMSN");     
      var tbWW = $id("tbWW");     
      var tbYHT = $id("tbYHT"); 
      
      var radioQQ= $id("radioQQ");
      var radioMSN= $id("radioMSN");
      var radioWW= $id("radioWW");
      var radioYHT=$id("radioYHT");
      var bl=true;
      
      if(radioQQ.checked) 
      { 
       if(tbQQ.value=="")
       {
         lb1.innerHTML="请输入QQ账号！";  bl= false;
       }
//       else
//       {
////          var reg = /^\d{4,100}$/;
////          if(!reg.test(tbQQ.value)) {  lb1.innerHTML = "QQ账号输入不正确!"; bl= false;}
////          else {lb1.innerHTML=""; }
//       }
      }
      else if(radioMSN.checked)
      {
        if(tbMSN.value=="")
       {
          lb2.innerHTML="请输入MSN账号！"; bl= false;
       }
       else
       {
          var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
          if(!filter.test(tbMSN.value))   {lb2.innerHTML = "MSN账号输入不正确!";bl= false;}
          else {lb2.innerHTML=""; }
       }
      }     
      else if(radioWW.checked)
      {
        if(tbWW.value=="")
       {
        lb3.innerHTML="请输入旺旺账号！"; bl= false;
       }
     } 
     else if(radioYHT.checked)
      {
        if(tbYHT.value=="")
       {
        lb4.innerHTML="请输入雅虎通账号！"; bl= false;
       }
       else
       {
          var filter = /^[_a-zA-Z0-9\-]+(\.[_a-zA-Z0-9\-]*)*@[a-zA-Z0-9\-]+([\.][a-zA-Z0-9\-]+)+$/;
          if(!filter.test(tbYHT.value))  { lb4.innerHTML = "雅虎通账号输入不正确!"; bl= false;}
          else {lb4.innerHTML=""; }
       }
      }
      else
      {
         lb.innerHTML="<font color='red'>您没有输入任何数据！</font>";
         bl=false;
      } 
      return bl;    
}
</script>
</asp:Content>

