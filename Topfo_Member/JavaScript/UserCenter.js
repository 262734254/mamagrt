// JScript 文件
             
var ph;      
var phName;                  
function fillGrid(myPH,Func)
{
    phName = myPH;
    ph = window.document.getElementById(myPH);                            
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
    // check for XPath implementation
    /* 
    if( document.implementation.hasFeature("XPath", "3.0") ) 
    { 
        // prototying the XMLDocument 
        XMLDocument.prototype.selectNodes = function(cXPathString, xNode) 
        { 
           if( !xNode ) { xNode = this; } 
           var oNSResolver = this.createNSResolver(this.documentElement) 
           var aItems = this.evaluate(cXPathString, xNode, oNSResolver, 
                        XPathResult.ORDERED_NODE_SNAPSHOT_TYPE, null) 
           var aResult = []; 
           for( var i = 0; i < aItems.snapshotLength; i++) 
           { 
              aResult[i] =   aItems.snapshotItem(i); 
           } 
           return aResult; 
        } 

        // prototying the Element 
        Element.prototype.selectNodes = function(cXPathString) 
        { 
           if(this.ownerDocument.selectNodes) 
           { 
              return this.ownerDocument.selectNodes(cXPathString, this); 
           } 
           else{throw "For XML Elements Only";} 
        } 
    } 
    */
    try
    {                                 
          if(xmlhttp.readyState==4)
          {                                                                
              var row;
              if(navigator.userAgent.indexOf("MSIE")>0)
              {
                row =   xmlhttp.responseXML.selectNodes(".//");
              }
              else
              {
                row = xmlhttp.responseText;
                //row = xmlhttp.responseXML;
              }   
               //alert(row[1].text);
               if(navigator.userAgent.indexOf("MSIE")>0)
               {
                    ph.innerHTML = row[1].text;
               }
               else
               {
                   
                    
                    //alert(row);
                    ph.innerHTML = row;
                    //alert(ph.innerHTML);
                    //var str = "<div>"+ph.innerHTML+"</div>";
                    //ph.innerHTML = str;
                    //ph.innerHTML = ph.innerTEXT;
               }
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
                if($("diyueCount") && $("ctl00_ContentPlaceHolder1_lblMyDingYueCount"))
                    $("ctl00_ContentPlaceHolder1_lblMyDingYueCount").innerHTML = "("+$("diyueCount").innerHTML+")";
                document.getElementById("dgMyDingYue").style.display="block";	           
              }
              if(phName=="dgFocuseMe")
              {
                document.getElementById("UserCenter_FocuseMe").style.display="none";
                document.getElementById("dgFocuseMe").style.display="block";	           
              }
              if(phName=="dgRefresh")
              {
                document.getElementById("UserCenter_Refresh").style.display="none";
                document.getElementById("dgRefresh").style.display="block";	           
              }
              if(phName=="dgCart")
              {
                document.getElementById("UserCenter_Cart").style.display="none";
                if($("ctl00_ContentPlaceHolder1_lblCartCount") && $("shopCartCount"))
                    $("ctl00_ContentPlaceHolder1_lblCartCount").innerHTML = "("+$("shopCartCount").innerHTML+")";
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


function $(id)
{
    return document.getElementById(id);
}

    //去除字符串两边空格的函数
//参数：mystr传入的字符串
//返回：字符串mystr
function trim(mystr){
while ((mystr.indexOf(" ")==0) && (mystr.length>1)){
mystr=mystr.substring(1,mystr.length);
}//去除前面空格
while ((mystr.lastIndexOf(" ")==mystr.length-1)&&(mystr.length>1)){
mystr=mystr.substring(0,mystr.length-1);
}//去除后面空格
if (mystr==" "){
mystr="";
}
return mystr;
}


