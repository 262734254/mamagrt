<script language="JavaScript">
<!--
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);
// -->
</script>
  <script language="JavaScript">
<!--//
//message����,�������Ӹ����message;ע�������±��0��ʼ;
var message=new Array()
message[0]="ʥ���ھ�Ҫ������,��ΰ��Ű�����"
message[1]="������Զ��������,�����˸����Ѽ�һ�źؿ�����"
message[2]="��Ҫ����,Ҫ��Ϣ��"
message[3]="Merry Christmas Day and Happy NEW Year !"
message[4]="Join Maillist right Now!"

//ÿ��message��Ӧ������
var messageurl = new Array()
messageurl[0]="http://www.1stscript.com"
messageurl[1]="http://www.1stscript.com"
messageurl[2]="http://www.1stscript.com"
messageurl[3]="http://www.1stscript.com"
messageurl[4]="http://www.1stscript.com"

// �����С��ɫ
var fntsize=2
var fntface="Verdana"
var fntcolor="white"

// �����Ƿ�Ӵ�
var fontweight="yes"

//  messagebox�ı�����ɫ
var backgroundcolor="red"

// messagebox�Ŀ�Ⱥ͸߶� (pixels)
var messagewidth="380"
var messageheight="30"

// ��Ե���
var borderwidth="0"

// messages�����messagebox��λ�ù�ϵ��ǰ��ˮƽ��ϵ���ߴ�ֱ��ϵ��
var messagealign="center"
var messagevalign="middle"

// ����ҳ�涥���ľ��루��ȷ����λ�ã�
var messages_top=500

// ����ҳ�����ľ��루��ȷ����λ�ã�
var messages_left=150

// Ч��ת���ٶ�(ԽСԽ��)
var pause=50

// ͣ��ʱ�䣨�룩
var standstill=3

// -->
</script>
<script>
var coverimage = new Array()
coverimage[0]="stripes0.gif"
coverimage[1]="stripes1.gif"
coverimage[2]="stripes2.gif"
coverimage[3]="stripes3.gif"
coverimage[4]="stripes4.gif"
coverimage[5]="stripes5.gif"
coverimage[6]="stripes6.gif"
coverimage[7]="stripes7.gif"

var covimgpreload=new Array()
for (i=0;i<=coverimage.length-1;i++) {
	covimgpreload[i]=new Image()
	covimgpreload[i].src=coverimage[i]
}
var i_messages=0
var i_loop=0
var thisurl=0
var timer
var coverwidth
var coverheight
standstill=standstill*1000

var content
if (fontweight=="yes") {
    fontweight="<b>"
} 
else {fontweight=""}

function init() {
    //ʵ������ʾ��message��table��������ƣ���������״���ĺ��壬�������ɶȸ�����޸ģ�
    content="<table width='"+messagewidth+"' height='"+messageheight+"' border='"+borderwidth+"'>"
    content+="<tr valign='"+messagevalign+"'><td align='"+messagealign+"' bgcolor='"+backgroundcolor+"'>"
    content+="<font size='"+fntsize+"' face='"+fntface+"'  color='"+fntcolor+"'>"
    content+=fontweight
    content+=message[i_messages]
    content+="</font></td></tr></table>"
    if (document.all) {
       document.all.messagebox.style.posTop=messages_top
        document.all.messagebox.style.posLeft=messages_left
        document.all.cover.style.posTop=messages_top
        document.all.cover.style.posLeft=messages_left
		messagebox.innerHTML=content
		coverwidth=messagebox.offsetWidth
		coverheight=messagebox.offsetHeight
		cover.innerHTML="<a href='javascript:gotourl()'><img width="+coverwidth+" height="+coverheight+" name='imgcover' src='"+coverimage[i_loop]+"' border=0></a>"
		
        enlargehearts()
    }
	
	if (document.layers) {
	    document.messagebox.top=messages_top
        document.messagebox.left=messages_left
        document.cover.top=messages_top
        document.cover.left=messages_left
		document.messagebox.document.write(content)
		document.messagebox.document.close()
		coverwidth=document.messagebox.document.width
		coverheight=document.messagebox.document.height
		document.cover.document.write("<a href='javascript:gotourl()'><img width="+coverwidth+" height="+coverheight+" name='imgcover' src='"+coverimage[i_loop]+"' border=0></a>")
		document.cover.document.close()
		
        enlargehearts()
    }
}

function enlargehearts() {
        if (i_loop<=coverimage.length-1) {   
            if (document.all) {
                imgcover.src=coverimage[i_loop]
            }
            if (document.layers) {
                document.cover.document.imgcover.src=coverimage[i_loop]
            }
            i_loop++
            timer= setTimeout("enlargehearts()",pause)  
        }
        else {
            clearTimeout(timer)
            i_loop--
            timer= setTimeout("shrinkhearts()",standstill)
       }
}

function shrinkhearts() {
        if (i_loop>=0) {  
            if (document.all) { 
                imgcover.src=coverimage[i_loop]
            }
            if (document.layers) {
                document.cover.document.imgcover.src=coverimage[i_loop]
            }
            i_loop--
            timer= setTimeout("shrinkhearts()",pause)
        }
        else {
            clearTimeout(timer)
            i_loop=0
            i_messages++
            
            if (i_messages>=message.length) {i_messages=0}
                content="<table width='"+messagewidth+"' height='"+messageheight+"' border='"+borderwidth+"'>"
                content+="<tr valign='"+messagevalign+"'><td align='"+messagealign+"' bgcolor='"+backgroundcolor+"'>"
                content+="<font size='"+fntsize+"' face='"+fntface+"'  color='"+fntcolor+"'>"
                content+=fontweight
                content+=message[i_messages]
                content+="</font></td></tr></table>"
                if (document.all) { 
                    messagebox.innerHTML=content
                }
                if (document.layers) {
                    document.messagebox.document.write(content)
                    document.messagebox.document.close()
                }
            timer= setTimeout("enlargehearts()",(4*pause))
        }
}

function gotourl() {
	document.location.href=messageurl[i_messages]
}
window.onload=init
</script>


-------------------------
<script language="JavaScript">
<!--
function MM_reloadPage(init) {  //reloads the window if Nav4 resized
  if (init==true) with (navigator) {if ((appName=="Netscape")&&(parseInt(appVersion)==4)) {
    document.MM_pgW=innerWidth; document.MM_pgH=innerHeight; onresize=MM_reloadPage; }}
  else if (innerWidth!=document.MM_pgW || innerHeight!=document.MM_pgH) location.reload();
}
MM_reloadPage(true);
// -->
</script>
  <script language="JavaScript">
<!--//
//message����,�������Ӹ����message;ע�������±��0��ʼ;
var message=new Array()
message[0]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>�ҹ�˾���ൺ�ȵغ����¾���</font></a>  <a href='/Merchant/index.htm'><font size='0.2' color='#ff8b38'>�ҹ�˾ҵ���������һ��</font></a>"
message[1]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>��Ԯ���ٴ�ݰ���ҹ�˾ָ������</font></a>  <a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>����Я��ȫ����ҵ����������վ</font></a>"
message[2]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'><font size='0.2' color='#ff8b38'>��ʤ���س�����������˾Ǣ̸��Ŀ</font></a>  <a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>����ʡ������ĿǢ̸��˳���ٿ�</font></a>"
message[3]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>�ҹ�˾����¹��ʽ���������ϵ</font></a>  <a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>�ҹ�˾Ϊ�����й���Ͷ�ʴٻ��׼��ײ�</font></a>"

//ÿ��message��Ӧ������
var messageurl = new Array()
messageurl[0]="http://www.1stscript.com"
messageurl[1]="http://www.1stscript.com"
messageurl[2]="http://www.1stscript.com"
messageurl[3]="http://www.1stscript.com"
messageurl[4]="http://www.1stscript.com"

// �����С��ɫ
var fntsize="0.2"
var fntface="Verdana"
var fntcolor="#ff8b38"

// �����Ƿ�Ӵ�
var fontweight="yes"

//  messagebox�ı�����ɫ
var backgroundcolor="white"

// messagebox�Ŀ�Ⱥ͸߶� (pixels)
var messagewidth="500"
var messageheight="30"

// ��Ե���
var borderwidth="0"

// messages�����messagebox��λ�ù�ϵ��ǰ��ˮƽ��ϵ���ߴ�ֱ��ϵ��
var messagealign="left"
var messagevalign="middle"

// ����ҳ�涥���ľ��루��ȷ����λ�ã�
var messages_top=390

// ����ҳ�����ľ��루��ȷ����λ�ã�
var messages_left=170

// Ч��ת���ٶ�(ԽСԽ��)
var pause=50

// ͣ��ʱ�䣨�룩
var standstill=3

// -->
</script>
<script>
var coverimage = new Array()
coverimage[0]="stripes0.gif"
coverimage[1]="stripes1.gif"
coverimage[2]="stripes2.gif"
coverimage[3]="stripes3.gif"
coverimage[4]="stripes4.gif"
coverimage[5]="stripes5.gif"
coverimage[6]="stripes6.gif"
coverimage[7]="stripes7.gif"

var covimgpreload=new Array()
for (i=0;i<=coverimage.length-1;i++) {
	covimgpreload[i]=new Image()
	covimgpreload[i].src=coverimage[i]
}
var i_messages=0
var i_loop=0
var thisurl=0
var timer
var coverwidth
var coverheight
standstill=standstill*1000

var content
if (fontweight=="yes") {
    fontweight="<b>"
} 
else {fontweight=""}

function init() {
    //ʵ������ʾ��message��table��������ƣ���������״���ĺ��壬�������ɶȸ�����޸ģ�
    content="<table width='"+messagewidth+"' height='"+messageheight+"' border='"+borderwidth+"'>"
    content+="<tr valign='"+messagevalign+"'><td align='"+messagealign+"' bgcolor='"+backgroundcolor+"'>"
    content+="<font size='"+fntsize+"' face='"+fntface+"'  color='"+fntcolor+"'>"
    content+=fontweight
    content+=message[i_messages]
    content+="</font></td></tr></table>"
    if (document.all) {
       document.all.messagebox.style.posTop=messages_top
        document.all.messagebox.style.posLeft=messages_left
        document.all.cover.style.posTop=messages_top
        document.all.cover.style.posLeft=messages_left
		messagebox.innerHTML=content
		coverwidth=messagebox.offsetWidth
		coverheight=messagebox.offsetHeight
		cover.innerHTML="<a href='javascript:gotourl()'></a>"
		
        enlargehearts()
    }
	
	if (document.layers) {
	    document.messagebox.top=messages_top
        document.messagebox.left=messages_left
        document.cover.top=messages_top
        document.cover.left=messages_left
		document.messagebox.document.write(content)
		document.messagebox.document.close()
		coverwidth=document.messagebox.document.width
		coverheight=document.messagebox.document.height
		document.cover.document.write("<a href='javascript:gotourl()'></a>")
		document.cover.document.close()
		
        enlargehearts()
    }
}

function enlargehearts() {
        if (i_loop<=coverimage.length-1) {   
            if (document.all) {
              //  imgcover.src=coverimage[i_loop]
            }
            if (document.layers) {
             //   document.cover.document.imgcover.src=coverimage[i_loop]
            }
            i_loop++
            timer= setTimeout("enlargehearts()",pause)  
        }
        else {
            clearTimeout(timer)
            i_loop--
            timer= setTimeout("shrinkhearts()",standstill)
       }
}

function shrinkhearts() {
        if (i_loop>=0) {  
            if (document.all) { 
              //  imgcover.src=coverimage[i_loop]
            }
            if (document.layers) {
              //  document.cover.document.imgcover.src=coverimage[i_loop]
            }
            i_loop--
            timer= setTimeout("shrinkhearts()",pause)
        }
        else {
            clearTimeout(timer)
            i_loop=0
            i_messages++
            
            if (i_messages>=message.length) {i_messages=0}
                content="<table width='"+messagewidth+"' height='"+messageheight+"' border='"+borderwidth+"'>"
                content+="<tr valign='"+messagevalign+"'><td align='"+messagealign+"' bgcolor='"+backgroundcolor+"'>"
                content+="<font size='"+fntsize+"' face='"+fntface+"'  color='"+fntcolor+"'>"
                content+=fontweight
                content+=message[i_messages]
                content+="</font></td></tr></table>"
                if (document.all) { 
                    messagebox.innerHTML=content
                }
                if (document.layers) {
                    document.messagebox.document.write(content)
                    document.messagebox.document.close()
                }
            timer= setTimeout("enlargehearts()",(4*pause))
        }
}

function gotourl() {
	document.location.href=messageurl[i_messages]
}
window.onload=init
</script>