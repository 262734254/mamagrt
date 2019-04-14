
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestLg.aspx.cs" Inherits="TestLg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    
</head>
<body>
    <form id="form1" runat="server">
      <div class="rrcont">
                <div class="login">
                    <div class="loginbg1">
                    </div>
                    <div class="logcon">
                        <h3>
                            <asp:Label ID="Label1" runat="server" Text="已经是拓富会员"></asp:Label>&nbsp;</h3>
                        <div class="reinput3">
                            请输入用户名和密码
                            </div>
                        <div class="reinput">
                            用户名：<asp:TextBox runat="server" ID="txtUserName" class="inpcss" onmouseover="this.className='oninpcss'"
                                onmouseout="this.className='inpcss'"></asp:TextBox></div>
                        <div class="reinput">
                            密&nbsp; 码：<asp:TextBox runat="server" ID="txtPsd" class="inpcss" onmouseover="this.className='oninpcss'"
                                onmouseout="this.className='inpcss'" TextMode="Password"></asp:TextBox></div>
                        <div class="reinput2">
                            <input name="cbSaveUserName" id="cbSaveUserName" onclick="Javascript:SetUserNameOnLogin();" type="checkbox"
                                value="cbSaveUserName" />记住用户名<br />
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblPasswordWrong" ForeColor="#C00000"></asp:Label>
                        </div>
                        <div>
                            <asp:Label runat="server" ID="lblValidate" ForeColor="#C00000"></asp:Label>
                        </div>
                        <div>
                            <a href="" class="Spaces">&nbsp;</a><asp:ImageButton ID="imbLogin" runat="server"
                                ImageUrl="images/load/btn_1.gif" OnClick="imbLogin_Click" /></div>
                        <div class="password">
                            <a  href="http://member.topfo.com/Register/RetrieveStep1.aspx" target="_blank">
                                忘记密码</a><a href="http://www.topfo.com/help/register.shtml#15" target="_blank">设置安全密码</a><a
                                    href="http://www.topfo.com/help/login.shtml" target="_blank">登陆帮助</a></div>
                        <div style="height:19px; background:url(images/icr_picline.gif) no-repeat;">
                        
                           </div>
                        <div>
                            <span class="bold f14t">如果您还不是拓富会员</span><br />
                            <span class="bold">注册非常快速、简便！</span>
                        </div>
                        <div>
                            <a href="Register/Register.aspx" class="Spaces">
                                <img src="images/load/btn_2.gif" id="IMG1" onclick="return IMG1_onclick()" /></a>
                            <br />
                       <a href="http://www.topfo.com/Service/enterprisemember.shtml" target="_blank"><span class="gtext">[点这里 ，查看拓富通会员服务]</span></a> </div>
                  </div>
                    <div class="loginbg2">
                    </div>
                </div>
                <div class="faq">
                    <div class="faqbg1">
                    </div>
                    <div class="fagcon">
                        <div class="fag_title">
                            常见问题</div>
                        <ul>
                            <li><a href="http://www.topfo.com/help/register.shtml">·我的用户和密码忘记了，怎么办？</a></li>
                            <li><a href="http://www.topfo.com/help/register.shtml">·如何修改密码?</a></li>
                            <li><a href="http://www.topfo.com/help/register.shtml#15">·如何设置安全密码</a></li>
                        </ul>
                    </div>
                    <div class="faqbg2">
                    </div>
                </div>
            </div>
    </form>
</body>
</html>