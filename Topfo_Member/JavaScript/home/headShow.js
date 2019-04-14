

//headShow
function initShow()
{   

//    SetOnlineCount();
    document.getElementById("tz888_big_show").style.display="block";
    setTimeout("smallShow()",3000);
}

function smallShow()
{
    
    document.getElementById("tz888_big_show").style.display="none";
    document.getElementById("tz888_small_show").style.display="block";
}

function close_small_show()
{
    document.getElementById("tz888_small_show").style.display="none";
}
//online
function SetOnlineCount()
{
    today=new Date();
    var date=today.getFullYear();
    if(today.getMonth()<9)
    { 
      date=date+"-0"+(today.getMonth()+1); 
    } 
    else
    { 
        date=date+"-"+(today.getMonth()+1); 
    }
    if(today.getDate()<10){ 
        date=date+"-0"+(today.getDate()); 
    } 
    else
    { 
        date=date+"-"+(today.getDate()); 
    }
    
    var online=GetObj("online");
   

    date = date +" "; 
if(today.getHours()<10){ 
date=date+"0"+today.getHours(); 
} 
else{ 
date=date+today.getHours(); 
} 

if(today.getMinutes()<10){ 
date=date+":0"+today.getMinutes(); 
} 
else{ 
date=date+":"+today.getMinutes(); 
} 
if(today.getSeconds()<10){ 
date=date+":0"+today.getSeconds(); 
} 
else{ 
date=date+":"+today.getSeconds(); 
} 

var memberNum=0;
var requireNum=0;
var hours=today.getHours();
var minutes=today.getMinutes();
var seconds=today.getSeconds();

if(today.getHours()< 9)
{
        memberNum=today.getHours()*40;
        requireNum=today.getHours()*30;
        memberNum=memberNum+Math.floor(today.getMinutes()*0.5);
        requireNum=requireNum+Math.floor(today.getMinutes()*0.2);
        if(today.getSeconds()<5)
        {
            memberNum=memberNum+1;
        }
        else if(today.getSeconds()<9)
        {
            memberNum=memberNum+2;
            requireNum=requireNum+1;
        }
        else if(today.getSeconds()<12)
        {
            memberNum=memberNum+3;
        }
        else if(today.getSeconds()<16)
        {
            memberNum=memberNum+4;
            requireNum=requireNum+3;
        }
        else if(today.getSeconds()<18)
        {
            memberNum=memberNum+5;
        }
        else if(today.getSeconds()<23)
        {
            memberNum=memberNum+6;
            requireNum=requireNum+4;
        } 
        else if(today.getSeconds()<30)
        {
            memberNum=memberNum+7;
        }
        else if(today.getSeconds()<37)
        {
            memberNum=memberNum+8;
            requireNum=requireNum+5;
        }
        else if(today.getSeconds()<43)
        {
            memberNum=memberNum+9;
        }
        else if(today.getSeconds()<52)
        {
            memberNum=memberNum+10;
            requireNum=requireNum+6;
        }
        else if(today.getSeconds()<59)
        {
            memberNum=memberNum+11;
        }       
} 
else if(today.getHours()> 8)
{
     memberNum=today.getHours()*80;
     requireNum=today.getHours()*40;
     memberNum=memberNum+today.getMinutes()*1;
     requireNum=requireNum+Math.floor(today.getMinutes()*0.4);
        if(today.getSeconds()<5)
        {
            memberNum=memberNum+1;
            requireNum=requireNum+1;
        }
        else if(today.getSeconds()<9)
        {
            memberNum=memberNum+2;
            
        }
        else if(today.getSeconds()<12)
        {
            memberNum=memberNum+3;
            requireNum=requireNum+3;
        }
        else if(today.getSeconds()<16)
        {
            memberNum=memberNum+4;
        }
        else if(today.getSeconds()<18)
        {
            memberNum=memberNum+5;
        }
        else if(today.getSeconds()<23)
        {
            memberNum=memberNum+6;
        } 
        else if(today.getSeconds()<30)
        {
            memberNum=memberNum+7;
            requireNum=requireNum+5;
        }
        else if(today.getSeconds()<37)
        {
            memberNum=memberNum+8;
        }
        else if(today.getSeconds()<43)
        {
            memberNum=memberNum+9;
            requireNum=requireNum+6;
        }
        else if(today.getSeconds()<52)
        {
            memberNum=memberNum+10;
        }
        else if(today.getSeconds()<59)
        {
            memberNum=memberNum+11;
            requireNum=requireNum+9;
        }    
}
var day=today.getDay();
if((day==0)||(day==6))
{
    memberNum=Math.floor(memberNum*0.6);
    requireNum=Math.floor(requireNum*0.6);
}

    online.innerHTML=date+' <span>新加入会员'+memberNum+'位，</span>新发布需求 '+requireNum+'条'; 
}