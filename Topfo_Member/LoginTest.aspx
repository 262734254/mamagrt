<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginTest.aspx.cs" Inherits="LoginTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title>拓富-中国招商投资网</title>
    <link href="css/load.css" rel="stylesheet" type="text/css" />

    <script src="javascript/OPCookie.js"></script>

    <script language="javascript">
 

function GetUserNameOnLogin()
{   
    var vvvv = getCookie("SetUserNameOnLogin"); 
      
    if (vvvv == '1')
	{	
	    var vUserNameOnCookie = getCookie("SetUserNameOnLoginValue"); 
	    
		document.getElementById("txtUserName").value=vUserNameOnCookie;
		document.getElementById("cbSaveUserName").checked = "true";
	}
	 
} 


function SetUserNameOnLogin()
{
    var vIsSet = document.getElementById("cbSaveUserName").checked;
    if(vIsSet)
    {
       
        vUserNameOnCookie =document.getElementById("txtUserName").value;
        setCookie("SetUserNameOnLogin", 1, 100000000);
        setCookie("SetUserNameOnLoginValue",vUserNameOnCookie, 100000000);    
    }
    else
    {
    
        vUserNameOnCookie =document.getElementById("txtUserName").value;
        setCookie("SetUserNameOnLogin", 0, 100000000);
        setCookie("SetUserNameOnLoginValue",vUserNameOnCookie, -10000);    
    }    
}



    </script>

    <style type="text/css">
<!--
.gtext {
	font-size: 12px;
	color: #25970b;
}
-->
    </style>
</head>
<body>
    <form id="form1" runat="server">
  
        <div class="header">
            <div class="leftfloat">
                <a href="http://www.topfo.com" target="_blank">
                    <img src="http://www.topfo.com/web13/images/logo.jpg" /></a></div>
            <div class="leftfloat pm20">
                全球最大的招商投资融资门户</div>
            <div class="rightfloat">
                <a href="http://www.topfo.com/" target="_blank">返回首页</a><span>|</span><a href="http://www.topfo.com/Sys/Message.aspx"
                    target="_blank">留言反馈</a><span>|</span><a href="http://www.topfo.com/help/index.shtml"
                        target="_blank">帮助中心</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="container">
            <div class="llcont">
                <div class="topbanner">
                    <div class="bannertext">
                        <div class="slogan">
                            <div class="sloganbg">
                                <span>网遍全球</span><span>融通天下</span></div>
                            <div class="sbg2">
                                融资招商投资系统解决方案成功有保障</div>
                        </div>
                        <div class="enterm">
                            <a href="register/register.aspx">立即免费注册会员 &gt;&gt;</a></div>
                    </div>
                </div>
                <div class="midcont">
                    <h3>
                        在这里，您可以做什么？</h3>
					<div class="page_css1">
                        <img src="images/load/icr_02.gif" width="46" height="36" />
                        <div class="spp">
                            <span>寻资金 找项目</span><br />
                            搜索、查询您需要的对口资源！

                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="page_css1">
                        <img src="images/load/icr_07.gif" width="46" height="42" /><span>发布政府招商需求</span><br />
                        提供招商·投资·融资“一站式”系统解决方案！

                    <div class="clear">
                      </div>
                  </div>
				  <div class="page_css1">
                        <img src="images/load/icr_06.gif" width="46" height="42" />
                        <div class="spp">
                            <span>发布专业服务需求</span><br />
                            数百家专业服务联盟机构 高效联动促进招商投资！
                        </div>
                        <div class="clear">
                        </div>
                  </div>
				  <div class="page_css1">
                        <img src="images/load/icr_01.gif" width="46" height="42" />
                        <div class="spp">
                            <span>免费发布商业需求</span><br />
                            免费发布，智能配对，快速找到对口对象！
                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="page_css1">
                        <img src="images/load/icr_03.gif" width="46" height="37" />
                        <div class="spp">
                            <span>免费推广企业/机构</span><br />
                            建立网上展厅，全面展示自己！
                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="page_css1">
                        <img src="images/load/icr_04.gif" width="46" height="40" />
                        <div class="spp">
                            <span>结交商友</span><br />
                            结交商友，拓展人脉，建立行业关系链!
                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="block_b">
                    <h3>
                        拓富会员都是什么样的人？</h3>
                    <div class="block_main">
                        <img src="images/load/banner2.gif" />
                        <div class="detail">
                            他们有投资家、政府官员、企业家、高级管理人员，<br />
                            也有充满激情的创业者，<br />
                            您想成为其中的一员吗？<br />
                            拓富大家庭，欢迎您的加入！

                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
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
                            <a href="http://member.topfo.com/Register/RetrieveStep1.aspx" target="_blank">
                                忘记密码</a><a href="http://www.topfo.com/help/register.shtml#15" target="_blank">设置安全密码</a><a
                                    href="http://www.topfo.com/help/login.shtml" target="_blank">登陆帮助</a></div>
                        <div style="height:19px; background:url(images/icr_picline.gif) no-repeat;">
                        
                           </div>
                        <div>
                            <span class="bold f14t">如果您还不是拓富会员</span><br />
                            <span class="bold">注册非常快速、简便！</span>
                        </div>
                        <div>
                            <a href="Register/RegisterTest.aspx" class="Spaces">
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
            <div class="clear">
            </div>
        </div>
        <div style="clear: both; height: 10px; ont-size: 1px; overflow: hidden; display: block">
       
        </div>
        <!--#include file="common/allfooter.html"-->

        <script language="javascript">    GetUserNameOnLogin();</script>
 
    </form>
</body>
</html>
