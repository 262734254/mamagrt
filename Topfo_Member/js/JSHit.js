// JScript 文件

function getCookie()//读取cookies函数        
{ 
    var loginnameStr="";
    var ckdataStr="";
    
    if(document.cookie!=""&&document.cookie.indexOf(";")!=-1)
    {   
        var cookies = document.cookie.split(';');
        for(var i=0;i<cookies.length;i++)
        {
        //alert(cookies[i]);
            var co = cookies[i];
            if(co.indexOf("topfo.com")!=-1)
            {
                if(co.indexOf("topfo.com.LoginName")!=-1)
                {
                    loginnameStr=co.split('=')[1];
                }
                if(co.indexOf("topfo.com_CKData")!=-1)
                {
                    ckdataStr=co.split('=')[1];
                }
            } 
        }
    }
    if(loginnameStr =="" || loginnameStr ==null)
    {
        loginnameStr = ckdataStr;
    }
    if(loginnameStr==null || loginnameStr=="")
   {
      loginnameStr="游客";
      
   }
   document.getElementById("LoginNameID").value=loginnameStr;
   }
   
   
    function crossSubDomainRequest(InfoID) 
    { 

   var lg=document.getElementById("LoginNameID").value;
    var now=new Date();
    var stat=now.toLocaleString();
    var yy=stat.split('年');
    var MM=yy[1].split('月');
    var dd=MM[1].split('日');
    var time=yy[0]+"-"+MM[0]+"-"+dd[0]+dd[1];
    var url="http://member.topfo.com/Access/AddAccess.ashx?InfoID="+InfoID+"&AccessName="+lg+"&AccessTime="+time+"&jsoncallback=?";
    $.getJSON(url,function(msg){

    });
    
    } 

function sendHit(cn)
{
var url="http://member.topfo.com/Access/Hit.ashx?InfoID="+cn+"&jsoncallback=?";

$.getJSON(url,function(msg){

　　document.getElementById("divcountID").innerHTML=msg.name;
});

}

 function Domain()
 {
 var InfoID=document.getElementById("DivInfoID").innerHTML;
    getCookie();
   crossSubDomainRequest(InfoID);
   sendHit(InfoID)
 }

