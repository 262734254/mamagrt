<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSurver.aspx.cs" Inherits="Vote_UserSurver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>��վ�İ����-�й�����Ͷ����</title>
<link href="css/surver.css" rel="stylesheet" type="text/css" />
<link href="css/head.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
    function checkSelect()
    {
        var allcheck = 0;
        var itemsLength = 11;
        
        if($("txtLinkName").value == "")
        {
            alert("����д����������");
            return false;
        }   
        if($("txtTel").value == "")
        {
           alert("����д������ϵ�绰��");
            return false; 
        }  
         
        if($("email").value == "")
        {
            alert("����д����Email��");
            return false;
        }else
        {
            var rex = /^[\w-]+(\.[\w-]+)*@[\w-]+\.(com|com.cn|cn|net|net.cn|info|org|org.cn|gov|gov.cn|tv)$/i;
           
            if(rex.test($("email").value) == false)
            {
               alert("����д��Email��ʽ����ȷ��");
               return false;
              }
        }
        
        if($("userContent").value.length > 255)
        {
            alert("�һ��л���˵�����ݳ��ȴ���255");
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
           
           alert("�����������һ��������⣡");
           return false;
        }
       if(allcheck < itemsLength)
       {
            document.getElementById("allchecked").value = "false";
             return confirm("��û�����ȫ�����⣬�޷��������Ϊ���ṩ�Ĳ��뽱�Ͳμ����˴�齱���ʸ��Ƿ���Ȼ�ύ�õ����ʾ�");
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
<h3 class="h3title">�𾴵��û���</h3>
<div class="blank0"></div>
<p class="pcss">�ظ����й�����Ͷ������http://www.topfo.com��ȫ�¸İ������ˣ�Ϊ�˸����ṩ���õķ��������ؿ�չ�˴��û����������ϣ���������������������������ȫ������������û������ܻ�������ṩ�ľ�����Ʒ��</p>
<div class="blank0"></div>
<div class="icrbg"><span class="orange02">�������ڲ������֮ǰ�����˽�һ���°�������Щ�仯��</span> <span><a href="http://www.topfo.com/specialserve/serve03.shtml"  target="_blank" class="Ablue02">���ھ�ȥ�˽�һ��&gt;&gt;</a></span></div>

<div class="blank0"></div>

<div class="llnote">
<h3 class="f12"><span>�ʱ�䣺</span>2007��11��20�ա�2008��1��20��</h3>
<h3 class="f12"><span>�����</span></h3>
<p>
    ֻҪ�����涨Ҫ����д���ʾ����ύ�������ϣ��Ϳ��Ի�������ṩ�Ĳ��뽱һ�ݣ�����ò������˴�齱���ʸ�</p>
<p>
    ���˳齱���н��������ڵ��������ͳһ���������ǵĿͷ�����������µ���ϵ��ʽ�������硣���λ�����ս���Ȩ������<a href="" target="_blank" class="Ared01">�ظ����й�����Ͷ����</a>��</p>
<p>����֧��������ǰ�����������</p>
</div>

<div  class="rrnote">
<h3 class="f12"><span>�������ã�</span></h3>
<p>
һ�Ƚ���2��    �ظ�ͨ��Ա�ʸ񼰼�ֵ2000Ԫ��ʱ���ֻ�һ��<br />
���Ƚ���10��   �ظ�ͨ��Ա�ʸ�<br />
���Ƚ���100��  ���100Ԫ���ظ���ֵ��һ��<br />
���뽱������   �Ż�ȯ50Ԫ
</p>
<div class="blank14"></div>
<h3 class="f12">˵����</h3>
<p>
1�����һ���������Ƚ����û���Ҫ��Ϊ���ǵ�ע���Ա���ܻ�ý�Ʒ;<br />
2������ظ�ͨ��Ա�ʸ�Ļ��û�����Ҫ�ṩ��ص�֤�����ϼ�������֤����;
</p>
</div>

</div>
<div class="clear"></div>
<div class="bgimg04"></div>
</div>

<form action="http://www.topfo.com/vote/WebForm1.aspx?cid=34&do=redir" method="post"  id="voteForm" onsubmit="return checkSelect()">
<input type="hidden" id="hidCID" name="hidCID" value="34" />
<div class="votebg" style="text-align:center">

<h3 class="vtitle">���ڿ�ʼ����</h3>

<div class="votestart" id="votestart" runat="server">
 </div>

<!-- ����end -->


<h3 class="msgtitle">�һ��л���˵��</h3>
<div class="msgbox">
<div class="uerbg"><textarea name="userContent" id="userContent" onclick="if(this.value == '��ֱ����������˵�Ļ���ף�����������߽��鶼����.')this.value=''" cols="" rows=""  class="uermsgbox">��ֱ����������˵�Ļ���ף�����������߽��鶼����.</textarea></div>

<div class="blank0"></div>

<div class="msgtitle02">���λΪ�н����飬Ϊ�����н��������ϵ������д�������ϡ�����������Ͻ����ڳ齱�����ǳ�ŵΪ�����ܡ�</div>

<div class="blank0"></div>

<ul class="uerinfo">
<li class="li01">����������<li>
<li class="li02"><input name="txtLinkName" id="txtLinkName" type="text" class="inputcss2"/><span>����д��ʵ�������Ա�����ʱ������ϵ</span>
<div class="clear"></div>
</li>
</ul>

<ul class="uerinfo">
<li class="li01">������ϵ�绰��<li>
<li class="li02"><input name="txtTel" id="txtTel" type="text" class="inputcss2"/><span>�ֻ���̶��绰�Կɣ�����Ҫ��</span>
<div class="clear"></div>
</li>
</ul>

<ul class="uerinfo">
<li class="li01">���ĵ������䣺<li>
<li class="li02"><input name="txtEmail" id="email" type="text" class="inputcss2"/><span>����д����õ����䣬�Ա�����ʱ���������ʼ�</span>
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

