<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    ResponseEncoding="GB2312" CodeFile="SendInfo.aspx.cs" Inherits="InnerInfo_SendInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/messagemanage.css" rel="stylesheet" type="text/css" />

    <script src="../JavaScript/FriendList.js"></script>

    <div id="mainconbox">
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
                <li class="liwai">发送短消息</li>
                <li>我收到的消息 </li>
                <li>我发出的消息 </li>
                <li>回收站</li>
            </ul>
        </div>
        <div class=" cshibiank">
            <div class="blank8">
            </div>
            <table width="73%" border="0" cellpadding="4" cellspacing="0" class="float_all">
                <tr>
                    <td width="16%" align="right" style="height: 21px">
                        收件人：</td>
                    <td style="height: 21px">
                        <label>
                            <asp:TextBox ID="txtReceivedMan" runat="server" CssClass="input1" EnableViewState="False"
                                Width="398px" onclick="changed()"></asp:TextBox></label></td>
                </tr>
                <tr>
                    <td align="right" style="height: 21px">
                        主题：</td>
                    <td style="height: 21px">
                        <asp:TextBox ID="txtTopic" runat="server" CssClass="input1" EnableViewState="False"
                            MaxLength="25" Width="354px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        内容：</td>
                    <td>
                        <asp:TextBox ID="txtContext" runat="server" CssClass="input1" EnableViewState="False"
                            Height="181px" MaxLength="1000" TextMode="MultiLine" Width="476px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="height: 21px">
                        &nbsp;</td>
                    <td style="height: 21px">
                        <p>
                            &nbsp;<asp:CheckBox ID="cbIsSave" runat="server" Text="发送的同时保存到发件箱" /></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td height="50" align="center">
                        <label>
                            <input name="button3" type="submit" id="button3" value="预 览" />&nbsp;<asp:Button
                                ID="butSend" runat="server" OnClick="butSend_Click" Text="发 送" />
                        </label>
                    </td>
                </tr>
            </table>
            <div class="sendlist" style="height: 280px">
                <h1 class="lightc">
                    好友列表</h1>
                <p>
                    <asp:ListBox ID="lstFriend" runat="server" DataTextField="" DataValueField="" Height="231px"
                        Rows="5" Width="149px" onclick="FillToTxtFeild()"></asp:ListBox>&nbsp;</p>
            </div>
            <div style="width: 600px; float: right; text-align: right; padding: 5px 100px 10px 0">
                <a href="#">管理我的好友</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="blank20">
        </div>
    </div>

    <script>
   var opionText="";    
   var itemValue = '';
   var IsChange=0;
   function changed()
   {
      IsChange=1;
   }
   
   function FillToTxtFeild() 
   {
    var getMember=1;
    var listFeild = document.getElementById('lstFriend');
    var textFeild = document.getElementById('txtReceivedMan');
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

    </script>

</asp:Content>
