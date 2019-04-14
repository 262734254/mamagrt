// JScript 文件
//Function:     Ajax Chat
//Author:       Siser(Siser0409@163.com)
//Modify Date:  2007-10-1
var Request=new function()
{
  
    /**
     * 创建新的通信对象
     * @return 一个新的通信对象
     */
    this.createInstance=function()
    {
        var instance=null;
        if (window.XMLHttpRequest)
        {
            //mozilla
            instance=new XMLHttpRequest();
            //有些版本的Mozilla浏览器处理服务器返回的未包含XML mime-type头部信息的内容时会出错。因此，要确保返回的内容包含text/xml信息
            if (instance.overrideMimeType)
            {
                instance.overrideMimeType="text/xml";
            }
        }
        else if (window.ActiveXObject)
        {
            //IE
            var MSXML = ['MSXML2.XMLHTTP.5.0', 'Microsoft.XMLHTTP', 'MSXML2.XMLHTTP.4.0', 'MSXML2.XMLHTTP.3.0', 'MSXML2.XMLHTTP'];
            for(var i = 0; i < MSXML.length; i++)
            {
                try
                {
                    instance = new ActiveXObject(MSXML[i]);
                    break;
                }
                catch(e)
                {                    
                }
            }
        }
        return instance;
    }
    /////////////////////////////////
    ////////////////检查
  
   this.CheckName = function(obj,divid)
   {
        var _url = "../Register/Control/ResponseAjax.aspx?type=name&name="+ obj.value +"&p="+(new Date).getTime();
         this.Chat(_url,obj,divid);
        

      
   }
  
   
   this.Chat = function(url,obj,divid)
   {
        var _url = url; 
        var _asynchronous = true;
        var instance = this.createInstance();
        //var result = new Result;
        instance.open("GET",_url,_asynchronous);
        instance.send(null);
        
      instance.onreadystatechange=function()
        {
            if (instance.readyState == 4) // 判断对象状态            {
                if (instance.status == 200) // 信息已经成功返回，开始处理信息                {
                    if(obj)
                    { 
                        if(instance.responseText == "0") //=0可用
                        {  
                           document.getElementById(divid).innerHTML="";
                           document.getElementById(divid).style.display="none";
                           invite = true;

                        }
                        else　if(instance.responseText == "1") //不可用
                         { 
                          document.getElementById(divid).innerHTML="用户名已经存在";
                          document.getElementById(divid).style.display="inline";
                          invite = false;

                            
                         }    
                        else
                          {
                            document.getElementById(divid).innerHTML="*";
                            document.getElementById(divid).style.display="inline";
                          }
                     }
                   
                }
                else
                {

                }
            }
        }
     }
 
}

function $(id)
{
    return document.getElementById(id);
}