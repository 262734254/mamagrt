// JScript 文件
//Function:     Tz888.cn Register Module(Send The Validation Email Afresh & Change User's Email)
//Author:       Siser(Siser0409@163.com)
//Create Date   2007-10-05
//Modify Date:  2007-10-05


function ShowMessageWin(type)
{     
     if($("eadd_bgdiv") && $("eadd_windiv"))  
        return ;
        
        var h;
        if(document.body.scrollHeight > document.body.offsetHeight)
                h = document.body.scrollHeight;
        else
                h = document.body.offsetHeight;
        
        //底层
        var bgdiv = document.createElement("div");
        bgdiv.id = "eadd_bgdiv";
        bgdiv.style.left = 0;                                
        bgdiv.style.top = 0;        
        bgdiv.style.width = document.body.scrollWidth;
        bgdiv.style.height = h;
        bgdiv.style.position = "absolute";
        bgdiv.style.filter = "alpha(opacity=60)";        
        bgdiv.style.backgroundColor = "#999999";
        bgdiv.style.zIndex = 99;
        
        //上层
        var windiv = document.createElement("div");
        windiv.id = "eadd_windiv";
        windiv.style.left = (document.body.offsetWidth-436)/2;                                
        windiv.style.top = 200;
        windiv.style.width = "400px";
        windiv.style.position = "absolute";
        windiv.style.filter = "alpha(opacity=100)";
        windiv.style.zIndex = 100;
        
      if(type == "modify")
      {
        //修改邮箱
        var clewframe ='width:470px!important;width:436px; height:110px;border:3px solid #ff8400; padding:4px 4px 40px 40px; text-align:left; background:white;';
        var content = '<div id="send">';
	    content += '<div style="'+clewframe +'">';
	    content += '<div style="float:right; width="436px"><a href="javascript:void(0)" class="Spaces"><img id="close" border="0" src="../images/reg_step/no.gif" alt="关闭此窗口"></a></div>';
	    content += '<h4 style="margin-top:40px">更换新的邮箱：</h4>';
		content += '<table width="0" border="0">';
		content += '<tr>';
		content += 	    '<td><input class="email_input nomargin" type="text" id="semail" /></td>';
		content += 	    '<td><button id="submit"  class="stylebtn">确定并发送验证邮件</button></td>';
		content += '</tr>';
		content += '</table>';
	    content +=  '<h6>(请确保新邮箱是您本人常用的)</h6>';
	    content += '<br><div style="text-align:center"><button id="close2"  class="styleclose">关 闭</button></div>';
	    content += '</div></div>';
        
        windiv.innerHTML = content;  
      }else
      {
        var clewbox = 'width:570px!important;width = 554px; background:url(../images/reg_step/kuang_bg_co.gif) repeat-y;  text-align:left; margin:0 auto; margin-top:20px';
        var clewbox_content = 'margin-left:20px; margin-right:20px;';
        var content =' <div id="change" style="'+clewbox+'">';
		 content +='<div class="clewbox_top"></div>';
		 content += '<div style="'+clewbox_content+'">';
		 content += '<div style="float:right; width="436px"><a href="javascript:void(0)" class="Spaces"><img id="close" border="0" src="../images/reg_step/no.gif" alt="关闭此窗口"></a></div>';
	     content += '<h4>您的邮箱还没经过验证！现在请按以下步骤操作：</h4>';
	     content += '<h1>方法一：重发验证邮件 </h1>';
         content += '<h2>我们已发送验证信到：<span id="orgemail"></span>';
	     content += '&nbsp;&nbsp;<button id="btnresend"  class="stylebtn">点此重发验证邮件</button>';
	     content +='<h1>方法二：更换新的邮箱</h1><br />';
         content +='    <input class="email_input" type="text" id="semail" />';
		 content +='    <button id="submit"  class="stylebtn">确定并发送验证邮件</button>';
		 content +='     </div>';
		 content += '<br><div style="text-align:center"><button id="close2"  class="styleclose">关 闭</button></div>';
	     content +='    <div class="clewbox_bot"></div></div>';
		 
		 windiv.innerHTML = content;  
      }  
      
        document.body.appendChild(bgdiv);
        document.body.appendChild(windiv);
        
        window.scrollTo(0,0);
        
        
        var btn = $("submit");
        if(btn)
         { btn.onclick = HideMessageWin;}
         
         if( $("orgemail") && $("lblMail").innerHTML)
            $("orgemail").innerHTML = $("lblMail").innerHTML;
        
        var btnresend = $("btnresend");
        if(btnresend)
            { btnresend.onclick =HideMessageWinT; }
        
        if($("close") || $("close2"))
        {
            $("close").onclick = HiddenDIV;
            $("close2").onclick = HiddenDIV;
            
        }
        
        
        var txtemail = $("semail");
        if(txtemail)
        {
            txtemail.onkeydown = function(evnt)
                { 
                   if(event.keyCode == 13)
                        HideMessageWin();
                }   
        } 
        

}


function HideMessageWin()
{
    
    var name = escape($("name").value);
    var email = escape($("semail").value);
    var validurl =escape($("validurl").value);
    var domain = escape($("domain").value);
    var lblMail = $("lblMail");
    
    var Rex = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/;
    
    if(email == $("lblMail").innerHTML)
    {
        alert("输入的邮箱和原来的一样，你只要点重发就可以了");
        return;
    }
    
    if (!Rex.test(email))
    {
        alert("请输入正确的新 E_Mail!");
        return;
    }
    Request.ChangeEmail(name,email,validurl,domain); 
     alert("邮箱更新成功，新邮箱为"+email);
    lblMail.innerHTML = email;
   
    HiddenDIV();            
}
//重发按钮
function HideMessageWinT()
{
    var name = escape($("name").value);
    var email = escape($("lblMail").innerHTML);
    var validurl =escape($("validurl").value);
    var domain = escape($("domain").value);
   
    Request.ReSend(name,email,validurl,domain); 
    alert("验证邮件已重新发送到"+email);
    HiddenDIV();
                    
}
function HiddenDIV()
{
    var bgdiv = $("eadd_bgdiv");
    var windiv = $("eadd_windiv");
    document.body.removeChild(bgdiv);
    document.body.removeChild(windiv); 
}

function $(id)
{
    if(id)
       {return document.getElementById(id);}
}

