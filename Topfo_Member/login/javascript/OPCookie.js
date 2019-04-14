function setCookie(name,value,time)
{
 
var expires=new Date();
//time以秒为单位;
expires.setTime(expires.getTime()+time*1000);
var expiryDate=expires.toGMTString();
document.cookie=name+"="+value+";path=" + "/" + ";expires="+expiryDate;
}


function getCookie(str){
 
 var tmp,reg=new RegExp("(^| )"+str+"=([^;]*)(;|$)","gi");
 if(tmp=reg.exec(document.cookie))
 return(tmp[2]);
 return null;
}