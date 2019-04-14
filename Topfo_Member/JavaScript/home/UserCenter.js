// JScript 文件
             
var ph;      
var phName;                  
function fillGrid(myPH,Func)
{
    phName = myPH;
    ph = window.document.getElementById(myPH);                            
    //var url = "http://member2.topfo.com/WebService/UserData.asmx/"+Func;
    var url = "/WebService/UserData.asmx/"+Func;
  
     if(window.XMLHttpRequest)
    {        
        xmlhttp=new XMLHttpRequest();        
    }
    //code for IE
    else    if(window.ActiveXObject)
    {   
        try
        {
            xmlhttp= new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch(e)
        {
            alert("errorrrrrrrrrr");
            try
            {
                xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
            }
            catch(e)
            {
                alert("errrro222222");
            }
        } 
     }                                 
    if(xmlhttp)
    {
        try
        { 	                                                                    
            if(!xmlhttp && typeof XMLHttpRequest!='undefined') 
            {
 
              xmlhttp = new XMLHttpRequest();
            }
                                                        
            xmlhttp.open("get",url, true); 
 
             
            xmlhttp.onreadystatechange = function() 
            {
 
                if(xmlhttp.readyState==4) 
                {   
                                             
                    fillGrid_Change(xmlhttp);
                }
            }
            xmlhttp.send(null);                                            
        }
        catch(e)
        { 
            alert(e.name + ":" + e.message);
        }
    }    
}
function fillGrid_Change()
{
    try
    {                                 
          if(xmlhttp.readyState==4)
          {                                                                
              var row =   xmlhttp.responseXML.selectNodes(".//");
              ph.innerHTML = row[1].text;
              if(phName=="dgInner")
              {
                document.getElementById("UserCenter_Inner").style.display="none";
                document.getElementById("dgInner").style.display="block";	           
              }
              if(phName=="dgMsgToMe")
              {
                document.getElementById("UserCenter_divMsgToMe").style.display="none";
                document.getElementById("dgMsgToMe").style.display="block";	           
              }
              
              if(phName=="dgMyDingYue")
              {
                document.getElementById("UserCenter_DingYue").style.display="none";
                document.getElementById("dgMyDingYue").style.display="block";	           
              }
              if(phName=="dgFocuseMe")
              {
                document.getElementById("UserCenter_FocuseMe").style.display="none";
                document.getElementById("dgFocuseMe").style.display="block";	           
              }
              if(phName=="dgCart")
              {
                document.getElementById("UserCenter_Cart").style.display="none";
                document.getElementById("dgCart").style.display="block";	           
              }
            
              
          }
          else
          {
            alert("xmlhttp.readyState:"+xmlhttp.readyState);                                  
          }
    }  
     catch(e)
    {
        alert(e.name + ":" + e.message);
    }                              
}                             
