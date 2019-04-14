<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPD.aspx.cs" Inherits="LoginPD" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>拓富-中国招商投资网</title>
    <link href="css/load.css" rel="stylesheet" type="text/css" />
    <script src="javascript/OPCookie.js"></script>
<style>
<!--
p{ padding:0; margin:0;}
body{ font-size: 12px;color: #000000; line-height: 180%; font-family: "宋体";margin:0;padding:0; }
a.spaces:link    {}
a.spaces:visited {}
a.spaces:active  {}
a.spaces:hover   {left: 1px;top: 1px;position: relative;}
a:link,a:visited,a:active {	COLOR: #000000; TEXT-DECORaTION: none} /* 默认样式 */
a:hover{COLOR: #ff0000;text-decoration: underline;}
.padlg{padding:10px 0 8px 0}
.padlg2{
padding:8px 5px 0 5px;
}
.channelLog{
	text-align:center;
	margin-bottom: 8px;
	padding-top: 37px; background-color:transparent;
}
.c_inpugt{width:90px;}
.channelLog span{font-weight:bold;color:#ff6600;}
.channelLog  .m20{}
.btopt {
	background-image: url(images/login/btoptbg.gif);
	background-repeat: no-repeat;
}
.atopt {
	background-repeat: no-repeat;
	padding: 0 15px 0 15px;
}
.atopt .left{
	width: 70px;
	float: left;
}	
.atopt .right{
	width: 90px;
	float: right;
	text-align: right;
	font-weight: normal;
}	
.btopt h1{
	font-size: 12px;
	font-weight: normal;
	text-align: left;
	padding: 10px 0 3px 35px;
	letter-spacing: 1px;
}
.cu{
	font-weight: bold;
}
.bbottomlg{
	background-image: url(images/login/bbottombg.gif);
	background-repeat: no-repeat;
	height: 11px;
	overflow: hidden;
}
-->
</style>
</head>
<body  STYLE="background-color:transparent">

  <form id="Form1" method="post" runat="server">
        <div class="channelLog" id="member_logout" runat="server" >
          <div class="padlg">
                用户名：<asp:TextBox ID="txtUserName" runat="server" class="inpcss" onmouseout="this.className='inpcss'"
                    onmouseover="this.className='oninpcss'" Height="10px" Width="104px"></asp:TextBox></div>
            <div>
                密　码：<asp:TextBox ID="txtPsd" runat="server" class="inpcss" onmouseout="this.className='inpcss'"
                    onmouseover="this.className='oninpcss'" TextMode="Password" Height="10px" Width="104px"></asp:TextBox></div>
           
           
          <div >
            <div style=" text-align:left;margin-left:60px; padding:7px 0 0 0">
             <input name="cbSaveUserName" onclick="Javascript:SetUserNameOnLogin();" type="checkbox"
                    value="cbSaveUserName" />记住用户名</div>
            <div class="padlg2">
			                 <a href="" class="spaces"><asp:ImageButton ID="imbLogin" runat="server" ImageUrl="images/login/buttom_dl.gif" OnClick="imbLogin_Click" 
                    /></a>
                <a href="http://member.topfo.com/Register/Register.aspx" target="_blank" class="spaces"><img src="images/login/buttom_qx.gif" border="0" /></a> <div style="padding:0 10px 0 15px ; text-align:left; height:30px; line-height:120%">
                <asp:Label ID="lblPasswordWrong" runat="server" ForeColor="#C00000" Font-Bold=false></asp:Label><br />
                <asp:Label
                    ID="lblValidate" runat="server" ForeColor="#C00000"  Font-Bold=false></asp:Label></div></div>
          </div>
        </div>

		
        <div class="channelLog" id="member_login" runat="server" > <div style=" padding:5px 0 0 0;">  欢迎您,
                 <asp:Label CssClass="cu"  Font-Bold=true ID="lblNickName" runat="server" ></asp:Label>
        </div>
		  <div class="atopt">你现在已成功登陆为 <br />
		  <asp:Label
                    ID="lblUserType" runat="server"></asp:Label>
	      </div><div class="m20">
             <P style="important;padding:6px 0 6px 0" ><img src="images/login/icon_biao.gif" width="10" height="9" />  <a href="http://member.topfo.com/" target="_blank">进入拓富中心</a></P>
               <img src="images/login/icon_biao.gif" width="10" height="9" /> <br />
              <p align="right" style="padding:8px 15px 18px 0">  <asp:LinkButton ID="linkout" runat="server" OnClick="linkout_Click">>> 退出</asp:LinkButton></p></div>
    </div>
  </form>
		
		
		

</body>
</html>