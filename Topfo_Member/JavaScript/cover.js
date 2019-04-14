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
//message数组,随意增加更多的message;注意数组下标从0开始;
var message=new Array()
message[0]="圣诞节就要到来了,如何安排啊？？"
message[1]="很想念远方的亲人,别忘了给朋友寄一张贺卡啊！"
message[2]="不要工作,要休息！"
message[3]="Merry Christmas Day and Happy NEW Year !"
message[4]="Join Maillist right Now!"

//每个message对应的连接
var messageurl = new Array()
messageurl[0]="http://www.1stscript.com"
messageurl[1]="http://www.1stscript.com"
messageurl[2]="http://www.1stscript.com"
messageurl[3]="http://www.1stscript.com"
messageurl[4]="http://www.1stscript.com"

// 字体大小颜色
var fntsize=2
var fntface="Verdana"
var fntcolor="white"

// 字体是否加粗
var fontweight="yes"

//  messagebox的背景颜色
var backgroundcolor="red"

// messagebox的宽度和高度 (pixels)
var messagewidth="380"
var messageheight="30"

// 边缘宽度
var borderwidth="0"

// messages相对于messagebox的位置关系，前者水平关系后者垂直关系；
var messagealign="center"
var messagevalign="middle"

// 距离页面顶部的距离（精确调整位置）
var messages_top=500

// 距离页面左侧的距离（精确调整位置）
var messages_left=150

// 效果转换速度(越小越快)
var pause=50

// 停滞时间（秒）
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
    //实际上显示的message的table由这里控制，如果你明白代码的含义，可以自由度更大的修改；
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
//message数组,随意增加更多的message;注意数组下标从0开始;
var message=new Array()
message[0]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>我公司打开青岛等地合作新局面</font></a>  <a href='/Merchant/index.htm'><font size='0.2' color='#ff8b38'>我公司业务辐射乡镇一级</font></a>"
message[1]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>胡援东再次莅临我公司指导工作</font></a>  <a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>我网携手全球商业机构共建网站</font></a>"
message[2]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'><font size='0.2' color='#ff8b38'>武胜副县长张利纯来我司洽谈项目</font></a>  <a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>吉林省招商项目洽谈会顺利召开</font></a>"
message[3]="<a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>我公司与祥德国际建立合作关系</font></a>  <a href='/capital/index.htm'><font size='0.2' color='#ff8b38'>我公司为深圳市国际投资促会献计献策</font></a>"

//每个message对应的连接
var messageurl = new Array()
messageurl[0]="http://www.1stscript.com"
messageurl[1]="http://www.1stscript.com"
messageurl[2]="http://www.1stscript.com"
messageurl[3]="http://www.1stscript.com"
messageurl[4]="http://www.1stscript.com"

// 字体大小颜色
var fntsize="0.2"
var fntface="Verdana"
var fntcolor="#ff8b38"

// 字体是否加粗
var fontweight="yes"

//  messagebox的背景颜色
var backgroundcolor="white"

// messagebox的宽度和高度 (pixels)
var messagewidth="500"
var messageheight="30"

// 边缘宽度
var borderwidth="0"

// messages相对于messagebox的位置关系，前者水平关系后者垂直关系；
var messagealign="left"
var messagevalign="middle"

// 距离页面顶部的距离（精确调整位置）
var messages_top=390

// 距离页面左侧的距离（精确调整位置）
var messages_left=170

// 效果转换速度(越小越快)
var pause=50

// 停滞时间（秒）
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
    //实际上显示的message的table由这里控制，如果你明白代码的含义，可以自由度更大的修改；
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