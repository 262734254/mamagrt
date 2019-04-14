<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="SendView.aspx.cs" Inherits="InnerInfo_Send2" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<!--
<link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />
-->
    <script src="../JavaScript/FriendList.js"></script>
<style type="text/css">
.note
{
	float:left;
	text-align:left;
	font-size:12px;
	color:#999999;
	padding:3px;
	line-height:130%;
	background:#ffffff;
	border:#ffffff 1px solid;
}
.notetrue
{
	float:left;
	text-align:left;
	font-size:12px;
	padding:3px;
	line-height:130%;
	color:#485E00;
	background:#F7FFDD;
	border:#485E00 1px solid;
}
.noteawoke
{
	float:left;
	text-align:left;
	padding:3px;
	line-height:130%;
	background:#fff5d8;
	border:#ff7300 1px solid;
	background-image:url("http://member.topfo.com/images/icon_noteawake_16x16.gif");
	background-repeat:no-repeat;
	background-position:2 3px;
}
</style>
    <script type="text/javascript" language="javascript">
   var opionText="";    
   var itemValue = '';
   var IsChange=0;
   function changed()
   {
      var txt=document.getElementById('ctl00_ContentPlaceHolder1_txtReceivedMan');
      if(txt.value=='请输入收件人昵称')
      {
        txt.value='';
      }
      else
      {
        IsChange=1;
      }
   }
   
   function FillToTxtFeild() 
   {
    var getMember=1;
    var listFeild = document.getElementById('ctl00_ContentPlaceHolder1_lstFriend');
    var textFeild = document.getElementById('ctl00_ContentPlaceHolder1_txtReceivedMan');
    if(textFeild.value=='请输入收件人昵称')
    {
        textFeild.value='';
    }
    var a ;
    var max = listFeild.options.length ;
  
    for (var i= 0 ;i < max;i++) 
    {
		if(listFeild.options[i].selected)
		{			
			itemValue += listFeild.options[i].value;
			itemValue += ',';			 
			
			if(IsChange==0)
			{
                 a  = opionText.split(","); 
            }
            else
            {
                a = textFeild.value.split(",");
                opionText = textFeild.value;
                if(opionText.Right!=",")
                {
                    //alert(opionText.Right);
                    opionText = opionText+",";
                }
            }
            for(var j=0;j<a.length;j++)
            {            
                 if(listFeild.options[i].text==a[j])
                 {
                    getMember=0;//是否己添加譔联系人
                    break;
			     }
			 }
			 if(getMember==1)
			 {
			    opionText += listFeild.options[i].text;
			    opionText += ',';			  
			    textFeild.value = opionText;   			   
			 }  	    
		 }
    }
}

function checkByteLength(str,minlen,maxlen) {
	if (str == null) return false;
	var l = str.length;
	var blen = 0;
	for(i=0; i<l; i++) {
		if ((str.charCodeAt(i) & 0xff00) != 0) {
			blen ++;
		}
		blen ++;
	}
	if (blen > maxlen || blen < minlen) {
		return false;
	}
	return true;
} 

function checkContent()
{
    var id = "<%=this.txtContext.ClientID %>";
    var obj = document.getElementById(id);
    if(obj.value == "")
    {
        document.getElementById("spContext").innerHTML = "&nbsp;&nbsp;&nbsp;请填写短信内容！";
        document.getElementById("spContext").className = "noteawoke";
        obj.focus();
        return false;
    }
    else if(!checkByteLength(obj.value,1,1000))
    {
        document.getElementById("spContext").innerHTML = "&nbsp;&nbsp;&nbsp;短信内容不得超过500字！";
        document.getElementById("spContext").className = "noteawoke";
        obj.focus();
        return false;
    }
    else
    {
        document.getElementById("spContext").innerHTML = "";
        document.getElementById("spContext").className = "";
        return true;
    }
}
function CheckForm()
{
    var revalue = true;
    if(!checkContent()){
        if(revalue) revalue = false;}    
    return revalue;
}
document.getElementById("aspnetForm").onsubmit = CheckForm;

    </script>
    

    <div class="mainconbox">
        <div class="topzi">
            <div class="left">
                我的短信息</div>
            <div class="right">
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="blank0">
        </div>
        <div class="handtop">
            <ul>
                <li class="liwai"><a href="SendView.aspx">发送短消息</a></li><li><a href="inbox2.aspx">我收到的消息</a>
                </li>
                <li><a href="SendBox2.aspx">我发出的短消息</a> </li>
                <li><a href="waster2.aspx">回收站</a></li></ul>
        </div>
        <div class=" cshibiank">
            <div class="blank20">
            </div>
            <table width="73%" border="0" cellpadding="4" cellspacing="0" class="float_all">
                <tr>
                    <td width="16%" align="right" style="height: 21px">
                        收件人：</td>
                    <td style="height: 21px">
                        <label>
                            <asp:TextBox ID="txtReceivedMan" runat="server" CssClass="input1" EnableViewState="False"
                                Width="398px" onclick="changed()" Text="请输入收件人昵称"></asp:TextBox>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 21px">
                        主题：</td>
                    <td style="height: 21px">
                        <asp:TextBox ID="txtTopic" runat="server" CssClass="input1" EnableViewState="False"
                            Width="396px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        内容：</td>
                    <td>
                        <asp:TextBox ID="txtContext" runat="server" CssClass="input1" EnableViewState="False"
                            Height="181px" MaxLength="1000" TextMode="MultiLine" onchange="JavaScrpit:checkContent()" Width="396px"></asp:TextBox>
                        <span id="spContext"></span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 21px">&nbsp;
                        </td>
                    <td style="height: 21px">
                        <p>
                            &nbsp;<asp:CheckBox ID="cbIsSave" runat="server" Text="发送的同时保存到发件箱" /></p>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;
                        </td>
                    <td height="50" align="center">
                        <label>
							<asp:Button ID="butSend" runat="server" Text="发 送" OnClick="butSend_Click" CssClass="buttomal" />
                        </label>
                    </td>
                </tr>
            </table>
            <div class="sendlist" >
                <h1 >
                    好友列表</h1>
                <p>
                    <asp:ListBox ID="lstFriend" runat="server" DataTextField="" DataValueField="" Height="231px"
                        Rows="5" Width="149px" onclick="FillToTxtFeild()"></asp:ListBox>
                   </p>  <div style="width: 149px; padding: 10px 0 20px 0; text-align:center">
               <img src="../images/PayManage/hand.gif" /> <a href="http://member.topfo.com/helper/FriendManager/FriendList.aspx">管理我的好友</a></div>
            </div>
          
            <div class="clear">
            </div> <div class="blank20">
        </div>
        </div>
       
    </div>
</asp:Content>
