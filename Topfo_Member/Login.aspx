<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Debug="true" EnableEventValidation="false"
    Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ظ�-�й�����Ͷ����</title>
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
                ȫ����������Ͷ�������Ż�</div>
            <div class="rightfloat">
                <a href="http://www.topfo.com/" target="_blank">������ҳ</a><span>|</span><a href="http://www.topfo.com/Sys/Message.aspx"
                    target="_blank">���Է���</a><span>|</span><a href="http://www.topfo.com/help/index.shtml"
                        target="_blank">��������</a></div>
            <div class="clear">
            </div>
        </div>
        <div class="container">
            <div class="llcont">
                <div class="topbanner">
                    <div class="bannertext">
                        <div class="slogan">
                            <div class="sloganbg">
                                <span>����ȫ��</span><span>��ͨ����</span></div>
                            <div class="sbg2">
                                ��������Ͷ��ϵͳ��������ɹ��б���</div>
                        </div>
                        <div class="enterm">
                            <a href="register/register.aspx">�������ע���Ա &gt;&gt;</a></div>
                    </div>
                </div>
                <div class="midcont">
                    <h3>
                        �������������ʲô��</h3>
					<div class="page_css1">
                        <img src="images/load/icr_02.gif" width="46" height="36" />
                        <div class="spp">
                            <span>Ѱ�ʽ� ����Ŀ</span><br />
                            ��������ѯ����Ҫ�ĶԿ���Դ��

                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="page_css1">
                        <img src="images/load/icr_07.gif" width="46" height="42" /><span>����������������</span><br />
                        �ṩ���̡�Ͷ�ʡ����ʡ�һվʽ��ϵͳ���������

                    <div class="clear">
                      </div>
                  </div>
				  <div class="page_css1">
                        <img src="images/load/icr_06.gif" width="46" height="42" />
                        <div class="spp">
                            <span>����רҵ��������</span><br />
                            ���ټ�רҵ�������˻��� ��Ч�����ٽ�����Ͷ�ʣ�
                        </div>
                        <div class="clear">
                        </div>
                  </div>
				  <div class="page_css1">
                        <img src="images/load/icr_01.gif" width="46" height="42" />
                        <div class="spp">
                            <span>��ѷ�����ҵ����</span><br />
                            ��ѷ�����������ԣ������ҵ��Կڶ���
                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="page_css1">
                        <img src="images/load/icr_03.gif" width="46" height="37" />
                        <div class="spp">
                            <span>����ƹ���ҵ/����</span><br />
                            ��������չ����ȫ��չʾ�Լ���
                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="page_css1">
                        <img src="images/load/icr_04.gif" width="46" height="40" />
                        <div class="spp">
                            <span>�ύ����</span><br />
                            �ύ���ѣ���չ������������ҵ��ϵ��!
                        </div>
                        <div class="clear">
                        </div>
                  </div>
                    <div class="clear">
                    </div>
                </div>
                <div class="block_b">
                    <h3>
                        �ظ���Ա����ʲô�����ˣ�</h3>
                    <div class="block_main">
                        <img src="images/load/banner2.gif" />
                        <div class="detail">
                            ������Ͷ�ʼҡ�������Ա����ҵ�ҡ��߼�������Ա��<br />
                            Ҳ�г�������Ĵ�ҵ�ߣ�<br />
                            �����Ϊ���е�һԱ��<br />
                            �ظ����ͥ����ӭ���ļ��룡

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
                            <asp:Label ID="Label1" runat="server" Text="�Ѿ����ظ���Ա"></asp:Label>&nbsp;</h3>
                        <div class="reinput3">
                            �������û���������

                            </div>
                        <div class="reinput">
                            �û�����<asp:TextBox runat="server" ID="txtUserName" class="inpcss" onmouseover="this.className='oninpcss'"
                                onmouseout="this.className='inpcss'"></asp:TextBox></div>
                        <div class="reinput">
                            ��&nbsp; �룺<asp:TextBox runat="server" ID="txtPsd" class="inpcss" onmouseover="this.className='oninpcss'"
                                onmouseout="this.className='inpcss'" TextMode="Password"></asp:TextBox></div>
                        <div class="reinput2">
                            <input name="cbSaveUserName" id="cbSaveUserName" onclick="Javascript:SetUserNameOnLogin();" type="checkbox"
                                value="cbSaveUserName" />��ס�û���<br />
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
                                ��������</a><a href="http://www.topfo.com/help/register.shtml#15" target="_blank">���ð�ȫ����</a><a
                                    href="http://www.topfo.com/help/login.shtml" target="_blank">��½����</a></div>
                        <div style="height:19px; background:url(images/icr_picline.gif) no-repeat;">
                        
                           </div>
                        <div>
                            <span class="bold f14t">������������ظ���Ա</span><br />
                            <span class="bold">ע��ǳ����١���㣡</span>
                        </div>
                        <div>
                            <a href="Register/Register.aspx" class="Spaces">
                                <img src="images/load/btn_2.gif" id="IMG1" onclick="return IMG1_onclick()" /></a>
                            <br />
                       <a href="http://www.topfo.com/Service/enterprisemember.shtml" target="_blank"><span class="gtext">[������ ���鿴�ظ�ͨ��Ա����]</span></a> </div>
                  </div>
                    <div class="loginbg2">
                    </div>
                </div>
                <div class="faq">
                    <div class="faqbg1">
                    </div>
                    <div class="fagcon">
                        <div class="fag_title">
                            ��������</div>
                        <ul>
                            <li><a href="http://www.topfo.com/help/register.shtml">���ҵ��û������������ˣ���ô�죿</a></li>
                            <li><a href="http://www.topfo.com/help/register.shtml">������޸�����?</a></li>
                            <li><a href="http://www.topfo.com/help/register.shtml#15">��������ð�ȫ����</a></li>
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
