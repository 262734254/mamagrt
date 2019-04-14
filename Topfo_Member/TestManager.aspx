<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestManager.aspx.cs" Inherits="TestManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link href="../css/index_fhy.css" rel="stylesheet" type="text/css" />
    <link href="../css/common.css" rel="stylesheet" type="text/css" />
    <link href="../css/right_fhy.css" rel="stylesheet" type="text/css" />
    <link href="img/member.css" rel="stylesheet" type="text/css" />
    <title>拓富中心-拓富·中国招商投资网</title>

    <script type="text/javascript" src="/JavaScript/png.js"></script>

    <script type="text/javascript" src="/javascript/OPCookie.js"></script>

    <script type="text/javascript" src="/javascript/UserCustom.js"></script>

    <script language="javascript" type="text/javascript">
        function LogoutToURL(url)
        {  

              var ToURL;
              if(url!="")
                ToURL = url;
              else
                ToURL = location.href;   

              location.href ='/Logout.aspx?url='+ToURL;
        }
    </script>

</head>
<body style="word-break: break-all">
    <form runat="server" id="frmsearch">

        <script language="javascript" type="text/javascript">
		function killErrors() 
		{ 
		return true; 
		}   
		window.onerror = killErrors; 
        </script>

        <div class="topsearch">
            <div class="float_right" style="position: relative; top: 5px">
                <a href="http://www.topfo.com" target="_blank">网站首页</a> <a href="javascript:void(0)"
                    onclick="LogoutToURL('Login.aspx');return false;">退出</a>
            </div>
            <div class="float_all">
                <iframe src="/common/search.htm" scrolling="no" frameborder="0" width="100%" height="24">
                </iframe>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="footer">
            <div class="footer_bai">
                <div class="footer_all">
                    <div class="footer_ll">
                        <a href="http://www.topfo.com" target="_blank" class="Spaces">
                            <img src="/images_fhy/logo.png" /></a></div>
                    <div class="footer_cc" style="height: 72px;">
                        <a href="http://www.topfo.com/TopfoCenter/Application/superiorityApp.shtml" target="_blank">
                            <img src="http://www.topfo.com/web13/images/home/tf551x72.jpg"  alt=""/></a>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="info">
            <div class="info_cont">
                <div class="info_cont_ll">
                    欢迎<asp:Literal runat="server" ID="lblMemberGrade"></asp:Literal><span><asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></span>登录拓富中心</div>
                <div class="info_cont_rr" style="display: none">
                    <div class="info_cont_rr_border">
                        今天共发了<span class="red_2"><asp:Label ID="lblInfoCount" runat="server" Text="0"></asp:Label></span>条新的需求，新加入会员<span
                            class="red_2"><asp:Label ID="lblMemberCount" runat="server" Text="0"></asp:Label></span>人</div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="container">
            <div class="lefttopmenu">
                <div id="fhy_menu" class="fhy_menu">
                    <asp:Literal ID="ltMenu" runat="server"></asp:Literal>
                </div>
                <div class="intervbg intervbgTmar">
                    <img src="/images_fhy/arrow_6.gif"  alt=""/><a href="/Register/VIPMemberRegister_In.aspx"
                        class="chenglink">申请拓富通</a></div>
                <div class="intervbg">
                    <img src="/images_fhy/arrow_6.gif"  alt=""/><a href="http://www.topfo.com/Sys/Message.aspx"
                        class="chenglink" target="_blank">给我们留言</a></div>
                <br />
                <span style="margin-left: 5px;">中国招商投资QQ群：9823663</span>
            </div>
         
            <div class="clear">
            </div>
        </div>

        <script type="text/javascript" language="javascript">
         function chkmenucolor(str)
         {  //alert(str);
            var Arr = document.getElementById("fhy_menu").getElementsByTagName("a");
            for(var a=0;a<Arr.length;a++)
            {
                if(str.indexOf(Arr[a].href)!=-1)
                {
                    //alert(Arr[a].href);
                    Arr[a].style.color="red";
                }
                else
                {
                    Arr[a].style.color="black";
                }
            }
         }
         chkmenucolor(location.href);
        </script>

        <div class="fhybottom">
            <div class="fhybottom_tel">
                <span>
                    <img src="/images_fhy/icon_tel.gif" align="absmiddle" /></span> <span>客服热线：0755-82210116
                    </span><span><a href="javascript:jiayingOpenMyWin()">
                        <img src="/images_fhy/liuyanbg.gif" alt="" align="absmiddle" /></a> </span>
            </div>
            <div class="fhybottom_contact">
                <div>
                    <span><a href="http://www.topfo.com/aboutus/index.aspx" target="_blank">关于我们</a> | <a
                        href="http://www.topfo.com/ContactUs.shtml" target="_blank">联系我们</a> | <a href="http://www.topfo.com/Aboutus/ServiceOnline/index.shtml"
                            target="_blank">我们的服务</a> | <a href="http://www.topfo.com/ADbusiness/ad/ad_pay.htm"
                                target="_blank">支付方式</a> | <a href="http://www.topfo.com/ServiceItem/ServiceItem.shtml"
                                    target="_blank">服务条款</a> | <a href="http://www.topfo.com/Map.shtml" target="_blank">
                                        网站地图</a> | <a href="http://www.topfo.com/zhaoping/index.shtml" target="_blank">诚聘英才
                                        </a>| <a href="http://www.topfo.com/TopfoCenter/Application/TopfoServe.shtml" class="red"
                                            target="_blank">拓富通服务</a></span>
                </div>
                <div>
                    中国招商投资网有限公司<span>1998-2008</span></div>
                <div style="display: none">

                    <script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? " https://ssl." : " http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
                    </script>

                    <script type="text/javascript">
try {
var pageTracker = _gat._getTracker("UA-15744874-1");
pageTracker._trackPageview();
} catch(err) {}</script>

                </div>

                <script language="javascript" src="http://chat.7k35.com/chat/7k35_1.jsp?eprId=topfo"></script>

            </div>
        </div>
    </form>
</body>
</html>
