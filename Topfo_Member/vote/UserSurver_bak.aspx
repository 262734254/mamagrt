<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSurver.aspx.cs" Inherits="Vote_UserSurver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>网站改版调查-中国招商投资网</title>
<link href="css/surver.css" rel="stylesheet" type="text/css" />
<link href="css/head.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    function checkSelect()
    {
        var allcheck = 0;
        var itemsLength = 11;
        
        if($("txtLinkName").value == "")
        {
            alert("请填写您的姓名！");
            return false;
        }   
        if($("txtTel").value == "")
        {
           alert("请填写您的联系电话！");
            return false; 
        }  
         
        if($("email").value == "")
        {
            alert("请填写您的Email！");
            return false;
        }else
        {
            var rex = /^[\w-]+(\.[\w-]+)*@[\w-]+\.(com|com.cn|cn|net|net.cn|info|org|org.cn|gov|gov.cn|tv)$/i;
           
            if(rex.test($("email").value) == false)
            {
               alert("你填写的Email格式不正确。");
               return false;
              }
        }
        
        if($("userContent").value.length > 255)
        {
            alert("我还有话想说：内容长度大于255");
            return false;
        }
        
        for(i=0;i<=itemsLength;i++)
        {
            var obj = document.getElementsByName("poll"+i.toString());
            for(m=0;m<obj.length;m++)
                if(obj[m].checked)
                {
                    allcheck ++
                    break;
                }        
        }
       if(allcheck == 0)
        {
           
           alert("请您至少完成一项调查问题！");
           return false;
        }
       if(allcheck < itemsLength)
       {
            document.getElementById("allchecked").value = "false";
             return confirm("您没有完成全部问题，无法获得我们为您提供的参与奖和参加幸运大抽奖的资格！是否仍然提交该调查问卷？");
        }
       else
         document.getElementById("allchecked").value = "true";
 
       return true;
    }
    
    function $(id)
    {
        return document.getElementById(id);
    }
</script>
</head>

<body>

<div style=" background:#ffffff">
<!--#include file="head.html" -->
</div>

<div class="redblack6"></div>


<div class="downbg">
<div class="wrap">


<div class="container">
<div class="topbg2"></div>

<div class="topnote">
<div class="bgimg03"></div>

<div class="notebox">
<h3 class="h3title">尊敬的用户：</h3>
<div class="blank0"></div>
<p class="pcss">拓富·中国招商投资网（http://www.topfo.com）全新改版上线了！为了给您提供更好的服务，我们特开展此次用户体验调查活动，希望从中聆听到您宝贵的意见！完成全部调查问题的用户，皆能获得我们提供的精美礼品。</p>
<div class="blank0"></div>
<div class="icrbg"><span class="orange02">建议您在参与调查之前，先了解一下新版有了哪些变化？</span> <span><a href="http://www.topfo.com/specialserve/serve03.shtml"  target="_blank" class="Ablue02">现在就去了解一下&gt;&gt;</a></span></div>

<div class="blank0"></div>

<div class="llnote">
<h3 class="f12"><span>活动时间：</span>2007年11月20日～2008年1月20日</h3>
<h3 class="f12"><span>活动规则：</span></h3>
<p>
    只要您按规定要求填写完问卷，并提交个人资料，就可以获得我们提供的参与奖一份，并获得参与幸运大抽奖的资格。</p>
<p>
    幸运抽奖的中奖名单将在调查结束后统一公布，我们的客服会根据您留下的联系方式与您联络。本次活动的最终解释权归属于<a href="" target="_blank" class="Ared01">拓富·中国招商投资网</a>。</p>
<p>您的支持是我们前进的最大动力！</p>
</div>

<div  class="rrnote">
<h3 class="f12"><span>奖项设置：</span></h3>
<p>
一等奖：2名    拓富通会员资格及价值2000元的时尚手机一部<br />
二等奖：10名   拓富通会员资格<br />
三等奖：100名  面额100元的拓富充值卡一张<br />
参与奖：若干   优惠券50元
</p>
<div class="blank14"></div>
<h3 class="f12">说明：</h3>
<p>
1）获得一、二、三等奖的用户需要成为我们的注册会员才能获得奖品;<br />
2）获得拓富通会员资格的获奖用户，需要提供相关的证明材料及进行验证程序;
</p>
</div>

</div>
<div class="clear"></div>
<div class="bgimg04"></div>
</div>

<form action="http://www.topfo.com/vote/WebForm1.aspx?cid=34&do=redir" method="post"  id="voteForm" onsubmit="return checkSelect()">
<input type="hidden" id="hidCID" name="hidCID" value="34" />
<div class="votebg" style="text-align:center">

<h3 class="vtitle">现在开始调查</h3>

<div class="votestart" id="votestart" runat="server">
 </div>

<!-- 调查end -->


<h3 class="msgtitle">我还有话想说：</h3>
<div class="msgbox">
<div class="uerbg"><textarea name="userContent" id="userContent" onclick="if(this.value == '请直接输入您想说的话，祝福、批评或者建议都可以.')this.value=''" cols="" rows=""  class="uermsgbox">请直接输入您想说的话，祝福、批评或者建议都可以.</textarea></div>

<div class="blank0"></div>

<div class="msgtitle02">本次活动为有奖调查，为便于中奖后和您联系，请填写以下资料。所填个人资料仅用于抽奖，我们承诺为您保密。</div>

<div class="blank0"></div>

<ul class="uerinfo">
<li class="li01">您的姓名：<li>
<li class="li02"><input name="txtLinkName" id="txtLinkName" type="text" class="inputcss2"/><span>请填写真实姓名，以便您获奖时与您联系</span>
<div class="clear"></div>
</li>
</ul>

<ul class="uerinfo">
<li class="li01">您的联系电话：<li>
<li class="li02"><input name="txtTel" id="txtTel" type="text" class="inputcss2"/><span>手机或固定电话皆可，很重要！</span>
<div class="clear"></div>
</li>
</ul>

<ul class="uerinfo">
<li class="li01">您的电子邮箱：<li>
<li class="li02"><input name="txtEmail" id="email" type="text" class="inputcss2"/><span>请填写您最常用的邮箱，以便您获奖时给您发送邮件</span>
<div class="clear"></div>
</li>
</ul>


<div class="blank0"></div>

<div class="submitp"><input type="image" src="images/btn_msg2.gif" /></div>
</div>

<div class="votebgdown"></div>


</div><!-- end -->
<input name="rs_count" type="hidden" id="rs_count" value="12" />
<input name="allchecked" type="hidden" id="allchecked" />
<input type="hidden" name="txtCompany" />
<input type="hidden" name="txtAddress" />
<input type="hidden" name="txtFax" />
<input type="hidden" name="txtWebSite" />

</form>
<div class="blank20"></div>
<div class="blank20"></div>


</div>


</div>
</div>


<div style=" background:#ffffff">
<!--# file="/web13/Common/bottom.html" -->
<div class="clear"></div>
</div>

</body>
</html>

