function ShowMessageWin()
{  
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
        //windiv.style.width = "800px";
        windiv.style.position = "absolute";
        windiv.style.filter = "alpha(opacity=100)";
        windiv.style.zIndex = 100;
        
        var clewframe ='width:800px; height:110px;border:2px';
	    content = '<div style="'+clewframe+'">';
	    var htm="<iframe id='frame1'  width='421' height='250' marginheight='0' frameborder='0' scrolling='no' marginwidth='0' src='SetNotice.aspx' ></iframe>";
	    content += htm;
	    content += '</div>';

        windiv.innerHTML = content; 
      
        document.body.appendChild(bgdiv);
        document.body.appendChild(windiv);
        
        window.scrollTo(0,0);
        
        var windiv = $("eadd_windiv");
}

function HideMessageWin(para,beChange)
{    
    var bgdiv = $("eadd_bgdiv");
    var windiv = $("eadd_windiv");

    document.body.removeChild(bgdiv);
    document.body.removeChild(windiv);    
    if(beChange=="1") 
       $("ctl00_ContentPlaceHolder1_lbNotice").innerHTML = "您已选择使用" + para + "的定阅通知<br> 请点击此处<a  href='javascript:ShowMessageWin()'><font color='#0000FF'>修改通知接收方式</font></a>";
}



function $(id)
{
    if(id)
       {return document.getElementById(id);}
}